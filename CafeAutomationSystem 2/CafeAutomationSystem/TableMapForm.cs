using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace CafeAutomationSystem
{
    public class TableMapForm : Form
    {
        private readonly Color ColorFree     = Color.FromArgb(60,  180, 110);
        private readonly Color ColorOccupied = Color.FromArgb(220, 70,  60);
        private readonly Color ColorWaiting  = Color.FromArgb(249, 198, 66);

        private FlowLayoutPanel tablePanel;
        private Label           lblTitle;
        private Panel           legendPanel;

        public TableMapForm()
        {
            this.Text          = "Карта столов — Aurora Cafe";
            this.ClientSize    = new Size(760, 530);
            this.BackColor     = Color.FromArgb(245, 247, 251);
            this.Font          = new Font("Segoe UI", 10F);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize   = new Size(600, 420);
            BuildLayout();
            LoadTables();
        }

        private void BuildLayout()
        {
            var header = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.FromArgb(33, 41, 54) };
            lblTitle = new Label { Text = "Схема зала", Dock = DockStyle.Fill, Font = new Font("Segoe UI Semibold", 14F), ForeColor = Color.White, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(16, 0, 0, 0) };
            header.Controls.Add(lblTitle);

            legendPanel = new Panel { Dock = DockStyle.Bottom, Height = 42, BackColor = Color.White, Padding = new Padding(12, 0, 12, 0) };
            BuildLegend();

            tablePanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(16) };

            this.Controls.Add(tablePanel);
            this.Controls.Add(legendPanel);
            this.Controls.Add(header);
        }

        private void BuildLegend()
        {
            legendPanel.Controls.Clear();
            var flow = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(0, 10, 0, 0) };

            foreach (var item in new[] { ("Свободен", ColorFree), ("Занят", ColorOccupied), ("Ожидает оплаты", ColorWaiting) })
            {
                flow.Controls.Add(new Panel { Size = new Size(14, 14), BackColor = item.Item2, Margin = new Padding(2, 2, 4, 0) });
                flow.Controls.Add(new Label { Text = item.Item1, AutoSize = true, Margin = new Padding(0, 0, 18, 0) });
            }

            var btnRefresh = new Button { Text = "Обновить", Dock = DockStyle.Right, Width = 100, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(33, 41, 54), ForeColor = Color.White, Font = new Font("Segoe UI", 8.5F), Cursor = Cursors.Hand };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => LoadTables();

            legendPanel.Controls.Add(flow);
            legendPanel.Controls.Add(btnRefresh);
        }

        private void LoadTables()
        {
            tablePanel.SuspendLayout();
            tablePanel.Controls.Clear();
            try
            {
                using (var conn = DbHelper.GetOpenConnection())
                using (var cmd = new SQLiteCommand("SELECT Number, Capacity, Status FROM Tables ORDER BY Number", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int    n    = Convert.ToInt32(r["Number"]);
                        int    cap  = Convert.ToInt32(r["Capacity"]);
                        string stat = r["Status"] == null ? "Free" : r["Status"].ToString();
                        tablePanel.Controls.Add(MakeTableButton(n, cap, stat));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tablePanel.ResumeLayout();
        }

        private Button MakeTableButton(int n, int cap, string status)
        {
            Color bg = StatusColor(status);
            var btn = new Button { Text = "Стол " + n + "\r\n" + cap + " мест", Size = new Size(120, 96), Margin = new Padding(8), FlatStyle = FlatStyle.Flat, BackColor = bg, ForeColor = Color.White, Font = new Font("Segoe UI Semibold", 10.5F), Cursor = Cursors.Hand, Tag = n };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(Math.Max(0, bg.R - 25), Math.Max(0, bg.G - 25), Math.Max(0, bg.B - 25));
            btn.Click += TableButton_Click;
            return btn;
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            var btn    = (Button)sender;
            int n      = (int)btn.Tag;
            string cur = DbHelper.GetTableStatus(n);
            var menu   = new ContextMenuStrip();
            menu.Font  = new Font("Segoe UI", 9.5F);

            if (cur == "Free")
                menu.Items.Add("Открыть заказ", null, (s, ev) => { DbHelper.SetTableStatus(n, "Occupied"); LoadTables(); });

            if (cur == "Occupied")
                menu.Items.Add("Ожидает оплаты", null, (s, ev) => { DbHelper.SetTableStatus(n, "WaitingPayment"); LoadTables(); });

            if (cur != "Free")
                menu.Items.Add("Освободить стол", null, (s, ev) =>
                {
                    if (MessageBox.Show("Освободить стол " + n + "?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    { DbHelper.SetTableStatus(n, "Free"); LoadTables(); }
                });

            if (menu.Items.Count > 0)
                menu.Show(btn, new Point(0, btn.Height));
        }

        private Color StatusColor(string status)
        {
            if (status == "Occupied")       return ColorOccupied;
            if (status == "WaitingPayment") return ColorWaiting;
            return ColorFree;
        }
    }
}
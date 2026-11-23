using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CafeAutomationSystem
{
    public partial class Form1 : Form
    {
        // Роль пользователя
        private string currentUserRole = "Admin";

        // Цена выбранного блюда
        private int currentPrice = 0;

        // Категории, которые показываем как кнопки на странице Продажи
        private static readonly string[] SalesCategories =
            { "Все", "Завтраки", "Супы", "Горячее", "Салаты", "Десерты", "Напитки" };

        // Текущая выбранная категория на странице Продажи
        private string selectedSalesCategory = "Все";

        // Активная кнопка категории (для подсветки)
        private Button activeCategoryButton = null;

        public Form1()
        {
            InitializeComponent();

            ApplyModernStyle();

            // Кнопки меню
            btnStats.Click  += btnStats_Click;
            btnSales.Click  += btnSales_Click;
            btnMenu.Click   += btnMenu_Click;
            btnAccess.Click += btnAccess_Click;

            // Пользователи
            btnAddUser.Click    += btnAddUser_Click;
            btnDeleteUser.Click += btnDeleteUser_Click;

            // Меню
            btnAddFood.Click += btnAddFood_Click;

            // Заказы
            btnAddToOrder.Click += btnAddToOrder_Click;
            btnSaveOrder.Click  += btnSaveOrder_Click;

            // ComboBox блюд
            cmbFoods.SelectedIndexChanged += cmbFoods_SelectedIndexChanged;

            // Таймер часов
            timerClock.Tick += timerClock_Tick;

            // Адаптивная разметка — пересчёт позиций при изменении размера окна
            this.Resize += (s, ev) => RelayoutPages();
        }

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelper.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось инициализировать базу: " + ex.Message);
                return;
            }

            ApplyRole();
            HighlightNav(btnStats);
            ShowPanel(panelStats);

            // Колонки таблицы заказов
            if (dgvOrders.Columns.Count == 0)
            {
                dgvOrders.Columns.Add("Food",  "Блюдо");
                dgvOrders.Columns.Add("Qty",   "Кол-во");
                dgvOrders.Columns.Add("Price", "Сумма");
                dgvOrders.Columns["Food"].AutoSizeMode  = DataGridViewAutoSizeColumnMode.Fill;
                dgvOrders.Columns["Qty"].Width   = 80;
                dgvOrders.Columns["Price"].Width = 100;
            }

            // Колонки последних заказов
            if (dgvRecent.Columns.Count == 0)
            {
                dgvRecent.Columns.Add("RecTime",  "Время");
                dgvRecent.Columns.Add("RecTable", "Стол");
                dgvRecent.Columns.Add("RecSum",   "Сумма");
                dgvRecent.Columns["RecTime"].Width  = 90;
                dgvRecent.Columns["RecTable"].Width = 60;
                dgvRecent.Columns["RecSum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Список категорий для добавления блюда (страница «Меню»)
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Все");
            cmbCategory.Items.Add("Завтраки");
            cmbCategory.Items.Add("Супы");
            cmbCategory.Items.Add("Горячее");
            cmbCategory.Items.Add("Салаты");
            cmbCategory.Items.Add("Десерты");
            cmbCategory.Items.Add("Напитки");
            cmbCategory.SelectedIndex = 0;

            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");
            cmbRole.Items.Add("Intern");

            // Кнопки категорий на странице «Продажи»
            BuildCategoryButtons();

            LoadUsers();
            LoadMenu();
            LoadTables();
            LoadFoods();
            LoadChart();
            LoadRecentOrders();
            UpdateStats();
            UpdateMonthCard();

            // Часы
            UpdateClock();
            timerClock.Start();

            // Первичная расстановка адаптивных блоков
            RelayoutPages();
        }

        // ============================================================
        //  АДАПТИВНАЯ РАЗМЕТКА
        //  Вызывается из Form1_Load и при изменении размера окна.
        //  Пересчитывает позиции/размеры карточек так, чтобы они
        //  помещались на текущей ширине, не вылезая за край.
        // ============================================================
        private void RelayoutPages()
        {
            if (panelStats == null || panelSales == null) return;
            LayoutStatsPage();
            LayoutSalesPage();
        }

        private void LayoutStatsPage()
        {
            // Доступная ширина страницы статистики
            int availW = panelStats.ClientSize.Width
                         - panelStats.Padding.Left - panelStats.Padding.Right;
            int availH = panelStats.ClientSize.Height
                         - panelStats.Padding.Top  - panelStats.Padding.Bottom;
            int x0 = panelStats.Padding.Left;
            int y0 = panelStats.Padding.Top;

            int gap   = 12;
            int cardH = 82;
            int cardW = (availW - gap * 3) / 4;     // 4 карточки в ряд
            if (cardW < 130) cardW = 130;

            int cardY = y0 + 36;                    // под заголовком "Статистика"

            panelRevenue .SetBounds(x0,                       cardY, cardW, cardH);
            panelProfit  .SetBounds(x0 + (cardW + gap),       cardY, cardW, cardH);
            panelOrders  .SetBounds(x0 + (cardW + gap) * 2,   cardY, cardW, cardH);
            panelAvgCheck.SetBounds(x0 + (cardW + gap) * 3,   cardY, cardW, cardH);

            // График + карточка "За этот месяц" под карточками
            int chartY      = cardY + cardH + 12;
            int monthCardW  = 200;
            int chartW      = availW - monthCardW - gap;
            int chartH      = availH - (chartY - y0) - 8;
            if (chartH < 200) chartH = 200;

            panelChart    .SetBounds(x0,                  chartY, chartW,     chartH);
            panelMonthCard.SetBounds(x0 + chartW + gap,   chartY, monthCardW, chartH);
        }

        private void LayoutSalesPage()
        {
            int availW = panelSales.ClientSize.Width
                         - panelSales.Padding.Left - panelSales.Padding.Right;
            int availH = panelSales.ClientSize.Height
                         - panelSales.Padding.Top  - panelSales.Padding.Bottom;
            int x0 = panelSales.Padding.Left;
            int y0 = panelSales.Padding.Top;

            int gap        = 12;
            int rightColW  = 240;                  // ширина правой колонки
            int leftW      = availW - rightColW - gap;
            if (leftW < 380) leftW = 380;

            // Категории — растягиваются по ширине левой части
            flowCategories.SetBounds(x0, y0 + 28, leftW, 36);

            // Грид заказа — растягивается на всю оставшуюся высоту
            int gridY = y0 + 128;
            int gridH = availH - (gridY - y0) - 6;
            if (gridH < 160) gridH = 160;
            dgvOrders.SetBounds(x0, gridY, leftW, gridH);

            // Правая колонка: ИТОГО (фикс. высота) + Последние заказы (на оставшееся)
            int rightX     = x0 + leftW + gap;
            int totalCardH = 118;
            panelTotalCard .SetBounds(rightX, y0 + 28,                    rightColW, totalCardH);
            panelRecentCard.SetBounds(rightX, y0 + 28 + totalCardH + gap, rightColW,
                                      availH - 28 - totalCardH - gap - 6);
        }

        // ----- Современный дизайн -----
        private void ApplyModernStyle()
        {
            // Цветовая палитра
            Color sidebar  = Color.FromArgb(33, 41, 54);
            Color content  = Color.FromArgb(245, 247, 251);
            Color accent   = Color.FromArgb(255, 138, 0);
            Color cardBg   = Color.White;

            this.Font = new Font("Segoe UI", 9.5F);
            this.BackColor = content;

            // Боковое меню
            panelMenu.BackColor = sidebar;
            panelMenu.Width = 180;

            StyleNavButton(btnStats,  "📊  Статистика", accent);
            StyleNavButton(btnSales,  "🧾  Продажи",    accent);
            StyleNavButton(btnMenu,   "🍽  Меню",        accent);
            StyleNavButton(btnAccess, "👥  Доступ",     accent);

            // Контент
            panelMain.BackColor       = content;
            panelStats.BackColor      = content;
            panelSales.BackColor      = content;
            panelMenuPage.BackColor   = content;
            panelAccess.BackColor     = content;

            // Карточки статистики
            StyleCard(panelRevenue,   cardBg);
            StyleCard(panelProfit,    cardBg);
            StyleCard(panelOrders,    cardBg);
            StyleCard(panelAvgCheck,  cardBg);

            // Карточки на странице «Продажи»
            StyleCard(panelTotalCard,  cardBg);
            StyleCard(panelRecentCard, cardBg);

            // Карточка месячной статистики
            StyleCard(panelMonthCard,  cardBg);

            // Цвет цифр в карточках
            Color metric = Color.FromArgb(33, 41, 54);
            label9.ForeColor  = metric;
            label11.ForeColor = metric;
            label6.ForeColor  = metric;
            label8.ForeColor  = metric;

            Color caption = Color.FromArgb(120, 130, 145);
            label10.ForeColor = caption;
            label12.ForeColor = caption;
            label5.ForeColor  = caption;
            label7.ForeColor  = caption;

            // Грид
            StyleGrid(dataGridView1);
            StyleGrid(dgvMenu);
            StyleGrid(dgvOrders);
            StyleGrid(dgvRecent);

            // Кнопки действий
            StyleActionButton(btnAddUser,    accent);
            StyleActionButton(btnDeleteUser, Color.FromArgb(220, 80, 80));
            StyleActionButton(btnAddFood,    accent);
            StyleActionButton(btnAddToOrder, accent);
            StyleActionButton(btnSaveOrder,  Color.FromArgb(60, 180, 110));

            // Поля
            StyleTextBox(txtName);
            StyleTextBox(txtFoodName);
            StyleTextBox(txtPrice);
            StyleCombo(cmbRole);
            StyleCombo(cmbCategory);
            StyleCombo(cmbFoods);
            StyleCombo(cmbTable);
            numQuantity.BorderStyle = BorderStyle.FixedSingle;
            numQuantity.Font = new Font("Segoe UI", 10F);

            // Заголовки/подписи
            lblPrice.Font = new Font("Segoe UI Semibold", 10F);
            lblPrice.ForeColor = accent;
            lblTotal.Font = new Font("Segoe UI Semibold", 16F);
            lblTotal.ForeColor = metric;

            // График
            chart1.BackColor = content;
            if (chart1.ChartAreas.Count > 0)
                chart1.ChartAreas[0].BackColor = cardBg;
        }

        private void StyleNavButton(Button b, string text, Color accent)
        {
            b.Text = text;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Color.FromArgb(33, 41, 54);
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 9.75F);
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Padding = new Padding(16, 0, 0, 0);
            b.Cursor = Cursors.Hand;
            b.Width = 180;
            b.Height = 40;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 70);
        }

        private void HighlightNav(Button active)
        {
            foreach (Button b in new[] { btnStats, btnSales, btnMenu, btnAccess })
            {
                b.BackColor = Color.FromArgb(33, 41, 54);
                b.ForeColor = Color.White;
            }
            active.BackColor = Color.FromArgb(255, 138, 0);
            active.ForeColor = Color.White;
        }

        private void StyleCard(Panel p, Color bg)
        {
            p.BackColor = bg;
            p.BorderStyle = BorderStyle.None;
            // Padding оставляем тот, что задан в Designer
        }

        private void StyleGrid(DataGridView g)
        {
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.GridColor = Color.FromArgb(230, 233, 240);
            g.EnableHeadersVisualStyles = false;
            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToResizeRows = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.ColumnHeadersHeight = 34;
            g.RowTemplate.Height = 30;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 234, 207);
            g.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 41, 54);
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 41, 54);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
        }

        private void StyleActionButton(Button b, Color accent)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = accent;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI Semibold", 9.75F);
            b.Cursor = Cursors.Hand;
            b.Height = 36;
        }

        private void StyleTextBox(TextBox t)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.Font = new Font("Segoe UI", 10F);
            t.BackColor = Color.White;
        }

        private void StyleCombo(ComboBox c)
        {
            c.FlatStyle = FlatStyle.Flat;
            c.Font = new Font("Segoe UI", 10F);
            c.BackColor = Color.White;
        }

        // ----- Часы в шапке -----
        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            var now = DateTime.Now;
            lblHeaderTime.Text = now.ToString("HH:mm:ss");
            // Формат: «понедельник, 11 мая 2026»
            var ru = CultureInfo.GetCultureInfo("ru-RU");
            lblHeaderDate.Text = now.ToString("dddd, dd MMMM yyyy", ru);
        }

        // ----- Кнопки категорий на странице Продажи -----
        private void BuildCategoryButtons()
        {
            flowCategories.Controls.Clear();
            activeCategoryButton = null;

            for (int i = 0; i < SalesCategories.Length; i++)
            {
                var cat = SalesCategories[i];
                var b = new Button
                {
                    Text = cat,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(2),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI Semibold", 9F),
                    Cursor = Cursors.Hand,
                    Tag = cat,
                    UseCompatibleTextRendering = false
                };
                b.FlatAppearance.BorderSize = 0;
                StyleCategoryButton(b, isActive: cat == selectedSalesCategory);
                b.Click += CategoryButton_Click;

                flowCategories.Controls.Add(b, i, 0);

                if (cat == selectedSalesCategory)
                    activeCategoryButton = b;
            }
        }

        private void StyleCategoryButton(Button b, bool isActive)
        {
            if (isActive)
            {
                b.BackColor = Color.FromArgb(255, 138, 0);
                b.ForeColor = Color.White;
            }
            else
            {
                b.BackColor = Color.White;
                b.ForeColor = Color.FromArgb(33, 41, 54);
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b == null) return;

            if (activeCategoryButton != null)
                StyleCategoryButton(activeCategoryButton, false);

            StyleCategoryButton(b, true);
            activeCategoryButton = b;

            selectedSalesCategory = b.Tag as string ?? "Все";
            LoadFoods();
        }

        // ----- Переключение панелей -----
        void ShowPanel(Panel panel)
        {
            panelStats.Visible    = false;
            panelSales.Visible    = false;
            panelMenuPage.Visible = false;
            panelAccess.Visible   = false;

            panel.Visible = true;
            panel.BringToFront();
        }

        // ----- Роли -----
        void ApplyRole()
        {
            if (currentUserRole == "Admin")
            {
                btnStats.Visible  = true;
                btnAccess.Visible = true;
                btnSales.Visible  = true;
                btnMenu.Visible   = true;
            }
            else if (currentUserRole == "Staff")
            {
                btnStats.Visible  = false;
                btnAccess.Visible = false;
                btnSales.Visible  = true;
                btnMenu.Visible   = true;
            }
            else if (currentUserRole == "Intern")
            {
                btnStats.Visible  = false;
                btnAccess.Visible = false;
                btnSales.Visible  = false;
                btnMenu.Visible   = true;
            }

            if (!btnStats.Visible)
            {
                if (btnSales.Visible)
                {
                    HighlightNav(btnSales);
                    ShowPanel(panelSales);
                }
                else if (btnMenu.Visible)
                {
                    HighlightNav(btnMenu);
                    ShowPanel(panelMenuPage);
                }
            }
        }

        // ----- График: реальные продажи за последние 7 дней -----
        void LoadChart()
        {
            chart1.Series.Clear();

            Series series = new Series("Выручка")
            {
                ChartType = SeriesChartType.SplineArea,
                Color = Color.FromArgb(255, 138, 0),
                BorderWidth = 3,
                BorderColor = Color.FromArgb(255, 138, 0),
                IsVisibleInLegend = false
            };

            // Готовим словарь день → сумма
            var ru = CultureInfo.GetCultureInfo("ru-RU");
            var totals = new Dictionary<DateTime, decimal>();
            var today = DateTime.Today;
            for (int i = 6; i >= 0; i--)
                totals[today.AddDays(-i)] = 0m;

            try
            {
                using (var conn = DbHelper.GetOpenConnection())
                using (var cmd = new SQLiteCommand(
                    @"SELECT date(SaleDate) AS d, SUM(TotalPrice) AS s
                      FROM Sales
                      WHERE date(SaleDate) >= date('now', '-6 days')
                      GROUP BY date(SaleDate)", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        if (r["d"] == DBNull.Value) continue;
                        DateTime d;
                        if (DateTime.TryParse(r["d"].ToString(), out d))
                        {
                            decimal sum = r["s"] == DBNull.Value ? 0 : Convert.ToDecimal(r["s"]);
                            if (totals.ContainsKey(d.Date))
                                totals[d.Date] = sum;
                        }
                    }
                }
            }
            catch
            {
                // если что-то пошло не так — нарисуем нули
            }

            foreach (var kv in totals)
            {
                string label = kv.Key.ToString("dd.MM", ru);
                series.Points.AddXY(label, (double)kv.Value);
            }

            chart1.Series.Add(series);

            if (chart1.ChartAreas.Count > 0)
            {
                var area = chart1.ChartAreas[0];
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 233, 240);
                area.AxisX.LineColor = Color.FromArgb(200, 205, 215);
                area.AxisY.LineColor = Color.FromArgb(200, 205, 215);
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
                area.AxisX.Interval = 1;
            }
        }

        // ----- Карточки статистики (живые цифры) -----
        void UpdateStats()
        {
            try
            {
                using (var conn = DbHelper.GetOpenConnection())
                {
                    decimal revenue = 0;
                    int orders = 0;

                    // Выручка — сумма всех Sales
                    using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(TotalPrice),0) FROM Sales", conn))
                    {
                        var v = cmd.ExecuteScalar();
                        if (v != null && v != DBNull.Value)
                            revenue = Convert.ToDecimal(v);
                    }

                    // Кол-во заказов считаем как уникальные OrderNo (если 0 — fallback на COUNT строк)
                    using (var cmd = new SQLiteCommand(
                        "SELECT COUNT(DISTINCT OrderNo) FROM Sales WHERE OrderNo > 0", conn))
                    {
                        var v = cmd.ExecuteScalar();
                        if (v != null && v != DBNull.Value)
                            orders = Convert.ToInt32(v);
                    }
                    if (orders == 0)
                    {
                        using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Sales", conn))
                        {
                            var v = cmd.ExecuteScalar();
                            if (v != null && v != DBNull.Value)
                                orders = Convert.ToInt32(v);
                        }
                    }

                    decimal avg    = orders > 0 ? revenue / orders : 0;
                    decimal profit = revenue * 0.35m;

                    label9.Text  = $"{revenue:N0} сом";
                    label11.Text = $"{profit:N0} сом";
                    label6.Text  = orders.ToString();
                    label8.Text  = $"{avg:N0} сом";
                }
            }
            catch { /* статистика не критична */ }
        }

        // ----- Пользователи -----
        void LoadUsers()
        {
            using (var conn = DbHelper.GetOpenConnection())
            {
                var adapter = new SQLiteDataAdapter("SELECT Id, Name, Role FROM Users", conn);
                var table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        void AddUser()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            using (var conn = DbHelper.GetOpenConnection())
            using (var cmd = new SQLiteCommand("INSERT INTO Users (Name, Role) VALUES (@name, @role)", conn))
            {
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@role", cmbRole.Text);
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
            txtName.Text = "";
            cmbRole.Text = "";
        }

        void DeleteUser()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            using (var conn = DbHelper.GetOpenConnection())
            using (var cmd = new SQLiteCommand("DELETE FROM Users WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
        }

        // ----- Меню -----
        void LoadMenu()
        {
            using (var conn = DbHelper.GetOpenConnection())
            {
                var adapter = new SQLiteDataAdapter(
                    "SELECT Id, Name AS [Название], Price AS [Цена], Category AS [Категория] FROM MenuItems",
                    conn);
                var table = new DataTable();
                adapter.Fill(table);
                dgvMenu.DataSource = null;
                dgvMenu.DataSource = table;
            }
        }

        void AddFood()
        {
            if (string.IsNullOrWhiteSpace(txtFoodName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text)    ||
                string.IsNullOrWhiteSpace(cmbCategory.Text) ||
                cmbCategory.Text == "Все")
            {
                MessageBox.Show("Заполните название, цену и категорию (не «Все»).");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Введите цену правильно");
                return;
            }

            using (var conn = DbHelper.GetOpenConnection())
            using (var cmd = new SQLiteCommand(
                "INSERT INTO MenuItems (Name, Price, Category) VALUES (@name, @price, @category)", conn))
            {
                cmd.Parameters.AddWithValue("@name",     txtFoodName.Text.Trim());
                cmd.Parameters.AddWithValue("@price",    price);
                cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                cmd.ExecuteNonQuery();
            }   

            MessageBox.Show("Блюдо добавлено");

            LoadMenu();
            LoadFoods();

            txtFoodName.Clear();
            txtPrice.Clear();
        }

        // ----- Загрузка блюд (для cmbFoods на «Продажах») с учётом выбранной категории -----
        void LoadFoods()
        {
            using (var conn = DbHelper.GetOpenConnection())
            {
                string query = "SELECT Name FROM MenuItems";
                bool filter = !string.IsNullOrEmpty(selectedSalesCategory)
                              && selectedSalesCategory != "Все";

                if (filter)
                    query += " WHERE Category = @category";

                query += " ORDER BY Name";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    if (filter)
                        cmd.Parameters.AddWithValue("@category", selectedSalesCategory);

                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbFoods.Items.Clear();
                        currentPrice = 0;
                        lblPrice.Text = "Цена: 0 сом";
                        while (reader.Read())
                            cmbFoods.Items.Add(reader["Name"].ToString());
                    }
                }
            }
        }

        // ----- Загрузка столиков -----
        void LoadTables()
        {
            cmbTable.Items.Clear();
            try
            {
                using (var conn = DbHelper.GetOpenConnection())
                using (var cmd = new SQLiteCommand("SELECT Number FROM Tables ORDER BY Number", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int n = Convert.ToInt32(r["Number"]);
                        cmbTable.Items.Add("Стол " + n);
                    }
                }
            }
            catch { /* пусто — UI не падает */ }

            if (cmbTable.Items.Count > 0)
                cmbTable.SelectedIndex = 0;
        }

        private int GetSelectedTableNumber()
        {
            if (cmbTable.SelectedItem == null) return 0;
            string s = cmbTable.SelectedItem.ToString();
            // "Стол 5" → 5
            int n;
            string digits = new string(System.Linq.Enumerable.ToArray(
                System.Linq.Enumerable.Where(s, ch => char.IsDigit(ch))));
            return int.TryParse(digits, out n) ? n : 0;
        }

        // ----- Цена выбранного блюда -----
        private void cmbFoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFoods.Text)) return;

            using (var conn = DbHelper.GetOpenConnection())
            using (var cmd = new SQLiteCommand("SELECT Price FROM MenuItems WHERE Name = @name LIMIT 1", conn))
            {
                cmd.Parameters.AddWithValue("@name", cmbFoods.Text);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    currentPrice = Convert.ToInt32(Convert.ToDouble(result));
                    lblPrice.Text = "Цена: " + currentPrice + " сом";
                }
            }
        }

        // ----- Заказ -----
        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFoods.Text))
            {
                MessageBox.Show("Выберите блюдо");
                return;
            }

            string food = cmbFoods.Text;
            int qty = (int)numQuantity.Value;
            if (qty <= 0) qty = 1;

            int total = qty * currentPrice;
            dgvOrders.Rows.Add(food, qty, total);
            CalculateTotal();
        }

        void CalculateTotal()
        {
            int total = 0;
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells[2].Value != null)
                    total += Convert.ToInt32(row.Cells[2].Value);
            }
            lblTotal.Text = total.ToString("N0") + " сом";
        }

        void SaveOrder()
        {
            if (dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("Заказ пуст");
                return;
            }

            int tableNumber = GetSelectedTableNumber();
            if (tableNumber <= 0)
            {
                MessageBox.Show("Выберите столик перед сохранением заказа");
                return;
            }

            int orderNo = DbHelper.NextOrderNo();
            string nowIso = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var conn = DbHelper.GetOpenConnection())
            using (var tx = conn.BeginTransaction())
            {
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.Cells[0].Value == null) continue;

                    string food   = row.Cells[0].Value.ToString();
                    int qty       = Convert.ToInt32(row.Cells[1].Value);
                    decimal total = Convert.ToDecimal(row.Cells[2].Value);

                    using (var cmd = new SQLiteCommand(
                        @"INSERT INTO Sales (FoodName, Quantity, TotalPrice, SaleDate, TableNumber, OrderNo)
                          VALUES (@food, @qty, @total, @date, @tableNum, @orderNo)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@food",     food);
                        cmd.Parameters.AddWithValue("@qty",      qty);
                        cmd.Parameters.AddWithValue("@total",    total);
                        cmd.Parameters.AddWithValue("@date",     nowIso);
                        cmd.Parameters.AddWithValue("@tableNum", tableNumber);
                        cmd.Parameters.AddWithValue("@orderNo",  orderNo);
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
            }

            MessageBox.Show($"Заказ #{orderNo} сохранён (Стол {tableNumber})");

            dgvOrders.Rows.Clear();
            lblTotal.Text = "0 сом";

            // автоматическое обновление статистики, графика и списка последних заказов
            UpdateStats();
            UpdateMonthCard();
            LoadChart();
            LoadRecentOrders();
        }

        // ----- Карточка «За этот месяц» -----
        void UpdateMonthCard()
        {
            try
            {
                decimal revenue = 0;
                int orders = 0;
                string top = "—";

                using (var conn = DbHelper.GetOpenConnection())
                {
                    using (var cmd = new SQLiteCommand(
                        @"SELECT IFNULL(SUM(TotalPrice), 0)
                          FROM Sales
                          WHERE strftime('%Y-%m', SaleDate) = strftime('%Y-%m', 'now')", conn))
                    {
                        var v = cmd.ExecuteScalar();
                        if (v != null && v != DBNull.Value)
                            revenue = Convert.ToDecimal(v);
                    }

                    using (var cmd = new SQLiteCommand(
                        @"SELECT COUNT(DISTINCT OrderNo)
                          FROM Sales
                          WHERE OrderNo > 0
                            AND strftime('%Y-%m', SaleDate) = strftime('%Y-%m', 'now')", conn))
                    {
                        var v = cmd.ExecuteScalar();
                        if (v != null && v != DBNull.Value)
                            orders = Convert.ToInt32(v);
                    }
                    if (orders == 0)
                    {
                        using (var cmd = new SQLiteCommand(
                            @"SELECT COUNT(*) FROM Sales
                              WHERE strftime('%Y-%m', SaleDate) = strftime('%Y-%m', 'now')", conn))
                        {
                            var v = cmd.ExecuteScalar();
                            if (v != null && v != DBNull.Value)
                                orders = Convert.ToInt32(v);
                        }
                    }

                    using (var cmd = new SQLiteCommand(
                        @"SELECT FoodName, SUM(Quantity) AS qty
                          FROM Sales
                          WHERE strftime('%Y-%m', SaleDate) = strftime('%Y-%m', 'now')
                          GROUP BY FoodName
                          ORDER BY qty DESC
                          LIMIT 1", conn))
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read() && r["FoodName"] != DBNull.Value)
                            top = r["FoodName"].ToString();
                    }
                }

                decimal profit = revenue * 0.35m;

                lblMonthProfit.Text = $"{profit:N0} сом";
                lblMonthOrders.Text = orders.ToString();
                lblMonthTop.Text    = top;
            }
            catch { /* не критично */ }
        }

        // ----- Список последних заказов (правая карточка на «Продажах») -----
        void LoadRecentOrders()
        {
            dgvRecent.Rows.Clear();
            try
            {
                using (var conn = DbHelper.GetOpenConnection())
                using (var cmd = new SQLiteCommand(
                    @"SELECT OrderNo,
                             MAX(SaleDate)    AS LastDate,
                             MAX(TableNumber) AS TblNum,
                             SUM(TotalPrice)  AS Sum
                      FROM Sales
                      WHERE OrderNo > 0
                      GROUP BY OrderNo
                      ORDER BY OrderNo DESC
                      LIMIT 10", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        DateTime dt;
                        string when = r["LastDate"]?.ToString() ?? "";
                        if (DateTime.TryParse(when, out dt))
                            when = dt.ToString("HH:mm");

                        int tbl   = r["TblNum"] == DBNull.Value ? 0 : Convert.ToInt32(r["TblNum"]);
                        decimal s = r["Sum"]    == DBNull.Value ? 0 : Convert.ToDecimal(r["Sum"]);

                        dgvRecent.Rows.Add(when, "№" + tbl, s.ToString("N0") + " сом");
                    }
                }
            }
            catch { /* не критично */ }
        }

        // ----- Кнопки -----
        private void btnStats_Click(object sender, EventArgs e)
        {
            HighlightNav(btnStats);
            ShowPanel(panelStats);
            UpdateStats();
            UpdateMonthCard();
            LoadChart();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            HighlightNav(btnSales);
            ShowPanel(panelSales);
            LoadRecentOrders();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            HighlightNav(btnMenu);
            ShowPanel(panelMenuPage);
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            HighlightNav(btnAccess);
            ShowPanel(panelAccess);
        }

        private void btnAddUser_Click(object sender, EventArgs e)    { AddUser(); }
        private void btnDeleteUser_Click(object sender, EventArgs e) { DeleteUser(); }
        private void btnAddFood_Click(object sender, EventArgs e)    { AddFood(); }
        private void btnSaveOrder_Click(object sender, EventArgs e)  { SaveOrder(); }

        // Пустые события (нужны Designer-у)
        private void label1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panelMenuPage_Paint(object sender, PaintEventArgs e) { }

        // Категория на странице «Меню» (для добавления блюд) — обновляет cmbFoods на Продажах
        // только если выбрано «Все», иначе фильтр Продаж задаёт пользователь кнопками.
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Список cmbFoods зависит только от selectedSalesCategory,
            // вызываем LoadFoods чтобы обновить, если меню изменилось.
            LoadFoods();
        }
    }
}

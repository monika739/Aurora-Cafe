using System.Windows.Forms;

namespace CafeAutomationSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 =
                new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 =
                new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 =
                new System.Windows.Forms.DataVisualization.Charting.Series();

            this.panelMenu       = new System.Windows.Forms.Panel();
            this.lblBrand        = new System.Windows.Forms.Label();
            this.btnAccess       = new System.Windows.Forms.Button();
            this.btnMenu         = new System.Windows.Forms.Button();
            this.btnSales        = new System.Windows.Forms.Button();
            this.btnStats        = new System.Windows.Forms.Button();

            this.panelMain       = new System.Windows.Forms.Panel();

            // ---- Header ----
            this.panelHeader     = new System.Windows.Forms.Panel();
            this.lblHeaderTitle  = new System.Windows.Forms.Label();
            this.lblHeaderDate   = new System.Windows.Forms.Label();
            this.lblHeaderTime   = new System.Windows.Forms.Label();
            this.timerClock      = new System.Windows.Forms.Timer(this.components);

            this.panelStats      = new System.Windows.Forms.Panel();
            this.lblStatsTitle   = new System.Windows.Forms.Label();
            this.panelAvgCheck   = new System.Windows.Forms.Panel();
            this.label8          = new System.Windows.Forms.Label();
            this.label7          = new System.Windows.Forms.Label();
            this.panelOrders     = new System.Windows.Forms.Panel();
            this.label6          = new System.Windows.Forms.Label();
            this.label5          = new System.Windows.Forms.Label();
            this.panelProfit     = new System.Windows.Forms.Panel();
            this.label11         = new System.Windows.Forms.Label();
            this.label12         = new System.Windows.Forms.Label();
            this.panelRevenue    = new System.Windows.Forms.Panel();
            this.label9          = new System.Windows.Forms.Label();
            this.label10         = new System.Windows.Forms.Label();
            this.panelChart      = new System.Windows.Forms.Panel();
            this.chart1          = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // ---- Карточка «За этот месяц» ----
            this.panelMonthCard      = new System.Windows.Forms.Panel();
            this.lblMonthTitle       = new System.Windows.Forms.Label();
            this.lblMonthProfitCap   = new System.Windows.Forms.Label();
            this.lblMonthProfit      = new System.Windows.Forms.Label();
            this.lblMonthOrdersCap   = new System.Windows.Forms.Label();
            this.lblMonthOrders      = new System.Windows.Forms.Label();
            this.lblMonthTopCap      = new System.Windows.Forms.Label();
            this.lblMonthTop         = new System.Windows.Forms.Label();

            this.panelSales      = new System.Windows.Forms.Panel();
            this.lblSalesTitle   = new System.Windows.Forms.Label();
            this.flowCategories  = new System.Windows.Forms.TableLayoutPanel();
            this.lblTable        = new System.Windows.Forms.Label();
            this.cmbTable        = new System.Windows.Forms.ComboBox();
            this.lblFood         = new System.Windows.Forms.Label();
            this.lblQty          = new System.Windows.Forms.Label();
            this.cmbFoods        = new System.Windows.Forms.ComboBox();
            this.numQuantity     = new System.Windows.Forms.NumericUpDown();
            this.btnAddToOrder   = new System.Windows.Forms.Button();
            this.btnSaveOrder    = new System.Windows.Forms.Button();
            this.lblTotal        = new System.Windows.Forms.Label();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblPrice        = new System.Windows.Forms.Label();
            this.dgvOrders       = new System.Windows.Forms.DataGridView();
            this.panelTotalCard  = new System.Windows.Forms.Panel();
            this.panelRecentCard = new System.Windows.Forms.Panel();
            this.lblRecentTitle  = new System.Windows.Forms.Label();
            this.dgvRecent       = new System.Windows.Forms.DataGridView();

            this.panelMenuPage   = new System.Windows.Forms.Panel();
            this.lblMenuTitle    = new System.Windows.Forms.Label();
            this.lblFoodName     = new System.Windows.Forms.Label();
            this.lblFoodPriceLbl = new System.Windows.Forms.Label();
            this.lblCategoryLbl  = new System.Windows.Forms.Label();
            this.txtFoodName     = new System.Windows.Forms.TextBox();
            this.txtPrice        = new System.Windows.Forms.TextBox();
            this.cmbCategory     = new System.Windows.Forms.ComboBox();
            this.btnAddFood      = new System.Windows.Forms.Button();
            this.dgvMenu         = new System.Windows.Forms.DataGridView();

            this.panelAccess     = new System.Windows.Forms.Panel();
            this.lblAccessTitle  = new System.Windows.Forms.Label();
            this.lblUserName     = new System.Windows.Forms.Label();
            this.lblUserRole     = new System.Windows.Forms.Label();
            this.txtName         = new System.Windows.Forms.TextBox();
            this.cmbRole         = new System.Windows.Forms.ComboBox();
            this.btnAddUser      = new System.Windows.Forms.Button();
            this.btnDeleteUser   = new System.Windows.Forms.Button();
            this.dataGridView1   = new System.Windows.Forms.DataGridView();

            this.panelMenu.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelAvgCheck.SuspendLayout();
            this.panelOrders.SuspendLayout();
            this.panelProfit.SuspendLayout();
            this.panelRevenue.SuspendLayout();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panelMonthCard.SuspendLayout();
            this.panelSales.SuspendLayout();
            this.panelTotalCard.SuspendLayout();
            this.panelRecentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panelMenuPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.panelAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            //
            // panelMenu (боковое меню)
            //
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(33, 41, 54);
            this.panelMenu.Controls.Add(this.btnAccess);
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Controls.Add(this.btnSales);
            this.panelMenu.Controls.Add(this.btnStats);
            this.panelMenu.Controls.Add(this.lblBrand);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 720);

            //
            // lblBrand
            //
            this.lblBrand.AutoSize = false;
            this.lblBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBrand.Height = 70;
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Text = "☕  CAFÉ";
            this.lblBrand.BackColor = System.Drawing.Color.FromArgb(28, 35, 46);

            //
            // btnStats
            //
            this.btnStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStats.Height = 40;
            this.btnStats.Text = "Статистика";
            this.btnStats.Name = "btnStats";

            //
            // btnSales
            //
            this.btnSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSales.Height = 40;
            this.btnSales.Text = "Продажи";
            this.btnSales.Name = "btnSales";

            //
            // btnMenu
            //
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.Height = 40;
            this.btnMenu.Text = "Меню";
            this.btnMenu.Name = "btnMenu";

            //
            // btnAccess
            //
            this.btnAccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccess.Height = 40;
            this.btnAccess.Text = "Доступ";
            this.btnAccess.Name = "btnAccess";

            //
            // panelMain
            //
            this.panelMain.Controls.Add(this.panelMenuPage);
            this.panelMain.Controls.Add(this.panelAccess);
            this.panelMain.Controls.Add(this.panelSales);
            this.panelMain.Controls.Add(this.panelStats);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Name = "panelMain";

            // ===========================================================
            // panelHeader  (верхняя полоса с датой и временем)
            // ===========================================================
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 46;
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Controls.Add(this.lblHeaderTime);
            this.panelHeader.Controls.Add(this.lblHeaderDate);

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(33, 41, 54);
            this.lblHeaderTitle.Location = new System.Drawing.Point(18, 13);
            this.lblHeaderTitle.Text = "POS Кафе";

            this.lblHeaderTime.AutoSize = false;
            this.lblHeaderTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHeaderTime.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblHeaderTime.ForeColor = System.Drawing.Color.FromArgb(255, 138, 0);
            this.lblHeaderTime.Size = new System.Drawing.Size(100, 22);
            this.lblHeaderTime.Location = new System.Drawing.Point(820, 12);
            this.lblHeaderTime.Text = "00:00:00";

            this.lblHeaderDate.AutoSize = false;
            this.lblHeaderDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHeaderDate.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderDate.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            this.lblHeaderDate.Size = new System.Drawing.Size(200, 20);
            this.lblHeaderDate.Location = new System.Drawing.Point(615, 14);
            this.lblHeaderDate.Text = "—";

            //
            // timerClock
            //
            this.timerClock.Interval = 1000;
            this.timerClock.Enabled = false; // включаем в Form1.cs

            // ===========================================================
            // panelStats
            // ===========================================================
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStats.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.panelStats.Controls.Add(this.panelMonthCard);
            this.panelStats.Controls.Add(this.panelChart);
            this.panelStats.Controls.Add(this.panelAvgCheck);
            this.panelStats.Controls.Add(this.panelOrders);
            this.panelStats.Controls.Add(this.panelProfit);
            this.panelStats.Controls.Add(this.panelRevenue);
            this.panelStats.Controls.Add(this.lblStatsTitle);
            this.panelStats.Visible = false;
            this.panelStats.AutoScroll = true;

            this.lblStatsTitle.AutoSize = true;
            this.lblStatsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblStatsTitle.Location = new System.Drawing.Point(20, 8);
            this.lblStatsTitle.Text = "Статистика";

            // карточки — стартовые размеры; реальные позиции будут пересчитаны в LayoutStatsPage()
            int cardY = 44;
            int cardW = 175;
            int cardH = 82;
            int gap   = 12;
            int x0    = 20;

            this.panelRevenue.Location = new System.Drawing.Point(x0,                 cardY);
            this.panelRevenue.Size     = new System.Drawing.Size(cardW, cardH);
            this.panelRevenue.Controls.Add(this.label9);
            this.panelRevenue.Controls.Add(this.label10);

            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(14, 10);
            this.label10.Text = "Выручка";

            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.label9.Location = new System.Drawing.Point(14, 36);
            this.label9.Text = "0 сом";

            this.panelProfit.Location = new System.Drawing.Point(x0 + (cardW + gap),  cardY);
            this.panelProfit.Size     = new System.Drawing.Size(cardW, cardH);
            this.panelProfit.Controls.Add(this.label11);
            this.panelProfit.Controls.Add(this.label12);

            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(14, 10);
            this.label12.Text = "Прибыль";

            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.label11.Location = new System.Drawing.Point(14, 36);
            this.label11.Text = "0 сом";

            this.panelOrders.Location = new System.Drawing.Point(x0 + (cardW + gap)*2, cardY);
            this.panelOrders.Size     = new System.Drawing.Size(cardW, cardH);
            this.panelOrders.Controls.Add(this.label6);
            this.panelOrders.Controls.Add(this.label5);

            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(14, 10);
            this.label5.Text = "Заказы";

            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.label6.Location = new System.Drawing.Point(14, 36);
            this.label6.Text = "0";

            this.panelAvgCheck.Location = new System.Drawing.Point(x0 + (cardW + gap)*3, cardY);
            this.panelAvgCheck.Size     = new System.Drawing.Size(cardW, cardH);
            this.panelAvgCheck.Controls.Add(this.label8);
            this.panelAvgCheck.Controls.Add(this.label7);

            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(14, 10);
            this.label7.Text = "Средний чек";

            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.label8.Location = new System.Drawing.Point(14, 36);
            this.label8.Text = "0 сом";

            // График — белая карточка (стартовые размеры; пересчитываются в LayoutStatsPage())
            int chartY = cardY + cardH + 12;
            int chartW = (cardW + gap)*3 - gap;
            this.panelChart.Location  = new System.Drawing.Point(x0, chartY);
            this.panelChart.Size      = new System.Drawing.Size(chartW, 300);
            this.panelChart.BackColor = System.Drawing.Color.White;
            this.panelChart.Padding   = new System.Windows.Forms.Padding(10);
            this.panelChart.Controls.Add(this.chart1);

            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Name = "chart1";

            // ----- Карточка «За этот месяц» рядом с графиком -----
            this.panelMonthCard.Location = new System.Drawing.Point(x0 + chartW + gap, chartY);
            this.panelMonthCard.Size     = new System.Drawing.Size(cardW, 300);
            this.panelMonthCard.BackColor = System.Drawing.Color.White;
            this.panelMonthCard.Padding  = new System.Windows.Forms.Padding(14);
            this.panelMonthCard.Controls.Add(this.lblMonthTop);
            this.panelMonthCard.Controls.Add(this.lblMonthTopCap);
            this.panelMonthCard.Controls.Add(this.lblMonthOrders);
            this.panelMonthCard.Controls.Add(this.lblMonthOrdersCap);
            this.panelMonthCard.Controls.Add(this.lblMonthProfit);
            this.panelMonthCard.Controls.Add(this.lblMonthProfitCap);
            this.panelMonthCard.Controls.Add(this.lblMonthTitle);

            this.lblMonthTitle.AutoSize = true;
            this.lblMonthTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblMonthTitle.ForeColor = System.Drawing.Color.FromArgb(33, 41, 54);
            this.lblMonthTitle.Location = new System.Drawing.Point(14, 12);
            this.lblMonthTitle.Text = "За этот месяц";

            this.lblMonthProfitCap.AutoSize = true;
            this.lblMonthProfitCap.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMonthProfitCap.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            this.lblMonthProfitCap.Location = new System.Drawing.Point(14, 46);
            this.lblMonthProfitCap.Text = "Прибыль";

            this.lblMonthProfit.AutoSize = true;
            this.lblMonthProfit.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblMonthProfit.ForeColor = System.Drawing.Color.FromArgb(60, 180, 110);
            this.lblMonthProfit.Location = new System.Drawing.Point(14, 64);
            this.lblMonthProfit.Text = "0 сом";

            this.lblMonthOrdersCap.AutoSize = true;
            this.lblMonthOrdersCap.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMonthOrdersCap.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            this.lblMonthOrdersCap.Location = new System.Drawing.Point(14, 112);
            this.lblMonthOrdersCap.Text = "Заказы";

            this.lblMonthOrders.AutoSize = true;
            this.lblMonthOrders.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblMonthOrders.ForeColor = System.Drawing.Color.FromArgb(33, 41, 54);
            this.lblMonthOrders.Location = new System.Drawing.Point(14, 130);
            this.lblMonthOrders.Text = "0";

            this.lblMonthTopCap.AutoSize = true;
            this.lblMonthTopCap.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMonthTopCap.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            this.lblMonthTopCap.Location = new System.Drawing.Point(14, 178);
            this.lblMonthTopCap.Text = "Топ блюдо";

            this.lblMonthTop.AutoSize = false;
            this.lblMonthTop.Size = new System.Drawing.Size(150, 50);
            this.lblMonthTop.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblMonthTop.ForeColor = System.Drawing.Color.FromArgb(255, 138, 0);
            this.lblMonthTop.Location = new System.Drawing.Point(14, 196);
            this.lblMonthTop.Text = "—";

            // ===========================================================
            // panelSales  (POS-вид)
            // ===========================================================
            this.panelSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSales.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.panelSales.AutoScroll = true;
            this.panelSales.Controls.Add(this.panelRecentCard);
            this.panelSales.Controls.Add(this.panelTotalCard);
            this.panelSales.Controls.Add(this.dgvOrders);
            this.panelSales.Controls.Add(this.btnAddToOrder);
            this.panelSales.Controls.Add(this.numQuantity);
            this.panelSales.Controls.Add(this.cmbFoods);
            this.panelSales.Controls.Add(this.cmbTable);
            this.panelSales.Controls.Add(this.lblQty);
            this.panelSales.Controls.Add(this.lblFood);
            this.panelSales.Controls.Add(this.lblTable);
            this.panelSales.Controls.Add(this.lblPrice);
            this.panelSales.Controls.Add(this.flowCategories);
            this.panelSales.Controls.Add(this.lblSalesTitle);
            this.panelSales.Visible = false;

            this.lblSalesTitle.AutoSize = true;
            this.lblSalesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblSalesTitle.Location = new System.Drawing.Point(16, 6);
            this.lblSalesTitle.Text = "Продажи";

            // Кнопки категорий — TableLayoutPanel 7 равных колонок (всегда помещаются)
            this.flowCategories.Location = new System.Drawing.Point(16, 36);
            this.flowCategories.Size = new System.Drawing.Size(560, 36);
            this.flowCategories.ColumnCount = 7;
            for (int _i = 0; _i < 7; _i++)
                this.flowCategories.ColumnStyles.Add(
                    new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / 7F));
            this.flowCategories.RowCount = 1;
            this.flowCategories.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flowCategories.BackColor = System.Drawing.Color.Transparent;
            this.flowCategories.Padding = new System.Windows.Forms.Padding(0);
            this.flowCategories.Margin = new System.Windows.Forms.Padding(0);
            this.flowCategories.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                 | System.Windows.Forms.AnchorStyles.Left
                 | System.Windows.Forms.AnchorStyles.Right));

            // Стол / Блюдо / Кол-во / + В заказ
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTable.Location = new System.Drawing.Point(16, 80);
            this.lblTable.Text = "Столик";

            this.cmbTable.Location = new System.Drawing.Point(16, 98);
            this.cmbTable.Size = new System.Drawing.Size(108, 25);
            this.cmbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTable.Name = "cmbTable";

            this.lblFood.AutoSize = true;
            this.lblFood.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFood.Location = new System.Drawing.Point(132, 80);
            this.lblFood.Text = "Блюдо";

            this.cmbFoods.Location = new System.Drawing.Point(132, 98);
            this.cmbFoods.Size = new System.Drawing.Size(200, 25);
            this.cmbFoods.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFoods.Name = "cmbFoods";

            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQty.Location = new System.Drawing.Point(340, 80);
            this.lblQty.Text = "Кол-во";

            this.numQuantity.Location = new System.Drawing.Point(340, 98);
            this.numQuantity.Size = new System.Drawing.Size(68, 25);
            this.numQuantity.Minimum = 1;
            this.numQuantity.Value = 1;
            this.numQuantity.Name = "numQuantity";

            this.btnAddToOrder.Location = new System.Drawing.Point(416, 96);
            this.btnAddToOrder.Size = new System.Drawing.Size(120, 30);
            this.btnAddToOrder.Text = "+  В заказ";
            this.btnAddToOrder.Name = "btnAddToOrder";

            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(544, 102);
            this.lblPrice.Text = "Цена: 0 сом";

            this.dgvOrders.Location = new System.Drawing.Point(16, 136);
            this.dgvOrders.Size = new System.Drawing.Size(560, 320);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                 | System.Windows.Forms.AnchorStyles.Bottom
                 | System.Windows.Forms.AnchorStyles.Left
                 | System.Windows.Forms.AnchorStyles.Right));

            // === Карточка ИТОГО + кнопка сохранения (правая колонка) ===
            this.panelTotalCard.Location = new System.Drawing.Point(592, 36);
            this.panelTotalCard.Size = new System.Drawing.Size(240, 118);
            this.panelTotalCard.BackColor = System.Drawing.Color.White;
            this.panelTotalCard.Padding = new Padding(14);
            this.panelTotalCard.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                 | System.Windows.Forms.AnchorStyles.Right));
            this.panelTotalCard.Controls.Add(this.btnSaveOrder);
            this.panelTotalCard.Controls.Add(this.lblTotal);
            this.panelTotalCard.Controls.Add(this.lblTotalCaption);

            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalCaption.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            this.lblTotalCaption.Location = new System.Drawing.Point(14, 10);
            this.lblTotalCaption.Text = "Итого по заказу";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblTotal.Location = new System.Drawing.Point(14, 30);
            this.lblTotal.Text = "0 сом";

            this.btnSaveOrder.Location = new System.Drawing.Point(14, 72);
            this.btnSaveOrder.Size = new System.Drawing.Size(212, 34);
            this.btnSaveOrder.Text = "💾  Сохранить заказ";
            this.btnSaveOrder.Name = "btnSaveOrder";

            // === Карточка «Последние заказы» ===
            this.panelRecentCard.Location = new System.Drawing.Point(592, 168);
            this.panelRecentCard.Size = new System.Drawing.Size(240, 288);
            this.panelRecentCard.BackColor = System.Drawing.Color.White;
            this.panelRecentCard.Padding = new Padding(10);
            this.panelRecentCard.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                 | System.Windows.Forms.AnchorStyles.Bottom
                 | System.Windows.Forms.AnchorStyles.Right));
            this.panelRecentCard.Controls.Add(this.dgvRecent);
            this.panelRecentCard.Controls.Add(this.lblRecentTitle);

            this.lblRecentTitle.Dock = DockStyle.Top;
            this.lblRecentTitle.Height = 24;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblRecentTitle.Text = "Последние заказы";
            this.lblRecentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.dgvRecent.Dock = DockStyle.Fill;
            this.dgvRecent.Name = "dgvRecent";

            // ===========================================================
            // panelMenuPage
            // ===========================================================
            this.panelMenuPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenuPage.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.panelMenuPage.AutoScroll = true;
            this.panelMenuPage.Controls.Add(this.dgvMenu);
            this.panelMenuPage.Controls.Add(this.btnAddFood);
            this.panelMenuPage.Controls.Add(this.cmbCategory);
            this.panelMenuPage.Controls.Add(this.txtPrice);
            this.panelMenuPage.Controls.Add(this.txtFoodName);
            this.panelMenuPage.Controls.Add(this.lblCategoryLbl);
            this.panelMenuPage.Controls.Add(this.lblFoodPriceLbl);
            this.panelMenuPage.Controls.Add(this.lblFoodName);
            this.panelMenuPage.Controls.Add(this.lblMenuTitle);
            this.panelMenuPage.Visible = false;

            this.lblMenuTitle.AutoSize = true;
            this.lblMenuTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblMenuTitle.Location = new System.Drawing.Point(20, 8);
            this.lblMenuTitle.Text = "Меню";

            this.lblFoodName.AutoSize = true;
            this.lblFoodName.Location = new System.Drawing.Point(20, 44);
            this.lblFoodName.Text = "Название";

            this.txtFoodName.Location = new System.Drawing.Point(20, 62);
            this.txtFoodName.Size = new System.Drawing.Size(190, 25);
            this.txtFoodName.Name = "txtFoodName";

            this.lblFoodPriceLbl.AutoSize = true;
            this.lblFoodPriceLbl.Location = new System.Drawing.Point(222, 44);
            this.lblFoodPriceLbl.Text = "Цена";

            this.txtPrice.Location = new System.Drawing.Point(222, 62);
            this.txtPrice.Size = new System.Drawing.Size(100, 25);
            this.txtPrice.Name = "txtPrice";

            this.lblCategoryLbl.AutoSize = true;
            this.lblCategoryLbl.Location = new System.Drawing.Point(334, 44);
            this.lblCategoryLbl.Text = "Категория";

            this.cmbCategory.Location = new System.Drawing.Point(334, 62);
            this.cmbCategory.Size = new System.Drawing.Size(170, 25);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.SelectedIndexChanged +=
                new System.EventHandler(this.cmbCategory_SelectedIndexChanged);

            this.btnAddFood.Location = new System.Drawing.Point(518, 61);
            this.btnAddFood.Size = new System.Drawing.Size(120, 28);
            this.btnAddFood.Text = "+  Добавить";
            this.btnAddFood.Name = "btnAddFood";

            this.dgvMenu.Location = new System.Drawing.Point(20, 102);
            this.dgvMenu.Size = new System.Drawing.Size(820, 360);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                 | System.Windows.Forms.AnchorStyles.Bottom
                 | System.Windows.Forms.AnchorStyles.Left
                 | System.Windows.Forms.AnchorStyles.Right));

            // ===========================================================
            // panelAccess
            // ===========================================================
            this.panelAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccess.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.panelAccess.AutoScroll = true;
            this.panelAccess.Controls.Add(this.dataGridView1);
            this.panelAccess.Controls.Add(this.btnDeleteUser);
            this.panelAccess.Controls.Add(this.btnAddUser);
            this.panelAccess.Controls.Add(this.cmbRole);
            this.panelAccess.Controls.Add(this.txtName);
            this.panelAccess.Controls.Add(this.lblUserRole);
            this.panelAccess.Controls.Add(this.lblUserName);
            this.panelAccess.Controls.Add(this.lblAccessTitle);
            this.panelAccess.Visible = false;

            this.lblAccessTitle.AutoSize = true;
            this.lblAccessTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblAccessTitle.Location = new System.Drawing.Point(20, 8);
            this.lblAccessTitle.Text = "Доступ пользователей";

            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(20, 44);
            this.lblUserName.Text = "Имя";

            this.txtName.Location = new System.Drawing.Point(20, 62);
            this.txtName.Size = new System.Drawing.Size(190, 25);
            this.txtName.Name = "txtName";

            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Location = new System.Drawing.Point(222, 44);
            this.lblUserRole.Text = "Роль";

            this.cmbRole.Location = new System.Drawing.Point(222, 62);
            this.cmbRole.Size = new System.Drawing.Size(140, 25);
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Items.AddRange(new object[] { "Admin", "Staff", "Intern" });

            this.btnAddUser.Location = new System.Drawing.Point(376, 61);
            this.btnAddUser.Size = new System.Drawing.Size(118, 28);
            this.btnAddUser.Text = "+  Добавить";
            this.btnAddUser.Name = "btnAddUser";

            this.btnDeleteUser.Location = new System.Drawing.Point(502, 61);
            this.btnDeleteUser.Size = new System.Drawing.Size(118, 28);
            this.btnDeleteUser.Text = "🗑  Удалить";
            this.btnDeleteUser.Name = "btnDeleteUser";

            this.dataGridView1.Location = new System.Drawing.Point(20, 102);
            this.dataGridView1.Size = new System.Drawing.Size(820, 360);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                 | System.Windows.Forms.AnchorStyles.Bottom
                 | System.Windows.Forms.AnchorStyles.Left
                 | System.Windows.Forms.AnchorStyles.Right));
            this.dataGridView1.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cafe Automation System";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.panelMenu.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelAvgCheck.ResumeLayout(false);
            this.panelAvgCheck.PerformLayout();
            this.panelOrders.ResumeLayout(false);
            this.panelOrders.PerformLayout();
            this.panelProfit.ResumeLayout(false);
            this.panelProfit.PerformLayout();
            this.panelRevenue.ResumeLayout(false);
            this.panelRevenue.PerformLayout();
            this.panelChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panelMonthCard.ResumeLayout(false);
            this.panelMonthCard.PerformLayout();
            this.panelSales.ResumeLayout(false);
            this.panelSales.PerformLayout();
            this.panelTotalCard.ResumeLayout(false);
            this.panelTotalCard.PerformLayout();
            this.panelRecentCard.ResumeLayout(false);
            this.panelRecentCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panelMenuPage.ResumeLayout(false);
            this.panelMenuPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.panelAccess.ResumeLayout(false);
            this.panelAccess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel  panelMenu;
        private System.Windows.Forms.Label  lblBrand;
        private System.Windows.Forms.Button btnAccess;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnStats;

        private System.Windows.Forms.Panel  panelMain;

        private System.Windows.Forms.Panel  panelHeader;
        private System.Windows.Forms.Label  lblHeaderTitle;
        private System.Windows.Forms.Label  lblHeaderDate;
        private System.Windows.Forms.Label  lblHeaderTime;
        private System.Windows.Forms.Timer  timerClock;

        private System.Windows.Forms.Panel  panelStats;
        private System.Windows.Forms.Label  lblStatsTitle;
        private System.Windows.Forms.Panel  panelRevenue;
        private System.Windows.Forms.Label  label10;
        private System.Windows.Forms.Label  label9;
        private System.Windows.Forms.Panel  panelProfit;
        private System.Windows.Forms.Label  label12;
        private System.Windows.Forms.Label  label11;
        private System.Windows.Forms.Panel  panelOrders;
        private System.Windows.Forms.Label  label5;
        private System.Windows.Forms.Label  label6;
        private System.Windows.Forms.Panel  panelAvgCheck;
        private System.Windows.Forms.Label  label7;
        private System.Windows.Forms.Label  label8;
        private System.Windows.Forms.Panel  panelChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        private System.Windows.Forms.Panel  panelMonthCard;
        private System.Windows.Forms.Label  lblMonthTitle;
        private System.Windows.Forms.Label  lblMonthProfitCap;
        private System.Windows.Forms.Label  lblMonthProfit;
        private System.Windows.Forms.Label  lblMonthOrdersCap;
        private System.Windows.Forms.Label  lblMonthOrders;
        private System.Windows.Forms.Label  lblMonthTopCap;
        private System.Windows.Forms.Label  lblMonthTop;

        private System.Windows.Forms.Panel       panelSales;
        private System.Windows.Forms.Label       lblSalesTitle;
        private System.Windows.Forms.TableLayoutPanel flowCategories;
        private System.Windows.Forms.Label       lblTable;
        private System.Windows.Forms.ComboBox    cmbTable;
        private System.Windows.Forms.Label       lblFood;
        private System.Windows.Forms.Label       lblQty;
        private System.Windows.Forms.ComboBox    cmbFoods;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button      btnAddToOrder;
        private System.Windows.Forms.Label       lblPrice;
        private System.Windows.Forms.DataGridView dgvOrders;

        private System.Windows.Forms.Panel       panelTotalCard;
        private System.Windows.Forms.Label       lblTotalCaption;
        private System.Windows.Forms.Label       lblTotal;
        private System.Windows.Forms.Button      btnSaveOrder;

        private System.Windows.Forms.Panel       panelRecentCard;
        private System.Windows.Forms.Label       lblRecentTitle;
        private System.Windows.Forms.DataGridView dgvRecent;

        private System.Windows.Forms.Panel       panelMenuPage;
        private System.Windows.Forms.Label       lblMenuTitle;
        private System.Windows.Forms.Label       lblFoodName;
        private System.Windows.Forms.Label       lblFoodPriceLbl;
        private System.Windows.Forms.Label       lblCategoryLbl;
        private System.Windows.Forms.TextBox     txtFoodName;
        private System.Windows.Forms.TextBox     txtPrice;
        private System.Windows.Forms.ComboBox    cmbCategory;
        private System.Windows.Forms.Button      btnAddFood;
        private System.Windows.Forms.DataGridView dgvMenu;

        private System.Windows.Forms.Panel       panelAccess;
        private System.Windows.Forms.Label       lblAccessTitle;
        private System.Windows.Forms.Label       lblUserName;
        private System.Windows.Forms.Label       lblUserRole;
        private System.Windows.Forms.TextBox     txtName;
        private System.Windows.Forms.ComboBox    cmbRole;
        private System.Windows.Forms.Button      btnAddUser;
        private System.Windows.Forms.Button      btnDeleteUser;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

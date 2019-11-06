namespace sloanTaxCalculator
{
    partial class TaxCalculatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SalesTaxLbl = new System.Windows.Forms.Label();
            this.SalesCityLbl = new System.Windows.Forms.Label();
            this.SalesStateLbl = new System.Windows.Forms.Label();
            this.SalesLocalLbl = new System.Windows.Forms.Label();
            this.SalesCityTxt = new System.Windows.Forms.TextBox();
            this.SalesLocalTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OccLocalTxt = new System.Windows.Forms.TextBox();
            this.OccStateTxt = new System.Windows.Forms.TextBox();
            this.OccCityTxt = new System.Windows.Forms.TextBox();
            this.OccTaxLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OccLocalLbl = new System.Windows.Forms.Label();
            this.OccCityLbl = new System.Windows.Forms.Label();
            this.OccStateLbl = new System.Windows.Forms.Label();
            this.DeliveryLocalTxt = new System.Windows.Forms.TextBox();
            this.DeliveryStateTxt = new System.Windows.Forms.TextBox();
            this.DeliveryCityTxt = new System.Windows.Forms.TextBox();
            this.DeliveryTaxLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DeliveryLocalLbl = new System.Windows.Forms.Label();
            this.DeliveryCityLbl = new System.Windows.Forms.Label();
            this.DeliveryStateLbl = new System.Windows.Forms.Label();
            this.SubtotalPricesTxt = new System.Windows.Forms.TextBox();
            this.SubtotalPricesLbl = new System.Windows.Forms.Label();
            this.NontaxablePricesLbl = new System.Windows.Forms.Label();
            this.NontaxablePricesTxt = new System.Windows.Forms.TextBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.DeliveryFeesLbl = new System.Windows.Forms.Label();
            this.DeliveryFeesTxt = new System.Windows.Forms.TextBox();
            this.SalesStateTxt = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SalesTaxCalculationLbl = new System.Windows.Forms.Label();
            this.OccCalculationSectionLbl = new System.Windows.Forms.Label();
            this.UnroundedCityOccLbl = new System.Windows.Forms.Label();
            this.RoundedCityOccLbl = new System.Windows.Forms.Label();
            this.RoundedStateOccLbl = new System.Windows.Forms.Label();
            this.UnroundedStateOccLbl = new System.Windows.Forms.Label();
            this.RoundedLocalOccLbl = new System.Windows.Forms.Label();
            this.UnroundedLocalOccLbl = new System.Windows.Forms.Label();
            this.OccTotalLbl = new System.Windows.Forms.Label();
            this.DeliveryFeesOccTotalLbl = new System.Windows.Forms.Label();
            this.SubtotalOccTotalLbl = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.SubtotalSalesTotalLbl = new System.Windows.Forms.Label();
            this.SalesTotalLbl = new System.Windows.Forms.Label();
            this.RoundedLocalSalesLbl = new System.Windows.Forms.Label();
            this.UnroundedLocalSalesLbl = new System.Windows.Forms.Label();
            this.RoundedStateSalesLbl = new System.Windows.Forms.Label();
            this.UnroundedStateSalesLbl = new System.Windows.Forms.Label();
            this.RoundedCitySalesLbl = new System.Windows.Forms.Label();
            this.UnroundedCitySalesLbl = new System.Windows.Forms.Label();
            this.SubtotalCalculationSectionLbl = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // SalesTaxLbl
            // 
            this.SalesTaxLbl.AutoSize = true;
            this.SalesTaxLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesTaxLbl.Location = new System.Drawing.Point(55, 9);
            this.SalesTaxLbl.Name = "SalesTaxLbl";
            this.SalesTaxLbl.Size = new System.Drawing.Size(100, 13);
            this.SalesTaxLbl.TabIndex = 0;
            this.SalesTaxLbl.Text = "Sales Tax Rates";
            // 
            // SalesCityLbl
            // 
            this.SalesCityLbl.AutoSize = true;
            this.SalesCityLbl.Location = new System.Drawing.Point(12, 33);
            this.SalesCityLbl.Name = "SalesCityLbl";
            this.SalesCityLbl.Size = new System.Drawing.Size(64, 13);
            this.SalesCityLbl.TabIndex = 1;
            this.SalesCityLbl.Text = "City Rate %:";
            // 
            // SalesStateLbl
            // 
            this.SalesStateLbl.AutoSize = true;
            this.SalesStateLbl.Location = new System.Drawing.Point(12, 56);
            this.SalesStateLbl.Name = "SalesStateLbl";
            this.SalesStateLbl.Size = new System.Drawing.Size(72, 13);
            this.SalesStateLbl.TabIndex = 2;
            this.SalesStateLbl.Text = "State Rate %:";
            // 
            // SalesLocalLbl
            // 
            this.SalesLocalLbl.AutoSize = true;
            this.SalesLocalLbl.Location = new System.Drawing.Point(12, 80);
            this.SalesLocalLbl.Name = "SalesLocalLbl";
            this.SalesLocalLbl.Size = new System.Drawing.Size(73, 13);
            this.SalesLocalLbl.TabIndex = 3;
            this.SalesLocalLbl.Text = "Local Rate %:";
            // 
            // SalesCityTxt
            // 
            this.SalesCityTxt.Location = new System.Drawing.Point(85, 31);
            this.SalesCityTxt.Name = "SalesCityTxt";
            this.SalesCityTxt.Size = new System.Drawing.Size(100, 20);
            this.SalesCityTxt.TabIndex = 4;
            this.SalesCityTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SalesLocalTxt
            // 
            this.SalesLocalTxt.Location = new System.Drawing.Point(85, 76);
            this.SalesLocalTxt.Name = "SalesLocalTxt";
            this.SalesLocalTxt.Size = new System.Drawing.Size(100, 20);
            this.SalesLocalTxt.TabIndex = 6;
            this.SalesLocalTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 106);
            this.panel1.TabIndex = 7;
            // 
            // OccLocalTxt
            // 
            this.OccLocalTxt.Location = new System.Drawing.Point(286, 76);
            this.OccLocalTxt.Name = "OccLocalTxt";
            this.OccLocalTxt.Size = new System.Drawing.Size(100, 20);
            this.OccLocalTxt.TabIndex = 14;
            this.OccLocalTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OccStateTxt
            // 
            this.OccStateTxt.Location = new System.Drawing.Point(286, 54);
            this.OccStateTxt.Name = "OccStateTxt";
            this.OccStateTxt.Size = new System.Drawing.Size(100, 20);
            this.OccStateTxt.TabIndex = 13;
            this.OccStateTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OccCityTxt
            // 
            this.OccCityTxt.Location = new System.Drawing.Point(286, 31);
            this.OccCityTxt.Name = "OccCityTxt";
            this.OccCityTxt.Size = new System.Drawing.Size(100, 20);
            this.OccCityTxt.TabIndex = 12;
            this.OccCityTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OccTaxLbl
            // 
            this.OccTaxLbl.AutoSize = true;
            this.OccTaxLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OccTaxLbl.Location = new System.Drawing.Point(61, 4);
            this.OccTaxLbl.Name = "OccTaxLbl";
            this.OccTaxLbl.Size = new System.Drawing.Size(94, 13);
            this.OccTaxLbl.TabIndex = 8;
            this.OccTaxLbl.Text = "OCC Tax Rates";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.OccLocalLbl);
            this.panel2.Controls.Add(this.OccCityLbl);
            this.panel2.Controls.Add(this.OccStateLbl);
            this.panel2.Controls.Add(this.OccTaxLbl);
            this.panel2.Location = new System.Drawing.Point(206, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 106);
            this.panel2.TabIndex = 15;
            // 
            // OccLocalLbl
            // 
            this.OccLocalLbl.AutoSize = true;
            this.OccLocalLbl.Location = new System.Drawing.Point(3, 76);
            this.OccLocalLbl.Name = "OccLocalLbl";
            this.OccLocalLbl.Size = new System.Drawing.Size(73, 13);
            this.OccLocalLbl.TabIndex = 26;
            this.OccLocalLbl.Text = "Local Rate %:";
            // 
            // OccCityLbl
            // 
            this.OccCityLbl.AutoSize = true;
            this.OccCityLbl.Location = new System.Drawing.Point(3, 29);
            this.OccCityLbl.Name = "OccCityLbl";
            this.OccCityLbl.Size = new System.Drawing.Size(64, 13);
            this.OccCityLbl.TabIndex = 24;
            this.OccCityLbl.Text = "City Rate %:";
            // 
            // OccStateLbl
            // 
            this.OccStateLbl.AutoSize = true;
            this.OccStateLbl.Location = new System.Drawing.Point(3, 52);
            this.OccStateLbl.Name = "OccStateLbl";
            this.OccStateLbl.Size = new System.Drawing.Size(72, 13);
            this.OccStateLbl.TabIndex = 25;
            this.OccStateLbl.Text = "State Rate %:";
            // 
            // DeliveryLocalTxt
            // 
            this.DeliveryLocalTxt.Location = new System.Drawing.Point(487, 76);
            this.DeliveryLocalTxt.Name = "DeliveryLocalTxt";
            this.DeliveryLocalTxt.Size = new System.Drawing.Size(100, 20);
            this.DeliveryLocalTxt.TabIndex = 22;
            this.DeliveryLocalTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DeliveryStateTxt
            // 
            this.DeliveryStateTxt.Location = new System.Drawing.Point(487, 54);
            this.DeliveryStateTxt.Name = "DeliveryStateTxt";
            this.DeliveryStateTxt.Size = new System.Drawing.Size(100, 20);
            this.DeliveryStateTxt.TabIndex = 21;
            this.DeliveryStateTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DeliveryCityTxt
            // 
            this.DeliveryCityTxt.Location = new System.Drawing.Point(487, 31);
            this.DeliveryCityTxt.Name = "DeliveryCityTxt";
            this.DeliveryCityTxt.Size = new System.Drawing.Size(100, 20);
            this.DeliveryCityTxt.TabIndex = 20;
            this.DeliveryCityTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DeliveryTaxLbl
            // 
            this.DeliveryTaxLbl.AutoSize = true;
            this.DeliveryTaxLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryTaxLbl.Location = new System.Drawing.Point(46, 4);
            this.DeliveryTaxLbl.Name = "DeliveryTaxLbl";
            this.DeliveryTaxLbl.Size = new System.Drawing.Size(115, 13);
            this.DeliveryTaxLbl.TabIndex = 16;
            this.DeliveryTaxLbl.Text = "Delivery Tax Rates";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.DeliveryLocalLbl);
            this.panel3.Controls.Add(this.DeliveryCityLbl);
            this.panel3.Controls.Add(this.DeliveryStateLbl);
            this.panel3.Controls.Add(this.DeliveryTaxLbl);
            this.panel3.Location = new System.Drawing.Point(407, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(195, 106);
            this.panel3.TabIndex = 23;
            // 
            // DeliveryLocalLbl
            // 
            this.DeliveryLocalLbl.AutoSize = true;
            this.DeliveryLocalLbl.Location = new System.Drawing.Point(3, 76);
            this.DeliveryLocalLbl.Name = "DeliveryLocalLbl";
            this.DeliveryLocalLbl.Size = new System.Drawing.Size(73, 13);
            this.DeliveryLocalLbl.TabIndex = 29;
            this.DeliveryLocalLbl.Text = "Local Rate %:";
            // 
            // DeliveryCityLbl
            // 
            this.DeliveryCityLbl.AutoSize = true;
            this.DeliveryCityLbl.Location = new System.Drawing.Point(3, 29);
            this.DeliveryCityLbl.Name = "DeliveryCityLbl";
            this.DeliveryCityLbl.Size = new System.Drawing.Size(64, 13);
            this.DeliveryCityLbl.TabIndex = 27;
            this.DeliveryCityLbl.Text = "City Rate %:";
            // 
            // DeliveryStateLbl
            // 
            this.DeliveryStateLbl.AutoSize = true;
            this.DeliveryStateLbl.Location = new System.Drawing.Point(3, 52);
            this.DeliveryStateLbl.Name = "DeliveryStateLbl";
            this.DeliveryStateLbl.Size = new System.Drawing.Size(72, 13);
            this.DeliveryStateLbl.TabIndex = 28;
            this.DeliveryStateLbl.Text = "State Rate %:";
            // 
            // SubtotalPricesTxt
            // 
            this.SubtotalPricesTxt.Location = new System.Drawing.Point(5, 134);
            this.SubtotalPricesTxt.Multiline = true;
            this.SubtotalPricesTxt.Name = "SubtotalPricesTxt";
            this.SubtotalPricesTxt.Size = new System.Drawing.Size(195, 189);
            this.SubtotalPricesTxt.TabIndex = 24;
            // 
            // SubtotalPricesLbl
            // 
            this.SubtotalPricesLbl.AutoSize = true;
            this.SubtotalPricesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubtotalPricesLbl.Location = new System.Drawing.Point(60, 118);
            this.SubtotalPricesLbl.Name = "SubtotalPricesLbl";
            this.SubtotalPricesLbl.Size = new System.Drawing.Size(93, 13);
            this.SubtotalPricesLbl.TabIndex = 25;
            this.SubtotalPricesLbl.Text = "Subtotal Prices";
            this.SubtotalPricesLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SubtotalPricesLbl.Click += new System.EventHandler(this.SubtotalPricesLbl_Click);
            // 
            // NontaxablePricesLbl
            // 
            this.NontaxablePricesLbl.AutoSize = true;
            this.NontaxablePricesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NontaxablePricesLbl.Location = new System.Drawing.Point(257, 118);
            this.NontaxablePricesLbl.Name = "NontaxablePricesLbl";
            this.NontaxablePricesLbl.Size = new System.Drawing.Size(110, 13);
            this.NontaxablePricesLbl.TabIndex = 27;
            this.NontaxablePricesLbl.Text = "Nontaxable Prices";
            this.NontaxablePricesLbl.Click += new System.EventHandler(this.NontaxablePricesLbl_Click);
            // 
            // NontaxablePricesTxt
            // 
            this.NontaxablePricesTxt.Location = new System.Drawing.Point(206, 134);
            this.NontaxablePricesTxt.Multiline = true;
            this.NontaxablePricesTxt.Name = "NontaxablePricesTxt";
            this.NontaxablePricesTxt.Size = new System.Drawing.Size(195, 84);
            this.NontaxablePricesTxt.TabIndex = 26;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(425, 179);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(177, 94);
            this.CalculateButton.TabIndex = 28;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // DeliveryFeesLbl
            // 
            this.DeliveryFeesLbl.AutoSize = true;
            this.DeliveryFeesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryFeesLbl.Location = new System.Drawing.Point(264, 223);
            this.DeliveryFeesLbl.Name = "DeliveryFeesLbl";
            this.DeliveryFeesLbl.Size = new System.Drawing.Size(84, 13);
            this.DeliveryFeesLbl.TabIndex = 31;
            this.DeliveryFeesLbl.Text = "Delivery Fees";
            this.DeliveryFeesLbl.Click += new System.EventHandler(this.DeliveryFeesLbl_Click);
            // 
            // DeliveryFeesTxt
            // 
            this.DeliveryFeesTxt.Location = new System.Drawing.Point(206, 239);
            this.DeliveryFeesTxt.Multiline = true;
            this.DeliveryFeesTxt.Name = "DeliveryFeesTxt";
            this.DeliveryFeesTxt.Size = new System.Drawing.Size(195, 84);
            this.DeliveryFeesTxt.TabIndex = 30;
            // 
            // SalesStateTxt
            // 
            this.SalesStateTxt.Location = new System.Drawing.Point(85, 54);
            this.SalesStateTxt.Name = "SalesStateTxt";
            this.SalesStateTxt.Size = new System.Drawing.Size(100, 20);
            this.SalesStateTxt.TabIndex = 5;
            this.SalesStateTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 100);
            this.panel5.TabIndex = 0;
            // 
            // SalesTaxCalculationLbl
            // 
            this.SalesTaxCalculationLbl.AutoSize = true;
            this.SalesTaxCalculationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesTaxCalculationLbl.Location = new System.Drawing.Point(3, 0);
            this.SalesTaxCalculationLbl.Name = "SalesTaxCalculationLbl";
            this.SalesTaxCalculationLbl.Size = new System.Drawing.Size(130, 13);
            this.SalesTaxCalculationLbl.TabIndex = 39;
            this.SalesTaxCalculationLbl.Text = "Sales Tax Calculation";
            // 
            // OccCalculationSectionLbl
            // 
            this.OccCalculationSectionLbl.AutoSize = true;
            this.OccCalculationSectionLbl.Location = new System.Drawing.Point(11, 335);
            this.OccCalculationSectionLbl.Name = "OccCalculationSectionLbl";
            this.OccCalculationSectionLbl.Size = new System.Drawing.Size(129, 13);
            this.OccCalculationSectionLbl.TabIndex = 33;
            this.OccCalculationSectionLbl.Text = "OccCalculationSectionLbl";
            // 
            // UnroundedCityOccLbl
            // 
            this.UnroundedCityOccLbl.AutoSize = true;
            this.UnroundedCityOccLbl.Location = new System.Drawing.Point(11, 358);
            this.UnroundedCityOccLbl.Name = "UnroundedCityOccLbl";
            this.UnroundedCityOccLbl.Size = new System.Drawing.Size(111, 13);
            this.UnroundedCityOccLbl.TabIndex = 34;
            this.UnroundedCityOccLbl.Text = "UnroundedCityOccLbl";
            // 
            // RoundedCityOccLbl
            // 
            this.RoundedCityOccLbl.AutoSize = true;
            this.RoundedCityOccLbl.Location = new System.Drawing.Point(11, 371);
            this.RoundedCityOccLbl.Name = "RoundedCityOccLbl";
            this.RoundedCityOccLbl.Size = new System.Drawing.Size(102, 13);
            this.RoundedCityOccLbl.TabIndex = 35;
            this.RoundedCityOccLbl.Text = "RoundedCityOccLbl";
            // 
            // RoundedStateOccLbl
            // 
            this.RoundedStateOccLbl.AutoSize = true;
            this.RoundedStateOccLbl.Location = new System.Drawing.Point(11, 409);
            this.RoundedStateOccLbl.Name = "RoundedStateOccLbl";
            this.RoundedStateOccLbl.Size = new System.Drawing.Size(110, 13);
            this.RoundedStateOccLbl.TabIndex = 37;
            this.RoundedStateOccLbl.Text = "RoundedStateOccLbl";
            // 
            // UnroundedStateOccLbl
            // 
            this.UnroundedStateOccLbl.AutoSize = true;
            this.UnroundedStateOccLbl.Location = new System.Drawing.Point(11, 396);
            this.UnroundedStateOccLbl.Name = "UnroundedStateOccLbl";
            this.UnroundedStateOccLbl.Size = new System.Drawing.Size(119, 13);
            this.UnroundedStateOccLbl.TabIndex = 36;
            this.UnroundedStateOccLbl.Text = "UnroundedStateOccLbl";
            // 
            // RoundedLocalOccLbl
            // 
            this.RoundedLocalOccLbl.AutoSize = true;
            this.RoundedLocalOccLbl.Location = new System.Drawing.Point(11, 451);
            this.RoundedLocalOccLbl.Name = "RoundedLocalOccLbl";
            this.RoundedLocalOccLbl.Size = new System.Drawing.Size(111, 13);
            this.RoundedLocalOccLbl.TabIndex = 39;
            this.RoundedLocalOccLbl.Text = "RoundedLocalOccLbl";
            // 
            // UnroundedLocalOccLbl
            // 
            this.UnroundedLocalOccLbl.AutoSize = true;
            this.UnroundedLocalOccLbl.Location = new System.Drawing.Point(11, 438);
            this.UnroundedLocalOccLbl.Name = "UnroundedLocalOccLbl";
            this.UnroundedLocalOccLbl.Size = new System.Drawing.Size(120, 13);
            this.UnroundedLocalOccLbl.TabIndex = 38;
            this.UnroundedLocalOccLbl.Text = "UnroundedLocalOccLbl";
            // 
            // OccTotalLbl
            // 
            this.OccTotalLbl.AutoSize = true;
            this.OccTotalLbl.Location = new System.Drawing.Point(11, 477);
            this.OccTotalLbl.Name = "OccTotalLbl";
            this.OccTotalLbl.Size = new System.Drawing.Size(65, 13);
            this.OccTotalLbl.TabIndex = 40;
            this.OccTotalLbl.Text = "OccTotalLbl";
            // 
            // DeliveryFeesOccTotalLbl
            // 
            this.DeliveryFeesOccTotalLbl.AutoSize = true;
            this.DeliveryFeesOccTotalLbl.Location = new System.Drawing.Point(11, 490);
            this.DeliveryFeesOccTotalLbl.Name = "DeliveryFeesOccTotalLbl";
            this.DeliveryFeesOccTotalLbl.Size = new System.Drawing.Size(126, 13);
            this.DeliveryFeesOccTotalLbl.TabIndex = 41;
            this.DeliveryFeesOccTotalLbl.Text = "DeliveryFeesOccTotalLbl";
            // 
            // SubtotalOccTotalLbl
            // 
            this.SubtotalOccTotalLbl.AutoSize = true;
            this.SubtotalOccTotalLbl.Location = new System.Drawing.Point(11, 503);
            this.SubtotalOccTotalLbl.Name = "SubtotalOccTotalLbl";
            this.SubtotalOccTotalLbl.Size = new System.Drawing.Size(104, 13);
            this.SubtotalOccTotalLbl.TabIndex = 42;
            this.SubtotalOccTotalLbl.Text = "SubtotalOccTotalLbl";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Location = new System.Drawing.Point(5, 329);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(292, 194);
            this.panel6.TabIndex = 8;
            // 
            // SubtotalSalesTotalLbl
            // 
            this.SubtotalSalesTotalLbl.AutoSize = true;
            this.SubtotalSalesTotalLbl.Location = new System.Drawing.Point(5, 162);
            this.SubtotalSalesTotalLbl.Name = "SubtotalSalesTotalLbl";
            this.SubtotalSalesTotalLbl.Size = new System.Drawing.Size(110, 13);
            this.SubtotalSalesTotalLbl.TabIndex = 52;
            this.SubtotalSalesTotalLbl.Text = "SubtotalSalesTotalLbl";
            // 
            // SalesTotalLbl
            // 
            this.SalesTotalLbl.AutoSize = true;
            this.SalesTotalLbl.Location = new System.Drawing.Point(5, 149);
            this.SalesTotalLbl.Name = "SalesTotalLbl";
            this.SalesTotalLbl.Size = new System.Drawing.Size(71, 13);
            this.SalesTotalLbl.TabIndex = 51;
            this.SalesTotalLbl.Text = "SalesTotalLbl";
            // 
            // RoundedLocalSalesLbl
            // 
            this.RoundedLocalSalesLbl.AutoSize = true;
            this.RoundedLocalSalesLbl.Location = new System.Drawing.Point(5, 123);
            this.RoundedLocalSalesLbl.Name = "RoundedLocalSalesLbl";
            this.RoundedLocalSalesLbl.Size = new System.Drawing.Size(117, 13);
            this.RoundedLocalSalesLbl.TabIndex = 50;
            this.RoundedLocalSalesLbl.Text = "RoundedLocalSalesLbl";
            // 
            // UnroundedLocalSalesLbl
            // 
            this.UnroundedLocalSalesLbl.AutoSize = true;
            this.UnroundedLocalSalesLbl.Location = new System.Drawing.Point(5, 110);
            this.UnroundedLocalSalesLbl.Name = "UnroundedLocalSalesLbl";
            this.UnroundedLocalSalesLbl.Size = new System.Drawing.Size(126, 13);
            this.UnroundedLocalSalesLbl.TabIndex = 49;
            this.UnroundedLocalSalesLbl.Text = "UnroundedLocalSalesLbl";
            // 
            // RoundedStateSalesLbl
            // 
            this.RoundedStateSalesLbl.AutoSize = true;
            this.RoundedStateSalesLbl.Location = new System.Drawing.Point(5, 81);
            this.RoundedStateSalesLbl.Name = "RoundedStateSalesLbl";
            this.RoundedStateSalesLbl.Size = new System.Drawing.Size(116, 13);
            this.RoundedStateSalesLbl.TabIndex = 48;
            this.RoundedStateSalesLbl.Text = "RoundedStateSalesLbl";
            // 
            // UnroundedStateSalesLbl
            // 
            this.UnroundedStateSalesLbl.AutoSize = true;
            this.UnroundedStateSalesLbl.Location = new System.Drawing.Point(5, 68);
            this.UnroundedStateSalesLbl.Name = "UnroundedStateSalesLbl";
            this.UnroundedStateSalesLbl.Size = new System.Drawing.Size(125, 13);
            this.UnroundedStateSalesLbl.TabIndex = 47;
            this.UnroundedStateSalesLbl.Text = "UnroundedStateSalesLbl";
            // 
            // RoundedCitySalesLbl
            // 
            this.RoundedCitySalesLbl.AutoSize = true;
            this.RoundedCitySalesLbl.Location = new System.Drawing.Point(5, 43);
            this.RoundedCitySalesLbl.Name = "RoundedCitySalesLbl";
            this.RoundedCitySalesLbl.Size = new System.Drawing.Size(108, 13);
            this.RoundedCitySalesLbl.TabIndex = 46;
            this.RoundedCitySalesLbl.Text = "RoundedCitySalesLbl";
            // 
            // UnroundedCitySalesLbl
            // 
            this.UnroundedCitySalesLbl.AutoSize = true;
            this.UnroundedCitySalesLbl.Location = new System.Drawing.Point(5, 30);
            this.UnroundedCitySalesLbl.Name = "UnroundedCitySalesLbl";
            this.UnroundedCitySalesLbl.Size = new System.Drawing.Size(117, 13);
            this.UnroundedCitySalesLbl.TabIndex = 45;
            this.UnroundedCitySalesLbl.Text = "UnroundedCitySalesLbl";
            // 
            // SubtotalCalculationSectionLbl
            // 
            this.SubtotalCalculationSectionLbl.AutoSize = true;
            this.SubtotalCalculationSectionLbl.Location = new System.Drawing.Point(5, 4);
            this.SubtotalCalculationSectionLbl.Name = "SubtotalCalculationSectionLbl";
            this.SubtotalCalculationSectionLbl.Size = new System.Drawing.Size(148, 13);
            this.SubtotalCalculationSectionLbl.TabIndex = 44;
            this.SubtotalCalculationSectionLbl.Text = "SubtotalCalculationSectionLbl";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.RoundedStateSalesLbl);
            this.panel7.Controls.Add(this.SubtotalCalculationSectionLbl);
            this.panel7.Controls.Add(this.SubtotalSalesTotalLbl);
            this.panel7.Controls.Add(this.UnroundedLocalSalesLbl);
            this.panel7.Controls.Add(this.SalesTotalLbl);
            this.panel7.Controls.Add(this.UnroundedCitySalesLbl);
            this.panel7.Controls.Add(this.RoundedLocalSalesLbl);
            this.panel7.Controls.Add(this.RoundedCitySalesLbl);
            this.panel7.Controls.Add(this.UnroundedStateSalesLbl);
            this.panel7.Location = new System.Drawing.Point(5, 531);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(292, 184);
            this.panel7.TabIndex = 43;
            // 
            // TaxCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 723);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.SubtotalOccTotalLbl);
            this.Controls.Add(this.DeliveryFeesOccTotalLbl);
            this.Controls.Add(this.OccTotalLbl);
            this.Controls.Add(this.RoundedLocalOccLbl);
            this.Controls.Add(this.UnroundedLocalOccLbl);
            this.Controls.Add(this.RoundedStateOccLbl);
            this.Controls.Add(this.UnroundedStateOccLbl);
            this.Controls.Add(this.RoundedCityOccLbl);
            this.Controls.Add(this.UnroundedCityOccLbl);
            this.Controls.Add(this.OccCalculationSectionLbl);
            this.Controls.Add(this.SalesTaxLbl);
            this.Controls.Add(this.SalesCityLbl);
            this.Controls.Add(this.SalesStateLbl);
            this.Controls.Add(this.SalesLocalLbl);
            this.Controls.Add(this.DeliveryFeesLbl);
            this.Controls.Add(this.DeliveryFeesTxt);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.NontaxablePricesLbl);
            this.Controls.Add(this.NontaxablePricesTxt);
            this.Controls.Add(this.SubtotalPricesLbl);
            this.Controls.Add(this.SubtotalPricesTxt);
            this.Controls.Add(this.DeliveryLocalTxt);
            this.Controls.Add(this.OccLocalTxt);
            this.Controls.Add(this.DeliveryStateTxt);
            this.Controls.Add(this.OccStateTxt);
            this.Controls.Add(this.DeliveryCityTxt);
            this.Controls.Add(this.OccCityTxt);
            this.Controls.Add(this.SalesLocalTxt);
            this.Controls.Add(this.SalesStateTxt);
            this.Controls.Add(this.SalesCityTxt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Name = "TaxCalculatorForm";
            this.Text = "sloanTaxCalculator";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SalesTaxLbl;
        private System.Windows.Forms.Label SalesCityLbl;
        private System.Windows.Forms.Label SalesStateLbl;
        private System.Windows.Forms.Label SalesLocalLbl;
        private System.Windows.Forms.Label OccTaxLbl;
        private System.Windows.Forms.Label OccCityLbl;
        private System.Windows.Forms.Label OccStateLbl;
        private System.Windows.Forms.Label OccLocalLbl;
        private System.Windows.Forms.Label DeliveryTaxLbl;
        private System.Windows.Forms.Label DeliveryCityLbl;
        private System.Windows.Forms.Label DeliveryStateLbl;
        private System.Windows.Forms.Label DeliveryLocalLbl;
        private System.Windows.Forms.Label SubtotalPricesLbl;
        private System.Windows.Forms.Label NontaxablePricesLbl;
        private System.Windows.Forms.Label DeliveryFeesLbl;
        private System.Windows.Forms.TextBox SalesCityTxt;
        private System.Windows.Forms.TextBox SalesLocalTxt;
        private System.Windows.Forms.TextBox SalesStateTxt;
        private System.Windows.Forms.TextBox OccCityTxt;
        private System.Windows.Forms.TextBox OccLocalTxt;
        private System.Windows.Forms.TextBox OccStateTxt;
        private System.Windows.Forms.TextBox DeliveryCityTxt;
        private System.Windows.Forms.TextBox DeliveryStateTxt;
        private System.Windows.Forms.TextBox DeliveryLocalTxt;
        private System.Windows.Forms.TextBox SubtotalPricesTxt;
        private System.Windows.Forms.TextBox NontaxablePricesTxt;
        private System.Windows.Forms.TextBox DeliveryFeesTxt;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label SalesTaxCalculationLbl;
        private System.Windows.Forms.Label OccCalculationSectionLbl;
        private System.Windows.Forms.Label UnroundedCityOccLbl;
        private System.Windows.Forms.Label RoundedCityOccLbl;
        private System.Windows.Forms.Label RoundedStateOccLbl;
        private System.Windows.Forms.Label UnroundedStateOccLbl;
        private System.Windows.Forms.Label RoundedLocalOccLbl;
        private System.Windows.Forms.Label UnroundedLocalOccLbl;
        private System.Windows.Forms.Label OccTotalLbl;
        private System.Windows.Forms.Label DeliveryFeesOccTotalLbl;
        private System.Windows.Forms.Label SubtotalOccTotalLbl;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label SubtotalSalesTotalLbl;
        private System.Windows.Forms.Label SalesTotalLbl;
        private System.Windows.Forms.Label RoundedLocalSalesLbl;
        private System.Windows.Forms.Label UnroundedLocalSalesLbl;
        private System.Windows.Forms.Label RoundedStateSalesLbl;
        private System.Windows.Forms.Label UnroundedStateSalesLbl;
        private System.Windows.Forms.Label RoundedCitySalesLbl;
        private System.Windows.Forms.Label UnroundedCitySalesLbl;
        private System.Windows.Forms.Label SubtotalCalculationSectionLbl;
        private System.Windows.Forms.Panel panel7;
    }
}


using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sloanTaxCalculator
{
    public partial class TaxCalculatorForm : Form
    {
        private const string APP_VERSION = "1.0.4";
        private Taxes salesTax;
        private Taxes occTax;
        private Taxes bevTax;
        private Taxes delivTax;
        private Taxes servTax;
        private Taxes smallTax;
        private Taxes tipTax;
        private decimal OccAmount = 0;
        private decimal SalesSubtotal = 0;
        private decimal BeverageSubtotal = 0;
        private decimal DeliveryFeeSubtotal = 0;
        private decimal ServiceFeeSubtotal = 0;
        private decimal SmallOrderFeeSubtotal = 0;
        private decimal TipSubtotal = 0;
        private decimal TaxableSubtotal = 0;
        private decimal DisplayableTaxableSubtotal = 0;
        private decimal NontaxableSubtotal = 0;
        private bool PennyRounding = false;
        private bool ZeroTotal = false;

        public TaxCalculatorForm()
        {
            InitializeComponent();
            Text = "sloanTaxCalculator - v" + APP_VERSION;

            salesTax = new Taxes("Sales Tax");
            occTax = new Taxes("OCC Tax");
            bevTax = new Taxes("Bev Tax");
            delivTax = new Taxes("Delivery Fee Tax");
            servTax = new Taxes("Service Fee Tax");
            smallTax = new Taxes("Small Order Fee Tax");
            tipTax = new Taxes("Tip Tax");

            //--> Sloan: Prepopulate the saved tax rates. Will show 0 if there are no tax rates saved.
            SalesCityTxt.Text = salesTax.CityTaxRate.ToString("G29");
            SalesStateTxt.Text = salesTax.StateTaxRate.ToString("G29");
            SalesLocalTxt.Text = salesTax.LocalTaxRate.ToString("G29");
            OccCityTxt.Text = occTax.CityTaxRate.ToString("G29");
            OccStateTxt.Text = occTax.StateTaxRate.ToString("G29");
            OccLocalTxt.Text = occTax.LocalTaxRate.ToString("G29");
            BevCityTxt.Text = bevTax.CityTaxRate.ToString("G29");
            BevStateTxt.Text = bevTax.StateTaxRate.ToString("G29");
            BevLocalTxt.Text = bevTax.LocalTaxRate.ToString("G29");
            DeliveryFeeCityTxt.Text = delivTax.CityTaxRate.ToString("G29");
            DeliveryFeeStateTxt.Text = delivTax.StateTaxRate.ToString("G29");
            DeliveryFeeLocalTxt.Text = delivTax.LocalTaxRate.ToString("G29");
            ServiceFeeCityTxt.Text = servTax.CityTaxRate.ToString("G29");
            ServiceFeeStateTxt.Text = servTax.StateTaxRate.ToString("G29");
            ServiceFeeLocalTxt.Text = servTax.LocalTaxRate.ToString("G29");
            SmallOrderFeeCityTxt.Text = smallTax.CityTaxRate.ToString("G29");
            SmallOrderFeeStateTxt.Text = smallTax.StateTaxRate.ToString("G29");
            SmallOrderFeeLocalTxt.Text = smallTax.LocalTaxRate.ToString("G29");
            TipCityTxt.Text = tipTax.CityTaxRate.ToString("G29");
            TipStateTxt.Text = tipTax.StateTaxRate.ToString("G29");
            TipLocalTxt.Text = tipTax.LocalTaxRate.ToString("G29");

            SetTaxes();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            SetTaxes();
            SalesSubtotal = GetSum(SubtotalPricesTxt);
            BeverageSubtotal = GetSum(BevPricesTxt);
            NontaxableSubtotal = GetSum(NontaxablePricesTxt);
            DeliveryFeeSubtotal = GetSum(DeliveryFeeTxt);
            ServiceFeeSubtotal = GetSum(ServiceFeeTxt);
            SmallOrderFeeSubtotal = GetSum(SmallOrderFeeTxt);
            TipSubtotal = GetSum(TipTxt);

            TaxableSubtotal = SalesSubtotal + BeverageSubtotal + DeliveryFeeSubtotal + ServiceFeeSubtotal + SmallOrderFeeSubtotal;
            DisplayableTaxableSubtotal = SalesSubtotal + BeverageSubtotal;

            //--> Calculate & Display the occ subtotal
            occTax.CalculateTaxes(TaxableSubtotal);
            DisplayOccSectionMath(TaxableSubtotal);

            OccAmount = occTax.CalculateTotalTaxAmount();

            //--> Calculate & Display the sales tax
            if (SalesSubtotal == 0)
                salesTax.CalculateTaxes(0);
            else
                salesTax.CalculateTaxes(SalesSubtotal + OccAmount);
            DisplaySubtotalSectionMath(SalesSubtotal + OccAmount);

            //--> Calculate & Display the beverage tax
            if (BeverageSubtotal == 0)
                bevTax.CalculateTaxes(0);
            else
                bevTax.CalculateTaxes(BeverageSubtotal + OccAmount);
            DisplayBeverageSectionMath(BeverageSubtotal + OccAmount);

            //--> Calculate & Display the delivery fee tax
            if (DeliveryFeeSubtotal == 0)
                delivTax.CalculateTaxes(0);
            else
                delivTax.CalculateTaxes(DeliveryFeeSubtotal + OccAmount);
            DisplayDeliveryFeeSectionMath(DeliveryFeeSubtotal + OccAmount);

            //--> Calculate & Display the service fee tax
            if (ServiceFeeSubtotal == 0)
                servTax.CalculateTaxes(0);
            else
                servTax.CalculateTaxes(ServiceFeeSubtotal + OccAmount);
            DisplayServiceFeeSectionMath(ServiceFeeSubtotal + OccAmount);

            //--> Calculate & Display the small order fee tax
            if (SmallOrderFeeSubtotal == 0)
                smallTax.CalculateTaxes(0);
            else
                smallTax.CalculateTaxes(SmallOrderFeeSubtotal + OccAmount);
            DisplaySmallOrderFeeSectionMath(SmallOrderFeeSubtotal + OccAmount);

            tipTax.CalculateTaxes(TipSubtotal);
            DisplayTipSectionMath(TipSubtotal);

            DisplayReceipt();
        }

        private void DisplayReceipt()
        {
            ReceiptTaxableTotalActualLbl.Text = DisplayableTaxableSubtotal.ToString();
            ReceiptNontaxableTotalActualLbl.Text = NontaxableSubtotal.ToString();
            ReceiptSubtotalActualLbl.Text = (DisplayableTaxableSubtotal + NontaxableSubtotal).ToString();

            ReceiptDeliveryFeesActualLbl.Text = DeliveryFeeSubtotal.ToString();
            ReceiptServiceFeeActualLbl.Text = ServiceFeeSubtotal.ToString();
            ReceiptSmallOrderFeeActualLbl.Text = SmallOrderFeeSubtotal.ToString();
            ReceiptTipActualLbl.Text = TipSubtotal.ToString();
            ReceiptDeliveryTaxActualLbl.Text = (delivTax.CalculateTotalTaxAmount()
                + smallTax.CalculateTotalTaxAmount()
                + servTax.CalculateTotalTaxAmount()
                + tipTax.CalculateTotalTaxAmount()).ToString();

            ReceiptOccTaxActualLbl.Text = occTax.CalculateTotalTaxAmount().ToString();
            ReceiptSalesTaxActualLbl.Text = (salesTax.CalculateTotalTaxAmount() + bevTax.CalculateTotalTaxAmount()).ToString();

            decimal Total = TaxableSubtotal + NontaxableSubtotal + TipSubtotal
                    + occTax.CalculateTotalTaxAmount()
                    + salesTax.CalculateTotalTaxAmount()
                    + bevTax.CalculateTotalTaxAmount()
                    + delivTax.CalculateTotalTaxAmount()
                    + servTax.CalculateTotalTaxAmount()
                    + smallTax.CalculateTotalTaxAmount()
                    + tipTax.CalculateTotalTaxAmount();

            if (ZeroTotal)
                Total = Total - BeverageSubtotal - SalesSubtotal - NontaxableSubtotal;

            ReceiptTotalActualLbl.Text = Total.ToString();

            if (PennyRounding)
                ReceiptPennyRoundingActualLbl.Text = (Math.Round(Total * 20) / 20).ToString();
        }

        private void DisplayOccSectionMath(decimal subtotal)
        {
            UnroundedCityOccLbl.Text = "Unrounded City Occ Tax: " + subtotal + " x " + occTax.CityTaxRate.ToString() + " = " + occTax.CityTaxAmountUnrounded.ToString();
            RoundedCityOccLbl.Text = "Rounded City Occ Tax:    " + occTax.CityTaxAmount.ToString();

            UnroundedStateOccLbl.Text = "Unrounded State Occ Tax: " + subtotal + " x " + occTax.StateTaxRate.ToString() + " = " + occTax.StateTaxAmountUnrounded.ToString();
            RoundedStateOccLbl.Text = "Rounded State Occ Tax:    " + occTax.StateTaxAmount.ToString();

            UnroundedLocalOccLbl.Text = "Unrounded Local Occ Tax: " + subtotal + " x " + occTax.LocalTaxRate.ToString() + " = " + occTax.LocalTaxAmountUnrounded.ToString();
            RoundedLocalOccLbl.Text = "Rounded Local Occ Tax:    " + occTax.LocalTaxAmount.ToString();

            OccTotalLbl.Text = "Total Tax: " + occTax.CalculateTotalTaxAmount().ToString();
        }
        private void DisplaySubtotalSectionMath(decimal subtotal)
        {
            UnroundedCitySalesLbl.Text = "Unrounded City Sales Tax: " + subtotal + " x " + salesTax.CityTaxRate.ToString() + " = " + salesTax.CityTaxAmountUnrounded.ToString();
            RoundedCitySalesLbl.Text = "Rounded City Sales Tax:    " + salesTax.CityTaxAmount.ToString();

            UnroundedStateSalesLbl.Text = "Unrounded State Sales Tax: " + subtotal + " x " + salesTax.StateTaxRate.ToString() + " = " + salesTax.StateTaxAmountUnrounded.ToString();
            RoundedStateSalesLbl.Text = "Rounded State Sales Tax:    " + salesTax.StateTaxAmount.ToString();

            UnroundedLocalSalesLbl.Text = "Unrounded Local Sales Tax: " + subtotal + " x " + salesTax.LocalTaxRate.ToString() + " = " + salesTax.LocalTaxAmountUnrounded.ToString();
            RoundedLocalSalesLbl.Text = "Rounded Local Sales Tax:    " + salesTax.LocalTaxAmount.ToString();

            SalesTotalLbl.Text = "Total Tax: " + salesTax.CalculateTotalTaxAmount().ToString();
            SubtotalSalesTotalLbl.Text = "Taxed Subtotal: " + subtotal + " + " + salesTax.CalculateTotalTaxAmount().ToString() + " = " + (subtotal + salesTax.CalculateTotalTaxAmount()).ToString();
        }
        private void DisplayBeverageSectionMath(decimal subtotal)
        {
            UnroundedCityBevLbl.Text = "Unrounded City Beverage Tax: " + subtotal + " x " + bevTax.CityTaxRate.ToString() + " = " + bevTax.CityTaxAmountUnrounded.ToString();
            RoundedCityBevLbl.Text = "Rounded City Beverage Tax:    " + bevTax.CityTaxAmount.ToString();

            UnroundedStateBevLbl.Text = "Unrounded State Beverage Tax: " + subtotal + " x " + bevTax.StateTaxRate.ToString() + " = " + bevTax.StateTaxAmountUnrounded.ToString();
            RoundedStateBevLbl.Text = "Rounded State Beverage Tax:    " + bevTax.StateTaxAmount.ToString();

            UnroundedLocalBevLbl.Text = "Unrounded Local Beverage Tax: " + subtotal + " x " + bevTax.LocalTaxRate.ToString() + " = " + bevTax.LocalTaxAmountUnrounded.ToString();
            RoundedLocalBevLbl.Text = "Rounded Local Beverage Tax:    " + bevTax.LocalTaxAmount.ToString();

            BevTotalLbl.Text = "Total Tax: " + bevTax.CalculateTotalTaxAmount().ToString();
            SubtotalBevTotalLbl.Text = "Taxed Subtotal: " + subtotal + " + " + bevTax.CalculateTotalTaxAmount().ToString() + " = " + (subtotal + bevTax.CalculateTotalTaxAmount()).ToString();
        }
        private void DisplayDeliveryFeeSectionMath(decimal subtotal)
        {
            UnroundedCityDelivLbl.Text = "Unrounded City Delivery Fee Tax: " + subtotal + " x " + delivTax.CityTaxRate.ToString() + " = " + delivTax.CityTaxAmountUnrounded.ToString();
            RoundedCityDelivLbl.Text = "Rounded City Delivery Fee Tax:    " + delivTax.CityTaxAmount.ToString();

            UnroundedStateDelivLbl.Text = "Unrounded State Delivery Fee Tax: " + subtotal + " x " + delivTax.StateTaxRate.ToString() + " = " + delivTax.StateTaxAmountUnrounded.ToString();
            RoundedStateDelivLbl.Text = "Rounded State Delivery Fee Tax:    " + delivTax.StateTaxAmount.ToString();

            UnroundedLocalDelivLbl.Text = "Unrounded Local Delivery Fee Tax: " + subtotal + " x " + delivTax.LocalTaxRate.ToString() + " = " + delivTax.LocalTaxAmountUnrounded.ToString();
            RoundedLocalDelivLbl.Text = "Rounded Local Delivery Fee Tax:    " + delivTax.LocalTaxAmount.ToString();

            DelivTotalLbl.Text = "Total Tax: " + delivTax.CalculateTotalTaxAmount().ToString();
            SubtotalDelivTotalLbl.Text = "Taxed Subtotal: " + subtotal + " + " + delivTax.CalculateTotalTaxAmount().ToString() + " = " + (subtotal + delivTax.CalculateTotalTaxAmount()).ToString();
        }
        private void DisplayServiceFeeSectionMath(decimal subtotal)
        {
            UnroundedCityServLbl.Text = "Unrounded City Service Fee Tax: " + subtotal + " x " + servTax.CityTaxRate.ToString() + " = " + servTax.CityTaxAmountUnrounded.ToString();
            RoundedCityServLbl.Text = "Rounded City Service Fee Tax:    " + servTax.CityTaxAmount.ToString();

            UnroundedStateServLbl.Text = "Unrounded State Service Fee Tax: " + subtotal + " x " + servTax.StateTaxRate.ToString() + " = " + servTax.StateTaxAmountUnrounded.ToString();
            RoundedStateServLbl.Text = "Rounded State Service Fee Tax:    " + servTax.StateTaxAmount.ToString();

            UnroundedLocalServLbl.Text = "Unrounded Local Service Fee Tax: " + subtotal + " x " + servTax.LocalTaxRate.ToString() + " = " + servTax.LocalTaxAmountUnrounded.ToString();
            RoundedLocalServLbl.Text = "Rounded Local Service Fee Tax:    " + servTax.LocalTaxAmount.ToString();

            ServTotalLbl.Text = "Total Tax: " + servTax.CalculateTotalTaxAmount().ToString();
            SubtotalServTotalLbl.Text = "Taxed Subtotal: " + subtotal + " + " + servTax.CalculateTotalTaxAmount().ToString() + " = " + (subtotal + servTax.CalculateTotalTaxAmount()).ToString();
        }
        private void DisplayTipSectionMath(decimal subtotal)
        {
            UnroundedCityTipLbl.Text = "Unrounded City Tip Tax: " + subtotal + " x " + tipTax.CityTaxRate.ToString() + " = " + tipTax.CityTaxAmountUnrounded.ToString();
            RoundedCityTipLbl.Text = "Rounded City Tip Tax:    " + tipTax.CityTaxAmount.ToString();

            UnroundedStateTipLbl.Text = "Unrounded State Tip Tax: " + subtotal + " x " + tipTax.StateTaxRate.ToString() + " = " + tipTax.StateTaxAmountUnrounded.ToString();
            RoundedStateTipLbl.Text = "Rounded State Tip Tax:    " + tipTax.StateTaxAmount.ToString();

            UnroundedLocalTipLbl.Text = "Unrounded Local Tip Tax: " + subtotal + " x " + tipTax.LocalTaxRate.ToString() + " = " + tipTax.LocalTaxAmountUnrounded.ToString();
            RoundedLocalTipLbl.Text = "Rounded Local Tip Tax:    " + tipTax.LocalTaxAmount.ToString();

            TipTotalLbl.Text = "Total Tax: " + tipTax.CalculateTotalTaxAmount().ToString();
            SubtotalTipTotalLbl.Text = "Taxed Subtotal: " + subtotal + " + " + tipTax.CalculateTotalTaxAmount().ToString() + " = " + (subtotal + tipTax.CalculateTotalTaxAmount()).ToString();
        }
        private void DisplaySmallOrderFeeSectionMath(decimal subtotal)
        {
            UnroundedCitySmallLbl.Text = "Unrounded City Small Order Fee Tax: " + subtotal + " x " + smallTax.CityTaxRate.ToString() + " = " + smallTax.CityTaxAmountUnrounded.ToString();
            RoundedCitySmallLbl.Text = "Rounded City Small Order Fee Tax:    " + smallTax.CityTaxAmount.ToString();

            UnroundedStateSmallLbl.Text = "Unrounded State Small Order Fee Tax: " + subtotal + " x " + smallTax.StateTaxRate.ToString() + " = " + smallTax.StateTaxAmountUnrounded.ToString();
            RoundedStateSmallLbl.Text = "Rounded State Small Order Fee Tax:    " + smallTax.StateTaxAmount.ToString();

            UnroundedLocalSmallLbl.Text = "Unrounded Local Small Order Fee Tax: " + subtotal + " x " + smallTax.LocalTaxRate.ToString() + " = " + smallTax.LocalTaxAmountUnrounded.ToString();
            RoundedLocalSmallLbl.Text = "Rounded Local Small Order Fee Tax:    " + smallTax.LocalTaxAmount.ToString();

            SmallTotalLbl.Text = "Total Tax: " + smallTax.CalculateTotalTaxAmount().ToString();
            SubtotalSmallTotalLbl.Text = "Taxed Subtotal: " + subtotal + " + " + smallTax.CalculateTotalTaxAmount().ToString() + " = " + (subtotal + smallTax.CalculateTotalTaxAmount()).ToString();
        }

        private decimal SetTax(string TaxRateAmount, decimal DefaultTaxRate = 0.0M)
        {
            if(decimal.TryParse(TaxRateAmount, out decimal amount))
            {
                if (amount > 0)
                    return (amount / 100);
            }
            return DefaultTaxRate;
        }

        private void SetTaxes()
        {
            salesTax.CityTaxRate =  SetTax(SalesCityTxt.Text);
            salesTax.StateTaxRate = SetTax(SalesStateTxt.Text);
            salesTax.LocalTaxRate = SetTax(SalesLocalTxt.Text);

            occTax.CityTaxRate =    SetTax(OccCityTxt.Text);
            occTax.StateTaxRate =   SetTax(OccStateTxt.Text);
            occTax.LocalTaxRate =   SetTax(OccLocalTxt.Text);

            bevTax.CityTaxRate =    SetTax(BevCityTxt.Text);
            bevTax.StateTaxRate =   SetTax(BevStateTxt.Text);
            bevTax.LocalTaxRate =   SetTax(BevLocalTxt.Text);

            delivTax.CityTaxRate =  SetTax(DeliveryFeeCityTxt.Text);
            delivTax.StateTaxRate = SetTax(DeliveryFeeStateTxt.Text);
            delivTax.LocalTaxRate = SetTax(DeliveryFeeLocalTxt.Text);

            servTax.CityTaxRate =   SetTax(ServiceFeeCityTxt.Text);
            servTax.StateTaxRate =  SetTax(ServiceFeeStateTxt.Text);
            servTax.LocalTaxRate =  SetTax(ServiceFeeLocalTxt.Text);

            smallTax.CityTaxRate =  SetTax(SmallOrderFeeCityTxt.Text);
            smallTax.StateTaxRate = SetTax(SmallOrderFeeStateTxt.Text);
            smallTax.LocalTaxRate = SetTax(SmallOrderFeeLocalTxt.Text);

            tipTax.CityTaxRate =    SetTax(TipCityTxt.Text);
            tipTax.StateTaxRate =   SetTax(TipStateTxt.Text);
            tipTax.LocalTaxRate =   SetTax(TipLocalTxt.Text);
        }

        //--> Sloan: Get the total of all prices in a field
        private decimal GetSum(TextBox textBox)
        {
            decimal sum = 0;
            string temp = textBox.Text.Replace(',', '\n');
            var prices = new List<string>(temp.Split('\n'));
            for (int i = 0; i < prices.Count; i++)
            {
                try
                {
                    decimal price = decimal.Parse(prices[i]);
                    price = Math.Truncate(price * 100) / 100;
                    sum += price;
                }
                catch (FormatException) { continue; }
            }
            return sum;
        }

        //--> Sloan: Clearing price fields
        private void SubtotalPricesLbl_Click(object sender, EventArgs e)
        {
            SubtotalPricesTxt.Text = "";
        }

        private void BevPricesLbl_Click(object sender, EventArgs e)
        {
            BevPricesTxt.Text = "";
        }

        private void NontaxablePricesLbl_Click(object sender, EventArgs e)
        {
            NontaxablePricesTxt.Text = "";
        }

        private void DeliveryFeesLbl_Click(object sender, EventArgs e)
        {
            DeliveryFeeTxt.Text = "";
        }


        //--> Sloan: Clearing tax rates
        private void SalesTaxLbl_Click(object sender, EventArgs e)
        {
            SalesCityTxt.Text = "";
            SalesStateTxt.Text = "";
            SalesLocalTxt.Text = "";
        }

        private void BevTaxLbl_Click(object sender, EventArgs e)
        {
            BevCityTxt.Text = "";
            BevStateTxt.Text = "";
            BevLocalTxt.Text = "";
        }

        private void OccTaxLbl_Click(object sender, EventArgs e)
        {
            OccCityTxt.Text = "";
            OccStateTxt.Text = "";
            OccLocalTxt.Text = "";
        }

        private void DeliveryTaxLbl_Click(object sender, EventArgs e)
        {
            DeliveryFeeCityTxt.Text = "";
            DeliveryFeeStateTxt.Text = "";
            DeliveryFeeLocalTxt.Text = "";
        }

        private void SaveTaxRates()
        {
            SetTaxes();
            salesTax.DeleteSavedTaxRates();
            salesTax.SaveTaxRates();
            bevTax.SaveTaxRates();
            occTax.SaveTaxRates();
            delivTax.SaveTaxRates();
            servTax.SaveTaxRates();
            smallTax.SaveTaxRates();
            tipTax.SaveTaxRates();
        }

        private void TaxCalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to save your tax rates?", "Save Tax Rates?", MessageBoxButtons.YesNoCancel);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    SaveTaxRates();
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void PennyRoundingChk_CheckedChanged(object sender, EventArgs e)
        {
            PennyRounding = !PennyRounding;
            ReceiptPennyRoundedLbl.Visible = PennyRounding;
            ReceiptPennyRoundingActualLbl.Visible = PennyRounding;
        }

        private void ZeroSubtotalChk_CheckedChanged(object sender, EventArgs e)
        {
            ZeroTotal = !ZeroTotal;
        }
    }
}

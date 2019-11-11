using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sloanTaxCalculator
{
    public partial class TaxCalculatorForm : Form
    {
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

        public TaxCalculatorForm()
        {
            InitializeComponent();
            
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
            salesTax.CalculateTaxes(SalesSubtotal + OccAmount);
            DisplaySubtotalSectionMath(SalesSubtotal + OccAmount);

            //--> Calculate & Display the beverage tax
            bevTax.CalculateTaxes(BeverageSubtotal + OccAmount);
            DisplayBeverageSectionMath(BeverageSubtotal + OccAmount);

            //--> Calculate & Display the delivery fee tax
            delivTax.CalculateTaxes(DeliveryFeeSubtotal + OccAmount);
            DisplayDeliveryFeeSectionMath(DeliveryFeeSubtotal + OccAmount);

            //--> Calculate & Display the service fee tax
            servTax.CalculateTaxes(ServiceFeeSubtotal + OccAmount);
            //DisplayServiceFeeSectionMath(ServiceFeeSubtotal + OccAmount);

            //--> Calculate & Display the small order fee tax
            smallTax.CalculateTaxes(SmallOrderFeeSubtotal + OccAmount);
            //DisplaySmallOrderFeeSectionMath(SmallOrderFeeSubtotal + OccAmount);

            tipTax.CalculateTaxes(TipSubtotal);
            //DisplayTipSectionMath(TipSubtotal);

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
            ReceiptDeliveryTaxActualLbl.Text = delivTax.CalculateTotalTaxAmount().ToString();

            ReceiptOccTaxActualLbl.Text = occTax.CalculateTotalTaxAmount().ToString();
            ReceiptSalesTaxActualLbl.Text = (salesTax.CalculateTotalTaxAmount() + bevTax.CalculateTotalTaxAmount()).ToString();

            ReceiptTotalActualLbl.Text = (TaxableSubtotal + NontaxableSubtotal 
                + occTax.CalculateTotalTaxAmount()
                + salesTax.CalculateTotalTaxAmount()
                + delivTax.CalculateTotalTaxAmount()
                + bevTax.CalculateTotalTaxAmount()).ToString();
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
        private void DisplayDeliveryFeeSectionMath(decimal subtotal)
        {
            UnroundedCityDelivLbl.Text = "Unrounded City Delivery Tax: " + subtotal + " x " + delivTax.CityTaxRate.ToString() + " = " + delivTax.CityTaxAmountUnrounded.ToString();
            RoundedCityDelivLbl.Text = "Rounded City Delivery Tax:    " + delivTax.CityTaxAmount.ToString();

            UnroundedStateDelivLbl.Text = "Unrounded State Delivery Tax: " + subtotal + " x " + delivTax.StateTaxRate.ToString() + " = " + delivTax.StateTaxAmountUnrounded.ToString();
            RoundedStateDelivLbl.Text = "Rounded State Delivery Tax:    " + delivTax.StateTaxAmount.ToString();

            UnroundedLocalDelivLbl.Text = "Unrounded Local Delivery Tax: " + subtotal + " x " + delivTax.LocalTaxRate.ToString() + " = " + delivTax.LocalTaxAmountUnrounded.ToString();
            RoundedLocalDelivLbl.Text = "Rounded Local Delivery Tax:    " + delivTax.LocalTaxAmount.ToString();

            DelivTotalLbl.Text = "Total Tax: " + delivTax.CalculateTotalTaxAmount().ToString();
            SubtotalDelivTotalLbl.Text = "Taxed Subtotal: " + subtotal + " + " + delivTax.CalculateTotalTaxAmount().ToString() + " = " + (subtotal + delivTax.CalculateTotalTaxAmount()).ToString();
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

        private void SetTaxes()
        {
            try { salesTax.CityTaxRate = decimal.Parse(SalesCityTxt.Text) / 100; }
            catch (FormatException) { salesTax.CityTaxRate = 0; }
            try { salesTax.StateTaxRate = decimal.Parse(SalesStateTxt.Text) / 100; }
            catch (FormatException) { salesTax.StateTaxRate = 0; }
            try { salesTax.LocalTaxRate = decimal.Parse(SalesLocalTxt.Text) / 100; }
            catch (FormatException) { salesTax.LocalTaxRate = 0; }

            try { occTax.CityTaxRate = decimal.Parse(OccCityTxt.Text) / 100; }
            catch (FormatException) { occTax.CityTaxRate = 0; }
            try { occTax.StateTaxRate = decimal.Parse(OccStateTxt.Text) / 100; }
            catch (FormatException) { occTax.StateTaxRate = 0; }
            try { occTax.LocalTaxRate = decimal.Parse(OccLocalTxt.Text) / 100; }
            catch (FormatException) { occTax.LocalTaxRate = 0; }

            try { bevTax.CityTaxRate = decimal.Parse(BevCityTxt.Text) / 100; }
            catch (FormatException) { bevTax.CityTaxRate = 0; }
            try { bevTax.StateTaxRate = decimal.Parse(BevStateTxt.Text) / 100; }
            catch (FormatException) { bevTax.StateTaxRate = 0; }
            try { bevTax.LocalTaxRate = decimal.Parse(BevLocalTxt.Text) / 100; }
            catch (FormatException) { bevTax.LocalTaxRate = 0; }

            try { delivTax.CityTaxRate = decimal.Parse(DeliveryFeeCityTxt.Text) / 100; }
            catch (FormatException) { delivTax.CityTaxRate = 0; }
            try { delivTax.StateTaxRate = decimal.Parse(DeliveryFeeStateTxt.Text) / 100; }
            catch (FormatException) { delivTax.StateTaxRate = 0; }
            try { delivTax.LocalTaxRate = decimal.Parse(DeliveryFeeLocalTxt.Text) / 100; }
            catch (FormatException) { delivTax.LocalTaxRate = 0; }

            try { servTax.CityTaxRate = decimal.Parse(ServiceFeeCityTxt.Text) / 100; }
            catch (FormatException) { servTax.CityTaxRate = 0; }
            try { servTax.StateTaxRate = decimal.Parse(ServiceFeeStateTxt.Text) / 100; }
            catch (FormatException) { servTax.StateTaxRate = 0; }
            try { servTax.LocalTaxRate = decimal.Parse(ServiceFeeLocalTxt.Text) / 100; }
            catch (FormatException) { servTax.LocalTaxRate = 0; }

            try { smallTax.CityTaxRate = decimal.Parse(SmallOrderFeeCityTxt.Text) / 100; }
            catch (FormatException) { smallTax.CityTaxRate = 0; }
            try { smallTax.StateTaxRate = decimal.Parse(SmallOrderFeeStateTxt.Text) / 100; }
            catch (FormatException) { smallTax.StateTaxRate = 0; }
            try { smallTax.LocalTaxRate = decimal.Parse(SmallOrderFeeLocalTxt.Text) / 100; }
            catch (FormatException) { smallTax.LocalTaxRate = 0; }

            try { tipTax.CityTaxRate = decimal.Parse(TipCityTxt.Text) / 100; }
            catch (FormatException) { tipTax.CityTaxRate = 0; }
            try { tipTax.StateTaxRate = decimal.Parse(TipStateTxt.Text) / 100; }
            catch (FormatException) { tipTax.StateTaxRate = 0; }
            try { tipTax.LocalTaxRate = decimal.Parse(TipLocalTxt.Text) / 100; }
            catch (FormatException) { tipTax.LocalTaxRate = 0; }
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
    }
}

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
        private decimal OccAmount = 0;
        private decimal SalesSubtotal = 0;
        private decimal BeverageSubtotal = 0;
        private decimal DeliverySubtotal = 0;
        private decimal TaxableSubtotal = 0;
        private decimal NontaxableSubtotal = 0;

        public TaxCalculatorForm()
        {
            InitializeComponent();
            BaseTab.Text = "Calculator";
            CalculationTab.Text = "Calculations";
            
            salesTax = new Taxes("Sales Tax");
            occTax = new Taxes();
            bevTax = new Taxes();
            delivTax = new Taxes();

            SalesCityTxt.Text = salesTax.CityTaxRate.ToString();
            SetTaxes();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            SetTaxes();
            SalesSubtotal = GetSum(SubtotalPricesTxt);
            BeverageSubtotal = GetSum(BevPricesTxt);
            DeliverySubtotal = GetSum(DeliveryFeesTxt);
            NontaxableSubtotal = GetSum(NontaxablePricesTxt);
            TaxableSubtotal = SalesSubtotal + BeverageSubtotal + DeliverySubtotal;

            //--> Calculate & Display the occ subtotal
            occTax.CalculateTaxes(TaxableSubtotal);
            DisplayOccSectionMath(TaxableSubtotal);

            OccAmount = occTax.CalculateTotalTaxAmount();

            //--> Calculate & Display the sales tax
            salesTax.CalculateTaxes(SalesSubtotal + OccAmount);
            DisplaySubtotalSectionMath(SalesSubtotal + OccAmount);

            //--> Calculate & Display the delivery tax
            delivTax.CalculateTaxes(DeliverySubtotal + OccAmount);
            DisplayDeliverySectionMath(DeliverySubtotal + OccAmount);

            //--> Calculate & Display the beverage tax
            bevTax.CalculateTaxes(BeverageSubtotal + OccAmount);
            DisplayBeverageSectionMath(BeverageSubtotal + OccAmount);

            DisplayReceipt();
        }

        private void DisplayReceipt()
        {
            ReceiptTaxableTotalActualLbl.Text = (TaxableSubtotal - DeliverySubtotal).ToString();
            ReceiptNontaxableTotalActualLbl.Text = NontaxableSubtotal.ToString();
            ReceiptSubtotalActualLbl.Text = ((TaxableSubtotal - DeliverySubtotal) + NontaxableSubtotal).ToString();

            ReceiptDeliveryFeesActualLbl.Text = DeliverySubtotal.ToString();
            ReceiptDeliveryTaxActualLbl.Text = delivTax.CalculateTotalTaxAmount().ToString();

            ReceiptOccTaxActualLbl.Text = occTax.CalculateTotalTaxAmount().ToString();
            ReceiptSalesTaxActualLbl.Text = (salesTax.CalculateTotalTaxAmount() + bevTax.CalculateTotalTaxAmount()).ToString();

            ReceiptTotalActualLbl.Text = (TaxableSubtotal + NontaxableSubtotal 
                + occTax.CalculateTotalTaxAmount()
                + salesTax.CalculateTotalTaxAmount()
                + delivTax.CalculateTotalTaxAmount()
                + bevTax.CalculateTotalTaxAmount()).ToString();
        }

        private void DisplaySalesTaxes()
        {
            
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
            SubtotalOccTotalLbl.Text = "Taxed Subtotal: " + subtotal + " + " + occTax.CalculateTotalTaxAmount().ToString() + " = " + (subtotal + occTax.CalculateTotalTaxAmount()).ToString();
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
        private void DisplayDeliverySectionMath(decimal subtotal)
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

            try { delivTax.CityTaxRate = decimal.Parse(DeliveryCityTxt.Text) / 100; }
            catch (FormatException) { delivTax.CityTaxRate = 0; }
            try { delivTax.StateTaxRate = decimal.Parse(DeliveryStateTxt.Text) / 100; }
            catch (FormatException) { delivTax.StateTaxRate = 0; }
            try { delivTax.LocalTaxRate = decimal.Parse(DeliveryLocalTxt.Text) / 100; }
            catch (FormatException) { delivTax.LocalTaxRate = 0; }
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
            DeliveryFeesTxt.Text = "";
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
            DeliveryCityTxt.Text = "";
            DeliveryStateTxt.Text = "";
            DeliveryLocalTxt.Text = "";
        }
    }
}

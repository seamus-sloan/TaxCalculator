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
        private decimal subtotal = 0;
        private decimal nontaxable = 0;

        public TaxCalculatorForm()
        {
            InitializeComponent();
            salesTax = new Taxes();
            occTax = new Taxes();
            ApplyTaxes();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            ApplyTaxes();
            subtotal = GetSubtotalSum();

            //--> Calculate & Display the occ subtotal
            occTax.CalculateCityRateAmount(subtotal); //--> Move into one function? private void CalculateTaxes(Taxes taxes)
            occTax.CalculateStateRateAmount(subtotal);
            occTax.CalculateLocalRateAmount(subtotal);
            DisplayOccSectionMath();
            subtotal += occTax.CalculateTotalTaxAmount();

            //--> Calculate & Display the sales tax
            salesTax.CalculateCityRateAmount(subtotal);
            salesTax.CalculateStateRateAmount(subtotal);
            salesTax.CalculateLocalRateAmount(subtotal);
            DisplaySubtotalSectionMath();

            //--> Calculate & Display the delivery tax

            //--> Calculate & Display the beverage tax
        }

        private void DisplayOccSectionMath()
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

        private void DisplaySubtotalSectionMath()
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

        private void ApplyTaxes()
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
        }

        private void SubtotalPricesLbl_Click(object sender, EventArgs e)
        {
            SubtotalPricesTxt.Text = "";
        }

        private void NontaxablePricesLbl_Click(object sender, EventArgs e)
        {
            NontaxablePricesTxt.Text = "";
        }

        private void DeliveryFeesLbl_Click(object sender, EventArgs e)
        {
            DeliveryFeesTxt.Text = "";
        }

        private decimal GetSubtotalSum()
        {
            decimal sum = 0;
            var prices = new List<string>(SubtotalPricesTxt.Text.Split('\n'));
            for (int i = 0; i < prices.Count; i++)
            {
                try
                {
                    sum += decimal.Parse(prices[i]);
                }
                catch (FormatException) { continue; }
            }
            return sum;
        }
    }
}

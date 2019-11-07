using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sloanTaxCalculator
{
    class Taxes
    {
        public string[] lines;
        public string test;

        // Check for folder
        // if not there, create directory
        // put in documents
        // Check for file
        // if not there, create file

        // Read file
        // Get line matching TaxType
        // Ignore up to ':' and split line on ',' for tax rates


        public Taxes(string TaxType="")
        {
            string[] taxRates;
            string TextFile = @"C:\sloanSavedTaxRates\TaxRates.txt";
            if (System.IO.File.Exists(TextFile) && TaxType != "")
            {
                lines = System.IO.File.ReadAllLines(TextFile);
                foreach (string line in lines)
                {
                    if (line.Contains(TaxType))
                    {
                        test = line.Replace(TaxType + ": ", "");
                        taxRates = test.Split(',');
                        CityTaxRate = decimal.Parse(taxRates[0]);
                        StateTaxRate = decimal.Parse(taxRates[1]);
                        LocalTaxRate = decimal.Parse(taxRates[2]);
                    }
                }
            }

        }

        public decimal CityTaxAmount { get; private set; }

        public decimal StateTaxAmount { get; private set; }

        public decimal LocalTaxAmount { get; private set; }

        public decimal CityTaxAmountUnrounded { get; private set; }

        public decimal StateTaxAmountUnrounded { get; private set; }

        public decimal LocalTaxAmountUnrounded { get; private set; }

        public decimal CityTaxRate { get; set; }

        public decimal StateTaxRate { get; set; }

        public decimal LocalTaxRate { get; set; }

        public void CalculateTaxes(decimal subtotal)
        {
            CalculateCityRateAmount(subtotal);
            CalculateLocalRateAmount(subtotal);
            CalculateStateRateAmount(subtotal);
        }

        public void CalculateCityRateAmount(decimal subtotal)
        {
            CityTaxAmountUnrounded = subtotal * CityTaxRate;
            CityTaxAmount = CalculateRoundedAmount(CityTaxAmountUnrounded);
        }

        public void CalculateLocalRateAmount(decimal subtotal)
        {
            LocalTaxAmountUnrounded = subtotal * LocalTaxRate;
            LocalTaxAmount = CalculateRoundedAmount(LocalTaxAmountUnrounded);
        }

        public void CalculateStateRateAmount(decimal subtotal)
        {
            StateTaxAmountUnrounded = subtotal * StateTaxRate;
            StateTaxAmount = CalculateRoundedAmount(StateTaxAmountUnrounded);
        }
        public decimal CalculateRoundedAmount(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.ToEven);
        }

        public decimal CalculateTotalTaxAmount()
        {
            return StateTaxAmount + CityTaxAmount + LocalTaxAmount;
        }
    }
}

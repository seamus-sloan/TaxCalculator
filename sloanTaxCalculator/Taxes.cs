using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sloanTaxCalculator
{
    class Taxes
    {
        public string name;
        public string[] lines;
        public string test;
        public static string MyDocumentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string TaxRatesDirectory = MyDocumentsDirectory+ "/sloanSavedTaxRates";
        public static string TaxRatesFile = TaxRatesDirectory + "/TaxRates.txt";


        public Taxes(string TaxType="")
        {
            name = TaxType;
            ReadTaxRates();
        }

        private void ReadTaxRates()
        {
            if (System.IO.Directory.Exists(MyDocumentsDirectory))
            {
                if (System.IO.Directory.Exists(TaxRatesDirectory))
                {
                    if (System.IO.File.Exists(TaxRatesFile))
                    {
                        lines = System.IO.File.ReadAllLines(TaxRatesFile);
                        foreach (string line in lines)
                        {
                            string[] taxRates;
                            if (line.Contains(name))
                            {
                                test = line.Replace(name + ": ", "");
                                taxRates = test.Split(',');
                                CityTaxRate = decimal.Parse(taxRates[0]);
                                StateTaxRate = decimal.Parse(taxRates[1]);
                                LocalTaxRate = decimal.Parse(taxRates[2]);
                            }
                        }
                    }
                    else
                    {
                        // NO TAX RATES FILE
                        System.IO.File.Create(TaxRatesFile);
                    }
                }
                else
                {
                    // NO TAX RATES DIRECTORY
                    System.IO.Directory.CreateDirectory(TaxRatesDirectory);
                    System.IO.File.Create(TaxRatesFile);
                }
            }
            else
            {
                // NO MYDOCUMENTS DIRECTORY
                // Create a new error message in a popup window
            }
        }

        public void DeleteSavedTaxRates()
        {
            System.IO.File.Delete(TaxRatesFile);
        }

        public void SaveTaxRates()
        {
            System.IO.File.AppendAllText(TaxRatesFile, Environment.NewLine + name + ": " + CityTaxRate * 100 + ", " + StateTaxRate * 100 + ", " + LocalTaxRate * 100);
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

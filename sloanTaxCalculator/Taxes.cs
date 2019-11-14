using System;
using System.IO;

namespace sloanTaxCalculator
{
    class Taxes
    {
        private string _name;
        private string[] lines;
        private static readonly char DIR_SEP = Path.DirectorySeparatorChar;
        private static readonly string TAX_RATES_DIR = "sloanSavedTaxRates";
        private static readonly string TAX_RATES_FILE = "TaxRates.txt";
        private static readonly string _baseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static readonly string _taxRatesDirectory = _baseDirectory + DIR_SEP + TAX_RATES_DIR;
        private static readonly string _taxRatesFile = _taxRatesDirectory + DIR_SEP + TAX_RATES_FILE;


        public Taxes(string TaxType = "")
        {
            _name = TaxType;
            ReadTaxRates();
        }

        //--> Sloan: Used to create (if not present), read, and set
        //           tax rates for a given tax rate
        private void ReadTaxRates()
        {
            if (Directory.Exists(_baseDirectory))
            {
                if (Directory.Exists(_taxRatesDirectory))
                {
                    if (File.Exists(_taxRatesFile))
                    {
                        lines = File.ReadAllLines(_taxRatesFile);
                        foreach (string line in lines)
                        {
                            string[] taxRates;
                            if (line.Contains(_name))
                            {
                                string temp = line.Replace(_name + ": ", "");
                                taxRates = temp.Split(',');
                                CityTaxRate = decimal.Parse(taxRates[0]);
                                StateTaxRate = decimal.Parse(taxRates[1]);
                                LocalTaxRate = decimal.Parse(taxRates[2]);
                            }
                        }
                    }
                    else // No Tax Rates File
                    {
                        var tempFile = File.Create(_taxRatesFile);
                        tempFile.Close();
                    }
                }
                else // No Tax Rates Directory
                {
                    Directory.CreateDirectory(_taxRatesDirectory);
                    var tempFile = File.Create(_taxRatesFile);
                    tempFile.Close();
                }
            }
        }

        //--> Sloan: Only purpose of this is to delete the file and
        //           create it again in the SaveTaxRates() function
        //           with the updated tax rates.
        public void DeleteSavedTaxRates()
        {
            if (File.Exists(_taxRatesFile))
            {
                try { File.Delete(_taxRatesFile); }
                catch (IOException ioex) { throw ioex; }
            }
        }

        public void SaveTaxRates()
        {
            if (Directory.Exists(Path.GetDirectoryName(_taxRatesDirectory)))
            {
                try
                {
                    string TextToAppend = Environment.NewLine + _name + ": " + CityTaxRate * 100 + ", " + StateTaxRate * 100 + ", " + LocalTaxRate * 100;
                    if (File.Exists(_taxRatesFile))
                        File.AppendAllText(_taxRatesFile, TextToAppend);
                    else
                        File.WriteAllText(_taxRatesFile, TextToAppend);
                }
                catch (IOException ioex)
                {
                    throw ioex;
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
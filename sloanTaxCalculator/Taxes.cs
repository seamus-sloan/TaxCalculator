using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sloanTaxCalculator
{
    class Taxes
    {
        public decimal CityTaxAmount { get; private set; }

        public decimal StateTaxAmount { get; private set; }

        public decimal LocalTaxAmount { get; private set; }

        public decimal CityTaxAmountUnrounded { get; private set; }

        public decimal StateTaxAmountUnrounded { get; private set; }

        public decimal LocalTaxAmountUnrounded { get; private set; }

        public decimal CityTaxRate { get; set; }

        public decimal StateTaxRate { get; set; }

        public decimal LocalTaxRate { get; set; }

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

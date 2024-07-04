using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Market
    {
        private static double CurrencyARate = 100.0;
        private static double CurrencyBRate = 100.0;

        public static double CurrencyAValue()
        {
            CurrencyARate += CurrencyARate * (rand.NextDouble() * 0.01 - 0.005);
            return CurrencyARate;
        }

        public static double CurrencyBValue()
        {
            CurrencyBRate += CurrencyBRate * (rand.NextDouble() * 0.01 - 0.005);
            return CurrencyBRate;
        }

    }


}

using System;

namespace SteamTests.HelpClasses
{
    public class DiscountInfo
    {
        public double Discount;
        public double OldPrice;
        public double NewPrice;

        public DiscountInfo(double discount, double oldPrice, double newPrice)
        {
            this.Discount = discount;
            this.OldPrice = oldPrice;
            this.NewPrice = newPrice;
        }

        public DiscountInfo(string discount, string oldPrice, string newPrice)
        {
            double discountNormalized = Convert.ToDouble(discount.Trim('-', '%'));
            double oldPriceNormalized = Convert.ToDouble(oldPrice.Trim('$').Replace(".", "").Replace("USD", ""));
            double newPriceNormalized = Convert.ToDouble(newPrice.Trim('$').Replace(".", "").Replace("USD", ""));

            this.Discount = discountNormalized;
            this.OldPrice = oldPriceNormalized;
            this.NewPrice = newPriceNormalized;
        }

        public override bool Equals(object obj)
        {
            var info = obj as DiscountInfo;

            if (this.Discount == info.Discount &&
                this.NewPrice == info.NewPrice &&
                this.OldPrice == info.OldPrice) 
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Discount, OldPrice, NewPrice);
        }
    }
}

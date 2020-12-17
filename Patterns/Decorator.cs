namespace Patterns
{
    public interface IBike
    {
        string GetDetails();
        double GetPrice();
    }

    public class AluminiumBike : IBike
    {
        public string GetDetails()
        {
            return "Aluminium Bike";
        }

        public double GetPrice()
        {
            return 100;
        }
    }

    public class CarbonBike : IBike
    {
        public string GetDetails()
        {
            return "Carbon Bike";
        }

        public double GetPrice()
        {
            return 1000;
        }
    }

    public abstract class BikeAccessories : IBike
    {
        private readonly IBike _bike;

        public BikeAccessories(IBike bike)
        {
            _bike = bike;
        }

        public virtual string GetDetails()
        {
            return _bike.GetDetails();
        }

        public virtual double GetPrice()
        {
            return _bike.GetPrice();
        }
    }

    public class SecurityPackage : BikeAccessories
    {
        public SecurityPackage(IBike bike) : base(bike)
        {
        }

        public override string GetDetails()
        {
            return base.GetDetails() + " + Security Package";
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 100;
        }
    }

    public class SportPackage : BikeAccessories
    {
        public SportPackage(IBike bike) : base(bike)
        {
        }

        public override string GetDetails()
        {
            return base.GetDetails() + " + Sport Package";
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 150;
        }
    }

    public class DiscountPackage : BikeAccessories
    {
       public double Percentage { get; set; }
        public DiscountPackage(IBike bike, double percentage) : base(bike)
        {
            Percentage = percentage;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $" + Discount Package of {Percentage * 100}%";
        }

        public override double GetPrice()
        {
            return base.GetPrice() - (base.GetPrice() * Percentage);
        }
    }

    public class BikeShop
    {
        public static void UpgradeBike()
        {
            var basicBike = new CarbonBike();
            BikeAccessories upgraded = new SportPackage(basicBike);
            upgraded = new SecurityPackage(upgraded);
            upgraded = new DiscountPackage(upgraded, 0.1);

            var basicBike2 = new AluminiumBike();
            BikeAccessories upgraded2 = new SportPackage(basicBike2);
            upgraded2 = new SecurityPackage(upgraded2);

            System.Console.WriteLine($"Bike: '{upgraded.GetDetails()}' Cost: {upgraded.GetPrice()}");
            System.Console.WriteLine($"Bike: '{upgraded2.GetDetails()}' Cost: {upgraded2.GetPrice()}");
        }   
    }
}
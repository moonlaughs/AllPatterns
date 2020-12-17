using System;

namespace Patterns
{
    /*
    Showcase for the Factory Pattern

    -creational
    -Static Factory Method is NOT the same as the static factory method
    -static factory method is a static method that returns an instance of a class

    */
    public interface IFactory
    {
        void Drive(int miles);
    }

    public class Car : IFactory 
    {
        public void Drive(int miles)
        {
            System.Console.WriteLine("Drive the Car : " + miles.ToString() + "km");
        }
    }

    public class Bike : IFactory
    {
        public void Drive(int miles)
        {
            System.Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }
    }

    public class Truck : IFactory
    {
        public void Drive(int miles)
        {
            System.Console.WriteLine("Drive the Truck : " + miles.ToString() + "km");
        }
    }

    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(string Vehicle);
    }

    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(string vehicle)
        {
            switch (vehicle)
            {
                case "Car":
                    return new Car();
                case "Bike":
                    return new Bike();
                case "Truck":
                    return new Truck();
                default:
                    //throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", vehicle));             //for only Factory
                    return new NullObject(); //Factory with Null
            }
        }
    }

    /*
    Showcase for a Null object pattern

    -> behavioral
    */
    public class NullObject : IFactory
    {
        public void Drive(int miles)
        {
            throw new ApplicationException(string.Format("Vehicle cannot be created"));
        }
    }

    public static class RunFactoryPattern
    {
        public static void Run()
        {
             try
            {
                VehicleFactory factory = new ConcreteVehicleFactory();

                IFactory car = factory.GetVehicle("Car");
                car.Drive(10);

                IFactory bike = factory.GetVehicle("Bike");
                bike.Drive(20);

                System.Console.WriteLine("3.Null Object======================");
                var sthElse = factory.GetVehicle("Lorry");
                sthElse.Drive(1245);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("No such vehicle");
            }
        }
    }
}
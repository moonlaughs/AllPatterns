using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Patterns
{
    //<--structural

    // The Flyweight stores a common portion of the state (also called intrinsic
    // state) that belongs to multiple real business entities. The Flyweight
    // accepts the rest of the state (extrinsic state, unique for each entity)
    // via its method parameters.
    public class Flyweight
    {
        private FlyweightCar _sharedState;

        public Flyweight(FlyweightCar car)
        {
            this._sharedState = car;
        }

        public void Operation(FlyweightCar uniqueState)
        {
            string s = JsonConvert.SerializeObject(this._sharedState);
            string u = JsonConvert.SerializeObject(uniqueState);
            System.Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
        }
    }

    public class FlyweightCar
    {
        public string Owner { get; set; }

        public string Number { get; set; }

        public string Company { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }
    }

    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params FlyweightCar[] args)
        {
            foreach(var elem in args)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), this.getKey(elem)));
            }
        }

        private string getKey(FlyweightCar key)
        {
            List<string> elements = new List<string>();

            elements.Add(key.Model);
            elements.Add(key.Color);
            elements.Add(key.Company);

            if(key.Owner != null && key.Number != null)
            {
                elements.Add(key.Number);
                elements.Add(key.Owner);
            }

            elements.Sort();

            return string.Join("_", elements);
        }

        // Returns an existing Flyweight with a given state or creates a new
        // one.    
        public Flyweight GetFlyweight(FlyweightCar sharedState)
        {
            string key = this.getKey(sharedState);

            if(flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                System.Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }    

        public void ListFlyweights()
        {
            var count = flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }

    public static class RunFlyweightPattern
    {
        public static void Run()
        {
            // The client code usually creates a bunch of pre-populated
            // flyweights in the initialization stage of the application.
            var factory = new FlyweightFactory(
                new FlyweightCar { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new FlyweightCar { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new FlyweightCar { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new FlyweightCar { Company = "BMW", Model = "M5", Color = "red" },
                new FlyweightCar { Company = "BMW", Model = "X6", Color = "white" }
            );
            factory.ListFlyweights();

            addCarToPoliceDatabase(factory, new FlyweightCar {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            });

            addCarToPoliceDatabase(factory, new FlyweightCar {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            });

            factory.ListFlyweights();
        }

        public static void addCarToPoliceDatabase(FlyweightFactory factory, FlyweightCar car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = factory.GetFlyweight(new FlyweightCar {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            // The client code either stores or calculates extrinsic state and
            // passes it to the flyweight's methods.
            flyweight.Operation(car);
        }
        
    }
}
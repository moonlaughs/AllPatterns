using System.Collections.Generic;

namespace Patterns
{
    /*
    ->creational pattern
    */
    public interface ICakeBuilder
    {
        
        // The Builder interface specifies methods for creating the different parts
        // of the Product objects.
        void BuildBase(string myBase);
        void AddFruit(string fruit);
    }

    public class CakeBuilder : ICakeBuilder
    {
        private Cake _product = new Cake();

        public CakeBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new Cake();
        }

        public void AddFruit(string fruit)
        {
            this._product.Add(fruit);
            System.Console.WriteLine("Fruit added");
        }

        public void BuildBase(string myBase)
        {
            this._product.Add(myBase);
            System.Console.WriteLine("Base: " + myBase);
        }

        public Cake GetCake()
        {
            Cake result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Cake
    {
        private List<object> _parts = new List<object>();
        
        public void Add(string part)
        {
            this._parts.Add(part);
        }
        
        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Cake parts: " + str + "\n";
        }
    }

    public class Director
    {
        private ICakeBuilder _builder;

        public ICakeBuilder Builder
        {
            set { _builder = value; }
        }

        public void MakeChockolateCakeWithFruit()
        {
            this._builder.BuildBase("chockolate");
            this._builder.AddFruit("strawberries");
        }

        public void MAkeFruitCake()
        {
            this._builder.BuildBase("fruit");
            //this._builder.AddFruit("forest fruit");
        }
    }

    public static class RunBuilderPattern
    {
        public static void Run()
        {
            var Director = new Director();
            var builder = new CakeBuilder();
            Director.Builder = builder;

            System.Console.WriteLine("Chockolate Cake");
            Director.MakeChockolateCakeWithFruit();
            System.Console.WriteLine(builder.GetCake().ListParts());

            System.Console.WriteLine("Fruit Cake");
            Director.MAkeFruitCake();
            System.Console.WriteLine(builder.GetCake().ListParts());
        }
    }
}
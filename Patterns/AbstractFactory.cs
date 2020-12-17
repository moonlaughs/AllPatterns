namespace Patterns
{
    public class AnimalWorld
    {
        public static IContinetFactory CreateContinent(string continet)
        {
            IContinetFactory cf;
            if(continet.ToLower().Trim() == "america")
            {
                cf = new AmericaFactory();
            }
            else
            {
                cf = new AfricaFactory();
            }

            return cf;
        }

        private AnimalWorld()
        {

        }
    }

    public interface IContinetFactory
    {
        public IHerbivore CreateHerbivore();
        public ICarnivore CreateCarnivore();
    }

    public interface ICarnivore
    {
        public void Hunt();
    }

    public interface IHerbivore
    {
        public void Eat();
    }

    internal class AfricaFactory : IContinetFactory
    {
        public ICarnivore CreateCarnivore()
        {
            return new Lion();
        }

        public IHerbivore CreateHerbivore() //this is a factory itself
        {
            return new WildeBeast(); 
        }
    }

    internal class WildeBeast : IHerbivore
    {
        public void Eat()
        {
            System.Console.WriteLine("WildeBeast eats...");
        }
    }

    internal class Lion : ICarnivore
    {
        public void Hunt()
        {
            System.Console.WriteLine("Lion Hunts...");
        }
    }

    internal class AmericaFactory : IContinetFactory
    {
        public ICarnivore CreateCarnivore()
        {
            return new Wolf();
        }

        public IHerbivore CreateHerbivore()
        {
            return new Bison();
        }
    }

    internal class Bison : IHerbivore
    {
        public void Eat()
        {
            System.Console.WriteLine("Bison eats...");
        }
    }

    internal class Wolf : ICarnivore
    {
        public void Hunt()
        {
            System.Console.WriteLine("Lion hunts...");
        }
    }

    public static class RunAbstractFactory
    {
        public static void Run()
        {
            IContinetFactory america = AnimalWorld.CreateContinent("america");

            america.CreateCarnivore().Hunt();
            america.CreateHerbivore().Eat();

            IContinetFactory africa = AnimalWorld.CreateContinent("africa");
            africa.CreateCarnivore().Hunt();
            africa.CreateHerbivore().Eat();
        }
    }
}
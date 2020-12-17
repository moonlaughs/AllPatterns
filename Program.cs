using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Patterns");
            System.Console.WriteLine("\n1.Singleton======================");
            RunSingletonPattern.Run();

            System.Console.WriteLine("\n2.Factory======================");
            RunFactoryPattern.Run(); //<- inside is Null Object PAttern included

            System.Console.WriteLine("\n4.Abstract Factory======================");
            RunAbstractFactory.Run();

            System.Console.WriteLine("\n5.Prototype======================");
            RunPrototypePattern.Run();
            
            System.Console.WriteLine("\n6.Builder======================");
            RunBuilderPattern.Run();
            
            System.Console.WriteLine("\n7.Facade======================");
            RunFacadePattern.Run();
            
            System.Console.WriteLine("\n8.Flyweight======================");
            RunFlyweightPattern.Run();
            
            System.Console.WriteLine("\n9.Bridge======================");
            RunBridgePattern.Run();
            
            System.Console.WriteLine("\n10.Command======================");
            RunCommandPattern.Run();

            System.Console.WriteLine("\n11.Visitor======================");
            RunVisitorPattern.Run();

            System.Console.WriteLine("\n12.Observer======================");
            RunObserverPattern.Run();

            System.Console.WriteLine("\n13.Strategy======================");
            StrategyPattern.RunStrategyPattern();
            
            System.Console.WriteLine("\n14.Composite======================");
            RunCompositePattern.Run();

            System.Console.WriteLine("\n15.Iterator======================");
            RunIteratorPattern.Run();

            System.Console.WriteLine("\n16.Decorator======================");
            BikeShop.UpgradeBike();
            
            System.Console.WriteLine("\n17.State======================");
            RunStatePattern.Run();

            System.Console.WriteLine("\n18.Template Method======================");
            RunTemplateMethodPattern.Run();

            System.Console.WriteLine("\n19.Adapter======================");
            RunAdapterPattern.Run();

            System.Console.WriteLine("\n20.Chain of Resposnibility======================");
            RunChainOfResponsibilityPattern.Run();
        }
    }
}

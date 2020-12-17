using System;

namespace Patterns
{
    /*
    -> Facade
    */
    
    // The Facade class provides a simple interface to the complex logic of one
    // or several subsystems. The Facade delegates the client requests to the
    // appropriate objects within the subsystem. The Facade is also responsible
    // for managing their lifecycle. All of this shields the client from the
    // undesired complexity of the subsystem.
    
    public class Facade
    {
        protected Subsystem1 _subsystem1;
        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }

        // The Facade's methods are convenient shortcuts to the sophisticated
        // functionality of the subsystems. However, clients get only to a
        // fraction of a subsystem's capabilities.
        public string Operation()
        {
            string result = "Facade inilializes subsystems\n";
            result += this._subsystem1.Operation1();
            result += this._subsystem2.Operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this._subsystem1.OperationN();
            result += this._subsystem2.OperationZ();
            return result;
        }
    }

    public class Subsystem2
    {
        public string Operation1()
        {
            return "Subsystem 2: Get ready!\n";
        }

        public string OperationZ()
        {
            return "Subsystem 2: Fire!\n";
        }
    }

    public class Subsystem1
    {
        public string Operation1()
        {
            return "Subsystem 1: Get ready!\n";
        }

        public string OperationN()
        {
            return "Subsystem 1: Go!\n";
        }
    }

    public static class RunFacadePattern
    {
        public static void Run()
        {
            Subsystem1 s1 = new Subsystem1();
            Subsystem2 s2 = new Subsystem2();

            Facade facade = new Facade(s1,s2);
            System.Console.WriteLine(facade.Operation());
        }
    }
}
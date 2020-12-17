using System.Runtime.CompilerServices;

namespace Patterns
{
    /*
    Showcase for singleton Pattern elements

    -> creational
    
    Singleton is defined only when:
    1. One instance only can be created
    2. There is only one access point
    */

    //Lazy Singleton -> Waiting until you need it
    public class LazySingleton
    {
        private volatile static LazySingleton _instance; //volatile -> provides double check locking

        //private constructor does not allow new objects 
        //in other classes of this to be created by using "new" keyword
        private LazySingleton(){

        }

        //public method == the only access point
        [MethodImpl(MethodImplOptions.Synchronized)] //synchronized to make it thread safe
        public static LazySingleton GetInstance(){
            if(_instance == null){
                _instance = new LazySingleton();
            }
            return _instance;
        }
    }

/*
Get initialized as soon as the program runs
*/
    public class EagerSingleton{
        private static EagerSingleton _instance = new EagerSingleton();

        //private constructor does not allow to create a new object of this class
        private EagerSingleton()
        {
            
        }

        public static EagerSingleton GetInstance(){
            return EagerSingleton._instance;
        }
    }

    public class ExtraEagerSingleton{
        //public and readonly does not need a getInstance method
        public readonly static ExtraEagerSingleton _instance = new ExtraEagerSingleton();

        //private constructor does not allow to create a new object of this class
        private ExtraEagerSingleton()
        {
            
        }
    }

    public static class RunSingletonPattern
    {
        public static void Run()
        {
            //LazySingleton firstLazySingletonObj = new LazySingleton(); <--not allowed
            //here we create a new instance
            LazySingleton secondLazySingletonObject = LazySingleton.GetInstance();
            //here we reassign the same instance
            LazySingleton thirdLazySingleton = LazySingleton.GetInstance();
            if(secondLazySingletonObject.Equals(thirdLazySingleton)){
                System.Console.WriteLine("LazySingletonObjects are equal");
            }
            else
            {
                System.Console.WriteLine("LazySingletonObjects are NOT equal");
            }

            //EagerSingleton firstEagerSingleton = new EagerSingleton(); <--not allowed
            EagerSingleton secondEagerSingleton = EagerSingleton.GetInstance();
            EagerSingleton thirdEagerSingleton = EagerSingleton.GetInstance();
            if(secondEagerSingleton.Equals(thirdEagerSingleton)){
                System.Console.WriteLine("EagerSingletonObjects are equal");
            }
            else
            {
                System.Console.WriteLine("EagerSingletonObjects are NOT equal");
            }

            //ExtraEagerSingleton firstExtraEagerSingleton = new ExtraEagerSingleton(); <-- not allowed
            ExtraEagerSingleton secondExtraEagerSingletonObj = ExtraEagerSingleton._instance;
            ExtraEagerSingleton thirdExtraEagerSingletonObj = ExtraEagerSingleton._instance;
            if(secondExtraEagerSingletonObj.Equals(thirdExtraEagerSingletonObj)){
                System.Console.WriteLine("ExtraEagerSingletonObjects are equal");
            }
            else
            {
                System.Console.WriteLine("ExtraEagerSingletonObjects are NOT equal");
            }
        }
    }
}
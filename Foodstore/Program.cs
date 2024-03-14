using Foodstore.BuilderPattern;
using Foodstore.CommandPattern;
using Foodstore.Singleton;
using Foodstore.Singleton.SingletonPattern;
using Foodstore;
using FoodStore;

namespace Foodstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FoodStoreApp app = new FoodStoreApp();
            app.Run();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodstore.Singleton
{
    namespace SingletonPattern
    {
        public class FoodStore
        {
            private static FoodStore instance;
            private FoodStore() { }
            public static FoodStore GetInstance()
            {
                if (instance == null)
                {
                    instance = new FoodStore();
                }
                return instance;
            }
        }
    }
}

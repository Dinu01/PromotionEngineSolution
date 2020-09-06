using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineRules
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expected Input in a List of Character
            // List<char>charPromotion =new List<char>(){'A','B','C'}
            // List<char>charPromotion =new List<char>(){'A','B','C','A','B','A'}
            // List<char>charPromotion =new List<char>(){'A','B','C','A','B','B','B','A','B','D'}

            Console.WriteLine("Please Enter the Number Of SKU Character");

            List<char> charPromotion = new List<char>();
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                charPromotion.Add(char.Parse(Console.ReadLine()));
            }

            IPromotion promotion = new PromotionManager();

            Console.WriteLine(promotion.SetPromotion(charPromotion));

            Console.ReadKey();
        }
    }
}

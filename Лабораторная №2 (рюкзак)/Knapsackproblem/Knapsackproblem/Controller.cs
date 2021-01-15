using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsackproblem
{
   public  class Knapsackpr
    {
        public static List<int> knapsack(int[] healthinessofproduct, int[] priceofproduct, int m_healthiness) 
        {
            List<int> backpack = new List<int>(); // create new list

            int mh = healthinessofproduct.Length; 

            int[,] mas = new int[m_healthiness + 1, mh + 1]; // create array

            for (int x = 1; x <= mh; x++)
            {
                for (int e = 1; e <= m_healthiness; e++)
                {
                    // maximize the value of the total value
                    if (healthinessofproduct[x - 1] <= e)
                    {
                        mas[e, x] = Math.Max(mas[e, x - 1], mas[e - healthinessofproduct[x - 1], x - 1] + priceofproduct[x - 1]);
                    }
                    //take the cell value from the previous row
                    else
                    {
                        mas[e, x] = mas[e, x - 1];
                    }
                }
            }
            // here we take the necessary elements
            int result = mas[m_healthiness, mh], m = m_healthiness;
            
            for (int y = mh; y >= 0; y--)//reverse order
            {
                if (result <= 0) //--> interruption (knapsack was packed)
                    break;
                if (result == mas[m, y - 1])//---> keep going
                    continue;

                else // count healthiness and price
                {
                    backpack.Add(y - 1);
                    result -= priceofproduct[y - 1];
                    m -= healthinessofproduct[y - 1]; 
                }
            }
            backpack.Add(mas[m_healthiness, mh]); // add the healthiest products to knapsack
            return backpack;
        }
    }
}
//https://proglib.io/p/python-i-dinamicheskoe-programmirovanie-na-primere-zadachi-o-ryukzake-2020-02-04

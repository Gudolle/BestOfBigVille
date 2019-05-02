using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BestOfBigVille.Models;

namespace BestOfBigVille
{
    class Program
    {
        public static Map MyMap = new Map();
        static void Main(string[] args)
        {

            Genetique Algo = new Genetique();

            MyMap.Show();

            Algo.TriageList();
            for (int i = 0; i < 500; i++)
            {
                Algo.CalculDistance();
                Algo.BabyMaking();
            }



            Console.ReadKey();
        }
        public static void ShowMap()
        {

            
        }
    }
}

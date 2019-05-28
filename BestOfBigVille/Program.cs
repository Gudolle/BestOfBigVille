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

            //MyMap.Show();

            Algo.TriageList();
            for (int i = 0; i < 1000; i++)
            {
                Algo.CalculDistance();
                Algo.BabyMaking();
            }

            Console.WriteLine(Algo.MaListDeListVille.First().Identifiant);

            Console.ReadKey();
        }
        public static void ShowMap()
        {

            
        }
    }
}

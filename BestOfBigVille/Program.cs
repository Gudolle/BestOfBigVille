using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestOfBigVille.Models;

namespace BestOfBigVille
{
    class Program
    {
        static void Main(string[] args)
        {

            Genetique Algo = new Genetique();
            Algo.TriageList();
            Algo.CalculDistance();

            
            
            
            Console.ReadKey();
        }
    }
}

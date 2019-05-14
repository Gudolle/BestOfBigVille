using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BestOfBigVille.Models;

namespace BestOfBigVille
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {

            
            Thread MonShread = new Thread(new ThreadStart(AlgoGenetique));
            MonShread.SetApartmentState(ApartmentState.STA);
            MonShread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Map());

           



            Console.ReadKey();
        }

        public static void AlgoGenetique()
        {
            Genetique Algo = new Genetique();

            Algo.TriageList();
            for (int i = 0; i < 500; i++)
            {
                Algo.CalculDistance();
                Algo.BabyMaking();
            }
        }

        public static void ShowMap()
        {
            Map MyMap = new Map();
            MyMap.Show();
        }
    }
}

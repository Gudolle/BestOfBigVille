using BestOfBigVille.Models;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BestOfBigVille
{
    class Genetique
    {
        private List<Ville> MesVilles { get; set; }
        private List<ComposantList> MaListDeListVille = new List<ComposantList>();


        public Genetique()
        {
            MesVilles = Json.GetJson();
        }


        public void TriageList()
        {
            List<List<Ville>> TestListVille = new List<List<Ville>>();
            for (int i = 0; i <= 50000; i++)
            {
                List<Ville> NewVille = MesVilles.OrderBy(x => Guid.NewGuid()).ToList();
                //List<Ville> NewVille = MesVilles;

                if (!TestListVille.Contains(NewVille))
                {
                    MaListDeListVille.Add(new ComposantList { Villes = NewVille });
                    TestListVille.Add(NewVille);
                }
            }

            //foreach(IList<Ville> item in MaListDeListVille)
            //{
            //    item.ToList().ForEach(x => Console.Write(String.Format(" {0} ",x.city)));
            //    Console.WriteLine();
            //}

            Console.WriteLine();
            Console.Write(String.Format("Nombre d'élément : {0}", MaListDeListVille.Count));
            Console.WriteLine();
        }

        public void CalculDistance()
        {
            foreach(ComposantList item in MaListDeListVille)
            {
                for(int i = 0; i< item.Villes.Count - 1; i++)
                {
                    item.DistanceTotal += (item.Villes[i].GetCoord().GetDistanceTo(item.Villes[i + 1].GetCoord()))/1000; 
                }
            }


            MaListDeListVille = MaListDeListVille.OrderByDescending(x => x.DistanceTotal).Take(50).ToList();
            MaListDeListVille.ForEach(x => Console.WriteLine("Distance  = " + Math.Floor(x.DistanceTotal) + "km"));

            
        }
    }
}

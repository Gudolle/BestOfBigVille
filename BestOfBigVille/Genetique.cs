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
            for (int i = 0; i <= 5000; i++)
            {
                List<Ville> NewVille = MesVilles.OrderBy(x => Guid.NewGuid()).ToList();
                //List<Ville> NewVille = MesVilles;

                if (!TestListVille.Contains(NewVille))
                {

                    ComposantList MaList = new ComposantList { Villes = NewVille };
                    NewVille.ForEach(x => MaList.Identifiant += x.city);


                    MaListDeListVille.Add(MaList);

                    TestListVille.Add(NewVille);
                }
                else
                {
                    Console.WriteLine("DOUBLONS !!");
                }
            }

            Console.WriteLine();
            Console.Write(String.Format("Nombre d'élément : {0}", MaListDeListVille.Count));
            Console.WriteLine();
        }

        public void CalculDistance()
        {
            foreach (ComposantList item in MaListDeListVille)
            {
                item.DistanceTotal = 0;
                for (int i = 0; i < item.Villes.Count - 1; i++)
                {
                    item.DistanceTotal += (item.Villes[i].GetCoord().GetDistanceTo(item.Villes[i + 1].GetCoord())) / 1000;
                }
            }


            Console.WriteLine("===================================");
            MaListDeListVille = MaListDeListVille.OrderBy(x => x.DistanceTotal).Take(2000).ToList();
            MaListDeListVille.Take(3).ToList().ForEach(x => Console.WriteLine("Distance  = " + Math.Floor(x.DistanceTotal) + "km"));



        }

        public void BabyMaking()
        {
            Random random = new Random();
            for (int i = 0; i <= 5000; i++)
            {
                if (i % 200 == 0)
                    AddMutantYann();
                else
                {
                    ComposantList Papa = MaListDeListVille.ElementAt(random.Next(0, MaListDeListVille.Count));
                    ComposantList Maman = MaListDeListVille.ElementAt(random.Next(0, MaListDeListVille.Count));
                    if (!Papa.Equals(Maman))
                    {
                        ComposantList Enfant = new ComposantList();
                        Enfant.Villes = Papa.Villes.Take(8).ToList();



                        foreach (Ville item in Maman.Villes)
                        {
                            if (!Enfant.Villes.Contains(item))
                                Enfant.Villes.Add(item);
                        }

                        Enfant.Villes.ForEach(x => Enfant.Identifiant += x.city);

                        if (MaListDeListVille.Where(x => x.Identifiant.Equals(Enfant.Identifiant)).ToList().Count == 0)
                            MaListDeListVille.Add(Enfant);
                        else
                            AddMutantYann();


                    }
                }
            }
        }
        public void AddMutantYann()
        {
            ComposantList MutantBaby = new ComposantList()
            {
                Villes = MesVilles.OrderBy(x => Guid.NewGuid()).ToList()
            };
            MutantBaby.Villes.ForEach(x => MutantBaby.Identifiant += x.city);
            if (MaListDeListVille.Where(x => x.Identifiant.Equals(MutantBaby.Identifiant)).ToList().Count == 0)
                MaListDeListVille.Add(MutantBaby);

        }



    }
}

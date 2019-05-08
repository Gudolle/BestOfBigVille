﻿using BestOfBigVille.Models;
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
        private List<ComposantList> HistoDeListVille = new List<ComposantList>();


        public Genetique()
        {
            MesVilles = Json.GetJson();
        }

        public void TriageList()
        {
            List<List<Ville>> ListVille = new List<List<Ville>>();
            for (int i = 0; i <= 33333; i++)
            {
                List<Ville> NewVille = MesVilles.OrderBy(x => Guid.NewGuid()).ToList();
                //List<Ville> NewVille = MesVilles;

                if (!ListVille.Contains(NewVille))
                {

                    ComposantList MaList = new ComposantList { Villes = NewVille };
                    NewVille.ForEach(x => MaList.Identifiant += x.city);


                    MaListDeListVille.Add(MaList);
                    HistoDeListVille.Add(MaList);

                    ListVille.Add(NewVille);
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
            MaListDeListVille = MaListDeListVille.OrderBy(x => x.DistanceTotal).Take(1800).ToList();
            MaListDeListVille.Take(3).ToList().ForEach(x => Console.WriteLine("Distance  = " + Math.Floor(x.DistanceTotal) + "km"));



        }

        public void BabyMaking()
        {
            Random random = new Random();
            for (int i = 0; i <= 4500; i++)
            {
                if (i % 150 == 0)
                {
                    AddMutant();
                }
                else
                {
                    ComposantList Papa = MaListDeListVille.ElementAt(random.Next(0, MaListDeListVille.Count));
                    ComposantList Maman = MaListDeListVille.ElementAt(random.Next(0, MaListDeListVille.Count));
                    if (!Papa.Equals(Maman))
                    {
                        ComposantList Enfant = new ComposantList
                        {
                            Villes = Papa.Villes.Take(8).ToList()
                        };



                        foreach (Ville item in Maman.Villes)
                        {
                            if (!Enfant.Villes.Contains(item))
                                Enfant.Villes.Add(item);
                        }

                        Enfant.Villes.ForEach(x => Enfant.Identifiant += x.city);

                        if (HistoDeListVille.Where(x => x.Identifiant.Equals(Enfant.Identifiant)).ToList().Count == 0)
                        {
                            MaListDeListVille.Add(Enfant);
                            HistoDeListVille.Add(Enfant);
                        }
                        else
                            AddMutant();


                    }
                }
            }
        }
        public void AddMutant()
        {
            //Choose two random chromosomes to be mutated
            Random random = new Random();
            int MutatedChromosome1 = random.Next(0, 14);
            int MutatedChromosome2 = random.Next(0, 14);
            while (MutatedChromosome2 == MutatedChromosome1)
                MutatedChromosome2 = random.Next(0, 14);

            //Create mutant baby from a random parent
            ComposantList Parent = MaListDeListVille.ElementAt(random.Next(0, MaListDeListVille.Count));
            ComposantList MutantBaby = new ComposantList
            {
                Villes = Parent.Villes.ToList()
            };
            Ville tmp = MutantBaby.Villes[MutatedChromosome1];
            MutantBaby.Villes[MutatedChromosome1] = MutantBaby.Villes[MutatedChromosome2];
            MutantBaby.Villes[MutatedChromosome2] = tmp;

            // Add mutant baby if it hasn't appeared before
            if (HistoDeListVille.Where(x => x.Identifiant.Equals(MutantBaby.Identifiant)).ToList().Count == 0)
            {
                MaListDeListVille.Add(MutantBaby);
                HistoDeListVille.Add(MutantBaby);
            }

        }
        //public void AddList(ComposantList newList)
        //{
        //    if (HistoDeListVille.Where(x => x.Identifiant.Equals(newList.Identifiant)).ToList().Count == 0)
        //    {
        //        MaListDeListVille.Add(newList);
        //        HistoDeListVille.Add(newList);
        //    }
        //}

    }
}

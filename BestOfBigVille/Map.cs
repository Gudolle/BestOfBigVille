using BestOfBigVille.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOfBigVille
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
            Load += new EventHandler(NaviguateTo);
        }

        private void NaviguateTo(object sender, System.EventArgs e)
        {

            string Contenue = File.ReadAllText("./MyMap.html");


            List<Ville> MesVilles = Json.GetJson();
            List<Gmap> PourGmap = new List<Gmap>();
            MesVilles.ForEach(x => PourGmap.Add(x.GoogleMap()));

            Contenue = Contenue.Replace("%JSON%", JsonConvert.SerializeObject(PourGmap));
            webBrowser1.DocumentText = Contenue;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //StringBuilder location = new StringBuilder("http://google.com/");
            //webBrowser1.Navigate(location.ToString());
        }
    }
}

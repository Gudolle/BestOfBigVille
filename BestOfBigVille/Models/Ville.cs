using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfBigVille.Models
{
    class Ville
    {
        public string city { get; set; }
        public double lan { get; set; }
        public double lng { get; set; }

        public GeoCoordinate GetCoord() => new GeoCoordinate { Latitude = lan, Longitude = lng };
        
    }
}

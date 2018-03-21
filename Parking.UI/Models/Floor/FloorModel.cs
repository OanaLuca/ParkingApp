using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.UI.Models.Floor
{
    public class FloorModel:IEnumerable
    {
        public int ID { get; set; }

        public int CountCarsParked { get; set; }

        public int CountEmptyPlaces { get; set; }

        public int CountReservedPlaces { get; set; }

        public DateTime NextEmptyPlace { get; set; }

        public string BookedPlace { get; set; }

        public int FloorNumber { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository.Entity
{
    [Table("dbo.Floor")]
    public class FloorEntity
    {
        [Key]
        public int ID { get; set; }

        public int CountCarsParked { get; set; }

        public int CountEmptyPlaces { get; set; }

        public int CountReservedPlaces { get; set; }

        public DateTime NextEmptyPlace { get; set; }

        public string BookedPlace { get; set; }

        public int FloorNumber { get; set; }
    }
}

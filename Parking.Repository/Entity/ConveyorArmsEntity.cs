using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository.Entity
{
    [Table("dbo.ConveyorArms")]
    public class ConveyorArmsEntity
    {
        [Key]
        public int ID { get; set; }

        public int Position { get; set; }

        public bool Busy { get; set; }

        public string CarKeyTransported { get; set; }

        public int WhichOne { get; set; }
    }
}

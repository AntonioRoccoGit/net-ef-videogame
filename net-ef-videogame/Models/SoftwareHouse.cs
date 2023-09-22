using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    [Table("software_house")]
    public class SoftwareHouse
    {
        [Column("id")]
        public long SoftwareHouseId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("vat_number")]
        public string VatNumber { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("country")]
        public string Country { get; set; }

        public List<Videogame> Videogames { get; set; }
    }
}

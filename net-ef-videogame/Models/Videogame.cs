using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    [Table("videogames")]
    public class Videogame
    {

        [Column("id")]
        public long VideogameId { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("overview")]
        public string Overview { get; set; }

        [Column("release_date"), Required]
        public DateTime ReleaseDate { get; set; }


        //RELATIONS
        [Column("software_house_id")]
        public long SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }
    }   
}

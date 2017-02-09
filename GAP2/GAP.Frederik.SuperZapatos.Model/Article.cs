using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.Model
{
    public class Article
    {
        public Article()
        {


        }
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(200), MinLength(5)]
        public string name { get; set; }

        [Required]
        [MaxLength(400), MinLength(5)]
        public string description { get; set; }

        [Required]
        public decimal price { get; set; }

        public int total_in_shelf { get; set; }

        public int total_in_vault { get; set; }

        [ForeignKey("Store")]
        public int store_id { get; set; }
        public Store Store { get; set; }



    }
}

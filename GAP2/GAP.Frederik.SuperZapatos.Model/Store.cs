using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.Model
{
    public class Store
    {

        public Store()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100), MinLength(5)]
        public string name { get; set; }

        [Required]
        [MaxLength(100), MinLength(10)]
        public string address { get; set; }

    }
}

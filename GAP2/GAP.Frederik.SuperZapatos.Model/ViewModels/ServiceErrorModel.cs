using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.Model.ViewModels
{
    public class ServiceErrorModel
    {
        public string error_msg { get; set; }
        public int error_code { get; set; }
        public bool success { get; set; }
    }
}

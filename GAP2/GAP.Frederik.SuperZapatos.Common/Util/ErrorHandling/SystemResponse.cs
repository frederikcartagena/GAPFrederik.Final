using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling
{
    public class SystemResponse : ISystemResponse
    {        
        public SystemResponse()
        {
            Error = false;
        }
                
        public bool Error { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Detail { get; set; }

        public Exception Exception { get; set; }        
    }
}

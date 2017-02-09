using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling
{
    public interface ISystemResponse
    {
        bool Error { get; set; }

        string Title { get; set; }

        string Message { get; set; }

        string Detail { get; set; }

        Exception Exception { get; set; }
    } 
}

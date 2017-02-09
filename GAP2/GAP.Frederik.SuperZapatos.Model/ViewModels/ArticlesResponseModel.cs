using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.Model.ViewModels
{
    public class ArticlesResponseModel
    {
        public List<ArticleModel> articles { get; set; }
        public bool success { get; set; }
        public int total_elements { get; set; }
    }
}

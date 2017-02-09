using GAP.Frederik.SuperZapatos.BLL;
using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;
using GAP.Frederik.SuperZapatos.Model;
using GAP.Frederik.SuperZapatos.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GAP.Frederik.SuperZapatos.Controllers
{
    public class ArticleClientController : Controller
    {
        private IArticleBll _articleBll;
        private IStoreBll _storeBll;

        public ArticleClientController(IArticleBll articleBll, IStoreBll storeBll)
        {
            this._articleBll = articleBll;
            this._storeBll = storeBll;
        }

        // GET: Article
        public ActionResult Index()
        {
            ISystemResponse error = new SystemResponse();
            var stores = _articleBll.GetArticles(error);

            return View(stores);
        }
    }
}
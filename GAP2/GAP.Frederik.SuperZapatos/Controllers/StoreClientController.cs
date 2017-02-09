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
    public class StoreClientController : Controller
    {
        private IStoreBll _storeBll;

        public StoreClientController(IStoreBll storeBll)
        {
            this._storeBll = storeBll;
        }

        // GET: Store
        public ActionResult Index()
        {
            ISystemResponse error = new SystemResponse();
            var stores = _storeBll.GetStores(error);

            return View(stores);
        }
    }
}
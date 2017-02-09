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
    public class StoreController : Controller
    {
        private  IStoreBll _storeBll;

        public StoreController(IStoreBll storeBll)
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

        [HttpPost]
        public ActionResult Create(Store store)
        {
            bool created = false;
            ISystemResponse error = new SystemResponse();

            if (ModelState.IsValid)
            {
                created = _storeBll.CreateStore(store, error);

                if(created)
                    return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISystemResponse error = new SystemResponse();
            StoreModel store = _storeBll.GetStore(id.Value, error);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ISystemResponse error = new SystemResponse();
            bool deleted = _storeBll.DeleteStore(id, error);

            if (deleted)
                return RedirectToAction("Index");

            return View();
        }

        //public ActionResult Update()
        //{
        //    ISystemResponse error = new SystemResponse();
        //    bool updated = _storeBll.
        //}

        public ActionResult Details(int id)
        {
            ISystemResponse error = new SystemResponse();
            var store = _storeBll.GetStore(id, error);

            return View(store);
        }

        public ActionResult Edit(int id)
        {
            ISystemResponse error = new SystemResponse();
            var store = _storeBll.GetStore(id, error);

            return View(store);
        }

        [HttpPost]
        public ActionResult Edit(StoreModel store)
        {
            ISystemResponse error = new SystemResponse();
            bool updated = _storeBll.UpdateStore(store, error);

            if (updated)
                return RedirectToAction("Index");

            return View();
        }
    }
}
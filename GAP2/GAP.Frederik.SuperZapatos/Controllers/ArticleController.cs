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
    public class ArticleController : Controller
    {
        private IArticleBll _articleBll;
        private IStoreBll _storeBll;

        public ArticleController(IArticleBll articleBll, IStoreBll storeBll)
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


        [HttpPost]
        public ActionResult Create(Article article)
        {
            bool created = false;
            ISystemResponse error = new SystemResponse();

            if (ModelState.IsValid)
            {
                created = _articleBll.CreateArticle(article, error);

                if (created)
                    return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            ISystemResponse error = new SystemResponse();
            List<StoreModel> stores = _storeBll.GetStores(error);
            ViewBag.store_id = new SelectList(stores, "Id", "name");
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISystemResponse error = new SystemResponse();
            Article article = _articleBll.GetArticle(id.Value, error);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ISystemResponse error = new SystemResponse();
            bool deleted = _articleBll.DeleteArticle(id, error);

            if (deleted)
                return RedirectToAction("Index");

            return View();
        }        

        public ActionResult Details(int id)
        {
            ISystemResponse error = new SystemResponse();
            var store = _articleBll.GetArticle(id, error);

            return View(store);
        }

        public ActionResult Edit(int id)
        {
            ISystemResponse error = new SystemResponse();
            var article = _articleBll.GetArticle(id, error);
            List<StoreModel> stores = _storeBll.GetStores(error);
            ViewBag.store_id = new SelectList(stores, "Id", "name", article.store_id);

            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(ArticleModel article)
        {
            ISystemResponse error = new SystemResponse();
            bool updated = _articleBll.UpdateArticle(article, error);

            if (updated)
                return RedirectToAction("Index");

            return View();
        }
    }
}
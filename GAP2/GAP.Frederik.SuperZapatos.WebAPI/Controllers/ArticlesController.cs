using GAP.Frederik.SuperZapatos.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GAP.Frederik.SuperZapatos.Model;
using GAP.Frederik.SuperZapatos.Model.Factory;
using GAP.Frederik.SuperZapatos.WebAPI.Filters;
using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;
using GAP.Frederik.SuperZapatos.Model.ViewModels;

namespace GAP.Frederik.SuperZapatos.WebAPI.Controllers
{
    [ZapatosAPIAuthorize]
    [RoutePrefix("services/articles")]
    public class ArticlesController : ApiController
    {
        IArticleRepository _repository;
        ModelFactory _modelFactory;

        public ArticlesController(IArticleRepository repository)
        {
            _repository = repository;
            _modelFactory = new ModelFactory();
        }

        /// <summary>
        /// Return a list of all articles
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IHttpActionResult Get()
        {
            ISystemResponse error = new SystemResponse();
            var articles = _repository.GetArticles(error);
            var response = _modelFactory.Create(articles);

            return Ok(response);
        }


        /// <summary>
        /// Get all articles related to the store 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [Route("stores/{storeId}")]
        public IHttpActionResult Get(string storeId)
        {
            int storeIdConverted;
            bool isNumeric = int.TryParse(storeId, out storeIdConverted);

            if (!isNumeric)
            {
                var errorResponse = new ServiceErrorModel { error_msg = "Bad Request", error_code = 400, success = false };
                return Ok(errorResponse);
            }

            ISystemResponse error = new SystemResponse();
            var articles = _repository.GetArticlesByStoreId(storeIdConverted, error);
            var response = _modelFactory.Create(articles);
            

            if (!articles.Any())
            {
                var errorResponse = new ServiceErrorModel { error_msg = "Record not Found", error_code = 404, success = false };
                return Ok(errorResponse);
            }
                

            return Ok(response);

        }


        [Route("")]
        public IHttpActionResult Get(int articleId, bool bit)
        {
            ISystemResponse error = new SystemResponse();
            var article = _repository.GetArticleById(articleId, error);
            var response = new ArticleResponseModel { article = article };

            return Ok(response);
        }

        [Route("")]
        public IHttpActionResult Post(Article article)
        {
            ISystemResponse error = new SystemResponse();
            bool created = _repository.CreateArticle(article, error);
            var response = _modelFactory.Create(created, error.Message);

            return Ok(response);
        }

        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete(int articleId)
        {
            ISystemResponse error = new SystemResponse();
            bool deleted = _repository.DeleteArticle(articleId, error);
            var response = _modelFactory.Create(deleted, error.Message);

            return Ok(response);
        }

        [Route("")]
        public IHttpActionResult Put(Article article)
        {
            ISystemResponse error = new SystemResponse();
            bool updated = _repository.UpdateArticle(article, error);
            var response = _modelFactory.Create(updated, error.Message);

            return Ok(response);
        }
    }
}
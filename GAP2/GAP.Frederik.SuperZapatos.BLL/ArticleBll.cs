using GAP.Frederik.SuperZapatos.Common.Util;
using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;
using GAP.Frederik.SuperZapatos.Model;
using GAP.Frederik.SuperZapatos.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GAP.Frederik.SuperZapatos.BLL
{
    public class ArticleBll : IArticleBll
    {
        public bool CreateArticle(Article article, ISystemResponse error)
        {
            bool created = false;

            try
            {
                string request = WebAPIClient.PostRequest("Articles", "", article, error, new Dictionary<string, string>());

                if (!string.IsNullOrEmpty(request) && !error.Error)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    BasicResponseModel response = serializer.Deserialize<BasicResponseModel>(request);

                    if (response != null && !error.Error)
                        created = response.success;
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "No fue posible crear el articulo";
                error.Exception = ex;
            }

            return created;
        }

        public bool DeleteArticle(int articleId, ISystemResponse error)
        {
            bool deleted = false;

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("articleId", articleId.ToString());
                string request = WebAPIClient.DeleteRequest("Articles", "", error, parameters);

                if (!string.IsNullOrEmpty(request) && !error.Error)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    BasicResponseModel response = serializer.Deserialize<BasicResponseModel>(request);

                    if (response != null && !error.Error)
                        deleted = response.success;
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "No fue posible eliminar";
                error.Exception = ex;
            }

            return deleted;
        }

        public Article GetArticle(int articleId, ISystemResponse error)
        {
            Article article = new Article();

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("articleId", articleId.ToString());
                parameters.Add("bit", "false");

                string request = WebAPIClient.GetRequest("Articles", "Get", parameters, error);

                if (!string.IsNullOrEmpty(request) && !error.Error)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    ArticleResponseModel response = serializer.Deserialize<ArticleResponseModel>(request);

                    if (response != null && !error.Error && response.article != null)
                        article = response.article;
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "No se pudo obtener la informacion del articulo solicitado";
                error.Exception = ex;
            }

            return article;
        }

        public List<ArticleModel> GetArticles(ISystemResponse error)
        {
            List<ArticleModel> articles = new List<ArticleModel>();

            try
            {
                string request = WebAPIClient.GetRequest("Articles", "Get", new Dictionary<string, string>(), error);

                if (!string.IsNullOrEmpty(request) && !error.Error)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    ArticlesResponseModel response = serializer.Deserialize<ArticlesResponseModel>(request);

                    if (response != null && !error.Error && response.articles != null)
                        articles = response.articles;
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "No se pudieron obtener los articulos";
                error.Exception = ex;
            }

            return articles;
        }

        public bool UpdateArticle(ArticleModel article, ISystemResponse error)
        {
            bool updated = false;

            try
            {
                string request = WebAPIClient.PutRequest("Articles", "", article, error, new Dictionary<string, string>());

                if (!string.IsNullOrEmpty(request) && !error.Error)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    BasicResponseModel response = serializer.Deserialize<BasicResponseModel>(request);

                    if (response != null && !error.Error)
                        updated = response.success;
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "No fue posible actualizar el articulo";
                error.Exception = ex;
            }

            return updated;
        }
    }
}

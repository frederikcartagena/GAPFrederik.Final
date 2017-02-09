using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Frederik.SuperZapatos.DataAccess.Context;
using GAP.Frederik.SuperZapatos.Model;
using System.Data.Entity;
using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;

namespace GAP.Frederik.SuperZapatos.DataAccess.Repository
{
    public class ArticleRepository : RepositoryBase<SuperZapatosContext>, IArticleRepository
    {
        public bool CreateArticle(Article article, ISystemResponse error)
        {
            bool created = false;

            try
            {
                using (DataContext)
                {
                    DataContext.Articles.Add(article);
                    DataContext.SaveChanges();
                    created = true;
                }
            }
            catch (Exception ex)
            {
                created = false;
                error.Error = true;
                error.Message = "Ocurrio un error al crear el articulo";
                error.Exception = ex;
            }

            return created;
        }

        public bool DeleteArticle(int articleId, ISystemResponse error)
        {
            bool deleted = false;

            try
            {
                using (DataContext)
                {
                    Article article = DataContext.Articles.Find(articleId);

                    if (article != null)
                    {
                        DataContext.Articles.Remove(article);
                        DataContext.SaveChanges();
                        deleted = true;
                    }
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "Ocurrio un error al eliminar el articulo";
                error.Exception = ex;
            }

            return deleted;
        }

        public Article GetArticleById(int articleId, ISystemResponse error)
        {
            Article article = new Article();
            try
            {
                using (DataContext)
                {
                    article = DataContext.Articles.Find(articleId);
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "Ocurrio un error al obtener el articulo";
                error.Exception = ex;
            }

            return article;
        }

        public List<Article> GetArticles(ISystemResponse error)
        {
            List<Article> articles = new List<Article>();

            try
            {
                using (DataContext)
                {
                    articles = DataContext.Articles.ToList();
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "Ocurrio un error al obtener los articulos";
                error.Exception = ex;
            }

            return articles;
        }        

        public List<Article> GetArticlesByStoreId(int storeId, ISystemResponse error)
        {
            List<Article> articles = new List<Article>();

            try
            {
                using (DataContext)
                {
                    articles = DataContext.Articles
                                .Where(a => a.store_id == storeId)
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "Ocurrio un error al obtener los articulos de la tienda solicitada";
                error.Exception = ex;
            }

            return articles;
        }

        public bool UpdateArticle(Article article, ISystemResponse error)
        {
            bool updated = false;

            try
            {
                using (DataContext)
                {
                    Article oldArticle = DataContext.Articles.Find(article.Id);

                    if (oldArticle != null)
                    {
                        oldArticle.description = article.description;
                        oldArticle.name = article.name;
                        oldArticle.price = article.price;
                        oldArticle.store_id = article.store_id;
                        oldArticle.total_in_shelf = article.total_in_shelf;
                        oldArticle.total_in_vault = article.total_in_vault;
                        DataContext.SaveChanges();
                        updated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "Ocurrio un error al actualizar la tienda";
                error.Exception = ex;
            }

            return updated;
        }
    }
}

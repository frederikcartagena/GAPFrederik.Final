using GAP.Frederik.SuperZapatos.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.Model.Factory
{
    public class ModelFactory
    {
        #region Articles
        public ArticlesResponseModel Create(List<Article> articles)
        {
            ArticlesResponseModel model = new ArticlesResponseModel();

            model.total_elements = articles.Count();
            model.articles = articles.Select(a => Create(a)).ToList();

            return model;
        }

        public ArticleModel Create(Article article)
        {
            return new ArticleModel()
            {
                description = article.description,
                id = article.Id,
                name = article.name,
                price = article.price,
                store_id = article.store_id,
                total_in_shelf = article.total_in_shelf,
                total_in_vault = article.total_in_vault
            };
        }
        #endregion

        #region Stores
        public StoresResponseModel Create(List<Store> stores)
        {
            StoresResponseModel model = new StoresResponseModel();

            model.total_elements = stores.Count();
            model.stores = stores.Select(s => Create(s)).ToList();

            return model;
        }

        public StoreModel Create(Store store)
        {
            return new StoreModel()
            {
                id = store.Id,
                name = store.name,
                address = store.address
            };
        }
        #endregion

        public BasicResponseModel Create(bool created, string message)
        {
            return new BasicResponseModel()
            {
                success = created,
                message = message
            };
        }
        
    }
}

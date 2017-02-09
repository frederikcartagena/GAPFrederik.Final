using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;
using GAP.Frederik.SuperZapatos.Model;
using GAP.Frederik.SuperZapatos.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAP.Frederik.SuperZapatos.BLL
{
    public interface IArticleBll
    {
        List<ArticleModel> GetArticles(ISystemResponse error);

        bool CreateArticle(Article article, ISystemResponse error);
        Article GetArticle(int articleId, ISystemResponse error);
        bool DeleteArticle(int articleId, ISystemResponse error);
        bool UpdateArticle(ArticleModel store, ISystemResponse error);
    }
}

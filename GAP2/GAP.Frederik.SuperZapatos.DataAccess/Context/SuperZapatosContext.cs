using GAP.Frederik.SuperZapatos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.DataAccess.Context
{
    public class SuperZapatosContext : DbContext
    {
        public SuperZapatosContext()
            : base("ZapatosDBContext")
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Store>()
            //    .HasMany<Article>(s => s.Articles)
            //    .WithMany(a => a.Stores)
            //    .Map(sa => 
            //        {
            //            sa.MapLeftKey("storeId");
            //            sa.MapRightKey("articleId");
            //            sa.ToTable("StoreArticle");
            //        });
            //Database.SetInitializer<SuperZapatosContext>(null);
            //base.OnModelCreating(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Frederik.SuperZapatos.DataAccess.Context;
using GAP.Frederik.SuperZapatos.Model;
using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;

namespace GAP.Frederik.SuperZapatos.DataAccess.Repository
{
    public class StoreRepository : RepositoryBase<SuperZapatosContext>, IStoreRepository
    {
        public List<Store> GetStores(ISystemResponse error)
        {
            List<Store> stores = new List<Store>();
            try
            {
                using (DataContext)
                {
                    stores = DataContext.Stores.ToList();
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "Ocurrio un error al obtener las tiendas";
                error.Exception = ex;
            }

            return stores;
        }

        public bool CreateStore(Store store, ISystemResponse error)
        {
            bool created = false;

            try
            {
                using (DataContext)
                {
                    DataContext.Stores.Add(store);
                    DataContext.SaveChanges();
                    created = true;
                }
            }
            catch (Exception ex)
            {
                created = false;
                error.Error = true;
                error.Message = "Ocurrio un error al crear la tienda";
                error.Exception = ex;
            }

            return created;
        }

        public bool UpdateStore(Store store, ISystemResponse error)
        {
            bool updated = false;

            try
            {
                using (DataContext)
                {
                    Store oldStore = DataContext.Stores.Find(store.Id);

                    if(oldStore != null)
                    {
                        oldStore.address = store.address;
                        oldStore.name = store.name;
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

        public Store GetStoreById(int storeId, ISystemResponse error)
        {
            Store store = new Store();
            try
            {
                using (DataContext)
                {
                    store = DataContext.Stores.Find(storeId);
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "Ocurrio un error al obtener la tienda";
                error.Exception = ex;
            }

            return store;
        }

        public bool DeleteStore(int storeId, ISystemResponse error)
        {
            bool deleted = false;

            try
            {
                using (DataContext)
                {
                    Store store = DataContext.Stores.Find(storeId);

                    if (store != null)
                    {
                        DataContext.Stores.Remove(store);
                        DataContext.SaveChanges();
                        deleted = true;
                    }
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "Ocurrio un error al eliminar la tienda";
                error.Exception = ex;
            }

            return deleted;
        }
    }
}

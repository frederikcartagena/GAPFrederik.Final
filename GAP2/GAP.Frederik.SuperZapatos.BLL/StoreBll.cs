using GAP.Frederik.SuperZapatos.Common.Util;
using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;
using GAP.Frederik.SuperZapatos.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GAP.Frederik.SuperZapatos.Model;

namespace GAP.Frederik.SuperZapatos.BLL
{
    public class StoreBll : IStoreBll
    {
        public bool CreateStore(Store store, ISystemResponse error)
        {
            bool created = false;

            try
            {
                string request = WebAPIClient.PostRequest("Stores","", store, error, new Dictionary<string, string>());
                
                if(!string.IsNullOrEmpty(request) && !error.Error)
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
                error.Message = "No fue posible crear la tienda";
                error.Exception = ex;
            }

            return created;
        }

        public List<StoreModel> GetStores(ISystemResponse error)
        {
            List<StoreModel> stores = new List<StoreModel>();

            try
            {
                string request = WebAPIClient.GetRequest("Stores", "Get", new Dictionary<string, string>(), error);

                if (!string.IsNullOrEmpty(request) && !error.Error)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    StoresResponseModel response = serializer.Deserialize<StoresResponseModel>(request);

                    if (response != null && !error.Error && response.stores != null)
                        stores = response.stores;
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "No se pudieron obtener las tiendas";
                error.Exception = ex;                
            }

            return stores;
        }

        public StoreModel GetStore(int storeId, ISystemResponse error)
        {
            StoreModel store = new StoreModel();

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("storeId", storeId.ToString());

                string request = WebAPIClient.GetRequest("Stores", "Get", parameters, error);

                if(!string.IsNullOrEmpty(request)  && !error.Error)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    StoreResponseModel response = serializer.Deserialize<StoreResponseModel>(request);

                    if (response != null && !error.Error && response.store != null)
                        store = response.store;
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Message = "No se pudo obtener la informacion de la tienda solicitada";
                error.Exception = ex;
            }

            return store;
        }

        public bool DeleteStore(int storeId, ISystemResponse error)
        {
            bool deleted = false;

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("storeId", storeId.ToString());
                string request = WebAPIClient.DeleteRequest("Stores", "", error, parameters);

                if(!string.IsNullOrEmpty(request) && !error.Error)
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
                error.Message = "No fue posible eliminar la tienda";
                error.Exception = ex;
            }

            return deleted;
        }

        public bool UpdateStore(StoreModel store, ISystemResponse error)
        {
            bool updated = false;

            try
            {
                string request = WebAPIClient.PutRequest("Stores", "", store, error, new Dictionary<string, string>());

                if(!string.IsNullOrEmpty(request) && !error.Error)
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
                error.Message = "No fue posible actualizar la tienda";
                error.Exception = ex;
            }

            return updated;
        }
    }
}

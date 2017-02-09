using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;
using GAP.Frederik.SuperZapatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Frederik.SuperZapatos.DataAccess.Repository
{
    public interface IStoreRepository
    {
        List<Store> GetStores(ISystemResponse error);
        bool CreateStore(Store store, ISystemResponse error);
        bool UpdateStore(Store store, ISystemResponse error);
        Store GetStoreById(int storeId, ISystemResponse error);
        bool DeleteStore(int storeId, ISystemResponse error);
    }
}

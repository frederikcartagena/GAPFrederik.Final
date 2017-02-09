using GAP.Frederik.SuperZapatos.Common.Util.ErrorHandling;
using GAP.Frederik.SuperZapatos.Model;
using GAP.Frederik.SuperZapatos.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAP.Frederik.SuperZapatos.BLL
{
    public interface IStoreBll
    {
        List<StoreModel> GetStores(ISystemResponse error);
        bool CreateStore(Store store, ISystemResponse error);
        StoreModel GetStore(int storeId, ISystemResponse error);
        bool DeleteStore(int storeId, ISystemResponse error);
        bool UpdateStore(StoreModel store, ISystemResponse error);
    }
}

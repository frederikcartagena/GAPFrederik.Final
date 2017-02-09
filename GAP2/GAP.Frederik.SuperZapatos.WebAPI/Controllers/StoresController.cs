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
    [RoutePrefix("services/stores")]
    public class StoresController : ApiController
    {
        IStoreRepository _repository;
        ModelFactory _modelFactory;

        public StoresController(IStoreRepository repository)
        {
            _repository = repository;
            _modelFactory = new ModelFactory();
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            ISystemResponse error = new SystemResponse();
            var stores = _repository.GetStores(error);
            var response = _modelFactory.Create(stores);

            return Ok(response);
        }

        [Route("")]
        public IHttpActionResult Get(int storeId)
        {
            ISystemResponse error = new SystemResponse();
            var store = _repository.GetStoreById(storeId, error);
            var response = new StoreResponseModel { store = _modelFactory.Create(store) };

            return Ok(response);
        }

        [Route("")]
        public IHttpActionResult Post(Store store)
        {
            ISystemResponse error = new SystemResponse();
            bool created = _repository.CreateStore(store, error);
            var response = _modelFactory.Create(created, error.Message);

            return Ok(response);
        }

        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete(int storeId)
        {
            ISystemResponse error = new SystemResponse();
            bool deleted = _repository.DeleteStore(storeId, error);
            var response = _modelFactory.Create(deleted, error.Message);

            return Ok(response);
        }

        [Route("")]
        public IHttpActionResult Put(Store store)
        {
            ISystemResponse error = new SystemResponse();
            bool updated = _repository.UpdateStore(store, error);
            var response = _modelFactory.Create(updated, error.Message);

            return Ok(response);
        }
    }
}
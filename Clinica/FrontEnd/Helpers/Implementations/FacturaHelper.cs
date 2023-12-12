using System;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FrontEnd.Helpers.Implementations
{
	public class FacturaHelper : IFacturaHelper
	{
        IServiceRepository _repository;


        public FacturaHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public string Token { get; set; }

        private void SetAuthorizationHeader()
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token);
        }

        public List<FacturaInfoViewModel> GetFacturaInfoAll()
        {
            SetAuthorizationHeader();
            List<FacturaInfoViewModel> lista = new List<FacturaInfoViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Factura/Info");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<FacturaInfoViewModel>>(content);
            }
            return lista;
        }
    }
}


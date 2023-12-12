using System;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FrontEnd.Helpers.Implementations
{
	public class ReservaHelper : IReservaHelper
	{
        IServiceRepository _repository;

        public ReservaHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public string Token { get; set; }

        private void SetAuthorizationHeader()
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token);
        }

        public List<ReservaInfoViewModel> GetReservaInfoAll()
        {
            SetAuthorizationHeader();
            List<ReservaInfoViewModel> lista = new List<ReservaInfoViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Reserva/Info");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ReservaInfoViewModel>>(content);
            }
            return lista;
        }
    }
}


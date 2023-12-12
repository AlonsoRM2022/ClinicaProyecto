using System;
using FrontEnd.Helpers.Interfaces;
using System.Net.Http.Headers;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd.Helpers.Implementations
{
	public class DiagnosticoHelper : IDiagnosticoHelper
    {
        IServiceRepository _repository;

        public DiagnosticoHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public class JsonRequestModel
        {
            public string Query { get; set; }
        }

        public string Token { get; set; }

        private void SetAuthorizationHeader()
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token);
        }

        public List<DiagnosticoInfoViewModel> GetDiagnosticoInfoAll()
        {
            SetAuthorizationHeader();
            List<DiagnosticoInfoViewModel> lista = new List<DiagnosticoInfoViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Diagnostico/Info");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<DiagnosticoInfoViewModel>>(content);
            }
            return lista;
        }

        public DiagnosticoViewModel AddDiagnostico(DiagnosticoViewModel diagnosticoViewModel)
        {
            SetAuthorizationHeader();

            JsonRequestModel requestData = new JsonRequestModel
            {
                Query = diagnosticoViewModel.Descripcion
            };

            HttpResponseMessage recomendacionMessage = _repository.PostResponse("api/Openai", requestData);
            if (recomendacionMessage != null)
            {
                var content = recomendacionMessage.Content.ReadAsStringAsync().Result;
                diagnosticoViewModel.Recomendacion = content;
            }

            DiagnosticoViewModel diagnostico = new DiagnosticoViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Diagnostico", diagnosticoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                diagnostico = JsonConvert.DeserializeObject<DiagnosticoViewModel>(content);
            }
            return diagnostico;
        }
    }
}


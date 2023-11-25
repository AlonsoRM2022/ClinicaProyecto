using System.Net.Http.Headers;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
	public class UsuarioHelper : IUsuarioHelper
	{
        IServiceRepository _repository;

        public UsuarioHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public string Token { get; set; }

        private void SetAuthorizationHeader()
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token);
        }

        public UsuarioViewModel GetUsuario(string Correo, string Clave)
        {
            SetAuthorizationHeader();
            UsuarioViewModel usuario = new();
            UsuarioViewModel model = new()
            {
                Correo = Correo,
                Clave = Clave
            };
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Usuario/", model);
            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            }
            return usuario;
        }
    }
}


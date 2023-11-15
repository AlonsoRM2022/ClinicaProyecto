using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PrecioHelper : IPrecioHelper
    {
        IServiceRepository _repository;

        public PrecioHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public PrecioViewModel AddPrecio(PrecioViewModel precioViewModel)
        {
            PrecioViewModel precio = new PrecioViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Precio", precioViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                precio = JsonConvert.DeserializeObject<PrecioViewModel>(content);
            }
            return precio;
        }

        public void DeletePrecio(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Precio/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public PrecioViewModel EditPrecio(PrecioViewModel precioViewModel)
        {
            PrecioViewModel precio = new PrecioViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Precio", precioViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                precio = JsonConvert.DeserializeObject<PrecioViewModel>(content);
            }
            return precio;
        }

        public List<PrecioViewModel> GetAll()
        {
            List<PrecioViewModel> lista = new List<PrecioViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Precio");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<PrecioViewModel>>(content);
            }

            return lista;
        }

        public PrecioViewModel GetById(int id)
        {
            PrecioViewModel precio = new PrecioViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Precio/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                precio = JsonConvert.DeserializeObject<PrecioViewModel>(content);
            }
            return precio;
        }
    }
}

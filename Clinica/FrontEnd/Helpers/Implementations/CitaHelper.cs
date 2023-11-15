using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CitaHelper : ICitaHelper
    {

        IServiceRepository _repository;

        public CitaHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public CitaViewModel AddCita(CitaViewModel CitaViewModel)
        {
            CitaViewModel cita = new CitaViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/cita", CitaViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                cita = JsonConvert.DeserializeObject<CitaViewModel>(content);
            }
            return cita;
        }

        public void DeleteCita(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/cita/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public CitaViewModel EditCita(CitaViewModel CitaViewModel)
        {
            CitaViewModel cita = new CitaViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/cita", CitaViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                cita = JsonConvert.DeserializeObject<CitaViewModel>(content);
            }
            return cita;
        }

        public List<CitaViewModel> GetAll()
        {
            List<CitaViewModel> lista = new List<CitaViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Cita");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CitaViewModel>>(content);
            }
            return lista;
        }

        public CitaViewModel GetById(int id)
        {
            CitaViewModel Cita = new CitaViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Cita/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                Cita = JsonConvert.DeserializeObject<CitaViewModel>(content);
            }
            return Cita;
        }
    }
}

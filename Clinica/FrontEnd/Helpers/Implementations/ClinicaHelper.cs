using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ClinicaHelper : IClinicaHelper
    {
        IServiceRepository _repository;

        public ClinicaHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public ClinicaViewModel AddClinica(ClinicaViewModel clinicaViewModel)
        {
            ClinicaViewModel clinica = new ClinicaViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Clinica", clinicaViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                clinica = JsonConvert.DeserializeObject<ClinicaViewModel>(content);
            }
            return clinica;
        }

        public void DeleteClinica(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Clinica/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public ClinicaViewModel EditClinica(ClinicaViewModel clinicaViewModel)
        {
            ClinicaViewModel clinica = new ClinicaViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Clinica", clinicaViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                clinica = JsonConvert.DeserializeObject<ClinicaViewModel>(content);
            }
            return clinica;
        }

        public List<ClinicaViewModel> GetAll()
        {
            List<ClinicaViewModel> lista = new List<ClinicaViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Clinica");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ClinicaViewModel>>(content);
            }

            return lista;
        }

        public ClinicaViewModel GetById(int id)
        {
            ClinicaViewModel clinica = new ClinicaViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Clinica/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                clinica = JsonConvert.DeserializeObject<ClinicaViewModel>(content);
            }
            return clinica;
        }
    }
}

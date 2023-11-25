using System.Net.Http.Headers;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class DoctorHelper : IDoctorHelper
    {
        IServiceRepository _repository;

        public DoctorHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public string Token { get; set; }

        private void SetAuthorizationHeader()
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token);
        }

        public DoctorViewModel AddDoctor(DoctorViewModel doctorViewModel)
        {
            SetAuthorizationHeader();
            DoctorViewModel doctor = new DoctorViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Doctor", doctorViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                doctor = JsonConvert.DeserializeObject<DoctorViewModel>(content);
            }
            return doctor;
        }

        public void DeleteDoctor(int id)
        {
            SetAuthorizationHeader();
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Doctor/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public DoctorViewModel EditDoctor(DoctorViewModel doctorViewModel)
        {
            SetAuthorizationHeader();
            DoctorViewModel doctor = new DoctorViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Doctor", doctorViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                doctor = JsonConvert.DeserializeObject<DoctorViewModel>(content);
            }
            return doctor;
        }

        public List<DoctorViewModel> GetAll()
        {
            SetAuthorizationHeader();
            List<DoctorViewModel> lista = new List<DoctorViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Doctor");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<DoctorViewModel>>(content);
            }

            return lista;
        }

        public DoctorViewModel GetById(int id)
        {
            SetAuthorizationHeader();
            DoctorViewModel doctor = new DoctorViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Doctor/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                doctor = JsonConvert.DeserializeObject<DoctorViewModel>(content);
            }
            return doctor;
        }
    }
}

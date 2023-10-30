using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class HorarioHelper : IHorarioHelper
    {
        IServiceRepository _repository;

        public HorarioHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public HorarioViewModel AddHorario(HorarioViewModel horarioViewModel)
        {
            HorarioViewModel horario = new HorarioViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Horario", horarioViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                horario = JsonConvert.DeserializeObject<HorarioViewModel>(content);
            }
            return horario;
        }

        public void DeleteHorario(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Horario/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public HorarioViewModel EditHorario(HorarioViewModel horarioViewModel)
        {
            HorarioViewModel horario = new HorarioViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Horario", horarioViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                horario = JsonConvert.DeserializeObject<HorarioViewModel>(content);
            }
            return horario;
        }

        public List<HorarioViewModel> GetAll()
        {
            List<HorarioViewModel> lista = new List<HorarioViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Horario");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<HorarioViewModel>>(content);
            }

            return lista;
        }

        public HorarioViewModel GetById(int id)
        {
            HorarioViewModel horario = new HorarioViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Horario/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                horario = JsonConvert.DeserializeObject<HorarioViewModel>(content);
            }
            return horario;
        }
    }
}
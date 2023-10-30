using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class HorarioService : IHorarioService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public HorarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddHorario(Horario horario)
        {
            bool resultado = _unidadDeTrabajo._horarioDAL.Add(horario);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeteleHorario(Horario horario)
        {
            bool resultado = _unidadDeTrabajo._horarioDAL.Remove(horario);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Horario GetById(int id)
        {
            Horario horario;
            horario = _unidadDeTrabajo._horarioDAL.Get(id);
            return horario;
        }

        public async Task<IEnumerable<Horario>> GetHorariosAsync()
        {
            IEnumerable<Horario> horarios;
            horarios = await _unidadDeTrabajo._horarioDAL.GetAll();
            return horarios;
        }

        public bool UpdateHorario(Horario horario)
        {
            bool resultado = _unidadDeTrabajo._horarioDAL.Update(horario);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
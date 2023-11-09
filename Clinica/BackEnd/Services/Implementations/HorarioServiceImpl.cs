using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class HorarioServiceImpl : IHorarioService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public HorarioServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Horario horario)
        {
            bool res = _unidadDeTrabajo._horarioDAL.Add(horario);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Horario horario)
        {
            bool res = _unidadDeTrabajo._horarioDAL.Remove(horario);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Horario GetById(int id)
        {
            Horario horario;
            horario = _unidadDeTrabajo._horarioDAL.Get(id);
            return horario;
        }

        public async Task<IEnumerable<Horario>> GetHorariosAsync()
        {
            IEnumerable<Horario> horarios = await _unidadDeTrabajo._horarioDAL.GetAll();
            return horarios;
        }

        public bool Update(Horario horario)
        {
            bool res = _unidadDeTrabajo._horarioDAL.Update(horario);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}


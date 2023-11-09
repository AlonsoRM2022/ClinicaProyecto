using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class DiagnosticoServiceImpl : IDiagnosticoService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public DiagnosticoServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Diagnostico diagnostico)
        {
            bool res = _unidadDeTrabajo._diagnosticoDAL.Add(diagnostico);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Diagnostico diagnostico)
        {
            bool res = _unidadDeTrabajo._diagnosticoDAL.Remove(diagnostico);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Diagnostico GetById(int id)
        {
            Diagnostico diagnostico;
            diagnostico = _unidadDeTrabajo._diagnosticoDAL.Get(id);
            return diagnostico;
        }

        public async Task<IEnumerable<Diagnostico>> GetDiagnosticosAsync()
        {
            IEnumerable<Diagnostico> diagnosticos = await _unidadDeTrabajo._diagnosticoDAL.GetAll();
            return diagnosticos;
        }

        public bool Update(Diagnostico diagnostico)
        {
            bool res = _unidadDeTrabajo._diagnosticoDAL.Update(diagnostico);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}


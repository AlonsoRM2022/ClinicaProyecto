using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IHorarioService
    {
        Task<IEnumerable<Horario>> GetHorariosAsync();
        Horario GetById(int id);
        bool AddHorario(Horario horario);
        bool UpdateHorario(Horario horario);
        bool DeteleHorario(Horario horario);


    }
}

using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPrecioHelper
    {
        List<PrecioViewModel> GetAll();
        PrecioViewModel GetById(int id);
        PrecioViewModel AddPrecio(PrecioViewModel precioViewModel);
        PrecioViewModel EditPrecio(PrecioViewModel precioViewModel);
        void DeletePrecio(int id);
    }
}

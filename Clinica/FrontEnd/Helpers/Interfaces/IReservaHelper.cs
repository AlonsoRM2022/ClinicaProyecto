using System;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
	public interface IReservaHelper
	{
        string Token { get; set; }
        List<ReservaInfoViewModel> GetReservaInfoAll();
    }
}


using System;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
	public interface IFacturaHelper
	{
        string Token { get; set; }
        List<FacturaInfoViewModel> GetFacturaInfoAll();
    }
}


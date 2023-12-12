using System;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
	public interface IDiagnosticoHelper
	{
        string Token { get; set; }
        List<DiagnosticoInfoViewModel> GetDiagnosticoInfoAll();
        DiagnosticoViewModel AddDiagnostico(DiagnosticoViewModel diagnosticoViewModel);
    }
}


using System.ComponentModel.DataAnnotations;

namespace Locadora.Common.Enums
{
    public enum TipoUsuario
    {
        [Display(Name = "Cliente")]
        Cliente,
        [Display(Name = "Funcionário")]
        Funcionario    
    }
}
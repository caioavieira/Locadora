using System.ComponentModel.DataAnnotations;

namespace Locadora.Common.Enums
{
    public enum CategoriaProduto
    {
        [Display(Name = "Ação")]
        Acao,
        [Display(Name = "Aventura")]
        Aventura,
        [Display(Name = "Comédia")]
        Comedia,
        [Display(Name = "Romance")]
        Romance,
        [Display(Name = "Suspense")]
        Suspense,
        [Display(Name = "Terror")]
        Terror          
    }
}
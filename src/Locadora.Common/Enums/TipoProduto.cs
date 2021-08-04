using System.ComponentModel.DataAnnotations;

namespace Locadora.Common.Enums
{
    public enum TipoProduto
    {
        [Display(Name = "Filme")]
        Filme,
        [Display(Name = "Jogo")]
        Jogo,
        [Display(Name = "Série")]
        Serie
    }
}
using System.ComponentModel.DataAnnotations;

namespace Locadora.Common.Enums
{
    public enum MidiaProduto
    {
        [Display(Name = "Blu-Ray")]
        BluRay,
        [Display(Name = "Cartucho")]
        Cartucho,
        [Display(Name = "CD")]
        CD,
        [Display(Name = "DVD")]
        DVD,
        [Display(Name = "VHS")]
        VHS        
    }
}
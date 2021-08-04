using System.ComponentModel.DataAnnotations;

namespace Locadora.Common.Enums
{
    public enum StatusAluguel
    {
        [Display(Name = "Solicitação pendente")]
        SolicitacaoPendente,
        [Display(Name = "Reserva concluída")]
        ReservaConcluida,
        [Display(Name = "Baixa na locação")]
        BaixaLocacao
    }
}
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public enum EnumStatusScheduling
{
    [Display(Name = "Aguardando confirmação")]
    WaitingConfirmation,
    [Display(Name = "Confirmado")]
    Confirmed
}
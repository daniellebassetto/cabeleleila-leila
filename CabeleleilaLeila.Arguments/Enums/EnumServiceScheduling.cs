using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public enum EnumServiceScheduling
{
    [Display(Name = "Corte")]
    Haircut,
    [Display(Name = "Hidratação")]
    Hydration,
    [Display(Name = "Manicure")]
    Manicure,
    [Display(Name = "Pedicure")]
    Pedicure
}
using System.ComponentModel.DataAnnotations;

public enum MarcadorCombustivelEnum
{
    Vazio,
    [Display(Name = "Um/quarto")]UmQuarto,
    [Display(Name = "Meio/tanque")] MeioTanque,
    [Display(Name = "Tres/quartos")] TresQuartos,
    Completo
}

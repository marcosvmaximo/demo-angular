using System.ComponentModel.DataAnnotations;
using CarrocinhaDoBem.Api.Models.Base;

namespace CarrocinhaDoBem.Api.Models;

public class Institution : ModelBase
{
    [Required(ErrorMessage = "O CNPJ da instituição é obrigatório.")]
    [StringLength(14, ErrorMessage = "O CNPJ da instituição deve ter 14 caracteres.")]
    public string InstitutionCNPJ { get; set; }

    [Required(ErrorMessage = "O nome da instituição é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome da instituição não pode ter mais de 100 caracteres.")]
    public string InstitutionName { get; set; }
}
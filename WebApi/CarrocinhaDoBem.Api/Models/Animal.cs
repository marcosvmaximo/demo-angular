using System.ComponentModel.DataAnnotations;
using CarrocinhaDoBem.Api.Models.Base;

namespace CarrocinhaDoBem.Api.Models;

public class Animal : ModelBase
{
    [Required(ErrorMessage = "O ID da instituição é obrigatório.")]
    public int InstitutionId { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "O tamanho do animal deve ser um número positivo.")]
    public double? PetSize { get; set; }

    [Required(ErrorMessage = "A idade do animal é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime AnimalAge { get; set; }

    [Required(ErrorMessage = "A data de resgate é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime RescueDate { get; set; }

    [Required(ErrorMessage = "O nome do animal é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do animal não pode ter mais de 100 caracteres.")]
    public string AnimalName { get; set; }

    [StringLength(50, ErrorMessage = "A raça do animal não pode ter mais de 50 caracteres.")]
    public string Breed { get; set; }

    [StringLength(20, ErrorMessage = "A cor do animal não pode ter mais de 20 caracteres.")]
    public string Color { get; set; }

    [Required(ErrorMessage = "O tipo de animal é obrigatório.")]
    [StringLength(50, ErrorMessage = "O tipo de animal não pode ter mais de 50 caracteres.")]
    public string AnimalType { get; set; }
}
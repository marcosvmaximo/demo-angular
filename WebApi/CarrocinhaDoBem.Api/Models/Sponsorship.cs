using System.ComponentModel.DataAnnotations;
using CarrocinhaDoBem.Api.Models.Base;

namespace CarrocinhaDoBem.Api.Models;

public class Sponsorship : ModelBase
{
    [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "O ID do animal é obrigatório.")]
    public int AnimalId { get; set; }

    [Required(ErrorMessage = "A data inicial da patrocínio é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime InitialDate { get; set; }

    [Required(ErrorMessage = "A data final da patrocínio é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "O valor da patrocínio é obrigatório.")]
    [Range(0, double.MaxValue, ErrorMessage = "O valor da patrocínio deve ser um número positivo.")]
    public double SponsorshipValue { get; set; }

    [StringLength(20, ErrorMessage = "O tipo de patrocínio não pode ter mais de 20 caracteres.")]
    public string SponsorshipType { get; set; }

    // Relacionamento com a tabela Animal
    public virtual Animal Animal { get; set; }

    // Relacionamento com a tabela User
    public virtual User User { get; set; }
}
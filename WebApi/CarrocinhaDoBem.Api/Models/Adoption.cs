using System.ComponentModel.DataAnnotations;
using CarrocinhaDoBem.Api.Models.Base;

namespace CarrocinhaDoBem.Api.Models;

public class Adoption : ModelBase
{
    [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "O ID do animal é obrigatório.")]
    public int AnimalId { get; set; }

    [Required(ErrorMessage = "A data de adoção é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime AdoptionDate { get; set; }

    public bool AdoptionStatus { get; set; }

    // Relacionamento com a tabela Animal
    public virtual Animal Animal { get; set; }

    // Relacionamento com a tabela User
    public virtual User User { get; set; }
}
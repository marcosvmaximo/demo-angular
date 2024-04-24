using System.ComponentModel.DataAnnotations;
using CarrocinhaDoBem.Api.Models.Base;

namespace CarrocinhaDoBem.Api.Models;

public class Donation : ModelBase
{
    [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "O ID da instituição é obrigatório.")]
    public int InstitutionId { get; set; }

    [Required(ErrorMessage = "O valor da doação é obrigatório.")]
    [Range(0, double.MaxValue, ErrorMessage = "O valor da doação deve ser um número positivo.")]
    public double DonationValue { get; set; }

    [Required(ErrorMessage = "A data da doação é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DonationDate { get; set; }

    [StringLength(200, ErrorMessage = "A descrição da doação não pode ter mais de 200 caracteres.")]
    public string Description { get; set; }

    // Relacionamento com a tabela Institution
    public virtual Institution Institution { get; set; }

    // Relacionamento com a tabela User
    public virtual User User { get; set; }
}
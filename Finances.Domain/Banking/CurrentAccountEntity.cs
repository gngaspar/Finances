namespace Finances.Domain.Banking
{
    using System.ComponentModel.DataAnnotations;

    public class CurrentAccountEntity : AccountEntity
    {
        [Required]
        [MaxLength(100)]
        public string Iban { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace LoadComboboxFilterIssue.Database
{
    public class MyEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required byte[] Data { get; set; }
    }
}

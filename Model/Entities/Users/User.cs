using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities.Users
{
    public class User
    {
        [Key, Required]
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedByName { get; set; }
        public Guid CreatedBy { get; set; }
        public string? UpdatedByName { get; set; }
        public Guid UpdatedBy { get; set; }
        public string? DeletedByName { get; set; }
        public Guid DeletedBy { get; set; }
        public DateTime CreateByDate { get; set; }
        public DateTime UpdateByDate { get; set; }
        public DateTime DeleteByDate { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }
        public AccountRole.RoleEnum Type { get; set; }
    }
}

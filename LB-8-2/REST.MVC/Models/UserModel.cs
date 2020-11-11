using System.ComponentModel.DataAnnotations;

namespace REST.MVC.Models
{
    public class UserModel
    {
        /// <summary>User's Id</summary>
        /// <example>0</example>
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        /// <summary>User's Email</summary>
        /// <example>test@mail.com</example>
        public string Email { get; set; }
        
        /// <summary>User's Password</summary>
        /// <example>Pa$$w0rd</example>
        public string Password { get; set; }
        
        /// <summary>User's Status</summary>
        /// <example>Online</example>
        /// <example>Offline</example>
        public string Status { get; set; }
        
        /// <summary>User's Role</summary>
        /// <example>Student</example>
        /// <example>Teacher</example>
        public string Role { get; set; }
    }
}
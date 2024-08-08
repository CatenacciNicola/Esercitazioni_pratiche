﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Esercitazione_18.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [StringLength(40)]
        public required string Name { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(max)")]
        public required string Password { get; set; }
        public List<Role> Roles { get; set; } = [];
        
    }
}

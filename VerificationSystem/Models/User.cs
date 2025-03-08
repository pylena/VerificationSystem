﻿using System.Reflection.Metadata;

namespace VerificationSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Document> Documents { get; set; } //reference to list of documents one-many
    }
}

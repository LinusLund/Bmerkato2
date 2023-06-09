﻿namespace Bmerkato2.Models.Dtos
{
    public class ContactFormData
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }
        public string Comment { get; set; } = null!;
        public bool RememberMe { get; set; }
        public DateTime DateTime { get; set; }
    }
}

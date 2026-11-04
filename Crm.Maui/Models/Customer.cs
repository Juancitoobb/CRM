using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Maui.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirtName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName => $"{FirtName} {LastName}";
    }
}

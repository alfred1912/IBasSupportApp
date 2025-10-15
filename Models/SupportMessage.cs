using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBasSupportApp.Models
{
    public class SupportMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [JsonProperty("customer")]
        public CustomerInfo Customer { get; set; } = new();

        [Required(ErrorMessage = "Beskrivelse skal udfyldes")]
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori skal udfyldes")]
        [JsonProperty("category")]
        public string Category { get; set; } = string.Empty;

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonProperty("status")]
        public string Status { get; set; } = "Åben";
    }

    public class CustomerInfo
    {
        [Required(ErrorMessage = "Navn skal udfyldes")]
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email skal udfyldes")]
        [EmailAddress(ErrorMessage = "Ugyldig email-adresse")]
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Ugyldigt telefonnummer")]
        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;
    }
}
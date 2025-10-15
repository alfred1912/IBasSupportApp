using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBasSupportApp.Models
{
    public class SupportMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("customer")]
        public CustomerInfo? Customer { get; set; }

        // Fallback-felter hvis gamle dokumenter ikke har "customer"
        [JsonProperty("name")]
        public string? LegacyName { get; set; }

        [JsonProperty("email")]
        public string? LegacyEmail { get; set; }

        [JsonProperty("phone")]
        public string? LegacyPhone { get; set; }

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

        // Helper properties til visning (kombinerer begge formater)
        [JsonIgnore]
        public string Name => Customer?.Name ?? LegacyName ?? string.Empty;

        [JsonIgnore]
        public string Email => Customer?.Email ?? LegacyEmail ?? string.Empty;

        [JsonIgnore]
        public string Phone => Customer?.Phone ?? LegacyPhone ?? string.Empty;
    }

    public class CustomerInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;
    }
}
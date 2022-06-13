using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Car
    {
        public int Id { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public string Model { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }

        public string Luggage { get; set; }
        public bool AirsConditioning { get; set; }

        public int MinimumAge { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile photo { get; set; }

    }
}

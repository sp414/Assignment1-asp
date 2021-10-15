using System;
using System.ComponentModel.DataAnnotations;

namespace Sanketkumar_Blankets.Models
{
    public class Blankets
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public decimal Rating { get; set; }

        public string Material { get; set; }
    }
}

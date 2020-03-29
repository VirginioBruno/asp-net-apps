using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceControl.Models 
{
    public class Spent 
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public SpentCategory Category { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Spent() { }
        public Spent(string description, double cost, SpentCategory category, DateTime date)
        {
            Description = description;
            Cost = cost;
            Category = category;
            Date = date;
        }
    }
}
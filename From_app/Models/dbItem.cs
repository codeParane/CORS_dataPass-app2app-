using System.ComponentModel.DataAnnotations;
namespace dbCore.Models{
    
   public class Book
    {
        [Key]
        public string Books{get; set;}
        public string Authors{get; set;}
       
    }
}
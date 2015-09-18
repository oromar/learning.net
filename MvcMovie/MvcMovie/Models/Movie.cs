using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID               { get; set; }
        [Required( ErrorMessage = "Title is Required !")]
        public string Title         { get; set; }
        [Required(ErrorMessage = "Release Date is Required !")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Genre is Required !")]
        public string Genre         { get; set; }
        [Required(ErrorMessage = "Title is Required !")]
        [Range(1, 100, ErrorMessage = "Price must be set between $1 and $100 !")]
        [DataType(DataType.Currency)]
        public decimal Price        { get; set; }
        [Required (ErrorMessage = "Rating is Required !")]
        [StringLength(5)]
        public string Rating        { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }

}
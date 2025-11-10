using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie>? Movies { get; set; }           // List of movies to display
        public SelectList? Genres { get; set; }            // List of genres for dropdown
        public string? MovieGenre { get; set; }           // Selected genre
        public string? SearchString { get; set; }         // Search string for title
    }
}
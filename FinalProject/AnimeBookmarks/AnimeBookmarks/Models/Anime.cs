using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace AnimeBookmarks.Models;





public class Anime
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Genre is required.")]
    public string? Genre { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Image URL is required.")]
    public string? ImageUrl { get; set; }
    
    public string? Slug { get; set; }

    public Anime() { }

    public Anime(int id, string title, string genre, string description, string imageUrl)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Description = description;
        ImageUrl = imageUrl;
    }

    public static string GenerateSlug(string title)
    {
        return title.ToLower().Replace(" ", "-");
    }
}


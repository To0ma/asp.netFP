using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YtBookStore.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int GenreId { get; set; }
        public virtual Author? Author { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}

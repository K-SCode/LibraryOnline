using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace LibraryOnline.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string? CoverImageURL { get; set; }
        public int TotalCopies { get; set; }
        public DateOnly PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;
        
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<Loan> Loans { get; set; } = [];
        public ICollection<Review> Reviews { get; set; } = [];
        public ICollection<Reservation> Reservations { get; set; } = [];
    }
}
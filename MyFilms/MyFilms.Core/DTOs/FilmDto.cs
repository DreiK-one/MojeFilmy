using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilms.Core.DTOs
{
    public class FilmDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float? Rating { get; set; }
        public int CreationYear { get; set; }
    }
}

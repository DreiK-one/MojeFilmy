using System.ComponentModel.DataAnnotations;

namespace MyFilms.WebAPI.Models.Requests
{
    public class CreateOrEditRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CreationYear { get; set; }
    }
}

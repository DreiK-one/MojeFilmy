namespace MyFilms.Data.Entities
{
    public class Film : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CreationYear { get; set; }
    }
}

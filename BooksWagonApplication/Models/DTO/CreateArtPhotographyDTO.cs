namespace BooksWagonApplication.Models.DTO
{
    public class CreateArtPhotographyDTO
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Author { get; set; }
        public int? Price { get; set; }
        public int? TotalPrice { get; set; }
        public string? Publisher { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Languagetype { get; set; }
        public string? Bindingtype { get; set; }
        public string? TypeOfBook { get; set; }
        public string? SubTypeOfBook { get; set; }
        public int? BookTypeId { get; set; }


    }
}

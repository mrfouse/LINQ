namespace LibraryApp.Models
{
    public abstract class Publication
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public abstract string Description { get; }
    }
}

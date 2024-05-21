namespace LibraryApp.Models
{
    public class Book : Publication
    {
        public string Summary { get; set; }

        public override string Description
        {
            get
            {
                return $"Book: {Title} by {Author}, Year: {Year}, Summary: {Summary}";
            }
        }
    }
}

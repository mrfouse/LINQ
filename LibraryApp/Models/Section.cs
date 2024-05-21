using System.Collections.Generic;

namespace LibraryApp.Models
{
    public class Section
    {
        public string Genre { get; set; }
        public int PublicationCount => Publications.Count;
        public List<Publication> Publications { get; set; }

        public Section()
        {
            Publications = new List<Publication>();
        }
    }
}

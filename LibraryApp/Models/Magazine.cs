using System.Collections.Generic;

namespace LibraryApp.Models
{
    public class Magazine : Publication
    {
        public List<string> Articles { get; set; }

        public Magazine()
        {
            Articles = new List<string>();
        }

        public override string Description
        {
            get
            {
                return $"Magazine: {Title} by {Author}, Year: {Year}, Articles: {string.Join(", ", Articles)}";
            }
        }
    }
}

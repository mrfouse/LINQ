using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Models
{
    public class Library
    {
        public string Name { get; set; }
        public List<Section> Sections { get; set; }

        public Library()
        {
            Sections = new List<Section>();
        }

        public void AddSection(Section section)
        {
            Sections.Add(section);
        }

        public void RemoveSection(string genre)
        {
            Sections.RemoveAll(s => s.Genre == genre);
        }

        public void UpdateSection(Section updatedSection)
        {
            var section = Sections.FirstOrDefault(s => s.Genre == updatedSection.Genre);
            if (section != null)
            {
                section.Genre = updatedSection.Genre;
                section.Publications = updatedSection.Publications;
            }
        }

        public void SortSectionsByGenre(bool ascending = true)
        {
            if (ascending)
            {
                Sections = Sections.OrderBy(s => s.Genre).ToList();
            }
            else
            {
                Sections = Sections.OrderByDescending(s => s.Genre).ToList();
            }
        }
    }
}

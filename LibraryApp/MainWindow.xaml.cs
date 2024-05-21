using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LibraryApp.Models;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Section> Sections { get; set; }
        private Library library;

        public MainWindow()
        {
            InitializeComponent();

            library = new Library { Name = "My Library" };
            Sections = new ObservableCollection<Section>(library.Sections);

            SectionsList.ItemsSource = Sections;
        }

        private void AddSection_Click(object sender, RoutedEventArgs e)
        {
            var section = new Section { Genre = $"Genre {Sections.Count + 1}" };
            library.AddSection(section);
            Sections.Add(section);
        }

        private void RemoveSection_Click(object sender, RoutedEventArgs e)
        {
            if (SectionsList.SelectedItem is Section selectedSection)
            {
                library.RemoveSection(selectedSection.Genre);
                Sections.Remove(selectedSection);
            }
        }

        private void EditSection_Click(object sender, RoutedEventArgs e)
        {
            if (SectionsList.SelectedItem is Section selectedSection)
            {
                var editWindow = new EditSectionWindow(selectedSection);
                if (editWindow.ShowDialog() == true)
                {
                    var editedSection = editWindow.Section;
                    library.UpdateSection(editedSection);
                    var index = Sections.IndexOf(selectedSection);
                    Sections[index] = editedSection;
                    SectionsList.Items.Refresh();
                }
            }
        }

        private void SortSectionsAscending_Click(object sender, RoutedEventArgs e)
        {
            library.SortSectionsByGenre(true);
            Sections = new ObservableCollection<Section>(library.Sections);
            SectionsList.ItemsSource = Sections;
        }

        private void SortSectionsDescending_Click(object sender, RoutedEventArgs e)
        {
            library.SortSectionsByGenre(false);
            Sections = new ObservableCollection<Section>(library.Sections);
            SectionsList.ItemsSource = Sections;
        }

        private void AddPublication_Click(object sender, RoutedEventArgs e)
        {
            if (SectionsList.SelectedItem is Section selectedSection)
            {
                string selectedPublicationType = ((ComboBoxItem)PublicationTypeComboBox.SelectedItem).Content.ToString();
                Publication publication = null;

                switch (selectedPublicationType)
                {
                    case "Book":
                        publication = new Book { Title = "New Book", Author = "Unknown", Year = 2022, Summary = "No summary" };
                        break;
                    case "Magazine":
                        publication = new Magazine { Title = "New Magazine", Author = "Unknown", Year = 2022, Articles = new List<string> { "Article 1" } };
                        break;
                }

                if (publication != null)
                {
                    selectedSection.Publications.Add(publication);
                    library.UpdateSection(selectedSection);
                    SectionsList.Items.Refresh();
                }
            }
        }

        private void RemovePublication_Click(object sender, RoutedEventArgs e)
        {
            if (SectionsList.SelectedItem is Section selectedSection)
            {
                if (selectedSection.Publications.Count > 0)
                {
                    selectedSection.Publications.RemoveAt(selectedSection.Publications.Count - 1); // Example of removing the last publication
                    library.UpdateSection(selectedSection);
                    SectionsList.Items.Refresh();
                }
            }
        }
    }
}

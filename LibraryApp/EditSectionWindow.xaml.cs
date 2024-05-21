using System.Windows;
using LibraryApp.Models;

namespace LibraryApp
{
    public partial class EditSectionWindow : Window
    {
        public Section Section { get; private set; }

        public EditSectionWindow(Section section)
        {
            InitializeComponent();

            Section = section;
            GenreTextBox.Text = Section.Genre;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(GenreTextBox.Text))
            {
                Section.Genre = GenreTextBox.Text;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid genre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Developing_an_application_using
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Note
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    public partial class MainWindow : Window
    {
        public ObservableCollection<Note> Notes { get; set; }
        private bool isEditing = false;
        public MainWindow()
        {
            InitializeComponent();
            Notes = new ObservableCollection<Note>();
            notes.ItemsSource = Notes;
            notes.SelectionChanged += Notes_Changed;
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            Notes.Add(new Note { Title = "Новая заметка", Text = "" });
            notes.SelectedItem = Notes[Notes.Count - 1];
            UpdateButtonStates();
        }
        private void Notes_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateText();
            UpdateButtonStates();
        }
        private void UpdateText()
        {
            if (notes.SelectedItem is Note selectedNote)
            {
                title.Text = selectedNote.Title;
                text.Text = selectedNote.Text;
            }
            else
            {
                title.Text = "";
                text.Text = "";
            }
            title.IsReadOnly = !isEditing;
            text.IsReadOnly = !isEditing;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (notes.SelectedItem is Note note)
            {
                title.IsReadOnly = false;
                text.IsReadOnly = false;
                title.Focus();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (notes.SelectedItem is Note note)
            {
                Notes.Remove(note);
                UpdateText();
                UpdateButtonStates();
            }
        }
        private void UpdateButtonStates()
        {
            bool hasSelection = notes.SelectedItem != null;
            EditNote.IsEnabled = hasSelection;
            DeleteNote.IsEnabled = hasSelection;
        }
        private void title_Changed(object sender, TextChangedEventArgs e)
        {
            UpdateNote();
        }

        private void text_Changed(object sender, TextChangedEventArgs e)
        {
            UpdateNote();
        }

        private void UpdateNote()
        {
            if (notes.SelectedItem is Note note && isEditing)
            {
                note.Title = title.Text;
                note.Text = text.Text;
            }
        }
    }
}

using Notes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notes.ViewModels
{
    public class AllNotesViewModel : INotifyPropertyChanged
    {

        private string _currentNote;
        public string CurrentNote
        {
            get => _currentNote;
            set
            {
                if (_currentNote != value)
                {
                    _currentNote = value;
                    OnPropertyChanged(nameof(CurrentNote));
                }
            }
        }

        private string _currentDescription;
        public string CurrentDescription
        {
            get => _currentDescription;
            set
            {
                if (_currentDescription != value)
                {
                    _currentDescription = value;
                    OnPropertyChanged(nameof(CurrentDescription));
                }
            }
        }

        public ObservableCollection<Note> Notes { get; set; }
        public ICommand addNoteCommand { get; }

        public AllNotesViewModel()
        {
            Notes = new ObservableCollection<Note>();
            addNoteCommand = new Command(AddNote);
        }

        private void AddNote()
        {
            if (!string.IsNullOrWhiteSpace(CurrentNote))
            {
                Notes.Add(new Note
                {
                    CurrentNote = CurrentNote,
                    Description = CurrentDescription,
                    Date = DateTime.Now
                });
                CurrentNote = string.Empty;
                CurrentDescription = string.Empty;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

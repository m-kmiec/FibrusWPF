using Caliburn.Micro;
using Fibrus.Models;
using FibrusWPF.Events;

namespace FibrusWPF.ViewModels
{
    internal class StudentDeletionViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        private int _id;

        public int Id
        {
            get 
            {
                return _id;
            }
            set 
            { 
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
        public StudentDeletionViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void OnSubmit()
        {
            _eventAggregator.PublishOnUIThreadAsync(new StudentDeletionEvent(Id));
        }
    }
}
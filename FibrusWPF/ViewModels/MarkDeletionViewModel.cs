using Caliburn.Micro;
using FibrusWPF.Events;

namespace FibrusWPF.ViewModels
{
    internal class MarkDeletionViewModel : Screen
    {
        private int _id;
        private string _mark;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);

            }
        }

        public string Mark
        {
            get { return _mark; }
            set
            {
                _mark = value;
                NotifyOfPropertyChange(() => Mark);
            }
        }

        private IEventAggregator eventAggregator;

        public MarkDeletionViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }
        public void OnSubmit()
        {
            eventAggregator.PublishOnUIThreadAsync(new MarkDeletionEvent(Id, Mark));
        }
    }
}
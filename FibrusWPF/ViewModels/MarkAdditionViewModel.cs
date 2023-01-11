using Caliburn.Micro;
using Fibrus.Models;
using Fibrus.Utils;
using FibrusWPF.Events;

namespace FibrusWPF.ViewModels
{
    internal class MarkAdditionViewModel : Screen
    {        
        private IEventAggregator eventAggregator;

        private int _id;

        private string _mark;

        public int Id
        {
            get { return _id; }
            set { _id = value;
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

        public MarkAdditionViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void OnSubmit()
        {
            eventAggregator.PublishOnUIThreadAsync(new MarkAdditionEvent(Id, Mark));
        }
    }
}
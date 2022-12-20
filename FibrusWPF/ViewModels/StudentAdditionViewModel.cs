using Caliburn.Micro;
using Fibrus.Models;
using Fibrus.Utils;
using FibrusWPF.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibrusWPF.ViewModels
{
    internal class StudentAdditionViewModel : Screen
    {
		private readonly IEventAggregator _eventAggregator;

        private TextDatabase textDatabase = TextDatabase.getInstance();

        private string _firstName;
		private string _lastName;
		private string _className;
		private string _marks;
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value;
				NotifyOfPropertyChange(() => FirstName);
			}
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value;
				NotifyOfPropertyChange(() => LastName);
			}
		}
		public string ClassName
		{
			get { return _className; }
			set { _className = value;
				NotifyOfPropertyChange(() => ClassName);
			}
		}

		public string Marks
		{
			get { return _marks; }
			set { _marks = value;
				NotifyOfPropertyChange(() => Marks);
			}
		}

		public StudentAdditionViewModel(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
		}
		public void OnSubmit()
		{
			_eventAggregator.PublishOnUIThreadAsync(new SubmitEvent(FirstName, LastName, ClassName, Marks));
			textDatabase.AddStudent(FirstName, LastName, ClassName, Marks);
		}

	}
}

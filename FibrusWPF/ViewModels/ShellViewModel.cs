using Caliburn.Micro;
using Fibrus.Models;
using Fibrus.Utils;
using FibrusWPF.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace FibrusWPF.ViewModels
{
	public class ShellViewModel : Conductor<object>, IHandle<SubmitEvent>
    {
		private readonly IEventAggregator _eventAggregator;
		private StudentAdditionViewModel StudentAdditionViewModel { get; set; }

		private TextDatabase textDatabase = TextDatabase.getInstance();

		private StudentClass _selectedStudentClass;
		private BindableCollection<Student> _studentsForSelectedClass;
		private BindableCollection<StudentClass> _studentClasses;

		public StudentClass SelectedStudentClass 
		{ 
			get { return _selectedStudentClass; }
			set
			{
                _selectedStudentClass = value;
                NotifyOfPropertyChange(() => SelectedStudentClass);
				UpdateGrid();
			}
		}
		public BindableCollection<Student> StudentsForSelectedClass 
		{ 
			get {	return _studentsForSelectedClass;  }
			set	
			{	
				_studentsForSelectedClass = value;
				NotifyOfPropertyChange(() => StudentsForSelectedClass);
			} 
		}
		public BindableCollection<StudentClass> StudentClasses
		{
			get { return _studentClasses; }
			set { _studentClasses = value;
				NotifyOfPropertyChange(() => StudentClasses);
			}
		}

		[System.Obsolete]
		public ShellViewModel(IEventAggregator eventAggregator)
		{
			getStudentClasses();
			_eventAggregator = eventAggregator;
			eventAggregator.SubscribeOnPublishedThread(this);
		}

		private void getStudentClasses()
		{
			StudentClasses = new BindableCollection<StudentClass>(textDatabase.getStudentClasses());
		}

		private void UpdateGrid()
		{
			StudentsForSelectedClass = new BindableCollection<Student>(SelectedStudentClass.Students);
		}

		public void LoadStudentAdditionForm()
		{
			StudentAdditionViewModel = new StudentAdditionViewModel(_eventAggregator);
			ActivateItemAsync(StudentAdditionViewModel);
		}

        public void LoadStudentDeletionForm()
		{
			
		}

        Task IHandle<SubmitEvent>.HandleAsync(SubmitEvent message, CancellationToken cancellationToken)
		{
			DeactivateItemAsync(StudentAdditionViewModel, true);
            return Task.CompletedTask;
        }
	}
}

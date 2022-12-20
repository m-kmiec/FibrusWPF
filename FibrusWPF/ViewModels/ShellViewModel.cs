using Caliburn.Micro;
using Fibrus.Models;
using Fibrus.Utils;
using FibrusWPF.Events;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace FibrusWPF.ViewModels
{
	public class ShellViewModel : Conductor<object>, IHandle<SubmitEvent>, IHandle<DeletionEvent>, IHandle<MarkAdditionEvent>, IHandle<MarkDeletionEvent>
    {
		private readonly IEventAggregator _eventAggregator;
		private StudentAdditionViewModel StudentAdditionViewModel { get; set; }
		private StudentDeletionViewModel StudentDeletionViewModel { get; set; }
		private MarkAdditionViewModel MarkAdditionViewModel { get; set; }
		private MarkDeletionViewModel MarkDeletionViewModel { get; set; }

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
			StudentDeletionViewModel = new StudentDeletionViewModel(_eventAggregator);
			ActivateItemAsync(StudentDeletionViewModel);
		}
		public void LoadMarkAdditionForm()
		{
			MarkAdditionViewModel = new MarkAdditionViewModel(_eventAggregator);
			ActivateItemAsync(MarkAdditionViewModel);
		}
		
		public void LoadMarkDeletionForm()
		{
            MarkDeletionViewModel = new MarkDeletionViewModel(_eventAggregator);
            ActivateItemAsync(MarkDeletionViewModel);
        }

        Task IHandle<SubmitEvent>.HandleAsync(SubmitEvent message, CancellationToken cancellationToken)
		{
			Student student = new Student(message.FirstName, message.LastName, StudentsForSelectedClass.Count + 1, message.Marks);
			StudentsForSelectedClass.Add(student);
			textDatabase.AddStudent(message.FirstName, message.LastName, SelectedStudentClass.ClassName, message.Marks);
			StudentsForSelectedClass.Refresh();
			DeactivateItemAsync(StudentAdditionViewModel, true);
            return Task.CompletedTask;
        }
		
		Task IHandle<DeletionEvent>.HandleAsync(DeletionEvent message, CancellationToken cancellationToken)
		{
			StudentsForSelectedClass.Remove(StudentsForSelectedClass.Single(s => s.Id == message.Id));
            StudentsForSelectedClass.Refresh();
            DeactivateItemAsync(StudentDeletionViewModel, true);
			return Task.CompletedTask;
		}

		Task IHandle<MarkAdditionEvent>.HandleAsync(MarkAdditionEvent message, CancellationToken cancellationToken)
		{
			StudentsForSelectedClass.First(s => s.Id == message.StudentId).MarkString += (", " + message.Mark);
			textDatabase.AddMark(message.StudentId, Convert.ToInt32(message.Mark), SelectedStudentClass.Id);
            StudentsForSelectedClass.Refresh();
			DeactivateItemAsync(MarkAdditionViewModel, true);
            return Task.CompletedTask;
        }

		Task IHandle<MarkDeletionEvent>.HandleAsync(MarkDeletionEvent message, CancellationToken cancellationToken)
		{
            Student student = textDatabase.DeleteMark(message.StudentId, Convert.ToInt32(message.Mark), SelectedStudentClass.Id);
			student.MarkString = student.MarksToString();
			StudentsForSelectedClass[message.StudentId - 1] = student;
            StudentsForSelectedClass.Refresh();

			DeactivateItemAsync(MarkDeletionViewModel, true);

            return Task.CompletedTask;
		}
	}
}

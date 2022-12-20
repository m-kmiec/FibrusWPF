using Caliburn.Micro;
using Fibrus.Models;
using Fibrus.Utils;

namespace FibrusWPF.ViewModels
{
	public class ShellViewModel : Conductor<object>
    {
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
			set { _studentClasses = value; }
		}

		public ShellViewModel()
		{
			getStudentClasses();
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
			ActivateItemAsync(new StudentAdditionViewModel());
		}
	}
}

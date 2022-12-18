using Caliburn.Micro;
using Fibrus.Models;
using Fibrus.Utils;

namespace FibrusWPF.ViewModels
{
	public class ShellViewModel : Screen
    {
		private TextDatabase textDatabase = TextDatabase.getInstance();
		
		private StudentClass studentClass;
		private BindableCollection<Student> _students;

		public BindableCollection<Student> Students 
		{ 
			get
			{
				return _students;
			}
			set
			{
				_students = value;
			} 
		}
		public ShellViewModel()
		{
			studentClass = textDatabase.getStudentClasses(0);
			Students = new BindableCollection<Student>(studentClass.Students);
		}
	
	}
}

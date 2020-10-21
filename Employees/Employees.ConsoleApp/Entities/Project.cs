namespace Employees.ConsoleApp.Entities
{
    public class Project
    {
        public int ProjectID
        {
            get;
            private set;
        }

        public int Days
        {
            get;
            private set;
        }

        public Project(int projectId, int days)
        {
            ProjectID = projectId;
            Days = days;
        }
    }
}

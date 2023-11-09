using ProjectModel;
using ConsoleTables;

using IEntityOperation;
using ProjectModel;

namespace Project
{
    public class ProjectMethods : IEntity<ProjectProperties>
    {
        public static List<ProjectProperties> list = new List<ProjectProperties>();
        static ProjectMethods projectMethods = new ProjectMethods();

        /// Adds a project to the list.

        /// <param name="project">The project to add.</param>
        public void Add(ProjectProperties project)
        {
            list.Add(project);
        }

        /// Returns a console table with all projects.

        /// <returns>A console table with all projects.</returns>
        public ConsoleTable ListAll()
        {
            var table = new ConsoleTable("ProjectId", "ProjectName", "Start Date", "End Date");

            foreach (var project in list)
            {
                string formattedStartDate = project.StartDate.ToString("MM-dd-yyyy");
                string formattedEndDate = project.EndDate.ToString("MM-dd-yyyy");

                table.AddRow(project.Id, project.Name, formattedStartDate, formattedEndDate);
            }

            return table;
        }

        /// Returns a console table with the project that matches the given ID.

        /// <param name="projectId">The ID of the project to list.</param>
        /// <returns>A console table with the project that matches the given ID.</returns>
        public ConsoleTable ListById(int projectId)
        {
            var table = new ConsoleTable("ProjectId", "ProjectName", "Start Date", "End Date");

            var project = list.Find(p => p.Id == projectId);
            if (project != null)
            {
                string formattedStartDate = project.StartDate.ToString("MM-dd-yyyy");
                string formattedEndDate = project.EndDate.ToString("MM-dd-yyyy");

                table.AddRow(project.Id, project.Name, formattedStartDate, formattedEndDate);
            }

            return table;
        }

        /// Deletes the project that matches the given ID from the list.

        /// <param name="projectId">The ID of the project to delete.</param>
        /// <returns>True if the project was deleted successfully, false otherwise.</returns>
        public bool DeleteById(int projectId)
        {
            var project = list.Find(p => p.Id == projectId);
            if (project != null)
            {
                list.Remove(project);
                return true;
            }

            return false;
        }

        public bool MapEmployeToProject(int projectId, int employeeId)
        {
            var projectObj = list.Find(projectIdObj => projectIdObj.Id == projectId);
            if (projectObj != null)
            {
                projectObj.ProjectEmployesList.Add(employeeId);
                return true;
            }
            return false;
        }

        public bool CheckEmployeMapedToProject(int empId)
        {
            foreach (var listObj in list)
            {
                if (listObj.ProjectEmployesList.Contains(empId))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteEmployeeFromProject(int projectIdToFind, int employeIdToDelete)
        {
            var employeToDelete = list.Find(
                projectIdObj =>
                    projectIdObj.Id == projectIdToFind
                    && projectIdObj.ProjectEmployesList.Contains(employeIdToDelete)
            );
            if (employeToDelete != null)
            {
                employeToDelete.ProjectEmployesList.Remove(employeIdToDelete);
                return true;
            }
            return false;
        }

        public bool CheckProjectIdExists(int projectIdExists)
        {
            var projectIdObjExists = list.Find(projectId => projectId.Id == projectIdExists);

            if (projectIdObjExists != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckEmployeIdExists(int empIdExists)
        {
            var employeIdExists = list.Find(employeIdObj => employeIdObj.Id == empIdExists);
            if (employeIdExists != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckEmployeIdExistsInProject(int projectIdExists, int empIdExists)
        {
            var employeIdExists = list.Find(
                employeIdObj =>
                    employeIdObj.Id == projectIdExists
                    && employeIdObj.ProjectEmployesList.Contains(empIdExists)
            );
            if (employeIdExists != null)
            {
                return true;
            }
            return false;
        }
    }
}

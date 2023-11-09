using ConsoleTables;
using AddEmployeeToProjectProps;

namespace AddEmployeToProject
{
    public class AddEmployeeToProjectMethods
    {
        public static List<AddEmployeeToProjectProperties> addEmployeeToProjectslist = new List<AddEmployeeToProjectProperties>();

        /// Adds an employee to the list of employees assigned to projects.
        
        /// <param name="addEmployeeToProjectObj">The employee to add to the project.</param>
        public static void AddEmployeeToProject(AddEmployeeToProjectProperties addEmployeeToProjectObj)
        {
            addEmployeeToProjectslist.Add(addEmployeeToProjectObj);
        }

        
        /// Displays a table of the employees assigned to projects.
       
        public static void ViewEmployeesOfProject()
        {
            var table = new ConsoleTable("ProjectId", "EmployeeId", "FirstName", "LastName");
            foreach (AddEmployeeToProjectProperties addEmployeeToProject in addEmployeeToProjectslist)
            {
                table.AddRow(addEmployeeToProject.ProjectId, addEmployeeToProject.EmployeeId, addEmployeeToProject.FirstName, addEmployeeToProject.LastName);
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(table);
            Console.ResetColor();
        }        

        
        /// Removes an employee from the list of employees assigned to a specific project.
        
        /// <param name="employeeIdToRemove">The ID of the employee to remove.</param>
        /// <param name="projectIdToRemove">The ID of the project from which to remove the employee.</param>
        public static void RemoveEmployeeFromProject(int employeeIdToRemove, int projectIdToRemove)
        {
            addEmployeeToProjectslist.RemoveAll(itemObj => itemObj.EmployeeId == employeeIdToRemove && itemObj.ProjectId == projectIdToRemove);
        }
    }
}

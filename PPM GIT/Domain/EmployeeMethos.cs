// using Properties;
using ConsoleTables;
using System.Collections.Generic;
using Employee_Details;
using AddEmployeeToProjectProps;
using IEntityOperation;

namespace Employee
{
    public class EmployeeMethods:IEntity<EmployeeDetailsProps>
    {

        public static  List<EmployeeDetailsProps> list = new List<EmployeeDetailsProps>();

        
        /// Adds an employee to the list of employees.
        
        /// <param name="employeeDetailsObj">The employee details object to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when the employee details object is null.</exception>
        public  void Add(EmployeeDetailsProps employeeDetailsObj)
        {
            if (employeeDetailsObj == null)
            {
                throw new ArgumentNullException(nameof(employeeDetailsObj), "Employee details object cannot be null.");
            }

            list.Add(employeeDetailsObj);
            Console.WriteLine("Employee Details Added Successfully....");
        }

        
        /// Displays a table with the details of all employees in the list.
      
        /// <returns>The console table with employee details.</returns>
        public  ConsoleTable ListAll()
        {
            var table = new ConsoleTable("Id", "Firstname", "LastName", "Email", "PhoneNumber", "EmployeeAddress", "RollId");

            foreach (EmployeeDetailsProps employeeDetails in list)
            {
                table.AddRow(employeeDetails.Id, employeeDetails.FirstName, employeeDetails.LastName, employeeDetails.Email, employeeDetails.PhoneNumber, employeeDetails.EmployeeAddress, employeeDetails.RollId);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            table.Write();
            Console.ResetColor();

            return table;
        }

        
        /// Displays a table with the details of the employee with the specified ID.
       
        /// <param name="employeeId">The ID of the employee to display.</param>
        /// <returns>The console table with the employee details.</returns>
        public  ConsoleTable ListById(int employeeId)
        {
            var employeeIdTable = new ConsoleTable("Id", "Firstname", "LastName", "Email", "PhoneNumber", "EmployeeAddress", "RollId");
            var emp = list.FirstOrDefault(empobj => empobj.Id == employeeId);

            if (emp != null)
            {
                employeeIdTable.AddRow(emp.Id, emp.FirstName, emp.LastName, emp.Email, emp.PhoneNumber, emp.EmployeeAddress, emp.RollId);
            }

            return employeeIdTable;
        }

     
        /// Deletes the employee with the specified ID from the list.
   
        /// <param name="deleteEmployeeId">The ID of the employee to delete.</param>
        /// <returns>True if the employee was deleted successfully, false otherwise.</returns>
        public  bool DeleteById(int deleteEmployeeId)
        {
            var deleteEmployeeIdObj = list.FirstOrDefault(deleteEmpObj => deleteEmpObj.Id == deleteEmployeeId);

            if (deleteEmployeeIdObj != null)
            {
                list.Remove(deleteEmployeeIdObj);
                return true;
            }

            return false;
        }

        public  bool CheckEmployeIdExists(int EmployeId)
        {
            var checkEmployeeIdObj = list.FirstOrDefault(deleteEmpObj => deleteEmpObj.Id == EmployeId);

            if (checkEmployeeIdObj != null)
            {
               
                return true;
            }

            return false;
           
        }
        public  int CheckRoleIdMatchedToEmployeeId(int roleId)
        {
            var checkRoleIdObj = list.FirstOrDefault(deleteEmpObj => deleteEmpObj.RollId == roleId);
            if(checkRoleIdObj != null)
            {
                return checkRoleIdObj.Id;
            }
            return 0;


            
        }
    }
}

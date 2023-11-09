// using ConsoleTables;
// using Properties;
// using Logic;
// using System.Text.RegularExpressions;
// using System.Collections;

// namespace UserInterface
// {
//     public class UI
//     {
//         public void ViewDisplay()
//         {
//             ConsoleTable consoleTable = ProjectMethods.ViewProject();
//             System.Console.WriteLine(consoleTable);

//         }
//         public int MenuMethod()
//         {


//             // Display the main menu
//             Console.ForegroundColor = ConsoleColor.Green;
//             var table = new ConsoleTable("-----Menu Options-----");
//             table.AddRow("1. Add Project");
//             table.AddRow("2. View Project");
//             table.AddRow("3. Add Employee");
//             table.AddRow("4. View Employee");
//             table.AddRow("5. Add Roles");
//             table.AddRow("6. View Roles");
//             table.AddRow("7. Add Employee To Project");
//             table.AddRow("8. Delete Employee From Project");
//             table.AddRow("9. View Employees in  Project");
//             table.AddRow("10. Quit");



//             System.Console.WriteLine(table);
//             Console.ResetColor(); //reset the color

//             Console.ForegroundColor = ConsoleColor.Yellow; //set the color 
//             System.Console.Write("Choose any option : ");
//             int chooseOption = Convert.ToInt32(Console.ReadLine());

//             Console.ResetColor();
//             return chooseOption;

//         }


//         public ProjectProperties AddProjectUi()
//         {
//             Console.Clear();
//             int projectId;
//             while (true)
//             {
//                 Console.Write("Enter Project Id : ");
//                 if (!int.TryParse(Console.ReadLine(), out projectId))
//                 {
//                     Console.WriteLine("Invalid input for Project Id. Please enter a number.");
//                     continue;
//                 }
//                 break;
//             }

//             // input from the user
//             Console.Write("Enter Project Name: ");
//             string projectName = Console.ReadLine();

//             DateTime startDate; //Date Initialization
//             while (true)
//             {
//                 Console.Write("Enter Project StartDate in the format MM/DD/YYYY: ");
//                 if (!DateTime.TryParse(Console.ReadLine(), out startDate))
//                 {
//                     Console.WriteLine("Invalid date format. Please use MM/DD/YYYY.");
//                     continue;
//                 }
//                 break;
//             }

//             DateTime endDate;
//             while (true)
//             {
//                 Console.Write("Enter Project EndDate: ");
//                 if (!DateTime.TryParse(Console.ReadLine(), out endDate))
//                 {
//                     Console.WriteLine("Invalid date format. Please use MM/DD/YYYY.");
//                     continue;
//                 }
//                 else if (startDate >= endDate)
//                 {
//                     System.Console.WriteLine("start date cannot be greater than enddate...");
//                     continue;
//                 }
//                 else
//                 {
//                     break;
//                 }

//             }


//             ProjectProperties projectProperties = new ProjectProperties
//             {
//                 Id = projectId,
//                 Name = projectName,
//                 StartDate = startDate,
//                 EndDate = endDate
//             };
//             Console.WriteLine("Project added successfully....");
//             return projectProperties;

//         }
//         public void AddEmployeUi()
//         {
//             Console.Clear();
//             UI ui = new UI();
//             EmployeeMethods employeeMethods = new();
//         // Id, First name, Last name, Email, Mobile, Address, RoleId
//         EmpId:
//             System.Console.WriteLine("Enter Employee Id");
//             int id = Convert.ToInt32(Console.ReadLine());


//             bool isValid = EmployeeMethods.list.Any(a => a.Id == id);
//             if (isValid)
//             {
//                 System.Console.WriteLine("Employee Id already exists.");
//                 goto EmpId;
//             }

//             System.Console.Write("Enter Employee First Name :");
//             string firstName = Console.ReadLine();

//             System.Console.Write("Enter Employee Last Name :");
//             string lastName = Console.ReadLine();
//             string email = null;
//             RolesMethods rolesMethods = new RolesMethods();
//             while (true)
//             {
//                 System.Console.Write("Enter Employee Email :");
//                 email = Console.ReadLine();
//                 //Checking the email is valid or not

//                 if (!IsValidEmail(email))
//                 {
//                     System.Console.Write("Employee Email is not valid ");
//                 }
//                 else
//                 {
//                     break;
//                 }
//             }

//             static bool IsValidEmail(string email)
//             {
//                 // Define a regular expression pattern for basic email validation
//                 string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

//                 // Use Regex.IsMatch to check if the email matches the pattern
//                 return Regex.IsMatch(email, pattern);
//             }
//             string inputPhoneNumber = null;

//             while (true)
//             {

//                 System.Console.Write("Enter Employee Phone Number :");
//                 inputPhoneNumber = Console.ReadLine();

//                 if (inputPhoneNumber.Length != 10)
//                 {
//                     System.Console.Write("Please Enter the valid phone number...");
//                 }
//                 else
//                 {
//                     break;
//                 }

//             }
//             System.Console.Write("Enter Employee Address : ");
//             string employeeAddress = Console.ReadLine();
//             int rollId;

//         roll:

//             while (true)
//             {

//                 Console.Write("Enter Roll Id : ");
//                 if (!int.TryParse(Console.ReadLine(), out rollId))
//                 {
//                     Console.WriteLine("Invalid input for Roll Id. Please enter a number.");
//                     continue;
//                 }




//                 if (RolesMethods.rolesList.Count != 0)
//                 {

//                     if (isPresent(rollId))
//                     {
//                         EmployeeDetails employeeDetails = new EmployeeDetails
//                         {
//                             Id = id,
//                             FirstName = firstName,
//                             LastName = lastName,
//                             PhoneNumber = inputPhoneNumber,
//                             Email = email,
//                             EmployeeAddress = employeeAddress,
//                             RollId = rollId
//                         };



//                         employeeMethods.AddEmployee(employeeDetails);
//                     }

//                     else
//                     {
//                         System.Console.WriteLine("Enter Valid Roll Id");
//                         goto roll;


//                     }


//                 }
//                 else
//                 {
//                     System.Console.WriteLine("No Roles Present to Assign...");
//                     // ui.MenuMethod();

//                 }



//                 break;


//             }


//         }

//         public bool isPresent(int rollId)
//         {
//             foreach (Roles role in RolesMethods.rolesList)
//             {

//                 if (role.RollId == rollId)
//                 {
//                     return true;
//                 }
//             }
//             return false;

//         }


//         public Roles AddRolesUi()
//         {
//             System.Console.WriteLine("Enter the Role Id");
//             int roleId = Convert.ToInt32(Console.ReadLine());
//             System.Console.WriteLine("Enter the Employee Name");
//             string rollName = Console.ReadLine();

//             Roles roles = new Roles
//             {
//                 RollId = roleId,
//                 RollName = rollName
//             };

//             return roles;
//         }


//         public void AddEmployeetoProject()
//         {
//             int projectId;
//             AddEmployeeToProjectMethods addEmployeeToProjectMethodsObj = new AddEmployeeToProjectMethods();
//             ProjectMethods projectMethods = new ProjectMethods();
//             while (true)
//             {
//             projId:
//                 System.Console.WriteLine($"{ProjectMethods.list.Count()}");
//                 System.Console.WriteLine("Enter ProjectId");
//                 if (!int.TryParse(Console.ReadLine(), out projectId))
//                 {
//                     System.Console.WriteLine("Enter Proper ProjectId");
//                     continue;
//                 }
//                 else
//                 {

//                     foreach (ProjectProperties projectObj in ProjectMethods.list)
//                     {
//                         if (projectObj.Id == projectId)
//                         {
//                             int employeeId;
//                         empId:
//                             while (true)
//                             {

//                                 System.Console.Write("Enter Employee Id :");
//                                 if (!int.TryParse(Console.ReadLine(), out employeeId))
//                                 {
//                                     System.Console.WriteLine("Enter Proper Employee Id");
//                                     continue;
//                                 }
//                                 if (isPresentEmployeeId(employeeId))
//                                 {
//                                     var empObj = EmployeeMethods.list.FirstOrDefault(a => a.Id == employeeId);
//                                     AddEmployeeToProject addEmployeeToProject = new AddEmployeeToProject
//                                     {
//                                         ProjectId = projectId,
//                                         EmployeeId = employeeId,
//                                         FirstName = empObj.FirstName,
//                                         LastName = empObj.LastName

//                                     };
//                                     addEmployeeToProjectMethodsObj.AddEmployeeToProject(addEmployeeToProject);
//                                 }

//                                 else
//                                 {
//                                     System.Console.WriteLine("Enter valid employeeId");
//                                     goto empId;
//                                 }

//                                 break;

//                             }


//                         }
//                         else
//                         {
//                             System.Console.WriteLine("Enter Valid Project Id");
//                             goto projId;
//                         }

//                     }
//                     break;
//                 }
//             }



//         }
//         public bool isPresentEmployeeId(int employeeId)
//         {

//             foreach (var employeeObj in EmployeeMethods.list)
//             {

//                 if (employeeObj.Id == employeeId)
//                 {

//                     return true;
//                 }

//             }
//             return false;
//         }

//         public static (int,int) DeleteEmployeeFromProject()
//         {

//             int employeeIdToRemove;
//             int projectIdToRemove;
//             while (true)
//             {
//                 System.Console.Write("Enter EmployeeId :");
//                 if (!int.TryParse(Console.ReadLine(), out employeeIdToRemove))
//                 {
//                     System.Console.Write("enter valid employeeId :");
//                     continue;
//                 }
//                 System.Console.Write("Enter ProjectId :");
//                 if (!int.TryParse(Console.ReadLine(), out projectIdToRemove))
//                 {
//                     System.Console.Write("enter valid Project Id :");
//                     continue;
//                 }
//                 bool employeeIdIsPresent = AddEmployeeToProjectMethods.addEmployeeToProjectslist.Any(a => a.EmployeeId == employeeIdToRemove);
//                 if (!employeeIdIsPresent)
//                 {
//                     System.Console.WriteLine("Entered employee id is not present");
//                     continue;
//                 }
//                 bool projectIdIsPresent = AddEmployeeToProjectMethods.addEmployeeToProjectslist.Any(a => a.ProjectId == employeeIdToRemove);
//                 if (!projectIdIsPresent)
//                 {
//                     System.Console.WriteLine("Entered Project id is not present");
//                     continue;
//                 }

//                 break;
//             }

//             return (employeeIdToRemove,projectIdToRemove);
//         }

//     }
// }

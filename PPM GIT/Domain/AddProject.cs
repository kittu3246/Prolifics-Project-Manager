// using Properties;
// using ConsoleTables;
// using System.Collections.Generic;


// namespace AddProject
// {
//     public class ProjectMethods
//     {
//         public static List<ProjectProperties> list = new List<ProjectProperties>();

//         public static void AddProject(ProjectProperties ProjectPropertiesObj)
//         {
//             list.Add(ProjectPropertiesObj);
//         }

//         public static ConsoleTable ViewProject()
//         {
//             Console.ForegroundColor = ConsoleColor.Yellow;
//             var table = new ConsoleTable("ProjectId", "ProjectName", "Start Date", "End Date");

//             foreach (ProjectProperties objlist in list)
//             {
//                 string formattedStartDate = objlist.StartDate.ToString("MM-dd-yyyy");
//                 string formattedEndDate = objlist.EndDate.ToString("MM-dd-yyyy");

//                 table.AddRow(objlist.Id, objlist.Name, formattedStartDate, formattedEndDate);
//             }
//             return table;
//         }
//     }
// }

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ProjectModel;
using Roles;
using AddEmployeeToProjectProps;
using Employee_Details;
using Project;
using Role;
using AddEmployeToProject;
using Employee;

namespace SavePoint
{
    public class AppDataSerializer
    {
        public static void SerializeData(
            List<ProjectProperties> projects,
            List<EmployeeDetailsProps> employees,
            List<RolesProperties> roles,
            List<AddEmployeeToProjectProperties> employeeProjects,
            string projectData,
            string employeeData,
            string roleData,
            string employeeProjectData
        )
        {
            try
            {
                using (var writer = new StreamWriter(projectData))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<ProjectProperties>));
                    serializer.Serialize(writer, projects);
                }

                using (
                    StreamWriter writer = new StreamWriter(
                        "C:\\Users\\SPotharaju\\Desktop\\ProlificsProjectManager\\solutions\\PPM.Domain\\projectdata.txt"
                    )
                )
                {
                    foreach (var data in projects)
                    {
                        writer.WriteLine(data);
                    }
                }

                using (var writer = new StreamWriter(employeeData))
                {
                    XmlSerializer serializer = new XmlSerializer(
                        typeof(List<EmployeeDetailsProps>)
                    );
                    serializer.Serialize(writer, employees);
                }

                using (var writer = new StreamWriter(roleData))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<RolesProperties>));
                    serializer.Serialize(writer, roles);
                }

                using (var writer = new StreamWriter(employeeProjectData))
                {
                    XmlSerializer serializer = new XmlSerializer(
                        typeof(List<AddEmployeeToProjectProperties>)
                    );
                    System.Console.WriteLine($" --------> {employeeProjects.Count}");
                    serializer.Serialize(writer, employeeProjects);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while serializing data: " + ex.Message);
            }
        }

        public void SaveAppData()
        {
            string projectPath =
                "C:\\Users\\SPotharaju\\Desktop\\ProlificsProjectManager\\solutions\\.vscode\\SerializeData\\SerializeProjectMethodsData.xml";
            string employeePath =
                "C:\\Users\\SPotharaju\\Desktop\\ProlificsProjectManager\\solutions\\.vscode\\SerializeData\\SerializeEmployeMethodsData.xml";
            string rolePath =
                "C:\\Users\\SPotharaju\\Desktop\\ProlificsProjectManager\\solutions\\.vscode\\SerializeData\\SerializeRoleMethodsData.xml";
            string employeeProjectPath =
                "C:\\Users\\SPotharaju\\Desktop\\ProlificsProjectManager\\solutions\\.vscode\\SerializeData\\SerializeAddEmployeToProject.XML";

            AppDataSerializer.SerializeData(
                ProjectMethods.list,
                EmployeeMethods.list,
                RolesMethods.rolesList,
                ProjectMethods.list,
                projectPath,
                employeePath,
                rolePath,
                employeeProjectPath
            );

            Console.WriteLine("Application data saved successfully.");
        }
    }
}

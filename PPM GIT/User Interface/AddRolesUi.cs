using ProjectModel;
using System;
using Roles;
using Role;

namespace AddRoles
{
    public class AddRolesUI
    {
        static RolesMethods rolesMethods = new RolesMethods();

        /// Prompts the user to enter a role ID and role name, performs the operation to add the roles, and returns true if the operation was successful.

        /// <returns>True if the operation was successful, otherwise false.</returns>
        public static bool AddRolesUi()
        {
            Console.WriteLine("Enter the Role Id");
            int roleId;
            while (!int.TryParse(Console.ReadLine(), out roleId))
            {
                Console.WriteLine("Invalid Role Id. Please enter a valid integer value.");
            }

            Console.WriteLine("Enter the Role Name");
            string roleName = Console.ReadLine();

            // Perform the operation to add roles

            if (!rolesMethods.CheckRollIdExists(roleId))
            {
                RolesProperties roleObj = new RolesProperties
                {
                    RollId = roleId,
                    RollName = roleName
                };

                rolesMethods.Add(roleObj);
                return true;
            }
            else
            {
                Console.WriteLine("Failed to add role.");
            }

            return false;

            // Return true if the operation was successful
        }
    }
}

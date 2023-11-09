
using ConsoleTables;
using Roles;

using IEntityOperation;

namespace Role
{
    public class RolesMethods : IEntity<RolesProperties>
    {
        public static List<RolesProperties> rolesList = new List<RolesProperties>();


        /// Adds a role to the list if the role ID doesn't already exist.

        /// <param name="roleObj">The role object to add</param>
        public void Add(RolesProperties roleObj)
        {



            rolesList.Add(roleObj);





            // return true;

        }

        /// Checks if a role ID already exists in the list.

        /// <param name="roleObj">The role object to check</param>
        /// <returns>True if the role ID exists, false otherwise</returns>
        public bool CheckRollId(RolesProperties roleObj)
        {
            return rolesList.Any(a => a.RollId == roleObj.RollId);
        }


        /// Displays a table of all roles in the list.

        public ConsoleTable ListAll()
        {
            var table = new ConsoleTable("RollId", "RollName");

            if (!rolesList.Any())
            {

                return null;
            }
            else
            {
                foreach (RolesProperties role in rolesList)
                {

                    table.AddRow(role.RollId, role.RollName);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine(table);
                return table;

            }

        }


        /// Returns a role object with the specified ID.

        /// <param name="rollId">The ID of the role to retrieve</param>
        /// returns The role object with the specified ID, or null if not found</returns>
        public ConsoleTable ListById(int rollId)
        {
            var idObj = rolesList.FirstOrDefault(role => role.RollId == rollId);
            var table = new ConsoleTable("RoleId", "RoleName");
            table.AddRow(idObj.RollId);
            table.AddRow(idObj.RollName);
            return table;
        }


        /// Deletes a role with the specified ID from the list.

        /// <param name="deleteByRollId">The ID of the role to delete</param>
        /// <returns>True if the role was deleted, false otherwise</returns>
        public bool DeleteById(int deleteByRollId)
        {
            RolesProperties roleToDelete = rolesList.FirstOrDefault(role => role.RollId == deleteByRollId);
            if (roleToDelete != null)
            {
                rolesList.Remove(roleToDelete);
                return true;
            }
            return false;
        }


        public bool CheckRollIdExists(int rollId)
        {

            return rolesList.Any(role => role.RollId == rollId);
        }
        public bool CheckRolesExists()
        {
            if (rolesList.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}

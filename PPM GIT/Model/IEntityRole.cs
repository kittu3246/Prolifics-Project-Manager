using ConsoleTables;
using Roles;
namespace IEntityRoleOperation
{
    public interface IEntityRole
    {
         bool AddRoles(int roleId, string roleName);
         bool CheckRollId(RolesProperties roleObj);
         ConsoleTable ViewRoles();
         RolesProperties ViewRolesById(int rollId);
         bool DeleteByRollId(int deleteByRollId);
         bool CheckRollIdExists(int rollId);
    }
}
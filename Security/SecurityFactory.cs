using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    /// <summary>
    ///A static class exposing all the methods required to work with the security module
    /// </summary>
    /// 
    public static class SecurityFactory
    {
        /// <summary>
        /// Load all users from the database
        /// </summary>
        /// <returns></returns>
        public static Users GetUsers()
        {
            try
            {
                Users users = new Users();
                users.Load();
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static Users GetwebUsers()
        {
            try
            {
                Users users = new Users();
                users.Loadweb();
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Login the user and return a ticket if the credentials are valid.
        /// Otherwise returns null.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(string username, string password)
        {
            try
            {
                User user = new User()
                {
                    Password = password,
                    UserName = username
                };

                user.Load();

                if (user != null && user.Active)
                {

                    Ticket.Instance.User = user;
                    Ticket.Instance.LastActivityTime = DateTime.Now;

                    AuditTrailManager.Instance.Add("LOGIN", "User", user.UserID.ToString(), user.UserName, 0);

                    return true;
                }
                else
                {
                    AuditTrailManager.Instance.Add("LOGIN FAILURE", "User", user.UserID.ToString(), user.UserName, 0);
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates a user in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="active">Whether the user is enabled or disabled</param>
        /// <returns>The user object that was created</returns>
        public static User CreateUser(string username, string password, bool active, int? staffID)
        {
            try
            {
                if (username.Length * password.Length == 0)
                    return null;

                User user = new User()
                {
                    Active = active,
                    Password = password,
                    UserName = username,
                    StaffID = staffID
                };

                user.Save();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Change the password of the user whose user id is provided
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="newPassword"></param>
        public static void ChangeUserPassword(int userID, string newPassword)
        {
            try
            {
                User user = new User() { UserID = userID, Password = newPassword };
                user.ChangePassword();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Enable or Disable a user
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isActive"></param>
        public static void ChangeUserStatus(int userID, bool isActive)
        {
            try
            {
                User user = new User() { UserID = userID, Active = isActive };
                user.ChangeUserStatus();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates and saves a new role in the database
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public static Role CreateRole(string roleName, string description)
        {
            try
            {
                Role role = new Role() { RoleName = roleName, Description = description, IsSystemRole = false };
                role.Save();
                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Load all the roles from the database
        /// </summary>
        /// <returns></returns>
        public static Roles GetRoles(bool all = true)
        {
            try
            {
                Roles roles = new Roles();
                roles.Load(all);
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Update role information in the database
        /// </summary>
        /// <param name="role"></param>
        public static void UpdateRole(Role role)
        {
            try
            {
                role.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Load all the securables from the database
        /// </summary>
        /// <returns></returns>
        public static Securables GetSecurables()
        {
            try
            {
                Securables secs = new Securables();
                secs.Load();
                return secs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates the permissions for a role
        /// </summary>
        /// <param name="rolePermissions"></param>
        public static void UpdatePermissions(RolePermissions rolePermissions)
        {
            try
            {
                rolePermissions.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Finds users matching a username or part of a username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Users SearchUsers(string username)
        {
            try
            {
                Users users = new Users();
                users.Search(username);
                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Saves the members (users) of a role to the database
        /// </summary>
        /// <param name="role"></param>
        /// <param name="members"></param>
        public static void CreateRoleMembers(Role role, Users members)
        {
            try
            {
                if (members.Count > 0)
                {
                    foreach (User user in members)
                    {
                        RolesUser mem = new RolesUser() { RoleID = role.RoleID, UserID = user.UserID };
                        mem.Save();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates the member information of a role
        /// </summary>
        /// <param name="role"></param>
        /// <param name="members"></param>
        public static void UpdateRoleMembers(Role role, Users members)
        {
            try
            {
                role.DeleteMembers();

                if (members.Count > 0)
                {
                    foreach (User user in members)
                    {
                        RolesUser mem = new RolesUser() { RoleID = role.RoleID, UserID = user.UserID };
                        mem.Save();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Removes a user from the database
        /// </summary>
        /// <param name="user"></param>
        public static void DeleteUser(User user)
        {
            try
            {
                user.Delete();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Gets the list of all audit actions that have been performed in the system
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAuditActions()
        {
            try
            {
                List<string> actions = AuditTrailManager.Instance.GetAuditActions();

                return actions;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Gets the list of all securables that have been acted on in the system
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAuditObjects()
        {
            try
            {
                List<string> objects = AuditTrailManager.Instance.GetAuditObjects();

                return objects;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Gets the list of all users who have performed actions in the system
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAuditUsers()
        {
            try
            {
                List<string> users = AuditTrailManager.Instance.GetAuditUsers();

                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static RolesUsers GetUserRoles(int userId)
        {
            try
            {
                RolesUsers ru = new RolesUsers();
                ru.LoadForUser(userId);

                return ru;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeleteUserRoles(int userId, List<int> removedRoles)
        {
            try
            {
                foreach (byte id in removedRoles)
                {
                    RolesUser ru = new RolesUser();
                    ru.Delete(id, userId);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SaveUserRoles(List<int> addedRoles, int userId)
        {
            try
            {
                foreach (byte id in addedRoles)
                {
                    RolesUser ru = new RolesUser() { RoleID = id, UserID = userId };
                    ru.Save();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int GetRoleID(string name)
        {
            Roles roles = GetRoles();

            Role role = roles.FirstOrDefault(r => r.RoleName == name);
            return role.RoleID;
        }

        public static string GetRoleName(int id)
        {
            Roles roles = GetRoles();

            Role role = roles.FirstOrDefault(r => r.RoleID == id);
            return role.RoleName;
        }
    }
}

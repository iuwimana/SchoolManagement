using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public static class Guard
    {
        /// <summary>
        /// All possible actions that can be performed on a securable
        /// </summary>
        public enum Actions
        {
            CanAccess = 1,
            CanCreate = 2,
            CanView = 3,
            CanModify = 4,
            CanDelete = 5,
            CanExecute = 6,
        }
        /// <summary>
        /// Checks the current users ability to perform a specific action against a securable
        /// </summary>
        /// <param name="securable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool CheckPermissions(string securable, Actions action)
        {

            RolePermissions permissions = Ticket.Instance.User.Permissions;

            bool isAdmin = Ticket.Instance.User.IsSystemUser;

            RolePermission permission = permissions.FirstOrDefault(p => p.SecurableName == securable);

            if (permission != null)
            {
                switch (action)
                {
                    case Actions.CanAccess:
                        return permission.CanAccess || isAdmin;
                    case Actions.CanCreate:
                        return permission.CanCreate || isAdmin;
                    case Actions.CanDelete:
                        return permission.CanDelete || isAdmin;
                    case Actions.CanExecute:
                        return permission.CanExecute || isAdmin;
                    case Actions.CanModify:
                        return permission.CanModify || isAdmin;
                    case Actions.CanView:
                        return permission.CanView || isAdmin;
                    default:
                        return false || isAdmin;
                }
            }
            else
                return false || isAdmin;


        }
    }
}

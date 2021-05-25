using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp;
using System.Data.SqlClient;
using System.Collections;

namespace Security
{
    /// <summary>
    /// Represents a system user
    /// </summary>
    public class User
    {
        #region "Public properties"
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int? StaffID { get; set; }
        public string RoleList { get; set; }

        public RolePermissions Permissions { get; set; }
        public RolesUsers Roles { get; set; }

        /// <summary>
        /// Checks whether this is a system defined user
        /// </summary>
        public bool IsSystemUser
        {
            get
            {
                if (UserName == "admin")
                    return true;
                else
                    return false;
            }

        }

        #endregion

        public User()
        {
            Permissions = new RolePermissions();
            Roles = new RolesUsers();
        }

        #region "Data Access"


        /// <summary>
        /// Saves a new user to the database
        /// </summary>
        internal void Save()
        {

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@UserID", UserID);
                parameters.Add("@UserName", UserName);
                parameters.Add("@Password", Password);
                parameters.Add("@Active", Active);
                parameters.Add("@StaffID", StaffID);

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("InsertWinClientUsers", parameters);

                while (dr.Read())
                {
                    UserID = Convert.ToInt32(dr["NewID"]);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        internal void Delete()
        {

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@ID", UserID);
                DBAccess.MISDB.ExecuteNonQuery("DeleteUser", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void ChangePassword()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@UserID", UserID);
                parameters.Add("@Password", Password);

                DBAccess.MISDB.ExecuteNonQuery("ChangePassword", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void ChangeUserStatus()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@UserID", UserID);
                parameters.Add("@Active", Active);

                DBAccess.MISDB.ExecuteNonQuery("ChangeWinClientUserStatus", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        internal void Load()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@UserName", UserName);
                parameters.Add("@Password", Password);
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetWinClientUser", parameters);

                while (dr.Read())
                {
                    UserID = Convert.ToInt32(dr.GetValue(0));
                    UserName = Convert.ToString(dr.GetValue(1));
                    Active = Convert.ToBoolean(dr.GetValue(2));
                    StaffID = DBUtility.SafeGet<int>(dr, "StaffID");

                    Permissions.Load(UserID);
                    Roles.LoadForUser(UserID);
                }
                dr.Close();

            }
            catch (Exception)
            {
                throw;

            }
        }

        public bool IsInRole(string roleName)
        {
            if (roleName == null)
                return false || IsSystemUser;

            RolesUser role = Roles.FirstOrDefault(ru => ru.RoleName.ToLower() == roleName.ToLower());

            if (role == null)
                return false || IsSystemUser;
            else
                return true;
        }
    }
    public class Users : ICollection<User>
    {
        private List<User> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetWinClientUsers");

                User user;

                while (dr.Read())
                {
                    user = new User();
                    user.UserID = Convert.ToInt32(dr["UserID"]);
                    user.UserName = Convert.ToString(dr["UserName"]);
                    user.Active = Convert.ToBoolean(dr["Active"]);
                    user.RoleList = DBUtility.SafeGet<string>(dr, "RoleList");

                    Add(user);

                }
                dr.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void Search(string username)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("SearchUsers", "username", username);

                User user;

                while (dr.Read())
                {
                    user = new User();
                    user.UserID = Convert.ToInt32(dr["UserID"]);
                    user.UserName = Convert.ToString(dr["UserName"]);
                    user.Active = Convert.ToBoolean(dr["Active"]);
                    Add(user);

                }
                dr.Close();

            }
            catch (Exception)
            {
                throw;

            }
        }

        internal void LoadForRole(int roleID)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetUsersForRole", "roleID", roleID);

                User user;

                while (dr.Read())
                {
                    user = new User();
                    user.UserID = Convert.ToInt32(dr["UserID"]);
                    user.UserName = Convert.ToString(dr["UserName"]);
                    user.Active = Convert.ToBoolean(dr["Active"]);
                    Add(user);

                }
                dr.Close();

            }
            catch (Exception)
            {
                throw;

            }
        }

        public void CopyTo(System.Array array, int index)
        {
            //CopyTo(array, index);

        }

        public int Count
        {
            get
            {

                return mCol.Count;

            }

        }

        public IEnumerator<User> GetEnumerator()
        {
            return mCol.GetEnumerator();

        }

        public bool IsSynchronized
        {
            get
            {

                return true;

            }

        }

        public object SyncRoot
        {
            get
            {

                return mCol;

            }

        }

        public void Add(User user)
        {
            if (user != null)
                mCol.Add(user);

        }

        public Users()
        {
            mCol = new List<User>();

        }

        public bool Contains(User user)
        {
            return mCol.Contains(user);
        }
        public void Clear()
        {
            mCol.Clear();
        }

        public void CopyTo(User[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(User item)
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Represents a role within the system. Roles are containers for users and are used to manage permissions
    /// </summary>
    public class Role
    {

        #region "public Properties"

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsSystemRole { get; set; }
        public Users Members { get; set; }
        public RolePermissions Permissions { get; set; }

        #endregion

        public Role()
        {

        }
        public Role(int id, string name)
        {
            RoleID = id;
            RoleName = name;
        }

        #region "Data Access"

        public override string ToString()
        {
            return RoleName;
        }

        internal void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@RoleID", RoleID);
                parameters.Add("@RoleName", RoleName);
                parameters.Add("@Description", Description);
                parameters.Add("@IsSystemRole", IsSystemRole);

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("InsertRoles", parameters);

                int roleID = RoleID;

                while (dr.Read())
                {
                    RoleID = Convert.ToInt32(dr.GetValue(0));
                }

                //If this is a new role
                //Create default permissions for this role for all securables
                if (roleID == 0)
                {
                    CreateDefaultPermissions();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateDefaultPermissions()
        {
            Securables secs = SecurityFactory.GetSecurables();

            foreach (Securable sec in secs)
            {
                RolePermission perm = new RolePermission();

                perm.SecurableID = sec.SecurableID;
                perm.RoleID = RoleID;
                perm.CanAccess = perm.CanCreate = perm.CanDelete = perm.CanExecute = perm.CanModify = perm.CanView = false;
                perm.Save();
            }
        }

        public void Delete()
        {

            try
            {
                DBAccess.MISDB.ExecuteNonQuery("DeleteRole", "ID", RoleID);

            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        internal void LoadForUser(int userid)
        {
            try
            {

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRoleForUser", "userid", userid);

                while (dr.Read())
                {

                    RoleID = Convert.ToInt32(dr.GetValue(0));
                    RoleName = Convert.ToString(dr.GetValue(1));

                }
                dr.Close();


            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetPermissions()
        {
            Permissions = new RolePermissions();
            Permissions.LoadForRole(RoleID);
        }

        public void GetMembers()
        {
            Members = new Users();
            Members.LoadForRole(RoleID);
        }

        internal void DeleteMembers()
        {
            foreach (User mem in Members)
            {
                RolesUser ru = new RolesUser();
                ru.Delete(RoleID, mem.UserID);
            }
        }
    }
    public class Roles : ICollection<Role>
    {
        private List<Role> mCol;



        public void Load(bool all)
        {
            try
            {
                SqlDataReader dr;

                if (all)
                    dr = DBAccess.MISDB.ExecuteReader("GetRoles");
                else
                    dr = DBAccess.MISDB.ExecuteReader("GetNonSystemRoles");

                LoadFromDataReader(dr);
                dr.Close();

            }
            catch (Exception)
            {
                throw;

            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Role role;

            while (dr.Read())
            {
                role = new Role();

                role.RoleID = Convert.ToInt32(dr.GetValue(0));
                role.RoleName = Convert.ToString(dr.GetValue(1));
                role.Description = Convert.ToString(dr.GetValue(2));
                role.IsSystemRole = Convert.ToBoolean(dr.GetValue(3));

                Add(role);

            }
        }


        public int Count
        {
            get
            {

                return mCol.Count;

            }

        }

        public IEnumerator<Role> GetEnumerator()
        {
            return mCol.GetEnumerator();

        }


        public bool IsSynchronized
        {
            get
            {

                return true;

            }

        }

        public object SyncRoot
        {
            get
            {

                return mCol;

            }

        }

        public void Add(Role role)
        {
            if (role != null)
                mCol.Add(role);

        }



        public Roles()
        {
            mCol = new List<Role>();

        }



        public bool Contains(Role role)
        {
            return mCol.Contains(role);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public void CopyTo(Role[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Role item)
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


    }

    public class RolesUser
    {
        #region "Private Variables"

        private int m_RoleUserID;
        private int m_RoleID;
        private int m_UserID;

        #endregion "Private Variables"

        #region "public Properties"

        public int RoleUserID
        {
            get
            {
                return m_RoleUserID;
            }
            set
            {
                m_RoleUserID = value;
            }
        }

        public int RoleID
        {
            get
            {
                return m_RoleID;
            }
            set
            {
                m_RoleID = value;
            }
        }

        public int UserID
        {
            get
            {
                return m_UserID;
            }
            set
            {
                m_UserID = value;
            }
        }

        #endregion "public Properties"

        #region "Data Access"

        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@RoleUserID", m_RoleUserID);
                parameters.Add("@RoleID", m_RoleID);
                parameters.Add("@UserID", m_UserID);

                DBAccess.MISDB.ExecuteNonQuery("InsertRolesUsers", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete()
        {
            try
            {
                DBAccess.MISDB.ExecuteNonQuery("DeleteRolesUsers", "ID", m_RoleUserID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void Delete(int roleID, int userID)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@roleID", roleID);
                parameters.Add("@userID", userID);

                DBAccess.MISDB.ExecuteNonQuery("DeleteRoleMembers", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion "Data Access"



        public string RoleName { get; set; }
    }
    public class RolesUsers : ICollection<RolesUser>
    {
        private List<RolesUser> mCol;

        internal void LoadForUser(int userId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRolesForUser", "UserID", userId);

                RolesUser rolesuser;

                while (dr.Read())
                {
                    rolesuser = new RolesUser();

                    rolesuser.RoleUserID = Convert.ToInt32(dr.GetValue(0));
                    rolesuser.RoleID = Convert.ToInt32(dr.GetValue(1));
                    rolesuser.UserID = Convert.ToInt32(dr.GetValue(2));
                    rolesuser.RoleName = DBUtility.SafeGet<string>(dr, "Rolename");
                    Add(rolesuser);
                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRolesUsers");

                RolesUser rolesuser;

                while (dr.Read())
                {
                    rolesuser = new RolesUser();

                    rolesuser.RoleUserID = Convert.ToInt32(dr.GetValue(0));
                    rolesuser.RoleID = Convert.ToInt32(dr.GetValue(1));
                    rolesuser.UserID = Convert.ToInt32(dr.GetValue(2));
                    Add(rolesuser);
                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CopyTo(System.Array array, int index)
        {
            //CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<RolesUser> GetEnumerator()
        {
            return mCol.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mCol.GetEnumerator();
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public object SyncRoot
        {
            get
            {
                return mCol;
            }
        }

        public void Add(RolesUser rolesuser)
        {
            if (rolesuser != null)
                mCol.Add(rolesuser);
        }

        public RolesUsers()
        {
            mCol = new List<RolesUser>();
        }

        public bool Contains(RolesUser rolesuser)
        {
            return mCol.Contains(rolesuser);
        }

        public void Clear()
        {
            mCol.Clear();
        }

        #region ICollection<RolesUser> Members

        public void CopyTo(RolesUser[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(RolesUser item)
        {
            throw new NotImplementedException();
        }

        #endregion ICollection<RolesUser> Members


    }

    public class Securable
    {

        #region "public Properties"

        public int SecurableID { get; set; }
        public string SecurableName { get; set; }
        public RolePermissions Permissions { get; set; }

        #endregion "public Properties"

        #region "Data Access"

        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@SecurableID", SecurableID);
                parameters.Add("@SecurableName", SecurableName);

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("InsertSecurables", parameters);

                int currentID = SecurableID;

                while (dr.Read())
                {
                    SecurableID = Convert.ToInt32(dr.GetValue(0));
                }

                //if this is a new securable, create default permissions for all roles in the system
                if (currentID == 0 || Permissions == null)
                {
                    Roles roles = SecurityFactory.GetRoles();

                    foreach (Role role in roles)
                    {
                        RolePermission perm = new RolePermission();
                        perm.RoleID = role.RoleID;
                        perm.SecurableID = SecurableID;

                        if (role.RoleName == "Administrators")
                        {
                            perm.CanAccess = true;
                            perm.CanCreate = true;
                            perm.CanDelete = true;
                            perm.CanExecute = true;
                            perm.CanModify = true;
                            perm.CanView = true;
                        }
                        else
                        {
                            perm.CanAccess = false;
                            perm.CanCreate = false;
                            perm.CanDelete = false;
                            perm.CanExecute = false;
                            perm.CanModify = false;
                            perm.CanView = false;
                        }
                        perm.Save();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete()
        {
            try
            {
                DBAccess.MISDB.ExecuteNonQuery("DeleteSecurables", "ID", SecurableID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Load(int securableID)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetSecurable", "ID", securableID);

                while (dr.Read())
                {
                    SecurableID = Convert.ToInt32(dr.GetValue(0));
                    SecurableName = Convert.ToString(dr.GetValue(1));
                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void LoadPermissions()
        {
            try
            {
                Permissions = new RolePermissions();

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRolePermissions", "SecurableID", SecurableID);

                RolePermission rolepermission;

                while (dr.Read())
                {
                    rolepermission = new RolePermission();

                    rolepermission.RolePermissionID = Convert.ToInt32(dr.GetValue(0));
                    rolepermission.RoleID = Convert.ToInt32(dr.GetValue(1));
                    rolepermission.SecurableID = Convert.ToInt32(dr.GetValue(2));
                    rolepermission.CanAccess = Convert.ToBoolean(dr.GetValue(3));
                    rolepermission.CanCreate = Convert.ToBoolean(dr.GetValue(4));
                    rolepermission.CanView = Convert.ToBoolean(dr.GetValue(5));
                    rolepermission.CanModify = Convert.ToBoolean(dr.GetValue(6));
                    rolepermission.CanDelete = Convert.ToBoolean(dr.GetValue(7));
                    rolepermission.CanExecute = Convert.ToBoolean(dr.GetValue(8));
                    rolepermission.RoleName = Convert.ToString(dr["RoleName"]);
                    Permissions.Add(rolepermission);

                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion "Data Access"
    }
    public class Securables : ICollection<Securable>
    {
        private List<Securable> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetSecurables");

                Securable securable;

                while (dr.Read())
                {
                    securable = new Securable();

                    securable.SecurableID = Convert.ToInt32(dr.GetValue(0));
                    securable.SecurableName = Convert.ToString(dr.GetValue(1));
                    securable.LoadPermissions();

                    Add(securable);
                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CopyTo(System.Array array, int index)
        {
            //CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Securable> GetEnumerator()
        {
            return mCol.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mCol.GetEnumerator();
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public object SyncRoot
        {
            get
            {
                return mCol;
            }
        }

        public void Add(Securable securable)
        {
            if (securable != null)
                mCol.Add(securable);
        }

        public Securables()
        {
            mCol = new List<Securable>();
        }



        public bool Contains(Securable securable)
        {
            return mCol.Contains(securable);
        }

        public void Clear()
        {
            mCol.Clear();
        }

        #region ICollection<Securable> Members

        public void CopyTo(Securable[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Securable item)
        {
            throw new NotImplementedException();
        }

        #endregion ICollection<Securable> Members
    }
    public class RolePermission
    {

        #region "public Properties"

        public int RolePermissionID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int SecurableID { get; set; }
        public bool CanAccess { get; set; }
        public bool CanCreate { get; set; }
        public bool CanView { get; set; }
        public bool CanModify { get; set; }
        public bool CanDelete { get; set; }
        public bool CanExecute { get; set; }
        public string SecurableName { get; set; }
        #endregion

        #region "Data Access"
        public void Save()
        {

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@RolePermissionID", RolePermissionID);
                parameters.Add("@RoleID", RoleID);
                parameters.Add("@SecurableID", SecurableID);
                parameters.Add("@CanAccess", CanAccess);
                parameters.Add("@CanCreate", CanCreate);
                parameters.Add("@CanView", CanView);
                parameters.Add("@CanModify", CanModify);
                parameters.Add("@CanDelete", CanDelete);
                parameters.Add("@CanExecute", CanExecute);

                DBAccess.MISDB.ExecuteNonQuery("InsertRolePermissions", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }



        public void Delete()
        {

            try
            {
                DBAccess.MISDB.ExecuteNonQuery("DeleteRolePermissions", "ID", RolePermissionID);
            }
            catch (Exception)
            {
                throw;
            }
        }




        #endregion


    }
    public class RolePermissions : ICollection<RolePermission>
    {
        private List<RolePermission> mCol;

        internal void LoadForRole(int roleID)
        {
            try
            {

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetPermissionsForRole", "RoleID", roleID);

                RolePermission rolepermission;

                while (dr.Read())
                {
                    rolepermission = new RolePermission();

                    rolepermission.RolePermissionID = Convert.ToInt32(dr.GetValue(0));
                    rolepermission.RoleID = Convert.ToInt32(dr.GetValue(1));
                    rolepermission.SecurableID = Convert.ToInt32(dr.GetValue(2));
                    rolepermission.CanAccess = Convert.ToBoolean(dr.GetValue(3));
                    rolepermission.CanCreate = Convert.ToBoolean(dr.GetValue(4));
                    rolepermission.CanView = Convert.ToBoolean(dr.GetValue(5));
                    rolepermission.CanModify = Convert.ToBoolean(dr.GetValue(6));
                    rolepermission.CanDelete = Convert.ToBoolean(dr.GetValue(7));
                    rolepermission.CanExecute = Convert.ToBoolean(dr.GetValue(8));
                    rolepermission.SecurableName = Convert.ToString(dr["SecurableName"]);
                    Add(rolepermission);

                }
                dr.Close();


            }
            catch (Exception)
            {
                throw;

            }
        }

        internal void Load(int userID)
        {
            try
            {

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetPermissionsForWinClientUser", "UserID", userID);

                RolePermission permission;

                while (dr.Read())
                {
                    permission = new RolePermission();
                    permission.SecurableName = Convert.ToString(dr["Securablename"]);
                    permission.CanAccess = Convert.ToBoolean(dr.GetValue(1));
                    permission.CanCreate = Convert.ToBoolean(dr.GetValue(2));
                    permission.CanView = Convert.ToBoolean(dr.GetValue(3));
                    permission.CanModify = Convert.ToBoolean(dr.GetValue(4));
                    permission.CanDelete = Convert.ToBoolean(dr.GetValue(5));
                    permission.CanExecute = Convert.ToBoolean(dr.GetValue(6));
                    Add(permission);

                }
                dr.Close();


            }
            catch (Exception)
            {
                throw;

            }
        }

        public void Load()
        {
            try
            {

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRolePermissions");

                RolePermission rolepermission;

                while (dr.Read())
                {
                    rolepermission = new RolePermission();

                    rolepermission.RolePermissionID = Convert.ToInt32(dr.GetValue(0));
                    rolepermission.RoleID = Convert.ToInt32(dr.GetValue(1));
                    rolepermission.SecurableID = Convert.ToInt32(dr.GetValue(2));
                    rolepermission.CanAccess = Convert.ToBoolean(dr.GetValue(3));
                    rolepermission.CanCreate = Convert.ToBoolean(dr.GetValue(4));
                    rolepermission.CanView = Convert.ToBoolean(dr.GetValue(5));
                    rolepermission.CanModify = Convert.ToBoolean(dr.GetValue(6));
                    rolepermission.CanDelete = Convert.ToBoolean(dr.GetValue(7));
                    rolepermission.CanExecute = Convert.ToBoolean(dr.GetValue(8));
                    rolepermission.RoleName = Convert.ToString(dr["RoleName"]);
                    Add(rolepermission);

                }
                dr.Close();


            }
            catch (Exception)
            {
                throw;

            }
        }
        public void CopyTo(System.Array array, int index)
        {
            //CopyTo(array, index);

        }

        public int Count
        {
            get
            {

                return mCol.Count;

            }

        }

        public IEnumerator<RolePermission> GetEnumerator()
        {
            return mCol.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mCol.GetEnumerator();
        }
        public bool IsSynchronized
        {
            get
            {

                return true;

            }

        }

        public object SyncRoot
        {
            get
            {

                return mCol;

            }

        }

        public void Add(RolePermission rolepermission)
        {
            if (rolepermission != null)
                mCol.Add(rolepermission);

        }



        public RolePermissions()
        {
            mCol = new List<RolePermission>();

        }


        public bool Contains(RolePermission rolepermission)
        {
            return mCol.Contains(rolepermission);
        }
        public void Clear()
        {
            mCol.Clear();
        }

        #region ICollection<RolePermission> Members


        public void CopyTo(RolePermission[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(RolePermission item)
        {
            throw new NotImplementedException();
        }

        #endregion

        internal void Save()
        {
            foreach (RolePermission perm in this)
            {
                perm.Save();
            }
        }


        public RolePermission Item(string p)
        {
            foreach (RolePermission perm in this)
            {
                if (perm.SecurableName == p)
                    return perm;
            }

            return null;
        }
    }

    public sealed class Ticket
    {
        public User User { get; set; }

        public DateTime LastActivityTime { get; set; }

        public static Ticket Instance
        {

            get { return Nested.Instance; }
        }

        private Ticket()
        {
        }



        private class Nested
        {

            static Nested()
            {
            }

            internal static readonly Ticket Instance = new Ticket();
        }


        public void Expire()
        {
            User = null;
            LastActivityTime = DateTime.Now;
        }
    }

}

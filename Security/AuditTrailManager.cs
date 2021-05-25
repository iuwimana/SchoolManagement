using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS;

namespace Security
{
    // Singleton class to making adding audit trail entries easier
    public class AuditTrailManager
    {
        // General singleton stuff
        #region Singleton Boilerplate

        private static readonly AuditTrailManager instance = new AuditTrailManager();

        private AuditTrailManager() { }

        public static AuditTrailManager Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Public Methods

        public long Add(string action, string target, string targetID, string remarks, long parentID)
        {

            AuditTrail entry = new AuditTrail()
            {
                Username = Ticket.Instance.User != null ? Ticket.Instance.User.UserName : "",
                Action = action,
                TargetObject = target,
                TargetObjectID = targetID,
                Workstation = System.Environment.MachineName,
                Remarks = remarks,
                ParentID = parentID
            };
            entry.Save();

            if (parentID == 0)
                currentParentID = entry.TrailID;
            else
            {
                childID = entry.TrailID;
                currentParentID = parentID;
            }

            return currentParentID;
        }

        public string GetAddSql(string action, string target, string targetID, string remarks, long parentID)
        {
            AuditTrail entry = new AuditTrail();
            entry.Username = Ticket.Instance.User.UserName;
            entry.Action = action;
            entry.TargetObject = target;
            entry.TargetObjectID = targetID;
            entry.Workstation = System.Environment.MachineName;
            entry.Remarks = remarks;
            entry.ParentID = parentID;

            string sql = entry.GetSaveSql();


            return sql;
        }

        private long currentParentID;
        public long CurrentParentID
        {
            get { return currentParentID; }
            set
            {
                currentParentID = value;
            }
        }

        private long childID;
        public long ChildID
        {
            get { return childID; }
            set
            {
                childID = value;
            }
        }

        #endregion

        internal List<string> GetAuditActions()
        {
            List<string> actions = new List<string>();

            SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetAuditTrailActions");

            while (dr.Read())
            {
                actions.Add(dr.GetString(0));
            }

            dr.Close();

            return actions;
        }

        internal List<string> GetAuditObjects()
        {
            List<string> objects = new List<string>();

            SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetAuditTrailObjects");

            while (dr.Read())
            {
                objects.Add(dr.GetString(0));
            }
            dr.Close();

            return objects;
        }

        internal List<string> GetAuditUsers()
        {
            List<string> users = new List<string>();

            SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetAuditTrailUsers");

            while (dr.Read())
            {
                users.Add(dr.GetString(0));
            }
            dr.Close();

            return users;
        }
    }
}

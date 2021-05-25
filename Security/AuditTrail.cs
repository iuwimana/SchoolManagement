using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using MIS;


namespace Security
{
    public class AuditTrail
    {

        #region "public Properties"

        public long TrailID { get; set; }
        public string Username { get; set; }
        public DateTime ActionDate { get; set; }
        public string Action { get; set; }
        public string TargetObject { get; set; }
        public string TargetObjectID { get; set; }
        public string Workstation { get; set; }
        public string Remarks { get; set; }
        public long ParentID { get; set; }

        #endregion

        public override string ToString()
        {
            return Action + "; " + ActionDate.ToString() + "; " + Username + "; " + TargetObject + "; " + TargetObjectID;
        }

        #region "Data Access"
        public void Save()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@TrailID", TrailID);
            parameters.Add("@Username", Username);
            //Parameters.Add("@ActionDate", m_ActionDate);
            parameters.Add("@Action", Action);
            parameters.Add("@TargetObject", TargetObject);
            parameters.Add("@TargetObjectID", TargetObjectID);
            parameters.Add("@Workstation", Workstation);
            parameters.Add("@Remarks", Remarks);
            parameters.Add("@ParentID", ParentID);

            SqlDataReader dr = DBAccess.MISDB.ExecuteReader("InsertAuditTrail", parameters);

            while (dr.Read())
            {
                TrailID = Convert.ToInt64(dr.GetValue(0));
            }

            dr.Close();
        }

        public string GetSaveSql()
        {
            string sql = "INSERT INTO @TrailIDs EXEC InsertAuditTrail ";

            sql += "@TrailID = " + TrailID;
            sql += ", @Username = '" + EscapeForSql(Username) + "'";
            sql += ", @Action = '" + EscapeForSql(Action) + "'";
            sql += ", @TargetObject = '" + EscapeForSql(TargetObject) + "'";
            sql += ", @TargetObjectID = " + TargetObjectID;
            sql += ", @Workstation = '" + EscapeForSql(Workstation) + "'";
            sql += ", @Remarks = '" + EscapeForSql(Remarks) + "'";
            sql += ", @ParentID = " + ParentID;
            sql += ";\r\n";

            return sql;
        }

        private string EscapeForSql(string variable)
        {
            return variable.Replace("'", "''");
        }

        public void Delete()
        {

            DBAccess.MISDB.ExecuteNonQuery("DeleteAuditTrail", "ID", TrailID);

        }

        #endregion

        public ICollection GetChildren()
        {
            ArrayList children = new ArrayList();

            SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetAuditTrailChildren", "TrailID", TrailID);

            AuditTrail trail;

            while (dr.Read())
            {
                trail = new AuditTrail();

                trail.TrailID = Convert.ToInt64(dr.GetValue(0));
                trail.Username = Convert.ToString(dr.GetValue(1));
                trail.ActionDate = Convert.ToDateTime(dr.GetValue(2));
                trail.Action = Convert.ToString(dr.GetValue(3));
                trail.TargetObject = Convert.ToString(dr.GetValue(4));
                trail.TargetObjectID = Convert.ToString(dr.GetValue(5));
                trail.Workstation = Convert.ToString(dr.GetValue(6));
                trail.Remarks = Convert.ToString(dr.GetValue(7));

                children.Add(trail);

            }
            dr.Close();

            return children;
        }
    }
    public class AuditTrails : ICollection<AuditTrail>
    {
        private List<AuditTrail> mCol;

        public void Load()
        {

            SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetAuditTrail");

            AuditTrail audittrail;

            while (dr.Read())
            {
                audittrail = new AuditTrail();

                audittrail.TrailID = Convert.ToInt64(dr.GetValue(0));
                audittrail.Username = Convert.ToString(dr.GetValue(1));
                audittrail.ActionDate = Convert.ToDateTime(dr.GetValue(2));
                audittrail.Action = Convert.ToString(dr.GetValue(3));
                audittrail.TargetObject = Convert.ToString(dr.GetValue(4));
                audittrail.TargetObjectID = Convert.ToString(dr.GetValue(5));
                audittrail.Workstation = Convert.ToString(dr.GetValue(6));
                audittrail.Remarks = Convert.ToString(dr.GetValue(7));

                Add(audittrail);

            }
            dr.Close();

        }

        public void Load(DateTime startDate, DateTime endDate, string action, string username, string securable)
        {

            Dictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters.Add("@start", startDate);
            Parameters.Add("@end", endDate);

            switch (action)
            {
                case "Add":
                    action = "INSERT";
                    break;
                case "Modify":
                    action = "UPDATE";
                    break;
            }

            Parameters.Add("@action", action);
            Parameters.Add("@username", username);
            Parameters.Add("@securable", securable);

            SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetAuditTrailWithFilter", Parameters);

            AuditTrail audittrail;

            while (dr.Read())
            {
                audittrail = new AuditTrail();
                audittrail.TrailID = Convert.ToInt64(dr.GetValue(0));
                audittrail.Username = Convert.ToString(dr.GetValue(1));
                audittrail.ActionDate = Convert.ToDateTime(dr.GetValue(2));
                audittrail.Action = Convert.ToString(dr.GetValue(3));
                audittrail.TargetObject = Convert.ToString(dr.GetValue(4));
                audittrail.TargetObjectID = Convert.ToString(dr.GetValue(5));
                audittrail.Workstation = Convert.ToString(dr.GetValue(6));
                audittrail.Remarks = Convert.ToString(dr.GetValue(7));
                audittrail.ParentID = Convert.ToInt64(dr["ParentID"]);
                Add(audittrail);

            }
            dr.Close();

        }
        public int Count
        {
            get
            {

                return mCol.Count;

            }

        }

        public IEnumerator<AuditTrail> GetEnumerator()
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

        public void Add(AuditTrail audittrail)
        {
            if (audittrail != null)
                mCol.Add(audittrail);

        }


        public AuditTrails()
        {
            mCol = new List<AuditTrail>();

        }



        public bool Contains(AuditTrail audittrail)
        {
            return mCol.Contains(audittrail);
        }
        public void Clear()
        {
            mCol.Clear();
        }

        #region ICollection<AuditTrail> Members

        public void CopyTo(AuditTrail[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(AuditTrail item)
        {
            return mCol.Remove(item);
        }

        #endregion

        public AuditTrail Item(long id)
        {
            return this.FirstOrDefault(a => a.TrailID == id);
        }
    }

}

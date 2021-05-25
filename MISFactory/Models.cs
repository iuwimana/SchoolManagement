
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MIS
{
    #region MIS

    public class Continent
    {
        #region "public Properties"

        public int ContinentID { get; set; }
        public string ContinentName { get; set; }
        public string Code { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@ContinentID", ContinentID);
                parameters.Add("@ContinentName", ContinentName);
                parameters.Add("@Code", Code);
                DBAccess.MISDB.ExecuteNonQuery("InsertContinent", parameters);
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
                DBAccess.MISDB.ExecuteNonQuery("DeleteContinent", "ContinentID", ContinentID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public void Load(int continentid)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetContinent", "ContinentID", continentid);

                while (dr.Read())
                {
                    ContinentID = DBUtility.SafeGet<int>(dr, "ContinentID");
                    ContinentName = DBUtility.SafeGet<string>(dr, "ContinentName");
                    Code = DBUtility.SafeGet<string>(dr, "Code");
                }

                dr.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class Continents : ICollection<Continent>
    {
        private List<Continent> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetContinents");
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoadFromDataReader(SqlDataReader dr)
        {
            Continent continent;

            while (dr.Read())
            {
                continent = new Continent();

                continent.ContinentID = Convert.ToInt32(dr["ContinentID"]);
                continent.ContinentName = DBUtility.SafeGet<string>(dr, "ContinentName");
                continent.Code = DBUtility.SafeGet<string>(dr, "Code");

                Add(continent);
            }
            dr.Close();
        }

        public void CopyTo(Continent[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Continent> GetEnumerator()
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

        public void Add(Continent continent)
        {
            if (continent != null)
                mCol.Add(continent);
        }

        public bool Remove(Continent continent)
        {
            return mCol.Remove(continent);
        }
        public Continents()
        {
            mCol = new List<Continent>();
        }
        public bool Contains(Continent continent)
        {
            return mCol.Contains(continent);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Country
    {
        #region "public Properties"

        public int CountryID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int ContinentID { get; set; }
        public string ContinentName { get; set; }
        public string ISOAlpha2 { get; set; }
        public string ISOAlpha3 { get; set; }
        public string ISONumeric { get; set; }
        public string ICAO { get; set; }
        public string PhoneCode { get; set; }
        public string Language { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@CountryID", CountryID);
                parameters.Add("@Name", Name);
                parameters.Add("@Nationality", Nationality);
                parameters.Add("@ContinentID", ContinentID);
                parameters.Add("@ISOAlpha2", ISOAlpha2);
                parameters.Add("@ISOAlpha3", ISOAlpha3);
                parameters.Add("@ISONumeric", ISONumeric);
                parameters.Add("@ICAO", ICAO);
                parameters.Add("@PhoneCode", PhoneCode);
                parameters.Add("@Language", Language);

                DBAccess.MISDB.ExecuteNonQuery("InsertCountry", parameters);
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
                DBAccess.MISDB.ExecuteNonQuery("DeleteCountry", "CountryID", CountryID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public void Load(int id)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCountry", "CountryID", id);
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Load(string isoAlpha2Code)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCountryByCode", "isoAlpha2Code", isoAlpha2Code);
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadByISO3(string isoAlpha3Code)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCountryByISO3Code", "@isoAlpha3Code", isoAlpha3Code);
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                CountryID = DBUtility.SafeGet<int>(dr, "CountryID");
                Name = DBUtility.SafeGet<string>(dr, "Name");
                Nationality = DBUtility.SafeGet<string>(dr, "Nationality");
                ContinentID = DBUtility.SafeGet<int>(dr, "ContinentID");
                ContinentName = DBUtility.SafeGet<string>(dr, "ContinentName");
                ISOAlpha2 = DBUtility.SafeGet<string>(dr, "ISOAlpha2");
                ISOAlpha3 = DBUtility.SafeGet<string>(dr, "ISOAlpha3");
                ISONumeric = DBUtility.SafeGet<string>(dr, "ISONumeric");
                ICAO = DBUtility.SafeGet<string>(dr, "ICAO");
                PhoneCode = DBUtility.SafeGet<string>(dr, "PhoneCode");
                Language = DBUtility.SafeGet<string>(dr, "Language");
            }

            dr.Close();
        }
    }
    public class Countries : ICollection<Country>
    {
        private List<Country> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCountries");
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadContinentCountries(int continentid)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetContinentCountries", "ContinentID", continentid);
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Country country;

            while (dr.Read())
            {
                country = new Country();

                country.CountryID = DBUtility.SafeGet<int>(dr, "CountryID");
                country.Name = DBUtility.SafeGet<string>(dr, "Name");
                country.Nationality = DBUtility.SafeGet<string>(dr, "Nationality");
                country.ContinentID = DBUtility.SafeGet<int>(dr, "ContinentID");
                country.ContinentName = DBUtility.SafeGet<string>(dr, "ContinentName");
                country.ISOAlpha2 = DBUtility.SafeGet<string>(dr, "ISOAlpha2");
                country.ISOAlpha3 = DBUtility.SafeGet<string>(dr, "ISOAlpha3");
                country.ISONumeric = DBUtility.SafeGet<string>(dr, "ISONumeric");
                country.ICAO = DBUtility.SafeGet<string>(dr, "ICAO");
                country.PhoneCode = DBUtility.SafeGet<string>(dr, "PhoneCode");
                country.Language = DBUtility.SafeGet<string>(dr, "Language");

                Add(country);
            }
            dr.Close();
        }

        public void CopyTo(Country[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Country> GetEnumerator()
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

        public void Add(Country country)
        {
            if (country != null)
                mCol.Add(country);
        }

        public bool Remove(Country country)
        {
            return mCol.Remove(country);
        }
        public Countries()
        {
            mCol = new List<Country>();
        }
        public bool Contains(Country country)
        {
            return mCol.Contains(country);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }




    /// <MaritalStatus>

    public class MaritalStatus
    {
        #region "public Properties"

        public int MaritalStatusID { get; set; }
        public string MaritalStatusName { get; set; }
        public string Code { get; set; }


        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@MaritalStatusID", MaritalStatusID);
                parameters.Add("@MaritalStatusName", MaritalStatusName);
                parameters.Add("@Code", Code);


                DBAccess.MISDB.ExecuteNonQuery("InsertMaritalStatus", parameters);
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
                DBAccess.MISDB.ExecuteNonQuery("DeleteCountry", "MaritalStatusID", MaritalStatusID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion





    public class MaritalStatuses : ICollection<MaritalStatus>
    {
        private List<MaritalStatus> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetMaritalStatuses");
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void LoadFromDataReader(SqlDataReader dr)
        {
            MaritalStatus MaritalStatus;

            while (dr.Read())
            {
                MaritalStatus = new MaritalStatus();

                MaritalStatus.MaritalStatusID = DBUtility.SafeGet<int>(dr, "MaritalStatusID");
                MaritalStatus.MaritalStatusName = DBUtility.SafeGet<string>(dr, "MaritalStatusName");
                MaritalStatus.Code = DBUtility.SafeGet<string>(dr, "Code");


                Add(MaritalStatus);
            }
            dr.Close();
        }

        public void CopyTo(MaritalStatus[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<MaritalStatus> GetEnumerator()
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

        public void Add(MaritalStatus MaritalStatus)
        {
            if (MaritalStatus != null)
                mCol.Add(MaritalStatus);
        }

        public bool Remove(MaritalStatus MaritalStatus)
        {
            return mCol.Remove(MaritalStatus);
        }
        public MaritalStatuses()
        {
            mCol = new List<MaritalStatus>();
        }
        public bool Contains(MaritalStatus MaritalStatus)
        {
            return mCol.Contains(MaritalStatus);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }





    /// </workingArrear>
    /// 


    /// <MaritalStatus>

    public class WINUSERROLEARREAR
    {
        #region "public Properties"

        public int WINUSERROLEARREARID { get; set; }
        public int UserID { get; set; }
        public int ProvinceID { get; set; }
        public int DistrictID { get; set; }




        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@WINUSERROLEARREARID", WINUSERROLEARREARID);
                parameters.Add("@UserID", UserID);
                parameters.Add("@ProvinceID", ProvinceID);
                parameters.Add("@DistrictID", DistrictID);


                DBAccess.MISDB.ExecuteNonQuery("InsertWINUSERROLEARREAR", parameters);
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
                DBAccess.MISDB.ExecuteNonQuery("DeleteWINUSERROLEARREAR", "WINUSERROLEARREARID", WINUSERROLEARREARID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion





    public class WINUSERROLEARREARs : ICollection<WINUSERROLEARREAR>
    {
        private List<WINUSERROLEARREAR> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetWINUSERROLEARREARS");
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void LoadFromDataReader(SqlDataReader dr)
        {
            WINUSERROLEARREAR WINUSERROLEARREAR;

            while (dr.Read())
            {
                WINUSERROLEARREAR = new WINUSERROLEARREAR();

                WINUSERROLEARREAR.WINUSERROLEARREARID = DBUtility.SafeGet<int>(dr, "WINUSERROLEARREARID");
                WINUSERROLEARREAR.UserID = DBUtility.SafeGet<int>(dr, "UserID");
                WINUSERROLEARREAR.ProvinceID = DBUtility.SafeGet<int>(dr, "ProvinceID");
                WINUSERROLEARREAR.DistrictID = DBUtility.SafeGet<int>(dr, "DistrictID");



                Add(WINUSERROLEARREAR);
            }
            dr.Close();
        }

        public void CopyTo(WINUSERROLEARREAR[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<WINUSERROLEARREAR> GetEnumerator()
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

        public void Add(WINUSERROLEARREAR WINUSERROLEARREAR)
        {
            if (WINUSERROLEARREAR != null)
                mCol.Add(WINUSERROLEARREAR);
        }

        public bool Remove(WINUSERROLEARREAR WINUSERROLEARREAR)
        {
            return mCol.Remove(WINUSERROLEARREAR);
        }
        public WINUSERROLEARREARs()
        {
            mCol = new List<WINUSERROLEARREAR>();
        }
        public bool Contains(WINUSERROLEARREAR WINUSERROLEARREAR)
        {
            return mCol.Contains(WINUSERROLEARREAR);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }





    /// </workingArrear>








    /// <WebUserRole>

    public class RNMUMemberRole
    {
        #region "public Properties"

        public int RNMUMemberRoleId { get; set; }
        public string RNMUMemberRoleName { get; set; }
        public int rnmumemberuserid { get; set; }
        public int userId { get; set; }
        public int RNMUMemberRoleid { get; set; }
        public int RNMUMEMBERUSERARREARID { get; set; }
        public int ProvinceID { get; set; }
        public int DistrictID { get; set; }



        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@rnmumemberuserid", rnmumemberuserid);
                parameters.Add("@userId", userId);
                parameters.Add("@RNMUMemberRoleid", RNMUMemberRoleid);



                DBAccess.MISDB.ExecuteNonQuery("InsertRNMUMEMBERUSER", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveMEMBERUSER()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@RNMUMEMBERUSERARREARID", RNMUMEMBERUSERARREARID);
                parameters.Add("@userId", userId);
                parameters.Add("@ProvinceID", ProvinceID);
                parameters.Add("@DistrictID", DistrictID);
               



                DBAccess.MISDB.ExecuteNonQuery("InsertRNMUMEMBERUSERArrer", parameters);
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
                DBAccess.MISDB.ExecuteNonQuery("DeleteRNMUMemberRole", "RNMUMemberRoleId", RNMUMemberRoleId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion





    public class RNMUMemberRoles : ICollection<RNMUMemberRole>
    {
        private List<RNMUMemberRole> mCol;

        public void LoadMemberRole()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRNMUMemberRole");
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadMemberRoleArrear()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetMemberRoleArrear");
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadMEMBERUSER()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRNMUMEMBERUSER");
                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void LoadFromDataReader(SqlDataReader dr)
        {
            RNMUMemberRole RNMUMemberRole;

            while (dr.Read())
            {
                RNMUMemberRole = new RNMUMemberRole();

                RNMUMemberRole.RNMUMemberRoleId = DBUtility.SafeGet<int>(dr, "RNMUMemberRoleId");
                RNMUMemberRole.RNMUMemberRoleName = DBUtility.SafeGet<string>(dr, "RNMUMemberRoleName");
                RNMUMemberRole.rnmumemberuserid = DBUtility.SafeGet<int>(dr, "rnmumemberuserid");
                RNMUMemberRole.userId = DBUtility.SafeGet<int>(dr, "userId");
                RNMUMemberRole.RNMUMemberRoleid = DBUtility.SafeGet<int>(dr, "RNMUMemberRoleid ");
                RNMUMemberRole.RNMUMEMBERUSERARREARID = DBUtility.SafeGet<int>(dr, "RNMUMEMBERUSERARREARID");
                RNMUMemberRole.ProvinceID = DBUtility.SafeGet<int>(dr, "ProvinceID");
                RNMUMemberRole.DistrictID = DBUtility.SafeGet<int>(dr, "DistrictID");


                Add(RNMUMemberRole);
            }
            dr.Close();
        }

        public void CopyTo(RNMUMemberRole[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<RNMUMemberRole> GetEnumerator()
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

        public void Add(RNMUMemberRole RNMUMemberRole)
        {
            if (RNMUMemberRole != null)
                mCol.Add(RNMUMemberRole);
        }

        public bool Remove(RNMUMemberRole RNMUMemberRole)
        {
            return mCol.Remove(RNMUMemberRole);
        }
        public RNMUMemberRoles()
        {
            mCol = new List<RNMUMemberRole>();
        }
        public bool Contains(RNMUMemberRole RNMUMemberRole)
        {
            return mCol.Contains(RNMUMemberRole);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }





    /// </WebUserRole>




    public class Department
    {
        #region "public Properties"

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int InstitutioncategoryId { get; set; }

        public string InstitutioncategoryName { get; set; }
        public int ProvinceID { get; set; }

        public string ProvinceName { get; set; }
        public int DistrictID { get; set; }

        public string DistrictName { get; set; }
        public int SectorID { get; set; }

        public string SectorName { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@DepartmentID", DepartmentID);
                parameters.Add("@DepartmentName", DepartmentName);
                parameters.Add("@InstitutioncategoryId", InstitutioncategoryId);
                parameters.Add("@DistrictID", DistrictID);


                DBAccess.MISDB.ExecuteNonQuery("InsertDepartment", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteDepartment", "DepartmentID", DepartmentID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int departmentID)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetDepartment", "DepartmentID", departmentID);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                DepartmentID = DBUtility.SafeGet<int>(dr, "DepartmentID");
                DepartmentName = DBUtility.SafeGet<string>(dr, "DepartmentName");
                InstitutioncategoryId = DBUtility.SafeGet<int>(dr, "InstitutioncategoryId");
                InstitutioncategoryName = DBUtility.SafeGet<string>(dr, "InstitutioncategoryName");
                ProvinceID = DBUtility.SafeGet<int>(dr, "ProvinceID");
                ProvinceName = DBUtility.SafeGet<string>(dr, "ProvinceName");
                DistrictID = DBUtility.SafeGet<int>(dr, "DistrictID");
                DistrictName = DBUtility.SafeGet<string>(dr, "DistrictName");
                SectorID = DBUtility.SafeGet<int>(dr, "SectorID");
                SectorName = DBUtility.SafeGet<string>(dr, "SectorName");
            }
            dr.Close();
        }
    }
    public class Departments : ICollection<Department>
    {
        private List<Department> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetDepartments");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Department dept;

            while (dr.Read())
            {
                dept = new Department();

                dept.DepartmentID = DBUtility.SafeGet<int>(dr, "DepartmentID");
                dept.DepartmentName = DBUtility.SafeGet<string>(dr, "DepartmentName");
                dept.InstitutioncategoryId = DBUtility.SafeGet<int>(dr, "InstitutioncategoryId");
                dept.InstitutioncategoryName = DBUtility.SafeGet<string>(dr, "InstitutioncategoryName");
                dept.ProvinceID = DBUtility.SafeGet<int>(dr, "ProvinceID");
                dept.ProvinceName = DBUtility.SafeGet<string>(dr, "ProvinceName");
                dept.DistrictID = DBUtility.SafeGet<int>(dr, "DistrictID");
                dept.DistrictName = DBUtility.SafeGet<string>(dr, "DistrictName");
                dept.SectorID = DBUtility.SafeGet<int>(dr, "SectorID");
                dept.SectorName = DBUtility.SafeGet<string>(dr, "SectorName");

                Add(dept);

            }
            dr.Close();
        }

        public void CopyTo(Department[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Department> GetEnumerator()
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

        public void Add(Department dept)
        {
            if (dept != null)
                mCol.Add(dept);
        }

        public bool Remove(Department dept)
        {
            return mCol.Remove(dept);
        }
        public Departments()
        {
            mCol = new List<Department>();
        }
        public bool Contains(Department dept)
        {
            return mCol.Contains(dept);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    public class school
    {
        #region "public Properties"

        public int EntityID { get; set; }
        public string EntityName { get; set; }
       public string Acronym { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ParentID { get; set; }

        public string TIN { get; set; }
        public int LogoID { get; set; }

        public string TopParentName { get; set; }
        

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
     
      
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@EntityID", EntityID);
                parameters.Add("@EntityName", EntityName);
                parameters.Add("@Acronym", Acronym);
                parameters.Add("@StartDate", StartDate);
                parameters.Add("@EndDate", EndDate);
                parameters.Add("@ParentID", ParentID);
                parameters.Add("@TIN", TIN);
                parameters.Add("@LogoID", LogoID);
                parameters.Add("@TopParentName", TopParentName);


                DBAccess.MISDB.ExecuteNonQuery("Insertscholl", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("Deleteschool", "EntityID", EntityID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int EntityID)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("Getschooll", "EntityID", EntityID);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                EntityID = DBUtility.SafeGet<int>(dr, "EntityID");
                EntityName = DBUtility.SafeGet<string>(dr, "EntityName");
                Acronym = DBUtility.SafeGet<string>(dr, "Acronym");
                StartDate = DBUtility.SafeGet<DateTime>(dr, "StartDate");
                EndDate = DBUtility.SafeGet<DateTime>(dr, "EndDate");
                ParentID = DBUtility.SafeGet<int>(dr, "ParentID");
                TIN = DBUtility.SafeGet<string>(dr, "TIN");
                LogoID = DBUtility.SafeGet<int>(dr, "LogoID");
                TopParentName = DBUtility.SafeGet<string>(dr, "TopParentName");
            }
            dr.Close();
        }
    }
    public class schools : ICollection<school>
    {
        private List<school> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("Getschools");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            school dept;

            while (dr.Read())
            {
                dept = new school();
                dept.EntityID = DBUtility.SafeGet<int>(dr, "EntityID");
                dept.EntityName = DBUtility.SafeGet<string>(dr, "EntityName");
                dept.Acronym = DBUtility.SafeGet<string>(dr, "Acronym");
                dept.StartDate = DBUtility.SafeGet<DateTime>(dr, "StartDate");
                dept.EndDate = DBUtility.SafeGet<DateTime>(dr, "EndDate");
                dept.ParentID = DBUtility.SafeGet<int>(dr, "ParentID");
                dept.TIN = DBUtility.SafeGet<string>(dr, "TIN");
                dept.LogoID = DBUtility.SafeGet<int>(dr, "LogoID");
                dept.TopParentName = DBUtility.SafeGet<string>(dr, "TopParentName");

                

                Add(dept);

            }
            dr.Close();
        }

        public void CopyTo(school[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<school> GetEnumerator()
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

        public void Add(school dept)
        {
            if (dept != null)
                mCol.Add(dept);
        }

        public bool Remove(school dept)
        {
            return mCol.Remove(dept);
        }
        public schools()
        {
            mCol = new List<school>();
        }
        public bool Contains(school dept)
        {
            return mCol.Contains(dept);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    public class institutioncategory
    {
        #region "public Properties"

        public int InstitutioncategoryId { get; set; }
        public string InstitutioncategoryName { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@InstitutioncategoryId", InstitutioncategoryId);
                parameters.Add("@InstitutioncategoryName", InstitutioncategoryName);

                DBAccess.MISDB.ExecuteNonQuery("InsertInstitutioncategory", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteInstitutioncategory", "InstitutioncategoryId", InstitutioncategoryId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int InstitutioncategoryId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetInstitutioncategory", "InstitutioncategoryId", InstitutioncategoryId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                InstitutioncategoryId = DBUtility.SafeGet<int>(dr, "InstitutioncategoryId");
                InstitutioncategoryName = DBUtility.SafeGet<string>(dr, "InstitutioncategoryName");
            }
            dr.Close();
        }
    }
    public class institutioncategories : ICollection<institutioncategory>
    {
        private List<institutioncategory> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("Getinstitutioncategories");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            institutioncategory institutioncategory;

            while (dr.Read())
            {
                institutioncategory = new institutioncategory();

                institutioncategory.InstitutioncategoryId = DBUtility.SafeGet<int>(dr, "InstitutioncategoryId");
                institutioncategory.InstitutioncategoryName = DBUtility.SafeGet<string>(dr, "InstitutioncategoryName");

                Add(institutioncategory);

            }
            dr.Close();
        }

        public void CopyTo(institutioncategory[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<institutioncategory> GetEnumerator()
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

        public void Add(institutioncategory institutioncategory)
        {
            if (institutioncategory != null)
                mCol.Add(institutioncategory);
        }

        public bool Remove(institutioncategory institutioncategory)
        {
            return mCol.Remove(institutioncategory);
        }
        public institutioncategories()
        {
            mCol = new List<institutioncategory>();
        }
        public bool Contains(institutioncategory institutioncategory)
        {
            return mCol.Contains(institutioncategory);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    public class Rank
    {
        #region "public Properties"

        public int RankID { get; set; }
        public string RankName { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@RankID", RankID);
                parameters.Add("@RankName", RankName);

                DBAccess.MISDB.ExecuteNonQuery("InsertRank", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteRank", "RankID", RankID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int rankId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRank", "RankID", rankId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                RankID = DBUtility.SafeGet<int>(dr, "RankID");
                RankName = DBUtility.SafeGet<string>(dr, "RankName");
            }
            dr.Close();
        }
    }
    public class Ranks : ICollection<Rank>
    {
        private List<Rank> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetRanks");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Rank rank;

            while (dr.Read())
            {
                rank = new Rank();

                rank.RankID = DBUtility.SafeGet<int>(dr, "RankID");
                rank.RankName = DBUtility.SafeGet<string>(dr, "RankName");

                Add(rank);

            }
            dr.Close();
        }

        public void CopyTo(Rank[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Rank> GetEnumerator()
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

        public void Add(Rank rank)
        {
            if (rank != null)
                mCol.Add(rank);
        }

        public bool Remove(Rank rank)
        {
            return mCol.Remove(rank);
        }
        public Ranks()
        {
            mCol = new List<Rank>();
        }
        public bool Contains(Rank rank)
        {
            return mCol.Contains(rank);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class StaffType
    {
        #region "public Properties"

        public int StaffTypeID { get; set; }
        public string StaffTypeName { get; set; }
        public int StaffTStatusID { get; set; }
        public string StaffStatusName { get; set; }
        public string TypeofContract { get; set; }
        public string DurationofContract { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@StaffTypeID", StaffTypeID);
                parameters.Add("@StaffTypeName", StaffTypeName);
                parameters.Add("@TypeofContract", TypeofContract);
                parameters.Add("@DurationofContract", DurationofContract);

                DBAccess.MISDB.ExecuteNonQuery("InsertStaffType", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Savestatus()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@StaffTStatusID", StaffTStatusID);
                parameters.Add("@StaffStatusName", StaffStatusName);

                DBAccess.MISDB.ExecuteNonQuery("InsertStaffStatus", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteStaffType", "StaffTypeID", StaffTypeID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Deletestatus()
        {
            try
            {
                DBAccess.MISDB.ExecuteNonQuery("DeleteStaffStatus", "StaffTypeID", StaffTStatusID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int staffTypeId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffType", "StaffTypeID", staffTypeId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                StaffTypeID = DBUtility.SafeGet<int>(dr, "StaffTypeID");
                StaffTypeName = DBUtility.SafeGet<string>(dr, "StaffTypeName");
                StaffTStatusID = DBUtility.SafeGet<int>(dr, "StaffTStatusID");
                StaffStatusName = DBUtility.SafeGet<string>(dr, "StaffStatusName");
                TypeofContract = DBUtility.SafeGet<string>(dr, "TypeofContract");
                DurationofContract = DBUtility.SafeGet<string>(dr, "DurationofContract");
            }
            dr.Close();
        }
    }
    public class StaffTypes : ICollection<StaffType>
    {
        private List<StaffType> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffTypes");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadStatus()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffstatus");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            StaffType staffType;

            while (dr.Read())
            {
                staffType = new StaffType();

                staffType.StaffTypeID = DBUtility.SafeGet<int>(dr, "StaffTypeID");
                staffType.StaffTypeName = DBUtility.SafeGet<string>(dr, "StaffTypeName");
                staffType.StaffTStatusID = DBUtility.SafeGet<int>(dr, "StaffTStatusID");
                staffType.StaffStatusName = DBUtility.SafeGet<string>(dr, "StaffStatusName");
                staffType.TypeofContract = DBUtility.SafeGet<string>(dr, "TypeofContract");
                staffType.DurationofContract = DBUtility.SafeGet<string>(dr, "DurationofContract");
                Add(staffType);

            }
            dr.Close();
        }

        public void CopyTo(StaffType[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<StaffType> GetEnumerator()
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

        public void Add(StaffType staffType)
        {
            if (staffType != null)
                mCol.Add(staffType);
        }

        public bool Remove(StaffType staffType)
        {
            return mCol.Remove(staffType);
        }
        public StaffTypes()
        {
            mCol = new List<StaffType>();
        }
        public bool Contains(StaffType staffType)
        {
            return mCol.Contains(staffType);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary> staffstatus

    public class Staffstatus
    {
        #region "public Properties"


        public int EmploymentStatusID { get; set; }
        public string EmploymentStatusName { get; set; }

        #endregion

        #region "Data Access"

        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@EmploymentStatusID", EmploymentStatusID);
                parameters.Add("@EmploymentStatusName", EmploymentStatusName);

                DBAccess.MISDB.ExecuteNonQuery("InsertStaffStatus", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteStaffStatus", "EmploymentStatusID", EmploymentStatusID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int staffstatusId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffstatus", "EmploymentStatusID", EmploymentStatusID);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {

                EmploymentStatusID = DBUtility.SafeGet<int>(dr, "EmploymentStatusID");
                EmploymentStatusName = DBUtility.SafeGet<string>(dr, "EmploymentStatusName");
            }
            dr.Close();
        }
    }
    public class Staffstatuses : ICollection<Staffstatus>
    {
        private List<Staffstatus> mCol;


        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffstatus");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Staffstatus Staffstatus;

            while (dr.Read())
            {
                Staffstatus = new Staffstatus();


                Staffstatus.EmploymentStatusID = DBUtility.SafeGet<int>(dr, "EmploymentStatusID");
                Staffstatus.EmploymentStatusName = DBUtility.SafeGet<string>(dr, "EmploymentStatusName");
                Add(Staffstatus);

            }
            dr.Close();
        }

        public void CopyTo(Staffstatus[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Staffstatus> GetEnumerator()
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

        public void Add(Staffstatus Staffstatus)
        {
            if (Staffstatus != null)
                mCol.Add(Staffstatus);
        }

        public bool Remove(Staffstatus Staffstatus)
        {
            return mCol.Remove(Staffstatus);
        }
        public Staffstatuses()
        {
            mCol = new List<Staffstatus>();
        }
        public bool Contains(Staffstatus Staffstatus)
        {
            return mCol.Contains(Staffstatus);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    /// </summary>
    public class Staff
    {
        #region "public Properties"

        public int StaffID { get; set; }
        public int RoleID { get; set; }
        public int StaffNumber { get; set; }

        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int StaffTypeID { get; set; }
        public string StaffTypeName { get; set; }
        public int RankID { get; set; }
        public string RankName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int NationalityID { get; set; }
        public string Nationality { get; set; }
        public string IdentificationNumber { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public DateTime MembershipEndDate { get; set; }
        public int ContributionAmount { get; set; }
        public bool IsActive { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Profession { get; set; }
        public bool HasDisability { get; set; }
        public string Desability { get; set; }
        public int EmploymentStatusID { get; set; }
        public string EmploymentStatusName { get; set; }
        public string LisenceNumber { get; set; }
        public string InstitutioncategoryName { get; set; }
        public string TypeofContract { get; set; }
        public string DurationofContract { get; set; }


        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@StaffID", StaffID);
                parameters.Add("@Surname", Surname);
                parameters.Add("@FirstName", FirstName);
                parameters.Add("@MiddleName", MiddleName);
                parameters.Add("@StaffTypeID", StaffTypeID);
                parameters.Add("@RankID", RankID);
                parameters.Add("@DepartmentID", DepartmentID);
                parameters.Add("@NationalityID", NationalityID);
                parameters.Add("@IdentificationNumber", IdentificationNumber);
                parameters.Add("@Gender", Gender);
                parameters.Add("@BirthDate", BirthDate);
                parameters.Add("@Telephone", Telephone);
                parameters.Add("@Email", Email);
                parameters.Add("@EmploymentDate", EmploymentDate);
                parameters.Add("@MembershipStartDate", MembershipStartDate);
                parameters.Add("@MembershipEndDate", MembershipEndDate);
                parameters.Add("@ContributionAmount", ContributionAmount);
                parameters.Add("@IsActive", IsActive);
                parameters.Add("@SocialSecurityNumber", SocialSecurityNumber);
                parameters.Add("@Profession", Profession);
                parameters.Add("@HasDisability", HasDisability);
                parameters.Add("@Desability", Desability);
                parameters.Add("@EmploymentStatusID", EmploymentStatusID);
                parameters.Add("@LisenceNumber", LisenceNumber);

                DBAccess.MISDB.ExecuteNonQuery("InsertStaff", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteStaff", "StaffID", StaffID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int staffId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaff", "StaffID", staffId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                StaffID = DBUtility.SafeGet<int>(dr, "StaffID");
                StaffNumber = DBUtility.SafeGet<int>(dr, "StaffNumber");
                Surname = DBUtility.SafeGet<string>(dr, "Surname");
                FirstName = DBUtility.SafeGet<string>(dr, "FirstName");
                MiddleName = DBUtility.SafeGet<string>(dr, "MiddleName");
                StaffTypeID = DBUtility.SafeGet<int>(dr, "StaffTypeID");
                StaffTypeName = DBUtility.SafeGet<string>(dr, "StaffTypeName");
                RankID = DBUtility.SafeGet<int>(dr, "RankID");
                RankName = DBUtility.SafeGet<string>(dr, "RankName");
                DepartmentID = DBUtility.SafeGet<int>(dr, "DepartmentID");
                DepartmentName = DBUtility.SafeGet<string>(dr, "DepartmentName");
                NationalityID = DBUtility.SafeGet<int>(dr, "NationalityID");
                Nationality = DBUtility.SafeGet<string>(dr, "Nationality");
                IdentificationNumber = DBUtility.SafeGet<string>(dr, "IdentificationNumber");
                Gender = DBUtility.SafeGet<string>(dr, "Gender");
                BirthDate = DBUtility.SafeGet<DateTime>(dr, "BirthDate");
                Telephone = DBUtility.SafeGet<string>(dr, "Telephone");
                Email = DBUtility.SafeGet<string>(dr, "Email");
                EmploymentDate = DBUtility.SafeGet<DateTime>(dr, "EmploymentDate");
                MembershipStartDate = DBUtility.SafeGet<DateTime>(dr, "MembershipStartDate");
                MembershipEndDate = DBUtility.SafeGet<DateTime>(dr, "MembershipEndDate");
                ContributionAmount = DBUtility.SafeGet<int>(dr, "ContributionAmount");
                IsActive = DBUtility.SafeGet<bool>(dr, "IsActive");
                SocialSecurityNumber = DBUtility.SafeGet<string>(dr, "SocialSecurityNumber");
                Profession = DBUtility.SafeGet<string>(dr, "Profession");
                HasDisability = DBUtility.SafeGet<bool>(dr, "HasDisability");
                Desability = DBUtility.SafeGet<string>(dr, "Desability");
                EmploymentStatusID = DBUtility.SafeGet<int>(dr, "EmploymentStatusID");
                EmploymentStatusName = DBUtility.SafeGet<string>(dr, "EmploymentStatusName");
                LisenceNumber = DBUtility.SafeGet<string>(dr, "LisenceNumber");
                InstitutioncategoryName = DBUtility.SafeGet<string>(dr, "InstitutioncategoryName");
                TypeofContract = DBUtility.SafeGet<string>(dr, "TypeofContract");
                DurationofContract = DBUtility.SafeGet<string>(dr, "DurationofContract");

            }
            dr.Close();
        }

    }
    public class Staffs : ICollection<Staff>
    {
        private List<Staff> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffs");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadprovecial(int userid)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetprovicialStaffs", "userid", userid);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loaduserrole(int userid)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("Getuserroles", "userid", userid);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public void Loaddistrict(int userid)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetDistrictStaffs", "userid", userid);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadproffession()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffproffession");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadproffessionN()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffproffessionN");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadproffessionM()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffproffessionM");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadproffessionT()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffproffessionT");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadHealtFacility()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacility");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityDH()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityDH");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityPH()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityPH");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityRH()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityRH");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityHC()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityHC");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityT()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityT");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadsexe()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffsexe");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadsexef()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffsexef");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadsexem()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffsexem");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadsexet()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffsexet");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadByName(string name)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffByName", "Name", name);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Staff staff;

            while (dr.Read())
            {
                staff = new Staff();

                staff.StaffID = DBUtility.SafeGet<int>(dr, "StaffID");
                staff.StaffNumber = DBUtility.SafeGet<int>(dr, "StaffNumber");
                staff.Surname = DBUtility.SafeGet<string>(dr, "Surname");
                staff.FirstName = DBUtility.SafeGet<string>(dr, "FirstName");
                staff.MiddleName = DBUtility.SafeGet<string>(dr, "MiddleName");
                staff.StaffTypeID = DBUtility.SafeGet<int>(dr, "StaffTypeID");
                staff.StaffTypeName = DBUtility.SafeGet<string>(dr, "StaffTypeName");
                staff.RankID = DBUtility.SafeGet<int>(dr, "RankID");
                staff.RankName = DBUtility.SafeGet<string>(dr, "RankName");
                staff.DepartmentID = DBUtility.SafeGet<int>(dr, "DepartmentID");
                staff.DepartmentName = DBUtility.SafeGet<string>(dr, "DepartmentName");
                staff.NationalityID = DBUtility.SafeGet<int>(dr, "NationalityID");
                staff.Nationality = DBUtility.SafeGet<string>(dr, "Nationality");
                staff.IdentificationNumber = DBUtility.SafeGet<string>(dr, "IdentificationNumber");
                staff.Gender = DBUtility.SafeGet<string>(dr, "Gender");
                staff.BirthDate = DBUtility.SafeGet<DateTime>(dr, "BirthDate");
                staff.Telephone = DBUtility.SafeGet<string>(dr, "Telephone");
                staff.Email = DBUtility.SafeGet<string>(dr, "Email");
                staff.EmploymentDate = DBUtility.SafeGet<DateTime>(dr, "EmploymentDate");
                staff.MembershipStartDate = DBUtility.SafeGet<DateTime>(dr, "MembershipStartDate");
                staff.MembershipEndDate = DBUtility.SafeGet<DateTime>(dr, "MembershipEndDate");
                staff.ContributionAmount = DBUtility.SafeGet<int>(dr, "ContributionAmount");
                staff.IsActive = DBUtility.SafeGet<bool>(dr, "IsActive");
                staff.SocialSecurityNumber = DBUtility.SafeGet<string>(dr, "SocialSecurityNumber");
                staff.Profession = DBUtility.SafeGet<string>(dr, "Profession");
                staff.HasDisability = DBUtility.SafeGet<bool>(dr, "HasDisability");
                staff.Desability = DBUtility.SafeGet<string>(dr, "Desability");
                staff.EmploymentStatusID = DBUtility.SafeGet<int>(dr, "EmploymentStatusID");
                staff.EmploymentStatusName = DBUtility.SafeGet<string>(dr, "EmploymentStatusName");
                staff.LisenceNumber = DBUtility.SafeGet<string>(dr, "LisenceNumber");
                staff.InstitutioncategoryName = DBUtility.SafeGet<string>(dr, "InstitutioncategoryName");
                staff.TypeofContract = DBUtility.SafeGet<string>(dr, "TypeofContract");
                staff.DurationofContract = DBUtility.SafeGet<string>(dr, "DurationofContract");
                staff.RoleID = DBUtility.SafeGet<int>(dr, "RoleID");
                Add(staff);

            }
            dr.Close();
        }

        public void CopyTo(Staff[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Staff> GetEnumerator()
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

        public void Add(Staff staff)
        {
            if (staff != null)
                mCol.Add(staff);
        }

        public bool Remove(Staff staff)
        {
            return mCol.Remove(staff);
        }
        public Staffs()
        {
            mCol = new List<Staff>();
        }
        public bool Contains(Staff staff)
        {
            return mCol.Contains(staff);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>



    /// </summary>
    public class Applicant
    {
      


        public int ApplicantID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RSSBNo { get; set; }
        public int MaritalStatusID { get; set; }
        public int NationalityID { get; set; }
        public string Nationality { get; set; }
        public int TitleID { get; set; }
        public int AdministrativeDivisionID { get; set; }
        public string PhoneNumber { get; set; }
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public bool IsCivilServant { get; set; }
        public string Disability { get; set; }
        public int StaffTypeID { get; set; }
        public int RankID { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public int ContributionAmount { get; set; }
        public string Profession { get; set; }
        public string LisenceNumber { get; set; }
        public int EmploymentStatusID { get; set; }
        public string statuses { get; set; }
        public string MaritalStatus { get; set; }



        public void Save()
        {
            try
            {
                
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@ApplicantID", ApplicantID);
                parameters.Add("@UserName", UserName);
                parameters.Add("@LastName", LastName);
                parameters.Add("@MiddleName", MiddleName);
                
                parameters.Add("@FirstName", FirstName);
                
                parameters.Add("@NationalityID", NationalityID);
                parameters.Add("@IDNumber", IDNumber);
                parameters.Add("@Gender", Gender);
                parameters.Add("@PhoneNumber", PhoneNumber);
                parameters.Add("@Email", Email);
                parameters.Add("@DateOfBirth", DateOfBirth);
                
               
                
                


                
                
               
                

                DBAccess.MISDB.ExecuteNonQuery("InsertApplicant", parameters);


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

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@ApplicantID", ApplicantID);
               
                DBAccess.MISDB.ExecuteNonQuery("DeleteApplicant", parameters);


            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Load(int ApplicantID)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetApplicant", "ApplicantID", ApplicantID);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                ApplicantID = DBUtility.SafeGet<int>(dr, "ApplicantID");
                UserName = DBUtility.SafeGet<string>(dr, "UserName");
                Email = DBUtility.SafeGet<string>(dr, "Email");
                CreationDate = DBUtility.SafeGet<DateTime>(dr, "CreationDate");
                FirstName = DBUtility.SafeGet<string>(dr, "FirstName");
                MiddleName = DBUtility.SafeGet<string>(dr, "MiddleName");
                LastName = DBUtility.SafeGet<string>(dr, "LastName");
                IDNumber = DBUtility.SafeGet<string>(dr, "IDNumber");
                DateOfBirth = DBUtility.SafeGet<DateTime>(dr, "DateOfBirth");
                RSSBNo = DBUtility.SafeGet<string>(dr, "RSSBNo");
                MaritalStatusID = DBUtility.SafeGet<int>(dr, "MaritalStatusID");
                NationalityID = DBUtility.SafeGet<int>(dr, "NationalityID");
                Nationality = DBUtility.SafeGet<string>(dr, "Nationality");
                TitleID = DBUtility.SafeGet<int>(dr, "TitleID");
                AdministrativeDivisionID = DBUtility.SafeGet<int>(dr, "AdministrativeDivisionID");
                PhoneNumber = DBUtility.SafeGet<string>(dr, "PhoneNumber");
                EmployeeID = DBUtility.SafeGet<int>(dr, "EmployeeID");
                FullName = DBUtility.SafeGet<string>(dr, "FullName");
                MaritalStatus = DBUtility.SafeGet<string>(dr, "MaritalStatus");

                Gender = DBUtility.SafeGet<string>(dr, "Gender");
                Disability = DBUtility.SafeGet<string>(dr, "Disability");
                IsCivilServant = DBUtility.SafeGet<bool>(dr, "IsCivilServant");
                StaffTypeID = DBUtility.SafeGet<int>(dr, "StaffTypeID");
                RankID = DBUtility.SafeGet<int>(dr, "RankID");
                EmploymentDate = DBUtility.SafeGet<DateTime>(dr, "EmploymentDate");
                MembershipStartDate = DBUtility.SafeGet<DateTime>(dr, "MembershipStartDate");
                ContributionAmount = DBUtility.SafeGet<int>(dr, "ContributionAmount");
                Profession = DBUtility.SafeGet<string>(dr, "Profession");
                Disability = DBUtility.SafeGet<string>(dr, "Disability");
                LisenceNumber = DBUtility.SafeGet<string>(dr, "LisenceNumber");
                EmploymentStatusID = DBUtility.SafeGet<int>(dr, "EmploymentStatusID");
                statuses = DBUtility.SafeGet<string>(dr, "statuses");



            }
            dr.Close();
        }

    }
    public class Applicants : ICollection<Applicant>
    {
        private List<Applicant> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffs");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadproffession()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffproffession");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadproffessionN()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffproffessionN");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadproffessionM()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffproffessionM");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadproffessionT()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffproffessionT");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadHealtFacility()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacility");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityDH()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityDH");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityPH()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityPH");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityRH()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityRH");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityHC()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityHC");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadHealtFacilityT()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffHealtFacilityT");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadsexe()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffsexe");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadsexef()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffsexef");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadsexem()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffsexem");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Loadsexet()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetStaffsexet");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadByName(string name)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetApplicantByName", "Name", name);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Applicant Applicant;

            while (dr.Read())
            {
                Applicant = new Applicant();

                Applicant.ApplicantID = DBUtility.SafeGet<int>(dr, "ApplicantID");
                Applicant.UserName = DBUtility.SafeGet<string>(dr, "UserName");
                Applicant.Email = DBUtility.SafeGet<string>(dr, "Email");
                Applicant.CreationDate = DBUtility.SafeGet<DateTime>(dr, "CreationDate");
                Applicant.FirstName = DBUtility.SafeGet<string>(dr, "FirstName");
                Applicant.MiddleName = DBUtility.SafeGet<string>(dr, "MiddleName");
                Applicant.LastName = DBUtility.SafeGet<string>(dr, "LastName");
                Applicant.IDNumber = DBUtility.SafeGet<string>(dr, "IDNumber");
                Applicant.DateOfBirth = DBUtility.SafeGet<DateTime>(dr, "DateOfBirth");
                Applicant.RSSBNo = DBUtility.SafeGet<string>(dr, "RSSBNo");
                Applicant.MaritalStatusID = DBUtility.SafeGet<int>(dr, "MaritalStatusID");
                Applicant.NationalityID = DBUtility.SafeGet<int>(dr, "NationalityID");
                Applicant.Nationality = DBUtility.SafeGet<string>(dr, "Nationality");
                Applicant.TitleID = DBUtility.SafeGet<int>(dr, "TitleID");
                Applicant.AdministrativeDivisionID = DBUtility.SafeGet<int>(dr, "AdministrativeDivisionID");
                Applicant.PhoneNumber = DBUtility.SafeGet<string>(dr, "PhoneNumber");
                Applicant.EmployeeID = DBUtility.SafeGet<int>(dr, "EmployeeID");
                Applicant.FullName = DBUtility.SafeGet<string>(dr, "FullName");
                Applicant.MaritalStatus = DBUtility.SafeGet<string>(dr, "MaritalStatus");
                Applicant.Gender = DBUtility.SafeGet<string>(dr, "Gender");
                Applicant.Disability = DBUtility.SafeGet<string>(dr, "Disability");
                Applicant.IsCivilServant = DBUtility.SafeGet<bool>(dr, "IsCivilServant");
                Applicant.StaffTypeID = DBUtility.SafeGet<int>(dr, "StaffTypeID");
                Applicant.RankID = DBUtility.SafeGet<int>(dr, "RankID");
                Applicant.EmploymentDate = DBUtility.SafeGet<DateTime>(dr, "EmploymentDate");
                Applicant.MembershipStartDate = DBUtility.SafeGet<DateTime>(dr, "MembershipStartDate");
                Applicant.ContributionAmount = DBUtility.SafeGet<int>(dr, "ContributionAmount");
                Applicant.Profession = DBUtility.SafeGet<string>(dr, "Profession");
                Applicant.Disability = DBUtility.SafeGet<string>(dr, "Disability");
                Applicant.LisenceNumber = DBUtility.SafeGet<string>(dr, "LisenceNumber");
                Applicant.EmploymentStatusID = DBUtility.SafeGet<int>(dr, "EmploymentStatusID");
                Applicant.statuses = DBUtility.SafeGet<string>(dr, "statuses");
                Add(Applicant);

            }
            dr.Close();
        }

        public void CopyTo(Applicant[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Applicant> GetEnumerator()
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

        public void Add(Applicant Applicant)
        {
            if (Applicant != null)
                mCol.Add(Applicant);
        }

        public bool Remove(Applicant Applicant)
        {
            return mCol.Remove(Applicant);
        }
        public Applicants()
        {
            mCol = new List<Applicant>();
        }
        public bool Contains(Applicant Applicant)
        {
            return mCol.Contains(Applicant);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }




    /// </summary>
    public class Village
    {
        #region "public Properties"

        public int VillageID { get; set; }
        public string VillageName { get; set; }
        public int CellID { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@VillageID", VillageID);
                parameters.Add("@VillageName", VillageName);
                parameters.Add("@CellID", CellID);

                DBAccess.MISDB.ExecuteNonQuery("InsertVillage", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteVillage", "VillageID", VillageID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int villageId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetVillage", "VillageID", villageId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                VillageID = DBUtility.SafeGet<int>(dr, "VillageID");
                VillageName = DBUtility.SafeGet<string>(dr, "VillageName");
                CellID = DBUtility.SafeGet<int>(dr, "CellID");
            }
            dr.Close();
        }
    }
    public class Villages : ICollection<Village>
    {
        private List<Village> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetVillages");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadForCell(int cellId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetVillagesForCell", "CellID", cellId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Village village;

            while (dr.Read())
            {
                village = new Village();

                village.VillageID = DBUtility.SafeGet<int>(dr, "VillageID");
                village.VillageName = DBUtility.SafeGet<string>(dr, "VillageName");
                village.CellID = DBUtility.SafeGet<int>(dr, "CellID");

                Add(village);

            }
            dr.Close();
        }

        public void CopyTo(Village[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Village> GetEnumerator()
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

        public void Add(Village village)
        {
            if (village != null)
                mCol.Add(village);
        }

        public bool Remove(Village village)
        {
            return mCol.Remove(village);
        }
        public Villages()
        {
            mCol = new List<Village>();
        }
        public bool Contains(Village village)
        {
            return mCol.Contains(village);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Cell
    {
        #region "public Properties"

        public int CellID { get; set; }
        public string CellName { get; set; }
        public int SectorID { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@CellID", CellID);
                parameters.Add("@CellName", CellName);
                parameters.Add("@SectorID", SectorID);

                DBAccess.MISDB.ExecuteNonQuery("InsertCell", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteCell", "CellID", CellID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int cellId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCell", "CellID", cellId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                CellID = DBUtility.SafeGet<int>(dr, "CellID");
                CellName = DBUtility.SafeGet<string>(dr, "CellName");
                SectorID = DBUtility.SafeGet<int>(dr, "SectorID");
            }
            dr.Close();
        }
    }
    public class Cells : ICollection<Cell>
    {
        private List<Cell> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCells");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadForSector(int sectorId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCellsForSector", "SectorID", sectorId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Cell cell;

            while (dr.Read())
            {
                cell = new Cell();

                cell.CellID = DBUtility.SafeGet<int>(dr, "CellID");
                cell.CellName = DBUtility.SafeGet<string>(dr, "CellName");
                cell.SectorID = DBUtility.SafeGet<int>(dr, "SectorID");

                Add(cell);

            }
            dr.Close();
        }

        public void CopyTo(Cell[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Cell> GetEnumerator()
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

        public void Add(Cell cell)
        {
            if (cell != null)
                mCol.Add(cell);
        }

        public bool Remove(Cell cell)
        {
            return mCol.Remove(cell);
        }
        public Cells()
        {
            mCol = new List<Cell>();
        }
        public bool Contains(Cell cell)
        {
            return mCol.Contains(cell);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Sector
    {
        #region "public Properties"

        public int SectorID { get; set; }
        public string SectorName { get; set; }
        public int DistrictID { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SectorID", SectorID);
                parameters.Add("@SectorName", SectorName);
                parameters.Add("@DistrictID", DistrictID);

                DBAccess.MISDB.ExecuteNonQuery("InsertSector", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteSector", "SectorID", SectorID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int sectorId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetSector", "SectorID", sectorId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                SectorID = DBUtility.SafeGet<int>(dr, "SectorID");
                SectorName = DBUtility.SafeGet<string>(dr, "SectorName");
                DistrictID = DBUtility.SafeGet<int>(dr, "DistrictID");
            }
            dr.Close();
        }
    }
    public class Sectors : ICollection<Sector>
    {
        private List<Sector> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetSectors");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadForDistrict(int districtId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetSectorsForDistrict", "DistrictID", districtId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Sector sector;

            while (dr.Read())
            {
                sector = new Sector();

                sector.SectorID = DBUtility.SafeGet<int>(dr, "SectorID");
                sector.SectorName = DBUtility.SafeGet<string>(dr, "SectorName");
                sector.DistrictID = DBUtility.SafeGet<int>(dr, "DistrictID");

                Add(sector);

            }
            dr.Close();
        }

        public void CopyTo(Sector[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Sector> GetEnumerator()
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

        public void Add(Sector sector)
        {
            if (sector != null)
                mCol.Add(sector);
        }

        public bool Remove(Sector sector)
        {
            return mCol.Remove(sector);
        }
        public Sectors()
        {
            mCol = new List<Sector>();
        }
        public bool Contains(Sector sector)
        {
            return mCol.Contains(sector);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class District
    {
        #region "public Properties"

        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int ProvinceID { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@DistrictID", DistrictID);
                parameters.Add("@DistrictName", DistrictName);
                parameters.Add("@ProvinceID", ProvinceID);

                DBAccess.MISDB.ExecuteNonQuery("InsertDistrict", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteDistrict", "DistrictID", DistrictID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int districtId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetDistrict", "DistrictID", districtId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                DistrictID = DBUtility.SafeGet<int>(dr, "DistrictID");
                DistrictName = DBUtility.SafeGet<string>(dr, "DistrictName");
                ProvinceID = DBUtility.SafeGet<int>(dr, "ProvinceID");
            }
            dr.Close();
        }
    }
    public class Districts : ICollection<District>
    {
        private List<District> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetDistricts");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadForProvince(int provinceId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetDistrictsForProvince", "ProvinceID", provinceId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            District district;

            while (dr.Read())
            {
                district = new District();

                district.DistrictID = DBUtility.SafeGet<int>(dr, "DistrictID");
                district.DistrictName = DBUtility.SafeGet<string>(dr, "DistrictName");
                district.ProvinceID = DBUtility.SafeGet<int>(dr, "ProvinceID");

                Add(district);

            }
            dr.Close();
        }

        public void CopyTo(District[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<District> GetEnumerator()
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

        public void Add(District district)
        {
            if (district != null)
                mCol.Add(district);
        }

        public bool Remove(District district)
        {
            return mCol.Remove(district);
        }
        public Districts()
        {
            mCol = new List<District>();
        }
        public bool Contains(District district)
        {
            return mCol.Contains(district);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Province
    {
        #region "public Properties"

        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@ProvinceID", ProvinceID);
                parameters.Add("@ProvinceName", ProvinceName);

                DBAccess.MISDB.ExecuteNonQuery("InsertProvince", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteProvince", "ProvinceID", ProvinceID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int provinceId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetProvince", "ProvinceID", provinceId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                ProvinceID = DBUtility.SafeGet<int>(dr, "ProvinceID");
                ProvinceName = DBUtility.SafeGet<string>(dr, "ProvinceName");
            }
            dr.Close();
        }
    }
    public class Provinces : ICollection<Province>
    {
        private List<Province> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetProvinces");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Province province;

            while (dr.Read())
            {
                province = new Province();

                province.ProvinceID = DBUtility.SafeGet<int>(dr, "ProvinceID");
                province.ProvinceName = DBUtility.SafeGet<string>(dr, "ProvinceName");

                Add(province);

            }
            dr.Close();
        }

        public void CopyTo(Province[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Province> GetEnumerator()
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

        public void Add(Province province)
        {
            if (province != null)
                mCol.Add(province);
        }

        public bool Remove(Province province)
        {
            return mCol.Remove(province);
        }
        public Provinces()
        {
            mCol = new List<Province>();
        }
        public bool Contains(Province province)
        {
            return mCol.Contains(province);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class BankAccount
    {
        #region "public Properties"

        public int BankAccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public int BankID { get; set; }
        public int CurrencyID { get; set; }
        public string BankName { get; set; }
        public string Currency { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@BankAccountID", BankAccountID);
                parameters.Add("@AccountName", AccountName);
                parameters.Add("@AccountNumber", AccountNumber);
                parameters.Add("@BankID", BankID);
                parameters.Add("@CurrencyID", CurrencyID);

                DBAccess.MISDB.ExecuteNonQuery("InsertBankAccount", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteBankAccount", "BankAccountID", BankAccountID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int bankAccountId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetBankAccount", "BankAccountID", bankAccountId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                BankAccountID = DBUtility.SafeGet<int>(dr, "BankAccountID");
                AccountName = DBUtility.SafeGet<string>(dr, "AccountName");
                AccountNumber = DBUtility.SafeGet<string>(dr, "AccountNumber");
                BankID = DBUtility.SafeGet<int>(dr, "BankID");
                CurrencyID = DBUtility.SafeGet<int>(dr, "CurrencyID");
                BankName = DBUtility.SafeGet<string>(dr, "BankName");
                Currency = DBUtility.SafeGet<string>(dr, "Currency");
            }
            dr.Close();
        }
    }
    public class BankAccounts : ICollection<BankAccount>
    {
        private List<BankAccount> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetBankAccounts");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            BankAccount account;

            while (dr.Read())
            {
                account = new BankAccount();

                account.BankAccountID = DBUtility.SafeGet<int>(dr, "BankAccountID");
                account.AccountName = DBUtility.SafeGet<string>(dr, "AccountName");
                account.AccountNumber = DBUtility.SafeGet<string>(dr, "AccountNumber");
                account.BankID = DBUtility.SafeGet<int>(dr, "BankID");
                account.CurrencyID = DBUtility.SafeGet<int>(dr, "CurrencyID");
                account.BankName = DBUtility.SafeGet<string>(dr, "BankName");
                account.Currency = DBUtility.SafeGet<string>(dr, "Currency");

                Add(account);

            }
            dr.Close();
        }

        public void CopyTo(BankAccount[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<BankAccount> GetEnumerator()
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

        public void Add(BankAccount account)
        {
            if (account != null)
                mCol.Add(account);
        }

        public bool Remove(BankAccount account)
        {
            return mCol.Remove(account);
        }
        public BankAccounts()
        {
            mCol = new List<BankAccount>();
        }
        public bool Contains(BankAccount account)
        {
            return mCol.Contains(account);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Bank
    {
        #region "public Properties"

        public int BankID { get; set; }
        public string BankName { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@BankID", BankID);
                parameters.Add("@BankName", BankName);

                DBAccess.MISDB.ExecuteNonQuery("InsertBank", parameters);

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
                DBAccess.MISDB.ExecuteNonQuery("DeleteBank", "BankID", BankID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int bankId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetBank", "BankID", bankId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                BankID = DBUtility.SafeGet<int>(dr, "BankID");
                BankName = DBUtility.SafeGet<string>(dr, "BankName");
            }
            dr.Close();
        }
    }
    public class Banks : ICollection<Bank>
    {
        private List<Bank> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetBanks");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Bank bank;

            while (dr.Read())
            {
                bank = new Bank();

                bank.BankID = DBUtility.SafeGet<int>(dr, "BankID");
                bank.BankName = DBUtility.SafeGet<string>(dr, "BankName");

                Add(bank);

            }
            dr.Close();
        }

        public void CopyTo(Bank[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Bank> GetEnumerator()
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

        public void Add(Bank bank)
        {
            if (bank != null)
                mCol.Add(bank);
        }

        public bool Remove(Bank bank)
        {
            return mCol.Remove(bank);
        }
        public Banks()
        {
            mCol = new List<Bank>();
        }
        public bool Contains(Bank bank)
        {
            return mCol.Contains(bank);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Currency
    {
        #region "public Properties"

        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@CurrencyID", CurrencyID);
                parameters.Add("@Currency", CurrencyName);

                DBAccess.MISDB.ExecuteNonQuery("InsertCurrency", parameters);
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
                DBAccess.MISDB.ExecuteNonQuery("DeleteCurrency", "CurrencyID", CurrencyID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void Load(int currencyId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCurrency", "CurrencyID", currencyId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                CurrencyID = DBUtility.SafeGet<int>(dr, "CurrencyID");
                CurrencyName = DBUtility.SafeGet<string>(dr, "Currency");
            }
            dr.Close();
        }
    }
    public class Currencys : ICollection<Currency>
    {
        private List<Currency> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetCurrencies");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Currency currency;

            while (dr.Read())
            {
                currency = new Currency();

                currency.CurrencyID = DBUtility.SafeGet<int>(dr, "CurrencyID");
                currency.CurrencyName = DBUtility.SafeGet<string>(dr, "Currency");

                Add(currency);

            }
            dr.Close();
        }

        public void CopyTo(Currency[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Currency> GetEnumerator()
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

        public void Add(Currency currency)
        {
            if (currency != null)
                mCol.Add(currency);
        }

        public bool Remove(Currency currency)
        {
            return mCol.Remove(currency);
        }
        public Currencys()
        {
            mCol = new List<Currency>();
        }
        public bool Contains(Currency currency)
        {
            return mCol.Contains(currency);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Contribution
    {
        #region "public Properties"

        public long ContributionID { get; set; }
        public int StaffID { get; set; }
        public string Names { get; set; }
        public int Amount { get; set; }
        public Int16 Year { get; set; }
        public byte Month { get; set; }
        public int BankAccountID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public DateTime BankTransactionDate { get; set; }
        public string BankTransactionNumber { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }

        #endregion

        #region "Data Access"
        public void Save()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@ContributionID", ContributionID);
                parameters.Add("@StaffID", StaffID);
                parameters.Add("@Amount", Amount);
                parameters.Add("@Year", Year);
                parameters.Add("@Month", Month);
                parameters.Add("@BankAccountID", BankAccountID);
                parameters.Add("@BankTransactionDate", BankTransactionDate);
                parameters.Add("@BankTransactionNumber", BankTransactionNumber);
                parameters.Add("@UserID", UserID);

                DBAccess.MISDB.ExecuteNonQuery("InsertContribution", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int userId)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@ContributionID", ContributionID);
                parameters.Add("@UserID", userId);

                DBAccess.MISDB.ExecuteNonQuery("DeleteContribution", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public void Load(long contributionId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetContribution", "ContributionID", contributionId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            while (dr.Read())
            {
                ContributionID = DBUtility.SafeGet<long>(dr, "ContributionID");
                StaffID = DBUtility.SafeGet<int>(dr, "StaffID");
                Names = DBUtility.SafeGet<string>(dr, "Names");
                Amount = DBUtility.SafeGet<int>(dr, "Amount");
                Year = DBUtility.SafeGet<Int16>(dr, "Year");
                Month = DBUtility.SafeGet<byte>(dr, "Month");
                BankAccountID = DBUtility.SafeGet<int>(dr, "BankAccountID");
                BankName = DBUtility.SafeGet<string>(dr, "BankName");
                AccountNumber = DBUtility.SafeGet<string>(dr, "AccountNumber");
                AccountName = DBUtility.SafeGet<string>(dr, "AccountName");
                BankTransactionDate = DBUtility.SafeGet<DateTime>(dr, "BankTransactionDate");
                BankTransactionNumber = DBUtility.SafeGet<string>(dr, "BankTransactionNumber");
                UserID = DBUtility.SafeGet<int>(dr, "UserID");
                UserName = DBUtility.SafeGet<string>(dr, "UserName");
            }
            dr.Close();
        }
    }
    public class Contributions : ICollection<Contribution>
    {
        private List<Contribution> mCol;

        public void Load()
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetContributions");

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadForMember(int staffId)
        {
            try
            {
                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetContributionsForMember", "StaffID", staffId);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadForPeriod(DateTime from, DateTime to)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@StartDate", from);
                parameters.Add("@EndDate", to);

                SqlDataReader dr = DBAccess.MISDB.ExecuteReader("GetContributionsForPeriod", parameters);

                LoadFromDataReader(dr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromDataReader(SqlDataReader dr)
        {
            Contribution contribution;

            while (dr.Read())
            {
                contribution = new Contribution();

                contribution.ContributionID = DBUtility.SafeGet<long>(dr, "ContributionID");
                contribution.StaffID = DBUtility.SafeGet<int>(dr, "StaffID");
                contribution.Names = DBUtility.SafeGet<string>(dr, "Names");
                contribution.Amount = DBUtility.SafeGet<int>(dr, "Amount");
                contribution.Year = DBUtility.SafeGet<Int16>(dr, "Year");
                contribution.Month = DBUtility.SafeGet<byte>(dr, "Month");
                contribution.BankAccountID = DBUtility.SafeGet<int>(dr, "BankAccountID");
                contribution.BankName = DBUtility.SafeGet<string>(dr, "BankName");
                contribution.AccountNumber = DBUtility.SafeGet<string>(dr, "AccountNumber");
                contribution.AccountName = DBUtility.SafeGet<string>(dr, "AccountName");
                contribution.BankTransactionDate = DBUtility.SafeGet<DateTime>(dr, "BankTransactionDate");
                contribution.BankTransactionNumber = DBUtility.SafeGet<string>(dr, "BankTransactionNumber");
                contribution.UserID = DBUtility.SafeGet<int>(dr, "UserID");
                contribution.UserName = DBUtility.SafeGet<string>(dr, "UserName");

                Add(contribution);

            }
            dr.Close();
        }

        public System.Data.DataTable LoadContributions(int staffId)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@StaffID", staffId);

                return DBAccess.MISDB.ExecuteDataTable("GetContributionsForMember", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public System.Data.DataTable LoadAnnulContributions()
        {
            try
            {
                return DBAccess.MISDB.ExecuteDataTable("GetAnnualContributions");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CopyTo(Contribution[] array, int index)
        {
            mCol.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return mCol.Count;
            }
        }

        public IEnumerator<Contribution> GetEnumerator()
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

        public void Add(Contribution contribution)
        {
            if (contribution != null)
                mCol.Add(contribution);
        }

        public bool Remove(Contribution contribution)
        {
            return mCol.Remove(contribution);
        }
        public Contributions()
        {
            mCol = new List<Contribution>();
        }
        public bool Contains(Contribution contribution)
        {
            return mCol.Contains(contribution);
        }
        public void Clear()
        {
            mCol.Clear();
        }


        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}

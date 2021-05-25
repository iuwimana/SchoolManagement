using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS
{
    public static class MISFactory
    {
        #region MIS
        public static schools Getschools()
        {
            schools depts = new schools();
            depts.Load();
            return depts;
        }
        public static Departments GetDepartments()
        {
            Departments depts = new Departments();
            depts.Load();
            return depts;
        }
        public static Department GetDepartment(int deptID)
        {
            Department dept = new Department();
            dept.Load(deptID);
            return dept;
        }

        public static Ranks GetRanks()
        {
            Ranks ranks = new Ranks();
            ranks.Load();
            return ranks;
        }
        public static Rank GetRank(int rankId)
        {
            Rank rank = new Rank();
            rank.Load(rankId);
            return rank;
        }
        public static StaffTypes GetStaffTypes()
        {
            StaffTypes types = new StaffTypes();
            types.Load();
            return types;
        }
        public static Staffstatuses GetStaffStatus()
        {
            Staffstatuses types = new Staffstatuses();
            types.Load();
            return types;
        }
        public static StaffType GetStaffType(int staffTypeId)
        {
            StaffType type = new StaffType();
            type.Load(staffTypeId);
            return type;
        }
        public static Villages GetVillages()
        {
            Villages villages = new Villages();
            villages.Load();
            return villages;
        }
        public static Villages GetCellVillages(int cellId)
        {
            Villages villages = new Villages();
            villages.LoadForCell(cellId);
            return villages;
        }
        public static Village GetVillage(int villageId)
        {
            Village village = new Village();
            village.Load(villageId);
            return village;
        }
        public static Cells GetCells()
        {
            Cells cells = new Cells();
            cells.Load();
            return cells;
        }
        public static Cells GetSectorCells(int sectorId)
        {
            Cells cells = new Cells();
            cells.LoadForSector(sectorId);
            return cells;
        }
        public static Cell GetCell(int cellId)
        {
            Cell cell = new Cell();
            cell.Load(cellId);
            return cell;
        }
        public static Sectors GetSectors()
        {
            Sectors sectors = new Sectors();
            sectors.Load();
            return sectors;
        }
        public static Sectors GetDistrictSectors(int districtId)
        {
            Sectors sectors = new Sectors();
            sectors.LoadForDistrict(districtId);
            return sectors;
        }
        public static Sector GetSector(int sectorId)
        {
            Sector sector = new Sector();
            sector.Load(sectorId);
            return sector;
        }
        public static Districts GetDistricts()
        {
            Districts districts = new Districts();
            districts.Load();
            return districts;
        }
        public static Districts GetProvinceDistricts(int provinceId)
        {
            Districts districts = new Districts();
            districts.LoadForProvince(provinceId);
            return districts;
        }
        public static District GetDistrict(int districtId)
        {
            District district = new District();
            district.Load(districtId);
            return district;
        }
        public static Provinces GetProvinces()
        {
            Provinces provinces = new Provinces();
            provinces.Load();
            return provinces;
        }
        public static Province GetProvince(int provinceId)
        {
            Province province = new Province();
            province.Load(provinceId);
            return province;
        }
        public static Staffs GetStaffs()
        {
            Staffs staffs = new Staffs();
            staffs.Load();
            return staffs;
        }
        public static Staffs GetProvencialStaffs(int userid)
        {
            Staffs staffs = new Staffs();
            staffs.Loadprovecial(userid);
            return staffs;
        }

        public static Staffs Getuserroles(int userid)
        {
            Staffs userroles = new Staffs();
            userroles.Loaduserrole(userid);
            return userroles;
        }
        public static Staffs GetDistrictStaffs(int userid)
        {
            Staffs staffs = new Staffs();
            staffs.Loaddistrict(userid);
            return staffs;
        }


        public static Staffs GetStaffprofession()
        {
            Staffs staffs = new Staffs();
            staffs.Loadproffession();
            return staffs;
        }
        public static Staffs GetStaffprofessionN()
        {
            Staffs staffs = new Staffs();
            staffs.LoadproffessionN();
            return staffs;
        }
        public static Staffs GetStaffprofessionM()
        {
            Staffs staffs = new Staffs();
            staffs.LoadproffessionM();
            return staffs;
        }
        public static Staffs GetStaffprofessionT()
        {
            Staffs staffs = new Staffs();
            staffs.LoadproffessionT();
            return staffs;
        }
        public static Staffs GetStaffHealtFacility()
        {
            Staffs staffs = new Staffs();
            staffs.LoadHealtFacility();
            return staffs;
        }
        public static Staffs GetStaffHealtFacilityDH()
        {
            Staffs staffs = new Staffs();
            staffs.LoadHealtFacilityDH();
            return staffs;
        }
        public static Staffs GetStaffHealtFacilityPH()
        {
            Staffs staffs = new Staffs();
            staffs.LoadHealtFacilityPH();
            return staffs;
        }
        public static Staffs GetStaffHealtFacilityRH()
        {
            Staffs staffs = new Staffs();
            staffs.LoadHealtFacilityRH();
            return staffs;
        }
        public static Staffs GetStaffHealtFacilityHC()
        {
            Staffs staffs = new Staffs();
            staffs.LoadHealtFacilityHC();
            return staffs;
        }
        public static Staffs GetStaffHealtFacilityT()
        {
            Staffs staffs = new Staffs();
            staffs.LoadHealtFacilityT();
            return staffs;
        }
        public static Staffs GetStaffsexe()
        {
            Staffs staffs = new Staffs();
            staffs.Loadsexe();
            return staffs;
        }
        public static Staffs GetStaffsexef()
        {
            Staffs staffs = new Staffs();
            staffs.Loadsexef();
            return staffs;
        }
        public static Staffs GetStaffsexem()
        {
            Staffs staffs = new Staffs();
            staffs.Loadsexem();
            return staffs;
        }


        public static RNMUMemberRole CreateRNMUMemberRole(int rnmumemberuserid, int userId,  int RNMUMemberRoleid)
        {
            try
            {
                RNMUMemberRole user = new RNMUMemberRole()
                {
                    rnmumemberuserid = rnmumemberuserid,
                    userId = userId,
                    RNMUMemberRoleid = RNMUMemberRoleid
                    
                };

                user.Save();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static WINUSERROLEARREAR CreateWINUSERROLEARREAR(int WINUSERROLEARREARID, int userId, int ProvinceID, int DistrictID)
        {
            try
            {
                WINUSERROLEARREAR user = new WINUSERROLEARREAR()
                {
                    WINUSERROLEARREARID = WINUSERROLEARREARID,
                    UserID = userId,
                    ProvinceID = ProvinceID,
                    DistrictID= DistrictID

                };

                user.Save();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static RNMUMemberRole CreateRNMUMemberRoleArrear(int RNMUMEMBERUSERARREARID, int userId, int DistrictID, int ProvinceID)
        {
            try
            {
                RNMUMemberRole user = new RNMUMemberRole()
                {
                    RNMUMEMBERUSERARREARID = RNMUMEMBERUSERARREARID,
                    userId = userId,
                    DistrictID = DistrictID,
                    ProvinceID= ProvinceID

                };

                user.SaveMEMBERUSER();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Applicant CreateApplicant(int ApplicantID, string UserName, string LastName, string MiddleName, string FirstName, int NationalityID, string IDNumber, string Gender, string PhoneNumber, string Email,DateTime DateOfBirth)
        {
            try
            {
                Applicant user = new Applicant()
                {
                    ApplicantID = ApplicantID,
                    UserName= UserName,
                    LastName=LastName,
                    MiddleName= MiddleName,
                    FirstName= FirstName,
                    NationalityID= NationalityID,
                    IDNumber= IDNumber,
                    Gender=Gender,
                    PhoneNumber= PhoneNumber,
                    Email= Email,
                    DateOfBirth= DateOfBirth
                    

                };

                user.Save();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Applicant Createdelete(int ApplicantID)
        {
            try
            {
                Applicant user = new Applicant()
                {
                    ApplicantID = ApplicantID,
                   


                };

                user.Delete();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Staffs GetStaffsexet()
        {
            Staffs staffs = new Staffs();
            staffs.Loadsexet();
            return staffs;
        }
        public static Staffs GetStaffsByName(string name)
        {
            Staffs staffs = new Staffs();
            staffs.LoadByName(name);
            return staffs;
        }

        public static Applicants GetApplicants(string name)
        {
            Applicants Applicants = new Applicants();
            Applicants.LoadByName(name);
            return Applicants;
        }
        public static Staff GetStaff(int staffId)
        {
            Staff staff = new Staff();
            staff.Load(staffId);
            return staff;
        }


        public static Continents GetContinents()
        {
            Continents continents = new Continents();
            continents.Load();
            return continents;
        }

        public static Continent GetContinent(int continentid)
        {
            Continent continent = new Continent();
            continent.Load(continentid);
            return continent;
        }

        public static Countries GetCountries()
        {
            Countries countries = new Countries();
            countries.Load();
            return countries;
        }

        public static MaritalStatuses GetmaritalStatus()
        {
            MaritalStatuses countries = new MaritalStatuses();
            countries.Load();
            return countries;
        }

        public static RNMUMemberRoles GetRNMUMemberRoles()
        {
            RNMUMemberRoles RNMUMemberRole = new RNMUMemberRoles();
            RNMUMemberRole.LoadMemberRole();
            return RNMUMemberRole;
        }

        public static RNMUMemberRoles GetMEMBERUSER()
        {
            RNMUMemberRoles RNMUMemberRole = new RNMUMemberRoles();
            RNMUMemberRole.LoadMEMBERUSER();
            return RNMUMemberRole;
        }

        public static RNMUMemberRoles GetMemberRoleArrear()
        {
            RNMUMemberRoles RNMUMemberRole = new RNMUMemberRoles();
            RNMUMemberRole.LoadMemberRoleArrear();
            return RNMUMemberRole;
        }

        public static Countries GetContinentCountries(int continentid)
        {
            Countries countries = new Countries();
            countries.LoadContinentCountries(continentid);
            return countries;
        }

        public static Country GetCountry(int id)
        {
            Country country = new Country();
            country.Load(id);
            return country;
        }

        public static Country GetCountry(string isoAlpha2Code)
        {
            Country country = new Country();
            country.Load(isoAlpha2Code);
            return country;
        }

        public static Country GetCountryByISO3(string isoAlpha3Code)
        {
            Country country = new Country();
            country.LoadByISO3(isoAlpha3Code);
            return country;
        }

        public static BankAccounts GetBankAccounts()
        {
            BankAccounts accounts = new BankAccounts();
            accounts.Load();
            return accounts;
        }

        public static BankAccount GetBankAccount(int id)
        {
            BankAccount account = new BankAccount();
            account.Load(id);
            return account;
        }

        public static Banks GetBanks()
        {
            Banks banks = new Banks();
            banks.Load();
            return banks;
        }

        public static Bank GetBank(int id)
        {
            Bank bank = new Bank();
            bank.Load(id);
            return bank;
        }


        public static institutioncategories Getinstitutioncategories()
        {
            institutioncategories institutioncategories = new institutioncategories();
            institutioncategories.Load();
            return institutioncategories;
        }

        public static institutioncategory Getinstitutioncategory(int id)
        {
            institutioncategory institutioncategory = new institutioncategory();
            institutioncategory.Load(id);
            return institutioncategory;
        }

        public static Currencys GetCurrencys()
        {
            Currencys currencys = new Currencys();
            currencys.Load();
            return currencys;
        }

        public static Currency GetCurrency(int id)
        {
            Currency currency = new Currency();
            currency.Load(id);
            return currency;
        }



        public static Contributions GetContributionsForMember(int staffId)
        {
            Contributions contributions = new Contributions();
            contributions.LoadForMember(staffId);
            return contributions;
        }

        public static Contributions GetContributions()
        {
            Contributions contributions = new Contributions();
            contributions.Load();
            return contributions;
        }

        public static System.Data.DataTable GetContributions(int staffId)
        {
            Contributions contributions = new Contributions();
            return contributions.LoadContributions(staffId);
        }

        public static System.Data.DataTable GetAnnulContributions()
        {
            Contributions contributions = new Contributions();
            return contributions.LoadAnnulContributions();
        }

        public static Contributions GetContributionsForPeriod(DateTime from, DateTime to)
        {
            Contributions contributions = new Contributions();
            contributions.LoadForPeriod(from, to);
            return contributions;
        }

        public static Contribution GetContribution(long id)
        {
            Contribution contribution = new Contribution();
            contribution.Load(id);
            return contribution;
        }


        #endregion

    }
}

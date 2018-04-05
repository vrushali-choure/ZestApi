using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_ZEST.Models
{
    public class AuthenticationResponse
    {
        public int EmpID { get; set; }
     
   
        //public string MiddleName { get; set; }
        //public string LastName { get; set; }
        //public string EmployeePhoto { get; set; }
        //public string Email { get; set; }
        //public string Designation { get; set; }
        //public string Status { get; set; }
        //public string Level { get; set; }
        //public string Reporting { get; set; }
        //public string JoinDate { get; set; }
        //public string BirthDate { get; set; }
        //public string BloodGroup { get; set; }
        //public string AvgOfficeHrs { get; set; }
        //public string AvgTimeSheetHrs { get; set; }
        //public string LastFreezingDate { get; set; }
        public string AuthorizationToken { get; set; }
        //public List<EmployeeBirthDay> lstEmployeeBirthDay { get; set; }
        //public List<PolicyComponents> lstPolicyComponents { get; set; }
        //public MenuRights objMenuRights { get; set; }

    }

    public class EmployeeBirthDay
    {
        public int EmpID { get; set; }
        public string EmployeeName { get; set; }
        public string CurrentYearBirthDate { get; set; }

        public string EmployeePhoto { get; set; }
    }

    public class PolicyComponents
    {
        public string DisplayID { get; set; }
        public string ClosingBalance { get; set; }
        public int Display { get; set; }

    }

    public class MenuRights
    {
        public bool MyRequest { get; set; }
        public bool ApplyRequest { get; set; }
        public bool PMRequestApproval { get; set; }
        public bool HRRequestApproval { get; set; }
    }
    public class DashboardDetailsResponse
    {
        public List<EmployeeBirthDay> lstEmployeeBirthDay { get; set; }
        public List<PolicyComponents> lstPolicyComponents { get; set; }
    }
    public class AuthenticationAttendanceAPIResponse
    {
        public int UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AuthorizationToken { get; set; }
       
    }
    public class AuthenticateUserCredentialsResponse
    {
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string ReportingLevel1 { get; set; }
        public string EmployeeStatus { get; set; }
        public bool IsAuthenticUser { get; set; }
    }

}
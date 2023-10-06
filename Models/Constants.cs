namespace PlatformService.Models;

public struct Constants
{
    #region Routes

    public struct Routes
    {
        public const string ApiController = "api/v1/";
        public const string Action = "[action]";
        public const string Controller = "[controller]";

        //Auth
        public const string RefreshToken = "refresh-token";
        public const string RevokeAll = "revoke-all";

    }

    #endregion

    #region DbConnection Constants

    public struct DBConnection
    {
        public const string DefaultConnnectId = "DefaultConnection";
    }

    #endregion

    #region Author Constants

    public struct Author
    {
        public const string Ifeanyi = "Ifeanyi Odom";
    }

    #endregion

    #region ResponseMessages Constants

    public struct ResponseMessages
    {
        
    }

    #endregion

    #region Default Constants

    public struct Default
    {
        public const string Jwt = "jwt";
        public const string Cookie_Role = "cookie_role";
        public const string Name = "name";
        public const string AppSettings = "AppSettings";
        public const string MailSettings = "MailSettings";
        public const string DefaultConnection = "DefaultConnection";
        public const string AppSettingJson = "appsettings.json";
        public const string ContactUsEmail = "contactus@fintechgirl.org";
        public const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public const string CustomAuthorization = "CustomAuthorization";
    }

    #endregion

    #region ErrorMessages Constants

    public struct ErrorMessages
    {
       // public const string RegisterControllerError = "Error in [Register] Method ==> RegistrationController";
       
    }

    #endregion

    #region Table Constants

    public struct Table
    {
   
    }

    #endregion

    #region Specific Origins Policy

    public class AllowSpecificOriginsPolicy
    {
        //public static readonly string[] Policies = { "http://127.0.0.1:5173", "https://127.0.0.1:5173", "https://localhost:5173", "http://localhost:5173", " http://localhost:3000" };
        public static readonly string[] Policies =
        {
            "http://localhost:3000", "https://localhost:3000", "https://hammerhead-app-vxnv4.ondigitalocean.app/",
            "http://127.0.0.1:5173", "https://127.0.0.1:5173", "https://localhost:5173", "http://localhost:5173",
            " http://localhost:3000"
        };
    }

    #endregion
}
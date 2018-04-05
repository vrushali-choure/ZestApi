using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPi_HRInnova.Helpers
{
    public static class ConfigurationHelper
    {
        #region ' Declarations '

        /// <summary>
        /// The sync root.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The _instance.
        /// </summary>
        private static volatile NameValueCollection instance;

        /// <summary>
        /// Gets the app settings.
        /// </summary>
        public static NameValueCollection AppSettings
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NameValueCollection
                                           {
                                               ConfigurationManager.AppSettings,
                                               (NameValueCollection)
                                               ConfigurationManager.GetSection("secureAppSettings") ?? new NameValueCollection()
                                           };
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the connection strings.
        /// </summary>
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                return ConfigurationManager.ConnectionStrings;
            }
        }

        #endregion ' Declarations '

        #region ' SMTP Region '

        public static string BPOSupportmail
        {
            get
            {
                return Convert.ToString(AppSettings["BPOSupportmail"]);
            }
        }

        public static string SMTPServer
        {
            get
            {
                return Convert.ToString(AppSettings["SMTPServer"]);
            }
        }

        public static string SMTPUsername
        {
            get
            {
                return Convert.ToString(AppSettings["SMTPUsername"]);
            }
        }

        public static string SMTPPassword
        {
            get
            {
                return Convert.ToString(AppSettings["SMTPPassword"]);
            }
        }

        public static string FromDisplayName
        {
            get
            {
                return Convert.ToString(AppSettings["FromDisplayName"]);
            }
        }

        public static int SMTPPort
        {
            get
            {
                return Convert.ToInt32(AppSettings["SMTPPort"]);
            }
        }

        public static bool SMTPUseDefaultCredentials
        {
            get
            {
                return Convert.ToBoolean(AppSettings["SMTPUseDefaultCredentials"]);
            }
        }

        public static bool SMTPEnableSsl
        {
            get
            {
                return Convert.ToBoolean(AppSettings["SMTPEnableSsl"]);
            }
        }

        #endregion ' SMTP Region '

        #region ' SMS Region '

        /// <summary>
        /// Gets the name of the SMS gateway user.
        /// </summary>
        /// <value>
        /// The name of the SMS gateway user.
        /// </value>
        public static string SmsGatewayUserName
        {
            get
            {
                return AppSettings["SMSGatewayUserName"];
            }
        }

        /// <summary>
        /// Gets the SMS gateway password.
        /// </summary>
        /// <value>
        /// The SMS gateway password.
        /// </value>
        public static string SmsGatewayPassword
        {
            get
            {
                return AppSettings["SMSGatewayPassword"];
            }
        }

        /// <summary>
        /// Gets the is send SMS.
        /// </summary>
        /// <value>
        /// The is send SMS.
        /// </value>
        public static string IsSendSms
        {
            get
            {
                return AppSettings["IsSendSMS"];
            }
        }

        /// <summary>
        /// Gets the SMS sender identifier.
        /// </summary>
        /// <value>
        /// The SMS sender identifier.
        /// </value>
        public static string SMSSenderId
        {
            get { return AppSettings["SMSSenderId"]; }
        }

        /// <summary>
        /// Gets the SMS gateway URL.
        /// </summary>
        /// <value>
        /// The SMS gateway URL.
        /// </value>
        public static string SmsGatewayUrl
        {
            get
            {
                return AppSettings["SMSGatewayURL"];
            }
        }

        #endregion ' SMS Region '

       
        public static string AllowedCrossDomain
        {
            get
            {
                return AppSettings["AllowedCrossDomain"];
            }
        }

        public static string EnableServiceEncryption
        {
            get
            {
                return AppSettings["EnableServiceEncryption"];
            }
        }

        public static string TokenExpiryInMinutes
        {
            get
            {
                return AppSettings["TokenExpiryInMinutes"];
            }
        }

        
        /// <summary>
        /// Gets the google URL shortner API key.
        /// </summary>
        /// <value>
        /// The google URL shortner API key.
        /// </value>
        public static string GoogleUrlShortnerApiKey
        {
            get
            {
                return AppSettings["GoogleUrlShortnerApiKey"];
            }
        }

        public static string PublicAPIUrl
        {
            get
            {
                return AppSettings["PublicAPIUrl"];
            }
        }

        public static int CookieExpireTimeInMinutes
        {
            get
            {
                return int.Parse(AppSettings["CookieExpireTimeInMinutes"]);
            }
        }

        public static string GetAmazonS3RootPath
        {
            get
            {
                return Convert.ToString(AppSettings["AWSImagePath"]);
            }
        }

        public static string AwsAccessKey
        {
            get
            {
                return AppSettings["AwsAccessKey"];
            }
        }

        public static string AwsSecretKey
        {
            get
            {
                return AppSettings["AwsSecretKey"];
            }
        }

        public static string AwsBucket
        {
            get
            {
                return AppSettings["AwsBucket"];
            }
        }

        public static string AwsDomain
        {
            get
            {
                return AppSettings["AwsDomain"];
            }
        }

        /// <summary>
        /// Gets the payment disclaimer.
        /// </summary>
        /// <value>
        /// The payment disclaimer.
        /// </value>
        public static string PaymentDisclaimer
        {
            get { return AppSettings["PaymentDisclaimer"]; }
        }

        public static string StoreReOpenWithReopenDateForOrder
        {
            get
            {
                return AppSettings["StoreReOpenWithReopenDateForOrder"];
            }
        }

        public static string StoreReOpenWithoutReopenDateForOrder
        {
            get
            {
                return AppSettings["StoreReOpenWithoutReopenDateForOrder"];
            }
        }

        public static string StoreReOpenWithReopenDateForInquiry
        {
            get
            {
                return AppSettings["StoreReOpenWithReopenDateForInquiry"];
            }
        }

        public static string StoreReOpenWithoutReopenDateForInquiry
        {
            get
            {
                return AppSettings["StoreReOpenWithoutReopenDateForInquiry"];
            }
        }

        public static string BpoEmailId
        {
            get { return AppSettings["BPOEmailId"]; }
        }

        public static string PlacedInquiryNotificationUrl
        {
            get { return AppSettings["PlacedInquiryNotificationUrl"]; }
        }

        public static string GCMServerApiKey
        {
            get
            {
                return AppSettings["GCMServerApiKey"];
            }
        }

        public static string APNCertificatePath
        {
            get
            {
                return AppSettings["APNCertificatePath"];
            }
        }

        public static string APNCertificatePassword
        {
            get
            {
                return AppSettings["APNCertificatePassword"];
            }
        }

        public static bool AppleProductionNotification
        {
            get
            {
                return Convert.ToBoolean(AppSettings["AppleProductionNotification"]);
            }
        }

        public static int EmailTimerInterval
        {
            get
            {
                return Convert.ToInt32(AppSettings["EmailTimerInterval"]); ;
            }
        }

        public static bool AllowSendEmailJob
        {
            get
            {
                return Convert.ToBoolean(AppSettings["AllowSendEmailJob"]);
            }
        }

        public static int SMSTimerInterval
        {
            get
            {
                return Convert.ToInt32(AppSettings["SMSTimerInterval"]); ;
            }
        }

        public static bool AllowSendSMSJob
        {
            get
            {
                return Convert.ToBoolean(AppSettings["AllowSendSMSJob"]);
            }
        }

        public static bool AllowMerchantOrderReminderPushJob
        {
            get { return Convert.ToBoolean(AppSettings["AllowMerchantOrderReminderPushJob"]); }
        }

        public static bool ResetMerchantOrderReminderTime
        {
            get { return Convert.ToBoolean(AppSettings["ResetMerchantOrderReminderTime"]); }
        }

        public static bool AllowLocationSuggestionJob
        {
            get
            {
                return Convert.ToBoolean(AppSettings["AllowLocationSuggestionJob"]);
            }
        }

        public static string LocationSuggestionTimeInterval
        {
            get
            {
                return AppSettings["LocationSuggestionTimeInterval"];
            }
        }

        public static string DisplayName
        {
            get
            {
                return AppSettings["DisplayName"];
            }
        }

        public static string ServiceName
        {
            get
            {
                return AppSettings["ServiceName"];
            }
        }

        public static bool AllowSendNotificationJob
        {
            get { return Convert.ToBoolean(AppSettings["AllowSendNotificationJob"]); }
        }

        public static bool AllowCancelOrderNotificationWarningJob
        {
            get
            {
                return Convert.ToBoolean(AppSettings["AllowCancelOrderNotificationWarningJob"]);
            }
        }

        public static bool AllowMerchantCancelOrderJob
        {
            get
            {
                return Convert.ToBoolean(AppSettings["AllowMerchantCancelOrderJob"]);
            }
        }

        public static int DefaultCancelOrderDaysLimit
        {
            get { return Convert.ToInt16(AppSettings["DefaultCancelOrderDaysLimit"]); }
        }

        public static int DefaultCancelOrderWarningHours
        {
            get { return Convert.ToInt16(AppSettings["DefaultCancelOrderWarningHours"]); }
        }

        public static int NotificationTimerInterval
        {
            get
            {
                return Convert.ToInt32(AppSettings["NotificationTimerInterval"]); ;
            }
        }

        public static string AppId
        {
            get
            {
                return AppSettings["AppId"];
            }
        }

        /// <summary>
        /// Gets the store ids.
        /// </summary>
        public static List<string> StoresWithDiffSMSFormat
        {
            get
            {
                if (ConfigurationManager.AppSettings["StoresWithDiffSMSFormat"] != null)
                {
                    var ids = ConfigurationManager.AppSettings["StoresWithDiffSMSFormat"].Split(',').ToList();
                    return ids;
                }

                return new List<string>();
            }
        }

        public static double UserImageWidth
        {
            get
            {
                var userImageWidth = AppSettings["UserImageWidth"];
                return userImageWidth != null ? Convert.ToDouble(userImageWidth) : 100;
            }
        }

        public static double UserImageHeight
        {
            get
            {
                var userImageHeight = AppSettings["UserImageHeight"];
                return userImageHeight != null ? Convert.ToDouble(userImageHeight) : 100;
            }
        }

        public static double StoreLogoWidth
        {
            get
            {
                var storeLogoWidth = AppSettings["StoreLogoWidth"];
                return storeLogoWidth != null ? Convert.ToDouble(storeLogoWidth) : 300;
            }
        }

        public static double StoreLogoHeight
        {
            get
            {
                var storeLogoHeight = AppSettings["StoreLogoHeight"];
                return storeLogoHeight != null ? Convert.ToDouble(storeLogoHeight) : 100;
            }
        }

        public static double CoverImageWidth
        {
            get
            {
                var coverImageWidth = AppSettings["CoverImageWidth"];
                return coverImageWidth != null ? Convert.ToDouble(coverImageWidth) : 320;
            }
        }

        public static double CoverImageHeight
        {
            get
            {
                var coverImageHeight = AppSettings["CoverImageHeight"];
                return coverImageHeight != null ? Convert.ToDouble(coverImageHeight) : 180;
            }
        }

        public static double ProductImageWidth
        {
            get
            {
                var productImageWidth = AppSettings["ProductImageWidth"];
                return productImageWidth != null ? Convert.ToDouble(productImageWidth) : 1600;
            }
        }

        public static double ProductImageHeight
        {
            get
            {
                var productImageHeight = AppSettings["ProductImageHeight"];
                return productImageHeight != null ? Convert.ToDouble(productImageHeight) : 900;
            }
        }

        public static long ImageQuality
        {
            get
            {
                return Convert.ToInt64(AppSettings["ImageQuality"]);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is payment logging on.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is payment logging on; otherwise, <c>false</c>.
        /// </value>
        public static bool IsPaymentLoggingOn
        {
            get
            {
                return Convert.ToBoolean(AppSettings["IsPaymentLoggingOn"]);
            }
        }

        public static List<string> HideDemoStoreIds
        {
            get
            {
                if (!string.IsNullOrEmpty(AppSettings["CygnetStoresID"]))
                {
                    var ids = AppSettings["CygnetStoresID"].Split(',').ToList();
                    return ids;
                }

                return new List<string>();
            }
        }
        public static string StoreDefaultPassword
        {
            get
            {
                return AppSettings["StoreDefaultPassword"];
            }
        }

        public static string RegistrationMailFrom
        {
            get
            {
                return AppSettings["RegistrationMailFrom"];
            }
        }

        public static string ProductLogInURL
        {
            get
            {
                return AppSettings["ProductLogInURL"];
            }
        }

        public static string ProductForgotPasswordURL
        {
            get
            {
                return AppSettings["ProductForgotPasswordURL"];
            }
        }

        #region QuickBlox Configuration

        public static int QuickBloxAppId
        {
            get
            {
                return Convert.ToInt32(AppSettings["QuickBloxAppId"]);
            }
        }

        public static string QuickBloxAuthKey
        {
            get
            {
                return AppSettings["QuickBloxAuthKey"];
            }
        }

        public static string QuickBloxAuthSecret
        {
            get
            {
                return AppSettings["QuickBloxAuthSecret"];
            }
        }

        public static string QuickBloxDefaultPassword
        {
            get
            {
                return AppSettings["QuickBloxDefaultPassword"];
            }
        }

        public static string QuickBloxApiUrl
        {
            get
            {
                return AppSettings["QuickBloxApiUrl"];
            }
        }

        public static string QuickBloxChatUrl
        {
            get
            {
                return AppSettings["QuickBloxChatUrl"];
            }
        }

        #endregion
    }

}

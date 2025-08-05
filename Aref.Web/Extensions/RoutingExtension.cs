namespace Aref.Web.Extensions;

public static class RoutingExtension
{
    public static class Admin
    {
        #region Account

        public static class Account
        {
            public const string Login = "login";
            public const string Logout = "logout";
        }

        #endregion
    }
    

    public static class Site
    {
        #region AboutUs

        public const string AboutUs = "about-us";

        #endregion

        #region Account

        public static class Account
        {
            public const string Login = "login";
            public const string Logout = "logout";
            public const string ConfirmOtp = "confirm-otp";

            public static class Activation
            {
                private const string BaseUrl = "activation";

                public const string Account = BaseUrl + "account";
                public const string Confirm = BaseUrl + "confirm";
            }

            public static class Resend
            {
                private const string BaseUrl = "resend-";

                public const string Otp = BaseUrl + "otp/{userId}";
            }
        }

        #endregion
        
        #region Blog

        public static class Blog
        {
            public const string List = "blogs"; 
            public const string Detail = List + "/{slug}";     
            public const string ShortLink = "b/{id}";     
        }

        #endregion
        
        #region Consult

        public const string Consult = "consult";

        #endregion
        
        #region ContactUs

        public const string ContactUs = "contact-us";

        #endregion
        
        #region DynamicPages

        public const string DynamicPage = "pages/{slug}"; 

        #endregion

        #region Faq

        public const string Faq = "faq";

        #endregion

        #region Honnor  

        public static class Honor
        {
            public const string List = "honors";
            public const string Detail = List + "/{slug}";   
        }

        #endregion

        #region Job

        public static class Job
        {
            public const string List = "jobs";
            public const string Detail = List + "/{slug}";
            public const string ShortLink = "j/{id}";   
        }

        #endregion

        #region Order

        public static class Order
        {
            public const string Create = "create-order";   
        }

        #endregion
        
        #region OuServices

        public static class OurServices
        {
            public const string List = "services";     
            public const string Detail = List + "/{slug}";     
        }

        #endregion
        
        #region Project

        public static class Project
        {
            public const string List = "projects";     
            public const string Detail = List + "/{id}/{slug}";     
        }

        #endregion

        #region UserPosition

        public const string UserPosition = "team-members";      

        #endregion
        
        #region Errors

        public const string NotFound = "/not-found";
        public const string ServerError = "/server-error";

        #endregion
    }
}
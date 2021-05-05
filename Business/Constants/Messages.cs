using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserNotFound = "User not found";

        public static string PasswordError = "Wrong Password";

        public static string UserAlreadyExists = "User Already Exists";

        public static string UserRegistered = "Success User Registered";

        public static string LoginSuccess = "Successfully";

        public static string AuthorizationDenied = "Authorization Denied";

        public static string ImageLimitExceeded = "Limit exceeded";

        public static string PasswordChanged = "Password Changed";
    }
}

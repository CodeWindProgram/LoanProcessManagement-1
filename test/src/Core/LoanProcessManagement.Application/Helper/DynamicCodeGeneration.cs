using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Helper
{
    #region created class for generating dynamic string by - Ramya Guduru - 01/11/2021
    /// <summary>
    /// it generates dynamic string with the length 9. to update user password with this dynamic string in database.
    /// </summary>
    public static class DynamicCodeGeneration
    {
        public static string GeneratePassword()
        {
            string strPwdchar = "abcdefghijklmnopqrstuvwxyz0123456789#+@&$ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder strPwd = new StringBuilder(string.Empty);
            Random rnd = new Random();
            for (int i = 0; i <= 8; i++)
            {
                int iRandom = rnd.Next(0, strPwdchar.Length - 1);
                strPwd.Append(strPwdchar.Substring(iRandom, 1));
            }
            return strPwd.ToString();
        }
    }
    #endregion
}

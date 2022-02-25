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
            string strPwdchar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder strPwd = new StringBuilder(string.Empty);
            Random rnd = new Random();
            for (int i = 0; i <= 2; i++)
            {
                int iRandom = rnd.Next(0, strPwdchar.Length - 1);
                strPwd.Append(strPwdchar.Substring(iRandom, 1));
            }
            string strPwdsmall = "abcdefghijklmnopqrstuvwxyz";
            
            for (int i = 0; i <= 2; i++)
            {
                int iRa = rnd.Next(0, strPwdsmall.Length - 1);
                strPwd.Append(strPwdsmall.Substring(iRa, 1));
            }

            string strPwddigi = "0123456789";
            for (int i = 0; i <= 1; i++)
            {
                int iRandoms = rnd.Next(0, strPwddigi.Length - 1);
                strPwd.Append(strPwddigi.Substring(iRandoms, 1));
            }
            
            return strPwd.ToString();
        }
    }
    #endregion
}

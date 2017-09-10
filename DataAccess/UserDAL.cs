using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class UserDAL
    {
        private const string tableName = "T_BASE_USER";
        public User GetUserById(int id)
        {
            var user = new User();
            string sql = @"SELECT Id,BUSurname,BUGivenname,BUJobNumber,BUSex,BUAvatars,BUPhoneNum,BUEmail,BUDepartId,BUIsValid FROM " + tableName
                + "WHERE Id=@Id";
            var para = new SqlParameter("@Id", id);
            using (var dr = SqlHelper.ExecuteReader(SqlHelper.connectionString, CommandType.Text, sql, para))
            {
                if (dr.Read())
                {
                    user.Id = Convert.ToInt32(dr["Id"]);
                    user.BUSurname = dr["BUSurname"].ToString();
                    user.BUGivenname = dr["BUGivenname"].ToString();
                    user.BUJobNumber = dr["BUJobNumber"].ToString();
                    user.BUSex = Convert.ToInt32(dr["BUSex"]);
                    user.BUAvatars = dr["BUAvatars"].ToString();
                    user.BUPhoneNum = dr["BUPhoneNum"].ToString();
                    user.BUEmail = dr["BUEmail"].ToString();
                    user.BUDepartId = Convert.ToInt32(dr["BUDepartId"]);
                    user.BUIsValid = Convert.ToInt32(dr["BUIsValid"]);
                }
                else
                {
                    user = null;
                }
            }
            return user;
        }
    }
}

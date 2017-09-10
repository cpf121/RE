using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 描述:用户基础信息
    /// 创建标识：cpf23568
    /// 创建时间：2017-9-10 17:56:19
    /// </summary>
    public class UserInfoModel
    {
        public int UserId { get; set; }

        public string Surname { get; set; }

        public string Givenname { get; set; }

        public string JobNumber { get; set; }

        public int Sex { get; set; }

        public string Avatars { get; set; }

        public string PhoneNum { get; set; }

        public string Email { get; set; }

        public int DepartId { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User
    {
        public int Id { get; set; }

        public string BUSurname { get; set; }
        
        public string BUGivenname { get; set; }

        public string BUJobNumber { get; set; }

        public int BUSex { get; set; }

        public string BUAvatars { get; set; }

        public string BUPhoneNum { get; set; }

        public string BUEmail { get; set; }

        public int BUDepartId { get; set; }

        public int BUCreateUserId { get; set; }

        public string BUCreateUserName { get; set; }

        public DateTime BUCreateTime { get; set; }

        public int BUOperateUserId { get; set; }

        public string BUOperateUserName { get; set; }

        public DateTime BUOperateTime { get; set; }

        public int BUIsValid { get; set; }
    }
}

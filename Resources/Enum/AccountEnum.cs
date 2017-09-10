using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonFunciton.Enum
{
    public enum AccountType
    {
        [Description("管理员")]
        Admin=1,

        [Description("员工")]
        Employee=2,
    }
}

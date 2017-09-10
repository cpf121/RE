using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonFunciton.Enum
{
    public enum EnabledEnum
    {
        /// <summary>
        /// 是
        /// </summary>
        [Description("有效")]
        Enabled = 1,

        /// <summary>
        /// 否
        /// </summary>
        [Description("无效")]
        UnEnabled = 0,
    }
}

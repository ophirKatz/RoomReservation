using System.ComponentModel;

namespace Common.Enums
{
    public enum UserClearance
    {
        [Description("בסיסי")]
        Basic,
        [Description("מתקדם")]
        Advanced,
        [Description("אדמין")]
        Admin
    }
}
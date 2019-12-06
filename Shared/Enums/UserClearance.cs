using System.ComponentModel;

namespace Shared.Enums
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
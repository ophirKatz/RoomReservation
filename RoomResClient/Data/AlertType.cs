using System.ComponentModel;

namespace RoomResClient.Data
{
    public enum AlertType
    {
        [Description("שגיאה")]
        Error,
        [Description("אזהרה")]
        Warning,
        [Description("מידע")]
        Info,
        [Description("הצלחה")]
        Success
    }
}
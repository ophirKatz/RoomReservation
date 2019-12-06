using Shared.Enums;
using EnumsNET;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbEntities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public UserClearance UserClearance { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Username)}: {Username}, {nameof(UserClearance)}: {UserClearance.GetName()}";
        }
    }
}
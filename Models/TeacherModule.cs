using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Institute_Management.Models
{
    public class TeacherModule
    {
        public class Teacher
        {
            [Key]
            public int TeacherId { get; set; }
            public int UserId { get; set; }
            public string SubjectSpecialization { get; set; }

            [ForeignKey("UserId")]
            public UserModule.User User { get; set; }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace varsity.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
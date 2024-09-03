using buecherschosch_service.Enums;

namespace buecherschosch_service.Models
{
    public class LanguageJson
    {
        public string LanguageString { get; set; }
        public Language Language { get; set; }

        public LanguageJson(Language language)
        {
            this.Language = language;
            this.LanguageString = language.ToString();
        }
    }
}
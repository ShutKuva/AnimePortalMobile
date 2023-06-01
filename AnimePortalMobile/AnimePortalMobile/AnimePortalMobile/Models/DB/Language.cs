namespace AnimePortalMobile.Models.Db
{
    public class Language : BaseEntity
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => _name = value.ToLower();
        }
    }
}

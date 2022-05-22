namespace MauiApp1.MVVM.Models
{
    internal class UserProfile
    {
        public UserProfile() { }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public IList<UserImage> Images { get; set; } = new List<UserImage>();
        public string About { get; set; }
        public string Education { get; set; }
        public string Job { get; set; }
        public IList<Question> PersonalInfo { get; set; } = new List<Question>();
        public IList<Artist> Artists { get; set; } = new List<Artist>();
        public string Films { get; set; }
        public string Books { get; set; }

    }
}

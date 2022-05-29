namespace MauiApp1.MVVM.Models
{
    public class UserImage
    {
        public UserImage() 
        {
            ImagePath=string.Empty;
            Title = string.Empty;
        }

        public string ImagePath { get; set; }
        public string Title { get; set; }

    }
}

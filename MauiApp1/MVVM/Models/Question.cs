namespace MauiApp1.MVVM.Models
{
    public class Question
    {
        public string Text { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public int SelectedId { get; set; }
    }
}

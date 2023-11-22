using System;
using System.Windows.Media.Imaging;

namespace Bilding
{
    public class Question//класс определения вопроса
    {
        public BitmapImage Picture { get; set; }
        public string Answer { get; set; }
        public Question(string PathBitmapImageSource, string AnswerSource)
        {
            this.Picture = new BitmapImage();
            this.Picture.BeginInit();
            this.Picture.UriSource = new Uri(PathBitmapImageSource, UriKind.Relative);
            this.Picture.EndInit();
            this.Answer = AnswerSource;
        }
    }
}

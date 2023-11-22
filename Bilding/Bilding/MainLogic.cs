using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bilding
{
    class MainLogic//основная логика программы
    {
        private StackPanel spAnswers;//стек панель
        Image image;//картинка
        public static string currentAnswer;//ответы
        QuestionDb data;//данные со всеми вопросами

        public TextBlock CreateTb(string txt, StackPanel ToSp)
        {
            var tb = new TextBlock()
            {
                Text = txt,
                FontSize = 25,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(3),
                Background = Brushes.Coral,
                Width = 30,
                Height = 40,
            };
            //добавление буквы
            tb.MouseDown += (s, e) =>
              {
                  ToSp.Children.Add(CreateTbAlp((s as TextBlock).Text, ToSp));
                  CheckAnswer();
              };
            return tb;
        }

        public TextBlock CreateTbAlp(string txt, StackPanel stackPanel)
        {
            var tb = new TextBlock()
            {
                Text = txt,
                FontSize = 30,
                Background = Brushes.LightBlue,
                Margin = new Thickness(3),
                Padding = new Thickness(10),
            };
            //удаление буквы
            tb.MouseDown += (s, e) =>
            { stackPanel.Children.Remove((s as TextBlock)); };
            return tb;
        }
        public void CheckAnswer()//проверка ответа
        {
            string word = String.Empty;
            foreach (var e in spAnswers.Children) word += (e as TextBlock).Text;
            if (word == currentAnswer){
                LoadNewQuestion();
                MessageBox.Show("Верно!");
            }
        }
        private void LoadNewQuestion()//загрузка нового вопроса
        {
            var q = data.CurrentQuestion;
            image.Source = q.Picture;
            currentAnswer = q.Answer;
            spAnswers.Children.Clear();
        }
        public MainLogic(StackPanel SPAlphabet, StackPanel SPAnswer, Image ImageView)
        {
            data = new QuestionDb();
            image = ImageView;
            spAnswers = SPAnswer;
            for (int i = (int)'а'; i <= (int)'я'; i++)
            {
                SPAlphabet.Children.Add(CreateTb($"{(char)i}", SPAnswer));
                if(i==(int)'е') { SPAlphabet.Children.Add(CreateTb($"{'ё'}", SPAnswer)); } 
            }
            LoadNewQuestion();
        }
    }
}

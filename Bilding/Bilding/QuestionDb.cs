using System.Collections.Generic;
using System.IO;

namespace Bilding
{
    class QuestionDb//класс для хранения всех вопросов
    {
        private List<Question> db;
        private int index;
        public Question CurrentQuestion
        {
            get
            {
                index++;
                return db[index % db.Count];
            }
        }
        public QuestionDb()
        {
            this.db = new List<Question>();
            this.index = 0;
            var dataFile = File.ReadAllLines(@"..\..\Image\test.txt");
            foreach(var e in dataFile)
            {
                var args = e.Split('|');
                db.Add(new Question(args[0], args[1]));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Xml;

namespace UP6
{
    public class Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class Question
    {
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public List<Answer> Answers { get; set; } = new();

        // Несколько правильных ответов
        public List<int> CorrectIndices => Answers
            .Select((a, i) => (a, i))
            .Where(x => x.a.IsCorrect)
            .Select(x => x.i)
            .ToList();
    }

    public class Level
    {
        public int Difficulty { get; set; }
        public List<Question> Questions { get; set; } = new();
    }

    public class Topic
    {
        public string Name { get; set; }
        public List<Level> Levels { get; set; } = new();
        public int CurrentLevel { get; set; } = 1; // прогресс игрока
    }

    internal class XmlLoader
    {
        private XmlReader _reader;
        private string _path;

        public List<Topic> Load(string filePath)
        {
            _path = Path.GetDirectoryName(filePath);
            _reader = XmlReader.Create(filePath);
            var topics = new List<Topic>();

            while (_reader.Read())
            {
                if (_reader.Name == "topic" && _reader.NodeType == XmlNodeType.Element)
                    topics.Add(ReadTopic());
            }

            return topics;
        }

        private Topic ReadTopic()
        {
            var topic = new Topic { Name = _reader.GetAttribute("name") };

            while (_reader.Read())
            {
                if (_reader.Name == "topic" && _reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (_reader.Name == "level" && _reader.NodeType == XmlNodeType.Element)
                    topic.Levels.Add(ReadLevel());
            }

            return topic;
        }

        private Level ReadLevel()
        {
            var level = new Level
            {
                Difficulty = int.Parse(_reader.GetAttribute("difficulty"))
            };

            while (_reader.Read())
            {
                if (_reader.Name == "level" && _reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (_reader.Name == "q" && _reader.NodeType == XmlNodeType.Element)
                    level.Questions.Add(ReadQuestion());
            }

            return level;
        }

        private Question ReadQuestion()
        {
            var q = new Question
            {
                Text = _reader.GetAttribute("text"),
                ImagePath = _reader.GetAttribute("src") is { Length: > 0 } src
                            ? Path.Combine(_path, src) : null
            };

            while (_reader.Read())
            {
                if (_reader.Name == "q" && _reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (_reader.Name == "a" && _reader.NodeType == XmlNodeType.Element)
                {
                    bool isCorrect = _reader.GetAttribute("right") == "yes";
                    _reader.Read(); // читаем текст ответа
                    q.Answers.Add(new Answer { Text = _reader.Value, IsCorrect = isCorrect });
                }
            }

            return q;
        }
    }

    public class TestSession
    {
        private const int QuestionsPerSession = 5;
        private const int PassScore = 80;

        private List<Question> _questions;
        private int _current = 0;
        public int Score { get; private set; } = 0;
        public bool IsOver => _current >= _questions.Count;
        public Question Current => _questions[_current];

        public TestSession(Level level)
        {
            _questions = level.Questions
                .OrderBy(_ => Random.Shared.Next())
                .Take(QuestionsPerSession)
                .ToList();
        }

        // selectedIndices — список отмеченных чекбоксов
        public bool Submit(List<int> selectedIndices)
        {
            var correct = Current.CorrectIndices.ToHashSet();
            bool ok = correct.SetEquals(selectedIndices);

            if (ok) Score += 100 / QuestionsPerSession; // 20 баллов за вопрос
            _current++;
            return ok;
        }

        public bool Passed() => Score >= PassScore;
    }
}

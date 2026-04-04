using System.Xml.Linq;

namespace UP6
{
    public partial class Form1 : Form
    {
        private string _xmlPath = "C:\\Users\\Alex\\Desktop\\УП\\UP6\\UP6\\test.xml";
        private string _topic = "Циклы"; 
        private int _level = 1;

        // Вопросы текущей сессии
        private List<(string Text, List<(string Text, bool Right)> Answers)> _questions = new();
        private int _current = 0; 
        private int _score = 0; 

        
        private Button[] _answerButtons = null!;

        public Form1()
        {
            InitializeComponent();

            _answerButtons = new[] { button1, button2, button3, button7 };


            SetGameVisible(false);
            label3.Text = _level.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_xmlPath))
            {
                MessageBox.Show("Файл test.xml не найден!");
                return;
            }

            LoadQuestions();

            if (_questions.Count == 0)
            {
                MessageBox.Show($"Нет вопросов для уровня {_level}");
                return;
            }

            _current = 0;
            _score = 0;
            button8.Enabled = false;

            SetGameVisible(true);
            button6.Visible = false;

            ShowQuestion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_current > 0)
            {
                _score -= 20;
                _current--;
                ShowQuestion();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_current < _questions.Count - 1)
            {
                if (IsRichtige()) _score += 20;
                _current++;
                ShowQuestion();
            }
            else
            {
                ShowResult();
            }
        }

        private void button1_Click(object sender, EventArgs e) => SelectAnswer(button1);
        private void button2_Click(object sender, EventArgs e) => SelectAnswer(button2);
        private void button3_Click(object sender, EventArgs e) => SelectAnswer(button3);
        private void button7_Click(object sender, EventArgs e) => SelectAnswer(button7);

        private void SelectAnswer(Button clicked)
        {
            if (clicked.BackColor == Color.LightGreen)
                clicked.BackColor = SystemColors.Control;
            else
                clicked.BackColor = Color.LightGreen;
        }

        private void LoadQuestions()
        {
            _questions.Clear();
            var doc = XDocument.Load(_xmlPath);

            var levelEl = doc.Root?
                .Element("topics")?
                .Elements("topic")
                .FirstOrDefault(t => t.Attribute("name")?.Value == _topic)?
                .Elements("level")
                .FirstOrDefault(l => l.Attribute("difficulty")?.Value == _level.ToString());

            if (levelEl == null) return;

            var all = levelEl.Elements("q").Select(q =>
            {
                var text = q.Attribute("text")?.Value ?? "";
                var answers = q.Elements("a")
                    .Select(a => (a.Value, a.Attribute("right")?.Value == "yes"))
                    .ToList();
                return (text, answers);
            }).ToList();

            _questions = all.OrderBy(_ => Random.Shared.Next()).Take(5).ToList();
        }

        private void ShowQuestion()
        {
            var (text, answers) = _questions[_current];

            label2.Text = $"[{_current + 1}/{_questions.Count}]  {text}";

            foreach (var btn in _answerButtons)
            {
                btn.BackColor = SystemColors.Control;
                btn.Visible = false;
                btn.Text = "";
            }

            var shuffled = answers.OrderBy(_ => Random.Shared.Next()).ToList();
            for (int i = 0; i < Math.Min(shuffled.Count, 4); i++)
            {
                _answerButtons[i].Text = shuffled[i].Text;
                _answerButtons[i].Tag = shuffled[i].Right; 
                _answerButtons[i].Visible = true;
            }

            button4.Enabled = _current > 0;
            button5.Text = _current == _questions.Count - 1
                ? "Завершить" : "-->";
        }

        private bool IsRichtige()
        {
            var correctSet = _answerButtons
                .Where(b => b.Visible && (bool)(b.Tag ?? false))
                .Select(b => b.Text).ToHashSet();

            var selectedSet = _answerButtons
                .Where(b => b.Visible && b.BackColor == Color.LightGreen)
                .Select(b => b.Text).ToHashSet();
            return correctSet.SetEquals(selectedSet);
        }
        private void ShowResult()
        {
            if (IsRichtige()) _score += 20; 

            bool passed = _score >= 80;

            MessageBox.Show(
                $"Тест завершён!\nСчёт: {_score}/100\n" +
                (passed ? "Уровень пройден!" : "Попробуй ещё раз"),
                "Результат"
            );
            button8.Enabled = passed && _level < 3;
            button6.Visible = true;
            SetGameVisible(false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _level++;
            label3.Text = _level.ToString();
            button8.Enabled = false;
        }

        private void SetGameVisible(bool visible)
        {
            label2.Visible = visible;
            label4.Visible = visible;
            button4.Visible = visible;
            button5.Visible = visible;
            foreach (var btn in _answerButtons ?? Array.Empty<Button>())
                btn.Visible = visible;
        }
    }
}
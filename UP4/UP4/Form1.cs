using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UP4
{
    public partial class Form1 : Form
    {
        private string _groupName = "";
        private List<string> _disciplines = new();
        private List<int> _fives = new(); 
        private List<int> _fours = new(); 
        private List<int> _threes = new(); 
        private List<int> _twos = new();
        private List<int> _noAttest = new(); 

        private TabControl tabControl;

        // Вкладка 1 — ввод
        private TextBox tbGroup;
        private TextBox tbDiscipline;
        private NumericUpDown numFives, numFours, numThrees, numTwos, numNoAttest;
        private Button btnAdd, btnClear;
        private ListBox lbDisciplines;

        // Вкладка 2 
        private DataGridView dgv;
        private Button btnSave, btnLoad;

        // Вкладка 3 
        private Chart chart;
        private Button btnDraw;

        public Form1()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Успеваемость по группе";
            Size = new Size(850, 600);
            StartPosition = FormStartPosition.CenterScreen;

            tabControl = new TabControl { Dock = DockStyle.Fill };
            var tab1 = new TabPage("Ввод данных");
            var tab2 = new TabPage("Таблица результатов");
            var tab3 = new TabPage("Диаграмма");

            tabControl.TabPages.Add(tab1);
            tabControl.TabPages.Add(tab2);
            tabControl.TabPages.Add(tab3);
            Controls.Add(tabControl);

            BuildTab1(tab1);
            BuildTab2(tab2);
            BuildTab3(tab3);
        }

        private void BuildTab1(TabPage tab)
        {
            var lblGroup = new Label { Text = "Номер группы:", Location = new Point(10, 15), AutoSize = true };
            tbGroup = new TextBox { Location = new Point(130, 12), Width = 150 };

            var lblDisc = new Label { Text = "Дисциплина:", Location = new Point(10, 50), AutoSize = true };
            tbDiscipline = new TextBox { Location = new Point(130, 47), Width = 200 };

            int y = 85;
            var labels = new[] { "Пятёрки:", "Четвёрки:", "Тройки:", "Двойки:", "Не аттест.:" };
            numFives = new NumericUpDown { Location = new Point(130, y), Width = 70, Minimum = 0, Maximum = 999 };
            numFours = new NumericUpDown { Location = new Point(130, y + 35), Width = 70, Minimum = 0, Maximum = 999 };
            numThrees = new NumericUpDown { Location = new Point(130, y + 70), Width = 70, Minimum = 0, Maximum = 999 };
            numTwos = new NumericUpDown { Location = new Point(130, y + 105), Width = 70, Minimum = 0, Maximum = 999 };
            numNoAttest = new NumericUpDown { Location = new Point(130, y + 140), Width = 70, Minimum = 0, Maximum = 999 };

            for (int i = 0; i < labels.Length; i++)
                tab.Controls.Add(new Label
                {
                    Text = labels[i],
                    Location = new Point(10, y + i * 35),
                    AutoSize = true
                });

            btnAdd = new Button { Text = "Добавить дисциплину", Location = new Point(10, 310), Width = 160, Height = 30 };
            btnClear = new Button { Text = "Очистить всё", Location = new Point(180, 310), Width = 160, Height = 30 };
            btnAdd.Click += BtnAdd_Click;
            btnClear.Click += BtnClear_Click;

            var lblList = new Label { Text = "Добавленные дисциплины:", Location = new Point(350, 10), AutoSize = true };
            lbDisciplines = new ListBox { Location = new Point(350, 35), Size = new Size(450, 320) };

            tab.Controls.AddRange(new Control[]
            {
                lblGroup, tbGroup,
                lblDisc, tbDiscipline,
                numFives, numFours, numThrees, numTwos, numNoAttest,
                btnAdd, btnClear,
                lblList, lbDisciplines
            });
        }

        private void BuildTab2(TabPage tab)
        {
            dgv = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(800, 430),
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgv.Columns.Add("disc", "Дисциплина");
            dgv.Columns.Add("fives", "5");
            dgv.Columns.Add("fours", "4");
            dgv.Columns.Add("threes", "3");
            dgv.Columns.Add("twos", "2");
            dgv.Columns.Add("noatt", "Не атт.");
            dgv.Columns.Add("total", "Всего");
            dgv.Columns.Add("abs", "Абс. усп. %");
            dgv.Columns.Add("qual", "Кач. усп. %");

            btnSave = new Button { Text = "Сохранить в файл", Location = new Point(10, 455), Width = 160, Height = 30};
            btnLoad = new Button { Text = "Загрузить из файла", Location = new Point(180, 455), Width = 160, Height = 30  };
            btnSave.Click += BtnSave_Click;
            btnLoad.Click += BtnLoad_Click;

            tab.Controls.AddRange(new Control[] { dgv, btnSave, btnLoad });
        }

        private void BuildTab3(TabPage tab)
        {
            chart = new Chart { Location = new Point(10, 50), Size = new Size(800, 430) };
            chart.ChartAreas.Add(new ChartArea("Main"));
            chart.Legends.Add(new Legend("Main"));

            btnDraw = new Button { Text = "Построить диаграмму", Location = new Point(10, 10), Width = 180, Height = 30};
            btnDraw.Click += BtnDraw_Click;

            tab.Controls.AddRange(new Control[] { btnDraw, chart });
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGroup.Text))
            {
                MessageBox.Show("Введите номер группы!");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbDiscipline.Text))
            {
                MessageBox.Show("Введите название дисциплины!");
                return;
            }

            _groupName = tbGroup.Text.Trim();
            _disciplines.Add(tbDiscipline.Text.Trim());
            _fives.Add((int)numFives.Value);
            _fours.Add((int)numFours.Value);
            _threes.Add((int)numThrees.Value);
            _twos.Add((int)numTwos.Value);
            _noAttest.Add((int)numNoAttest.Value);

            // Обновить список и таблицу
            RefreshListBox();
            RefreshTable();

            // Очистить поля ввода
            tbDiscipline.Clear();
            numFives.Value = numFours.Value = numThrees.Value =
            numTwos.Value = numNoAttest.Value = 0;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистить все данные?", "Подтверждение",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            _groupName = "";
            _disciplines.Clear();
            _fives.Clear(); _fours.Clear(); _threes.Clear();
            _twos.Clear(); _noAttest.Clear();

            tbGroup.Clear();
            tbDiscipline.Clear();
            numFives.Value = numFours.Value = numThrees.Value =
            numTwos.Value = numNoAttest.Value = 0;

            RefreshListBox();
            RefreshTable();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_disciplines.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения!");
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы|*.txt",
                FileName = $"group_{_groupName}.txt"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            using var writer = new StreamWriter(dialog.FileName);
            writer.WriteLine(_groupName);               
            writer.WriteLine(_disciplines.Count);       

            for (int i = 0; i < _disciplines.Count; i++)
            {
                writer.WriteLine(_disciplines[i]);
                writer.WriteLine(_fives[i]);
                writer.WriteLine(_fours[i]);
                writer.WriteLine(_threes[i]);
                writer.WriteLine(_twos[i]);
                writer.WriteLine(_noAttest[i]);
            }

            MessageBox.Show("Данные сохранены!");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog { Filter = "Текстовые файлы|*.txt" };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var reader = new StreamReader(dialog.FileName);

                _groupName = reader.ReadLine() ?? "";
                int count = int.Parse(reader.ReadLine() ?? "0");

                // Очищаем старые данные
                _disciplines.Clear();
                _fives.Clear(); _fours.Clear(); _threes.Clear();
                _twos.Clear(); _noAttest.Clear();

                for (int i = 0; i < count; i++)
                {
                    _disciplines.Add(reader.ReadLine() ?? "");
                    _fives.Add(int.Parse(reader.ReadLine() ?? "0"));
                    _fours.Add(int.Parse(reader.ReadLine() ?? "0"));
                    _threes.Add(int.Parse(reader.ReadLine() ?? "0"));
                    _twos.Add(int.Parse(reader.ReadLine() ?? "0"));
                    _noAttest.Add(int.Parse(reader.ReadLine() ?? "0"));
                }

                tbGroup.Text = _groupName;
                RefreshListBox();
                RefreshTable();

                MessageBox.Show("Данные загружены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            if (_disciplines.Count == 0)
            {
                MessageBox.Show("Нет данных для диаграммы!");
                return;
            }

            DrawDiagram();
        }

        private void RefreshListBox()
        {
            lbDisciplines.Items.Clear();
            for (int i = 0; i < _disciplines.Count; i++)
            {
                int total = Total(i);
                lbDisciplines.Items.Add(
                    $"{_disciplines[i]} | 5:{_fives[i]} 4:{_fours[i]} " +
                    $"3:{_threes[i]} 2:{_twos[i]} н/а:{_noAttest[i]} | Всего:{total}"
                );
            }
        }
        private void RefreshTable()
        {
            dgv.Rows.Clear();

            for (int i = 0; i < _disciplines.Count; i++)
            {
                int total = Total(i);
                double abs = AbsPerf(i);
                double qual = QualPerf(i);

                dgv.Rows.Add(
                    _disciplines[i],
                    _fives[i],
                    _fours[i],
                    _threes[i],
                    _twos[i],
                    _noAttest[i],
                    total,
                    $"{abs:F1}%",
                    $"{qual:F1}%"
                );
            }
        }

        private void DrawDiagram()
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            chart.Titles.Add($"Успеваемость группы {_groupName}");
            chart.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);

            var serAbs = new Series("Абсолютная успеваемость")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "Main",
                Color = Color.SteelBlue,
                IsValueShownAsLabel = true,
                LabelFormat = "F1"
            };

            var serQual = new Series("Качественная успеваемость")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "Main",
                Color = Color.OrangeRed,
                IsValueShownAsLabel = true,
                LabelFormat = "F1"
            };

            for (int i = 0; i < _disciplines.Count; i++)
            {
                serAbs.Points.AddXY(_disciplines[i], AbsPerf(i));
                serQual.Points.AddXY(_disciplines[i], QualPerf(i));
            }

            chart.Series.Add(serAbs);
            chart.Series.Add(serQual);

            var area = chart.ChartAreas["Main"];
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 100;
            area.AxisY.Title = "Успеваемость %";
            area.AxisX.Title = "Дисциплина";
            area.AxisX.LabelStyle.Angle = -30;
        }

        // Всего оценок по дисциплине
        private int Total(int i)
            => _fives[i] + _fours[i] + _threes[i] + _twos[i] + _noAttest[i];

        // Абсолютная успеваемость
        private double AbsPerf(int i)
        {
            int total = Total(i);
            if (total == 0) return 0;
            int withoutBad = _fives[i] + _fours[i] + _threes[i];
            return withoutBad / (double)total * 100;
        }

        // Качественная успеваемость
        private double QualPerf(int i)
        {
            int total = Total(i);
            if (total == 0) return 0;
            int good = _fives[i] + _fours[i];
            return good / (double)total * 100;
        }
    }
}
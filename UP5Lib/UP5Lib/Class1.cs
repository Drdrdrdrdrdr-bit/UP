using System.Collections;
using System.Text.RegularExpressions;

namespace UP5Lib
{
    public class TaskLib
    {
        IWork _form;
        private Dictionary<int, HashSet<string>> _dict = new();
        private Regex _digits = new Regex(@"\b\w+\b", RegexOptions.Compiled);
        int _MError = 3;

        public TaskLib(IWork form) 
        {
            _form = form;
        }
        public void LoadWords()
        {   
            var matches = _digits.Matches(File.ReadAllText(_form.PatchLoad));
            foreach (Match match in matches)
            {
                LoadWord(match.Value);
            }
        }
        private void LoadWord(string word)
        {
            int key = word.Length;
            if (!_dict.ContainsKey(key))
                _dict[key] = new HashSet<string>();
            _dict[key].Add(word);
        }
        private void ReloadWord(string word)
        {
            int key = word.Length;
            if (!_dict.ContainsKey(key))
                _dict[key] = new HashSet<string>();
            _dict[key].Remove(word);
        }
        public string DictToString()
        {
            string s = "";
            foreach(var pair in _dict)
            {
                foreach (var query in pair.Value)
                {
                    s += $"{query}\n";
                }
            }
            return s;
        }
        public void AddWord(string word) 
        {
            try
            {
                _form.PrintMassage("Загружаем");
                LoadWord(word);
                File.WriteAllText(_form.PatchLoad, DictToString());
                _form.PrintMassage("Успешно");
            }
            catch (Exception ex)
            {
                _form.PrintMassage(ex.ToString());
            }
        }
        public void RemuvWord(string word) 
        {
            try
            {
                _form.PrintMassage("Загружаем");
                ReloadWord(word);
                File.WriteAllText(_form.PatchLoad, DictToString()); // !!
                _form.PrintMassage("Успешно");
            }
            catch (Exception ex)
            {
                _form.PrintMassage(ex.ToString());
            }
        }
        public void WriteResult(string words)
        {
               File.WriteAllText(_form.PatchSave, words);
            _form.PrintMassage("Успешно");
        }

        public void ReturnTask(string word)
        {
            _form.PrintMassage("Загружаем");
            int len = word.Length + 3;
            string s = "";
            foreach (var pair in _dict)
            {
                if (len >= pair.Key)
                {
                    foreach (var query in pair.Value)
                    {
                        if (HasLetters(word, query))
                            s += $"{query}\n";
                    }
                }
            }
            WriteResult(s);
        }
        private bool HasLetters(string word, string letters)
        {
            _form.PrintMassage("Загружаем");
            var set = new HashSet<char>(word);

            foreach (char c in letters)
            {
                if (!set.Contains(c))
                    return false;
            }

            return true;
        }
        public void ReturnLivingstain(string word)
        {
            int len = word.Length + 3;
            string s = "";
            foreach (var pair in _dict)
            {
                if (len >= pair.Key)
                {
                    foreach(var query in pair.Value)
                    {
                        if (Levenshtein(word, query))
                        s += $"{query}\n";
                    }
                }

            }
            WriteResult(s);
        }
        private bool Levenshtein(string word, string query)
        {
            int n = query.Length;

            int[] prev = new int[n + 1];

            for (int i = 0; i <= n; i++)
                prev[i] = i;

            foreach (char wc in word)
            {
                int[] curr = new int[n + 1];
                curr[0] = prev[0] + 1;

                for (int i = 1; i <= n; i++)
                {
                    int cost = (wc == query[i - 1]) ? 0 : 1;

                    curr[i] = Math.Min(
                        Math.Min(
                            curr[i - 1] + 1,   // вставка
                            prev[i] + 1),      // удаление
                        prev[i - 1] + cost     // замена
                    );
                }

                prev = curr;
            }

            return prev[n] <= _MError;
        }
    }
}

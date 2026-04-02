using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Postgrest = Supabase.Postgrest;

namespace UP4
{
    internal class WorkWithDB
    {
        private string _login, _password;
        private Supabase.Client _supabase;
        public async void ConectDB()
        {
            const string url = "https://MyDB.supabase.co";
            const string key = "vgqslwfgxxkccdjzjjew";

            /*Supabase → Project Settings → API

Project URL:  https://xxxx.supabase.co
anon key:     eyJhbGc...*/

            _supabase = new Supabase.Client(url, key);
            await _supabase.InitializeAsync();
        }
        public void SelectImage()
        {

        }
        public void Authorization()
        {

        }
        public async Task<(bool Success, byte[]? Avatar)> Login()
        {
            var response = await _supabase
                .From("users")
                .Select("avatar")
                .Filter("login", Postgrest.Constants.Operator.Equals, login)
                .Filter("password", Postgrest.Constants.Operator.Equals, password)
                .Get();

            // Ответ приходит как JSON строка
            if (string.IsNullOrEmpty(response.Content) || response.Content == "[]")
                return (false, null); // ← не найден

            // Парсим JSON
            var json = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                response.Content
            );

            var first = json?.FirstOrDefault();
            if (first == null) return (false, null);

            // Получить аватар — в Supabase bytea приходит как Base64 строка
            byte[]? avatar = null;
            if (first.TryGetValue("avatar", out var avatarEl)
                && avatarEl.ValueKind != JsonValueKind.Null)
            {
                avatar = Convert.FromBase64String(avatarEl.GetString()!);
            }

            return (true, avatar);
        }
    }
}

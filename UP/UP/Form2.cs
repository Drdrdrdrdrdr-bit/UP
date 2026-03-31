using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP
{
    public partial class Form2 : Form
    {
        class Claint
        {
            private Supabase.Client? supabase;

            public Claint()
            {
                InitializeClaint();
            }

            [Table("cities")]
            private class City : BaseModel
            {
                [PrimaryKey("id", false)]
                public int Id { get; set; }

                [Column("name")]
                public string Name { get; set; }

                [Column("country_id")]
                public int CountryId { get; set; }
            }

            public async Task InitializeClaint()
            {
                var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
                var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");

                var options = new Supabase.SupabaseOptions
                {
                    AutoConnectRealtime = true
                };

                supabase = new Supabase.Client(url!, key!, options);
                await supabase.InitializeAsync();
            }


            private async void CreateClaint()
            {
                
            

                var model = new City
                {
                    Name = "The Shire",
                    CountryId = 554
                };

                await this.supabase.From<City>().Insert(model);
            }
        }
        
        public Form2()
        {
            InitializeComponent();
        }
    }
}

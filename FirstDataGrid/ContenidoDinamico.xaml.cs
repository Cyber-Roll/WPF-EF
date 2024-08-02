using FirstDataGrid;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;

namespace Grid
{
    /// <summary>
    /// Interaction logic for ContenidoDinamico.xaml
    /// </summary>
    public partial class ContenidoDinamico : Window
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<FamiliaContext> _optionsBuilder;

        public ContenidoDinamico()
        {
            InitializeComponent();

            tbPizarra.AppendText("Llamando BuildConfiguration\r");
            tbPizarra.AppendText($"CNSTR: {_configuration.GetConnectionString("Familia")}\r");

            BuildConfiguration();
            BuildOptions();
            //******************************************************************


        }

        static void BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<FamiliaContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Familia"));
        }

        static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true,
            reloadOnChange: true);
            _configuration = builder.Build();
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdPrev_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Llamando BuildConfiguration");
            Console.WriteLine($"CNSTR: {_configuration.GetConnectionString("Familia")}");

            using (var db = new FamiliaContext(_optionsBuilder.Options))
            {
                var PersonasRoll = db.Personas.OrderByDescending(x => x.Id).Take(100).
                ToList();
                foreach (var p in PersonasRoll)
                {
                    string ln = String.Format(
                        $"{p.Id,-2} " +
                        $"{p.Nombre,-10} " +
                        $"{p.Apellido,-12} " +
                        $"{((DateTime)p.Fecnac).ToString("dd/MM/yy"),-10} " +
                        $"{p.Salario,-4} {p.Estatura,-4}"
                    );

                    tbPizarra.AppendText(ln + "\r");
                }
            }
        }

        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {
            tbPizarra.SelectAll();
            tbPizarra.Selection.Text = "";
        }
    }
}

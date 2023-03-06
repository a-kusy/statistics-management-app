using IS_Projekt.Core;
using IS_Projekt.Core.AccidentStatistics;
using RestSharp;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace IS_Projekt.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly XmlSerializer xmlSerializer;
        private readonly RestClient client;
        private AccidentStatisticsXml accidentStatistics;
        private string jwtToken;
        private readonly DtoToReadableServiceClient sc;

        public MainWindow()
        {
            xmlSerializer = new XmlSerializer(typeof(AccidentStatisticsXml));
            client = new RestClient("http://localhost:5229/");
            accidentStatistics = new AccidentStatisticsXml();
            sc = new();
            InitializeComponent();
        }

        private void ImportXml_Click(object sender, RoutedEventArgs e)
        {
            var fileName = "Assets/wypadki.xml";
            if (!File.Exists(fileName))
            {
                WyswietlNieznalezieniePliku(fileName);
                return;
            }

            using var fs = new FileStream(fileName, FileMode.Open);
            using var reader = new StreamReader(fs);

            var accidentStatistics = (AccidentStatisticsXml)xmlSerializer.Deserialize(reader);

            this.accidentStatistics = accidentStatistics;

            grid.ItemsSource = accidentStatistics.Rows.Select(x => ToReadable(x));
        }

        private static Core.AccidentStatistics.AccidentStatistic ToReadable(AccidentStatisticsRowXml row)
        {
            return new Core.AccidentStatistics.AccidentStatistic(
                LiczbaWypadkow: row.LiczbaWypadkow,
                MiejsceWypadku: row.MiejsceWypadku,
                PrzyczynaWypadku: row.PrzyczynaWypadku,
                RodzajWypadku: row.RodzajWypadku,
                RodzajZajec: row.RodzajZajec,
                TypPodmiotu: row.TypPodmiotu,
                Wojewodztwo: row.Wojewodztwo
            );
        }

        private void ExportXml_Click(object sender, RoutedEventArgs e)
        {
            if (grid.ItemsSource == null)
            {
                PokazNiezaladowaneDane();
                return;
            }

            const string filepath = "Assets/wypadki_export.xml";
            using var fs = new FileStream(filepath, FileMode.Create);
            using var textWriter = new StreamWriter(fs);
            xmlSerializer.Serialize(textWriter, accidentStatistics);
        }

        private void ImportJson_Click(object sender, RoutedEventArgs e)
        {
            const string path = "Assets/wypadki_export.json";
            if (!File.Exists(path))
            {
                WyswietlNieznalezieniePliku(path);
                return;
            }

            var text = File.ReadAllText(path);
            accidentStatistics = JsonSerializer.Deserialize<AccidentStatisticsXml>(text);
            grid.ItemsSource = accidentStatistics.Rows.Select(x => ToReadable(x));
        }

        private void ExportJson_Click(object sender, RoutedEventArgs e)
        {
            if (grid.ItemsSource == null)
            {
                PokazNiezaladowaneDane();
                return;
            }

            var text = JsonSerializer.Serialize(accidentStatistics);
            File.WriteAllText("Assets/wypadki_export.json", text);
        }

        private async void ImportDb_Click(object sender, RoutedEventArgs e)
        {
            var request = new RestRequest("api/accidents");
            if (!string.IsNullOrEmpty(jwtToken))
                request.AddHeader("Authorization", $"Bearer {jwtToken}");
            stateLabel.Content = "Trwa import db";
            var response = await PerformRequest(client.GetAsync<List<Core.AccidentStatistics.AccidentStatisticDto>>(request));
            if (response is null)
            {
                stateLabel.Content = "Nie powiodło się importowanie db";
                return;
            }
            stateLabel.Content = $"Trwa import db:\notrzymano dane ({response.Count} wierszy)\nkonwertowanie z użyciem SOAP...";
            accidentStatistics.Rows = (await ToXmlRows(response))?.ToList();
            stateLabel.Content = "Trwa import db:\n otrzymano SOAP,\n konwertowanie na czytelne...";
            grid.ItemsSource = accidentStatistics.Rows?.Select(x => ToReadable(x));
            stateLabel.Content = "Zakończono import db";
        }

        private async Task<IEnumerable<AccidentStatisticsRowXml>> ToXmlRows(IEnumerable<Core.AccidentStatistics.AccidentStatisticDto> dtos)
        {
            sc.InnerChannel.OperationTimeout = TimeSpan.FromHours(1);
            var readable = await sc.ToReadableMultipleAsync(dtos.Select(x => ServiceReferenceToCore(x)).ToArray());
            return readable.Zip(dtos).Select(x => new AccidentStatisticsRowXml
            {
                LiczbaWypadkow = x.Second.LiczbaWypadkow,
                IdMiejsceWypadku = x.Second.IdMiejsceWypadku,
                IdPrzyczynaWypadku = x.Second.IdPrzyczynaWypadku,
                IdRodzajWypadku = x.Second.IdRodzajWypadku,
                IdRodzajZajec = x.Second.IdRodzajZajec,
                IdTypPodmiotu = x.Second.IdTypPodmiotu,
                IdTerytWojewodztwo = x.Second.IdTerytWojewodztwo,
                MiejsceWypadku = x.First.MiejsceWypadku,
                PrzyczynaWypadku = x.First.PrzyczynaWypadku,
                RodzajWypadku = x.First.RodzajWypadku,
                RodzajZajec = x.First.RodzajZajec,
                TypPodmiotu = x.First.TypPodmiotu,
                Wojewodztwo = x.First.Wojewodztwo
            });
        }

        private async void ExportDb_Click(object sender, RoutedEventArgs e)
        {
            if (grid.ItemsSource == null)
            {
                PokazNiezaladowaneDane();
                return;
            }

            var request = new RestRequest("api/accidents");
            stateLabel.Content = "Trwa export db:\n wysłano dane do konwersji za pomocą SOAP";
            try
            {
                var dtos = await sc.ToDtoMultipleAsync(accidentStatistics.Rows.Select(x => ToReadable(x)).Select(x => CoreToProjectReference(x)).ToArray());
                stateLabel.Content = $"Trwa export db:\n otrzymano przekonwertowane dane\n ({dtos.Length} wierszy) z SOAP, \n wysyłanie do bazy";
                request.AddJsonBody(dtos);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Błąd SOAP", MessageBoxButton.OK, MessageBoxImage.Error);
                stateLabel.Content = "Nie powiódł się export db";
                return;
            }
            if (!string.IsNullOrEmpty(jwtToken))
                request.AddHeader("Authorization", $"Bearer {jwtToken}");
            await PerformRequest(client.PostAsync<ServiceReference1.AccidentStatisticDto[]>(request));
            stateLabel.Content = "Zakończono export db";
        }

        private static ServiceReference1.AccidentStatisticDto ServiceReferenceToCore(Core.AccidentStatistics.AccidentStatisticDto x) => new()
        {
            LiczbaWypadkow = x.LiczbaWypadkow,
            IdMiejsceWypadku = x.IdMiejsceWypadku,
            IdPrzyczynaWypadku = x.IdPrzyczynaWypadku,
            IdRodzajWypadku = x.IdRodzajWypadku,
            IdRodzajZajec = x.IdRodzajZajec,
            IdTypPodmiotu = x.IdTypPodmiotu,
            IdTerytWojewodztwo = x.IdTerytWojewodztwo
        };

        private static ServiceReference1.AccidentStatistic CoreToProjectReference(Core.AccidentStatistics.AccidentStatistic x) => new()
        {
            LiczbaWypadkow = x.LiczbaWypadkow,
            MiejsceWypadku = x.MiejsceWypadku,
            PrzyczynaWypadku = x.PrzyczynaWypadku,
            RodzajWypadku = x.RodzajWypadku,
            RodzajZajec = x.RodzajZajec,
            TypPodmiotu = x.TypPodmiotu,
            Wojewodztwo = x.Wojewodztwo
        };

        private static Core.AccidentStatistics.AccidentStatistic ServiceReferenceToCore(ServiceReference1.AccidentStatistic x) => new()
        {
            LiczbaWypadkow = x.LiczbaWypadkow,
            MiejsceWypadku = x.MiejsceWypadku,
            PrzyczynaWypadku = x.PrzyczynaWypadku,
            RodzajWypadku = x.RodzajWypadku,
            RodzajZajec = x.RodzajZajec,
            TypPodmiotu = x.TypPodmiotu,
            Wojewodztwo = x.Wojewodztwo
        };

        private static void PokazNiezaladowaneDane()
        {
            MessageBox.Show("Nie załadowano jeszcze danych.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private static void WyswietlNieznalezieniePliku(string nazwa)
        {
            var messageBoxText = $"Nie znaleziono wymaganego pliku \"{nazwa}\"";
            var caption = "Brak pliku";
            var button = MessageBoxButton.OK;
            var icon = MessageBoxImage.Warning;

            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var authInfo = new AuthenticationRequest
            {
                Password = passwordTextBox.Text,
                Username = loginTextBox.Text
            };

            var request = new RestRequest("api/users/authenticate");
            request.AddJsonBody(authInfo);

            var response = await PerformRequest(client.PostAsync<AuthenticationResponse>(request));
            jwtToken = response?.Token;
            loggedInUserLabel.Content = response?.Username;
        }

        private static async System.Threading.Tasks.Task<T> PerformRequest<T>(System.Threading.Tasks.Task<T> task)
        {
            try
            {
                return await task;
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                if (e.StatusCode is System.Net.HttpStatusCode.Unauthorized or System.Net.HttpStatusCode.Forbidden)
                    MessageBox.Show("Nie masz odpowiednich uprawnień.");
                else
                    MessageBox.Show("Błąd requestu, prawdopodobnie nie masz odpowiednich uprawnień.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return default;
        }

        private async void ClearDbButton_Click(object sender, RoutedEventArgs e)
        {
            stateLabel.Content = "Trwa czyszczenie bd...";
            var request = new RestRequest("api/accidents", Method.Delete);
            if (!string.IsNullOrEmpty(jwtToken))
                request.AddHeader("Authorization", $"Bearer {jwtToken}");
            await PerformRequest(client.DeleteAsync(request));
            stateLabel.Content = "Wyczyszczono bd";
        }

        private void ClearGridButton_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = null;
        }
    }
}

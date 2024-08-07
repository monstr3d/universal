// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;

internal class Program
{
    static string body;

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
      Task t =  new Task(Test);
        t.Start();
        Console.ReadKey();

    }


    async static void Test()
    {
        try
        {
            var client = new HttpClient();

            var s = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Paris?key=Q3722KCAVZH2FHZZ95NHP5M75";


            var request = new HttpRequestMessage(HttpMethod.Get, s);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw an exception if error

            body = await response.Content.ReadAsStringAsync();
            dynamic weather = JsonConvert.DeserializeObject(body);
            foreach (var day in weather.days)
            {
                string weather_date = day.datetime;
                string weather_desc = day.description;
                string weather_tmax = day.tempmax;
                string weather_tmin = day.tempmin;

                Console.WriteLine("Forecast for date: " + weather_date);
                Console.WriteLine(" General conditions: " + weather_desc);
                Console.WriteLine(" The high temperature will be " + weather_tmax);
                Console.WriteLine(" The low temperature will be: " + weather_tmin);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
   }

}
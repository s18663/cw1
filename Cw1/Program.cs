using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int? tmp1 = 1;   //znak zapytania = nullable variable
            //double tmp2 = 2.0;

            //string tmp3 = "aaaaa";
            //string tmp4 = "bbb";
            //Console.WriteLine($"{tmp3} {tmp4} {tmp1+3");
            //string path = @"C:\Users\s18663\Desktop"
            //bool tmp4 = false;

            //var tmp5 = 1;  // var przyjmuje typ zaleznie od inicjowanej wartosci

            //var NewPerson = new Person { FirstName = "Zuzanna" };

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();


            var response = await httpClient.GetAsync(url);

            //2xx

            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }


            }
        }
    }
}

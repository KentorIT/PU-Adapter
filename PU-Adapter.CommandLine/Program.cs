﻿using Kentor.PU_Adapter.TestData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Kentor.PU_Adapter.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var fetcher = new PU_Adapter.PknodFetcher();
            if (string.IsNullOrEmpty(fetcher.UserName))
            {
                Console.WriteLine("Inget användarnamn angivet i app.config, ange användarnamn");
                fetcher.UserName = Console.ReadLine();
            }
            if (string.IsNullOrEmpty(fetcher.Password))
            {
                Console.WriteLine("Inget lösenord angivet i app.config, ange lösenord");
                fetcher.Password = Console.ReadLine();
                Console.Clear();
            }
            //Change SSL checks so that all checks pass
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            while (true)
            {
                Console.WriteLine("Enter person number, or t to save all testperson numbers to file");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return;
                }
                if (input == "t")
                {
                    SaveAllTestPnrData(fetcher);
                    Console.WriteLine("Done");
                    break;
                }

                var result = fetcher.FetchPknodString(input);
                Console.WriteLine(result);
                Console.WriteLine("----------------------------------------------");
                var parsedData = new PknodData(result);
                if (parsedData.Field_Returkod == Enums.ReturnCode.Tjänsten_utförd)
                {
                    var json = JsonConvert.SerializeObject(parsedData, Formatting.Indented);
                    Console.WriteLine(json);
                    Console.WriteLine("----------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Error on fetch:");
                    Console.WriteLine(parsedData.Field_Returkod.ToString());
                }
                Console.WriteLine("--Plus--");
                var resultPlus = fetcher.FetchPknodPlusString(input);
                Console.WriteLine(resultPlus);
                Console.WriteLine("----------------------------------------------");
                var parsedDataPlus = new PknodPlusData(resultPlus);
                if (parsedDataPlus.Field_Returkod == Enums.ReturnCode.Tjänsten_utförd)
                {
                    var jsonPlus = JsonConvert.SerializeObject(parsedData, Formatting.Indented);
                    Console.WriteLine(jsonPlus);
                }
                else
                {
                    Console.WriteLine("Error on fetch:");
                    Console.WriteLine(parsedData.Field_Returkod.ToString());
                }
                Console.WriteLine("----------------------------------------------");
            }
        }

        private static void SaveAllTestPnrData(PU_Adapter.PknodFetcher fetcher)
        {
            var results = new List<string>();
            foreach (var pnr in Testpersonnummer.Nummer)
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var result = fetcher.FetchPknodPlusString(pnr);
                sw.Stop();
                Console.WriteLine("Time: " + sw.Elapsed);
                results.Add(result);
            }
            System.IO.File.WriteAllLines("c:\\Temp\\TestPnrData.txt", results);
        }
    }
}

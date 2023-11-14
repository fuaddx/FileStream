using Newtonsoft.Json;
using System;
using System.IO;
using TaskP.Models;

class Program
{

    static void Main()
    {
        string Root = @"C:\Users\birinci novbe\Desktop\Nihad\accessmodifiers\TaskP";

        string model = Path.Combine(Root, "Models");
        string data = Path.Combine(Root, "Data");

        if (!Directory.Exists(model))
        {
            Directory.CreateDirectory(model);
            Console.WriteLine("Models klasörü oluşturuldu.");
        }

        if (!Directory.Exists(data))
        {
            Directory.CreateDirectory(data);
            Console.WriteLine("Data klasörü oluşturuldu.");
        }

        string jsonData = Path.Combine(data, "jsonData.json");

        if (!File.Exists(jsonData))
        {
            File.Create(jsonData);
            Console.WriteLine("json yarandi");
        }
        else
        {
            Console.WriteLine("jsonData movcuddur");
        }


        string datas = "https://jsonplaceholder.typicode.com/posts";
        HttpClient client = new HttpClient();
        var response = client.GetStringAsync(datas).Result;
        List<CustomObject> objects = JsonConvert.DeserializeObject<List<CustomObject>>(response);

        string stds = JsonConvert.SerializeObject(objects);
        StreamWriter sw = new StreamWriter(Path.Combine(Root, jsonData));

        sw.Write(stds);
        sw.Close();

    }
}







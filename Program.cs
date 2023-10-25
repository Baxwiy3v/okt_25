using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    private static string jsonFilePath = "namees.json";

    static List<string> LoadData()
    {
        List<string> data;
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            data = JsonConvert.DeserializeObject<List<string>>(json);
        }
        else
        {
            data = new List<string>();
        }
        return data;
    }

   

    static void Add(string name)
    {
        List<string> data = LoadData();
        data.Add(name);
        SaveData(data);
    }

    static void SaveData(List<string> data)
    {
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(jsonFilePath, json);
    }

    static void Delete(string name)
    {
        List<string> data = LoadData();
        data.Remove(name);
        SaveData(data);
    }
    static bool Search(string name, Predicate<string> match)
    {
        List<string> data = LoadData();
        return data.Exists(match);
    }

    static void Main()
    {
       
        Add("Aqil");
        Add("Tural");

        Console.WriteLine("Search for 'Aqil': " + Search("Aqil", s => s == "Aqil")); // True
        Console.WriteLine("Search for 'Vaqif': " + Search("Vaqif", s => s == "Vaqif")); // False

        Delete("Tural");

        Console.WriteLine("Search for 'Tural' after deleting: " + Search("Tural", s => s == "Tural")); // False

        // Örnek bir liste oluşturuyoruz
        List<string> namesList = new List<string>
        {
            "Alice",
            "Bob",
            "Charlie",
            "David"
        };

        // JSON dosyasına yazmak için dosya adı
        string jsonFilePath = "names.json";

        // Listeyi JSON formatında serileştirip dosyaya yazıyoruz
        string json = JsonConvert.SerializeObject(namesList, Formatting.Indented);
        File.WriteAllText(jsonFilePath, json);

        Console.WriteLine("names.json oluşturuldu ve veriler dosyaya yazıldı.");
    }
}

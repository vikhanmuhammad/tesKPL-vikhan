using System.Net.NetworkInformation;

public sealed class Singleton
{
    private static Singleton _instance;
    private List<string> Data;
    private Singleton() 
    { 
        Data = new List<string>();
    }


    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }

    public List<string> GetData()
    {
        return Data;
    }

    public void PrintData()
    {
        for(int i = 0; i < Data.Count; i++)
        {
            Console.WriteLine(Data[i]);
        }
    }

    public void AddData(string input)
    {
        Data.Add(input);
    }

    public void RemoveData(int index) 
    {
        Data.RemoveAt(index);
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();

        s1.AddData("Yaris");
        s1.AddData("Fortuner");
        s1.AddData("Camry");
        s1.AddData("Innova");
        s1.AddData("Rush");

        s2.PrintData();
        Console.WriteLine("");

        s2.RemoveData(2);
        s1.PrintData();
    }
}


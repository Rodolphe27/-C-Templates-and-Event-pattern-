using Liste;
namespace Autos
{
public class Auto
{
    // Eigenschaften

	private string hersteller;
    public string Hersteller {
		 get{return hersteller;}
		 set{hersteller = value;} 
		 }
    public int Baujahr { get; set; }

    // Konstruktor
    public Auto(string hersteller, int baujahr)
    {
        Hersteller = hersteller;
        Baujahr = baujahr;
    }
}

public class AutoEventArgs : EventArgs
{
    public Auto newauto;
    public Auto Newauto{
        get;//{newauto;}
        // get => newauto;
        // set{newauto = value;}
        // private set{newauto = value;}
    }

    public AutoEventArgs (Auto newauto){
        Newauto = newauto;
    }
}

public delegate void EventLoic(object sender, AutoEventArgs args);

public class Fuhrpark
{
    // Verwendung von LinkedList für die interne Verwaltung der Fahrzeuge
    private Linkedlist<Auto> fahrzeuge = new Linkedlist<Auto>();

    public event EventLoic AutoAdded;
    // Ein Auto wird in den Fuhrpark aufgenommen
    public void Aufnehmen(Auto a)
    {
        fahrzeuge.AddFirst(a);
        if (AutoAdded != null){
        AutoAdded(this, new AutoEventArgs(a));
        }
        // ^ todo: possbily null
    }


    // Gibt die Daten aller Fahrzeuge auf der Konsole aus
    public void Inventur()
    {
        Iterator<Auto> iterator = fahrzeuge.GetIterator();
        while (iterator.HasNext())
        {
            Auto auto = iterator.Next();
        

        
            Console.WriteLine($"Hersteller: {auto.Hersteller}, Baujahr: {auto.Baujahr}");
        

    }
    }

    // Berechnet das durchschnittliche Alter der Fahrzeuge im Fuhrpark
    public double BerechneFlottenalter()
    {
    

        int gesamtalter = 0;
        int count=0;
        Iterator<Auto> iterator = fahrzeuge.GetIterator();
        while (iterator.HasNext())
        {
            Auto auto = iterator.Next();
        
            gesamtalter += (2024 - auto.Baujahr);
            count++;
        }

        return (double)gesamtalter / count;
    }
}

public class Info
{ 
    private Fuhrpark fp;
    public Info(Fuhrpark fp){
        this.fp=fp;
        this.fp.AutoAdded+=OnAutoAdded;

}
    private void OnAutoAdded(object sender, AutoEventArgs e)
    {
        Console.WriteLine($"Neues Auto:{e.Newauto.Hersteller}, Baujahr:{e.Newauto.Baujahr}");
    }
}
}
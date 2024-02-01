using System;
using Autos;
// using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Fuhrpark fh = new Fuhrpark();
        Info info = new Info(fh);
      //  fh.AutoAdded += info.OnAutoAdded;

        // Fahrzeuge hinzufügen
        fh.Aufnehmen(new Auto("Hersteller1", 2010));
        fh.Aufnehmen(new Auto("Hersteller2", 2015));
        fh.Aufnehmen(new Auto("Hersteller3", 2018));

        // Inventurliste anzeigen
        // Console.WriteLine("Inventurliste:");
        // fuhrpark.Inventur();

        // Durchschnittliches Alter ausgeben
        double durchschnittlichesAlter = fh.BerechneFlottenalter();
        Console.WriteLine($"Durchschnittliches Alter der Fahrzeuge: {durchschnittlichesAlter:F2} Jahre");
    }
}

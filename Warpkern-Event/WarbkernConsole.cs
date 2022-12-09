using System;
using System.Collections.Generic;
using System.Text;

namespace WarpkernEvent
{
    class WarpkernConsole    {
        public void Ausgeben() {
            Console.WriteLine("Ausgabe");
        }

        public virtual void OnTemperaturÄnderung(object source, TemperaturÄnderungEventArgs e) {
            Console.WriteLine("Temperatur-Änderung: Vorher: {0}  Aktuell: {1}  - Zeit: {2}", e.AlteTemperatur, e.NeueTemperatur,e.DatumZeit);
        }

        public virtual void OnTemperaturAlarm(object source, TemperaturÄnderungEventArgs e) {
            Console.WriteLine("*************** ALARM ************** Temperatur: {0} Grad", e.NeueTemperatur);
        }

    }
}

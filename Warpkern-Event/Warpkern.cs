using System;
using System.Collections.Generic;
using System.Text;

namespace WarpkernEvent
{
    class Warpkern {
        // Zufallszahlgenerator
        private Random zzG = new Random();

        // event
        public event EventHandler<TemperaturÄnderungEventArgs> TemperaturÄnderungEvent;
        public event EventHandler<TemperaturÄnderungEventArgs> TemperaturAlarmEvent;

        // Property
        private int WarpkernTemperatur { get; set; }


        // Methode
        public void ÄndereTemperatur() {
            int temperatur = zzG.Next(120, 777);
            System.Threading.Thread.Sleep(500);
            TemperaturÄnderungEventArgs täEventArgs=null;


            if (temperatur != this.WarpkernTemperatur) {
                täEventArgs = new TemperaturÄnderungEventArgs()
                {
                    AlteTemperatur = WarpkernTemperatur,
                    NeueTemperatur = temperatur
                };

                this.WarpkernTemperatur = temperatur;

                if (temperatur > 500) {
                    OnTemperaturAlarm(this, täEventArgs);
                }                    
                OnTemperaturÄnderung(this, täEventArgs);               
            }

        }

        private void OnTemperaturAlarm(Warpkern warpkern, TemperaturÄnderungEventArgs e) {
            if (TemperaturAlarmEvent != null) {
                TemperaturAlarmEvent(this, e);
            }
        }

        public virtual void OnTemperaturÄnderung(Warpkern warpkern , TemperaturÄnderungEventArgs e) {
            if (TemperaturÄnderungEvent != null) {
                TemperaturÄnderungEvent(this, e);
            }
        }


    }


    class TemperaturÄnderungEventArgs: EventArgs {
        public int AlteTemperatur { get; set; }
        public int NeueTemperatur { get; set; }
        public DateTime DatumZeit { get; set; }

        public TemperaturÄnderungEventArgs() {
           // AlteTemperatur = 
            DatumZeit = DateTime.Now;
        }
    }

}

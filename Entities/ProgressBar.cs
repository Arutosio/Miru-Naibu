using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miru_Naibu.Library;
using static System.ConsoleColor;

namespace Miru_Naibu.Entities
{
    public class ProgressBar
    {
        // Declaratuion Fase
        private readonly int barLength = 16;
        public string vuoto = "", full = "";
        public int stepProgress = 100;
        public string ColorProgress { get; set; } = "green";
        public char CharProgress { get; set; } = '█';
        public double Percent { get; set; } = 0;
        public int LastOutputLength { get; set; } 

        private ProgressBar() { }
        public ProgressBar(int x)
        {
            barLength = x;
        }
        public string SetVuoto()
        {
            for (int i = 0; i < barLength; i++)
                vuoto += " ";
            return vuoto;
        }
        public double PercentCalculation(double current, double maximum)
        {
            return (current / maximum) * 100;
        }
        public void UpdatePrintProgress(double PercentUp)
        {
            Console.CursorVisible = false;
            // Generate new state 
            int width = (int)(PercentUp / 100 * barLength);
            int fill = barLength - width;
            //Delete Last String
            string clear = string.Empty.PadRight(LastOutputLength, '\b');
            Console.Write(clear);
            if (true)
            {
                Console.Write((Percent < 10 ? "  " : (PercentUp >= 10 && PercentUp < 100) ? " " : "") + "{0:0}% [ ", PercentUp); ColorLine.WriteC(string.Empty.PadLeft(width, '█'), Green); Console.Write("{0} ] - ", string.Empty.PadLeft(fill, ' '));
                LastOutputLength = 3 + "% [ ".Length + barLength + " ] - ".Length;
            }
        }
        public void SincePrintProgress()
        {
            Console.CursorVisible = false;
            Console.Write(" =====> ");
            while (Percent <= stepProgress)
            {
                if (stepProgress == Percent)
                    stepProgress = 99;
                // Generate new state 
                int width = (int)(Percent / 100 * barLength);
                int fill = barLength - width;
                //Delete Last String
                string clear = string.Empty.PadRight(LastOutputLength, '\b');
                Console.Write(clear);
                Console.Write((Percent < 10 ? "  " : (Percent >= 10 && Percent < 100) ? " " : "") + "{0:0.0}% [ ", Percent); ColorLine.WriteC(string.Empty.PadLeft(width, '█'), Green); Console.Write("{0} ] - ", string.Empty.PadLeft(fill, ' '));
                LastOutputLength = 5 + "% [ ".Length + barLength + " ] - ".Length;
            }
            ColorLine.WriteC(" DONE", Green); Console.WriteLine('!');
            Console.CursorVisible = true;
        }
        
    }
}
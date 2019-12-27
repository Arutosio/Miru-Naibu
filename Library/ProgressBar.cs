using System;

namespace Miru_Naibu.Library
{
    public class ProgBar
    {
        // Declaratuion Fase
        private readonly int barLength = 16;
        protected int ColorProgress { get; set; } = 10;
        protected char CharProgress { get; set; } = '█';
        public double Percent { get; set; } = 0;
        protected int LastOutputLength { get; set; }
        public ProgBar(int barSize)
        {
            barLength = barSize;
        }

        private double PercentCalculation(double current, double maximum)
        {
            return (current / maximum) * 100;
        }
        private void PrintProgressBar(double pasentto) 
        {
            // Generate new state 
            int width = (int)(pasentto / 100 * barLength);
            int fill = barLength - width;
            int pasenttoLength = pasentto < 10 ? 3 : (pasentto >= 10 && pasentto < 100) ? 4 : 5;
            string charEmpyInStartLine = pasentto < 10 ? "  " : (pasentto >= 10 && pasentto < 100) ? " " : "";
            Console.Write(charEmpyInStartLine + "{0:0.0}% [ ", pasentto);
            ColorLine.WriteC(string.Empty.PadLeft(width, CharProgress), ConsoleColor.Green); Console.Write("{0} ] - ", string.Empty.PadLeft(fill, ' '));
            LastOutputLength = charEmpyInStartLine.Length + pasenttoLength + "% [ ".Length + barLength + " ] - ".Length;
        }
        private void DeleteLastLine()
        {
            //Delete Last String
            string clear = string.Empty.PadRight(LastOutputLength, '\b');
            Console.Write(clear);
        }
        public void PrintProgressPrecentUpdating()
        {//this method need a percent with auto update
            Console.CursorVisible = false;
            double pasentto = 0;
            PrintProgressBar(pasentto);
            while (pasentto <= 100)
            {
                pasentto = Percent;
                DeleteLastLine();
                PrintProgressBar(pasentto);
            }
            ColorLine.WriteC(" DONE", ConsoleColor.Green); Console.WriteLine('!');
            Console.CursorVisible = true;
        }
        public void PrintProgress(double pasentto)
        {
            Console.CursorVisible = false;
            DeleteLastLine();
            PrintProgressBar(pasentto);
            Console.CursorVisible = true;
        }
    }
}
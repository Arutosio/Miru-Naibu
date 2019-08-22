using System;
namespace Miru_Naibu.Library
{
    public static class ColorLine
    {
        public static bool Ask() {
            Console.Write("(Yes = ");ColorLine.WriteC("Y", ConsoleColor.Green);
            Console.Write(")/(No = ");
            ColorLine.WriteC("Another One", ConsoleColor.Red);Console.Write("): ");
            return Console.ReadKey().KeyChar.ToString().ToLower().Equals("y");
        }
        public static void WriteC(string write, ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black: // 0
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkBlue: // 1
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkGreen: // 2
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkCyan: // 3
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkRed: // 4
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkMagenta: // 5
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkYellow:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkGray:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.Cyan:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(write); Console.ResetColor();
                    break;
                case ConsoleColor.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(write); Console.ResetColor();
                    break;
                default:
                    //Console.Write(write); Console.Write("(Error:ForegroundColor " + '"' + (color != null ? color + '"' + "not found." : ConsoleColor.You did not choose a color"));
                    break;
            }
        }
        public static void WriteLineC(string write, ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkBlue:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkGreen:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkCyan:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkRed:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkMagenta:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkYellow:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkGray:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Cyan:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                default:
                    //Console.Write(write); Console.Write("(Error:ForegroundColor " + '"' + (color != null ? color + '"' + "not found." : ConsoleColor.You did not choose a color"));
                    break;
            }
        }
        public static void BackgroundC(string write, ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkBlue:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkGreen:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkCyan:
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkRed:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkMagenta:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkYellow:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.DarkGray:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Gray:
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Blue:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Green:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Cyan:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Red:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Magenta:
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.Yellow:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                case ConsoleColor.White:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(write); Console.ResetColor();
                    break;
                default:
                    //Console.Write(write); Console.Write("(Error:BackgroundColor " + '"' + (color != null ? color + '"' + "not found." : ConsoleColor.You did not choose a color"));
                    break;
            }
        }
        public static string ReadLineC( ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case ConsoleColor.DarkBlue:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case ConsoleColor.DarkGreen:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case ConsoleColor.DarkCyan:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case ConsoleColor.DarkRed:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case ConsoleColor.DarkMagenta:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case ConsoleColor.DarkYellow:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case ConsoleColor.DarkGray:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case ConsoleColor.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case ConsoleColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case ConsoleColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ConsoleColor.Cyan:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case ConsoleColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case ConsoleColor.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case ConsoleColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ConsoleColor.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    //Console.WriteLine("(Error:ForegroundColor " + '"' + (color != null ? color + '"' + "not found." : ConsoleColor.You did not choose a color"));
                    break;
            }
            string res = Console.ReadLine();
            Console.ResetColor();
            return res;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentSpysColourLib
{
    class ColourEngine
    {
        private static ConsoleColor _Foreground;
        private static ConsoleColor _Background;
        private static ConsoleColor Foreground
        {
            get
            {
                return _Foreground;
            }
            set
            {
                _Foreground = value;
            }
        }
        private static ConsoleColor Background
        {
            get
            {
                return _Background;
            }
            set
            {
                _Background = value;
            }
        }
        public static void write(string data, ConsoleColor dataForeground, ConsoleColor dataBackground)
        {
            Foreground = Console.ForegroundColor;
            Background = Console.BackgroundColor;
            Console.ForegroundColor = dataForeground;
            Console.BackgroundColor = dataBackground;
            Console.Write(data);
            Console.ForegroundColor = Foreground;
            Console.BackgroundColor = Background;
        }
        public static void writeLine(string data, ConsoleColor dataForeground, ConsoleColor dataBackground)
        {
            Foreground = Console.ForegroundColor;
            Background = Console.BackgroundColor;
            Console.ForegroundColor = dataForeground;
            Console.BackgroundColor = dataBackground;
            Console.WriteLine(data);
            Console.ForegroundColor = Foreground;
            Console.BackgroundColor = Background;
        }
    }
}

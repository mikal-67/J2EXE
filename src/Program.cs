using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J2EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize vars
            string JClass = "";
            string CscLocation = "csc.exe";
            string JavaLocation = "java.exe";
            //check if java.exe is in path
            try
            {
                Process.Start("java.exe");
            }
            catch(System.ComponentModel.Win32Exception)
            {
                Console.WriteLine("ERROR: Location of Java (java.exe) not found, please enter it here:");
                JavaLocation = Console.ReadLine();
            }
            Console.WriteLine("Type the name of the class (without the .class extension)");
            Console.WriteLine("Hint: If your program has more than 1 class, type the name of the main class.");
            JClass = Console.ReadLine();
            string[] lines = { "using System;", "using System.Diagnostics;", "public class J2EXEDerivative {", "static void Main(string[] args){", $"Process.Start(\"{JavaLocation}\", \"{JClass}\" );", "}", "}" };
            //check if csc.exe is in path
            try
            {
                Process.Start("csc.exe");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.WriteLine("ERROR: Location of the C# Compiler (csc.exe) not found, please enter it here:");
                JavaLocation = Console.ReadLine();
            }
            //write code to file
            File.WriteAllLines(JClass + ".cs", lines);
            //compile it
            Process.Start("csc.exe", JClass + ".cs");
            File.Delete(JClass + ".cs");
            Console.WriteLine("Done.");
        }
    }
}

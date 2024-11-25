using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {
            using (StreamWriter sw = new StreamWriter("hello.bat", false))
            {
                sw.WriteLine("timeout 1");
                sw.WriteLine("del /f " + System.AppDomain.CurrentDomain.FriendlyName);
                sw.WriteLine("start cmd.exe /c cd " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + " && del /f hello.bat");
            };

            Process This = Process.GetCurrentProcess();

            Process.Start("cmd.exe", "/c hello.bat");

            This.Kill();

            Console.WriteLine("got here");
            Console.Read();
        }
    }
}

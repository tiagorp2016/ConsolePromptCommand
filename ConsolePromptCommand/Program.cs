using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePromptCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o ip:");

            var ip = Console.ReadLine();            

            var retornoCMD = ExecutarCMD($@"shutdown -s -f -t 60 -m \\{ip}");
                       

            Console.ReadKey();
        }

        public static string ExecutarCMD(string comando)
        {
            try
            {
                using (Process processo = new Process())
                {
                    processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                    // Formata a string para passar como argumento para o cmd.exe
                    processo.StartInfo.Arguments = string.Format("/c {0}", comando);

                    processo.StartInfo.RedirectStandardOutput = true;
                    processo.StartInfo.UseShellExecute = false;
                    processo.StartInfo.CreateNoWindow = true;

                    processo.Start();
                    processo.WaitForExit();

                    string saida = processo.StandardOutput.ReadToEnd();
                    return saida;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.IO;

// TODO: Replace the following version attributes by creating AssemblyInfo.cs. You can do this in the properties of the Visual Studio project.
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]
[assembly: AssemblyInformationalVersion("1.0")]

// TODO: Uncomment the following line if the script requires write access.
// [assembly: ESAPIScript(IsWriteable = true)]

namespace Treatment_Report
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                using (Application app = Application.CreateApplication())
                {
                    Console.WriteLine("Acessando o Banco de dados...");
                    Execute(app);
                    Console.WriteLine("A aplicação terminou com êxito...");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        static void Execute(Application app)
        {
            // TODO: Add your code here.
            DateTime currentDate = DateTime.Now;

            //Criando o arquivo de saída dos dados
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = $"Treatment_Report_{currentDate.ToString("dd-MM-yyyy")}.csv";
            string outputPath = Path.Combine(baseDirectory, fileName);

            StreamWriter dataFile = new StreamWriter(outputPath);

            //Definindo o Header
            string header = "ID, Curso, Plano, Acelerador, Status do Plano, Fracionamento, Fracoes Comp/Fracoes Plan, Data do Ult TTO";
            dataFile.WriteLine(header);

            //Definindo a data de inicio da busca
            DateTime startDate = currentDate - TimeSpan.FromDays(120);










            dataFile.Close();

        }
    }
}

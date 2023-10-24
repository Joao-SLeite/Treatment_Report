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
                    Console.WriteLine("A aplica��o terminou com �xito...");
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

            //Criando o arquivo de sa�da dos dados
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = $"Treatment_Report_{currentDate.ToString("dd-MM-yyyy")}.csv";
            string outputPath = Path.Combine(baseDirectory, fileName);

            StreamWriter dataFile = new StreamWriter(outputPath);

            //Definindo o Header
            string header = "ID, Curso, Plano, Acelerador, Status do Plano, Fracionamento, Fracoes Comp/Fracoes Plan, Data do Ult TTO";
            dataFile.WriteLine(header);

            //Definindo a data de inicio da busca
            DateTime startDate = currentDate - TimeSpan.FromDays(120);

            IEnumerable<PatientSummary> patientSummaries = app.PatientSummaries;
            Console.WriteLine("Quantidade de Pacientes: " + patientSummaries.Count());
            foreach (PatientSummary patientSummary in patientSummaries)
            {
                try
                {
                    Patient patient = app.OpenPatient(patientSummary);

                    foreach (Course course in patient.Courses.Where(c => c.IsCompleted() == false && c.Id.ToUpper().Contains("CQ") == false && c.Id.ToUpper().Contains("QA") == false))
                    {
                        if (course.StartDateTime >= startDate || course.HistoryDateTime >= startDate)
                        {
                            IEnumerable<PlanSetup> planSetups = course.PlanSetups;
                            foreach (PlanSetup planSetup in planSetups.Where(p => p.IsTreated || p.ApprovalStatus == PlanSetupApprovalStatus.TreatmentApproved))
                            {
                                List<DateTime> dateSessions = new List<DateTime>();

                                IEnumerable<PlanTreatmentSession> planTreatmentSessions = planSetup.TreatmentSessions;
                                if (planSetup.PlanType == PlanType.ExternalBeam && planTreatmentSessions.Count() != 0 && planTreatmentSessions.FirstOrDefault().HistoryDateTime >= startDate)
                                {
                                    foreach (PlanTreatmentSession planTreatmentSession in planTreatmentSessions)
                                    {
                                        if (planTreatmentSession.Status == TreatmentSessionStatus.Completed)
                                        {
                                            dateSessions.Add(planTreatmentSession.HistoryDateTime);
                                        }
                                    }

                                    string dateLastTreatment = "Inicio";
                                    if (dateSessions.Count() != 0)
                                    {
                                        dateLastTreatment = dateSessions.Max().ToString();
                                    }
                                    string output = $"{patient.Id}, {course.Id}, {planSetup.Id}, {planSetup.Beams.FirstOrDefault().TreatmentUnit}, {planSetup.ApprovalStatus}," +
                                        $"{planSetup.NumberOfFractions}x{planSetup.DosePerFraction}," +
                                        $"{dateSessions.Count()}|{planSetup.NumberOfFractions}, {dateLastTreatment}";
                                    dataFile.WriteLine(output);
                                    Console.WriteLine(output);
                                }
                            }
                        }
                    }
                    app.ClosePatient();
                }
                catch (ApplicationException)
                {
                    continue;
                }

            }
            dataFile.Close();
        }
    }
}

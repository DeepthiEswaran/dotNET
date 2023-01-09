using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Diseases
    {
        public string DName { get; set;}
        public string Severity { get;  set; }

        public void ShallowCopy(Diseases copy)
        {
            this.DName = copy.DName;
            this.Severity = copy.Severity;
        }
        public Diseases DeepCopy(Diseases copy)
        {
            Diseases diseases = new Diseases();
            diseases.ShallowCopy(copy);
            return diseases;
        }
    }
    namespace Repository
    {
        using SampleConApp;
        class Symptoms  : Diseases
        {
        public string Sympt { get; set; }
        public int temperature { get; set; }
        private Diseases[] _disease = null;
        private static int _size=0;

        public Symptoms(int size)
            {
                
                _size = size;
                _disease = new Diseases[_size];
            }

            public void AddDisease(Diseases disease)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_disease[i] == null)
                    {
                        _disease[i] = disease.DeepCopy(disease);
                      
                    }
                }
               
            }
            public void AddSymptom(Diseases disease)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_disease[i] != null)

                    {
                        _disease[i] = disease.DeepCopy(disease);
                        
                    }
                }
            }
        }
    }
    namespace PatientDetails
    {
        using Repository;
        using SampleConApp;
        class Patient
        {
            public int PatientId { get; set;}
            public string PatientName { get; set; }

        }
    }
    namespace UILayer
    {
        using Repository;
        using SampleConApp;
        enum Optionsss
        {
            AddDisease = 1, AddSymptom = 2, PatientDetails=3
        }
        class UIComponenT
        {
            public const string Diseases = "~~~~~~~~~~~~~~~~Medical Research Application~~~~~~~~~~~\nTo Add New Disease----------->PRESS 1\nTo Add New Symptom----------->PRESS 2\nPatient Details------>PRESS 3";
            private static Symptoms repo = null;
            public static void Run()
            {
        
                bool processing = true;
                do
                {
                    string option = Utilities.Prompt(Diseases);
                    processing = Process(option);
                } while (processing);
                Console.WriteLine("Thanks for Using our Application!!!");
            }
            private static bool Process(string option)
            {
                switch (option)
                {
                    case "1":
                        AddDise();
                        break;
                    case "2":
                        AddSymp();
                        break;
                    default:
                        return false;
                }
                return true;
            }
            private static void AddDise()
            {
                Console.WriteLine("Enter Disease Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Severity");
                string severity = Console.ReadLine();
               /*if (severity == ("low"||" medium"||"high"))
                {
                    Console.WriteLine("Valid");
                }
                Console.WriteLine("InValid");*/
                Diseases ds = new Diseases { DName = name, Severity = severity };
                repo.AddDisease(ds);
            }
            private static void AddSymp()
            {
                Console.WriteLine("Enter the Symptoms");
                string sympt = Console.ReadLine();
                Console.WriteLine("Temperature");
                int temperature = Convert.ToInt32(Console.ReadLine());
              //  string author = Utilities.Prompt("Enter the author");
                try
                {
                    Diseases[] ds = repo.AddSymptom(disease);

                    foreach (Diseases item in ds)
                    {

                        Console.WriteLine("The Symptom is " + item.DName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

    


            }
        }
    namespace Testing
    {
        using Repository;
        using SampleConApp;
        using System;
        class Mainfunc
        {
            static void Main(string[] args)
            {
                UILayer.UIComponenT.Run();

            }
        }
    }
}



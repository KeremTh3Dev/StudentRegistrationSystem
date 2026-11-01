
namespace StudentRegistrationSystem
{
    
    public class Student
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string StudentNo { get; set; }
    public int Grade { get; set; }
}
    public static class MainLoop
    {
        public static List<Student> students = new List<Student>();


        public static void Run()
        {
            GiveInformation();
            RunCommandLoop();
        }

        public static void GiveInformation()
        {
            Console.WriteLine("(komutlar: ogrencikaydet, ogrencinotgir, listeyikaydet, cikis)");
        }

        public static void RunCommandLoop()
        {
            //get input & direct accordingly

            bool unrecognizedCommand = false;
            do
            {
                unrecognizedCommand = false;
                Console.Write("Komut Giriniz >> ");
                string? komut = Console.ReadLine();

                switch (komut)
                {
                    case "ogrencikaydet":
                        RegisterStudent();
                        break;
                    case "ogrencinotgir":
                        EnterGrades();
                        break;
                    case "listeyikaydet":
                        SaveList();
                        break;
                    case "cikis":
                        return;
                    default:
                        Thread.Sleep(400); //waitfor 0.4s
                        Console.WriteLine("\n >>> Tanınmayan komut!\n");
                        Thread.Sleep(400); //waitfor 0.4s
                        unrecognizedCommand = true;
                        break;
                }
            }
            while (unrecognizedCommand);

        }

        public static void RegisterStudent()
        {
            Console.WriteLine("\n--- Öğrenci Kayıt Modu ---");
            Console.WriteLine("Ana menüye dönmek için isim kısmına 'q' yazabilirsiniz.\n");

            while (true)
            {
                Console.Write("Öğrenci Adı: ");
                string name = Console.ReadLine()?.Trim() ?? "";

                if (name.ToLower() == "q")
                {
                    Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                    break;
                }

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine(">>> İsim boş olamaz!\n");
                    continue;
                }

                Console.Write("Öğrenci Soyadı: ");
                string surname = Console.ReadLine()?.Trim() ?? "";

                if (surname.ToLower() == "q")
                {
                    Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                    break;
                }

                if (string.IsNullOrEmpty(surname))
                {
                    Console.WriteLine(">>> Soyisim boş olamaz!\n");
                    continue;
                }

                Console.Write("Öğrenci Numarası: ");
                string studentNo = Console.ReadLine()?.Trim() ?? "";

                if (studentNo.ToLower() == "q")
                {
                    Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                    break;
                }

                if (string.IsNullOrEmpty(studentNo))
                {
                    Console.WriteLine(">>> Öğrenci numarası boş olamaz!\n");
                    continue;
                }

                Student newStudent = new Student
                {
                    Name = name,
                    Surname = surname,
                    StudentNo = studentNo,
                    Grade = 0
                };

                students.Add(newStudent);
                Console.WriteLine(">>> Öğrenci başarıyla kaydedildi!\n");
            }
        }

        public static void EnterGrades()
        {
            Console.WriteLine("\n--- Not Girme Modu ---");
            Console.WriteLine("Ana menüye dönmek için not kısmına 'q' yazabilirsiniz.\n");
        }
        public static void SaveList()
        {
            //save lists
        }
    }
}

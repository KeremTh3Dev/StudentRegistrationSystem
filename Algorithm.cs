
namespace StudentRegistrationSystem
{


    public class Student
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string StudentNo { get; set; }
        public string? Grade { get; set; }

    }


    public static class Algorithm
    {
        public static List<Student> students = new List<Student>();

        public static void RegisterStudent()
        {
            Console.Clear();
            Console.WriteLine("\n--- Öğrenci Kayıt Modu ---");
            Console.WriteLine("Ana menüye dönmek için isim kısmına 'q' yazabilirsiniz.\n");

            while (true)
            {
                string name, surname, studentNo; //grade;
                while (true)
                {
                    Console.Write("Öğrenci Adı: ");
                    name = Console.ReadLine()?.Trim() ?? "";

                    if (name.ToLower() == "q")
                    {
                        Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                        Manage.MainMenu();
                        return;
                    }
                    if (string.IsNullOrEmpty(name) || !name.All(char.IsLetter))
                    {
                        Console.WriteLine(">>> Geçersiz isim\n");
                        continue;
                    }
                    break;
                }

                //---------------------------------

                while (true)
                {
                    Console.Write("Öğrenci Soyadı: ");
                    surname = Console.ReadLine()?.Trim() ?? "";

                    if (surname.ToLower() == "q")
                    {
                        Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                        Manage.MainMenu();
                        return;
                    }

                    if (string.IsNullOrEmpty(surname) || !surname.All(char.IsLetter))
                    {
                        Console.WriteLine(">>> Geçersiz soyad\n");
                        continue;
                    }
                    break;
                }

                //---------------------------------

                while (true)
                {
                    Console.Write("Öğrenci Numarası: ");
                    studentNo = Console.ReadLine()?.Trim() ?? "";

                    if (studentNo.ToLower() == "q")
                    {
                        Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                        Manage.MainMenu();
                        return;
                    }

                    if (string.IsNullOrEmpty(studentNo) || !int.TryParse(studentNo, out int parsedStudentNo) || parsedStudentNo < 1 || parsedStudentNo > 1000)
                    {
                        Console.WriteLine(">>> Geçersiz öğrenci numarası\n");
                        continue;
                    }
                    break;
                }



                Student newStudent = new Student
                {
                    Name = name,
                    Surname = surname,
                    StudentNo = studentNo,
                };

                students.Add(newStudent);
                Console.Clear();
                Console.WriteLine("\n  >>> Öğrenci başarıyla kaydedildi!\n");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine(" Sonraki öğrencinin bilgileri:\n\n (cıkmak icin q basiniz)\n\n\n");
            }
        }


        public static void SaveList()
        {
            Console.Clear();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentNo} no {student.Name} {student.Surname} adlı öğrencinin notu: {student.Grade}\n");
            }
            
            while (true)
            {
                Console.Write("\n >> Girilen bilgileri düzenlemek istiyor musunuz? (Y/N): ");
                string input = Console.ReadLine()?.Trim().ToLower() ?? "";
                if(input == "y")
                {
                    //bilgileri düzenlet
                }
                else if(input == "n")
                {
                    Console.Clear();
                    System.Console.WriteLine("Liste varsayılan olarak masaüstüne kaydedilecek, farklı bir dizin belirlemek ister misiniz? (Y/N)");
                    string input1 = Console.ReadLine()?.Trim().ToLower() ?? "";
                    if(input1 == "y")
                    {
                        //dizin sor ve o dizine kaydet.
                    }
                    else if(input1 == "n")
                    {
                        //desktopa kaydet
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        public static void ThrowException()
        {
            Thread.Sleep(400); //waitfor 0.4s
            Console.WriteLine("\n >>> Tanınmayan komut!\n");
            Thread.Sleep(400); //waitfor 0.4s
            Console.Clear();
        }
        public static void GiveInformation()
        {
            Console.WriteLine(" komutlar: ogrenciekle, notekle, kaydetvecik\n");
        }
        public static void Welcome()
        {
            Thread.Sleep(200);
            Console.Write("\n\n-- Sisteme Hoşgeldiniz! -- ");
            Thread.Sleep(3000);
        }

        public static void EnterGrades()
        {
            if (students.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\nÖncelikle en az 1 öğrenci kaydediniz.\n");
                Thread.Sleep(3000);
                Manage.MainMenu();
            }
            else
            {
                Console.Clear();
                foreach (var student in students)
                {
                    while (true)
                    {
                        Console.Write($"{student.Name} {student.Surname} ({student.StudentNo}no) adlı öğrencinin notu: ");
                        string temporaryInput = Console.ReadLine() ?? "";

                        if (temporaryInput?.ToLower() == "q")
                        {
                            Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                            Manage.MainMenu();
                            return;
                        }

                        if (string.IsNullOrEmpty(temporaryInput) || !int.TryParse(temporaryInput, out int parsedGrade) || parsedGrade < 0 || parsedGrade > 100)
                        {
                            Console.WriteLine("Geçersiz öğrenci notu!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            continue;
                        }
                        student.Grade = temporaryInput;
                        Console.Clear();
                        break;
                    }
                }
                LoadingAnim(2, LoadingType.dots);
                Console.Write("Tüm notlar başarıyla eklendi! ");
                Thread.Sleep(2000);
                Manage.MainMenu();
            }
        }


        public enum LoadingType
        {
            dots,
            text
        }
        public static void LoadingAnim(int loopCount, LoadingType type)
        {
            Console.CursorVisible = false;
            Console.Clear(); // Begin

            switch (type)
            {
                case LoadingType.dots:
                    for (int i = 0; i < loopCount; i++)
                    {
                        Console.Clear();
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(".");
                            Thread.Sleep(333);
                        }
                    }
                    Console.Clear();
                    break;

                case LoadingType.text:
                    for (int i = 0; i < loopCount; i++)
                    {
                        Console.Clear();
                        Console.Write("\n Loading");
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(".");
                            Thread.Sleep(333);
                        }
                    }
                    Console.Clear();
                    break;
            }
            Console.CursorVisible = true;
        }
    }
}
namespace StudentRegistrationSystem
{

    public class Course
    {
        public required string CourseName { get; set; }
        public required string Ects { get; set; }
    }
    public class CourseGrade
    {
        public required Course Course { get; set; }
        public required string Score { get; set; }
    }
    public class Student
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string StudentNo { get; set; }
        public List<CourseGrade> Grades { get; set; } = new();

    }



    public static class Algorithm
    {
        public static List<Student> students = new List<Student>();
        public static List<Course> courses = new List<Course>();
        public static void RegisterStudent()
        {
            Console.Clear();
            Console.WriteLine("\n--- Öğrenci Kayıt Modu ---");
            Console.WriteLine("Ana menüye dönmek için isim kısmına 'q' yazabilirsiniz.\n");

            while (true)
            {
                string name, surname, studentNo;
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

                    if (string.IsNullOrEmpty(studentNo) || !int.TryParse(studentNo, out int parsedStudentNo) || parsedStudentNo < 1 || parsedStudentNo > 10000)
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

        public static void RegisterCourse()
        {
            Console.Clear();
            Console.WriteLine("\n--- Ders Kayıt Modu ---");
            Console.WriteLine("Ana menüye dönmek için isim kısmına 'q' yazabilirsiniz.\n");

            while (true)
            {
                string courseName, ects;

                while (true)
                {
                    Console.Write("Ders Adı: ");
                    courseName = Console.ReadLine()?.Trim() ?? "";

                    if (courseName.ToLower() == "q")
                    {
                        Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                        Manage.MainMenu();
                        return;
                    }
                    if (string.IsNullOrEmpty(courseName) || !courseName.All(char.IsLetter))
                    {
                        Console.WriteLine(">>> Geçersiz ad\n");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write("Ders kredisi: ");
                    ects = Console.ReadLine()?.Trim() ?? "";

                    if (ects.ToLower() == "q")
                    {
                        Console.WriteLine(">>> Kayıt modundan çıkıldı.\n");
                        Manage.MainMenu();
                        return;
                    }
                    if (string.IsNullOrEmpty(ects) || !int.TryParse(ects, out int parsedEcts) || parsedEcts < 1 || parsedEcts > 10)
                    {
                        Console.WriteLine(">>> Geçersiz ders kredisi\n");
                        continue;
                    }
                    break;
                }

                Course newCourse = new Course
                {
                    CourseName = courseName,
                    Ects = ects
                };

                courses.Add(newCourse);
                Console.Clear();
                Console.WriteLine("\n  >>> Ders başarıyla kaydedildi!\n");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine(" Sonraki dersin bilgileri:\n\n (cıkmak icin q basiniz)\n\n\n");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------U N D E R-------------------------------------------------------------------------------------------------------
        public static void SaveList()
        {
            while (true)
            {
                ShowRegistered();
                Console.Write("\n >> Girilen bilgileri düzenlemek istiyor musunuz? (Y/N): ");
                string input = Console.ReadLine()?.Trim().ToLower() ?? "";
                if (input == "y")
                {
                    //bilgileri düzenlet (sırasıyla ders ve student sınıfı)
                }
                else if (input == "n")
                {
                    Console.Clear();
                    System.Console.Write("Liste varsayılan olarak masaüstüne kaydedilecek, farklı bir dizin belirlemek ister misiniz? (Y/N)");
                    string input1 = Console.ReadLine()?.Trim().ToLower() ?? "";
                    if (input1 == "y")
                    {
                        Console.Clear();
                        Console.WriteLine("Lütfen listeyi kaydetmek istediğiniz dosya dizinini aşağıya kopyalayın");
                        Console.Write("Dosya dizini: ");
                        string path = Console.ReadLine() ?? ""; //burası windows/linuxte farklı olur gibi yav onu nasıl yapıcaz...
                        //dizin sor ve o dizine kaydet.
                    }
                    else if (input1 == "n")
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
        public static void ShowRegistered()
        {
            Console.Clear();

            int studentIndex = 1;
            foreach (var student in students)
            {
                Console.WriteLine($" [{studentIndex}] {student.StudentNo} no {student.Name} {student.Surname} adlı öğrencinin notları:");

                int gradeIndex = 1;
                foreach (var g in student.Grades)
                {
                    Console.WriteLine($"({gradeIndex}) {g.Course.CourseName} ({g.Course.Ects} AKTS): {g.Score}p   ");
                    gradeIndex++;
                }

                Console.WriteLine("\n");
                studentIndex++;
            }
        }
        public static void GiveInformation()
        {
            Console.WriteLine(" komutlar: ogrenciekle, dersekle, notekle, kaydetvecik\n");
        }
        public static void Welcome()
        {
            Thread.Sleep(200);
            Console.Write("\n\n-- Sisteme Hoşgeldiniz! -- ");
            Thread.Sleep(3000);
        }


        public static void EditRegistered()
        {
            
            while (true)
            {
                ShowRegistered(); 
                Console.Write("Öğrenci sırasını girin: ");
                int studentIndex = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nÖğrencinin ders sırasını girin: ");
                int gradeIndex = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Öğrenci getiriliyor...");
                Thread.Sleep(500);
                LoadingAnim(2, LoadingType.text);
                ShowStudent(studentIndex, gradeIndex);
                int sIdx = studentIndex - 1;
                int gIdx = gradeIndex - 1;
                
                while (true)
                {
                    Console.Write("Düzenlemek istediğiniz kaydın sırasını seçiniz: ");
                    int registryIndex = Convert.ToInt32(Console.ReadLine());

                    switch (registryIndex)
                    {
                        case 1:
                        //adını degistir
                        Console.WriteLine($"Eski ad: {students[sIdx].Name}");
                        Console.Write($"Yeni ad:");
                        students[sIdx].Name = Console.ReadLine() ?? "";
                        Console.WriteLine("Ad başarıyla değiştirildi!");
                        Thread.Sleep(2000);
                        break;

                        case 2:
                        //soyadı degistir
                        Console.WriteLine($"Eski soyad: {students[sIdx].Surname}");
                        Console.Write($"Yeni soyad:");
                        students[sIdx].Surname = Console.ReadLine() ?? "";
                        Console.WriteLine("Soyad başarıyla değiştirildi!");
                        Thread.Sleep(2000);
                        break;

                        case 3:
                        //numara degistir
                        Console.WriteLine($"Eski numara: {students[sIdx].StudentNo}");
                        Console.Write($"Yeni numara:");
                        students[sIdx].StudentNo = Console.ReadLine() ?? "";
                        Console.WriteLine("Numara başarıyla değiştirildi!");
                        Thread.Sleep(2000);
                        break;

                        case 4:
                        //Ders adını değiştir
                        System.Console.WriteLine($"Uyarı: Bütün {students[sIdx].Grades[gIdx].Course.CourseName} adlı dersler değişecek!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Console.WriteLine($"Eski ders adı: {students[sIdx].Grades[gIdx].Course.CourseName}");
                        Console.Write($"Yeni ders adı:");
                        students[sIdx].Grades[gIdx].Course.CourseName = Console.ReadLine() ?? "";
                        Console.WriteLine("Ders adı başarıyla değiştirildi!");
                        Thread.Sleep(2000);
                        break;

                        case 5:
                        //ders akts degistir (uyarı)
                        System.Console.WriteLine($"Uyarı: Bütün {students[sIdx].Grades[gIdx].Course.Ects} adlı derslerin kredisi değişecek!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Console.WriteLine($"Eski ders kredisi: {students[sIdx].Grades[gIdx].Course.Ects}");
                        Console.Write($"Yeni ders kredisi:");
                        students[sIdx].Grades[gIdx].Course.Ects = Console.ReadLine() ?? "";
                        Console.WriteLine("Ders kredisi başarıyla değiştirildi!");
                        Thread.Sleep(2000);
                        break;

                        case 6:
                        //ders notunu degistir
                        Console.WriteLine($"Eski ders notu: {students[sIdx].Grades[gIdx].Score}");
                        Console.Write($"Yeni ders notu:");
                        students[sIdx].Grades[gIdx].Score = Console.ReadLine() ?? "";
                        Console.WriteLine("Ders notu başarıyla değiştirildi!");
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
        }

        public static void ShowStudent(int studentIndex, int gradeIndex)
        {
            // 0-based indekse çek
            int sIdx = studentIndex - 1;
            int gIdx = gradeIndex - 1;

            // Öğrenci indeksi listede var mı?
            if (sIdx < 0 || sIdx >= students.Count)
            {
                Console.WriteLine(">>> Geçersiz öğrenci sırası!");
                return;
            }
            // Seçilen öğrencinin o indekste dersi var mı?
            if (gIdx < 0 || gIdx >= students[sIdx].Grades.Count)
            {
                Console.WriteLine(">>> Geçersiz ders sırası!");
                return;
            }

            Console.WriteLine($"(1) Öğrenci adı: {students[sIdx].Name}");
            Console.WriteLine($"(2) Öğrenci soyadı: {students[sIdx].Surname}");
            Console.WriteLine($"(3) Öğrenci numarası: {students[sIdx].StudentNo}");

            Console.WriteLine($"(4) Ders adı: {students[sIdx].Grades[gIdx].Course.CourseName}");
            Console.WriteLine($"(5) Ders AKTS: {students[sIdx].Grades[gIdx].Course.Ects}");
            Console.WriteLine($"(6) Ders Notu: {students[sIdx].Grades[gIdx].Score}");
        }


        public static void EnterGrades()
        {
            if (students.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\nÖncelikle en az 1 öğrenci kaydediniz.\n");
                Thread.Sleep(3000);
                Manage.MainMenu();
                return;
            }
            if (courses.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\nÖncelikle en az 1 ders kaydediniz.\n");
                Thread.Sleep(3000);
                Manage.MainMenu();
                return;
            }
            else
            {
                Console.Clear();
                foreach (var student in students)
                {
                    student.Grades.Clear();

                    foreach (var course in courses)
                    {
                        while (true)
                        {
                            Console.Write($"{student.Name} {student.Surname} ({student.StudentNo}no) - {course.CourseName} notu: ");
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

                            student.Grades.Add(new CourseGrade
                            {
                                Course = course,
                                Score = temporaryInput
                            });
                            Console.Clear();
                            break;
                        }
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
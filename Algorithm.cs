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
                        return;
                    }
                    if (string.IsNullOrEmpty(name) || !IsValidName(name))
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
                        return;
                    }

                    if (string.IsNullOrEmpty(surname) || !IsValidName(surname))
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
                        return;
                    }
                    if (string.IsNullOrEmpty(courseName) || !IsValidName(courseName))
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
        public static bool SaveList()
        {
            if (students.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\nÖncelikle en az 1 öğrenci kaydediniz.\n");
                Thread.Sleep(3000);
                return false;
            }

            // --- Düzenleme sorusu ---
            while (true)
            {
                ShowRegistered();
                if (AskYesNo("\n >> Girilen bilgileri düzenlemek istiyor musunuz? (Y/N): "))
                {
                    EditRegistered(); // kendi sonunda ana menüye döner
                    return false;
                }
                break;
            }

            // --- Kayıt dizini seçimi ve kaydetme ---
            while (true)
            {
                Console.Clear();
                string directory;

                if (AskYesNo("Liste varsayılan olarak masaüstüne kaydedilecek, farklı bir dizin belirlemek ister misiniz? (Y/N): "))
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen listeyi kaydetmek istediğiniz dosya dizinini aşağıya kopyalayın");
                    Console.WriteLine("(Ana menüye dönmek için 'q' yazabilirsiniz.)\n");

                    while (true)
                    {
                        Console.Write("Dosya dizini: ");
                        string input = Console.ReadLine()?.Trim() ?? "";

                        if (input.ToLower() == "q")
                        {
                            Console.WriteLine(">>> Kaydetme modundan çıkıldı.\n");
                            return false;
                        }

                        // Windows'ta "Yol olarak kopyala" yapınca gelen tırnakları temizle
                        input = input.Trim('"', '\'').Trim();

                        if (string.IsNullOrEmpty(input) || !Directory.Exists(input))
                        {
                            Console.WriteLine(">>> Dizin bulunamadı!\n");
                            continue;
                        }

                        directory = input;
                        break;
                    }
                }
                else
                {
                    directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    // Linux'ta masaüstü klasörü yoksa boş dönebilir, ana klasöre kaydet
                    if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
                    {
                        directory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        Console.WriteLine("\n>>> Masaüstü bulunamadı, ana klasöre kaydedilecek.");
                        Thread.Sleep(1500);
                    }
                }

                // --- Dosya içeriğini hazırla (ShowRegistered ile aynı görünüm) ---
                var sb = new System.Text.StringBuilder();
                int studentIndex = 1;
                foreach (var student in students)
                {
                    sb.AppendLine($" [{studentIndex}] {student.StudentNo} no {student.Name} {student.Surname} adlı öğrencinin notları:");

                    if (student.Grades.Count == 0)
                    {
                        sb.AppendLine("     Not kaydı yok.");
                    }

                    int gradeIndex = 1;
                    foreach (var g in student.Grades)
                    {
                        sb.AppendLine($"({gradeIndex}) {g.Course.CourseName} ({g.Course.Ects} AKTS): {g.Score}p");
                        gradeIndex++;
                    }

                    sb.AppendLine();
                    studentIndex++;
                }

                string fileName = $"ogrenci_listesi_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string fullPath = Path.Combine(directory, fileName);

                // --- Dosyaya yaz ---
                try
                {
                    File.WriteAllText(fullPath, sb.ToString(), new System.Text.UTF8Encoding(true));
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("\n>>> Bu dizine yazma izniniz yok!");
                    Thread.Sleep(2500);
                    continue; // dizin sorusuna geri dön
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n>>> Dosya kaydedilemedi: {ex.Message}");
                    Thread.Sleep(2500);
                    continue;
                }

                Console.Clear();
                Console.WriteLine("\n  >>> Liste başarıyla kaydedildi!\n");
                Console.WriteLine($"  Konum: {fullPath}\n");
                Thread.Sleep(3000);
                return true;
            }

            // ----------- Yerel yardımcı fonksiyon -----------

            // Y/N cevabı alana kadar sorar. y -> true, n -> false.
            static bool AskYesNo(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine()?.Trim().ToLower() ?? "";

                    if (input == "y") return true;
                    if (input == "n") return false;

                    ThrowException();
                }
            }
        }


        // Harf ve boşluk kabul eder (ör. "Ali Can", "Veri Yapıları")
        public static bool IsValidName(string s) =>
            !string.IsNullOrWhiteSpace(s) && s.All(c => char.IsLetter(c) || c == ' ');

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
            if (students.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\nÖncelikle en az 1 öğrenci kaydediniz.\n");
                Thread.Sleep(3000);
                return;
            }

            ShowRegistered();
            Console.WriteLine(" Ana menüye dönmek için 'q' yazabilirsiniz.\n");

            // --- Öğrenci seçimi ---
            if (!ReadIndex("Öğrenci sırasını girin: ", 1, students.Count, out int studentIndex))
            {
                Console.WriteLine(">>> Düzenleme modundan çıkıldı.\n");
                return;
            }

            int sIdx = studentIndex - 1;
            Student student = students[sIdx];
            bool hasGrades = student.Grades.Count > 0;
            int gIdx = -1;

            // --- Ders seçimi (not kaydı varsa) ---
            if (hasGrades)
            {
                if (!ReadIndex("\nÖğrencinin ders sırasını girin: ", 1, student.Grades.Count, out int gradeIndex))
                {
                    Console.WriteLine(">>> Düzenleme modundan çıkıldı.\n");
                    return;
                }
                gIdx = gradeIndex - 1;
            }
            else
            {
                Console.WriteLine("\nBu öğrencinin not kaydı yok, sadece ad, soyad ve numara düzenlenebilir.");
                Thread.Sleep(2000);
            }

            Console.WriteLine("Öğrenci getiriliyor...");
            Thread.Sleep(500);
            LoadingAnim(2, LoadingType.text);

            // --- Düzenleme döngüsü ---
            while (true)
            {
                Console.Clear();
                if (hasGrades)
                {
                    ShowStudent(studentIndex, gIdx + 1);
                }
                else
                {
                    Console.WriteLine($"(1) Öğrenci adı: {student.Name}");
                    Console.WriteLine($"(2) Öğrenci soyadı: {student.Surname}");
                    Console.WriteLine($"(3) Öğrenci numarası: {student.StudentNo}");
                }
                Console.WriteLine("\n (çıkmak için q basınız)\n");

                int maxField = hasGrades ? 6 : 3;
                if (!ReadIndex("Düzenlemek istediğiniz kaydın sırasını seçiniz: ", 1, maxField, out int registryIndex))
                {
                    Console.WriteLine(">>> Düzenleme modundan çıkıldı.\n");
                    return;
                }

                string newValue;
                switch (registryIndex)
                {
                    case 1:
                        if (!ReadValue("ad", student.Name, IsValidName, ">>> Geçersiz isim\n", out newValue))
                        {
                            return;
                        }
                        student.Name = newValue;
                        Console.WriteLine("Ad başarıyla değiştirildi!");
                        break;

                    case 2:
                        if (!ReadValue("soyad", student.Surname, IsValidName, ">>> Geçersiz soyad\n", out newValue))
                        {
                            return;
                        }
                        student.Surname = newValue;
                        Console.WriteLine("Soyad başarıyla değiştirildi!");
                        break;

                    case 3:
                        if (!ReadValue("numara", student.StudentNo, IsValidStudentNo, ">>> Geçersiz öğrenci numarası\n", out newValue))
                        {
                            return;
                        }
                        student.StudentNo = newValue;
                        Console.WriteLine("Numara başarıyla değiştirildi!");
                        break;

                    case 4:
                        Console.WriteLine($"Uyarı: Bütün {student.Grades[gIdx].Course.CourseName} adlı dersler değişecek!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        if (!ReadValue("ders adı", student.Grades[gIdx].Course.CourseName, IsValidName, ">>> Geçersiz ad\n", out newValue))
                        {
                            return;
                        }
                        student.Grades[gIdx].Course.CourseName = newValue;
                        Console.WriteLine("Ders adı başarıyla değiştirildi!");
                        break;

                    case 5:
                        Console.WriteLine($"Uyarı: Bütün {student.Grades[gIdx].Course.CourseName} adlı derslerin kredisi değişecek!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        if (!ReadValue("ders kredisi", student.Grades[gIdx].Course.Ects, IsValidEcts, ">>> Geçersiz ders kredisi\n", out newValue))
                        {
                            return;
                        }
                        student.Grades[gIdx].Course.Ects = newValue;
                        Console.WriteLine("Ders kredisi başarıyla değiştirildi!");
                        break;

                    case 6:
                        if (!ReadValue("ders notu", student.Grades[gIdx].Score, IsValidScore, ">>> Geçersiz öğrenci notu\n", out newValue))
                        {
                            return;
                        }
                        student.Grades[gIdx].Score = newValue;
                        Console.WriteLine("Ders notu başarıyla değiştirildi!");
                        break;

                    default:
                        ThrowException();
                        continue;
                }

                Thread.Sleep(2000);

                // --- Devam mı? ---
                while (true)
                {
                    Console.Clear();
                    Console.Write("Başka bir kaydı düzenlemek istiyor musunuz? (Y/N): ");
                    string answer = Console.ReadLine()?.Trim().ToLower() ?? "";

                    if (answer == "y")
                    {
                        break; // dıştaki döngü: aynı öğrenci/ders ile devam
                    }
                    if (answer == "n" || answer == "q")
                    {
                        Console.WriteLine(">>> Düzenleme modundan çıkıldı.\n");
                        return;
                    }
                    ThrowException();
                }
            }

            // ----------- Yerel yardımcı fonksiyonlar -----------

            // Sıra numarası okur. 'q' yazılırsa false döner.
            static bool ReadIndex(string prompt, int min, int max, out int value)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine()?.Trim() ?? "";

                    if (input.ToLower() == "q")
                    {
                        value = 0;
                        return false;
                    }
                    if (int.TryParse(input, out value) && value >= min && value <= max)
                    {
                        return true;
                    }
                    Console.WriteLine(">>> Geçersiz sıra!\n");
                }
            }

            // Eski değeri gösterip yeni değeri doğrulayarak okur. 'q' yazılırsa false döner.
            static bool ReadValue(string label, string oldValue, Func<string, bool> isValid, string errorMessage, out string newValue)
            {
                Console.WriteLine($"Eski {label}: {oldValue}");
                while (true)
                {
                    Console.Write($"Yeni {label}: ");
                    string input = Console.ReadLine()?.Trim() ?? "";

                    if (input.ToLower() == "q")
                    {
                        newValue = "";
                        return false;
                    }
                    if (isValid(input))
                    {
                        newValue = input;
                        return true;
                    }
                    Console.WriteLine(errorMessage);
                }
            }

            static bool IsValidStudentNo(string s) => int.TryParse(s, out int n) && n >= 1 && n <= 10000;
            static bool IsValidEcts(string s) => int.TryParse(s, out int n) && n >= 1 && n <= 10;
            static bool IsValidScore(string s) => int.TryParse(s, out int n) && n >= 0 && n <= 100;
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
                return;
            }
            if (courses.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\nÖncelikle en az 1 ders kaydediniz.\n");
                Thread.Sleep(3000);
                return;
            }

            Console.Clear();
            Console.WriteLine("Çıkmak için 'q' yazabilirsiniz (girilen notlar kaydedilmez).\n");
            var pending = new List<List<CourseGrade>>();
            foreach (var student in students)
            {
                var list = new List<CourseGrade>();
                foreach (var course in courses)
                {
                    while (true)
                    {
                        Console.Write($"{student.Name} {student.Surname} ({student.StudentNo}no) - {course.CourseName} notu: ");
                        string temporaryInput = Console.ReadLine()?.Trim() ?? "";

                        if (temporaryInput.ToLower() == "q")
                        {
                            Console.WriteLine(">>> Kayıt modundan çıkıldı. Girilen notlar kaydedilmedi.\n");
                            Thread.Sleep(1500);
                            return;
                        }

                        if (!int.TryParse(temporaryInput, out int parsedGrade) || parsedGrade < 0 || parsedGrade > 100)
                        {
                            Console.WriteLine("Geçersiz öğrenci notu!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            continue;
                        }

                        list.Add(new CourseGrade
                        {
                            Course = course,
                            Score = parsedGrade.ToString()
                        });
                        Console.Clear();
                        break;
                    }
                }
                pending.Add(list);
            }

            for (int i = 0; i < students.Count; i++)
            {
                students[i].Grades = pending[i];
            }

            LoadingAnim(2, LoadingType.dots);
            Console.Write("Tüm notlar başarıyla eklendi! ");
            Thread.Sleep(2000);
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
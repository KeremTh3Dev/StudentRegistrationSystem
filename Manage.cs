namespace StudentRegistrationSystem
{
    public static class Manage
    {
        public static void Run()
        {
            Algorithm.RegisterStudent();

            /*
            Console.Clear();
            Algorithm.Welcome();
            MainMenu();
            */
        }


        public static void MainMenu()
        {
            Console.Clear();
            Algorithm.GiveInformation();
            bool unrecognizedCommand;
            do
            {
                unrecognizedCommand = false;
                Console.Write("Komut Giriniz >> ");
                string? komut = Console.ReadLine();
                //-------------------------------------------------

                switch (komut)
                {
                    case "ogrenciekle":
                        Algorithm.RegisterStudent();
                        break;
                    case "notekle":
                        Algorithm.EnterGrades();
                        break;
                    case "dersekle":
                        Algorithm.RegisterCourse();
                        break;
                    case "kaydetvecik":
                        Algorithm.EditRegistered(); //Burası savelist olmalı
                        return;
                    default:
                        Algorithm.ThrowException();
                        unrecognizedCommand = true;
                        break;
                }
            }
            while (unrecognizedCommand);
        }


    }
}



/*

verbatim string dosyaları içeren bir class oluştur, algorithm.cs ve manage.cs'i ona bağla. Ardınadn AI'a at ki güzel bir UI tasarım yapsın
öğrenci ders kayıtlarında öğrenci hallolunca done desin sonra diger ogrenciye gecsin
ders ve ogrenci adları bosluklu olabilsin


//öğrencinin kaydedilmiş bilgilerine bu şekilde erişilir.
            
            System.Console.WriteLine("\n Öğrenci adını değiştir: ");
            string newName = Console.ReadLine() ?? "";
            students[0].Name = newName;
            Console.WriteLine("Öğrenci adı: {0}",students[0].Name);
            Console.WriteLine("Öğrenci soyadı: {0}",students[0].Surname);
            Console.WriteLine("Öğrenci numarası: {0}",students[0].StudentNo);
            Console.WriteLine("Ders adı: {0}",students[0].Grades[0].Course.CourseName);
            Console.WriteLine("Ders AKTS: {0}",students[0].Grades[0].Course.Ects);
            Console.WriteLine("Ders Notu: {0}",students[0].Grades[0].Score);

            
*/
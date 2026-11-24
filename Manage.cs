namespace StudentRegistrationSystem
{
    public static class Manage
    {
        public static void Run()
        {
            Console.Clear();
            Algorithm.Welcome();

            bool exit = false;
            while (!exit)
            {
                exit = MainMenu();
            }

            Console.WriteLine("\n Çıkış yapıldı. Hoşça kalın!");
        }

        public static bool MainMenu()
        {
            Console.Clear();
            Algorithm.GiveInformation();

            while (true)
            {
                Console.Write("Komut Giriniz >> ");
                string komut = Console.ReadLine()?.Trim().ToLower() ?? "";

                switch (komut)
                {
                    case "ogrenciekle":
                        Algorithm.RegisterStudent();
                        return false;
                    case "notekle":
                        Algorithm.EnterGrades();
                        return false;
                    case "dersekle":
                        Algorithm.RegisterCourse();
                        return false;
                    case "kaydetvecik":
                        return Algorithm.SaveList();
                    default:
                        Algorithm.ThrowException();
                        Algorithm.GiveInformation();
                        break;
                }
            }
        }
    }
}
namespace StudentRegistrationSystem
{
    public static class Manage
    {
        public static void Run()
        {
            Console.Clear();
            Algorithm.Welcome();
            MainMenu();
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
                        Algorithm.SaveList();
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
*/
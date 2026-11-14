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

notlarım:


ders ekle diye bir kısım da olmalı
ogrenci notu girerken de bir loop;
ders adı: not:

*/
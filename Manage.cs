namespace StudentRegistrationSystem
{
    public static class Manage
    {
        public static void Run()
        {

            Algorithm.GiveInformation();

            MainMenu();

        }


        public static void MainMenu()
        {
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
                    case "cikis":
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
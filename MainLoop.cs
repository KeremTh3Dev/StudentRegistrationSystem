
namespace StudentRegistrationSystem
{
    public static class MainLoop
    {
        public static void Run()
        {
            CreateLists();
            GiveInformation();
            RunCommandLoop();
        }

        public static void CreateLists()
        {
            //create lists
        }
        public static void GiveInformation()
        {
            //give info
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
                        Console.WriteLine("\n >>> Tanınmayan komut!\n");
                        unrecognizedCommand = true;
                        break;
                }
            }
            while (unrecognizedCommand);

        }


        public static void RegisterStudent()
        {
            //register student
        }
        public static void EnterGrades()
        {
            //enter grades
        }
        public static void SaveList()
        {
            //save lists
        }
    }
}

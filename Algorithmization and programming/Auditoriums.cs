using System;
using System.Collections;

class Aud
{
    public int audFloor;
    public int audNumber;
    public int audPlaces;
    public bool audProjector;
    public bool audComputer;
    
    public Aud(int floor, int number, int places, bool projector, bool computer)
    {
        audFloor = floor;
        audNumber = number;
        audPlaces = places;
        audProjector = projector;
        audComputer = computer;
    }

    public void PrintAll()
    {
        Console.WriteLine($"Floor: {audFloor}");
        Console.WriteLine($"Number: {audNumber}");
        Console.WriteLine($"Places: {audPlaces}");
        Console.WriteLine($"Projector: {audProjector}");
        Console.WriteLine($"Computer: {audComputer}");
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        ArrayList  Auds = new ArrayList();

        bool IsInt(string try_int)
        {
            bool check_n = true;
            foreach (char value in try_int)
            {
                if (char.IsDigit(value) == false) { check_n = false; }
            }
            return check_n;
        }

        int TryStringToInt(string phrase)
        {
            bool check = false;
            string vvod;
            int result = -1;

            while (check == false)
            {
                Console.Write(phrase);
                vvod = Console.ReadLine();
                if(vvod.Length > 0)
                    {
                    if (IsInt(vvod))
                    {
                        result = Convert.ToInt32(vvod);
                        check = true;
                    }
                }
                
            }
            return result;
        }

        bool Try2optionsTF(string phrase, string optionT, string optionF)
        {
            bool check = false;
            string vvod;
            bool result = false;

            while (check == false)
            {
                Console.Write(phrase + $" ({optionT}/{optionF}): ");
                vvod = Console.ReadLine();
                if (vvod == optionT)
                {
                    result = true;
                    check = true;
                }
                else if (vvod == optionF)
                {
                    check = true;
                }
            }
            return result;
        }

        void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Add many");
            Console.WriteLine("3. Change");
            Console.WriteLine("4. Show all");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Exit");

            string option = Console.ReadLine();
            if (option == "1"){ Add(); Menu(); }
            else if (option == "2")
            {
                bool Out = false;
                while (Out == false)
                {
                    Add();
                    if (Try2optionsTF("Do you want to continue?", "Yes", "No") == false) { Out = true; Menu(); }
                }
            }
            else if (option == "3"){ Change(); }
            else if (option == "4")
            {
                Console.Clear();
                Console.WriteLine($"Totally {Auds.Count} auditorioms");
                Console.WriteLine();
                if (Auds.Count > 0) { foreach (Aud auditoria in Auds) { auditoria.PrintAll(); } }
                else { Console.WriteLine("No auditoriums yet" + "\n"); }
                Console.Write("Press Enter to return to menu");
                Console.ReadLine();
                Menu();
            }
            else if (option == "5"){ SearchMenu(); }
            else if (option == "6")
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else { Menu(); }
        }

        void Add()
        {
            Console.Clear();
            Console.WriteLine("You can add auditorium here");
            int floor = TryStringToInt("Enter floor: ");
            int number = TryStringToInt("Enter number: ");
            int places = TryStringToInt("Enter places: ");
            bool projector = Try2optionsTF("Projector?", "Yes", "No");
            bool computer = Try2optionsTF("Computer?", "Yes", "No");
            Auds.Add(new Aud(floor, number, places, projector, computer));
        }

        void Change()
        {
            Console.Clear();
            int floor = TryStringToInt("Enter auditorium floor: ");
            int number = TryStringToInt("Enter auditorium number: ");
            bool flag = false;
            foreach (Aud auditoria in Auds) 
            { 
                if(auditoria.audFloor == floor && auditoria.audNumber == number)
                {
                    flag = true;
                    if(Try2optionsTF("Do you want to change auditorium places?", "Yes", "No") == true) { auditoria.audPlaces = TryStringToInt("Enter new auditorium places: "); }
                    if (Try2optionsTF("Do you want to change auditorium projector status?", "Yes", "No") == true) { auditoria.audProjector = Try2optionsTF("Enter new projector status: ", "Yes", "No"); }
                    if (Try2optionsTF("Do you want to change auditorium computer status?", "Yes", "No") == true) { auditoria.audComputer = Try2optionsTF("Enter new computer status: ", "Yes", "No"); }
                }
            }
            if(flag == false) { Console.WriteLine("\n" + "No auditoriums yet" + "\n"); }
            Console.Write("Press Enter to return to menu");
            Console.ReadLine();
            Menu();
        }

        void SearchMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Search by places");
            Console.WriteLine("2. Search by projector + places");
            Console.WriteLine("3. Search by computer + places");
            Console.WriteLine("4. Search by floor");
            Console.WriteLine("5. Exit");
            string searchOption = Console.ReadLine();
            if(searchOption == "1") 
            {
                Console.Clear();
                int places = TryStringToInt("Enter neeeded places: ");
                bool flag = false;
                foreach (Aud auditoria in Auds)
                {
                    if (auditoria.audPlaces >= places)
                    {
                        if(flag == false) { Console.WriteLine(); }
                        flag = true;
                        auditoria.PrintAll();                        
                    }
                }
                if (flag == false) { Console.WriteLine("\n" + "No auditoriums yet" + "\n"); }
                Console.Write("Press Enter to return to menu");
                Console.ReadLine();
                Menu();
            }
            else if (searchOption == "2")
            {
                Console.Clear();
                int places = TryStringToInt("Enter neeeded places: ");
                bool flag = false;
                foreach (Aud auditoria in Auds)
                {
                    if (auditoria.audPlaces >= places && auditoria.audProjector == true)
                    {
                        if (flag == false) { Console.WriteLine(); }
                        flag = true;
                        auditoria.PrintAll();
                    }
                }
                if (flag == false) { Console.WriteLine("\n" + "No auditoriums yet" + "\n"); }
                Console.Write("Press Enter to return to menu");
                Console.ReadLine();
                Menu();
            }
            else if (searchOption == "3")
            {
                Console.Clear();
                int places = TryStringToInt("Enter neeeded places: ");
                bool flag = false;
                foreach (Aud auditoria in Auds)
                {
                    if (auditoria.audPlaces >= places && auditoria.audComputer == true)
                    {
                        if (flag == false) { Console.WriteLine(); }
                        flag = true;
                        auditoria.PrintAll();
                    }
                }
                if (flag == false) { Console.WriteLine("\n" + "No auditoriums yet" + "\n"); }
                Console.Write("Press Enter to return to menu");
                Console.ReadLine();
                Menu();
            }
            else if(searchOption == "4")
            {
                Console.Clear();
                int floor = TryStringToInt("Enter neeeded floor: ");
                bool flag = false;
                foreach (Aud auditoria in Auds)
                {
                    if (auditoria.audFloor == floor)
                    {
                        if (flag == false) { Console.WriteLine(); }
                        flag = true;
                        auditoria.PrintAll();
                    }
                }
                if (flag == false) { Console.WriteLine("\n" + "No auditoriums yet" + "\n"); }
                Console.Write("Press Enter to return to menu");
                Console.ReadLine();
                Menu();
            }
            else if (searchOption == "5") { Menu(); }
            else { SearchMenu(); }
        }

        Menu();
    }
}

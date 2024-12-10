class Program
{
    static string YesOrNo(string question)
    {
        Console.WriteLine(question);
        Console.Write("(y/n)>| ");
        return Console.ReadLine();
    }
    static void Main(string[] args)
    {
        Unit userUnit = null; //this is created here so I can catch a user not creating a character
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello and Welcome!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Create a character");
            Console.WriteLine("2) View your Character");
            Console.WriteLine("3) Save your character");
            Console.WriteLine("4) Load a character");
            Console.WriteLine("5) Use a character");
            Console.WriteLine("6) Upgrade a character");
            Console.WriteLine("7) Quit");
            Console.Write("\n(1/2/3/4/5/6/7)>| ");
            string response = Console.ReadLine();

            if (response == "1")
            //creates a new character
            {
                userUnit = Unit.CreateUnit();
                string input = YesOrNo("Would you like to create a custom Weapon?");
                if (input == "y")
                {
                    userUnit.AddEquipment(Weapon.CreateWeapon());
                }
                else
                {
                    userUnit.AddEquipment(new Weapon());
                }
                input = YesOrNo("Would you like to create a custom Shield?");
                if (input == "y")
                {
                    userUnit.AddEquipment(Shield.CreateShield());
                }
                input = YesOrNo("Would you like to create custom Armor Plating?");
                if (input == "y")
                {
                    userUnit.AddEquipment(ArmorPlating.CreatePlating());
                }
                userUnit.SetHitPoints();
                userUnit.SetMovePoints();
                userUnit.SetWeapon();
            }
            if (response == "2")
            //displays current character
            {
                if (userUnit == null)
                {
                    Console.WriteLine("You have no current character!");
                    string answer = YesOrNo("Would you like to use the default character?");
                    if (answer == "y")
                    {
                        userUnit = new Unit();
                        userUnit.DisplayInfo();
                    }
                }
                else
                {
                    userUnit.DisplayInfo();
                }
                Console.WriteLine("\nPress enter to continue");
                Console.ReadLine();
            }
            if (response == "3")
            //saves a character
            {
                Console.Write("Where would you like to save to? ");
                string input = Console.ReadLine();
                userUnit.SaveUnit(input);
                Console.WriteLine("Character saved, press enter to continue");
                Console.ReadLine();
            }
            if (response == "4")
            //loads a character
            {
                Console.WriteLine("What character would you like to load? ");
                string input = Console.ReadLine();
                userUnit = Unit.LoadUnit(input);
                Console.WriteLine("Character Loaded, press enter to continue");
                Console.ReadLine();
            }
            if (response == "5")
            //uses current character
            {
                if (userUnit == null)
                {
                    Console.WriteLine("You have no current character!");
                    try
                    {
                        string answer = YesOrNo("Would you like to use the default unit?");
                        if (answer == "y")
                        {
                            userUnit = new Unit();
                        }
                        else if (answer == "n")
                        {
                            return;
                        }
                        else
                        {
                            throw new Exception("unrecognized input");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Unit enemy1 = new Unit();
                //This is mostly just to make sure things are set up correctly
                while (true)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1) Make an attack");
                    Console.WriteLine("2) Defend against an attack");
                    Console.WriteLine("3) Dodge an attack");
                    Console.WriteLine("4) Quit");
                    Console.Write("\n(1/2/3/4)>| ");
                    string choice = Console.ReadLine();
                    Console.Clear();

                    if (choice == "1")
                    {
                        bool enemySuccess = enemy1.MakeDefense(0, 0);
                        int damage = userUnit.MakeAttack(15, enemySuccess, 0);
                        enemy1.TakeDamage(damage);
                    }
                    else if (choice == "2")
                    {
                        bool playerSuccess = userUnit.MakeDefense(0, 0);
                        int damage = enemy1.MakeAttack(30, playerSuccess, 0);
                    }
                    else if (choice == "3")
                    {
                        bool playerSuccess = userUnit.MakeDodge(0, 0);
                        int damage = enemy1.MakeAttack(30, playerSuccess, 0);
                    }
                    else if (choice == "4")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Unrecognized Input");
                    }
                }
            }
            if (response == "6")
            //upgrade a unit
            {
                //add or remove equipment
                //upgrade stats?
            }
            if (response == "7")
            {
                string input = YesOrNo("Are you sure?");
                if (input == "y")
                {
                    break;
                }
                else if (input == "n")
                {   
                }
                else
                {
                    Console.WriteLine("Unknown input");
                }
            }
            else
            {
                Console.WriteLine("Input not understood");
            }
        }
    }
}
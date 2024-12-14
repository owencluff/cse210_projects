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
        Unit userUnit = new Unit(); //this is created here so I can catch a user not creating a character
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Currently using character: {userUnit.GetName()}");
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
                Equipment toAdd;
                userUnit = Unit.CreateUnit();
                string input = YesOrNo("Create custom equipment? ");
                List<Equipment> adding = [];
                while (input == "y")
                {
                    toAdd = Equipment.CreateEquipment();
                    adding.Add(toAdd);
                    input = YesOrNo("Create another?");
                }
                foreach (Equipment e in adding)
                {
                    userUnit.AddEquipment(e);
                }
                if (userUnit.GetWeapon() == null)
                {
                    userUnit.AddEquipment(new Weapon());
                }
                /*string input = YesOrNo("Would you like to create a custom Weapon?");
                if (input == "y")
                {
                    
                    toAdd.CreateItem<Weapon>();
                    userUnit.AddEquipment(toAdd);
                }
                else
                {
                    userUnit.AddEquipment(new Weapon());
                }
                input = YesOrNo("Would you like to create a custom Shield?");
                if (input == "y")
                {
                    toAdd.CreateItem<Shield>();
                    userUnit.AddEquipment(toAdd);
                }
                input = YesOrNo("Would you like to create custom Armor Plating?");
                if (input == "y")
                {
                    toAdd.CreateItem<ArmorPlating>();
                    userUnit.AddEquipment(toAdd);
                }
                userUnit.SetHitPoints();
                userUnit.SetMovePoints();
                userUnit.SetWeapon();*/
            }
            if (response == "2")
            //displays current character
            {
                userUnit.DisplayInfo();
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
                Console.WriteLine("Would you like to upgrade your Pilot, Mech, or Equipment?");
                Console.Write("(Pilot/Mech/Equipment)>| ");
                string answer = Console.ReadLine();
                if (answer == "Pilot")
                {
                    userUnit.UpgradePilot();
                }
                else if (answer == "Mech")
                {
                    userUnit.UpgradeMech();
                }
                else if (answer == "Equipment")
                {
                    //this will be fun!
                    userUnit.UpgradeEquipment();
                }
                else
                {
                    Console.WriteLine("Unknown input");
                }
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
                Console.WriteLine("Unknown input");
            }
        }
    }
}
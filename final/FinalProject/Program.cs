class Program
{
    static void Main(string[] args)
    {
        //The default, balanced mech.
        List<Ability> mechAbilities = new List<Ability>([
            new Ability("Armor", 30),
            new Ability("Core", 30),
            new Ability("Frame", 30),
            new Ability("Mobility", 30),
            new Ability("Power", 30)
        ]);
        //This will be the default pilot, but is not necessarily the best pilot.
        List<Ability> pilotAbilities = new List<Ability>([
            new Ability("Grit", 20),
            new Ability("Intuition", 15),
            new Ability("Knowledge", 15)
        ]);
        Mech mech1 = new Mech("mech1", mechAbilities);
        Pilot pilot1 = new Pilot("pilot1", pilotAbilities);
        Unit unit1 = new Unit(pilot1, mech1, new Systems([]));
        
        Weapon rifle = new Weapon("rifle", 15, 0, 0, 1, 30, 1);
        Shield basicShield = new Shield("basic shield", 0, 0, 10, 1, 3, 1);
        ArmorPlating basicPlating = new ArmorPlating("basic plating", 0, 15, 0, 0, 1, 15);
        unit1.AddEquipment(rifle);
        unit1.AddEquipment(basicShield);
        unit1.AddEquipment(basicPlating);
        
    }
}
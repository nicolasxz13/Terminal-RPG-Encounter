public class Ninja : Human
{
    public Ninja(string name, int str, int intel, int hp, int dex = 75)
        : base(name, str, intel, dex, hp) { }

    public override void Attack(IBaseStats target)
    {
        int dmg = Dexterity;
        target.Health -= dmg;
        Console.WriteLine($"{Name} Ataco a {target.Name} por {dmg} daño!");

        Random rand = new Random();
        int probabilidad = rand.Next(0, 100);
        if (probabilidad < 20)
        {
            int dmgextra = 10;
            Console.WriteLine(
                $"{Name} a obtenido un golpe critico sobre el objetivo {target.Name} por la cantidad de {dmgextra}"
            );
            target.Health -= dmgextra;
        }
    }

    public override void Special(IBaseStats target)
    {
        target.Health -= 5;
        Health += 5;
    }

}

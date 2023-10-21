public class Wizard : Human
{
    public Wizard(string name, int str, int dex, int hp = 100, int intel = 25)
        : base(name, str, intel, dex, hp) { }

    public override void Attack(IBaseStats target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        //Cura al Wizard
        Health += dmg;
        Console.WriteLine($"{Name} Ataco a {target.Name} por {dmg} daño!");
    }

    public override void Special(IBaseStats? baseStats = null)
    {
        int heal = Intelligence * 3;
        Health += heal;
        Console.WriteLine($"{Name} se a curado por la cantidad de {heal} Vida");
    }
}

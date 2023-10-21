public class Samurai : Human
{
    public Samurai(string name, int str, int intel, int dex, int hp = 200)
        : base(name, str, intel, dex, hp) { }

    public override void Attack(IBaseStats target)
    {
        base.Attack(target);
        if (target.Health < 50)
        {
            target.Health = 0;
        }
        Console.WriteLine("Ataque letal.");
    }

    public override void Special(IBaseStats? baseStats = null)
    {
        Console.WriteLine("Comienza a meditar");
        Health = 200;
    }
}

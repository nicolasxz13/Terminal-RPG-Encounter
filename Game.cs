public class Game
{
    private List<IBaseStats> Enemies { get; set; }
    private List<IBaseStats> Heros { get; set; }

    public Game()
    {
        Enemies = new List<IBaseStats>()
        {
            new Zombie("Zombie 1", 100, 0, 10, 100),
            new Zombie("Zombie 2", 100, 0, 10, 100),
            new Spider("Spider", 150, 0, 10, 100),
        };
        Heros = new List<IBaseStats>()
        {
            new Ninja("Ninja 1", 100, 20, 10),
            new Wizard("Wizard", 100, 30),
            new Samurai("Samurai 1,", 200, 5, 30)
        };
    }

    public void Run()
    {
        bool winner = false;
        while (!winner)
        {
            IBaseStats player = Seleccionar(Heros.Count(), Heros);
            IBaseStats target = Seleccionar(Enemies.Count(), Enemies);
            Attacked(target, player);

            EnemyAutoAttack();

            //Elimina a los objetivos con vida inferior a 0.
            Heros = PrintLife(Heros);
            Enemies = PrintLife(Enemies);

            if (Heros.Count <= 0)
            {
                winner = true;
                Console.WriteLine("Los Enemigos han ganado");
            }
            else if (Enemies.Count <= 0)
            {
                winner = true;
                Console.WriteLine("Los heroes han ganado");
            }
        }
    }

    private List<IBaseStats> PrintLife(List<IBaseStats> objectives)
    {
        List<IBaseStats> temp = new List<IBaseStats>();
        foreach (IBaseStats result in objectives)
        {
            if (result.Health < 0)
            {
                Console.WriteLine(result.Name + " A sido eliminado");
            }
            else
            {
                Console.WriteLine(result.Name + " Tiene " + result.Health + " Vida");
                temp.Add(result);
            }
        }
        return temp;
    }

    private void Attacked(IBaseStats target, IBaseStats player)
    {
        Console.WriteLine("Seleccione la accion a realizar.");
        Console.WriteLine("0 - Atacar");
        Console.WriteLine("1 - Robar");
        if (int.TryParse(Console.ReadLine(), out int Input) && Input == 0)
        {
            ((Human)player).Attack(target);
        }
        else if (Input == 1)
        {
            ((Human)player).Special(target);
        }
        else
        {
            Console.WriteLine("Seleccione una opcion valida");
            Attacked(target, player);
        }
    }

    private IBaseStats Seleccionar(int count, List<IBaseStats> targets)
    {
        int Seleccioncount = 0;
        Console.WriteLine("Seleccione una opcion.");
        foreach (IBaseStats result in targets)
        {
            Console.WriteLine(Seleccioncount + " Nombre: " + result.Name);
            Seleccioncount++;
        }
        if (int.TryParse(Console.ReadLine(), out int Input) && Input >= 0 && Input < count)
        {
            return targets[Input];
        }
        else
        {
            Console.WriteLine("Seleccione una opcion valida");
            return Seleccionar(count, targets);
        }
    }

    private void EnemyAutoAttack()
    {
        Random rand = new Random();
        foreach (IBaseStats baseStats in Enemies)
        {
            int targetselect = rand.Next(0, Heros.Count());
            baseStats.Attack(Heros[targetselect]);
        }
    }
}

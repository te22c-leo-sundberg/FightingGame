using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

Random generator = new Random();



int player1hp = 0;
int player2hp = 0;
int cash = 0;

while (true)
{

    string[] player2names = { "Felix", "Bridget", "Astolfo", "Casper" };

    var random = new Random();

    string player2name = player2names[random.Next(0, player2names.Length)];

    player1hp = 100;
    player2hp = 100;

    Console.WriteLine("Welcome to the pit, where fighters compete for glory, greatness and cash!");
    Console.WriteLine($"Your current balance is {cash}");
    string player1name = " ";
    while (player1name.Length < 3 || player1name.Length > 12 )
    {
        Console.WriteLine("What is your name, brave fighter?");
        player1name = Console.ReadLine();
    }
    Console.WriteLine($"{player1name} huh? Let's hope you don't die on us");

    while (player1hp > 0 && player2hp > 0)
    {

        Console.WriteLine("\n -------- ||||| NEW ROUND ||||| --------");
        Console.WriteLine($"{player1name}: {player1hp}  {player2name}: {player2hp}\n");

        string attack = Console.ReadLine().ToUpper();
        while (attack != "LIGHT" && attack != "HEAVY")
        {
            Console.WriteLine("Will you use a heavy or a light attack?");
            attack = Console.ReadLine().ToUpper();
        }
        if (attack == "LIGHT")
        {
            int accuracy = generator.Next(1, 100);
            if (accuracy <= 5)
            {
                Console.WriteLine($"{player1name} prepares a punch, but stumbles, falling to the ground head first knocking a tooth out. Embarrasing");
                Console.WriteLine("Gosh, I'm cringing at the fact that this just happened. Here, take 5 cash and go seek some councelling");
                cash = +5;
            }
            else
            {
                int player1damage = generator.Next(1, 20);
                player2hp -= player1damage;
                player2hp = Math.Max(0, player2hp);
                Console.WriteLine($"{player1name} decided to bust it down sexual style, creating a massive whirlwind, dealing {player1damage} damage to {player2name}");
            }
        }
        else
        {
            int accuracy = generator.Next(10);
            if (accuracy <= 4)
            {
                Console.WriteLine($"{player1name} decided to go full throttle, throwing a gasoline boosted punch, but missed and fell on his ass.");
            }
            else
            {
                int player1damage = generator.Next(15, 30);
                player2hp -= player1damage;
                player2hp = Math.Max(0, player2hp);
                Console.WriteLine($"{player1name} decided to put his all into a punch, creating a extremely large air vacuum around his fist, then punching so hard he tore a black hole into the stomach of {player2name}, dealing {player1damage} damage.");
            }
        }
        int player2heavylight = generator.Next(1, 2);
        if (player2heavylight == 1)
        {
            int p2accuracy = generator.Next(1, 100);
            if (p2accuracy <= 5)
            {
                Console.WriteLine($"{player2name} thought he had that guy in him, but he was mistaken, so while charging his punch, he fell face first on the ground. Embarrasing");
            }
            int player2damage = generator.Next(20);
            player1hp -= player2damage;
            player1hp = Math.Max(0, player1hp);
            Console.WriteLine($"{player2name} decided to use his feminine features to charm {player1name} and kick him in the stomach, dealing {player2damage} damage");
        }
        else
        {
            int p2accuracy = generator.Next(10);
            if (p2accuracy <= 4)
            {
                Console.WriteLine($"{player2name} decided to inject himself with adrenaline for a TRIPLE DOG DEATH BARRAGE, but overdosed and fell asleep.");
            }
            else
            {
                int player2damage = generator.Next(15, 30);
                player1hp -= player2damage;
                player1hp = Math.Max(0, player1hp);
                Console.WriteLine($"{player2name} decided that playtime was over, and proceeded to inject 10 adrenaline syringes and do the TRIPLE DOG DEATH BARRAGE, dealing {player2damage}");
            }

            Console.WriteLine("Click any button to proceed to the next round.");
            Console.ReadKey();

        }
    }

    Console.WriteLine("\n The fight is over!");

    if (player1hp == 0 && player2hp == 0)
    {
        Console.WriteLine("The fight was a tie!");
    }
    else if (player1hp == 0)
    {
        Console.WriteLine($"{player1name} has fallen! He was unable to handle the ways of {player2name}!");
    }
    else
    {
        Console.WriteLine($"{player2name} has lost! He was unable overtake {player1name}! 100 cash has been rewarded to the winner!");
        cash += 100;
    }

    while (true)
    {
        Console.WriteLine("AWESOME!!! Would you like to try again? [Y/N]");
        string answer = Console.ReadLine().ToUpper();
        if (answer == "Y")
            break;
        if (answer == "N")
            return;
    }
}

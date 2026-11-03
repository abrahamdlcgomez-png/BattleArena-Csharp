Console.WriteLine("================================");
Console.WriteLine("          Battle Arena          ");
Console.WriteLine("================================");

Console.WriteLine();

Console.Write("Enter your warrior's name: ");
string playerName = Console.ReadLine() ?? "Warrior";

int playerHealth = 100;
int enemyHealth = 60;

Console.WriteLine();
Console.WriteLine($"Welcome to the Battle Arena, {playerName}!");

Console.WriteLine();
Console.WriteLine("A wild Goblin appeared!");

Console.WriteLine();
Console.WriteLine($"{playerName} health: {playerHealth}");
Console.WriteLine($"Goblin health: {enemyHealth}");

Random random = new Random();
while (playerHealth > 0 && enemyHealth > 0)
{
    int defenseAmount = 0;
    Console.WriteLine();
    Console.WriteLine("===== YOUR TURN =====");
    Console.WriteLine("1. Attack");
    Console.WriteLine("2. Heal");
    Console.WriteLine("3. Defend");
    Console.Write("Choose your action: ");

    string playerChoice = Console.ReadLine() ?? "";

    if (playerChoice == "1")
    { 
        int attackDamage = random.Next(5, 26); // Random damage between 5 and 25
        enemyHealth = enemyHealth - attackDamage;
        if (enemyHealth < 0)
        {
            enemyHealth = 0; // Prevent negative health
        }
        Console.WriteLine($"{playerName} attacks the Goblin!");
        Console.WriteLine($"You dealt {attackDamage} damage!");
        Console.WriteLine($"Goblin remaining health: {enemyHealth}");
    }
   else if (playerChoice == "2")
    {
        int healthBeforeHealing = playerHealth;
        int healAmount = random.Next(10, 21); // Random heal between 10 and 20

        playerHealth = playerHealth + healAmount;

        if (playerHealth > 100)
        {
            playerHealth = 100; // Cap health at 100
        }

        int actualHealing = playerHealth - healthBeforeHealing; // Calculate actual healing done
        Console.WriteLine($"{playerName} heals!");
        Console.WriteLine($"You healed {actualHealing} health!");
        Console.WriteLine($" current health: {playerHealth}");
    }
    else if (playerChoice == "3")
    {
        defenseAmount = random.Next(5, 16); // Random defense between 5 and 15

        Console.WriteLine($"{playerName} raises their shield!");
        Console.WriteLine($"You can block up to {defenseAmount} damage!");
    }
    else
    {
        Console.WriteLine("Invalid choice! Please choose a valid action.");
        continue; // Skip the enemy's turn if the player input is invalid
    }

    if (enemyHealth > 0)
    {
        int enemyAttackDamage = random.Next(5, 16); // Random damage between   5 and 15
        int actualDamage = enemyAttackDamage - defenseAmount;   
        if (actualDamage < 0)
         {
             actualDamage = 0; // Prevent negative damage
     }
     playerHealth = playerHealth - actualDamage;
    if (playerHealth < 0)
    {
        playerHealth = 0; // Prevent negative health
    }
    Console.WriteLine($"The Goblin attacks {playerName}!");
    Console.WriteLine($"Goblin dealt {actualDamage} damage!");
    Console.WriteLine($"{playerName} remaining health: {playerHealth}");
    }
}

Console.WriteLine();

if (playerHealth > 0)
{
    Console.WriteLine($"Congratulations, {playerName}! You have defeated the Goblin!");
}
else
{
    Console.WriteLine($"Game Over! The Goblin defeated you");
}
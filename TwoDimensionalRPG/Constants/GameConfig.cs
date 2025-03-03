namespace TwoDimensionalRPG.Constants;

public class GameConfig
{
    public partial class Map
    {
        public const int MaxHeight = 10;
        public const int MaxWidth = 10;
    }
    public partial class Character
    {
        public const int MaxHp = 300;
        public const int Damage = 1;
        public const int EruptingDamage = 50;
    }
    public partial class Monster
    {
        public const string Icon = "M";
        public const int MaxHp = 1;
        public const int Damage = 50;
        public const int EruptingDamage = 50;
    }
    public partial class State
    {
        public partial class DurationRound
        {
            public const int Invincible = 2;
            public const int Poisoned = 3;
            public const int Accelerated = 3;
            public const int Healing = 5;
            public const int Orderless = 3;
            public const int Stockpile = 2;
            public const int Erupting = 3;
            public const int Teleport = 1;
        }
        public partial class Effect
        {
            public const int PoisonedDamage = 10;
        }
    }
    public partial class Treasure
    {
        public const string Icon = "x";
        public partial class Probability
        {
            public const int SuperStar = 10;
            public const int Poison = 25;
            public const int AcceleratingPotion = 20;
            public const int HealingPotion = 15;
            public const int DevilFruit = 10;
            public const int KingsRock = 10;
            public const int DokodemoDoor = 10;
        }
    }
    public partial class Obstacle
    {
        public const string Icon = "□";
    }
}
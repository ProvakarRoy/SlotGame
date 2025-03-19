/// NameSpace of Game
namespace SlotGame
{
    public class Constants
    {
        public const string FREE_BONUS_LAST_PLAYED = "FREE_BONUS_LAST_PLAYED";
        public const string SpinCount = "SpinCount";
        public const string ExtraSpin = "ExtraSpin";
        public const string Vibration = "Vibration";
    }

    public enum SlotItemType
    {
        none = 0,
        Chicken_breast = 138,
        Pork = 122,
        Salmon = 99,
        Oysters = 41,
        Cabbage = 12,
        Cucumbers = 45,
        Spinach = 7,
        Apple = 52,
        Noodles = 5,
        Candies = 490,
        Soft_Drinks = 246,
        Pizza = 266,
        Burger = 295,
        French_Fries = 312,
        Hamburger_with_Mayonnaise = 942,
        IceCream = 400,
        Popcorn_With_Butter = 250,
        HotDog = 275
    }

    public enum FoodType
    {
        none = 0,
        Healthy = 1,
        Unhealthy = 2
    }

    // H = Healthy, 
    // UH = UnHealthy, 
    // X = None, 
    public enum CombinationType
    {
        All_H = 0,
        All_UH = 1,
        All_X = 2,
        H2_UH1 = 3,
        H1_UH2 = 4,
        H2_X = 5,
        UH2_X = 6,
        H_X2 = 7,
        UH_X2 = 8,
        RANDOM = 9
    }
}
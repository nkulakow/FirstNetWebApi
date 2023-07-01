namespace FirstNet.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Traveler";
        public uint HitPoints { get; set; } = 100;
        public uint Strenght { get; set; } = 10;
        public uint Defense { get; set; } = 10;
        public uint Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public static string setCharacterName(string newName, int Id)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return "Traveler " + Id;
            else
            {
                newName = newName.Trim();
                newName = newName.Replace(" ", "");
                return newName;
            }
        }

    }
}
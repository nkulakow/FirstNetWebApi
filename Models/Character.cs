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
                newName = System.Text.RegularExpressions.Regex.Replace(newName, @"\s+", " ");
                newName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newName.ToLower());
                return newName;
            }
        }

    }
}
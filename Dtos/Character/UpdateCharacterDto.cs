namespace FirstNet.Dtos.Character
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Traveler";
        public uint HitPoints { get; set; } = 100;
        public uint Strenght { get; set; } = 10;
        public uint Defense { get; set; } = 10;
        public uint Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}
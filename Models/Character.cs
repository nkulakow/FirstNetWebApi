using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNet.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Traveler";
        public int HitPoints { get; set; } = 100;
        public int Strenght { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}
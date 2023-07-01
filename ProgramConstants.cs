using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNet
{
    public class ProgramConstants
    {
        public const string NoNegativeCharacterValues = "Character stats cannot be negative";
        public static List<string> getConstants()
        {
            List<string> constants = new List<string>();
            constants.Add(NoNegativeCharacterValues);
            return constants;
        }
    }
}
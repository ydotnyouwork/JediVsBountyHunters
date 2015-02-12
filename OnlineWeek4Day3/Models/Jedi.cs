using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineWeek4Day3.Models
{
    public class Jedi : Character
    {
        [Display(Name = "Lightsaber Color")]
        public string LightsaberColor { get; set; }

        public Jedi(string name, string race, string color, int id)
            : base(name, race, CharacterType.Jedi, id)
        {
            LightsaberColor = color;
        }
    }
}
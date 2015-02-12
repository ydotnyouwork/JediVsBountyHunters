using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineWeek4Day3.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Race { get; set; }
        [Display(Name = "Jedi or Bounty Hunter")]
        public CharacterType CharacterType { get; set; }
        public int Id { get; set; }

        public Character(string name, string race, CharacterType type, int id)
        {
            Name = name;
            Race = race;
            CharacterType = type;
            Id = id;
        }

        public Character()
        {
        }
    }

    public enum CharacterType
    {
        Jedi, //0
        BountyHunter //1
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineWeek4Day3.Models
{
    public class BountyHunter : Character
    {
        [Display(Name = "Weapon Type")]
        public string WeaponType { get; set; }

        public BountyHunter(string name, string race, string weapon, int id)
            : base(name, race, CharacterType.BountyHunter, id)
        {
            WeaponType = weapon;
        }
    }
}
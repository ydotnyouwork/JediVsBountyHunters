using OnlineWeek4Day3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineWeek4Day3.Controllers
{
    public class HomeController : Controller
    {
        private List<Character> characters = new List<Character>()
        {
            new Jedi("Mace Wendu", "Human", "Purple", 1),
            new BountyHunter("Boba Fett", "Clone", "Blaster", 2),
            new Jedi("Yoda", "Little Green People", "Green", 3),
            new Jedi("General Grevious", "Cyborg", "Multiple", 4),
            new BountyHunter("Jango Fett", "Human", "Blaster", 5),
            new BountyHunter("Greedo", "Alien", "Gun (bad gun)", 6),
            new BountyHunter("IG-88", "Robot guy", "Gun(s)", 7),
            new Jedi("Darth Vader", "Part Human, Part Machine", "Red", 8)
        };

        public ActionResult Index()
        {
            return View(characters);
        }

        /// <summary>
        /// This action is written with the long, manual way to do everything
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowJedis()
        {
            List<Jedi> model = new List<Jedi>();
            foreach (Character character in characters)
            {
                if (character.CharacterType == CharacterType.Jedi)
                {
                    model.Add((Jedi)character);
                }
            }

            return View(model);
        }

        /// <summary>
        /// This action shows LINQ
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowBountyHunters()
        {
            List<BountyHunter> model = characters.Where(character => character.CharacterType == CharacterType.BountyHunter)
                .Cast<BountyHunter>()
                .ToList();

            return View(model);
        }

        public ActionResult Details(int id = -1)
        {
            if (id == -1)
            {
                return RedirectToAction("Index");
            }
            //Checks to see if any character exists with the given id
            if (characters.Any(x => x.Id == id))
            {
                Character model = characters.Where(x => x.Id == id).FirstOrDefault();
                if (model.CharacterType == CharacterType.Jedi)
                {
                    Jedi jedi = (Jedi)model;
                    return View("DisplayJedi", jedi);
                }
                else if (model.CharacterType == CharacterType.BountyHunter)
                {
                    BountyHunter bounty = (BountyHunter)model;
                    return View("DisplayBountyHunter", bounty);
                }
                else
                {
                    //Not Implemented
                    //return a basic view for a generic character
                    //return View(model)
                }
            }
            //If the character does not exist in the list, then go back to home page
            return RedirectToAction("Index");
        }

        public ActionResult AddCharacter()
        {
            return View(new Character());
        }

        [HttpPost]
        public ActionResult AddCharacter(Character model)
        {
            if (model.CharacterType == CharacterType.BountyHunter)
            {
                characters.Add(new Jedi(model.Name, model.Race, null, model.Id));
            }
            else if (model.CharacterType == CharacterType.Jedi)
            {
                characters.Add(new BountyHunter(model.Name, model.Race, null, model.Id));
            }
            return RedirectToAction("Index");
        }
    }
}
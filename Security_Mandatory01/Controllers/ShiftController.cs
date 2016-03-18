using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Security_Mandatory01.ViewModels;

namespace Security_Mandatory01.Controllers
{
    public class ShiftController : Controller
    {
        // GET: Shift
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlainText(ShiftViewModel model)
        {
            //Omdanner input til char-array
            var chars = model.text.ToCharArray();

            //Konverterer char-array til ASCII-bytes array
            var asciiBytes = Encoding.ASCII.GetBytes(chars);

            //Input til shift hentes
            var shiftAmount = model.numberKey;


            //Loop som kører stringens længde
            for (var i = 0; i < model.text.Length; i++)
            {
                //Laver variabel for den originale ASCII værdi
                var oldAscii = asciiBytes[i];

                //Condition som tjekker om det er et lille eller stort bogstav
                //Hvis ikke bliver char ikke ændret
                if (oldAscii >= 65 && oldAscii <= 90 || oldAscii >= 97 && oldAscii <= 122)
                {
                    //Laver variabel for den nye ASCII værdi
                    var newAscii = oldAscii + shiftAmount;

                    //Hvis det er et stort bogstav
                    if (oldAscii >= 65 && oldAscii <= 90)
                    {
                        //Starter alfabetet forfra hvis den nye værdi er uden for alfabetet
                        if (newAscii > 90)
                        {
                            newAscii -= 26;
                        }
                        else if (newAscii < 65)
                        {
                            newAscii += 26;
                        }
                    }

                    //Hvis det er et lille bogstav
                    else if (oldAscii >= 97 && oldAscii <= 122)
                    {
                        //Starter alfabetet forfra hvis den nye værdi er uden for alfabetet
                        if (newAscii > 122)
                        {
                            newAscii -= 26;
                        }
                        else if (newAscii < 97)
                        {
                            newAscii += 26;
                        }
                    }
                    //Konverterer ACSII-bytes til char
                    chars[i] = Convert.ToChar(newAscii);
                }
            }

            //Laver en ny string fra de nye værdier
            model.encodedText = new string(chars);

            return View("Index", model);
        }
    }
}
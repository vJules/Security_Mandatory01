using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Security_Mandatory01.ViewModels;

namespace Security_Mandatory01.Controllers
{
    public class VigController : Controller
    {
        // GET: Vig
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PlainText(VigViewModel model)
        {
            //Omdanner input til char-array
            var chars = model.text.ToCharArray();

            //Konverterer char-array til ASCII-bytes array
            var asciiBytes = Encoding.ASCII.GetBytes(chars);

            //Input til shift hentes
            var charatersKey = model.key.ToCharArray();

            //Liste som skal indeholde keys
            var numbersKey = new List<int>();

            for (var i = 0; i < model.key.Length; i++)
            {
                //Chars til uppercase og deres position i alfabetet findes. Tilføjes til liste
                var key = char.ToUpper(charatersKey[i]) - 64;
                numbersKey.Add(key);
            }

            //Variabel som holder den positionen på den key der er nået til
            var position = 0;

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
                    var newAscii = oldAscii + numbersKey[position];


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

                    //Tjekker hvor langt der er nået i keywordet. Hvis det er hvis den når over, startes der forfra.
                    if (position < numbersKey.Count - 1)
                    {
                        position++;
                    }
                    else
                    {
                        position = 0;
                    }

                    //Konverterer ACSII-bytes til char
                    chars[i] = Convert.ToChar(newAscii);
                }
            }
            //Laver en ny string fra de nye værdier
            model.encodedText = new string(chars);
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Encrypted(VigViewModel model)
        {
            //Omdanner input til char-array
            var chars = model.encodedText.ToCharArray();

            //Konverterer char-array til ASCII-bytes array
            var asciiBytes = Encoding.ASCII.GetBytes(chars);

            //Input til shift hentes
            var charatersKey = model.key.ToCharArray();

            //Liste som skal indeholde keys
            var numbersKey = new List<int>();

            for (var i = 0; i < model.key.Length; i++)
            {
                //Chars til uppercase og deres position i alfabetet findes. Tilføjes til liste
                var key = char.ToUpper(charatersKey[i]) - 64;
                numbersKey.Add(key);
            }

            //Variabel som holder den positionen på den key der er nået til
            var position = 0;

            //Loop som kører stringens længde
            for (var i = 0; i < model.encodedText.Length; i++)
            {
                //Laver variabel for den originale ASCII værdi
                var oldAscii = asciiBytes[i];

                //Condition som tjekker om det er et lille eller stort bogstav
                //Hvis ikke bliver char ikke ændret
                if (oldAscii >= 65 && oldAscii <= 90 || oldAscii >= 97 && oldAscii <= 122)
                {
                    //Laver variabel for den nye ASCII værdi
                    var newAscii = oldAscii - numbersKey[position];


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
                    //Tjekker hvor langt der er nået i keywordet. Hvis det er hvis den når over, startes der forfra.
                    if (position < numbersKey.Count - 1)
                    {
                        position++;
                    }
                    else
                    {
                        position = 0;
                    }

                    //Konverterer ACSII-bytes til char
                    chars[i] = Convert.ToChar(newAscii);
                }
            }
            //Laver en ny string fra de nye værdier
            model.text = new string(chars);
            return View("Index", model);
        }
    }
}
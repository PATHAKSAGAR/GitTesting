using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace WordCount.Controllers
{
    public class CountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtString)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            // Declare array and sorted 
            string[] words = { "Bike", "C++", "C#", "VB", "Java", "Ruby", "Physics", "Chemistry", "Mathematics", "Social Science", "History", "Geography", "Rickshaw", "Bus", "Train","cycle" };  //Declaration of array
            Array.Sort(words);
            for (int i = 0; i < words.Length; i++)
            {
                int count = 0;
                string Sentence = string.Empty;
                // Ignored max legth
                Sentence = (Convert.ToInt32(txtString.Length) >= Constants.MAXLENGTH) ? txtString.Substring(0, Constants.MAXLENGTH).Replace(Constants.SPACE, Constants.REPLACESPACE) : Sentence = txtString.Replace(Constants.SPACE, Constants.REPLACESPACE);
                if (Sentence.ToLower().Contains(words[i].Replace(Constants.SPACE, Constants.REPLACESPACE).ToLower()))
                {
                    count = (Sentence.ToLower().Split(new string[] { words[i].Replace(Constants.SPACE, Constants.REPLACESPACE).ToLower() }, StringSplitOptions.None).Length) - 1;
                    //results += words[i] + Constants.SEPRATOR + Convert.ToString(count) + Constants.LINEBREAK;
                    wordCount.Add(words[i], count);
                }
            }
            ViewBag.result = wordCount;
            return View();
        }
    }
}

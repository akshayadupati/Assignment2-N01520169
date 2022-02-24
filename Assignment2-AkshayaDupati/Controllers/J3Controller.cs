using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_AkshayaDupati.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// https://cemc.math.uwaterloo.ca/contests/computing/2006/stage1/juniorEn.pdf - J3 problem
        /// KeyPressed is used to find the number of times the button needs to pressed 
        /// for a given input
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Number of times the button is pressed</returns>
        /// <example>
        /// a - 1
        /// abba - 12
        /// halt - 0 - because it halts the program
        /// </example>
        [HttpGet]
        [Route("api/J3/KeyPressed/{word}")]

        public int KeyPressed(string word)
        {
            //four arrays are described to know how many times the number needs to be pressed
            string[] firstNumber = { "a", "d", "g", "j", "m", "p", "t", "w" };
            string[] secondNumber = { "b", "e", "h", "k", "n", "q", "u", "x" };
            string[] thirdNumber = { "c", "f", "i", "l", "o", "r", "v", "y" };
            string[] fourthNumber = { "", "", "", "", "", "s", "", "z" };

            int count = 0;
            // If the word is not halt the below for loop will be executed
            if (word != "halt")
            {
                //loops until the word length
                for (int i = 0; i < word.Length; i++)
                {
                    string currValue = word[i].ToString();
                    //checks if the first array contains the character
                    if (firstNumber.Contains(currValue))
                    {
                        //finds the index of the character in the first array
                        int currIndex = Array.IndexOf(firstNumber, currValue);
                        //to check if this character is the last character in the word
                        if (i != word.Length - 1)
                        {
                            string nextValue = word[i + 1].ToString();
                            //if the curr value and next value is same or the next value is present in other array in the same index as this value
                            //then we need to add 2 to the count
                            if (currValue == nextValue || nextValue == secondNumber[currIndex] || nextValue == thirdNumber[currIndex] || nextValue == fourthNumber[currIndex])
                            {
                                count = count + 2;
                            }
                        }
                        count = count + 1;
                    }
                    else if (secondNumber.Contains(currValue))
                    {
                        int currIndex = Array.IndexOf(secondNumber, currValue);
                        if (i != word.Length - 1)
                        {
                            string nextValue = word[i + 1].ToString();

                            if (currValue == nextValue || nextValue == firstNumber[currIndex] || nextValue == thirdNumber[currIndex] || nextValue == fourthNumber[currIndex])
                            {
                                count = count + 2;
                            }
                        }
                        count = count + 2;
                    }
                    else if (thirdNumber.Contains(currValue))
                    {
                        int currIndex = Array.IndexOf(thirdNumber, currValue);
                        if (i != word.Length - 1)
                        {
                            string nextValue = word[i + 1].ToString();
                            if (currValue == nextValue || nextValue == firstNumber[currIndex] || nextValue == secondNumber[currIndex] || nextValue == fourthNumber[currIndex])
                            {
                                count = count + 2;
                            }
                        }
                        count = count + 3;
                    }
                    else
                    {
                        int currIndex = Array.IndexOf(fourthNumber, currValue);
                        if (i != word.Length - 1)
                        {
                            string nextValue = word[i + 1].ToString();

                            if (currValue == nextValue || nextValue == firstNumber[currIndex] || nextValue == secondNumber[currIndex] || nextValue == thirdNumber[currIndex])
                            {
                                count = count + 2;
                            }
                        }
                        count = count + 4;
                    }
                }
            }
            return count;
        }
    }
}

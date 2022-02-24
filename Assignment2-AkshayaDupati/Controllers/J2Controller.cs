using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_AkshayaDupati.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// This problem is taken from the pdf assignment.
        /// This Adapted J2 problem solves the dice game. 
        /// Have used two for loops .
        /// One for the first dice and another for loop for second dice.
        /// For each instance of the first for loop, it goes through all the iteration of second for loop.
        /// It then check if sum is equal to 10. If it is, then the counter values gets incremented.
        /// Finally string is manipulated based on the count value.
        /// </summary>
        /// <param name="d1">Number of sides in first dice</param>
        /// <param name="d2">Number of sides in second dice</param>
        /// <returns>
        /// http://localhost:63418/api/J2/DiceGame/5/5 - > There is 1 way to get the sum 10.
        /// http://localhost:63418/api/J2/DiceGame/6/8 - > There are 5 ways to get the sum 10.
        /// http://localhost:63418/api/J2/DiceGame/12/4 - > There are 4 ways to get the sum 10.
        /// http://localhost:63418/api/J2/DiceGame/3/3 - > There are 0 ways to get the sum 10.
        /// </returns>
        [HttpGet]
        [Route("api/J2/DiceGame/{d1}/{d2}")]
        public string DiceGame(int d1, int d2)
        {
           int count = 0;
           string message;
           for(int i = 1; i <= d1; i++)
            {
                for(int j = 1; j <= d2; j++)
                {
                    int sum = i + j;
                    if(sum == 10)
                    {
                        count++;
                    }
                }
            }
           if(count == 1)
            {
                return message = "There is " + count.ToString() + " way to get the sum 10.";
            }
            else
            {
                return message = "There are " + count.ToString() + " ways to get the sum 10.";
            }
        }
    }
}

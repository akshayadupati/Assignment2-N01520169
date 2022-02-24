using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_AkshayaDupati.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// Adapted J1 Problem given in the Assignment 2 PDF.
        /// This below function calculates the calorie based on the order menu.
        /// I have added each variety as an array.
        /// The option given in the URL acts as an index to retrieve the specific value from the array using (index-1).
        /// If the value is other than the 4 options in each variety , it is concluded as "Invalid order".
        /// </summary>
        /// <param name="opt1">Burger option</param>
        /// <param name="opt2">Drink option</param>
        /// <param name="opt3">Side option</param>
        /// <param name="opt4">Dessert option</param>
        /// <returns>
        /// http://localhost:63418/api/J1/Menu/4/4/4/4 -> Your total calorie count is 0
        /// http://localhost:63418/api/J1/Menu/1/2/3/4 -> Your total calorie count is 691
        /// http://localhost:63418/api/J1/Menu/1/2/3/0 -> Invalid order
        /// </returns>
        [HttpGet]
        [Route("api/J1/Menu/{opt1}/{opt2}/{opt3}/{opt4}")]
        public string Menu(int opt1, int opt2, int opt3, int opt4)
        {
            if(opt1 < 1 || opt1 > 4 || opt2 < 1 || opt2 > 4 || opt3 < 1 || opt3 > 4 || opt4 < 1 || opt4 > 4)
            {
                return "Invalid order";
            }
            int[] burger = { 461, 431, 420, 0 };
            int[] drink = { 130, 160, 118, 0 };
            int[] side = { 100, 57, 70, 0 };
            int[] dessert = { 167, 266, 75, 0 };
            int total = burger[opt1-1] + drink[opt2-1] + side[opt3-1] + dessert[opt4-1];
            string message = "Your total calorie count is " + total.ToString();
            return message;
        }
    }
}

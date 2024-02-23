using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendDevelopment_Assignment2.Controllers
{
    /*
     Year 2022 Problem J-1    
     ProblemDescription: A regular box of cupcakes holds8 cupcakes, while a small box holds 3 cupcakes.There are 28 students
     in a class and a total of atleast 28 cupcakes. Your job is to determine how many cupcakes will be leftover
     if each student gets one cupcake.
    */

    public class cupCakePartyController : ApiController
    {
        /// <summary>
        /// Calculates the number of leftover cupcakes based on the number of regular and small boxes.
        /// </summary>
        /// <param name="regularBox">The number of regular boxes containing 8 cupcakes each.</param>
        /// <param name="smallBox">The number of small boxes containing 3 cupcakes each.</param>
        /// <returns>The number of cupcakes leftover after distributing one cupcake to each of the 28 students.</returns>
        /// <example>http://localhost:58844/api/cupcakeparty/leftovercupcakes/2/5</example>
        /// <return>3</return>
        /// Explanation: (2*8)regular + (5*3)small  = 16 + 15 = 31 => 31(totalcupcakes) - 28(students) = 3(leftover)
        /// <example>http://localhost:58844/api/cupcakeparty/leftovercupcakes/2/4</example>
        /// <return>0</return>
        /// Explanation: (2*8)regular + (4*3)small  = 16 + 12 = 28 => 28(totalcupcakes) - 28(students) = 0(leftover)
        [HttpGet]
        [Route("api/cupcakeparty/leftovercupcakes/{regularBox}/{smallBox}")]
        public string leftOverCupCakes(int regularBox, int smallBox)//in 1 regular box there are 8 cupcakes and in 1 small box there are 3 cupcakes
        {
            int totalCupCakes = regularBox * 8 + smallBox * 3;// getting total cupcakes

            int leftCupcakes = totalCupCakes - 28; // 28 is the students that we have in class

            return leftCupcakes.ToString();
            
        }
    }
}

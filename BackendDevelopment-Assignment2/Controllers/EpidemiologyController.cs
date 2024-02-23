using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendDevelopment_Assignment2.Controllers
{

    /*
     Year 2020
     ProblemJ2:Epidemiology
     ProblemDescription:
     People who study epidemiology use models to analyze the spread of disease. 
     In this problem,we use a simple model. When a person has a disease,they infect exactly R other people but only
     on the very next day. No person is infected more than once. We want to determine when a total of more than P people have
     had the disease. (This problem was designed before the current coronavirus outbreak, and we acknowledge the 
     distress currently being experienced by many people worldwide because of this and other diseases. We hope that including
     this problem at this time highlights the important roles that computer science and mathematics play in solving 
     real-world problems.)
     Input Specification:
     There are three lines of input. Each line contains one positive integer. The first line contains the value of P.
     The second line contains N,the number of people who have the disease on Day 0.The thirdline contains the value of R.
     Assume that P≤10^7 and N≤P and R≤10. 
     Output Specification: Output the number of the first day on which the total number of people
     who have had the disease is greater than P. 
     SampleInput1 
     750 1 5 
     Output for Sample Input1 
     4 
     Explanation of Output for Sample Input1 
     The 1 person on Day0 with the disease infects 5 people on Day1.On Day2,exactly 25 people are infected.On Day3,exactly 125 people
     are infected.
     A total of 1 + 5 + 25 + 125+ 625 = 781 people have had the disease by the end of Day 4 and 781>750. 
     SampleInput2 10 2 1
     OutputforSampleInput2 5
     */

    public class EpidemiologyController : ApiController
    {
        /// <summary>
        /// Calculate the total days that number of people infected day by day.
        /// </summary>
        /// <param name="P">Total people infected</param>
        /// <param name="N">Number of person have disease on day 0</param>
        /// <param name="R">Number of people came contact with infected one.</param>
        /// <example>http://localhost:58844/api/epidemiology/epidem/750/1/5</example>
        /// <returns>4</returns>
        /// <example>http://localhost:58844/api/epidemiology/epidem/10/2/1</example>
        /// <returns>5</returns>
    
        [HttpGet]
        [Route("api/epidemiology/epidem/{P}/{N}/{R}")]
        public int epiDem(int P, int N, int R)
        {   
            int totalinfected = N;///(2,2,4,8)(day 0 doesnt count(2))
            int D = 0;
            while (totalinfected <= P) {
                
                int newInfected = totalinfected * R;
                
                totalinfected += newInfected;
                  
                D++;
                ///1(2),2(4),3(8),4(16),5(exceed the threshold)
            }
            return D;///5
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Web.Http;

namespace BackendDevelopment_Assignment2.Controllers
{
    /*
     Year 2020
    Problem J3
    Problem J3: Secret Instructions
Problem Description
Professor Santos has decided to hide a secret formula for a new type of biofuel. She has,
however, left a sequence of coded instructions for her assistant.
Each instruction is a sequence of five digits which represents a direction to turn and the
number of steps to take.
The first two digits represent the direction to turn:
• If their sum is odd, then the direction to turn is left.
• If their sum is even and not zero, then the direction to turn is right.
• If their sum is zero, then the direction to turn is the same as the previous instruction.
The remaining three digits represent the number of steps to take which will always be at
least 100.
Your job is to decode the instructions so the assistant can use them to find the secret formula.
Input Specification
There will be at least two lines of input. Each line except the last line will contain exactly
five digits representing an instruction. The first line will not begin with 00. The last line
will contain 99999 and no other line will contain 99999.
Output Specification
There must be one line of output for each line of input except the last line of input. These
output lines correspond to the input lines (in order). Each output line gives the decoding of
the corresponding instruction: either right or left, followed by a single space, followed by
the number of steps to be taken in that direction.
Sample Input
57234
00907
34100
99999
Output for Sample Input
right 234
right 907
left 100
La version fran¸caise figure `a la suite de la version anglaise.
Explanation of Output for Sample Input
The first instruction is 57234 which is decoded as right 234 because 5 + 7 = 12 which is
even and 57 is followed by 234.
The second instruction is 00907 which is decoded with the same direction as the previous
instruction (right) but with 907 steps.
The third instruction is 34100 which is decoded as left 100 because 3 + 4 = 7 which is odd
and 34 is followed by 100.
The last line contains 99999 which tells us these are the only three instructions.
    */
    public class SecretInstructionController : ApiController
    {
        /// <summary> 
        /// To decode the instructions so the assistant can use them to find the secret formula.
        /// </summary>
        /// <param name="secretFormula1"></param>
        /// <param name="secretFormula2"></param>
        /// <param name="secretFormula3"></param>
        /// <param name="secretFormula4"></param>
        /// <returns>Decoded instructions</returns>
        /// <exammple>http://localhost:58844/api/SecretInstruction/SecretFormula/57234/00907/34100/99999</exammple>
        /// <return>right 234 right 907 left 100</return>
        /// <example>http://localhost:58844/api/SecretInstruction/SecretFormula/57234/00907/99999/67800</example>
        /// <return>right 234 right 907<</return> //here 3rd parameter is break so it will not give output of the next paramaeter
        [HttpGet]
        [Route("api/SecretInstruction/SecretFormula/{secretFormula1}/{secretFormula2}/{secretFormula3}/{secretFormula4}")]
        public string SecretFormula(string secretFormula1, string secretFormula2, string secretFormula3, string secretFormula4)
        {
            // Combine the secret formulas into an array for easier processing
            string[] secretFormulas = { secretFormula1, secretFormula2, secretFormula3, secretFormula4 };
            string decodedInstructions = "";

            // Loop through each secret formula
            foreach (string secretFormula in secretFormulas)
            {
                // Break if any of the secret formulas contains "99999"
                if (secretFormula.Contains("99999"))
                {
                    break;
                }

                // Ensure the secret formula is not null and has length greater than or equal to 5
                if (!string.IsNullOrEmpty(secretFormula) && secretFormula.Length >= 5)
                {
                    // Parse the direction and steps from the secret formula
                    int firstDigit = int.Parse(secretFormula.Substring(0, 1));
                    int secondDigit = int.Parse(secretFormula.Substring(1, 1));
                    int direction = firstDigit + secondDigit;
                    int steps = int.Parse(secretFormula.Substring(2));

                    string decodedDirection;

                    // Determine the direction based on the rules provided
                    if ((direction % 2) == 1)
                    {
                        decodedDirection = "left";
                    }
                    else if (direction == 0)
                    {
                        decodedDirection = "right";
                    }
                    else
                    {
                        decodedDirection = "right";
                    }

                    decodedInstructions += (string.IsNullOrEmpty(decodedInstructions) ? "" : " ") + decodedDirection + " " + steps;
                }
            }

            return decodedInstructions;
        }
    }
}

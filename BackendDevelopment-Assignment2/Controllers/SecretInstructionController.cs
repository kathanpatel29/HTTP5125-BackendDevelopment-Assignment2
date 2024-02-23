using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Web.Http;

namespace BackendDevelopment_Assignment2.Controllers
{
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

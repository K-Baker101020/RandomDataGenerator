using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomDataGenerator
{
    public class SSN
    {
        // property
        public string Number { get; init; }

        // constructor
        public SSN()
        {
            Number = GenerateInvalidSSN();
        }

        /// <summary>
        /// Generate an invalid SSN. Information comes from:
        /// https://secure.ssa.gov/apps10/poms.nsf/lnx/0110201035
        /// </summary>
        /// <returns>A string invalid SSN</returns>
        private string GenerateInvalidSSN()
        {
            //Notes:
            //Some special numbers are never allocated like numbers with all zeros in any digit group
            //Example: 000-##-####, ###-00-####, ###-##-0000
            //
            //Numbers with 666 or 900-999 in the first digit group.

            // create a local variable to store the value we will return
            string invalidSSN = String.Empty;
            Random random = new Random();

            // generate a random number from 900-999 and convert it to a string
            var nineHundredSeries = random.Next(900, 1000).ToString();
            var firstThreeArray = new string[] { "000", "666", nineHundredSeries };

            var firstThree = firstThreeArray[random.Next(3)];
            var secondTwo = "";
            var lastFour = "";

            //First group is all 0's
            if (firstThree == "000")
            {
                //Generate a random number for the second group
                for (int i = 0; i < 2; i++)
                {
                    secondTwo += random.Next(0, 10).ToString();
                }

                //Generate a random number for the third group
                for (int i = 0; i < 4; i++)
                {
                    lastFour += random.Next(0, 10).ToString();
                }
            }
            else
            {
                //Determine if we will put all 0's in the seond or third group (a random boolean decision)
                var zeroLocation = random.Next(2);

                if (zeroLocation == 0)
                {
                    //The second group is all 0's
                    secondTwo = "00";

                    //Generate a random number for the third group
                    for (int i = 0; i < 4; i++)
                    {
                        lastFour += random.Next(0, 10).ToString();
                    }
                }
                else
                {
                    //The third group is all 0's
                    lastFour = "0000";

                    //Generate a random number for the second group
                    for (int i = 0; i < 2; i++)
                    {
                        secondTwo += random.Next(0, 10).ToString();
                    }
                }
            }
            invalidSSN = string.Concat(firstThree, "-", secondTwo, "-", lastFour);
            return invalidSSN;
        }

        public override string ToString()
        {
            string socialSecurityNumber = Number;
            socialSecurityNumber = socialSecurityNumber.Insert(3, "-");
            socialSecurityNumber = socialSecurityNumber.Insert(6, "-");
            return socialSecurityNumber;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    class VariantUSXpress1stApril2022
    {
        // int Validate(string parameters);

        // --label SOMELABEL --range 5 --help

        // range: 10 >= range <= 100

        // --label	a string of length between 3 and 10 characters (inclusive) // valid only if >=3 and <=10
        // --range	an integer between 10 and 100 (inclusive) // valid only if >= 10 and  <= 100
        // --help	

        // --range g	-1
        // --help name	-1
        // --label	-1
        // --blah	-1
        // --label SOME_LABEL --range 10	0
        // --raNGe 44	0
        // --label --range	0
        // --label abc --help	1
        // --help --range 11	1
        // --Help	1

        // -1	if any invalid parameters are detected
        // 0	if all parameters are valid
        // 1	if help was specified and all parameters are valid


        // https://github.com/variant-inc/Code-Challenge-Instructions/blob/main/cli-validation.md
        // https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=net-6.0#system-string-split(system-char-system-int32-system-stringsplitoptions)
        public int Validate(string input)
        {
            if (input.Length == 0) return -1;
            if (string.IsNullOrEmpty(input))
            {
                return -1;
            }
            // sarr[0] = --label
            return Util(input);


        }

        public int Util(string input)
        {
            string[] sarr = input.Split(' ');  //--label SOMELABEL --range 5 --help //space space space --label<space<space>Good_Label
            bool help = false;
            int i = 0;
            while (i < sarr.Length)
            {
                if (sarr[i] == "--label")
                {
                    // valid only if >=3 and <=10
                    while (sarr[i] == " ")
                    {
                        i++;
                    }
                    i--;
                    if (((i < sarr.Length) && (sarr[i + 1].Length < 3 || sarr[i + 1].Length > 10)) || (i > sarr.Length))
                    {
                        return -1;
                    }
                    i = i + 2;
                }
                else if (sarr[i] == "--range")
                {
                    // valid only if >= 10 and  <= 100
                    try
                    {
                        if (int.Parse(sarr[i + 1]) < 10 || int.Parse(sarr[i + 1]) > 100)
                        {
                            return -1;
                        }
                        i = i + 2;
                    }
                    catch (Exception e)
                    {
                        return -1;
                    }

                }
                else if (sarr[i] == "--help")
                {
                    help = true;
                    i++;
                }
                else if (sarr[i] == " ")
                {
                    while (sarr[i] == " ")
                    {
                        i++;
                    }
                }
                else
                {
                    return -1;
                }
            }
            return help ? 1 : 0;
        }
    }
}

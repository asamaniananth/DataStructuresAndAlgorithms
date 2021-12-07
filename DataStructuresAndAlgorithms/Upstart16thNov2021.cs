using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Upstart16thNov2021
    {
        // To execute C#, please define "static void Main" on a class
        // named Solution.
        static void UpstartMain(string[] args)
        {
            string result = function("/a/./.././..");

            Console.WriteLine(result);
        }

        // "/ab/cd/./ef" => “/ab/cd/ef”
        // "/ab/cd/../ef" => “/ab/ef” --> 0- /ab/cd 1- /ef , ab cd .. ef
        // "/a/./.././.." => “/“ a . .. . ..

        // "/a/../.."
        public static string function(string s)
        {
            string[] carr = s.Split('/');
            StringBuilder sb = new StringBuilder();

            int i = carr.Length - 1;
            while (i >= 0)
            {
                if (carr[i] == "..")
                {
                    i = i - 2;
                }
                else if (carr[i] == ".")
                {
                    i--;
                }
                else
                {
                    if (i == 0)
                    {
                        sb.Insert(0, carr[i]);
                    }
                    else
                    {
                        sb.Insert(0, carr[i]);
                        sb.Insert(0, "/");
                    }
                    i--;
                }
            }
            return sb.ToString();
        }
    }
}

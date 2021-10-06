using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    //Dinosaur      , Pedal         , Feet length
    //Dilophosaurus , Bipedal       , 3.0        
    //Troodon       , quadrupedal   , 4.2        
    //Sauropoda     , Bipedal       , 4.1        
    //Archaeopteryx , quadrupedal   , 2.5      

    //Dinosaur      , Stride Length, Max Age
    //Archaeopteryx, 13.0          , 15         
    //Sauropoda     , 12.2          , 22         
    //Dilophosaurus , 14.1          , 37         
    //Troodon       , 12.5          , 71     

    //and given following formula for computing speed,
    //Speed = ((Feet length* Stride Length)/ (Pedal) ) * age

    public class Dinosaur
    {
        public double CalculateSpeed(double fl, double sl, double p, double ma)
        {
            return ((fl * sl) / (p)) * ma;
        }

        public void ReadAndCalculate()
        {
            List<string> firstCsv = new List<string> { "Dinosaur,Pedal, Feetlength",
                                                      "Dilophosaurus , Bipedal       , 3.0",
                                                      "Troodon       , quadrupedal   , 4.2 ",
                                                      "Sauropoda     , Bipedal       , 4.1  ",
                                                      "Archaeopteryx , quadrupedal   , 2.5    "
                                                    };

            List<string> secondCsv = new List<string> { "Dinosaur      , StrideLength, MaxAge",
                                                      "Archaeopteryx, 13.0          , 15  ",
                                                      "Sauropoda     , 12.2          , 22   ",
                                                      "Dilophosaurus , 14.1          , 37 ",
                                                      "Troodon       , 12.5          , 71  "
                                                    };

            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();

            string[] firstHeader = firstCsv[0].Split(',');
            string[] secondHeader = secondCsv[0].Split(',');

            for (int i = 1; i < firstCsv.Count; i++)
            {
                string[] temp = firstCsv[i].Split(',');
                if (!dict.ContainsKey(temp[0].Trim()))
                {
                    dict.Add(temp[0].Trim(), new Dictionary<string, double> { { firstHeader[1].Trim(), temp[1].Trim() == "Bipedal" ? 2 : 4 },
                                                                              { firstHeader[2].Trim(), Convert.ToDouble(temp[2].Trim()) }
                                                                            });
                }
                else
                {
                    dict[temp[0].Trim()].Add(firstHeader[1].Trim(), temp[1] == "Bipedal" ? 2 : 4);
                    dict[temp[0].Trim()].Add(firstHeader[2].Trim(), Convert.ToDouble(temp[2].Trim()));
                }
                
            }

            for (int i = 1; i < secondCsv.Count; i++)
            {
                string[] temp = secondCsv[i].Split(',');
                if (!dict.ContainsKey(temp[0].Trim()))
                {
                    dict.Add(temp[0].Trim(), new Dictionary<string, double> { { secondHeader[1].Trim(), Convert.ToDouble(temp[1].Trim()) },
                                                                              { secondHeader[2].Trim(), Convert.ToDouble(temp[2].Trim()) }
                                                                            });
                }
                else
                {
                    dict[temp[0].Trim()].Add(secondHeader[1].Trim(), Convert.ToDouble(temp[1].Trim()));
                    dict[temp[0].Trim()].Add(secondHeader[2].Trim(), Convert.ToDouble(temp[2].Trim()));
                }
            }

            Dictionary<string, double> res = new Dictionary<string, double>();

            foreach (KeyValuePair<string, Dictionary<string, double>> en in dict)
            {
                //((d.FeetLength * d.StrideLength) / (d.Pedal)) * d.MaxAge;
                //"Dinosaur,Pedal, Feetlength",
                //"Dinosaur      , StrideLength, MaxAge",

                double sp = CalculateSpeed(en.Value["Feetlength"], en.Value["StrideLength"], en.Value["Pedal"], en.Value["MaxAge"]);
                res.Add(en.Key, sp);
            }
        }

    }
}

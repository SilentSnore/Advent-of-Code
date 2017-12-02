using System;
using System.Collections;
using System.Collections.Generic;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            String spreadsheet = "116\t1259\t1045\t679\t1334\t157\t277\t1217\t218\t641\t1089\t136\t247\t1195\t239\t834\r\n269\t1751\t732\t3016\t260\t6440\t5773\t4677\t306\t230\t6928\t7182\t231\t2942\t2738\t3617\r\n644\t128\t89\t361\t530\t97\t35\t604\t535\t297\t599\t121\t567\t106\t114\t480\r\n105\t408\t120\t363\t430\t102\t137\t283\t123\t258\t19\t101\t181\t477\t463\t279\r\n873\t116\t840\t105\t285\t238\t540\t22\t117\t125\t699\t953\t920\t106\t113\t259\r\n3695\t161\t186\t2188\t3611\t2802\t157\t2154\t3394\t145\t2725\t1327\t3741\t2493\t3607\t4041\r\n140\t1401\t110\t119\t112\t1586\t125\t937\t1469\t1015\t879\t1798\t122\t1151\t100\t926\r\n2401\t191\t219\t607\t267\t2362\t932\t2283\t889\t2567\t2171\t2409\t1078\t2247\t2441\t245\r\n928\t1142\t957\t1155\t922\t1039\t452\t285\t467\t305\t506\t221\t281\t59\t667\t232\r\n3882\t1698\t170\t5796\t2557\t173\t1228\t4630\t174\t3508\t5629\t4395\t180\t5100\t2814\t2247\r\n396\t311\t223\t227\t340\t313\t355\t469\t229\t162\t107\t76\t363\t132\t453\t161\r\n627\t1331\t1143\t1572\t966\t388\t198\t2068\t201\t239\t176\t1805\t1506\t1890\t1980\t1887\r\n3390\t5336\t1730\t4072\t5342\t216\t3823\t85\t5408\t5774\t247\t5308\t232\t256\t5214\t787\r\n176\t1694\t1787\t1586\t3798\t4243\t157\t4224\t3603\t2121\t3733\t851\t2493\t4136\t148\t153\r\n2432\t4030\t3397\t4032\t3952\t2727\t157\t3284\t3450\t3229\t4169\t3471\t4255\t155\t127\t186\r\n919\t615\t335\t816\t138\t97\t881\t790\t855\t89\t451\t789\t423\t108\t95\t116";
            String[] rows = spreadsheet.Split('\r');
            int sum = 0;

            /*
            foreach (var row in rows)
            {
                String[] numbers = row.Split('\t');
                int min = Int32.MaxValue, max = Int32.MinValue;
                foreach (var number in numbers)
                {
                    int num = Int32.Parse(number);
                    if (num < min)
                        min = num;
                    if (num > max)
                        max = num;
                }
                sum += (max - min);
            }
            Console.WriteLine(sum);
            Console.ReadKey();
            */

            foreach (var row in rows)
            {
                String[] numbers = row.Split('\t');
                List<int> nums = new List<int>(numbers.Length);
                foreach (var number in numbers)
                {
                    nums.Add(Int32.Parse(number));
                }

                foreach (var num in nums)
                {
                    bool isFound = false;
                    foreach (var n in nums)
                    {
                        int first = num, second = n;
                        if(first == second)
                            continue;
                        if (first > second)
                        {
                            if (first % second == 0)
                            {
                                sum += (first / second);
                                isFound = true;
                                break;
                            }
                        }
                        else
                        {
                            if (second % first == 0)
                            {
                                sum += (second / first);
                                isFound = true;
                                break;
                            }
                        }
                    }
                    if (isFound == true)
                        break;
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}

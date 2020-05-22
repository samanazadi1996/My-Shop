using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class RateHelper
{

    public static string ToStarRate(this Common.RateType? rate)
    {
        string str = "";
        if (rate > 0)
        {

            str = "<div class='rating'>";
            for (int i = 0; i < (int)rate; i++)
            {
                str += "<span class='fa fa-stack'>" +
                    "<i class='fa fa-star fa-stack-1x'></i>" +
                    "<i class='fa fa-star-o fa-stack-1x'></i>" +
                    "</span>";

            }
            for (int i = 0; i < 5 - (int)rate; i++)
            {
                str += "<span class='fa fa-stack'>" +
                    "<i class='fa fa-star-o fa-stack-1x'></i>" +
                    "</span>";
            }
            str += "</div>";
        }
        return str;
    }
    public static string ProductToStarRate(int SumRates,int CountRates)
    {
        string str = "";
        

            str = "<div class='rating'>";
            for (int i = 0; i < (int)SumRates; i++)
            {
                str += "<span class='fa fa-stack'>" +
                    "<i class='fa fa-star fa-stack-1x'></i>" +
                    "<i class='fa fa-star-o fa-stack-1x'></i>" +
                    "</span>";

            }
            for (int i = 0; i < 5 - (int)SumRates; i++)
            {
                str += "<span class='fa fa-stack'>" +
                    "<i class='fa fa-star-o fa-stack-1x'></i>" +
                    "</span>";
            }
            str += "</div>";
        
        return str;
    }
}
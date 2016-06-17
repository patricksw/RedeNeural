using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RneDog
{
    public class Parse
    {
        public static int ToInt(object o)
        {
            try
            {
                return int.Parse(o.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static int BoolToInt(object o)
        {
            try
            {
                bool ret = Parse.ToBoolean(o);
                if (ret)
                    return 1;
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        public static bool IntToBool(object o)
        {
            try
            {
                int ret = Parse.ToInt(o);
                if (ret == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool ToBoolean(object o)
        {
            try
            {
                return bool.Parse(o.ToString());
            }
            catch
            {
                return false;
            }
        }

        public static double ToDouble(object o)
        {
            try
            {
                return double.Parse(o.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ToDate(object o)
        {
            try
            {
                return DateTime.Parse(o.ToString());
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
    }
}
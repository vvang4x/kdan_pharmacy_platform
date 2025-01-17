﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyMask.Fundation.Helper
{
    public static class StringHelper
    {
        public static List<T> ToListByCutString<T>(this string data, string cutString = ",")
        {
            List<T> result = null;
            if (!string.IsNullOrEmpty(data))
            {
                if (typeof(T) == typeof(bool))
                {
                    result = data.Split(cutString, StringSplitOptions.RemoveEmptyEntries).Select(i => (T)Convert.ChangeType(int.Parse(i), typeof(T))).ToList();
                }
                else if (typeof(T).IsEnum)
                {
                    result = data.Split(cutString, StringSplitOptions.RemoveEmptyEntries).Select(i => (T)Convert.ChangeType(Enum.Parse(typeof(T), i, true), typeof(T))).ToList();
                }
                else
                    result = data.Split(cutString, StringSplitOptions.RemoveEmptyEntries).Select(i => (T)Convert.ChangeType(i, typeof(T))).ToList();
            }
            return result;
        }
    }
}

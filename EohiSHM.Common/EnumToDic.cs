using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Common
{
    /// <summary>
    /// enum=>键值对集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumToDic
    {
        public static Dictionary<int, string> GetEnumToDic()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (int val in Enum.GetValues(typeof(TypeEnum)))
            {
                if (!dictionary.Keys.Contains(val))
                {
                    string name = Enum.GetName(typeof(TypeEnum), val);
                    dictionary.Add(val, name);
                }
            }
            return dictionary;
        }
    }
}

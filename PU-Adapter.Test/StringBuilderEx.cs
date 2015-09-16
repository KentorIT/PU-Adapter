using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kentor.PU_Adapter.Test
{
    public static class StringBuilderEx
    {
        public static StringBuilder OverWrite(this StringBuilder sb, int index, string newString)
        {
            return sb.Remove(index, newString.Length).Insert(index, newString);
        }
    }
}

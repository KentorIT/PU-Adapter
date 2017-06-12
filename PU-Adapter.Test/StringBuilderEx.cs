using Kentor.PU_Adapter.FieldDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kentor.PU_Adapter.Test
{
    public static class StringBuilderEx
    {

        public static StringBuilder OverWrite(this StringBuilder sb, FieldDefinition fieldDefinition, string newString)
        {
            if(newString.Length > fieldDefinition.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            return OverWrite(sb, fieldDefinition.StartPosition - 1, newString);
        }
        private static StringBuilder OverWrite(this StringBuilder sb, int index, string newString)
        {
            return sb.Remove(index, newString.Length).Insert(index, newString);
        }
    }
}

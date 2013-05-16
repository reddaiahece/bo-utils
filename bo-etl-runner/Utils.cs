using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectsEtl.Runner
{
    public static class Utils
    {
        internal static string Encode(string Value){
            return Utils.XORcrypt(Utils.DecodeFrom64(Value));
        }

        internal static string Decode(string Value){
            return Utils.EncodeTo64(Utils.XORcrypt(Value));
        }

        internal static string XORcrypt(string Value)
        {
            string Key="ydzngh";
            StringBuilder result = new StringBuilder();
            int pl=Value.Length;
            int kl=Key.Length;
            for (int c = 0; c < pl; c++){
                result.Append((char)((uint)Value[c] ^ (uint)Key[c % kl]));
            }
            return result.ToString();
        }

         internal static string EncodeTo64(string toEncode)
         {
             byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
             string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
             return returnValue;
         }

         internal static string DecodeFrom64(string encodedData)
         {
             byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
             string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
             return returnValue;
         }

    }
}


namespace BusinessObjectsUtils.helper
{
    public class ValuePair
    {
        public object Key;
        public string Value;

        public ValuePair(object key, string value)   
        {
            Key = key;
            Value = value;
        }   
        
        public override string ToString()   
        {
            return Value;
        }   

    }
}

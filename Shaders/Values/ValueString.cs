using System.IO;

namespace Rage.Shaders.Values
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class ValueString : Value
    {
        public string value { get; private set; }

        public ValueString(BinaryReader br)
        {
            Read(br);
        }

        public void Read(BinaryReader br)
        {
            value = Utils.ReadString(br);
        }

        public override string ToString()
        {
            return value;
        }
    }
}

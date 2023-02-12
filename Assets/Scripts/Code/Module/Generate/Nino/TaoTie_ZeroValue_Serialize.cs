/* this is generated by nino */
namespace TaoTie
{
    public partial class ZeroValue
    {
        [LitJson.Extensions.JsonIgnore]
        public static ZeroValue.SerializationHelper NinoSerializationHelper = new ZeroValue.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ZeroValue>
        {
            #region NINO_CODEGEN
            public override void Serialize(ZeroValue value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);

            }

            public override ZeroValue Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ZeroValue value = new ZeroValue();
                return value;
            }
            #endregion
        }
    }
}
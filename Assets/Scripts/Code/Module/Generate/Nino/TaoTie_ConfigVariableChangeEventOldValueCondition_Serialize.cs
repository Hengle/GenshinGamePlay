/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigVariableChangeEventOldValueCondition
    {
        [LitJson.Extensions.JsonIgnore]
        public static ConfigVariableChangeEventOldValueCondition.SerializationHelper NinoSerializationHelper = new ConfigVariableChangeEventOldValueCondition.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigVariableChangeEventOldValueCondition>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigVariableChangeEventOldValueCondition value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.CompressAndWriteEnum<TaoTie.CompareMode>(value.mode);
                writer.Write(value.value);
            }

            public override ConfigVariableChangeEventOldValueCondition Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigVariableChangeEventOldValueCondition value = new ConfigVariableChangeEventOldValueCondition();
                reader.DecompressAndReadEnum<TaoTie.CompareMode>(ref value.mode);
                reader.Read<System.Single>(ref value.value, Nino.Shared.Mgr.ConstMgr.SizeOfUInt);
                return value;
            }
            #endregion
        }
    }
}
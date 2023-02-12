/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigGearRemoveExtraGroupAction
    {
        [LitJson.Extensions.JsonIgnore]
        public static ConfigGearRemoveExtraGroupAction.SerializationHelper NinoSerializationHelper = new ConfigGearRemoveExtraGroupAction.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigGearRemoveExtraGroupAction>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigGearRemoveExtraGroupAction value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.Write(value.disable);
                writer.CompressAndWrite(ref value.localId);
                writer.Write(value.isOtherGear);
                writer.CompressAndWrite(ref value.otherGearId);
                writer.CompressAndWrite(ref value.groupId);
            }

            public override ConfigGearRemoveExtraGroupAction Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigGearRemoveExtraGroupAction value = new ConfigGearRemoveExtraGroupAction();
                reader.Read<System.Boolean>(ref value.disable, 1);
                reader.DecompressAndReadNumber<System.Int32>(ref value.localId);
                reader.Read<System.Boolean>(ref value.isOtherGear, 1);
                reader.DecompressAndReadNumber<System.UInt64>(ref value.otherGearId);
                reader.DecompressAndReadNumber<System.Int32>(ref value.groupId);
                return value;
            }
            #endregion
        }
    }
}
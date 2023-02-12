/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigAttackEvent
    {
        [LitJson.Extensions.JsonIgnore]
        public static ConfigAttackEvent.SerializationHelper NinoSerializationHelper = new ConfigAttackEvent.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigAttackEvent>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigAttackEvent value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.WriteCommonVal<TaoTie.ConfigBaseAttackPattern>(value.AttackPattern==null?TypeInfo<TaoTie.ConfigBaseAttackPattern>.Type:value.AttackPattern.GetType(),value.AttackPattern);
                TaoTie.ConfigAttackInfo.NinoSerializationHelper.Serialize(value.AttackInfo, writer);
            }

            public override ConfigAttackEvent Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigAttackEvent value = new ConfigAttackEvent();
                value.AttackPattern = reader.ReadCommonVal<TaoTie.ConfigBaseAttackPattern>();
                value.AttackInfo = TaoTie.ConfigAttackInfo.NinoSerializationHelper.Deserialize(reader);
                return value;
            }
            #endregion
        }
    }
}
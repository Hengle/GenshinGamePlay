/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigHitScene
    {
        [LitJson.Extensions.JsonIgnore]
        public static ConfigHitScene.SerializationHelper NinoSerializationHelper = new ConfigHitScene.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigHitScene>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigHitScene value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.Write(value.DefaultEffect);
                writer.Write(value.SurfaceEffect);
            }

            public override ConfigHitScene Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigHitScene value = new ConfigHitScene();
                value.DefaultEffect = reader.ReadString();
                value.SurfaceEffect = reader.ReadDictionary<System.String,System.String>();
                return value;
            }
            #endregion
        }
    }
}
using System;
using Nino.Serialization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TaoTie
{
    [TriggerType(typeof(ConfigExitZoneEventTrigger))]
    [NinoSerialize]
    public partial class ConfigExitZoneEventZoneEntityIdCondition : ConfigSceneGroupCondition<ExitZoneEvent>
    {
        [Tooltip(SceneGroupTooltips.CompareMode)]
        [OnValueChanged("@"+nameof(CheckModeType)+"("+nameof(Value)+","+nameof(Mode)+")")]
        [NinoMember(1)]
        public CompareMode Mode;
        [NinoMember(2)]
        public Int64 Value;

        public override bool IsMatch(ExitZoneEvent obj, SceneGroup sceneGroup)
        {
            return IsMatch(Value, obj.ZoneEntityId, Mode);
        }
#if UNITY_EDITOR
        protected override bool CheckModeType<T>(T t, CompareMode mode)
        {
            if (!base.CheckModeType(t, mode))
            {
                mode = CompareMode.Equal;
                return false;
            }

            return true;
        }
#endif
    }
}

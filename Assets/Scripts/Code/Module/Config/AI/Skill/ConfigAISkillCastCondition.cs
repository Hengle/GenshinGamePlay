﻿using Nino.Serialization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TaoTie
{
    [NinoSerialize]
    public partial class ConfigAISkillCastCondition
    {
        [NinoMember(1)][Tooltip("处于这些Pose中时有效, 为null表示全有效")]
        public int[] PoseIds;
        [NinoMember(2)][Min(0)][LabelText("与视线水平角度min")][BoxGroup("目标选取")]
        public float MinTargetAngleXZ;
        [NinoMember(3)][Min(0)][LabelText("与视线水平角度max")][BoxGroup("目标选取")]
        public float MaxTargetAngleXZ= 90;
        [NinoMember(4)][Min(0)][LabelText("与视线y角度min")][BoxGroup("目标选取")]
        public float MinTargetAngleY;
        [NinoMember(5)][Min(0)][LabelText("与视线y角度max")][BoxGroup("目标选取")]
        public float MaxTargetAngleY = 90;
        [NinoMember(6)][Min(0)][LabelText("距离min")][BoxGroup("目标选取")]
        public float PickRangeMin;
        [NinoMember(7)][Min(0)][LabelText("距离max")][BoxGroup("目标选取")]
        public float PickRangeMax = 1;
        [NinoMember(8)][LabelText("高度差min")][BoxGroup("目标选取")]
        public float PickRangeYMin = -1;
        [NinoMember(9)][LabelText("高度差max")][BoxGroup("目标选取")]
        public float PickRangeYMax = 1;
        [NinoMember(10)][Min(0)][LabelText("持续施法距离min")]
        public float SkillAnchorRangeMin;
        [NinoMember(11)][Min(0)][LabelText("持续施法距离max")]
        public float SkillAnchorRangeMax = 1;
        [NinoMember(12)][Min(0)][LabelText("施法距离min")]
        public float CastRangeMin;
        [NinoMember(13)][Min(0)][LabelText("施法距离max")]
        public float CastRangeMax = 1;
    }
}
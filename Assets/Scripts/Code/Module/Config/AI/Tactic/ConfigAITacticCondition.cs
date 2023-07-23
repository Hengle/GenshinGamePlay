﻿using Nino.Serialization;
using UnityEngine;

namespace TaoTie
{
    [NinoSerialize]
    public partial class ConfigAITacticCondition
    {
        [NinoMember(1)][Tooltip("处于这些Pose中时有效, 为null表示全有效")]
        public int[] PoseId;
    }
}
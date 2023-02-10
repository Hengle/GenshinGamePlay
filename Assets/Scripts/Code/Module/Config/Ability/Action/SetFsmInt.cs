﻿using Nino.Serialization;

namespace TaoTie
{
    [NinoSerialize]
    public class SetFsmInt : SetFsmParam<int>
    {
        protected override void SetData(FsmComponent fsmComponent)
        {
            fsmComponent.SetData(Key,Value);
        }
    }
}
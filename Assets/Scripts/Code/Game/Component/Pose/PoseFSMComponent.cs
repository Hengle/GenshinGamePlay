﻿using UnityEngine;

namespace TaoTie
{
    public class PoseFSMComponent: FsmComponent
    {
        public new PoseFsm defaultFsm => base.defaultFsm as PoseFsm;
        protected override Fsm CreateFsm(ConfigFsm fsmCfg)
        {
            return PoseFsm.Create(this, fsmCfg);
        }
    }
}
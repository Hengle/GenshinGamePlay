﻿namespace TaoTie
{
    public class DoActionByStateIDMixin : AbilityMixin
    {
        public ConfigDoActionByStateIDMixin config => baseConfig as ConfigDoActionByStateIDMixin;
        
        private Fsm fsm;
        private Entity onwer;
        public override void Init(ActorAbility actorAbility, ActorModifier actorModifier, ConfigAbilityMixin config)
        {
            base.Init(actorAbility, actorModifier, config);
            onwer = actorAbility.Parent.GetParent<Entity>();
            fsm = onwer?.GetComponent<FsmComponent>()?.GetFsm(this.config.ChargeLayer);
            if (fsm != null)
            {
                fsm.onStateChanged += OnStateChanged;
                if (this.config.StateIDs.Contains(fsm.currentStateName))
                {
                    OnEnter();
                }
            }
        }

        private void OnStateChanged(string from, string to)
        {
            if (config.StateIDs == null)
                return;

            bool flag = config.StateIDs.Contains(from), flag2 = config.StateIDs.Contains(to);
            if (!flag && flag2)
            {
                OnEnter();
            }
            else if (flag && !flag2)
            {
                OnExit();
            }
        }

        private void OnEnter()
        {
            if (config.EnterActions!=null && EvaluatePredicate(config.EnterPredicate))
            {
                for (int i = 0; i < config.EnterActions.Length; i++)
                {
                    config.EnterActions[i].DoExecute(onwer, actorAbility, actorModifier, null);
                }
            }
        }

        private bool EvaluatePredicate(ConfigAbilityPredicate predicate)
        {
            if (predicate != null)
            {
                return predicate.Evaluate(onwer, actorAbility, actorModifier, onwer);
            }
            return true;
        }

        private void OnExit()
        {
            if (config.ExitActions!=null && EvaluatePredicate(config.ExitPredicate))
            {
                for (int i = 0; i < config.ExitActions.Length; i++)
                {
                    config.ExitActions[i].DoExecute(onwer, actorAbility, actorModifier, null);
                }
            }
        }

        public override void Dispose()
        {
            if (fsm != null)
            {
                fsm.onStateChanged -= OnStateChanged;
                fsm = null;
            }
            
            onwer = null;
            base.Dispose();
        }
    }
}
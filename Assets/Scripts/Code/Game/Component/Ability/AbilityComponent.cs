﻿using System.Collections.Generic;

namespace TaoTie
{
    public class AbilityComponent:Component,IComponent<List<ConfigAbility>>
    {
        private bool isDestroy;
        private ListComponent<ActorAbility> abilities;

        private ListComponent<ActorModifier> modifiers;
        private UnOrderDoubleKeyMap<ConfigAbility, ConfigAbilityModifier, ActorModifier> modifierDictionary;
        #region override
        public void Init(List<ConfigAbility> data)
        {
            isDestroy = false;
            abilities = ListComponent<ActorAbility>.Create();
            modifiers = ListComponent<ActorModifier>.Create();
            modifierDictionary = new UnOrderDoubleKeyMap<ConfigAbility, ConfigAbilityModifier, ActorModifier>();
            for (int i = 0; i < data.Count; i++)
            {
                var ability = ActorAbility.Create(data[i], this);
                abilities.Add(ability);
                ability.AfterAdd();
            }
        }
		
        public void Destroy()
        {
            isDestroy = true;
            for (int i = 0; i < abilities.Count; i++)
            {
                abilities[i].BeforeRemove();
                abilities[i].Dispose();
            }
            abilities.Dispose();
            
            for (int i = 0; i < modifiers.Count; i++)
            {
                modifiers[i].BeforeRemove();
                modifiers[i].Dispose();
            }
            modifiers.Dispose();

            modifierDictionary = null;
        }

        #endregion


        public void ApplyModifier(long applierID, ActorAbility ability, string modifierName)
        {
            if (!ability.TryGetConfigAbilityModifier(modifierName, out var config))
            {
                Log.Error($"ApplyModifier Fail! modifierName = {modifierName} abilityName = {ability.Config.AbilityName}");
                return;
            }

            var list = modifierDictionary[ability.Config, config];
            if (list.Count > 0)
            {
                // 处理堆叠
                switch (config.StackingType)
                {
                    case StackingType.Unique:
                    {
                        // 只能存在唯一一个
                        return ;
                    }
                    case StackingType.Multiple:
                    {
                        // 互相独立存在,且有层数数量限制
                        int limitNum = int.MaxValue;
                        if (config.StackLimitCount > 0)
                        {
                            limitNum = config.StackLimitCount;
                        }

                        if (modifiers.Count < limitNum)
                        {
                            var modifier = ActorModifier.Create(applierID, config, ability, this);
                            modifiers.Add(modifier);
                            modifierDictionary.Add(ability.Config, config, modifier);
                            modifier.AfterAdd();
                        }
                        return ;
                    }
                    case StackingType.Refresh:
                    {
                        // 刷新已存在的modifier
                        for (int i = 0; i < modifiers.Count; ++i)
                        {
                            modifiers[i].SetDuration(config.Duration);
                        }
                        return ;
                    }
                    case StackingType.Prolong:
                    {
                        // 延长已存在的modifier
                        for (int i = 0; i < modifiers.Count; ++i)
                        {
                            modifiers[i].AddDuration(config.Duration);
                        }
                        return ;
                    }
                }
                return ;
            }
            else
            {
                var modifier = ActorModifier.Create(applierID, config, ability, this);
                modifiers.Add(modifier);
                modifierDictionary.Add(ability.Config, config, modifier);
                modifier.AfterAdd();
            }
            
        }
        
        public void RemoveModifier(ActorModifier modifier)
        {
            if(isDestroy) return;
            if (modifierDictionary.Contains(modifier.Ability.Config, modifier.Config, modifier))
            {
                modifier.BeforeRemove();
                modifiers.Remove(modifier);
                modifierDictionary.Remove(modifier.Ability.Config, modifier.Config, modifier);
                modifier.Dispose();
            }
        }

        
        
        public void RemoveAbility(ActorAbility ability)
        {
            if(isDestroy) return;
            if (abilities.Contains(ability))
            {
                ability.BeforeRemove();
                abilities.Remove(ability);
                ability.Dispose();
            }
        }
    }
}
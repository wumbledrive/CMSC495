using System;
using System.Collections.Generic;

namespace CharacterStatsSpace
{
    [Serializable]
    public class CharacterStats
    {

        public float BaseValue;

        public float Value
        {
            get
            {
                if (changed)
                {
                    _value = FinalValue();
                    changed = false;
                }
                return _value;
            }
        }

        private bool changed = true;
        private float _value;

        private readonly List<StatModifiers> modifiers;

        public CharacterStats()
        {
            modifiers = new List<StatModifiers>();
        }

        public CharacterStats(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        public void AddMod(StatModifiers mod)
        {
            changed = true;
            modifiers.Add(mod);
        }

        public bool RemoveMod(StatModifiers mod)
        {
            changed = true;
            return modifiers.Remove(mod);
        }

        public bool RemoveAllMods(object source)
        {
            bool removed = false;

            for (int i = modifiers.Count - 1; i >= 0; i--)
            {
                changed = true;
                removed = true;
                modifiers.RemoveAt(i);
            }
            return removed;
        }

        private float FinalValue()
        {
            float finalValue = BaseValue;

            for (int i = 0; i < modifiers.Count; i++)
            {
                finalValue += modifiers[i].Value;
            }

            return (float)Math.Round(finalValue, 4);
        }
    }
}

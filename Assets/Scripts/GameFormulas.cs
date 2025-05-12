using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

static class GameFormulas
{
    static bool HasElementAdvantage(ELEMENT attackElement, Hero defender) => (attackElement == defender.GetWeakness());
    static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender) => (attackElement == defender.GetResistance());
    static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
        {
            return 1.5f;
        }
        else if (HasElementDisadvantage(attackElement, defender))
        {
            return 0.5f;
        }
        else
        {
            return 1;
        }
    }
    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.aim - defender.eva;
        int result = Random.Range(0, 100);
        if (result > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        else
        {
            return true;
        }

    }
    static bool IsCrit(int critValue)
    {
        int result = Random.Range(0, 100);
        if (result < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        else
        {
            return false;
        }
    }
    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats totalStatsAttacker = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        Stats totalStatsDefender = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());

        int defenderDefense;

        if (attacker.GetWeapon().GetDmgType() == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            defenderDefense = totalStatsDefender.def;
        }
        else if (attacker.GetWeapon().GetDmgType() == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            defenderDefense = totalStatsDefender.res;
        }
        else
        {
            defenderDefense = 0;
        }

        int baseDamage = totalStatsAttacker.atk - defenderDefense;
        float elementModifier = EvaluateElementalModifier(attacker.GetWeapon().GetElem(), defender);
        int finalDamage = Mathf.RoundToInt(baseDamage * elementModifier);

        if (IsCrit(totalStatsAttacker.crt))
        {
            finalDamage *= 2;
        }

        if (finalDamage < 0)
        {
            finalDamage = 0;
            return finalDamage;
        }
        else
        {
            return finalDamage;
        }
    }

}

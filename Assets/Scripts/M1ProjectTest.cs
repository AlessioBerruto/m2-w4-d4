using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    public Hero heroA;
    public Hero heroB;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!heroA.IsAlive() || !heroB.IsAlive())
        {
            return;
        }

        int heroASpeed = heroA.GetBaseStats().spd + heroA.GetWeapon().GetBonusStats().spd;
        int heroBSpeed = heroB.GetBaseStats().spd + heroB.GetWeapon().GetBonusStats().spd;
        bool heroAAttacksFirst = heroASpeed > heroBSpeed;

        if (heroAAttacksFirst)
        {
            Attack(heroA, heroB);
            if (heroB.IsAlive())
            {
                Attack(heroB, heroA);
            }
        }
        else
        {            
            Attack(heroB, heroA);
            if (heroA.IsAlive())
            {
                Attack(heroA, heroB);
            }
        }

    }

    public void Attack(Hero attacker, Hero defender)
    {
        Stats attackerStats = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        Stats defenderStats = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());
        
        Debug.Log(attacker.GetName() + " attacca " + defender.GetName());

        if (GameFormulas.HasHit(attackerStats, defenderStats))
        {
            if (attacker.GetWeapon().GetElem() == defender.GetWeakness())
            {
                Debug.Log("WEAKNESS");

            }
            if (attacker.GetWeapon().GetElem() == defender.GetResistance())
            {
                Debug.Log("RESIST");

            }
            int damage = GameFormulas.CalculateDamage(attacker, defender);
            Debug.Log("Danno inflitto: " + damage);
            defender.TakeDamage(damage);

            if (!defender.IsAlive())
            {
                Debug.Log(attacker.GetName() + " è il vincitore");
            }
        }
    }
}

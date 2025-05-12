using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Weapon")]

public class Weapon : ScriptableObject
{
    public enum DAMAGE_TYPE
    {
        PHYSICAL,
        MAGICAL
    }

    [SerializeField] private string Name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private ELEMENT elem;
    [SerializeField] private Stats bonusStats;

    public Weapon(string name, DAMAGE_TYPE dmgType, ELEMENT elem, Stats bonusStats)
    {
        this.Name = name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }

    public string GetName() => Name;
    public DAMAGE_TYPE GetDmgType() => dmgType;
    public ELEMENT GetElem() => elem;
    public Stats GetBonusStats() => bonusStats;

    public void SetName(string name) => this.Name = string.IsNullOrEmpty(name) ? this.Name : name;
    public void SetDamageType(DAMAGE_TYPE dmgType) => this.dmgType = dmgType;
    public void SetElement(ELEMENT elem) => this.elem = elem;
    public void SetBonusStats(Stats bonusStats) => this.bonusStats = bonusStats;


}

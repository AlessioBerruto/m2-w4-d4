using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "NewHero", menuName = "ScriptableObjects/Hero")]

public class Hero : ScriptableObject
{
    [SerializeField] private string Name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;


    public Hero(string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon weapon)
    {
        this.Name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;
    }

    public string GetName() => Name;
    public int GetHP() => hp;
    public Stats GetBaseStats() => baseStats;
    public ELEMENT GetResistance() => resistance;
    public ELEMENT GetWeakness() => weakness;
    public Weapon GetWeapon() => weapon;

    public void SetName(string name) => this.Name = string.IsNullOrEmpty(name) ? this.Name : name;
    public void SetHP(int hp) => this.hp = (hp > 0) ? hp : 0;
    public void SetBaseStats(Stats baseStats) => this.baseStats = baseStats;
    public void SetResistance(ELEMENT resistance) => this.resistance = resistance;
    public void SetWeakness(ELEMENT weakness) => this.weakness = weakness;
    public void SetWeapon(Weapon weapon) => this.weapon = weapon;

    public void AddHP(int amount)
    {
        SetHP(hp + amount);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }
        AddHP(-damage);
    }

    public bool IsAlive() => (hp > 0);   

}

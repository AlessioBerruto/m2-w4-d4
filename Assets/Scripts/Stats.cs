using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]

public struct Stats
{
    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }

    public static Stats Sum(Stats a, Stats b)
    {
        Stats somma = new Stats();

        somma.atk = a.atk + b.atk;
        somma.def = a.def + b.def;
        somma.res = a.res + b.res;
        somma.spd = a.spd + b.spd;
        somma.crt = a.crt + b.crt;
        somma.aim = a.aim + b.aim;
        somma.eva = a.eva + b.eva;

        return somma;
    }
}

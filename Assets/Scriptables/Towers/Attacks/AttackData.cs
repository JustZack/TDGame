using System;
using UnityEngine;


public abstract class AttackData : PrefabableObject {
    public float range;
    public float speed;
    public bool isHoming;
    public long damage;
    public long damageGiven = 0;
    public bool destroyWhenZeroDamage;
    public long DamageLeft() {
        return Math.Max(this.damage - this.damageGiven, 0);
    }
}

using System;
using UnityEngine;


[CreateAssetMenu(fileName = "NewProjectileData", menuName = "Resources/Towers/Projectile")]
public class ProjectileData : PrefabableObject {
    public float range;
    public float speed;
    public bool isHoming;
    public float lifespan;
    public long damage;
    public long damageGiven = 0;
    public long DamageLeft() {
        return Math.Max(this.damage - this.damageGiven, 0);
    }
    public override GameObject Instantiate() {
        GameObject projectile = base.Instantiate();
        projectile.transform.localScale *= this.size;
        ProjectileController pc = projectile.AddComponent<ProjectileController>();
        pc.data = this.Copy<ProjectileData>();
        return projectile;
    }
}

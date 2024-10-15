using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectileData", menuName = "Resources/Towers/Attacks/Projectile")]
public class ProjectileData : AttackData {
    public float spawnTime;
    public float lifespan;
    public bool shouldDestroy() {
        return this.spawnTime + lifespan < Time.time;
    }
    public override GameObject Instantiate() {
        GameObject projectile = base.Instantiate();
        ProjectileController pc = projectile.AddComponent<ProjectileController>();
        ProjectileData pd = this.Copy<ProjectileData>();
        pd.spawnTime = Time.time;
        pc.data = pd;
        return projectile;
    }
}

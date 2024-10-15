using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStabData", menuName = "Resources/Towers/Attacks/Stab")]
public class StabData : AttackData {
    public override GameObject Instantiate() {
        GameObject projectile = base.Instantiate();
        ProjectileController pc = projectile.AddComponent<ProjectileController>();
        pc.data = this.Copy<ProjectileData>();
        return projectile;
    }
}

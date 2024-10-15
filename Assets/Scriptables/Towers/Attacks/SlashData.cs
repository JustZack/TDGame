using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSlashData", menuName = "Resources/Towers/Attacks/Slash")]
public class SlashData : AttackData {
    public override GameObject Instantiate() {
        GameObject projectile = base.Instantiate();
        ProjectileController pc = projectile.AddComponent<ProjectileController>();
        pc.data = this.Copy<ProjectileData>();
        return projectile;
    }
}

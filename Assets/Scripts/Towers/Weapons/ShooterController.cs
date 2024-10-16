using UnityEngine;

public class ShooterController : WeaponController {
    public override void Attack(GameObject toAttack) {
        base.Attack(toAttack);
        GameObject projectile = data.attack.Instantiate();
        projectile.transform.position = this.transform.position;
        ProjectileController pc = projectile.GetComponent<ProjectileController>();
        pc.SetTarget(toAttack);
        pc.Trigger();
    }
}

using UnityEngine;

public class StabberController : WeaponController {
    public override void Attack(GameObject toAttack) {
        base.Attack(toAttack);
        GameObject spear = data.attack.Instantiate();
        spear.transform.position = this.transform.position;
        StabController sc = spear.GetComponent<StabController>();
        sc.SetTarget(toAttack);
        sc.Trigger();
        sc.onComplete = this.ToggleSpearVisibility;
        this.ToggleSpearVisibility();
    }

    public void ToggleSpearVisibility() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}

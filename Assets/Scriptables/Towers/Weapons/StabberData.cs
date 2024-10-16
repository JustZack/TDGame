using UnityEngine;

[CreateAssetMenu(fileName = "NewStabberData", menuName = "Resources/Towers/Weapons/Stabber")]
public class StabberData : WeaponData {
    public override GameObject Instantiate() {
        GameObject weapon = base.Instantiate();
        StabberController sc = weapon.AddComponent<StabberController>();
        sc.data = this.Copy<StabberData>();
        return weapon;
    }
}

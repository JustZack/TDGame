using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Resources/Towers/Weapons/Shooter")]
public class ShooterData : WeaponData {
    public override GameObject Instantiate() {
        GameObject weapon = base.Instantiate();
        ShooterController sc = weapon.AddComponent<ShooterController>();
        sc.data = this.Copy<WeaponData>();
        return weapon;
    }
}

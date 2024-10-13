using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Resources/Towers/Weapon")]
public class WeaponData : PrefabableObject {
    public string name;
    public float cooldown;
    public ProjectileData projectile;
    public override GameObject Instantiate() {
        GameObject weapon = base.Instantiate();
        weapon.transform.localScale *= this.size;
        WeaponController wc = weapon.AddComponent<WeaponController>();
        wc.data = this;
        return weapon;
    }
}

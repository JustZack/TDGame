using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Resources/Towers/Weapon")]
public class WeaponData : PrefabableObject {
    public string name;
    public float cooldown;
    public AttackData attack;
}

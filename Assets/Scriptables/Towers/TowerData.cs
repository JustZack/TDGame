using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "NewTowerData", menuName = "Resources/Towers/Tower")]
public class TowerData : PlaceableObject {
    public uint cost;
    public float range;
    public WeaponData[] weapons;
    public Sprite icon;
    public uint kills;
    public override GameObject Instantiate() {
        GameObject tower = base.Instantiate();
        TowerController tc = tower.AddComponent<TowerController>();
        tc.data = this;
        return tower;
    }
}

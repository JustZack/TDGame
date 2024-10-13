using UnityEngine;


[CreateAssetMenu(fileName = "NewTowerData", menuName = "Resources/Towers/Upgrade")]
public class TowerUpgradeData : ScriptableObject {
    public string name;
    public float cost;
    public bool isActive;
    public float range;
    public float damage;
}

using UnityEngine;


[CreateAssetMenu(fileName = "NewTowerData", menuName = "Resources/Towers/UpgradePath")]
public class TowerUpgradesData : ScriptableObject {
    public TowerUpgradePathData path1;
    public TowerUpgradePathData path2;
    public TowerUpgradePathData path3;
}

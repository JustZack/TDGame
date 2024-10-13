using UnityEngine;


[CreateAssetMenu(fileName = "NewTowerData", menuName = "Resources/Towers/UpgradePath")]
public class TowerUpgradePathData : ScriptableObject {
    public TowerUpgradeData[] tiers;

    public void upgrade() {
        
    }
    public TowerUpgradeData getCurrentTier() {
        TowerUpgradeData lastTier = null;
        foreach (TowerUpgradeData tud in this.tiers) {
            if (tud.isActive) lastTier = tud;
            else break;
        }
        return lastTier;
    }
}

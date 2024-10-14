using System;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Resources/Enemy")]
public class EnemyData : PrefabableObject {
    public long maxHealth;
    public long hits = 0;
    public float speed;
    public Sprite icon;
    public long Health() {
        return Math.Max(this.maxHealth - this.hits, 0);
    }
    public override GameObject Instantiate() {
        GameObject enemy = base.Instantiate();
        EnemyController ec = enemy.AddComponent<EnemyController>();
        ec.data = this.Copy<EnemyData>();
        return enemy;
    }
}

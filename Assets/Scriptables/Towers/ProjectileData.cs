using UnityEngine;


[CreateAssetMenu(fileName = "NewProjectileData", menuName = "Resources/Towers/Projectile")]
public class ProjectileData : PrefabableObject {
    public float range;
    public float speed;
    public bool isHoming;
    public override GameObject Instantiate() {
        GameObject projectile = base.Instantiate();
        projectile.transform.localScale *= this.size;
        ProjectileController pc = projectile.AddComponent<ProjectileController>();
        pc.data = this;
        return projectile;
    }
}

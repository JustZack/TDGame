using UnityEngine;

public class WeaponController : MonoBehaviour {
    public WeaponData data;
    private float lastUse = 0;
    public bool CanFire() {
        return this.lastUse + data.cooldown < Time.time;
    }
    public void FireAt(GameObject toShoot) {
        this.lastUse = Time.time;
        GameObject projectile = data.projectile.Instantiate();
        projectile.transform.position = this.transform.position;
        ProjectileController pc = projectile.GetComponent<ProjectileController>();
        this.transform.LookAt(toShoot.transform);
        pc.SetTarget(toShoot);
        pc.Fire();
    }

    public void Start() {
        
    }

    public void Update() {

    }
}

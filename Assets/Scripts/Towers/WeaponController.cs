using UnityEngine;

public class WeaponController : MonoBehaviour {
    public WeaponData data;
    private float lastUse = 0;
    public bool CanFire() {
        return this.lastUse + data.cooldown < Time.time;
    }
    public void LookAt(GameObject toLook) {
        Vector3 direction = toLook.transform.position - this.transform.position;
        // Calculate the angle in degrees to rotate around the Z-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Apply the rotation by setting the Z angle
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + data.prefabAngleOffset));
    }
    public void FireAt(GameObject toShoot) {
        this.lastUse = Time.time;
        GameObject projectile = data.projectile.Instantiate();
        Destroy(projectile, data.projectile.lifespan);
        projectile.transform.position = this.transform.position;
        ProjectileController pc = projectile.GetComponent<ProjectileController>();
        pc.SetTarget(toShoot);
        pc.Fire();

        this.LookAt(toShoot);
    }

    public void Start() {
    }

    public void Update() {

    }
}

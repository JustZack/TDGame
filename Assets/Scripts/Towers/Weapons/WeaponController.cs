using UnityEngine;

public abstract class WeaponController : MonoBehaviour {
    public WeaponData data;
    private float lastUse = 0;
    public bool CanAttack() {
        return this.lastUse + data.cooldown < Time.time;
    }
    public void LookAt(GameObject toLook) {
        Vector3 direction = toLook.transform.position - this.transform.position;
        // Calculate the angle in degrees to rotate around the Z-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Apply the rotation by setting the Z angle
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + data.prefabAngleOffset));
    }
    public virtual void Attack(GameObject toAttack) {
        this.lastUse = Time.time;
        this.LookAt(toAttack);
    }
    public void Start() {
    }

    public void Update() {

    }
}

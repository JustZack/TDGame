using UnityEngine;

public abstract class AttackController : MonoBehaviour {
    public AttackData data;
    public GameObject target;
    public void SetTarget(GameObject target) {
        this.target = target;
        this.lookAtTarget();
    }
    public virtual void lookAtTarget() {
        this.target.GetComponent<SpriteRenderer>().color = Color.red;
        Vector3 direction = this.target.transform.position - this.transform.position;
        // Calculate the angle in degrees to rotate around the Z-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Apply the rotation by setting the Z angle
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + data.prefabAngleOffset));
    }
    public virtual void OnTriggerEnter(Collider other) {
        if (other.tag.Contains(Tags.Enemy)) {
            this.HitEnemy(other.GetComponent<EnemyController>());
        }
    }

    public virtual void HitEnemy(EnemyController ec) {
        long enemyHealth = ec.data.Health();
        long attackDamageLeft = this.data.DamageLeft();

        if (enemyHealth - attackDamageLeft < 0) {
            Destroy(ec.gameObject);
            this.data.damageGiven += enemyHealth;
        }  else if (this.data.destroyWhenZeroDamage) {
            Destroy(this.gameObject);
        }
    }
}

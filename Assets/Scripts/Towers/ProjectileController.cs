using System;
using JetBrains.Annotations;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    public ProjectileData data;
    private GameObject target;
    private bool fired = false;
    public void SetTarget(GameObject target) {
        this.target = target;
        this.lookAtTarget();
    }
    private void lookAtTarget() {
        this.target.GetComponent<SpriteRenderer>().color = Color.red;
        Vector3 direction = this.target.transform.position - this.transform.position;
        // Calculate the angle in degrees to rotate around the Z-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Apply the rotation by setting the Z angle
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + data.prefabAngleOffset));
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag.Contains(Tags.Enemy)) {
            this.HitEnemy(other.GetComponent<EnemyController>());
        }
    }
    public void HitEnemy(EnemyController ec) {
        long enemyHealth = ec.data.Health();
        long projectileHealth = this.data.DamageLeft();

        if (enemyHealth - projectileHealth < 0) {
            Destroy(ec.gameObject);
            this.data.damageGiven += enemyHealth;
        }  else Destroy(this.gameObject);
    }

    public void Fire() {
        this.fired = true;
    }   
    public bool isFired() {
        return this.fired;
    }
    public void Start() {
        
    }
    public void Update() {
        if (this.isFired()) {
            if (data.isHoming) this.lookAtTarget();
            this.transform.position += this.transform.up * data.speed * Time.deltaTime;
        }
    }
}

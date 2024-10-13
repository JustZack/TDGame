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
        this.transform.LookAt(target.transform);
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
            this.transform.position += this.transform.forward * data.speed * Time.deltaTime;
        }
    }
}

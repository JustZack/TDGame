using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileController : AttackController {
    private bool fired = false;
    public void Fire() {
        this.fired = true;
    }   
    public bool isFired() {
        return this.fired;
    }
    public bool didDestroy() {
        if (this.shouldDestroy()) {
            Destroy(this.gameObject);
            return true;
        } else {
            return false;
        }
    }
    public bool shouldDestroy() {
       return ((ProjectileData)this.data).shouldDestroy();
    }

    public void Start() {

    }
    public void Update() {
        if (this.isFired()) {
            if (!this.didDestroy()) {
                if (data.isHoming) this.lookAtTarget();
                this.transform.position += this.transform.up * data.speed * Time.deltaTime;
            }
        }
    }
    
    public void OnBecameInvisible() {
        this.didDestroy();
    }
}

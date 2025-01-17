using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileController : AttackController {
    public override bool shouldDestroy() {
       return ((ProjectileData)this.data).shouldDestroy();
    }

    public void Start() {

    }
    public void Update() {
        if (this.isTriggered()) {
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

using System;
using UnityEngine;

public class StabController : AttackController {
    private Vector3 startingPosition;
    private Vector3 targetPosition;
    private bool attackComplete = false;
    private bool movingForward = true;
    private float elapsed = 0;
    public Action onComplete;
    public override bool shouldDestroy() {
        return this.attackComplete;
    }
    public void Start() {
        this.startingPosition = this.transform.position;
        this.targetPosition = this.startingPosition + this.transform.up * this.data.range;
    }
    public void Update() {
        if (this.isTriggered() && !this.didDestroy()) {
            this.elapsed += Time.deltaTime;
            float easeTime = this.elapsed / this.data.speed;
            if (this.movingForward) {
                this.transform.position = Vector3.Lerp(this.startingPosition, this.targetPosition, easeTime);
                if (this.elapsed >= this.data.speed) {
                    this.movingForward = false;
                    this.elapsed = 0f;
                }
            } else {
                this.transform.position = Vector3.Lerp(this.targetPosition, this.startingPosition, easeTime);
                if (this.elapsed >= this.data.speed) {
                    this.attackComplete = true;
                    this.onComplete();
                }
            }
        }
    }
}

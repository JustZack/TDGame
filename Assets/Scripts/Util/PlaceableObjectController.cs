using UnityEngine;

public abstract class PlaceableObjectController : MonoBehaviour {
    private bool is_placed = false;
    public virtual void StopPlacement() {
        this.is_placed = true;
    }
    public bool isPlaced() { return this.is_placed; }
}

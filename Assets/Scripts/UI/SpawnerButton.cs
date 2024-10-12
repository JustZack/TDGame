using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerButton : MonoBehaviour, IClickable
{
    public SpawnerButtonData data;
    private static PlacementLayer PlacementLayer = null;
    public void OnPointerDown(PointerEventData eventData) {
        SpawnerButton.PlacementLayer.StartPlacement(Instantiate(data.tower));
    }

    public void OnPointerUp(PointerEventData eventData) {

    }

    public void Start() {
        if (SpawnerButton.PlacementLayer == null) {
            GameObject placementObject = GameObject.FindWithTag("PlacementLayer");
            if (placementObject != null) SpawnerButton.PlacementLayer = placementObject.GetComponent<PlacementLayer>();
            else throw new System.Exception("No placement layer found in scene. Be sure your object is tagged with `PlacementLayer` and has the PlacementLayer controller.");
        }
    }

    public void Update() {

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerButton : MonoBehaviour, IClickable
{
    public TowerData data;
    private static PlacementLayer PlacementLayer = null;
    public static void setPlacementLayer(PlacementLayer newPlacementLayer) {
        SpawnerButton.PlacementLayer = newPlacementLayer;
    }
    public void OnPointerDown(PointerEventData eventData) {
        SpawnerButton.PlacementLayer.StartPlacement(data);
    }

    public void OnPointerUp(PointerEventData eventData) {

    }

    public bool isEnabled() {
        return true;
    }

    public void Start() {

    }

    public void Update() {

    }
}

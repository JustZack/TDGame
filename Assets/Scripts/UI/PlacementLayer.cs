using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementLayer : MonoBehaviour
{
    private PlaceableObject placeable;
    private PlaceableObjectController controller;
    private GameObject placing;
    public bool isPlacing = false;

    public void StartPlacement(PlaceableObject placeable) {
        this.isPlacing = true;
        this.placeable = placeable;
        this.placing = placeable.Instantiate();
        this.controller = this.placing.GetComponent<PlaceableObjectController>();
    }

    public void StopPlacement() {
        this.controller.StopPlacement();
        
        this.isPlacing = false;
        this.placeable = null;
        this.controller = null;
        this.placing = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (this.isPlacing) {
            if (Input.GetMouseButton(0)) this.FollowMouse();
            else this.StopPlacement();
        }
    }

    private void FollowMouse() {
        // Get the mouse position in world space (assuming a 2D game or camera in perspective)
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Adjust as necessary (distance from the camera)
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Update the object's position
        this.placing.transform.position = worldPosition;
    }
}

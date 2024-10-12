using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementLayer : MonoBehaviour
{
    public GameObject toPlace;
    public bool isPlacing = false;

    public void StartPlacement(GameObject placeableObject) {
        this.isPlacing = true;
        this.toPlace = placeableObject;
    }

    public void StopPlacement() {
        this.isPlacing = false;
        this.toPlace = null;
        Debug.Log("placed");
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
        toPlace.transform.position = worldPosition;
    }
}

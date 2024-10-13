using System;
using UnityEngine;
using UnityEngine.UIElements;

class Find {
    public static GameObject NearestWithTag(Vector3 comparedTo, string tag, float maxDistance = Mathf.Infinity) {
        // Find all GameObjects with the specified tag
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity; // Set an infinitely large distance
        Vector3 currentPosition = comparedTo;

        // Iterate through all found objects and find the nearest one
        foreach (GameObject obj in objectsWithTag)
        {
            // Calculate the distance between the current position and the object's position
            float distance = Vector3.Distance(currentPosition, obj.transform.position);

            // If this distance is smaller than the previously recorded distance, update nearestObject
            if (distance < nearestDistance && distance <= maxDistance)
            {
                nearestDistance = distance;
                nearestObject = obj;
            }
        }

        return nearestObject; // Return the nearest object found
    }
}
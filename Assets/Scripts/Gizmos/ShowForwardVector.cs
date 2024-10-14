using UnityEngine;

public class ShowForwardVector : MonoBehaviour
{
    public float lineLength = 2f; // Length of the forward vector line

    // This method is called in the editor and while the game is running
    void OnDrawGizmos()
    {
        // Set the Gizmo color
        Gizmos.color = Color.blue;

        // Draw a line from the object’s position in the forward direction
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * lineLength);

        // Optionally, draw a small sphere at the endpoint for visualization
        Gizmos.DrawSphere(transform.position + transform.forward * lineLength, 0.1f);
        Gizmos.DrawSphere(transform.position + transform.up * lineLength/2, 0.1f);
    }
}

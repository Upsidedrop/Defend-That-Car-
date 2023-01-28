using UnityEngine;

public class TurretRotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Get the position of the mouse in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Get the direction the object needs to rotate towards
        Vector2 direction = new(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        // Get the angle of rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the object towards the mouse
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

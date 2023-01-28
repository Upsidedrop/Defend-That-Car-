using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float rotation;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * Input.GetAxis("Vertical") * 1.5f;
        rotation += 0-Input.GetAxis("Horizontal") * 1.2f;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

}

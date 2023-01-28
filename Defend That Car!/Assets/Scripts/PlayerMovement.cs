using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float rotation;
    bool cooldown = true;
    [SerializeField]
    Animator animator;
    private void Awake()
    {
        //gets the Rigidbody2D component of the object this script is attached to
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moves the object based on vertical input * 1.5f
        rb.velocity = 1.5f * Input.GetAxis("Vertical") * -transform.right;
        //adds the negative value of horizontal input to the rotation variable
        rotation += 0 - Input.GetAxis("Horizontal") * 1.2f;
        //sets the rotation of the object to the rotation variable
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    //The Update method is called every frame in the game.
    private void Update()
    {
        //This if statement checks if the left mouse button has been pressed and if the cooldown variable is true.
        if (Input.GetMouseButtonDown(0) && cooldown)
        {
            //If the conditions are met, the Cooldown method is called as a coroutine.
            StartCoroutine(Cooldown());
            //This line triggers the "Fire" animation in the animator.
            animator.SetTrigger("Fire");
        }
    }
    //This is the definition of the Cooldown method.
    IEnumerator Cooldown()
    {
        //This line sets the cooldown variable to false, preventing the player from firing again until the cooldown is over.
        cooldown = false;
        //This line makes the coroutine wait for 4 seconds before executing the next line.
        yield return new WaitForSeconds(4);
        //This line sets the cooldown variable to true, allowing the player to fire again.
        cooldown = true;
    }
}

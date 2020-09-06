using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float jumpingForce = 10f;
    public bool isGrounded = false;
    public float tiltAngle = 60.0f;
    float smooth = 5.0f;

    public Joystick joystick;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded == true)
        {
            Jump();
            Debug.Log("Player is grounded");
        }

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = joystick.Horizontal * tiltAngle;
        float tiltAroundX = joystick.Vertical * tiltAngle * Time.deltaTime;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }


    void Jump()
    {
        // Jump constantly

        rb2D.AddForce(transform.up * jumpingForce * Time.deltaTime, ForceMode2D.Impulse);
        // rb2D.velocity = new Vector3(0, jumpingForce, 0);
        isGrounded = false;
    }
}

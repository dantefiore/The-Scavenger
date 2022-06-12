using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public CharacterController controller;  //the player controller
    public Transform cam;   //the player's camera

    [Header("Speed")]
    public float speed = 6; //the players speed

    [Header("Jumping/Gravity")]
    public float gravity = -10f;    //the gravity of the player
    public float jumpHeight = 3;    //the jump height of the player
    Vector3 velocity;   //the velocity at which the players fall

    [Header("Turn Rotation")]
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Jump();
        Gravity();
        Walk();
    }

    private void Jump()
    {
        //if the player is on the ground and they arent falling
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = gravity;   //set velocity
        }

        //if the player pushes the jump button
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); //moves the character up
        }
    }
    
    //whenever the character is in the air
    private void Gravity()
    {
        //moves the character down at a certain speed
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Walk()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  //the 'a' and 'd' keys
        float vertical = Input.GetAxisRaw("Vertical");  //the 'w' and 's' keys

        //the direction the character is moving
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //if the character is moving
        if (direction.magnitude >= 0.1f)
        {
            //the angle the character is moving in relation to the camera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);   //rotates the character to the direction they are moving

            //moves the character
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
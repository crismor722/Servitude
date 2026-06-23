using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   public float speed = 5f;
   public float jumpForce = 5f;
   public float mouseSensitivity = 1f;
   private Rigidbody rb;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() // basic update
    {
        // movement
        moveInput = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
        if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
        if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
        if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;

        //mouse movement
        mouseInput = Mouse.current.delta.ReadValue();

        // rotation using mouse
        transform.Rotate(Vector3.up * mouseInput.x * mouseSensitivity);

        //raycasting, this allows the player to detect ground
        isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            0.6f
        );

        //jump
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate() //50 times per second update a lot of updating
    {
        // movement relative to where player is facing
        Vector3 move =
            (transform.right * moveInput.x +
             transform.forward * moveInput.y).normalized;

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float mouseSensitivity = 120f;
    public Transform playerCamera;

    private CharacterController controller;
    private float cameraPitch = 0f;
    private Vector3 velocity;
    private float gravity = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
       // ApplyGravity();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void Look()

{

    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    float keyboardTurn = 0f;

    if (Input.GetKey(KeyCode.Q))

    {

        keyboardTurn = -1f;

    }

    if (Input.GetKey(KeyCode.E))

    {

        keyboardTurn = 1f;

    }

    transform.Rotate(Vector3.up * (mouseX + keyboardTurn * mouseSensitivity * Time.deltaTime));

    cameraPitch -= mouseY;

    cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f);

    playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);

}

    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
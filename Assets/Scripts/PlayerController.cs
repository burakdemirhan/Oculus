using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float mouseSensitivity = 120f;
    public Transform playerCamera;
    public float interactionDistance = 3f;

    private CharacterController controller;
    private float cameraPitch = 0f;
    private Vector3 velocity;
    private float gravity = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (playerCamera != null)
        {
            playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
        CheckInteraction();

        // Şimdilik kapalı. Yatak/zemin sistemi stabil olunca açabiliriz.
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

    float keyboardPitch = 0f;

    if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))

        keyboardTurn = -1f;

    if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.RightArrow))

        keyboardTurn = 1f;

    if (Input.GetKey(KeyCode.UpArrow))

        keyboardPitch = 1f;

    if (Input.GetKey(KeyCode.DownArrow))

        keyboardPitch = -1f;

    transform.Rotate(Vector3.up * (mouseX + keyboardTurn * mouseSensitivity * Time.deltaTime));

    cameraPitch -= mouseY;

    cameraPitch += keyboardPitch * mouseSensitivity * Time.deltaTime;

    cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f);

    playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);

}

    void CheckInteraction()
    {
        if (playerCamera == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");

            Ray ray = new Ray(playerCamera.position, playerCamera.forward);

            if (Physics.SphereCast(ray, 0.5f, out RaycastHit hit, interactionDistance, ~LayerMask.GetMask("Player")))
            {
                Debug.Log("Hit: " + hit.collider.name);

                CollectibleObject collectible = hit.collider.GetComponentInParent<CollectibleObject>();

                if (collectible != null)
                {
                    collectible.Collect();
                    return;
                }

                InteractableObject interactable = hit.collider.GetComponentInParent<InteractableObject>();

                if (interactable != null)
                {
                    interactable.Interact();
                    return;
                }

                Debug.Log("Hit object has no interaction script.");
            }
            else
            {
                Debug.Log("Nothing hit");
            }
        }
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
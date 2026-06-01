using UnityEngine;

/// <summary>
/// First Person Controller for Unity 6
/// 
/// SETUP INSTRUCTIONS:
/// 1. Create a GameObject (e.g. "Player") and attach this script.
/// 2. Add a CharacterController component to the same GameObject.
/// 3. Create a Camera as a CHILD of the Player object.
///    - Position it at roughly (0, 0.8, 0) to simulate eye height.
/// 4. Assign that Camera to the "Player Camera" field in the Inspector.
/// 5. (Optional) Adjust speed, sensitivity, jump height, and gravity in the Inspector.
/// 6. Hit Play — cursor will lock automatically. Press Escape to unlock.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Walking speed in units per second.")]
    public float moveSpeed = 5f;

    [Tooltip("Multiplier applied to moveSpeed when holding Shift.")]
    public float sprintMultiplier = 1.8f;

    [Header("Jumping & Gravity")]
    [Tooltip("How high the player jumps in units.")]
    public float jumpHeight = 1.2f;

    [Tooltip("Gravity strength. Unity default is -9.81.")]
    public float gravity = -9.81f;

    [Header("Mouse Look")]
    [Tooltip("Mouse sensitivity for horizontal (X) and vertical (Y) rotation.")]
    public float mouseSensitivity = 2f;

    [Tooltip("Maximum degrees the camera can look up.")]
    public float maxLookUp = 80f;

    [Tooltip("Maximum degrees the camera can look down.")]
    public float maxLookDown = 80f;

    [Header("References")]
    [Tooltip("The Camera child object used for vertical mouse look.")]
    public Camera playerCamera;

    // ── Private state ──────────────────────────────────────────────────────────
    private CharacterController _controller;
    private Vector3 _velocity;          // Tracks vertical (gravity/jump) velocity
    private float _cameraPitch = 0f;  // Accumulated vertical camera rotation

    // ──────────────────────────────────────────────────────────────────────────
    void Awake()
    {
        _controller = GetComponent<CharacterController>();

        // Auto-find camera if not assigned in Inspector
        if (playerCamera == null)
            playerCamera = GetComponentInChildren<Camera>();

        if (playerCamera == null)
            Debug.LogWarning("[FirstPersonController] No camera found. Assign one in the Inspector.");

        LockCursor(true);
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        HandleCursorToggle();
    }

    // ── Mouse Look ─────────────────────────────────────────────────────────────
    void HandleMouseLook()
    {
        if (Cursor.lockState != CursorLockMode.Locked) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player body left/right (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera up/down (pitch), clamped to avoid flipping
        _cameraPitch -= mouseY;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -maxLookDown, maxLookUp);

        if (playerCamera != null)
            playerCamera.transform.localRotation = Quaternion.Euler(_cameraPitch, 0f, 0f);
    }

    // ── Movement & Gravity ─────────────────────────────────────────────────────
    void HandleMovement()
    {
        bool isGrounded = _controller.isGrounded;

        // Reset downward velocity when grounded (prevents accumulation)
        if (isGrounded && _velocity.y < 0f)
            _velocity.y = -2f;  // Small negative keeps the controller grounded

        // WASD / Arrow key input (uses Unity's Input Manager axes)
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Build move direction relative to where the player is facing
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Sprint (hold Left Shift)
        float speed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * sprintMultiplier : moveSpeed;

        _controller.Move(move * speed * Time.deltaTime);

        // Jump (Space, only when grounded)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // v = sqrt(h * -2 * g)  — classic kinematic formula for jump velocity
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    // ── Cursor Lock Toggle ─────────────────────────────────────────────────────
    void HandleCursorToggle()
    {
        // Press Escape to unlock the cursor (e.g. to access menus)
        if (Input.GetKeyDown(KeyCode.Escape))
            LockCursor(false);

        // Click anywhere to re-lock
        if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
            LockCursor(true);
    }

    void LockCursor(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}
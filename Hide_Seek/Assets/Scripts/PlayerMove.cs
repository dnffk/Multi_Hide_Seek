using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun
{
    public Transform cameraTransform;
    public CharacterController characterController;

    public float moveSpeed = 10f;
    public float jumpSpeed = 5f;
    public float gravity = -20f;
    public float sensitivity = 500f;

    private float yVelocity = 0;
    private float rotationY = 0f;

    void Start()
    {
        if (!photonView.IsMine)
        {
            if (cameraTransform != null)
                cameraTransform.gameObject.SetActive(false);
            return;
        }

        if (cameraTransform == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                cameraTransform = mainCamera.transform;
            }
            else
            {
                Debug.LogError("Main Camera를 찾을 수 없습니다!");
            }
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!photonView.IsMine) return;

        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = cameraTransform.forward * v + cameraTransform.right * h;
        moveDirection.y = 0;
        moveDirection *= moveSpeed;

        if (characterController.isGrounded)
        {
            yVelocity = -1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
            }
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

        moveDirection.y = yVelocity;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        float mouseMoveX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        rotationY += mouseMoveX;
        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 5f;
    public float runSpeed = 10f;

    [Header("Jump")]
    public float jumpForce = 5f;
    private Rigidbody rb;
    public bool isGrounded;

    [Header("Camera")]
    public Transform cameraTransform;
    
    [Header("Animation")]
    public Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTransform = Camera.main.transform;

        if (animator == null)
        {
            animator = GetComponent<Animator>(); 
        }
    }

    void Update()
    {
        MoveCharacter();
        HandleJump();
        Run();
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            cameraForward.y = 0; 
            cameraForward.Normalize();
            Vector3 moveDirection = Quaternion.LookRotation(cameraForward) * direction;
            rb.MovePosition(transform.position + moveDirection * movementSpeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runSpeed;
        }
        else
        {
            movementSpeed = 5f;
        }
    }

    void HandleJump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump"); 
        }
    }
}
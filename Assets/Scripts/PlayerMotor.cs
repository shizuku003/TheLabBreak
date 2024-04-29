using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float speed = 5f;
    [SerializeField]
    private float normalSpeed = 5f;
    [SerializeField]
    private float sprintSpeed = 10f;
    private bool isGrounded;
    private float gravity = -15f;
    [SerializeField]
    private float jumpHeight = 3f;
    private bool sprinting;
    private Animator animator;
    public bool destroyFlag;
    public bool jumpFlag;
    [SerializeField]
    private float rayLength = 1f;
    [SerializeField]
    private float rayOffset;
    [SerializeField]
    private LayerMask layerMask = default;
    private bool isGround;
    private bool powerFlag;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGround = CheckGrounded();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGround && jumpFlag == true)
            jumpFlag = false;
        else if (!isGround)
            jumpFlag = true;

    }

    //InputManager.csから値を受け取り、CharactorControllerに適用する。
    public void ProcessMove(Vector2 input)
    {
        if (input != new Vector2(0, 0))
            animator.SetBool("IsWalking", true);
        else
            animator.SetBool("IsWalking", false);

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded || isGround)
        {
            //ジャンプの初速計算（平方根）
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
            jumpFlag = true;
        }
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting && powerFlag)
            speed = sprintSpeed;
        else
            speed = normalSpeed;
    }

    public void Punch()
    {
        animator.SetBool("IsPunching", true);
        destroyFlag = true;
    }

    public void PunchEnd()
    {
        animator.SetBool("IsPunching", false);
        destroyFlag = false;
    }

    private bool CheckGrounded()
    {
        var ray = new Ray(origin: transform.position + Vector3.up * rayOffset, direction: Vector3.down);
        return Physics.Raycast(ray, rayLength, layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * rayOffset, Vector3.down * rayLength);
    }

    public void PowerUP()
    {
        powerFlag = true;
    }
}

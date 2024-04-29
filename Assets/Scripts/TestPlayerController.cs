using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 0.05f;
    private Rigidbody prb;
    [SerializeField]
    private GameObject rightArm;
    private Animator animator;
    public bool destroyFlag;
    private float flagTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        prb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("WalkingBool", false);

        if (Input.GetKey(KeyCode.W))
        {
            prb.velocity = transform.forward * playerSpeed;
            //transform.Translate(0, 0, playerSpeed);
            animator.SetBool("WalkingBool", true);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            prb.velocity = - transform.forward * playerSpeed;
            //transform.Translate(0, 0, -playerSpeed);
            animator.SetBool("WalkingBool", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            prb.velocity = transform.right * playerSpeed;
            animator.SetBool("WalkingBool", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            prb.velocity = - transform.right * playerSpeed;
            animator.SetBool("WalkingBool", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("PunchBool", true);
            destroyFlag = true;
        }
        else
        {
            animator.SetBool("PunchBool", false);
        }

        if (destroyFlag)
        {
            flagTimer += Time.deltaTime;
            if (flagTimer > 0.18)
            {
                destroyFlag = false;
                flagTimer = 0;
            }
        }
    }
}

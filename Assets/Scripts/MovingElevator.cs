using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElevator : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.01f;
    [SerializeField]
    private Transform point1;
    [SerializeField]
    private Transform point2;
    private float distance;
    private bool isArrived;
    [SerializeField]
    private GameObject player;
    public bool footFlag;
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    [SerializeField]
    private CharacterController controller;
    private PlayerMotor playerMotor;
    public bool electricalFlag;

    void Start()
    {
        previousPosition = transform.position;
        playerMotor = player.GetComponent<PlayerMotor>();
    }

    void Update()
    {
        currentPosition = transform.position;
        Vector3 deltaPosition = currentPosition - previousPosition;
        previousPosition = currentPosition;
        if (electricalFlag)
        {
            if (!isArrived)
            {
                distance = Vector3.Distance(gameObject.transform.position, point1.position);
                if (distance > 0.1)
                    transform.Translate(0, moveSpeed, 0);
                else
                    isArrived = true;
            }
        }

        if (footFlag)
        {
            controller.Move(deltaPosition);
            playerMotor.jumpFlag = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerFoot")
        {
            footFlag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerFoot")
        {
            footFlag = false;
        }
    }

    public void ElectricalOn()
    {
        electricalFlag = true;
    }
}

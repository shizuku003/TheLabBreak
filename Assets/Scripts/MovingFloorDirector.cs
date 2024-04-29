using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorDirector : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.3f;
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

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        currentPosition = transform.position;
        Vector3 deltaPosition = currentPosition - previousPosition;
        previousPosition = currentPosition;

        if (!isArrived)
        {
            distance = Vector3.Distance(gameObject.transform.position, point1.position);
            if (distance > 0.1)
                transform.Translate(0, 0, moveSpeed);
            else
                isArrived = true;
        }
        else
        {
            distance = Vector3.Distance(gameObject.transform.position, point2.position);
            transform.Translate(0, 0, -moveSpeed);
            if (distance < 0.1)
            {
                isArrived = false;
            }
        }

        if (footFlag)
        {
            controller.Move(deltaPosition);
            Debug.Log("ugoke");
        }
    }
}

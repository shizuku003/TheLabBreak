using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball;
    [SerializeField]
    private GameObject player;
    public Vector3 worldDir;
    public bool explosionFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            explosionFlag = !explosionFlag;
            if (explosionFlag)
                Debug.Log("Explosion!!");
            else
                Debug.Log("Not Explosion!!");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Ball).transform.position = player.transform.position + new Vector3(0, 0, 1);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            worldDir = ray.direction;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    [SerializeField]
    private float force = 2000;
    private DestroyWall dw;
    [SerializeField]
    private GameObject exSphere;
    private BallGenerator ballGen;

    // Start is called before the first frame update
    void Start()
    {
        ballGen = GameObject.Find("BallGenerator").GetComponent<BallGenerator>();
        GetComponent<Rigidbody>().AddForce(ballGen.worldDir.normalized * force);
        Debug.Log(ballGen.worldDir.normalized * force);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
            dw = collision.gameObject.GetComponent<DestroyWall>();
            dw.enabled = true;
            Destroy();
        }
    }

    private void Destroy()
    {
        if (ballGen.explosionFlag)
            Instantiate(exSphere).transform.position = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmScript : MonoBehaviour
{
    private DestroyWall dw;
    [SerializeField]
    private GameObject exSphere;
    [SerializeField]
    private PlayerMotor playerMotor;
    private float punchTiming = 0.23f;
    private float timer = 0f;
    private bool syringeFlag;
    [SerializeField]
    private AudioClip woodSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMotor.destroyFlag)
        {
            timer += Time.deltaTime;
            if (timer > punchTiming)
            {
                GetComponent<BoxCollider>().enabled = true;
            }
        }
        else
        {
            timer = 0f;
            GetComponent<BoxCollider>().enabled = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Breakable" && playerMotor.destroyFlag && syringeFlag)
        {
            if (collision.gameObject.GetComponent<DestroyWall>() != null)
            {
                dw = collision.gameObject.GetComponent<DestroyWall>();
                dw.enabled = true;
            }
            Destroy();
        }

        if (collision.gameObject.tag == "LightBreakable" && playerMotor.destroyFlag)
        {
            if (collision.gameObject.GetComponent<DestroyWall>() != null)
            {
                dw = collision.gameObject.GetComponent<DestroyWall>();
                dw.enabled = true;
                audioSource.PlayOneShot(woodSound);
            }
            Destroy();
        }
    }
    private void Destroy()
    {
        Instantiate(exSphere).transform.position = transform.position;
    }

    public void SyringeFlag()
    {
        syringeFlag = true;
    }
}

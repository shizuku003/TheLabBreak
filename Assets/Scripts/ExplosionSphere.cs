using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSphere : MonoBehaviour
{
    private Vector3 exposition;
    [SerializeField]
    private float exforce = 1;
    [SerializeField]
    private float exradius = 500;
    [SerializeField]
    private float exupwards = 0;
    PlayerMotor playerMotor;

    private void Start()
    {
        playerMotor = GameObject.Find("Player").GetComponent<PlayerMotor>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (playerMotor.jumpFlag == true)
        {
            exforce = 20f;
            exradius = 15f;
        }
        else
        {
            exforce = 5f;
            exradius = 5f;
        }
        exposition = transform.position;

        Collider[] hitColliders = Physics.OverlapSphere(exposition, exradius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Rigidbody rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(exforce, exposition, exradius, exupwards, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }
}

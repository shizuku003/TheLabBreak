using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    [SerializeField]
    private GameObject breakedWall;
    [SerializeField]
    private float adjustY = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject);
        //Instantiate(breakedWall).transform.position = transform.position - new Vector3(0, 1.5f, 0);
        GameObject wall = Instantiate(breakedWall);
        wall.transform.position = transform.position - new Vector3(0, adjustY, 0);
        wall.transform.rotation = transform.rotation;
    }
}

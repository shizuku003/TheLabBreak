using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lights;
    [SerializeField]
    private GameObject Audio_Object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LeadControll()
    {
        Instantiate(Audio_Object, transform.position, transform.rotation);
        for (int i=0;i<lights.Length;i++)
        {
            lights[i].SetActive(true);
        }
    }
}

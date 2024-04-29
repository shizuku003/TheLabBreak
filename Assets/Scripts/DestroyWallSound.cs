using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip wallSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(wallSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip syringeSound;
    private AudioSource audioSource;
    private float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(syringeSound);
    }

    private void Update()
    {
        destroyTime += Time.deltaTime;
        if (destroyTime > 2f)
        {
            Destroy(gameObject);
        }
    }
}

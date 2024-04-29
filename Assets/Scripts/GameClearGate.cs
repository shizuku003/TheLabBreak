using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearGate : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private int clearType;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.ClearTypeCheck(clearType);
            SceneManager.LoadScene("TLB_Start");
        }
    }
}

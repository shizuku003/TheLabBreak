using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaerTypeChecker : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private GameObject[] clearStickers;
    private bool[] clearTypeFlags;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //gameManager.ShowClearStrickers();
        clearTypeFlags = gameManager.SendClearType();

        for (int i = 0; i < clearStickers.Length; i++)
        {
            if (clearTypeFlags[i] == true)
            {
                Debug.Log(i);
                clearStickers[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingMenu;
    private bool menuFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuFlag == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                settingMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                settingMenu.SetActive(false);
                Time.timeScale = 1f;
            }

            menuFlag = !menuFlag;
        }
    }
}

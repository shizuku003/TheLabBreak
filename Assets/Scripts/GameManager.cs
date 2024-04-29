using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private bool[] clearTypeFlags;

    private float[] lookSensitivitys = { 20f, 20f };

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClearTypeCheck(int clearType)
    {
        clearTypeFlags[clearType] = true;
    }

    public bool[] SendClearType()
    {
        return clearTypeFlags;
    }

    public void SensitivityCheck(float xSensitivity, float ySensitivity)
    {
        lookSensitivitys[0] = xSensitivity;
        lookSensitivitys[1] = ySensitivity;
    }

    public float[] SendSensitivity()
    {
        return lookSensitivitys;
    }
}

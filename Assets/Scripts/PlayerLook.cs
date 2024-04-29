using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    public Camera cam;
    private float xRotation = 0f;

    [SerializeField]
    private Slider xSlider;
    [SerializeField]
    private Slider ySlider;
    [SerializeField]
    private float xSensitivity = 30f;
    [SerializeField]
    private float ySensitivity = 30f;
    private float[] receivedSensitivity = new float[2];

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        receivedSensitivity = gameManager.SendSensitivity();
        xSensitivity = receivedSensitivity[0];
        ySensitivity = receivedSensitivity[1];
        xSlider.value = xSensitivity;
        ySlider.value = ySensitivity;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }

    public void ChangeXSensitivity()
    {
        xSensitivity = xSlider.value;
        gameManager.SensitivityCheck(xSensitivity, ySensitivity);
    }

    public void ChangeYSensitivity()
    {
        ySensitivity = ySlider.value;
        gameManager.SensitivityCheck(xSensitivity, ySensitivity);
    }
}

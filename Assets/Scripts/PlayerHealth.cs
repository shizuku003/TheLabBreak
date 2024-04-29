using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int Health = 100;
    [SerializeField]
    private bool isDamaged;
    [SerializeField]
    private int damagePoint = 10;
    private bool isDead = false;
    [SerializeField]
    private Image damageImg;
    private bool dmgUIFlag;
    private float UITime;
    [SerializeField]
    private float fadeOut = 0.3f;
    [SerializeField]
    private float fadeSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged && !isDead)
        {
            Health -= damagePoint;
            UITime = 0f;
            dmgUIFlag = true;
            Debug.Log(Health);
            if (Health <= 0)
                isDead = true;
            isDamaged = false;
        }
        else if (isDead)
        {
            Debug.Log("You Dead!!");
        }

        if (dmgUIFlag)
        {
            damageImg.color = new Color(damageImg.color.r, damageImg.color.g, damageImg.color.b, 1);
            UITime += Time.deltaTime;
            if (UITime > fadeOut)
            {
                damageImg.color = new Color(damageImg.color.r, damageImg.color.g, damageImg.color.b, 1 - UITime / fadeSpeed);
                if (UITime / fadeSpeed > 1)
                {
                    UITime = 0f;
                    dmgUIFlag = false;
                }
            }
        }

    }

    public void Damaged()
    {
        isDamaged = true;
    }
}

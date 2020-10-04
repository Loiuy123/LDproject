using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToggle : MonoBehaviour
{

    public float DisableAlpha;
    public GameObject ToApply;

    public bool Enable;
    private bool lastEnable;


    private void Awake()
    {
        if (Enable)
        {
            EnableWall();
        }
        else
        {
            DisableWall();
        }
        lastEnable = Enable;
    }

    private void Update()
    {
        if (Enable!= lastEnable)
        {
            Awake();
        }
    }

    public void EnableWall()
    {
        ToApply.layer = 13;
        ToApply.GetComponent<SpriteRenderer>().color = 
            new Color(
                ToApply.GetComponent<SpriteRenderer>().color.r, 
                ToApply.GetComponent<SpriteRenderer>().color.g, 
                ToApply.GetComponent<SpriteRenderer>().color.b,
                1);
        Enable = true;
        lastEnable = true;
    }

    public void DisableWall()
    {
        ToApply.layer = 14;
        ToApply.GetComponent<SpriteRenderer>().color =
            new Color(
                ToApply.GetComponent<SpriteRenderer>().color.r,
                ToApply.GetComponent<SpriteRenderer>().color.g,
                ToApply.GetComponent<SpriteRenderer>().color.b,
                DisableAlpha);
        Enable = false;
        lastEnable = false;
    }


}

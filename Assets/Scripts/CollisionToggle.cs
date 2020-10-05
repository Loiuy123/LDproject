using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToggle : MonoBehaviour
{

    public float DisableAlpha;
    public GameObject ToApply;

    public Material On;
    public Material Off;

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
        if (ToApply.GetComponent<SpriteRenderer>() != null)
        {
            ToApply.GetComponent<SpriteRenderer>().color =
            new Color(
                ToApply.GetComponent<SpriteRenderer>().color.r,
                ToApply.GetComponent<SpriteRenderer>().color.g,
                ToApply.GetComponent<SpriteRenderer>().color.b,
                1);
        }
        if (ToApply.GetComponent<MeshRenderer>() != null)
        {
            ToApply.GetComponent<MeshRenderer>().material = On;
        }
        
        Enable = true;
        lastEnable = true;
    }

    public void DisableWall()
    {
        ToApply.layer = 14;
        if (ToApply.GetComponent<SpriteRenderer>() != null)
        {
            ToApply.GetComponent<SpriteRenderer>().color =
            new Color(
                ToApply.GetComponent<SpriteRenderer>().color.r,
                ToApply.GetComponent<SpriteRenderer>().color.g,
                ToApply.GetComponent<SpriteRenderer>().color.b,
                DisableAlpha);
        }
        if (ToApply.GetComponent<MeshRenderer>() != null)
        {
            ToApply.GetComponent<MeshRenderer>().material = Off;
        }
        
        Enable = false;
        lastEnable = false;
    }


}

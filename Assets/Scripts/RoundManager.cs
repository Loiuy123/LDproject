using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Current;



    private void Start()
    {
        Current = this;
    }



}

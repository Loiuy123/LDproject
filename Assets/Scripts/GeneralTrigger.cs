using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneralTrigger : MonoBehaviour
{

    public UnityEvent OnPlayerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerEnter.Invoke();
    }
}

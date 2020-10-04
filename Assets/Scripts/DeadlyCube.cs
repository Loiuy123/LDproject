using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyCube : MonoBehaviour
{
    public GameObject deadEffect;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MovementController>().Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{

    Rigidbody2D body;

    public float FrontForce;
    public float RotationForce;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {




        
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown( KeyCode.W)|| Input.GetKey(KeyCode.W))
        {
            body.AddForce(transform.up * FrontForce, ForceMode2D.Force);
        }

        if (Input.GetKeyDown( KeyCode.A)||Input.GetKey(KeyCode.A))
        {
            body.AddTorque(RotationForce);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            body.AddTorque(-RotationForce);
        }

    }




}

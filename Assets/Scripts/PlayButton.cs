using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    Vector3 scale = new Vector3();

    private void Start()
    {
        scale = transform.localScale;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x * 1.3f, transform.localScale.y * 1.3f, transform.localScale.z);
    }


    private void OnMouseExit()
    {
        transform.localScale = scale;
    }
}

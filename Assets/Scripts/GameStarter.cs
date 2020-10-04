using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public Color red;
    public Color yellow;
    public Color green;

    public SpriteRenderer sprite;
    public GameObject player;

    public void Start()
    {
        StartCoroutine(ChangeColors());
    }

    public IEnumerator ChangeColors()
    {
        yield return new WaitForSeconds(.3f);
        sprite.color = red;
        yield return new WaitForSeconds(1.5f);
        sprite.color = yellow;
        yield return new WaitForSeconds(1.5f);
        sprite.color = green;
        player.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
        yield return null;
    }
}

using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBomb : MonoBehaviour
{
    public GameObject explosionParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CameraShaker.Instance.ShakeOnce(1, 1, .1f, .6f);
            collision.gameObject.GetComponent<MovementController>().StartCoroutine(collision.gameObject.GetComponent<MovementController>().SpeedBoost());
            GameObject explosion = Instantiate(explosionParticle.gameObject, transform.position, Quaternion.identity);
            SoundManager.soundManager.PlaySound(SoundManager.soundManager.speedBomb);
            Destroy(explosion, 5);
            Destroy(gameObject);
        }
    }
}

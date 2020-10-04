using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{

    Rigidbody2D body;

    public float FrontForce;
    public float RotationForce;

    public ParticleSystem particleSystemA;
    public ParticleSystem particleSystemB;

    public GameObject deadEffect;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            particleSystemA.Stop();
            particleSystemB.Stop();
        }
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown( KeyCode.W)|| Input.GetKey(KeyCode.W))
        {
            body.AddForce(transform.up * FrontForce, ForceMode2D.Force);
            particleSystemA.Play();
            particleSystemB.Play();
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

    public IEnumerator SpeedBoost()
    {
        FrontForce *= 2.5f;
        yield return new WaitForSeconds(2f);
        FrontForce /= 2.5f;
        yield return null;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.soundManager.PlaySound(SoundManager.soundManager.hit);
    }

    public void Die()
    {
        SoundManager.soundManager.PlaySound(SoundManager.soundManager.death);
        GameObject effect = Instantiate(deadEffect.gameObject, transform.position, Quaternion.identity);
        Destroy(effect.gameObject, 5f);
        
        RoundManager.Current.StartCoroutine(WaitDeath());
    }
    public IEnumerator WaitDeath()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}

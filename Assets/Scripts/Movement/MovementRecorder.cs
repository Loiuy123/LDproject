using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRecorder : MonoBehaviour
{
    public MovementData CurrentData;

    public float T;

    public GameObject Prefab;

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        T = 0;
        CurrentData = new MovementData();
        KeyFrame();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var copy = Instantiate(Prefab);
            copy.GetComponent<MovementPlayback>().Data = CurrentData;
            Reset();
        }
    }


    private void FixedUpdate()
    {
        T += Time.fixedDeltaTime;
        KeyFrame();
    }

    private void KeyFrame()
    {
        MovementData.MovementFrame frame = new MovementData.MovementFrame(T, transform.position, transform.rotation);

        CurrentData.AddData(frame);
    }
}

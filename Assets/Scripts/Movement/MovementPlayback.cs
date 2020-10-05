using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayback : MonoBehaviour
{
    public MovementData Data;
    public float replayTime;

    public int lastIndex = 0;

    public bool Loop = false;
    Rigidbody2D body;

    public static float SpeedUp = 1;

    public int ID = 0;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public int GetMaxIndex(float time)
    {
        for (int i = lastIndex; i < Data.Data.Count; i++)
        {
            if (time<Data[i].Time)
            {
                return i;
            }
        }
        return -1;
    }

    public float CalculateSpeedFactor()
    {
        return (1 + (1 -((float)ID / RoundManager.lastId)))* SpeedUp;
    }

    void Update()
    {
        if (Data != null)
        {
            replayTime += Time.deltaTime*RoundManager.Current.ReplaySpeed;

            int nextIndex = GetMaxIndex(replayTime);

            if (nextIndex!= -1)
            {
                var curr = Data[lastIndex];
                var next = Data[nextIndex];

                var pos = Vector2.Lerp(curr.Position, next.Position, (replayTime - curr.Time) / (next.Time - curr.Time));
                var rot = Quaternion.Lerp(curr.Rotation, next.Rotation, (replayTime - curr.Time) / (next.Time - curr.Time));

                lastIndex = nextIndex - 1;
                ApplyPosition(pos, rot);
            }
            else
            {
                // move to the last one
                var pos = Data[Data.Data.Count - 1];
                ApplyPosition(pos.Position, pos.Rotation);
                if (Loop)
                {
                    replayTime = 0;
                    lastIndex = 0;
                }
                else
                {
                    Destroy(gameObject);
                }
                
            }            
        }        
    }
    public void ApplyPosition(Vector2 pos, Quaternion rotation)
    {
        body.MovePosition(pos);
        body.MoveRotation(rotation);
    }
}

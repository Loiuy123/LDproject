using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayback : MonoBehaviour
{
    public MovementData Data;
    public float replayTime;

    public int lastIndex = 0;

    public bool Loop = false;

    public int GetMaxIndex(float time)
    {
        for (int i = 0; i < Data.Data.Count; i++)
        {
            if (time<Data[i].Time)
            {
                return i;
            }
        }
        return -1;
    }

    void Update()
    {
        if (Data != null)
        {
            replayTime += Time.deltaTime;

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
        transform.position = pos;
        transform.rotation = rotation;
    }
}

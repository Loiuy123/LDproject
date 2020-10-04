using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementData 
{
    public struct MovementFrame
    {
        public float Time;
        public Vector2 Position;
        public Quaternion Rotation;

        public MovementFrame(float time, Vector2 position, Quaternion rotation)
        {
            Time = time;
            Position = position;
            Rotation = rotation;
        }
    }


    public List<MovementFrame> Data;

    public MovementFrame this[int index]
    {
        get { return Data[index]; }
    }

    public MovementData()
    {
        Data = new List<MovementFrame>();
    }

    public void AddData(MovementFrame frame)
    {
        if (Data.Count>0 && Data[Data.Count-1].Time>frame.Time)
        {
            return;
        }
        Data.Add(frame);
    }

    





}

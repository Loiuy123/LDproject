using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingCubes : MonoBehaviour
{
    // "Bobbing" animation from 1D Perlin noise.

    // Range over which height varies.
    float heightScale = 1.0f;

    // Distance covered per second along X axis of Perlin plane.
    float xScale = 1.0f;


    void Update()
    {
        float height = heightScale * Mathf.PerlinNoise(Time.time * xScale * 2, Time.time * xScale * 2);
        Vector3 pos = transform.localScale;
        pos.z = height;
        transform.localScale = pos;
    }
}

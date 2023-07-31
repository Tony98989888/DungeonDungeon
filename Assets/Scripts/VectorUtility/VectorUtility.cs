using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtility
{
    public static void Truncate(ref Vector3 vector, float max) 
    {
        float length = vector.magnitude;
        float i = max / length;

        i = Mathf.Clamp01(i);
        vector *= i;
    }
}

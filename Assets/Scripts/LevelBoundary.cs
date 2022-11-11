using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftside = 10.2f;
    public static float rightside = 23.5f;
    public float internalLeft;
    public float internalRight;
    void Update()
    {
        internalLeft = leftside;
        internalRight = rightside;
    }
}

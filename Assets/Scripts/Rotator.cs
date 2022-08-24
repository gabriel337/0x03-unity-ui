using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotator class for coins
/// </summary>
public class Rotator : MonoBehaviour
{
    public float degreesPerSecond = 45f;
    
    /// <summary>
    /// rotates coins in Maze Game
    /// </summary>
    void Update()
    {
        transform.Rotate(degreesPerSecond * Time.deltaTime, 0, 0);
    }
}

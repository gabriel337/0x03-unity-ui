using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for camera movement align with player
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; 
    /// <summary>
    /// get the player position
    /// </summary>
    void Start()
    {
         offset = transform.position - player.transform.position;
    }
    /// <summary>
    /// updates the camera postion while player is moving
    /// </summary>
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

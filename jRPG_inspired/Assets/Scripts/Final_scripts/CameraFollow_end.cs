using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_end : MonoBehaviour
{
    [SerializeField]
    private Transform followThisGameObject;  //Set this object to whatever you want the camera to follow but it will usually be the player.

    [SerializeField]
    private Vector3 offset = new Vector3(0f, 0f, -10f); //set z default so that it isn't at the same level as the scene

    // Update is called once per frame
    void FixedUpdate()
    {
        // Set camera to position of player with variable offset
        transform.position = new Vector3(followThisGameObject.position.x + offset.x, followThisGameObject.position.y + offset.y, offset.z);
    }
}

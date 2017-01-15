using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    Vector3 offset; //distance joueur/camera

    void Start()
    {
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        Vector3 CameraNewPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, CameraNewPos, 10f * Time.deltaTime); 
        // creer le mouvement avec un leger effet "smooth" a la camera
    }
}

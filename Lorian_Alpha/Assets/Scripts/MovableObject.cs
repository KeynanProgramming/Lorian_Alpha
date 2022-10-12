using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private Rigidbody2D objectRB;
    Vector2 objectMovement;
    void Start()
    {
        objectRB = GetComponent<Rigidbody2D>(); 
    }
    void FixedUpdate()
    {
        objectRB.MovePosition(objectRB.position + objectMovement);
    }
}

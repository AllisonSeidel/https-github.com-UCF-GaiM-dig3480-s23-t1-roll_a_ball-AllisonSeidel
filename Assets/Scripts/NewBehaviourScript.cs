using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;

    // The target (cylinder) position.
    private Transform target;


    void Awake()
    {
        // Position the cube at the origin.
        transform.position = new Vector3(9.0f, 0.5f, -4.0f);

        // Create and position the cylinder. Reduce the size.
        var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);

        // Grab cylinder values and place on the target.
        target = cylinder.transform;
        target.transform.position = new Vector3(-9.0f, 0.5f, -4.51f);
    }

    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            target.position *=  -1.0f;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    protected float NewOrientation (float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
            return Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
        else
        {
            return current;
        }
    }

    protected virtual KinematicSteeringOutput GetSteering() { return new KinematicSteeringOutput(); }
}

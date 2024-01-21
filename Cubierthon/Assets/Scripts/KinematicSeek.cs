using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MovementBehaviour
{
    [SerializeField] private float m_maxSpeed = 1f;
    private Rigidbody m_rb;
    private PlayerMovement m_playerMovement;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        m_rb.velocity = GetSteering().velocity;
    }

    protected override KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = m_playerMovement.transform.position - m_rb.transform.position;

        result.velocity.Normalize();
        result.velocity *= m_maxSpeed;

        float orientation = NewOrientation(m_rb.rotation.eulerAngles.y, result.velocity);
        Vector3 targetRot = m_rb.rotation.eulerAngles;
        targetRot.y = orientation;
        m_rb.rotation = Quaternion.Euler(targetRot);

        result.rotation = 0;
        return result;
    }
}
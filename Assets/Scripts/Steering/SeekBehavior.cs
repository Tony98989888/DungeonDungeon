using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehavior : MonoBehaviour
{
    Vector3 m_currentVelocity;
    Vector3 m_desiredVelocity;
    Vector3 m_steeringVelocity;

    float m_maxVelocity = 5.0f;
    float m_maxForce = 0.5f;

    [SerializeField]
    Rigidbody m_rb;

    [SerializeField]
    GameObject m_target;

    void UpdateSteeringState() 
    {
        m_desiredVelocity = (m_target.transform.position - transform.position).normalized;
        m_desiredVelocity *= m_maxVelocity;

        m_steeringVelocity = m_desiredVelocity - m_currentVelocity;
        m_steeringVelocity = Vector3.ClampMagnitude(m_steeringVelocity, m_maxForce);
        m_steeringVelocity /= m_rb.mass;

        m_currentVelocity += m_steeringVelocity;
        m_currentVelocity = Vector3.ClampMagnitude(m_currentVelocity, m_maxVelocity);

        transform.position += m_currentVelocity * Time.deltaTime;
    }

    void Update()
    {
        UpdateSteeringState();
    }
}

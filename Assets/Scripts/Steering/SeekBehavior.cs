using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehavior : MonoBehaviour
{
    Vector3 m_currentVelocity;
    Vector3 m_desiredVelocity;
    Vector3 m_steeringVelocity;

    [SerializeField]
    float m_maxVelocity;
    [SerializeField]
    float m_maxSteeringVelocity;

    [SerializeField]
    Rigidbody m_rb;

    [SerializeField]
    GameObject m_target;

    [SerializeField]
    float m_senseRange;

    [SerializeField]
    float m_turnSpeed;

    void UpdateSteeringState()
    {
        float distance = Vector3.Magnitude(m_target.transform.position - transform.position);
        m_desiredVelocity = (m_target.transform.position - transform.position).normalized;

        if (distance > m_senseRange)
        {
            m_desiredVelocity *= m_maxVelocity;
        }
        else if (distance < 2)
        {
            m_rb.velocity = Vector3.zero;
        }
        else
        {
            m_desiredVelocity = (distance / m_senseRange) * m_maxVelocity * m_desiredVelocity;
        }

        Debug.Log(distance);

        m_steeringVelocity = m_desiredVelocity - m_currentVelocity;
        m_steeringVelocity = Vector3.ClampMagnitude(m_steeringVelocity, m_maxSteeringVelocity);
        m_steeringVelocity /= m_rb.mass;

        m_currentVelocity += m_steeringVelocity;
        m_currentVelocity = Vector3.ClampMagnitude(m_currentVelocity, m_maxVelocity);

        transform.position += m_currentVelocity * Time.deltaTime;

        // Update rotation
        if (m_currentVelocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(m_currentVelocity, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * m_turnSpeed);
        }
    }

    void Update()
    {
        UpdateSteeringState();
    }
}

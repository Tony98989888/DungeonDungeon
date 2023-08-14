using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehaviour : MonoBehaviour
{
    public Rigidbody m_target;
    
    [SerializeField]
    float m_steerMaxSpeed;

    [SerializeField]
    float m_maxSpeed;

    [SerializeField]
    Rigidbody m_rb;

    Vector3 m_currentVelocity;

    Vector3 GetPredictTarget() 
    {
        var distance = Vector3.Distance(transform.position, m_target.position);
        var t = distance / m_maxSpeed;
        var predictPos = m_target.velocity * t + m_target.position;
        return predictPos;
    }

    void Pursuit() 
    {
        var targetPos = GetPredictTarget();
        var desiredVelocity = targetPos - transform.position;
        var steerVelocity = desiredVelocity - m_currentVelocity;
        steerVelocity = Vector3.ClampMagnitude(steerVelocity, m_steerMaxSpeed);
        steerVelocity /= m_rb.mass;

        m_currentVelocity += steerVelocity;
        m_currentVelocity = Vector3.ClampMagnitude(m_currentVelocity, m_maxSpeed);
        transform.position += m_currentVelocity * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingBehaviour : MonoBehaviour
{
    [SerializeField]
    Rigidbody m_rb;

    [SerializeField]
    float m_circleDistance;

    [SerializeField]
    float m_maxSteerSpeed;

    [SerializeField]
    float m_turnSpeed;

    [SerializeField]
    float m_maxVelocity;

    Vector3 m_currentVelocity;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Wandering point vector
        var moveVec = transform.forward * m_circleDistance;

        // Displacement
        var displacement = Random.insideUnitSphere * m_circleDistance;
        displacement.y = transform.position.y;

        // Wander velocity
        var wanderVelocity = moveVec + displacement;

        /*
            steering = wander()
            steering = truncate (steering, max_force)
            steering = steering / mass
            velocity = truncate (velocity + steering , max_speed)
            position = position + velocity
         */

        wanderVelocity = Vector3.ClampMagnitude(wanderVelocity, m_maxSteerSpeed);
        wanderVelocity /= m_rb.mass;

        m_currentVelocity += wanderVelocity;
        m_currentVelocity = Vector3.ClampMagnitude(m_currentVelocity, m_maxVelocity);

        transform.position += m_currentVelocity * Time.deltaTime;

        // Update rotation
        //if (m_currentVelocity != Vector3.zero)
        //{
        //    Quaternion targetRotation = Quaternion.LookRotation(m_currentVelocity, transform.up);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * m_turnSpeed);
        //}
    }
}

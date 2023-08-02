using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WanderingBehaviour : MonoBehaviour
{
    [SerializeField]
    Rigidbody m_rb;

    [SerializeField]
    float m_circleDistance;

    [SerializeField]
    float m_circleRadius;

    [SerializeField]
    float m_maxSteerSpeed;

    [SerializeField]
    float m_maxVelocity;

    Vector3 m_steerVelocity;
    Vector3 m_currentVelocity;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        StartCoroutine(GenerateRandomSteerVec());
    }

    public Vector3 RandomSteerVec()
    {
        var circleCenterVector = m_rb.velocity.normalized * m_circleDistance;
        var displacementVector = Random.insideUnitSphere.normalized * m_circleRadius;
        return (circleCenterVector + displacementVector).WithY(transform.position.y);
    }

    IEnumerator GenerateRandomSteerVec() 
    {
        while (true) 
        {
            m_steerVelocity = RandomSteerVec();
            yield return new WaitForSeconds(3);
        }
    }

    private void Update()
    {
        var steerVec = m_steerVelocity;

        Debug.DrawRay(transform.position, steerVec, Color.yellow);

        steerVec = Vector3.ClampMagnitude(steerVec, m_maxSteerSpeed);
        steerVec /= m_rb.mass;

        Debug.DrawRay(transform.position, m_currentVelocity, Color.white);

        m_currentVelocity += steerVec * Time.deltaTime;
        m_currentVelocity = Vector3.ClampMagnitude(m_currentVelocity, m_maxVelocity);

        Debug.DrawRay(transform.position, m_currentVelocity, Color.green);

        transform.position += m_currentVelocity * Time.deltaTime;
    }
}

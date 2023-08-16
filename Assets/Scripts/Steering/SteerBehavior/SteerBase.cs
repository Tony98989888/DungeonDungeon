using UnityEngine;

namespace Steer
{
    public abstract class SteerBase : MonoBehaviour
    {
        [SerializeField]
        float m_maxSpeed;

        [SerializeField]
        protected float m_maxSteerForce;

        [SerializeField]
        protected Transform m_target;

        [SerializeField]
        float m_slowRadius;

        [SerializeField]
        float m_stopRadius;

        [SerializeField, Range(0,1)]
        float m_slowSpeedFactor;

        protected Rigidbody m_rb;

        protected float m_distance;

        protected virtual void Start() 
        {
            m_rb = GetComponent<Rigidbody>();
        }

        protected abstract Vector3 CalculateSteering();

        protected virtual void Update() 
        {
            m_distance = Vector3.Distance(transform.position, m_target.transform.position);
        }

        protected virtual void FixedUpdate() 
        {
            Vector3 steering = CalculateSteering();
            steering = Vector3.ClampMagnitude(steering, m_maxSteerForce);
            m_rb.AddForce(steering, ForceMode.Acceleration);

            if (m_distance < m_stopRadius)
            {
                m_rb.velocity = Vector3.zero;
            }
            else if (m_distance < m_slowRadius) 
            {
                m_rb.velocity *= m_slowSpeedFactor;
            }
        }
    }
}


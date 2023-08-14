using UnityEngine;

namespace SteerLogic 
{
    public class SteerBehaviourBase : MonoBehaviour
    {
        [SerializeField]
        float m_maxMoveSpeed;
        [SerializeField]
        float m_maxSteerSpeed;
        [SerializeField]
        GameObject m_pursuitTarget;
        [SerializeField]
        Rigidbody m_rigidBody;

        Vector3 m_currentVelocity;
        Vector3 m_desiredVelocity;

        protected Vector3 DesiredVelocity => (m_pursuitTarget.transform.position - transform.position).normalized;
    }
}


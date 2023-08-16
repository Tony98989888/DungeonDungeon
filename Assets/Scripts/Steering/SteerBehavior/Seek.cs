using UnityEngine;

namespace Steer 
{
    public class Seek : SteerBase
    {
        protected override Vector3 CalculateSteering()
        {
            var desiredVelocity = m_target.transform.position - transform.position;
            var steerForce = desiredVelocity - m_rb.velocity;
            steerForce /= m_rb.mass;
            steerForce = Vector3.ClampMagnitude(steerForce, m_maxSteerForce);
            return steerForce;
        }
    }
}


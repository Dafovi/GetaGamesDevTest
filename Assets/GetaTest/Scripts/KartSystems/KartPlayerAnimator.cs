using UnityEngine;
using UnityEngine.Assertions;

namespace KartGame.KartSystems 
{
    public class KartPlayerAnimator : MonoBehaviour
    {
        public Animator PlayerAnimator;
        public KartController Kart;
        
        [Space(10)]
        public string SteeringParam = "Steering";
        public string GroundedParam = "Grounded";

        int m_SteerHash, m_GroundHash;

        float steeringSmoother;

        void Awake()
        {
            Assert.IsNotNull(Kart, "No ArcadeKart found!");
            Assert.IsNotNull(PlayerAnimator, "No PlayerAnimator found!");
            m_SteerHash  = Animator.StringToHash(SteeringParam);
            m_GroundHash = Animator.StringToHash(GroundedParam);
        }

        void Update()
        {
            steeringSmoother = Mathf.Lerp(steeringSmoother, Kart.Input.horizontalInput, Time.deltaTime * 5f);
            PlayerAnimator.SetFloat(m_SteerHash, steeringSmoother);

            // If more than 2 wheels are above the ground then we consider that the kart is airbourne.
            PlayerAnimator.SetBool(m_GroundHash, Kart.isKarGrounded);
        }
    }
}

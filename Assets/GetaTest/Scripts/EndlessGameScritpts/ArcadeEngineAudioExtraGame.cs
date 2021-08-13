using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using System;

namespace KartGame.KartSystems
{
    /// <summary>
    /// This class produces audio for various states of the vehicle's movement.
    /// </summary>
    public class ArcadeEngineAudioExtraGame : MonoBehaviour
    {
        [Tooltip("What audio clip should play when the kart starts?")]
        public AudioSource StartSound;
        [Tooltip("What audio clip should play when the kart does nothing?")]
        public AudioSource IdleSound;
        [Tooltip("What audio clip should play when the kart moves around?")]
        public AudioSource RunningSound;
        [Tooltip("Maximum Volume the running sound will be at full speed")]
        [Range(0.1f, 1.0f)]public float RunningSoundMaxVolume = 1.0f;
        [Tooltip("Maximum Pitch the running sound will be at full speed")]
        [Range(0.1f, 2.0f)] public float RunningSoundMaxPitch = 1.0f;
        [Tooltip("Maximum Volume the Reverse sound will be at full Reverse speed")]

        PlayerController kartController;
        public float aceleration;
        public Animator kart;

        void Awake()
        {
            kartController = GetComponentInParent<PlayerController>();
            aceleration=kartController.forwardSpeed;
            kart.enabled=true;
        }

        void Update()
        {
            float kartSpeed = 0.0f;
            if (kartController.isDrivable)
                kartSpeed = 1;
            else kartSpeed=0; 

            IdleSound.volume    = Mathf.Lerp(0.6f, 0.0f, kartSpeed * 4);

            RunningSound.volume = Mathf.Lerp(0.1f, RunningSoundMaxVolume, kartSpeed * 1.2f);
            RunningSound.pitch = Mathf.Lerp(0.3f, RunningSoundMaxPitch, kartSpeed + (Mathf.Sin(Time.time) * .1f));

            
        }
    }
}

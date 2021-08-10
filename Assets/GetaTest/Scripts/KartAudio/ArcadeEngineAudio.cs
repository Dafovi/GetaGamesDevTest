using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using System;

namespace KartGame.KartSystems
{
    /// <summary>
    /// This class produces audio for various states of the vehicle's movement.
    /// </summary>
    public class ArcadeEngineAudio : MonoBehaviour
    {
        [Tooltip("What audio clip should play when the kart starts?")]
        public AudioSource StartSound;
        [Tooltip("What audio clip should play when the kart does nothing?")]
        public AudioSource IdleSound;
        [Tooltip("What audio clip should play when the kart moves around?")]
        public AudioSource RunningSound;
        [Tooltip("What audio clip should play when the kart is drifting")]
        public AudioSource Drift;
        [Tooltip("Maximum Volume the running sound will be at full speed")]
        [Range(0.1f, 1.0f)]public float RunningSoundMaxVolume = 1.0f;
        [Tooltip("Maximum Pitch the running sound will be at full speed")]
        [Range(0.1f, 2.0f)] public float RunningSoundMaxPitch = 1.0f;
        [Tooltip("What audio clip should play when the kart moves in Reverse?")]
        public AudioSource ReverseSound;
        [Tooltip("Maximum Volume the Reverse sound will be at full Reverse speed")]
        [Range(0.1f, 1.0f)] public float ReverseSoundMaxVolume = 0.5f;
        [Tooltip("Maximum Pitch the Reverse sound will be at full Reverse speed")]
        [Range(0.1f, 2.0f)] public float ReverseSoundMaxPitch = 0.6f;

        KartController kartController;
        public float aceleration;

        void Awake()
        {
            kartController = GetComponentInParent<KartController>();
            aceleration=kartController.aceleration;
        }

        void Update()
        {
            float kartSpeed = 0.0f;
            if (kartController != null)
            {
                kartSpeed = kartController.Input.verticalInput;
                if(kartController.isKarGrounded)
                Drift.volume=Convert.ToInt16(kartController.Input.isDrifting);
            }

            IdleSound.volume    = Mathf.Lerp(0.6f, 0.0f, kartSpeed * 4);

            if (kartSpeed < 0.0f)
            {
                // In reverse
                RunningSound.volume = 0.0f;
                ReverseSound.volume = Mathf.Lerp(0.1f, ReverseSoundMaxVolume, -kartSpeed * 1.2f);
                ReverseSound.pitch = Mathf.Lerp(0.1f, ReverseSoundMaxPitch, -kartSpeed + (Mathf.Sin(Time.time) * .1f));
            }
            else
            {
                // Moving forward
                float engine;
                
                if(aceleration<kartController.speed && kartController.isKarGrounded) engine=0.2f;
                else if(!kartController.isKarGrounded) engine=0.6f;
                else engine = 0f;

                ReverseSound.volume = 0.0f;
                RunningSound.volume = Mathf.Lerp(0.1f, RunningSoundMaxVolume, kartSpeed * 1.2f);
                RunningSound.pitch = Mathf.Lerp(0.3f, RunningSoundMaxPitch+engine, kartSpeed + (Mathf.Sin(Time.time) * .1f));
            }

            
        }
    }
}

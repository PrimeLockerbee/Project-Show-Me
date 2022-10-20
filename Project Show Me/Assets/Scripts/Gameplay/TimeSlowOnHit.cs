using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{

    public class TimeSlowOnHit : MonoBehaviour
    {
        // Timescale to slow down to if slow down key is pressed
        [Tooltip("Timescale to slow down to if slow down key is pressed")]
        public float SlowTimeScale = 0.5f;

        [Tooltip("(Optional) Play this clip when starting to slow time")]
        public AudioClip SlowTimeClip;

        [Tooltip("(Optional) Play this clip when ending slow mo")]
        public AudioClip SpeedupTimeClip;

        public bool canSlowTime = true;

        float originalFixedDelta;

        public AudioSource audioSource;

        public bool ForceTimeScale = false;

        void Start()
        {
            originalFixedDelta = Time.fixedDeltaTime;
        }

        public void SlowTime()
        {
            // Play Slow time clip
            audioSource.clip = SlowTimeClip;
            audioSource.Play();

            Time.timeScale = SlowTimeScale;
            Time.fixedDeltaTime = originalFixedDelta * Time.timeScale;

            StartCoroutine(resumeTimeRoutine());
        }

        public IEnumerator resumeTimeRoutine()
        {
            // Wait for a second before resuming time again
            yield return new WaitForSeconds(3f);

            audioSource.clip = SpeedupTimeClip;
            audioSource.Play();

            Time.timeScale = 1;
            Time.fixedDeltaTime = originalFixedDelta;

            canSlowTime = true;
        }
    }
}
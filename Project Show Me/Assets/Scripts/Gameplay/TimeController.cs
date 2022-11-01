using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Timescale to slow down to if slow down key is pressed
    [Tooltip("Timescale to slow down to if slow down key is pressed")]
    public float SlowTimeScale = 0.5f;

    [Tooltip("(Optional) Play this clip when starting to slow time")]
    public AudioClip SlowTimeClip;

    [Tooltip("(Optional) Play this clip when ending slow mo")]
    public AudioClip SpeedupTimeClip;

    public bool canSlowTime = true;

    public float originalFixedDelta;

    public AudioSource audioSource;

    public bool ForceTimeScale = false;

    public bool timeSLowCooldownBool = false;

    public float timeSlowCooldown;

    void Start()
    {
        originalFixedDelta = Time.fixedDeltaTime;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.O) && canSlowTime == true && timeSLowCooldownBool == false)
        {
            SlowTime();
            canSlowTime = false;
            StartCoroutine(resumeTimeRoutine());
            timeSlowCooldown = 17f;
            timeSLowCooldownBool = true;
        }

        if(timeSLowCooldownBool == true)
        {
            timeSlowCooldown -= Time.deltaTime;
            if(timeSlowCooldown <=0)
            {
                timeSLowCooldownBool = false;
                timeSlowCooldown = 0;
            }
        }

        //Debug.Log(timeSlowCooldown);
        //Debug.Log(canSlowTime);
        //Debug.Log(timeSLowCooldownBool);
    }


    public void SlowTime()
    {
        // Play Slow time clip
        audioSource.clip = SlowTimeClip;
        audioSource.Play();

        Time.timeScale = SlowTimeScale;
        Time.fixedDeltaTime = originalFixedDelta * Time.timeScale;     
    }

    public IEnumerator resumeTimeRoutine()
    {
        // Wait for a split second before resuming time again
        yield return new WaitForSeconds(5f);

        audioSource.clip = SpeedupTimeClip;
        audioSource.Play();

        Time.timeScale = 1;
        Time.fixedDeltaTime = originalFixedDelta;

        canSlowTime = true;

    }
}

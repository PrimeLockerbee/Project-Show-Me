using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class TimeControllerUI : MonoBehaviour
{
    [SerializeField]
    Text cooldowntimetext;

    [SerializeField]
    TimeController m_PlayerTime;

    void Update()
    {
        if(m_PlayerTime.timeSlowCooldown <= 10)
        {
            // update time bar value
            cooldowntimetext.text = m_PlayerTime.timeSlowCooldown.ToString();
        }

    }
}

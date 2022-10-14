using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    [SerializeField] GameObject go_Player;

    public Transform t_target;

    public int i_gotHitFront;
    public int i_gotHitBack;
    public float i_timePlayed;
    public int i_Score;

    public PlayerData(int gothitfront, int gothitback, float timeplayed, int score)
    {
        i_gotHitFront = gothitfront;
        i_gotHitBack = gothitback;
        i_timePlayed = timeplayed;

    }

    void Start()
    {
        go_Player = this.gameObject;
        i_gotHitFront = 0;
        i_gotHitBack = 0;
        i_timePlayed = 0;
        i_Score = 0;
    }


    void Update()
    {
        i_timePlayed += Time.deltaTime;

        Debug.Log("front hit: " + i_gotHitFront);
        Debug.Log("back hit: " + i_gotHitBack);
    }

    private void OnTriggerEnter(Collider other)
    {
        t_target = other.gameObject.transform;
        Vector3 toTarget = (t_target.position - go_Player.transform.position);

        if (Vector3.Dot(toTarget, transform.forward) > 0 && other.tag == "EnemyBullet")
        {
            Debug.Log("Bullet hit the front of the player.");
            i_gotHitFront++;
        }

        if (Vector3.Dot(toTarget, transform.forward) < 0 && other.tag == "EnemyBullet")
        {
            Debug.Log("Bullet hit the back of the player.");
            i_gotHitBack++;
        }
    }

}

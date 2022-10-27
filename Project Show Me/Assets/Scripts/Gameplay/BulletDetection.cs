using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetection : MonoBehaviour
{
    [Header("Sphere Collider Settings")]
    public GameObject centerPosition;
    public float sphereRadius;
    public Vector3 centerPositionOffset;

    [Header("Closest Bullet Data")]
    public GameObject closestBullet;
    public float closestBulletDistance;

    private void Update()
    {
        Vector3 customPosition = centerPosition.transform.localPosition + centerPositionOffset;
        GetBulletsInRadius(customPosition, sphereRadius);
    }

    void GetBulletsInRadius(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        float distance = sphereRadius;
        closestBullet = null;
        foreach(var hitCollider in hitColliders)
        {
            if(hitCollider.tag == "EnemyBullet")
            {
                float tempDistance = Vector3.Distance(hitCollider.transform.position, center);
                if(tempDistance < distance)
                {
                    distance = tempDistance;
                    closestBullet = hitCollider.gameObject;
                }
            }
        }
        closestBulletDistance = distance;
    }
}

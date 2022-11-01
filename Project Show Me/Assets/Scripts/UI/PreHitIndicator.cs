using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreHitIndicator : MonoBehaviour
{
    [Header("Needed assets")]
    public BulletDetection bulletDetection;
    public Image[] preHitIndicationImages;

    private void Update()
    {
        Color c = preHitIndicationImages[0].color;
        c.a = map(bulletDetection.closestBulletDistance, 0, bulletDetection.sphereRadius, 1, 0);
        foreach(Image image in preHitIndicationImages)
        {
            image.color = c;
        }
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}

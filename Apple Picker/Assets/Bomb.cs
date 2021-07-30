using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        transform.Rotate(1f, 1f, 1f);
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}

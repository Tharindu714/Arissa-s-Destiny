using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthTracker : MonoBehaviour
{
    private int hitCount = 0;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void RegisterHit()
    {
        hitCount++;

        // Change color based on hit count
        if (hitCount == 2)
        {
            ChangeColor(Color.blue);
        }
        else if (hitCount == 5)
        {
            ChangeColor(Color.red);
        }
        else if (hitCount == 10)
        {
            ChangeColor(Color.black);
        }
        else if (hitCount == 12)
        {
            Destroy(gameObject);
        }
    }

    private void ChangeColor(Color color)
    {
        if (rend != null)
        {
            rend.material.color = color;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 5;
    private bool hasHit = false;
    public GameObject hitEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            hasHit = true;

            if (hitEffectPrefab != null)
            {
                GameObject effect = Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
                Destroy(effect, 2f);
            }

            // Notify enemy
            EnemyHealthTracker enemy = collision.gameObject.GetComponent<EnemyHealthTracker>();
            if (enemy != null)
            {
                enemy.RegisterHit();
            }

            // Change bullet color to red
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.red;
            }

            // Enable gravity
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = true;
                rb.isKinematic = false;
            }

            Destroy(gameObject, 5f);
        }
    }
}


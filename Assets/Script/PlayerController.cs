using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public GameObject GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       // Time.timeScale = 5;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Run", false);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed;
            animator.SetBool("Run", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed;
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed;
            
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
            animator.SetTrigger("Jump");
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided With " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Enemy"))
        {
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
                GameOverText.gameObject.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float walkspeed = 2f;
    public Animator animator;
    public GameObject lost;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * walkspeed;
            animator.SetTrigger("Left");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * walkspeed;
            animator.SetTrigger("Right");

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
                lost.gameObject.SetActive(true);
            }
        }
    }
}

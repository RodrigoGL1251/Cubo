using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    Rigidbody rb;
    Animator animator;
    public Transform transSquad;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }


    void Move()
    {
        Vector3 rotate = new Vector3(0f, 1f, 0f);

        if(Input.GetKey(KeyCode.W))
        {            
            animator.SetBool("walk", true);
            transSquad.rotation = Quaternion.AngleAxis(-90, rotate);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);            
        }
        else if(Input.GetKey(KeyCode.S))
        {            
            animator.SetBool("walk", true);
            transSquad.rotation = Quaternion.AngleAxis(90, rotate);
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walk", true);
            transSquad.rotation = Quaternion.AngleAxis(0, rotate);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walk", true);
            transSquad.rotation = Quaternion.AngleAxis(180, rotate);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) & !animator.GetBool("jump") )
        {
            animator.SetBool("jump", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            Debug.Log("Salto");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            animator.SetBool("jump", false);
        }
    }

}

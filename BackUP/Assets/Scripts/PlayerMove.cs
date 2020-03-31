using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if game is running
        if (MySceneManager.gameWon || MySceneManager.gameLost)
            moveSpeed = 0.0f;

            Movement();

    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0.0f, z);
        movement = transform.TransformDirection(movement);
        movement.Normalize();
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] float moveSpeed;

    [Header("Player Bools")]
    bool canMove = true;

    [Header("Player Components")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {
        if(canMove)
            Move();
    }

    void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.magnitude);
    }

}

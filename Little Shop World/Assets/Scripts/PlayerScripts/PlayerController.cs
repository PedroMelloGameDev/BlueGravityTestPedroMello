using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] float moveSpeed;
    //[SerializeField] float interactRange = 2;
    //[SerializeField] int playerHP = 40;
    //bool facingLeft = true;
    //bool facingDown = false;

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
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }*/
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
    /*void Interact()
    {

        /*RaycastHit2D hit;
        if (Physics2D.Raycast(transform.position, hit, interactRange))
        {

            IInteractable interaction = hit.transform.GetComponent<IInteractable>();
            if (interaction != null)
                interaction.Interact();
        }*/
        /*Vector2 worldPoint = this.gameObject.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, interactRange);
        if (hit.collider != null)
        {
            IInteractable interaction = hit.transform.GetComponent<IInteractable>();
            if (interaction != null)
                interaction.Interact();
        }
    }*/
}

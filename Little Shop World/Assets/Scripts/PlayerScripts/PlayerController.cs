using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Player Settings")]
    [SerializeField] float moveSpeed;

    [Header("Player Bools")]
    bool canMove = true;
    bool canAttack = true;

    [Header("Player Components")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] Rigidbody2D rb;

    [Header("Player Attack")]
    [SerializeField] float attackRange;
    [SerializeField] LayerMask hitLayers;

    [Header("Player Equip Spaces")]
    [SerializeField] public GameObject hatSpace;

    PlayerData pd;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        pd = PlayerData.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
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
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(canAttack)
            {
                playerAnimator.SetTrigger("Attack");
                StartCoroutine("CoolDown");

                Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, attackRange, hitLayers);
                foreach (Collider2D target in hit)
                {
                    target.GetComponent<IDamageable>().TakeDamage(1);
                }
            }
        }
    }
    IEnumerator CoolDown()
    {
        canAttack = false;
        canMove = false;
        yield return new WaitForSeconds(0.5f);
        canMove = true;
        canAttack = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

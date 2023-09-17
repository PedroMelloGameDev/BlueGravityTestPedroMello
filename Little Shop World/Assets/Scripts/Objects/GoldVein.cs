using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldVein : MonoBehaviour, IDamageable
{
    [SerializeField] int hp = 5;
    bool canTakeDamage = true;
    float damageCooldown = 0.4f;


    [SerializeField] GameObject goldCoin;

    // Update is called once per frame
    void Update()
    {
        damageCooldown += Time.deltaTime;
        if (damageCooldown >= 0.4f)
        {
            damageCooldown = 0.4f;
            canTakeDamage = true;
        }
    }

    public void TakeDamage(int damage)
    {
        if(canTakeDamage)
        {
            if(hp > 0)
            {
                hp -= damage;
                canTakeDamage = false;
                damageCooldown = 0;

                int randomCoins = Random.Range(0, 3); //instantiating a "random" number of coins per hit
                if (randomCoins == 0)
                {
                    GameObject coin1 = Instantiate(goldCoin, transform.position, Quaternion.identity);
                    coin1.GetComponent<Rigidbody2D>().AddForce(-transform.up * 6, ForceMode2D.Impulse);
                }
                else if (randomCoins == 1)
                {
                    GameObject coin1 = Instantiate(goldCoin, transform.position, Quaternion.identity);
                    coin1.GetComponent<Rigidbody2D>().AddForce(-transform.up * 6, ForceMode2D.Impulse);

                    GameObject coin2 = Instantiate(goldCoin, transform.position, Quaternion.identity);
                    coin2.GetComponent<Rigidbody2D>().AddForce(transform.up * 6, ForceMode2D.Impulse);
                }
                else if (randomCoins == 2)
                {
                    GameObject coin1 = Instantiate(goldCoin, transform.position, Quaternion.identity);
                    coin1.GetComponent<Rigidbody2D>().AddForce(-transform.up * 6, ForceMode2D.Impulse);

                    GameObject coin2 = Instantiate(goldCoin, transform.position, Quaternion.identity);
                    coin2.GetComponent<Rigidbody2D>().AddForce(transform.up * 6, ForceMode2D.Impulse);

                    GameObject coin3 = Instantiate(goldCoin, transform.position, Quaternion.identity);
                    coin3.GetComponent<Rigidbody2D>().AddForce(-transform.right * 6, ForceMode2D.Impulse);
                }
                
                if(hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

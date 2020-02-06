using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Slider healthBar;
    public int bossHealth;
    public GameObject objectToDisable;
    public GameObject player;

    private bool boss1Died;
    //public int bossDamage;

    private Lives playerLive;
    // Start is called before the first frame update
    void Start()
    {
        boss1Died = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = bossHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            bossHealth = bossHealth - 1;
            DeductHealth();
        }
    }

    public void DeductHealth()
    {
        if (bossHealth == 0)
        {
            boss1Died = true;
            //GameObject.FindGameObjectsWithTag("Player").transform.position = new Vector2(-4f, -0.7f);
            //player.transform.position = new Vector2(-4f, -0.7f);

            BossDead();
            teleportPlayer();
        }
    }

    void BossDead()
    {
        Destroy(objectToDisable);
        Destroy(gameObject);
    }

    void teleportPlayer()
    {
        player.transform.position = new Vector2(-4f, -0.7f);
    }
}

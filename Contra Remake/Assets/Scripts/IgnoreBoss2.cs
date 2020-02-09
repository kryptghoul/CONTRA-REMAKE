using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBoss2 : MonoBehaviour
{
    private BossController BossController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreLayerCollision(29, 30);
            //Physics2D.IgnoreCollision.CompareTag("Bullet");
        }

    }

    void ColliderEnable()
    {
        Physics2D.IgnoreLayerCollision(30, 31, false);
    }
}

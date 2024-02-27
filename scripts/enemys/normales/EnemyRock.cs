using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player damage");
            //Destroy(collision.gameObject);
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float wiatedTime;
    public float waitTimeToAtack = 3;
    public Animator animator;
    public GameObject bullerPrefab;
    public Transform lauchSpawnPoint;


    private void Start()
    {
        wiatedTime = waitTimeToAtack;
    }

    private void Update()
    {
        if (wiatedTime <= 0)
        {
            wiatedTime = waitTimeToAtack;
            animator.Play("atack");
            Invoke("LauchBullet", 0.5f);
        }
        else
        {
            wiatedTime -= Time.deltaTime;
        }
    }

    public void LauchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bullerPrefab, lauchSpawnPoint.position,lauchSpawnPoint.rotation);
    }
}

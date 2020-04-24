using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetPlayer : MonoBehaviour
{
    private GameObject PlayerCenterMass;
    private GameObject EnemyBulletSpawn;

    public Transform target;
    public Transform EnemyBulletSpawnTransform;

    public bool canSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCenterMass = GameObject.Find("CenterMass");

        EnemyBulletSpawn = GameObject.Find("Enemy Bullet Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerCenterMass.transform;
        transform.LookAt(target);

        //CheckRaycastHit();
    }


    /*
    private void CheckRaycastHit()
    {
        RaycastHit hit;

        //specify that it needs to hit the PLAYER'S collider
        if (Physics.Raycast(EnemyBulletSpawn.transform.position, EnemyBulletSpawn.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(EnemyBulletSpawn.transform.position, EnemyBulletSpawn.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

            canSeePlayer = ture;
        }
        else
        {
            Debug.DrawRay(EnemyBulletSpawn.transform.position, EnemyBulletSpawn.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
    */
}
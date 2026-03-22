using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Bullet;
    public float fireTime = 2.0f;
    public float fireTimer = 0f;
    public float playerDistance = 5.0f;
    public float rotSpeed = 2.0f;
    public float moveForce = 10.0f;
    public float maxForce = 15.0f;

    Transform player;
    public int curHp;
    public int score;
    //public EnemyType enemyType = EnemyType.SCOUT;
    Rigidbody rb;
    Transform BulletPos;
    public GameObject DebugActive;
    public int coin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
        BulletPos = this.transform.Find("BulletPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(this.transform.position, player.position);
       
        RotPlayer();
        if (distance > playerDistance)
        { 
            FollowPlayer();
        }
        else
        { 
            Stop();
            Fire();
        }
    }

    void FollowPlayer()
    {
        rb.AddForce(this.transform.forward * moveForce);
        if(rb.velocity.magnitude > maxForce)
        {
            rb.velocity = rb.velocity.normalized * maxForce;
        }
    }

    void Stop()
    {
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.1f);
    }

    void RotPlayer()
    {
        Vector3 dir = (player.position - this.transform.position).normalized;
        Quaternion targetRot = Quaternion.LookRotation(dir);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRot, rotSpeed * Time.deltaTime);
    }

    void ScoutShot()
    {
        GameObject bullet = Instantiate(Bullet, BulletPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().target = player;
    }

    void Fire()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireTime)
        {
            ScoutShot();
            fireTimer = 0;
        }
    }
}


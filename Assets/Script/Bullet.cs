using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 2.0f;
    public float addSpeed = 0;
    Vector3 dir;
    public float bulletDelDistance = 2.0f;
    public Transform player;
    public int damage = -1;
    public GameObject DebugActive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }

    void FixedUpdate()
    {
        //if (GameManager.instance.isBulletStop)
        //{
            //return;
        //}
        if (target != null)
        {
            dir = (target.position - this.transform.position).normalized;
        }
        transform.Translate(dir * (speed - addSpeed) * Time.deltaTime);
        addSpeed = 0;

        if(Vector3.Distance(this.transform.position, player.position) > bulletDelDistance)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = col.GetComponent<Enemy>();
            enemy.curHp += damage;
            if(enemy.curHp == 0)
            {
                Destroy(col.gameObject);
            }
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            Player player = col.GetComponent<Player>();
            if (!player.isReflect)
            {
                player.hp += damage;
                if (player.hp <= 0)
                {
                    player.hp = 0;
                }
                Destroy(this.gameObject);
            }
            else
            {
                //SetReflect();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

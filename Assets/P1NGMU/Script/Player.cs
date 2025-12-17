using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    public class Player : MonoBehaviour
    {
        
        public float bulletTime = 0.1f;
        
        public float reloadTime = 0f;
        Rigidbody thisRigi;
        
        public float speed = 2.0f;
        
        public GameObject objBullet;
        
        public Transform BulletPoint;
        public float hp;

        void Update()
        {
            Move();
            fireBullet();
        }

        void Start()
        {
            thisRigi = GetComponent<Rigidbody>();
        }

        public void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(moveX, 0.0f, moveZ);
            thisRigi.linearVelocity = move * speed;
            Vector3 poslnWorld = Camera.main.WorldToScreenPoint(this.transform.position);
            float posX = Mathf.Clamp(poslnWorld.x, 0, Screen.width);
            float posZ = Mathf.Clamp(poslnWorld.y, 0, Screen.height);
            Vector3 poslnScreen = Camera.main.ScreenToWorldPoint(new Vector3(posX, posZ, 0));
            thisRigi.position = new Vector3(poslnScreen.x, 0, poslnScreen.z);
        }

        void fireBullet()
        {
            reloadTime += Time.deltaTime;

            if(Input.GetButton("Fire1") && (bulletTime <= reloadTime))
            {
                reloadTime = 0f;
                GameObject bullet = Instantiate(objBullet, BulletPoint.position, this.transform.rotation);
                bullet.GetComponent<Bullet>().SetBullet(BulletPoint.position + Vector3.forward);
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                hp -= 1f;
                if (hp < 1.0f)
                {
                    Destroy(gameObject);
                }
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                hp -= 1f;
            }
            if (other.CompareTag("Item"))
            {
                switch (other.GetComponent<Item>().status)
                {
                    case ItemStatus.hp:
                        break;
                    case ItemStatus.upgrade:
                        break;
                    case ItemStatus.bomb:
                        break;
                }
                Destroy (other.gameObject);
                return;
            }
        }
    }
}
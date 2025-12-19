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
        GameManager gameManager;
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

            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
            if (gameManagerObject != null)
            {
                gameManager = gameManagerObject.GetComponent<GameManager>();
            }
            if (gameManager == null)
            {
                Debug.LogError("게임 매니저가 존재하지 않습니다.");
            }
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

            if (Input.GetButton("Fire1") && (bulletTime <= reloadTime))
            {
                reloadTime = 0f;
                GameObject bullet = Instantiate(objBullet, BulletPoint.position, this.transform.rotation);
                bullet.GetComponent<Bullet>().SetBullet(BulletPoint.position + Vector3.forward);
            }
            if (Input.GetButton("Fire2") && (GameDataManager.Instance.bombTime <= GameDataManager.Instance.bombing))
            {
                if (GameDataManager.Instance.bomb == 0)
                {
                    GameDataManager.Instance.isBomb = true;
                }
                else
                {
                    GameDataManager.Instance.bomb--;
                    GameDataManager.Instance.bombing = 0;
                    for (int i = 0; i < gameManager.listEnemys.Count; i++)
                    {
                        if (gameManager.listEnemys[i].GetComponent<Enemy>() == null)
                        {
                            GameDataManager.Instance.isBomb = true;
                        }
                        else
                        {
                            GameDataManager.Instance.bomb--;
                            GameDataManager.Instance.bombing = 0;

                            gameManager.listEnemys[i].GetComponent<Enemy>().hp -= 1;

                            if (gameManager.listEnemys[i].GetComponent<Enemy>().hp < 0)
                            {
                                gameManager.listEnemys[i].GetComponent<Enemy>().InitItem();
                                Destroy(gameManager.listEnemys[i].gameObject);
                            }

                        }
                    }
                }
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                GameDataManager.Instance.hp -= 1f;
                if (GameDataManager.Instance.hp < 1.0f)
                {
                    Destroy(gameObject);
                }
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                GameDataManager.Instance.hp -= 1f;
            }
            if (other.CompareTag("Item"))
            {
                switch (other.GetComponent<Item>().status)
                {
                    case ItemStatus.hp:
                        if(GameDataManager.Instance.hp < GameDataManager.Instance.maxHp)
                        {
                            GameDataManager.Instance.hp += 1f;
                        }
                        break;
                    case ItemStatus.upgrade:
                        if(GameDataManager.Instance.upgrade < GameDataManager.Instance.maxUpgrade)
                        {
                            GameDataManager.Instance.upgrade++;
                        }
                        break;
                    case ItemStatus.bomb:
                        if (GameDataManager.Instance.bomb < GameDataManager.Instance.maxBomb)
                        {
                            GameDataManager.Instance.bomb++;
                        }
                        break;
                }
                Destroy (other.gameObject);
                return;
            }
        }
    }
}
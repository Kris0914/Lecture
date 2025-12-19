using PlasticGui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Codice.Client.Common.EventTracking.TrackFeatureUseEvent.Features.DesktopGUI.Filters;

namespace P1NGMU
{
    public class Enemy : MonoBehaviour
    {
        private GameManager gameManager;
        public float speed;
        public float ThrowPower = 50.0f;
        private GameObject Player;
        public GameObject objBullet;
        public Transform BulletPoint;
        public float delay = 0.5f;
        public float fireRete = 1.0f;
        public GameObject[] item;
        public float hp = 1.0f;
        public float maxhp = 1.0f;

        void Start()
        {
            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
            if (gameManagerObject != null)
            {
                gameManager = gameManagerObject.GetComponent<GameManager>();
            }
            if (gameManager == null)
            {
                Debug.LogError("게임 매니저가 존재하지 않습니다.");
            }

            Player = GameObject.FindGameObjectWithTag("Player");

            if(Player == null)
            {
                Debug.Log(" Player .");
            }

            this.GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
            Invoke("ThrowPlayer", Random.Range(0.5f, 1.5f));
            InvokeRepeating("fireBullet", delay, fireRete);
        }

        void ThrowPlayer()
        {
            Vector3 dir = Player.transform.position - this.transform.position;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(dir.x, 0, 0) * ThrowPower);
        }

        void fireBullet()
        {
            if(Player != null)
            {
                GameObject bullet = Instantiate(objBullet, BulletPoint.position, this.transform.rotation);
                bullet.GetComponent<Bullet>().SetBullet(Player.transform.position);
            }
        }

        public void InitItem()
        {
            int itemNum = gameManager.CreateItem();
            if (itemNum != -1)
            {
                Instantiate(item[itemNum], this.transform.position, item[itemNum].transform.rotation);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                return;
            }

            if (other.CompareTag("Bullet"))
            {
                hp -= 1f;

                //아이템 드랍은 대회에서 무조건 나옴
                if(hp < 1.0f)
                {
                    int itemNum = gameManager.CreateItem();
                    if (!other.CompareTag("Player") && itemNum != -1)
                    {
                        Instantiate(item[itemNum], this.transform.position, item[itemNum].transform.rotation);
                    }
                    gameManager.listEnemys.Remove(this.gameObject);

                    Destroy(gameObject);
                }
                Destroy(other.gameObject);
            }

            else if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}

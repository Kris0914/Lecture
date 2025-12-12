using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    public class Player : MonoBehaviour
    {
        //총알 딜레이
        public float bulletTime = 0.1f;
        //총알 딜레이 만큼 시간이 지났는지 체크
        public float reloadTime = 0f;
        Rigidbody thisRigi;
        // 플레이어 이동 속도
        public float speed = 2.0f;
        // 총알 프리퓁
        public GameObject objBullet;
        // 총알이 생성 될 위치
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
            thisRigi.velocity = move * speed;

            //현재 플레이의 위치의 월드 좌표계를 스크린 좌표계로 바꾼다
            Vector3 poslnWorld = Camera.main.WorldToScreenPoint(this.transform.position);

            //스크린 좌표계에서 움직일 수 있는 범위를 제한한다
            float posX = Mathf.Clamp(poslnWorld.x, 0, Screen.width);
            float posZ = Mathf.Clamp(poslnWorld.y, 0, Screen.height);

            //제한 된 이동을 다시 월드 좌표계로 변환
            Vector3 poslnScreen = Camera.main.ScreenToWorldPoint(new Vector3(posX, posZ, 0));

            //이동 시킨다
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
        }
    }
}
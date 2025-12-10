using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    

        void Update()
        {
            Move();
        }



    void Start()
        {
            thisRigi = GetComponent<Rigidbody>();
        }

    private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(moveX, 0.0f, moveZ);
            thisRigi.velocity = move * speed;

            Vector3 poslnWorld = Camera.main.WorldToScreenPoint(this.transform.position);

            float posX = Mathf.Clamp(poslnWorld.x, 0, Screen.width);
            float posZ = Mathf.Clamp(poslnWorld.y, 0, Screen.height);

            Vector3 poslnScreen = Camera.main.ScreenToViewportPoint(new Vector3(posX, posZ,0));

            thisRigi.position = new Vector3(poslnScreen.x, 0, poslnScreen.z);
        }



    }
}

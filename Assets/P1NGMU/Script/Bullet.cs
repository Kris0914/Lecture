using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;
        [UnityEngine.SerializeField]
        private bool isThrow = false;
        public float speed = 1.0f;

        // 방향
        public Vector3 dir;

        void Update()
        {
            this.transform.position += dir.normalized * Time.deltaTime * speed;
        }

        public void SetBullet(Vector3 _destination)
        {
            destination = _destination;
            isThrow = true;


            //방향 계산
            dir = destination - this.transform.position;
        }
    }
}

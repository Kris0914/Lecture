using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    public class Enemy2 : MonoBehaviour
    {
        public float speed;
        public float hp = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            this.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }

        // Update is called once per frame
        void Update()
        {

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
                if (hp < 1.0f)
                {
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

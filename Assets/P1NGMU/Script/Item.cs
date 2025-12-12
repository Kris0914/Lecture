using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    [System.Serializable]

    public enum ItemStatus
    { 
        hp,
        upgrade,
        bomb
    }

    public class Item : MonoBehaviour
    {
        public float itemSpeed = -0.25f;

        public ItemStatus status = ItemStatus.hp;

        // Start is called before the first frame update


        // Update is called once per frame
        void Update()
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + Time.deltaTime * itemSpeed);

        }
        void Start()
        {

        }

    }
}

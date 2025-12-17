using UnityEngine;

namespace P1NGMU
{
    public class BackGround : MonoBehaviour
    {
        public float mapSpeed;
        public float mapSizeZ;
        private Vector3 startPos;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            startPos = this.transform.position;
        
        }

        // Update is called once per frame
        void Update()
        {
            float newPosition = Mathf.Repeat(this.transform.position.z + Time.deltaTime * mapSpeed, mapSizeZ);
            transform.position = new Vector3(startPos.x, startPos.y, newPosition);
        }
    }
}

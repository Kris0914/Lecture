using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 20.0f; //최대 속력
    public float currentSpeed = 0.0f; //현재 속력
    public float increaseSpeed = 5.0f; //속도 증가
    public float decreaseSpeed = 2.0f; //속도 감소
    public float backSpeed = 9.0f; //브레이크
    public float rotSpeed = 200.0f; 
    public float hp = 100f; //체력
    public GameObject bombEffect; //폭발 효과
    public int bombcnt = 3; //폭발 횟수
    public float knockbackPower = 10f; //넉백 힘
    public float knockbackTime = 0.2f; //넉백 시간

    Rigidbody rb;

    [SerializeField]
    bool isBtn1 = true;

    [SerializeField]
    bool isBtn2 = true;

    [SerializeField]
    bool isBtn3 = true;

    public bool isReflect = false;

    [SerializeField]
    float reflectTime = 3.0f;

    public GameObject Reflect;
    public GameObject BlackHole;
    public GameObject SlowHole;
    public GameObject DebugActive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += increaseSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= backSpeed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}

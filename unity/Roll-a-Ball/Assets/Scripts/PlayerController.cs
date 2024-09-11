using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // 에디터 안 Inspector에서 편집 가능한 속도 조정 변수 생성
    public float speed;
    // Rigidbody 형태의 변수 생성
    private Rigidbody rb;
    public float jumpForce;

    private bool jump = false;
    private bool isGrounded = false;

    // 스크립트가 활성화된 첫 프레임에 호출
    void Start()
    {
        // 현재 오브젝트의 Rigidbody를 참조
        rb = GetComponent<Rigidbody>();
    }

    // 프레임을 렌더링 하기 전에 호출
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
        }
    }

    // 물리효과 계산을 수행하기 전에 호출
    void FixedUpdate()
    {
        // 키보드의 키로 컨트롤하는 수평 축의 입력 (left, right)
        float moveHorizontal = Input.GetAxis("Horizontal");
        // 키보드의 키로 컨트롤하는 수직 축의 입력 (up, down)
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movemnet;


        if (jump)
        {
            movemnet = new Vector3(moveHorizontal, jumpForce, moveVertical);
            jump = false;
        }
        else
        {
            movemnet = new Vector3(moveHorizontal, 0, moveVertical);
        }
        // 플레이어의 Rigidbody에서 movement 값만큼 힘을 가해서 이동시킴
        rb.AddForce(movemnet * speed);
    }

    // 트리거 콜라이더를 처음 접촉할 때 호출
    void OnTriggerEnter(Collider other)
    {
        // 오브젝트의 태그 값 비교
        if (other.gameObject.CompareTag("PickUp"))
        {
            // 오브젝트 비활성화
            other.gameObject.SetActive(false);
        }
    }
}







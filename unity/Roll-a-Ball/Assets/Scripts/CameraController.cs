using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // 플레이어 오브젝트
    public GameObject player;
    // 카메라와 플레이어의 거리 차이
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        // 카메라와 플레이어의 거리 차이를 offset으로 둔다.
        // 카메라 위치 - 플레이어 위치
        offset = transform.position - player.transform.position;
    }

    // 프레임을 렌더링 하기 전에 호출
    void Update()
    {

    }

    // 모든 아이템이 Update()에서 다 처리된 후에 호출
    void LateUpdate()
    {
        // 카메라가 플레이어와 offset 거리를 유지하며 움직인다.
        transform.position = player.transform.position + offset;
    }
}




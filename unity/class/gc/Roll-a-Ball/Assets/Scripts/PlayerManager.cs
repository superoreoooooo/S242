using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Camera mainCamera;
    public bool isDragging = false;
    private float distanceToCamera;
    private Vector3 offset;
    private bool tableStatus;
    private GameObject obj;

    void Start()
    {
        mainCamera = Camera.main;
    }
/**
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    obj = hit.collider.gameObject;

                    if (obj.GetComponent<PM_powerButton>() != null) {
                        obj.GetComponent<PM_powerButton>().button();
                        return;
                    }

                    if (obj.tag != "interactableObject") return;
                    if (obj.GetComponent<InteractableObject>() != null) {
                        if (!obj.GetComponent<InteractableObject>().isDragable || obj.GetComponent<InteractableObject>().isAttached) return;
                    }
                    isDragging = true;
                    distanceToCamera = Vector3.Distance(obj.transform.position, mainCamera.transform.position);
                    offset = obj.transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
                }
            }

            if (isDragging && obj != null)
            {
                if (obj.GetComponent<InteractableObject>() != null) {
                    if (obj.GetComponent<InteractableObject>().isAttached) return;
                    //offset = offset * (1 + Input.GetAxis("Mouse ScrollWheel"));
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera);
                    Vector3 targetPosition = mainCamera.ScreenToWorldPoint(mousePosition) + offset;
                    //obj.transform.position = targetPosition;
                
                    obj.GetComponent<Rigidbody>().MovePosition(targetPosition);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                obj = null;
            }

            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            if (scrollInput != 0f)
            {
                distanceToCamera += scrollInput * 3f; 
                distanceToCamera = Mathf.Clamp(distanceToCamera, 1f, 50f);
            } 
    }

    public bool isInteracting = false;

    public void setCursorStateLocked(bool b) {
        UnityEngine.Cursor.visible = !b;
        if (b == true) {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        } else {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
    } */

    int cnt = 0;
    
    // 트리거 콜라이더를 처음 접촉할 때 호출
    void OnTriggerEnter(Collider other)
    {
        // 오브젝트의 태그 값 비교
        if (other.gameObject.CompareTag("PickUp"))
        {
            // 오브젝트 비활성화
            other.gameObject.SetActive(false);
            cnt += 1;
        }
    }

    public GameObject winUI;

    void Update() {
        if (cnt >= 12) {
            winUI.SetActive(true);
        }
        if (transform.position.y <= -10) {
            transform.position = new Vector3(0, 2, 0);
        }
    }
}
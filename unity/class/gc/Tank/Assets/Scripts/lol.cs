using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lol : MonoBehaviour
{
    // 색상 변화 속도
    public float colorChangeSpeed = 1.0f;

    // Emission 강도
    public float emissiveIntensity = 5.0f;

    // Renderer를 저장할 변수
    private Renderer objectRenderer;

    private float timer = 0.0f;

    private int colorPhase = 0;

    void Start()
    {
        /*
        // GameObject의 Renderer 컴포넌트를 가져옵니다
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogError("Renderer 컴포넌트를 찾을 수 없습니다.");
            return;
        }

        // Emission을 활성화하기 위해 키워드 설정
        objectRenderer.material.EnableKeyword("_EMISSION"); */
    }

    public Light light;

    void Update()
    {
        /*
        if (objectRenderer != null)
        {
            // 시간에 따른 RGB 값 계산
            float r = Mathf.Sin(Time.time * colorChangeSpeed) * 0.5f + 0.5f;
            float g = Mathf.Sin(Time.time * colorChangeSpeed + Mathf.PI / 3) * 0.5f + 0.5f;
            float b = Mathf.Sin(Time.time * colorChangeSpeed + 2 * Mathf.PI / 3) * 0.5f + 0.5f;


            // 새로운 Emissive Color 설정
            Color emissiveColor = new Color(r, g, b);

            // HDRP에서 Emission Color를 설정할 때 강도와 곱해서 설정
            objectRenderer.material.SetColor("_EmissiveColor", emissiveColor * emissiveIntensity);
        } */
        timer += Time.deltaTime;

        if (timer > colorChangeSpeed)
        {
            timer -= colorChangeSpeed;
            colorPhase = (colorPhase + 1) % 6;
        }

        // 색상 계산
        float t = timer / colorChangeSpeed;
        Color rgbColor = GetColorPhase(t, colorPhase);

        light.color = rgbColor * emissiveIntensity;
        //objectRenderer.material.SetColor("_EmissiveColor", rgbColor * emissiveIntensity);
    }

    Color GetColorPhase(float t, int phase)
    {
        switch (phase)
        {
            case 0: return new Color(1, t, 0); // 빨강 -> 노랑
            case 1: return new Color(1 - t, 1, 0); // 노랑 -> 녹색
            case 2: return new Color(0, 1, t); // 녹색 -> 청록색
            case 3: return new Color(0, 1 - t, 1); // 청록색 -> 파랑
            case 4: return new Color(t, 0, 1); // 파랑 -> 자홍색
            case 5: return new Color(1, 0, 1 - t); // 자홍색 -> 빨강
            default: return Color.white;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundsMoving : MonoBehaviour
{
    [SerializeField] private Transform[] segments;   // Top1, Top2, Middle1, Middle2, Bottom1, Bottom2 순서대로
    [SerializeField] private float[] speeds;         // 각 세그먼트별 speed 멀티플라이어 (Top은 topSpeed, Middle은 middleSpeed…)
    [SerializeField] private float bgMoveSpeed = 1f; // 공통 베이스 스피드
    [SerializeField] private float height = 10f;     // 세그먼트 1장의 높이

    void Update()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            var t = segments[i];
            t.Translate(Vector2.down * bgMoveSpeed * speeds[i] * Time.deltaTime);

            // y가 -height 밑으로 내려가면 위로 두 장 높이만큼 올려서 리사이클
            if (t.position.y < -height)
            {
                t.position += Vector3.up * (height * 2f);
            }
        }
    }
}

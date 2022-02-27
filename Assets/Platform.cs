using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector2 move_dir = Vector2.right;
    public float distance = 2.0f;
    public float move_time = 4.0f;

    public bool arrived = false; // 플랫폼이 이동을 완료 했을때 Flag가 True로 되는 변수입니다.

    public void Activate(float time)
    {
        StartCoroutine(저기까지몇초만에이동((Vector2)transform.position + move_dir * distance, time));
    }

    IEnumerator 저기까지몇초만에이동(Vector2 목표위치, float 목표시간)
    {
        float 경과시간 = 0.0f;
        Vector2 최초위치 = transform.position;
        while (경과시간 < 목표시간)
        {
            Vector2 new_pos = Vector2.Lerp(최초위치, 목표위치, 경과시간 / 목표시간);
            transform.position = new_pos;
            경과시간 += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }


        arrived = true;
    }
}

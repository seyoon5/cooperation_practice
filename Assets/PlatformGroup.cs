using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGroup : MonoBehaviour
{
    Platform[] platforms; // 여러개의 플렛폼을 관리하는 변수
    bool missionComplete = false;  // 발판이 이동로를 막았는지 확인하는 변수
    private void Awake()  // Awake 함수는 GameObject 가 생성되자마자 호출됨.
    {
        platforms = GetComponentsInChildren<Platform>();  // 하위 디렉토리로 넣어준 L,R Platform 들을 가져와서 platforms 변수에 넣어주기 위한 코드
    }

    private void Start()  // GameObject 에서 Awake() 다음에 자동으로 실행되는 함수
    {
        Activate();  // 게임이 시작되면 Activate 함수 호출
    }

    public void Activate()  // 발판을 같은 속도로 활성화 시키는 함수(platform 에 randTime 이 각 다르게 생성되서 속도가 달랐음) 
    {
        float randomPlatformMovingTime = GetRandTime();
        foreach (Platform platform in platforms)  // platforms 에 있는 모든 platform 을 가져 오는 함수.
        {
            platform.Activate(randomPlatformMovingTime);   // platform 을 활성화 시키는 함수.
        }
    }
    public float GetRandTime()
    {
        float minTime = 0.7f;
        float maxTime = 1.3f;
        return UnityEngine.Random.Range(minTime, maxTime);
    }

    public void Update()
    {
        if (missionComplete == false && CheckPlatformsDeactivate())
        {
            missionComplete = true;
            FindObjectOfType<PlatformManager>().AddNewPlatform();
        }
    }

    public bool CheckPlatformsDeactivate()
    {
        bool deactivate = true;
        foreach (Platform platform in platforms)
        {
            if (platform.arrived == false)
            {
                deactivate = false;
                break;
            }
        }
        return deactivate;
    }

    public void SetName(string name)
    {
        foreach (Platform platform in platforms)
        {
            platform.gameObject.name = name;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panel_GameOver : MonoBehaviour
{
    public Text Text_GameResult; // 게임의 결과를 표시해줄 Text Ui
    private void Awake()
    {
        transform.gameObject.SetActive(false); // 게임이 시작되면 GameOver 팝업 창을 보이지 않도록 한다.
    }

    public void Show()
    {
        transform.gameObject.SetActive(true); // GameOver 팝업 창을 화면에 표시 시키고
        int score = FindObjectOfType<ScoreText>().GetScore(); // ScoreText로 부터 현재 기록된 점수를 불러온다.
        int highScore = FindObjectOfType<ScoreText>().Get_HighScore();
        Text_GameResult.text = "GameSet\nScore : " + score.ToString(); // 팝업의 점수 창에 현재 점수를 표시한다.
                                                                       // \n 이라는 문자는! '줄바꿈' 즉! GameSet이라는 글자 다음에 한줄 띄어라
                                                                       // 라는 뜻이다.

        Text_GameResult.text = "게임종료\n" +
        "최고점수 : " + highScore.ToString() + "\n" +
        "내 점수 : " + score.ToString();

    }

    public void OnClick_Retry() // '재도전' 버튼을 클릭하며 호출 되어질 함수
    {
        SceneManager.LoadScene("GameScene"); // SceneManager의 LoadScene 함수를 사용하여! 현재 신 'GameScene'을 다시 불러오도록 시킨다.
                                             // 같은 신을 다시 불러오면 게임이 재시작 된다.
    }
}

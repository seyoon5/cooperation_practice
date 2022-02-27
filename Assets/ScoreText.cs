using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    int score = 0; //  점수를 저장하기 위해서 score 변수를 선언해줍니다.
    Text text_score; // score를 표시해줄 UI text (아까 저희가 만든 거에요!)

    private void Awake()
    {
        text_score = GetComponent<Text>(); // 저희는 Text에다가 바로 스크립트를 생성했기 때문에 GetComponent를 하면 Ui Text를 가져올 수 있습니다.
    }
    public void AddPoint() // AddPoint함수가 호출이 되면! score += 1; 저번에 말씀드렸죠? score = score + 1; 이것과 같은 거구요! 0점에서 1점이 된다는거죠!
    {
        score += 1; // 이런식으로 score를 + 해주고!
        UpdateTextUi(); // Ui Text에 숫자를 출력해 줍니다!
    }
    public void UpdateTextUi()
    {
        text_score.text = score.ToString(); // text_score라는 UiText의 text 에다가 score.ToString()을 저장해주는거죠!
                                            // score.ToString()은요! Int형인 score를 string의 형태! 즉 '문자열'로 변환을 시켜서
                                            // text_score.text 값에 넣어주는 것을 말합니다.
    }
    public int GetScore()
    {
        return score;
    }
    string highScoreKey = "HighScore";
    public int Get_HighScore()
    {
        int highScore = PlayerPrefs.GetInt(highScoreKey);
        return highScore;
    }
    public void Set_HighScore(int cur_score)
    {
        if (cur_score > Get_HighScore())
        {
            PlayerPrefs.SetInt(highScoreKey, cur_score);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float speed = 0.005f;
    public float move_term = 0.25f;
    public float boost_term = 3.0f;
    public float boost_speed = 4.0f;

    GameObject Player;
    BoxCollider2D boxCollider;

    public Panel_GameOver panel_GameOver;
    private void Awake()
    {
        Player = FindObjectOfType<Jump>().gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void Start()
    {
        StartCoroutine(Move());
    }

    public Vector2 GetTopPosition()
    {
        Vector2 topPos;
        topPos = boxCollider.bounds.max;
        return topPos;
    }

    IEnumerator Move()
    {
        while (true)
        {
            float cur_speed = speed;
            if (Player.transform.position.y > GetTopPosition().y + boost_term)
            {
                cur_speed *= boost_speed;
            }

            transform.position = new Vector2(transform.position.x, transform.position.y + cur_speed);
            yield return new WaitForSeconds(move_term);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameOver();
        }
    }
    public void Stop()
    {
        StopAllCoroutines();
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        Stop();
        FindObjectOfType<PlatformManager>().Stop();
        FindObjectOfType<Jump>().Die();

        ScoreText scoreText = FindObjectOfType<ScoreText>();
        scoreText.Set_HighScore(scoreText.GetScore());

        panel_GameOver.Show();
    }
}

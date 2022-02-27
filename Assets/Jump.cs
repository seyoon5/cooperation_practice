using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float JumpPower = 300.0f;
    [SerializeField] private LayerMask platformLayerMask;
    BoxCollider2D boxCollider2D;
    string recentCollisionObjectName = "땅";
    bool die = false; // 내가 추가함.
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        if (Input.GetMouseButtonDown(0) == true && die == false)
        {
            if (IsGrounded())
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));
            }
        }

    }
    public void Die()
    {
        die = true;
    }
    public bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeight, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.name != "땅" && raycastHit.collider.name != recentCollisionObjectName)
            {
                FindObjectOfType<ScoreText>().AddPoint();
                recentCollisionObjectName = raycastHit.collider.name;
            }
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(   // 조사관(Debug)을 불러서 Ray(광선)을 발사하라고 하여라
                        boxCollider2D.bounds.center,  // 충돌박스의 중앙점으로부터
                        Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), // 아래 방향으로 충돌박스의 절반 값에 추가적인 검침봉의 길이를 더한만큼
                        rayColor); // 위에서 정한 검침봉의 색깔로!)

        Debug.Log(raycastHit.collider);

        if (raycastHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnGUI()
    {

    }
}

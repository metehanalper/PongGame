using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Text rightScoreText;
    public Text leftScoreText;
    private int leftscore = 0;
    private int rightscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(1, 0)*30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "WallRight")
        {
            leftscore++;
            leftScoreText.text = leftscore.ToString();
            transform.position = Vector2.zero;
            rb2d.velocity = Vector2.left * 30;
        }
        if (other.gameObject.name == "WallLeft")
        {
            rightscore++;
            rightScoreText.text = rightscore.ToString();
            transform.position = Vector2.zero;
            rb2d.velocity = Vector2.right * 30;
        }

        if (other.gameObject.name == "RacketLeft")
        {
            float y= hitFactor(transform.position, other.transform.position, 4);
            rb2d.velocity = new Vector2(1, y).normalized * 30;
        }
        if (other.gameObject.name == "RacketRight")
        {
            float y = hitFactor(transform.position, other.transform.position, 4);
            rb2d.velocity = new Vector2(-1, y).normalized * 30;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, Vector2 racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public bool autoPlay = false;
    private Ball ball;

    // Use this for initialization
    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update () {
        if (!autoPlay)
        {
            moveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}

    void moveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);


        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 15f);

        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        paddlePos.x = Mathf.Clamp(ball.transform.position.x, 0f, 15f);
        this.transform.position = paddlePos;
    }
}

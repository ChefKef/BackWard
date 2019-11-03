using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigid;
    private const float MAX_SPEED = 3f;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rigid = player.GetComponent<Rigidbody2D>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(new Vector2(-MAX_SPEED * 2f, 0));
            if(rigid.velocity.x > 0)
            {
                rigid.AddForce(new Vector2(-MAX_SPEED * 10f, 0));
            }
            player.transform.rotation = new Quaternion(0, 180f, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(new Vector2(MAX_SPEED * 2f, 0));
            if (rigid.velocity.x < 0)
            {
                rigid.AddForce(new Vector2(MAX_SPEED * 10f, 0));
            }
            player.transform.rotation = new Quaternion(0, 0f, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = !grounded;
            rigid.AddForce(new Vector2(0, MAX_SPEED * 100));
        }
        if (rigid.velocity.x > MAX_SPEED)
        {
            rigid.velocity = new Vector2(MAX_SPEED, rigid.velocity.y);
        }
        if (rigid.velocity.x < -MAX_SPEED)
        {
            rigid.velocity = new Vector2(-MAX_SPEED, rigid.velocity.y);
        }
        if (player.transform.position.y < 0) //Handle the landing.
        {
            player.transform.position = new Vector3(player.transform.position.x, 0, 0);
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            grounded = true;
        }
        Debug.Log(rigid.velocity);
    }
}
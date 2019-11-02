using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject player;
    private Vector3 acc, vel, pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            acc += new Vector3(-.5f, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            acc += new Vector3(.5f, 0, 0);
        }
        if (vel.x > 0)
        {
            acc.x = acc.x -.2f;
        }
        if (vel.x < 0)
        {
            acc.x = acc.x + .2f;
        }
        vel += acc * Time.deltaTime;
        if(vel.x > 1)
        {
            vel = new Vector3(1, 0, 0);
        }
        if (vel.x < -1)
        {
            vel = new Vector3(-1, 0, 0);
        }
        pos += (vel * Time.deltaTime);
        player.transform.position = pos;
    }
}

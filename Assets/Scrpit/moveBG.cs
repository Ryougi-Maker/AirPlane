using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBG : MonoBehaviour
{
    float speed = 1;
    float bgHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, -speed * Time.deltaTime, 0);
        if (this.transform.position.y <= -bgHeight)
        {
            this.transform.position = new Vector3(0, bgHeight, 0);
        }
    }
}

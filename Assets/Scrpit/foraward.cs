using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foraward : MonoBehaviour
{

    float awardDownSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, -awardDownSpeed * Time.deltaTime, 0);
        if (this.transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forenemy : MonoBehaviour
{
    public GameObject smallEnemy;
    float smallSpeed = 1;

    public GameObject middleEnemy;
    float middleSpeed = 4;

    public GameObject bigEnemy;
    float bigSpeed = 16;

    public GameObject blueAward;
    float awardSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        repeatSmallenemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void createSmallenemy()
    {
        this.transform.position = new Vector3(Random.Range(-2.9f, 2.9f), this.transform.position.y, this.transform.position.z);
        Instantiate(smallEnemy, this.transform.position, Quaternion.identity);

    }

    void createMiddleenemy()
    {
        this.transform.position = new Vector3(Random.Range(-2.8f, 2.8f), this.transform.position.y, this.transform.position.z);
        Instantiate(middleEnemy, this.transform.position, Quaternion.identity);

    }
    void createBigenemy()
    {
        this.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), this.transform.position.y, this.transform.position.z);
        Instantiate(bigEnemy, this.transform.position, Quaternion.identity);

    }
    void createAward()
    {
        this.transform.position = new Vector3(Random.Range(-2.85f, 2.85f), this.transform.position.y, this.transform.position.z);
        Instantiate(blueAward, this.transform.position, Quaternion.identity);

    }


    void repeatSmallenemy()
    {
        InvokeRepeating("createSmallenemy", 0.1f, smallSpeed);
        InvokeRepeating("createMiddleenemy", 1f, middleSpeed);
        InvokeRepeating("createBigenemy", 4f, bigSpeed);
        InvokeRepeating("createAward", 4f, awardSpeed);
    }
    public void stopAll()
    {
        CancelInvoke("createSmallenemy");
        CancelInvoke("createMiddleenemy");
        CancelInvoke("createBigenemy");
        CancelInvoke("createAward");
    }
}

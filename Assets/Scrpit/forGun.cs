using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forGun : MonoBehaviour
{
    public GameObject ziDan;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //kaiQiang();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateBullet()
    {
        Instantiate(ziDan,this.transform.position,Quaternion.identity);
    }
    public void kaiQiang()
    {
        InvokeRepeating("CreateBullet", 0.1f, bulletSpeed);
    }
    public void Stopfire()
    {
        CancelInvoke("CreateBullet");
    }
}

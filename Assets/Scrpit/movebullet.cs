using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebullet : MonoBehaviour
{
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * bulletSpeed*Time.deltaTime);
        if (this.transform.position.y >= 5.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D diji)
    {
        if (diji.gameObject.tag == "Diji")
        {
            Destroy(this.gameObject);
            diji.gameObject.SendMessage("beiZhuang");
        }
    }
}

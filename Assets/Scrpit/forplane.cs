    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forplane : MonoBehaviour
{

    public Sprite[] feiji;
    float playSpeed = 10;
    int zongzhenshu;

    float superGunTime = 0;

    public GameObject topGun;
    public GameObject leftGun;
    public GameObject rightGun;

    bool isSuperGun;
    bool isNormalGun;

    public Sprite[] heroBomb;
    float heroBombSpeed = 6;
    float heroBombTime;
    bool isHeroDead;
    // Start is called before the first frame update
    void Start()
    {
        startNormalGun();
    }

    // Update is called once per frame
    void Update()
    {
        zongzhenshu = Mathf.CeilToInt(playSpeed * Time.time);

        this.GetComponent<SpriteRenderer >().sprite = feiji[zongzhenshu % 2];
        if (Input.GetMouseButton(0))
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CheckPosition();

        }
        superGunTime = superGunTime - Time.deltaTime;
        if (superGunTime > 0 && isSuperGun)
        {
            startSuperGun();
        }
        else if(superGunTime <=0&&isNormalGun)
        {
            startNormalGun();
        }
        if (isHeroDead)
        {
            heroBombTime = heroBombTime + Time.deltaTime;
            int bombFrames = (int)(heroBombTime * heroBombSpeed);
            if (bombFrames >= heroBomb.Length)
            {
                Destroy(this.gameObject);
                GameObject.Find("enemy").GetComponent<forenemy>().stopAll();
                gameover._instance.endGame();
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = heroBomb[bombFrames];
            }
        }
    }
    void CheckPosition()
    {
        Vector3 feijiPosition = this.transform.position;
        if (feijiPosition.x < -2.6f)
        {
            feijiPosition.x = -2.6f;
        }
        if (feijiPosition.x > 2.6f)
        {
            feijiPosition.x = 2.6f;
        }
        if (feijiPosition.y > 4.4f)
        {
            feijiPosition.y = 4.4f;
        }
        if (feijiPosition.y < -4.4f)
        {
            feijiPosition.y = -4.4f;
        }
        this.transform.position = new Vector3(feijiPosition.x, feijiPosition.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D beiZhuangZhe)
    {
        if (beiZhuangZhe.gameObject.tag == "award")
        {
            superGunTime = 5;
            isSuperGun = true;
            Destroy(beiZhuangZhe.gameObject);
        }
        else if (beiZhuangZhe.gameObject.tag == "Diji" && !beiZhuangZhe.GetComponent<Moveenemy>().isDead) 
        {
            //Destroy(this.gameObject);
            isHeroDead = true;


        }
    } 
    void startNormalGun()
    {
        topGun.GetComponent<forGun>().kaiQiang();
        leftGun.GetComponent<forGun>().Stopfire();
        rightGun.GetComponent<forGun>().Stopfire();
        isNormalGun = false;
        isSuperGun = true;
    }
    void startSuperGun()
    {
        topGun.GetComponent<forGun>().Stopfire();
        leftGun.GetComponent<forGun>().kaiQiang();
        rightGun.GetComponent<forGun>().kaiQiang();
        isSuperGun = false;
        isNormalGun = true;
    }
}

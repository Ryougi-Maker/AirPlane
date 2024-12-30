using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveenemy : MonoBehaviour
{

    float SmallenemySpeed = 1.5f;
    public bool isDead = false;
    public Sprite[] smallEnemyBomb;
    float bombSpeed = 10;
    float bombTime = 0;
    public int hp;//ÑªÁ¿
    bool ishit = false;

    public Sprite[] hitPictures;
    public float hitSpeed = 10;
    float hitTime = 0.2f;

    public int planeScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, -SmallenemySpeed * Time.deltaTime, 0);
        if (this.transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
        if (isDead)
        {
            bombTime = bombTime + Time.deltaTime;
            int bombFrames = (int)(bombSpeed * bombTime);
            if (bombFrames >= smallEnemyBomb.Length)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = smallEnemyBomb[bombFrames];
            }
        }
        if (ishit)
        {
            hitTime = hitTime - Time.deltaTime;
            if (hitTime >= 0)
            {
                int zhenShu = (int)(hitTime * hitSpeed)%2;
                this.GetComponent<SpriteRenderer>().sprite = hitPictures[zhenShu];
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = hitPictures[0];
                ishit = false;
                hitTime = 0.3f;
            }
        }
    }
    public void beiZhuang()
    {
        hp--;
        if (hp <= 0)
        {
            if (!isDead)
            {
                gameManager._instance.score = gameManager._instance.score + planeScore;
            }
            isDead = true;
        }
        else
        {
            ishit = true;
        }
        //Destroy(this.gameObject);
    }
}

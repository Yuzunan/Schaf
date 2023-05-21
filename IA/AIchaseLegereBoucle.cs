using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class AIchaseLegereBoucle : MonoBehaviour
{
    public Transform player;
    public GameObject color;
    public string monstercolor;
    public SpriteRenderer spriteRenderer;
    public Sprite[] UpSprites;
    public Sprite[] LeftSprites;
    public Sprite[] RightSprites;
    public Sprite[] DownSprites;
    public Sprite UpSprite;
    public Sprite LeftSprite;
    public Sprite RightSprite;
    public Sprite DownSprite;
    private float distance;
    public float speed;
    public float spurt;
    public float distanceSpurt;
    public bool activate;
    private float t;
    private Vector2 AddVector;
    private float sign;

    public float attackdmg;
    // Start is called before the first frame update
    void Start()
    {
        speed *= Random.Range((float)0.5, (float)1.5);
        tag = monstercolor;
        t = 0;
        distance = Vector2.Distance(player.position, transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if (direction.x > 0)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }
        if (monstercolor == "Red")
        {
            UpSprite = UpSprites[0];
            LeftSprite = LeftSprites[0];
            DownSprite = DownSprites[0];
            RightSprite = RightSprites[0];
        }
        if (monstercolor == "Green")
        {
            UpSprite = UpSprites[1];
            LeftSprite = LeftSprites[1];
            DownSprite = DownSprites[1];
            RightSprite = RightSprites[1];
        }
        if (monstercolor == "Orange")
        {
            UpSprite = UpSprites[2];
            LeftSprite = LeftSprites[2];
            DownSprite = DownSprites[2];
            RightSprite = RightSprites[2];
        }
        if (monstercolor == "Blue")
        {
            UpSprite = UpSprites[3];
            LeftSprite = LeftSprites[3];
            DownSprite = DownSprites[3];
            RightSprite = RightSprites[3];
        }
        if (monstercolor == "Yellow")
        {
            UpSprite = UpSprites[4];
            LeftSprite = LeftSprites[4];
            DownSprite = DownSprites[4];
            RightSprite = RightSprites[4];
        }
        if (monstercolor == "Purple")
        {
            UpSprite = UpSprites[5];
            LeftSprite = LeftSprites[5];
            DownSprite = DownSprites[5];
            RightSprite = RightSprites[5];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activate && distance >= 1)
        {
            if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) 
            {
                if ((color.CompareTag("Red") && CompareTag("Green")) ||
                    (color.CompareTag("Green") && CompareTag("Red")) ||
                    (color.CompareTag("Orange") && CompareTag("Blue")) ||
                    (color.CompareTag("Blue") && CompareTag("Orange")) ||
                    (color.CompareTag("Yellow") && CompareTag("Purple")) ||
                    (color.CompareTag("Purple") && CompareTag("Yellow")))
                {
                    activate = false;
                }
                    
            }
            
            distance = Vector2.Distance(player.position, transform.position);
            Vector2 direction = player.transform.position - transform.position;
            if (direction.x > direction.y)
            {
                if (direction.x > -1 * direction.y)
                {
                    spriteRenderer.sprite = RightSprite; 
                }
                else
                {
                    spriteRenderer.sprite = DownSprite; 
                }
            }
            else
            {
                if (-1 * direction.x > direction.y)
                {
                    spriteRenderer.sprite = LeftSprite; 
                }
                else
                {
                    spriteRenderer.sprite = UpSprite; 
                }
            }
            t += Time.deltaTime;
            AddVector = new Vector2(2/(t*t +1), 0)* sign/60;
            transform.position =
                Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime) + AddVector ;
            if (spurt >= 0)
            {
                if (distance < distanceSpurt)
                {
                    speed += spurt;
                    spurt = 0;
                    if (distance < 1.5)
                    {
                        player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(attackdmg);
                        activate = false;
                    }
                }
            }
        }
        else
        {
            IEnumerator waiter()
            {
                yield return new WaitForSecondsRealtime(2);
                this.GameObject().SetActive(false);
            }
            StartCoroutine(waiter());
        }
    }
}

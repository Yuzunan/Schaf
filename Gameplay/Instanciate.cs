using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public GameObject[] monster;
    private GameObject monstre = null;
    public Sprite DeadSprite;
    private float place;
    public Transform player;
    private string[] monstercolor;
    public GameObject color;
    public int stage;
    
    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, 3);
        place = Random.Range((float)-8.0, (float)8.0);
        while (place<4 && place>-4)
            place = Random.Range((float)-8.0, (float)8.0);
        monstre = Instantiate(monster[num], new Vector3(place, 5, 0), Quaternion.identity);
        
        int icolor = Random.Range(0, 6);
        if (stage == 1)
        {
            monstercolor = new string[]{"Red" ,"Green"};
            icolor = Random.Range(0, 2);
            if (monster[num].name == "MonsterZigZag")
                monstre.GetComponent<AIchaseZigZag>().speed = 2;
            else if (monster[num].name == "MonsterBoucles")
                monstre.GetComponent<AIchaseBoucles>().speed = 2;
            else
                monstre.GetComponent<AIchaseLegereBoucle>().speed = 2;
        }
        else if (stage == 2)
        {
            monstercolor = new string[]{"Orange","Blue"};
            icolor = Random.Range(0, 2);
        }
        else if (stage == 3)
        {
            monstercolor = new string[]{"Yellow","Purple"};
            icolor = Random.Range(0, 2);
            if (monster[num].name == "MonsterZigZag")
                monstre.GetComponent<AIchaseZigZag>().speed = 4;
            else if (monster[num].name == "MonsterBoucles")
                monstre.GetComponent<AIchaseBoucles>().speed = 4;
            else
                monstre.GetComponent<AIchaseLegereBoucle>().speed = 4;
        }
        else
        {
            monstercolor = new string[]{"Red" ,"Green","Orange","Blue","Yellow","Purple"};
        }

        if (monster[num].name == "MonsterZigZag")
        {
            monstre.GetComponent<AIchaseZigZag>().monstercolor = monstercolor[icolor];
            monstre.GetComponent<AIchaseZigZag>().player = player;
            monstre.GetComponent<AIchaseZigZag>().color = color;
        }
        else if (monster[num].name == "MonsterBoucles")
        {
            monstre.GetComponent<AIchaseBoucles>().monstercolor = monstercolor[icolor];
            monstre.GetComponent<AIchaseBoucles>().player = player;
            monstre.GetComponent<AIchaseBoucles>().color = color;
        }
        else
        {
            monstre.GetComponent<AIchaseLegereBoucle>().monstercolor = monstercolor[icolor];
            monstre.GetComponent<AIchaseLegereBoucle>().player = player;
            monstre.GetComponent<AIchaseLegereBoucle>().color = color;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (monstre is not null)
        {
            if (!monstre.activeSelf)
            {
                Destroy(monstre);
                monstre = null;
            }
        }
        else
        {
            if (player.GetComponent<PlayerHealth>().spriteRenderer.sprite != DeadSprite)
                Start();
        }
    }
    
}

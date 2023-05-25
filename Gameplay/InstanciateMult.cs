using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class InstanciateMult : NetworkBehaviour
{
    public GameObject[] monster;
    private GameObject monstre = null;
    public Sprite DeadSprite;
    private float place;
    public Transform player;
    private string[] monstercolor;
    public GameObject color;
    public int stage;
    
    public override void OnNetworkSpawn()
    {
        if (!IsServer)
        {
            Destroy(this);
        }
    }
    
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
            if (monster[num].name == "MonsterZigZagMult")
                monstre.GetComponent<AIchaseZigZagMult>().speed = 2;
            else if (monster[num].name == "MonsterBouclesMult")
                monstre.GetComponent<AIchaseBouclesMult>().speed = 2;
            else
                monstre.GetComponent<AIchaseLegereBoucleMult>().speed = 2;
        }
        else if (stage == 2)
        {
            monstercolor = new string[]{"Orange","Blue"};
            icolor = Random.Range(0, 2);
            if (monster[num].name == "MonsterZigZagMult")
                monstre.GetComponent<AIchaseZigZagMult>().speed = 3;
            else if (monster[num].name == "MonsterBouclesMult")
                monstre.GetComponent<AIchaseBouclesMult>().speed = 3;
            else
                monstre.GetComponent<AIchaseLegereBoucleMult>().speed = 3;
        }
        else if (stage == 3)
        {
            monstercolor = new string[]{"Yellow","Purple"};
            icolor = Random.Range(0, 2);
        }
        else
        {
            monstercolor = new string[]{"Red" ,"Green","Orange","Blue","Yellow","Purple"};
        }

        if (monster[num].name == "MonsterZigZagMult")
        {
            monstre.GetComponent<AIchaseZigZagMult>().monstercolor = monstercolor[icolor];
            monstre.GetComponent<AIchaseZigZagMult>().player = player;
            monstre.GetComponent<AIchaseZigZagMult>().color = color;
        }
        else if (monster[num].name == "MonsterBouclesMult")
        {
            monstre.GetComponent<AIchaseBouclesMult>().monstercolor = monstercolor[icolor];
            monstre.GetComponent<AIchaseBouclesMult>().player = player;
            monstre.GetComponent<AIchaseBouclesMult>().color = color;
        }
        else
        {
            monstre.GetComponent<AIchaseLegereBoucleMult>().monstercolor = monstercolor[icolor];
            monstre.GetComponent<AIchaseLegereBoucleMult>().player = player;
            monstre.GetComponent<AIchaseLegereBoucleMult>().color = color;
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
            if (player.GetComponent<PlayerHealthMult>().spriteRenderer.sprite != DeadSprite)
                Start();
        }
    }
    
}

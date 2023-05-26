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
    private NetworkObject m_SpawnedNetworkObject;

    // Start is called before the first frame update
    void Start()
    {
        if (!IsServer)
        {
            return;
        }
        int num = Random.Range(0, 3);
        place = Random.Range((float)-8.0, (float)8.0);
        while (place<4 && place>-4)
            place = Random.Range((float)-8.0, (float)8.0);
        monstre = Instantiate(monster[num], new Vector3(place, 5, 0), Quaternion.identity);
        
        int icolor = Random.Range(0, 6);
        
        monstercolor = new string[]{"Red" ,"Green","Orange","Blue","Yellow","Purple"};

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

        m_SpawnedNetworkObject = monstre.GetComponent<NetworkObject>();
        m_SpawnedNetworkObject.Spawn();

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

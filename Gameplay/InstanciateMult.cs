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
        m_SpawnedNetworkObject = monstre.GetComponent<NetworkObject>();
        
        int icolor = Random.Range(0, 6);
        
        monstercolor = new string[]{"Red" ,"Green","Orange","Blue","Yellow","Purple"};

        if (monster[num].name == "MonsterZigZagMult")
        {
            m_SpawnedNetworkObject.GetComponent<AIchaseZigZagMult>().monstercolor = monstercolor[icolor];
            m_SpawnedNetworkObject.GetComponent<AIchaseZigZagMult>().player = player;
            m_SpawnedNetworkObject.GetComponent<AIchaseZigZagMult>().color = color;
        }
        else if (monster[num].name == "MonsterBouclesMult")
        {
            m_SpawnedNetworkObject.GetComponent<AIchaseBouclesMult>().monstercolor = monstercolor[icolor];
            m_SpawnedNetworkObject.GetComponent<AIchaseBouclesMult>().player = player;
            m_SpawnedNetworkObject.GetComponent<AIchaseBouclesMult>().color = color;
        }
        else
        {
            m_SpawnedNetworkObject.GetComponent<AIchaseLegereBoucleMult>().monstercolor = monstercolor[icolor];
            m_SpawnedNetworkObject.GetComponent<AIchaseLegereBoucleMult>().player = player;
            m_SpawnedNetworkObject.GetComponent<AIchaseLegereBoucleMult>().color = color;
        }
        
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

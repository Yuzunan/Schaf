using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class InstanciateMult : NetworkBehaviour
{
    public GameObject[] monsterRGB;
    public GameObject[] monsterOYP;
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
        int num = Random.Range(0, 9);
        place = Random.Range((float)-8.0, (float)8.0);
        while (place<4 && place>-4)
            place = Random.Range((float)-8.0, (float)8.0);

        if (IsServer)
        {
            return;
            monstre = Instantiate(monsterRGB[num], new Vector3(place, 5, 0), Quaternion.identity);
            m_SpawnedNetworkObject = monstre.GetComponent<NetworkObject>();
            
            if (monsterRGB[num].name == "MonsterZigZagMult" || monsterRGB[num].name == "MonsterZigZagMultGREEN" || monsterRGB[num].name == "MonsterZigZagMultBLUE")
            {
                m_SpawnedNetworkObject.GetComponent<AIchaseZigZagMult>().player = player;
                m_SpawnedNetworkObject.GetComponent<AIchaseZigZagMult>().color = color;
            }
            else if (monsterRGB[num].name == "MonsterBouclesMult" || monsterRGB[num].name == "MonsterBouclesMultGREEN" || monsterRGB[num].name == "MonsterBouclesMultBLUE")
            {
                m_SpawnedNetworkObject.GetComponent<AIchaseBouclesMult>().player = player;
                m_SpawnedNetworkObject.GetComponent<AIchaseBouclesMult>().color = color;
            }
            else
            {
                m_SpawnedNetworkObject.GetComponent<AIchaseLegereBoucleMult>().player = player;
                m_SpawnedNetworkObject.GetComponent<AIchaseLegereBoucleMult>().color = color;
            }
        }
        else
        {
            monstre = Instantiate(monsterOYP[num], new Vector3(place, 5, 0), Quaternion.identity);
            
            if (monsterOYP[num].name == "MonsterZigZagMultORANGE" || monsterOYP[num].name == "MonsterZigZagMultPURPLE" || monsterOYP[num].name == "MonsterZigZagMultYELLOW")
            {
                monstre.GetComponent<AIchaseZigZagMult>().player = player;
                monstre.GetComponent<AIchaseZigZagMult>().color = color;
            }
            else if (monsterOYP[num].name == "MonsterBouclesMultORANGE" || monsterOYP[num].name == "MonsterBouclesMultPURPLE" || monsterOYP[num].name == "MonsterBouclesMultYELLOW")
            {
                monstre.GetComponent<AIchaseBouclesMult>().player = player;
                monstre.GetComponent<AIchaseBouclesMult>().color = color;
            }
            else
            {
                monstre.GetComponent<AIchaseLegereBoucleMult>().player = player;
                monstre.GetComponent<AIchaseLegereBoucleMult>().color = color;
            }
        }
        m_SpawnedNetworkObject = monstre.GetComponent<NetworkObject>();
        SpawnServerRpc();
        
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

    [ServerRpc]
    private void SpawnServerRpc()
    {
        m_SpawnedNetworkObject.Spawn();
    }
    
}

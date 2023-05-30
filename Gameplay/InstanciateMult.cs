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
        int num = Random.Range(0, 18);
        place = Random.Range((float)-8.0, (float)8.0);
        while (place<4 && place>-4)
            place = Random.Range((float)-8.0, (float)8.0);

        if (!IsServer)
        {
            return;
        }
        else
        {
            monstre = Instantiate(monster[num], new Vector3(place, 5, 0), Quaternion.identity);
            
            if (monster[num].name == "MonsterZigZagMultORANGE" || monster[num].name == "MonsterZigZagMultPURPLE" || monster[num].name == "MonsterZigZagMultYELLOW" 
                || monster[num].name == "MonsterZigZagMult" || monster[num].name == "MonsterZigZagMultGREEN" || monster[num].name == "MonsterZigZagMultBLUE")
            {
                monstre.GetComponent<AIchaseZigZagMult>().player = player;
            }
            else if (monster[num].name == "MonsterBouclesMultORANGE" || monster[num].name == "MonsterBouclesMultPURPLE" || monster[num].name == "MonsterBouclesMultYELLOW"
                     || monster[num].name == "MonsterBouclesMult" || monster[num].name == "MonsterBouclesMultGREEN" || monster[num].name == "MonsterBouclesMultBLUE")
            {
                monstre.GetComponent<AIchaseBouclesMult>().player = player;
            }
            else
            {
                monstre.GetComponent<AIchaseLegereBoucleMult>().player = player;
            }
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
            if (player.GetComponent<PlayerHealthMult>().spriteRenderer.sprite != DeadSprite)
                Start();
        }
    }
    
}

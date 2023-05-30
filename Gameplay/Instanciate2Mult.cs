using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class Instanciate2Mult : NetworkBehaviour
{
    public GameObject[] monster;
    private GameObject monstre = null;
    public Sprite DeadSprite;
    private float place;
    public Transform player;
    private string[] monstercolor;
    public GameObject color;
    private bool waited = false;
    private NetworkObject m_SpawnedNetworkObject;
    
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator waiter()
        {
            yield return new WaitForSecondsRealtime(1);
            waited = true;
        }
        StartCoroutine(waiter());
    }

    void Spawn()
    {
        int num = Random.Range(0, 9);
        place = Random.Range((float)-8.0, (float)8.0);
        while (place<4 && place>-4)
            place = Random.Range((float)-8.0, (float)8.0);

        if (IsServer)
        {
            
            monstre = Instantiate(monster[num], new Vector3(place, 5, 0), Quaternion.identity);
            
            if (monster[num].name == "MonsterZigZagMultORANGE" || monster[num].name == "MonsterZigZagMultPURPLE" || monster[num].name == "MonsterZigZagMultYELLOW" 
                || monster[num].name == "MonsterZigZagMult" || monster[num].name == "MonsterZigZagMultGREEN" || monster[num].name == "MonsterZigZagMultBLUE")
            {
                monstre.GetComponent<AIchaseZigZagMult>().player = player;
                monstre.GetComponent<AIchaseZigZagMult>().color = color;
            }
            else if (monster[num].name == "MonsterBouclesMultORANGE" || monster[num].name == "MonsterBouclesMultPURPLE" || monster[num].name == "MonsterBouclesMultYELLOW"
                     || monster[num].name == "MonsterBouclesMult" || monster[num].name == "MonsterBouclesMultGREEN" || monster[num].name == "MonsterBouclesMultBLUE")
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
        else
        {
            return;
        }
        
        m_SpawnedNetworkObject = monstre.GetComponent<NetworkObject>();
        m_SpawnedNetworkObject.Spawn();
        waited = true;
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
            if (player.GetComponent<PlayerHealthMult>().spriteRenderer.sprite != DeadSprite && waited)
                Spawn();
        }
    }
    
    [ServerRpc]
    private void SpawnServerRpc()
    {
        m_SpawnedNetworkObject.Spawn();
    }
}

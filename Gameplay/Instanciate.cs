using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public GameObject monster;
    private GameObject monstre = null;
    public Sprite DeadSprite;
    private float place;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        place = Random.Range((float)-8.0, (float)8.0);
        while (place<4 && place>-4)
            place = Random.Range((float)-8.0, (float)8.0);
        monstre = Instantiate(monster, new Vector3(place, 5, 0), Quaternion.identity);
        monster.GetComponent<AIchase>().player = player;
         
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

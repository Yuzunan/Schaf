using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate2 : MonoBehaviour
{
    public GameObject monster;
    private GameObject monstre = null;
    public Sprite DeadSprite;
    private float place;
    public Transform player;
    private string[] monstercolor;
    public GameObject color;
    public int stage;
    private bool waited = false;
    
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
        place = Random.Range((float)-8.0, (float)8.0);
        while (place<4 && place>-4)
            place = Random.Range((float)-8.0, (float)8.0);
        monstre = Instantiate(monster, new Vector3(place, 5, 0), Quaternion.identity);
        
        int icolor = Random.Range(0, 6);
        if (stage == 1)
        {
            monstercolor = new string[]{"Red" ,"Green"};
            icolor = Random.Range(0, 2);
            monstre.GetComponent<AIchase>().speed = 2;
        }
        else if (stage == 2)
        {
            monstercolor = new string[]{"Orange","Blue"};
            icolor = Random.Range(0, 2);
            monstre.GetComponent<AIchase>().speed = 3;
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
        monstre.GetComponent<AIchase>().monstercolor = monstercolor[icolor];
        monstre.GetComponent<AIchase>().player = player;
        monstre.GetComponent<AIchase>().color = color;
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
            if (player.GetComponent<PlayerHealth>().spriteRenderer.sprite != DeadSprite && waited)
                Spawn();
        }
    }
    
}

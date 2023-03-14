using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public GameObject monster;
    private GameObject monstre = null;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
         monstre = Instantiate(monster, new Vector3(-7, 4, 0), Quaternion.identity);
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
    }
}

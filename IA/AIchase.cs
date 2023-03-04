using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIchase : MonoBehaviour
{
    public Transform player;
    private float distance;
    public float speed;
    public float spurt;
    public float distanceSpurt;
    public bool activate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            distance = Vector2.Distance(player.position, transform.position);

            Vector2 direction = player.transform.position - transform.position;
            transform.position =
                Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (spurt >= 0)
            {
                if (distance < distanceSpurt)
                {
                    speed += spurt;
                    spurt = 0;
                    if (distance < 1.5)
                    {
                        player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(1);
                        activate = false;
                    }
                    
                }
            }
        }
        else
        {
            IEnumerator waiter()
            {
                yield return new WaitForSecondsRealtime(2);
                this.GameObject().SetActive(false);
            }
            StartCoroutine(waiter());
            
        }
    }
    

}

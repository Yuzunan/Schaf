using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject thispanel;
    public GameObject otherpanel;
    // Start is called before the first frame update
    public void SwipePanel()
    {
        thispanel.SetActive(false);
        otherpanel.SetActive(true);
    }
}

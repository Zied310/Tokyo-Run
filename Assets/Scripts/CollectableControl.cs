using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject CoinsCounter;
    public GameObject CoinsEndCounter;
    void Update()
    {
        CoinsCounter.GetComponent<Text>().text = "" + coinCount;
        CoinsEndCounter.GetComponent<Text>().text = "" + coinCount;
    }
}

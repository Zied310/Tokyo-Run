using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int dis;
    public bool addingDistance = false;
    public float DisDelay = 0.35f;
    void Update()
    {
        if(PlayerMove.canMove == true){
            if(addingDistance == false){
                addingDistance = true;
                StartCoroutine(AddingDis());
            }
        }
    }

    IEnumerator AddingDis(){
        dis += 1;
        disDisplay.GetComponent<Text>().text = "" + dis;
        disEndDisplay.GetComponent<Text>().text = "" + dis;
        yield return new WaitForSeconds(DisDelay);
        addingDistance = false;
    }
}

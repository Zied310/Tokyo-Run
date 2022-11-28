using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinSFX;
    void OnTriggerEnter(Collider other){
        coinSFX.Play();
        CollectableControl.coinCount+=1;
        this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playsound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource source;
    BoxCollider soundTrigger;

   private void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<BoxCollider>();
    }


    private void OnEnable()
    {
        Player.ObjetToucher += Son;
    }


    private void OnDisable()
    {
        Player.ObjetToucher -= Son;
    }

    private void Son()
    {
        source.Play();
    }


}

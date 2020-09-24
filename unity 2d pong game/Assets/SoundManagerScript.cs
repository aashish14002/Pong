using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip ballHit;
    static AudioSource audioObj;
    // Start is called before the first frame update
    void Start()
    {
        ballHit = Resources.Load<AudioClip>("hit");
        audioObj = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        audioObj.PlayOneShot(ballHit);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioSource AudioSource;

    private float musicVolume = 1f;
    



    // Start is called before the first frame update
    void Start()
    {
	}
   void Update()
    {
	AudioSource.volume = musicVolume;
    }
   public void updateVolume(float volume)
    {
	musicVolume = volume;
    }
} 

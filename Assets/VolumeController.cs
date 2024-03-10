using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public float vol = 0.5f;
    public float min = 0.0f;
    public float max = 1.0f;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = vol;
    }

    void OnGUI()
    {
        GUI.Label(new Rect (790,20,100,30), "Volume");
        vol = GUI.HorizontalSlider(new Rect (850,25,100,30), vol, min, max);
    }
}

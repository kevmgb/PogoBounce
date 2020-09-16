using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    private ParticleSystem particleSys;

    public float FillSpeed = 0.5f;

    private float targetProgress = 0;

    public Distance distance;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("ProgressBarParticle").GetComponent<ParticleSystem>();

    }
    // Start is called before the first frame update
    void Start()
    {
        //MaxValue = 10f;
        //IncrementProgress(0.75f);

        slider.maxValue = distance.distance_to_exit;

        Debug.Log("Max slider value: " + distance.distance_to_exit);

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
            if (!particleSys.isPlaying)
                particleSys.Play();
        }
        else
        {
            particleSys.Stop();
        }
        
    }

    // we are assuming value is between 0 and 1
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

}

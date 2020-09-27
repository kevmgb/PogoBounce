using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableMvmntTurorial : MonoBehaviour
{
    float restartDelay = 5f;

    public GameObject mvmntTutorial;

    // Start is called before the first frame update

    private void Start()
    {
        DisableMvmntTutorial();
    }

    void DisableMvmntTutorialDelay()
    {
        mvmntTutorial.SetActive(false);
    }

    public void DisableMvmntTutorial()
    {
      Invoke("DisableMvmntTutorialDelay", restartDelay);    
    }
}

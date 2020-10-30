using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUsButton : MonoBehaviour
{
    public void RateButton()
    {
        Application.OpenURL("market://details?id=com.SymbolsInteractive.PogoBounce");
    }
}

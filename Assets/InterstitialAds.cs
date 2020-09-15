using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour
{

    string GooglePlay_ID = "3823141";
    bool TestMode = true;

    void Start()
    {
        // Initialize the Ads service:
        Advertisement.Initialize(GooglePlay_ID, TestMode);
    }

    public void DisplayInterstitialAds()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            Debug.Log("Displaying interstitial ad");
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
}
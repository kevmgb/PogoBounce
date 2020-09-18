using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAdsScript : MonoBehaviour
{

    string GooglePlay_ID = "3823141";
    bool TestMode = true;

    public RespawnPlayer respawn;

    //string myPlacementId = "rewardedVideo";

    string interstitialAd = "video";

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GooglePlay_ID, TestMode);

        //Check if ads are ready and return bool
       // OnUnityAdsReady(myPlacementId);
    }

    // Update is called once per frame


    public void DisplayInterstitialAds()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(interstitialAd))
        {
            Advertisement.Show(interstitialAd);
            Debug.Log("Displaying interstitial ad");
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }

    //public void DisplayVideoAd()
    //{
    //    // Check if UnityAds ready before calling Show method:
    //    if (Advertisement.IsReady(myPlacementId))
    //    {
    //        Advertisement.Show(myPlacementId);
    //    }
    //    else
    //    {
    //        Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
    //    }
    //}
    //// Implement IUnityAdsListener interface methods:
    //public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    //{
    //    if (placementId == myPlacementId)
    //    {
    //        // Define conditional logic for each ad completion status:
    //        if (showResult == ShowResult.Finished)
    //        {
    //            // Reward the user for watching the ad to completion.
    //            respawn.RespawnPlayerFunc();
    //            Debug.Log("The player watched an ad, give them a reward.");

    //        }
    //        else if (showResult == ShowResult.Skipped)
    //        {
    //            // Do not reward the user for skipping the ad.
    //            Debug.Log("The player skipped the ad.");

    //        }
    //        else if (showResult == ShowResult.Failed)
    //        {
    //            Debug.LogWarning("The ad did not finish due to an error.");
    //        }
    //    }
    //}

    //public void OnUnityAdsReady(string placementId)
    //{
    //    // If the ready Placement is rewarded, show the ad:
    //    if (placementId == myPlacementId)
    //    {
    //        // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
    //        Debug.LogWarning("Ad is ready to play");
    //    }
    //}

    //public void OnUnityAdsDidError(string message)
    //{
    //    // Log the error.
    //    Debug.LogWarning("Error fetching ads");
    //}

    //public void OnUnityAdsDidStart(string placementId)
    //{
    //    // Optional actions to take when the end-users triggers an ad.
    //    Debug.Log("Ad is now playing");
    //}

    //// When the object that subscribes to ad events is destroyed, remove the listener:

    //// COmmenting this out is what caused the game over ui to not be disable in next level
    //public void OnDestroy()
    //{
    //    Advertisement.RemoveListener(this);
    //}
}

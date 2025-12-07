using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
//using AppodealStack.Monetization.Api;
//using AppodealStack.Monetization.Common;
#endif

public class Advertising : MonoBehaviour
#if UNITY_ANDROID
    , IRewardedVideoAdListener
#endif
{
    public System.Action onVideoClosed;

    public static int countGameSession = 1;

    private void Start()
    {
        #if UNITY_ANDROID
        Appodeal.disableLocationPermissionCheck();
        Appodeal.setAutoCache(Appodeal.REWARDED_VIDEO, false);
        Appodeal.initialize("9cb0c515be3554c7fe8f2cb02e5b54e554d20c1865ec0868", Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
        Appodeal.setRewardedVideoCallbacks(this);
#endif
    }

    public static void ShowVideoAd()
    {
        if (PlayerPrefs.HasKey("removeads"))
        {
            return;
        }

        countGameSession++;
        if (countGameSession >= 1)
        {
#if UNITY_ANDROID
            if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            {
                Appodeal.show(Appodeal.REWARDED_VIDEO);
                countGameSession = 1;
            }
            else if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            {
                Appodeal.show(Appodeal.INTERSTITIAL);
                countGameSession = 1;
            }

            Appodeal.cache(Appodeal.REWARDED_VIDEO);
#endif
            
        }
    }

    public void onRewardedVideoLoaded(bool precache)
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoShowFailed()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoShown()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoClosed(bool finished)
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoExpired()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoClicked()
    {
        throw new System.NotImplementedException();
    }
}

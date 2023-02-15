using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobMainScene : MonoBehaviour
{
     private InterstitialAd intersitional;
    private string appId="ca-app-pub-4962234576866611~2596048994";
    private string intersitionalId="ca-app-pub-4962234576866611/3893673397";
    void Start(){
        MobileAds.Initialize(appId);
        RequestConfigurationAd();
        
    }

     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }


      void RequestConfigurationAd(){
          intersitional=new InterstitialAd(intersitionalId);
          AdRequest request=AdRequestBuild();
          intersitional.LoadAd(request);

          intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
          intersitional.OnAdOpening+=this.HandleOnAdOpening;
          intersitional.OnAdClosed+=this.HandleOnAdClosed;

      }


      public bool showIntersitionalAd(){
          if(intersitional.IsLoaded()){
              intersitional.Show();

              return true;
          }

          return false;
      }

      private void OnDestroy(){
          DestroyIntersitional();

          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

      }

      private void HandleOnAdClosed(object sender, EventArgs e)
      {
          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

            RequestConfigurationAd();

        
      }

      private void HandleOnAdOpening(object sender, EventArgs e)
    {
        
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        
    }

 

     public void DestroyIntersitional(){
         intersitional.Destroy();
     }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Events;
public class Google_Sign_In_Script : MonoBehaviour {
    /* Pakai yg ini
    
    public void Cli_Start() {
      // PlayGamesPlatform.Activate();
      // PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
      PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
      // enables saving game progress.
      .EnableSavedGames()
      .RequestEmail()

      .RequestServerAuthCode(false)
      /// You need to request the Email before asking for it
      .AddOauthScope("email")

      .RequestIdToken()
      
      .Build(); 
      // .RequestEmail()
      PlayGamesPlatform.InitializeInstance(config);
      PlayGamesPlatform.DebugLogEnabled = true;
      PlayGamesPlatform.Activate();

      PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(bool status) {
      Debug.Log("Login with Google done. Email: " + ((PlayGamesLocalUser)Social.localUser).Email);
       Debug.Log("Login with Google done. IdToken: " + ((PlayGamesLocalUser)Social.localUser).GetIdToken());
      if (status == true) { // SignInStatus.Success
        Debug.Log("Success login");
        Login_Canvas.Ins.Sign_In_Success_Img.gameObject.SetActive (true);
        // Continue with Play Games Services
      } else {
        Debug.Log("Unsuccessful login");
        Login_Canvas.Ins.Sign_In_Failed_Img.gameObject.SetActive (true);
        // Disable your integration with Play Games Services or show a login button
        // to ask users to sign-in. Clicking it should call
        // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
      }
    }
    */

    /*
    void Start () {
        InitializePlayGamesLogin ();
    }

    void InitializePlayGamesLogin()
    {
        var config = new PlayGamesClientConfiguration.Builder()
            // Requests an ID token be generated.  
            // This OAuth token can be used to
            // identify the player to other services such as Firebase.
            .RequestIdToken()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Debug.Log ("Google_1");
    }

    public void LoginGoogle()
    {
        Login_Canvas.Ins.Sign_In_Success_Img.gameObject.SetActive (false);
        Login_Canvas.Ins.Sign_In_Success_Img.gameObject.SetActive (false);
        Social.localUser.Authenticate(OnGoogleLogin);
        Debug.Log ("Google_2");
    }

    void OnGoogleLogin(bool success)
    {
        if (success)
        {
            // Call Unity Authentication SDK to sign in or link with Google.
            Debug.Log("Login with Google done. IdToken: " + ((PlayGamesLocalUser)Social.localUser).GetIdToken());
            Login_Canvas.Ins.Sign_In_Success_Img.gameObject.SetActive (true);
            InitializePlayGamesLogin ();
        }
        else
        {
            Debug.Log("Unsuccessful login");
            Login_Canvas.Ins.Sign_In_Failed_Img.gameObject.SetActive (true);
            InitializePlayGamesLogin ();
        }
    }
    */

}

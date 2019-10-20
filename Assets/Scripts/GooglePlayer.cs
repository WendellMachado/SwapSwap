using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayer : MonoBehaviour
{
    PlayGamesClientConfiguration config;

    [SerializeField]
    Text privacyPolicy;

    void DeletePolicy()
    {
        privacyPolicy.text = string.Empty;
    }

    void Awake()
    {
        SetUpGooglePlatform();
    }

    void Start ()
    {
        ConectToGoogle();
        Invoke("DeletePolicy", 5);
	}

    void SetUpGooglePlatform()
    {
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }

    public void PostScore(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_swap_swap, (bool success) =>
        {

        }
        );
    }

    public void ShowRanking()
    {
        if (!Social.localUser.authenticated)
        {
            print("n conectado");
        }
        else
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_swap_swap);
        }
    }

    public void ShowAchievements()
    {
        if (!Social.localUser.authenticated)
        {
            print("n conectado");
        }
        else
        {
            Social.ShowAchievementsUI();
        }
    }

    public void Achievements(int value)
    {
        /*switch (value)
        {
            case 5:  Social.ReportProgress(GPGSIds.achievement_novice, 100.0f, (bool success) =>
            {   }   );
                    break;
            case 25:
                Social.ReportProgress(GPGSIds.achievement_apprentice, 100.0f, (bool success) =>
                { });
                break;

            case 50:
                Social.ReportProgress(GPGSIds.achievement_jorneyman, 100.0f, (bool success) =>
                { });
                break;

            case 75:
                Social.ReportProgress(GPGSIds.achievement_expert, 100.0f, (bool success) =>
                { });
                break;

            case 100:
                Social.ReportProgress(GPGSIds.achievement_master, 100.0f, (bool success) =>
                { });
                break;

            case 0:
                Social.ReportProgress(GPGSIds.achievement_regrettable, 100.0f, (bool success) =>
                { });
                break;
        }*/
    }

    void ConectToGoogle()
    {
        Social.localUser.Authenticate((bool success) =>
        {

        });
    }
}

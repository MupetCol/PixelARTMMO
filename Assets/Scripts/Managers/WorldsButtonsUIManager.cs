using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldsButtonsUIManager : MonoBehaviour
{
    public GameObject favorite, recent, day;
    private Button favoriteWorldButton, recentWorldButton, dayWorldButton;
    private Animator favButtonAnimator, recButtonAnimator, dayButtonAnimator;
    void Start()
    {
        favoriteWorldButton = favorite.GetComponent<Button>();
        recentWorldButton = recent.GetComponent<Button>();
        dayWorldButton = day.GetComponent<Button>();

        favButtonAnimator = favorite.GetComponent<Animator>();
        recButtonAnimator = recent.GetComponent<Animator>();
        dayButtonAnimator = day.GetComponent<Animator>();


        favoriteWorldButton.onClick.AddListener(FavoriteWorldUI);
        recentWorldButton.onClick.AddListener(RecentWorldUI);
        dayWorldButton.onClick.AddListener(DayWorldUI);
    }

    void FavoriteWorldUI()
    {
        favButtonAnimator.SetBool("Selected", true);
        recButtonAnimator.SetBool("Selected", false);
        dayButtonAnimator.SetBool("Selected", false);

    }

    void RecentWorldUI()
    {
        recButtonAnimator.SetBool("Selected", true);
        favButtonAnimator.SetBool("Selected", false);
        dayButtonAnimator.SetBool("Selected", false);
    }

    void DayWorldUI()
    {
        dayButtonAnimator.SetBool("Selected", true);
        recButtonAnimator.SetBool("Selected", false);
        favButtonAnimator.SetBool("Selected", false);
    }


}

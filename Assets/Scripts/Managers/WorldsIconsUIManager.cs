using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldsIconsUIManager: MonoBehaviour
{
    public GameObject favIcon, recIcon, dayIcon;
    public Button favoriteWorldButton, recentWorldButton, dayWorldButton;
    private Animator favAnimator, recAnimator, dayAnimator;
    // Start is called before the first frame update
    void Start()
    {
        favAnimator = favIcon.GetComponent<Animator>();
        recAnimator = recIcon.GetComponent<Animator>();
        dayAnimator = dayIcon.GetComponent<Animator>();

        favoriteWorldButton.onClick.AddListener(FavoriteWorldUI);
        recentWorldButton.onClick.AddListener(RecentWorldUI);
        dayWorldButton.onClick.AddListener(DayWorldUI);

    }

    void FavoriteWorldUI()
    {
        favAnimator.SetBool("Selected", true);
        recAnimator.SetBool("Selected", false);
        dayAnimator.SetBool("Selected", false);
    }

    void RecentWorldUI()
    {
        recAnimator.SetBool("Selected", true);
        dayAnimator.SetBool("Selected", false);
        favAnimator.SetBool("Selected", false);
    }

    void DayWorldUI()
    {
        dayAnimator.SetBool("Selected", true);
        recAnimator.SetBool("Selected", false);
        favAnimator.SetBool("Selected", false);

    }
}

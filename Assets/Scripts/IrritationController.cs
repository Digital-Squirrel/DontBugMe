using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IrritationController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float irritationIncrement = .1f;
    [SerializeField] GameObject uiPanel, deathText, irritatedText, offWorldText, successText, controlsText, tryAgainButton, BackToMainButton;

    private void Start()
    {
        UIEvents.current.onIncreaseIrritation += OnUpdateIrritationLevel;
        UIEvents.current.onTriggerIrritated += TriggerIrritated;
        UIEvents.current.onKillPlayer += KillPlayer;
        UIEvents.current.onFallOffWorld += TriggerOffWorld;
        UIEvents.current.onHideControls += HideControls;
        UIEvents.current.onTriggerSuccess += ShowSuccess;
    }

    private void OnUpdateIrritationLevel()
    {       
        slider.GetComponent<Slider>().value += irritationIncrement;
    }

    private void TriggerIrritated()
    {
        ToggleUIPanel();
        if (irritatedText != null) irritatedText.SetActive(true);
        EnableTryAgainButton();
    }

    private void ToggleUIPanel()
    {
        if (uiPanel != null) uiPanel.SetActive(!uiPanel.activeSelf);
    }


    private void EnableTryAgainButton()
    {
        if(tryAgainButton != null) tryAgainButton.SetActive(true);
    }

    private void KillPlayer()
    {
        ToggleUIPanel();
        if (deathText != null) deathText.SetActive(true);
        EnableTryAgainButton();
    }

    private void TriggerOffWorld()
    {
        ToggleUIPanel();
        if (offWorldText != null) offWorldText.SetActive(true);
        EnableTryAgainButton();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void HideControls()
    {
        ToggleUIPanel();
        if (controlsText != null) controlsText.SetActive(false);
    }

    private void ShowSuccess()
    {
        ToggleUIPanel();
        if (successText != null) successText.SetActive(true);
        if (BackToMainButton != null) BackToMainButton.SetActive(true);
    }
}

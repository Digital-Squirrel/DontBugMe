using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    // Create singleton
    public static UIEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onIncreaseIrritation;
    public event Action onKillPlayer;
    public event Action onTriggerIrritated;
    public event Action onFallOffWorld;
    public event Action onTriggerSuccess;
    public event Action onHideControls;

    public void IncreaseIrritationLevel()
    {
        if (onIncreaseIrritation != null) onIncreaseIrritation();
    }

    public void KillPlayer()
    {
        if (onKillPlayer != null) onKillPlayer();

    }

    public void TriggerIrritated()
    {
        if (onTriggerIrritated != null) onTriggerIrritated();

    }

    public void FallOffWorld()
    {
        if (onFallOffWorld != null) onFallOffWorld();
    }

    public void TriggerSuccess()
    {
        if (onTriggerSuccess != null) onTriggerSuccess();
    }

    public void HideControls()
    {
        if (onHideControls != null) onHideControls();
    }
}

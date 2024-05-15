using UnityEngine;
using UnityEngine.Events;

public class ConstructionModeButton : MonoBehaviour
{
    private ConstructionModeStatus _constructionModeStatus;


    public UnityEvent PlayerEnterInConstructionMode;
    public UnityEvent PlayerExitFromConstructionMode;


    private enum ConstructionModeStatus
    {
        Disabled = 0,
        Enabled = 1,
    }


    private void Start()
    {
        _constructionModeStatus = ConstructionModeStatus.Disabled;
        PlayerExitFromConstructionMode?.Invoke();
    }


    public void ClickOn()
    {
        switch (_constructionModeStatus)
        {
            case ConstructionModeStatus.Disabled:
                EnableClick();
                return;
            case ConstructionModeStatus.Enabled:
                DisableClick();
                break;
        }
    }

    public void DisableClick()
    {
        _constructionModeStatus = ConstructionModeStatus.Disabled;
        PlayerExitFromConstructionMode?.Invoke();
        
    }
    public void EnableClick()
    {
        _constructionModeStatus = ConstructionModeStatus.Enabled;
        PlayerEnterInConstructionMode?.Invoke();
    }
}

using UnityEngine;

public abstract class BaseScreenController<TView> : MonoBehaviour where TView : BaseScreenView
{
    protected TView _view;

    protected void Awake()
    {
        _view = GetComponent<TView>();
        _view.Init();
    }
}

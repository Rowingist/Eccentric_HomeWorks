using UnityEngine;

public class PlaneWalletSetup : MonoBehaviour
{
    [SerializeField] private ClampedAmountWithIconPlane _view;

    private PlaneWallet _model;
    private PlaneWalletPresenter _presenter;

    public int Coins => _model.Coins;

    private void Awake()
    {
        _model = new PlaneWallet();
        _presenter = new PlaneWalletPresenter(_model, _view);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
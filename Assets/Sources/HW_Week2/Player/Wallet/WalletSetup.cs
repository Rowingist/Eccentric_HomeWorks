using UnityEngine;

public class WalletSetup : MonoBehaviour
{
    [SerializeField] private ClampedAmountWithIcon _view;

    private Wallet _model;
    private WalletPresenter _presenter;

    public int Coins => _model.Coins;

    private void Awake()
    {
        _model = new Wallet();
        _presenter = new WalletPresenter(_model, _view);
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
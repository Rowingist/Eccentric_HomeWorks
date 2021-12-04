public class PlaneWalletPresenter
{
    private readonly ClampedAmountWithIconPlane _view;
    private readonly PlaneWallet _model;

    public PlaneWalletPresenter(PlaneWallet model, ClampedAmountWithIconPlane view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _model.CoinsChanged += OnCoinChanged;
        _view.CoinCollected += OnCollected;
    }

    public void Disable()
    {
        _model.CoinsChanged -= OnCoinChanged;
        _view.CoinCollected -= OnCollected;
    }

    private void OnCoinChanged()
    {
        _view.SetAmount(_model.Coins);
    }

    private void OnCollected()
    {
        _model.AddCoin();
        OnCoinChanged();
    }
}
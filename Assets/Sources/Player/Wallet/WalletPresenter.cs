public class WalletPresenter
{
    private readonly ClampedAmountWithIcon _view;
    private readonly Wallet _model;

    public WalletPresenter(Wallet model, ClampedAmountWithIcon view)
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
        _view.SetAmount(_model.Coins, _model.MaxCoins);
    }

    private void OnCollected()
    {
        _model.AddCoin();
        OnCoinChanged();
    }
}
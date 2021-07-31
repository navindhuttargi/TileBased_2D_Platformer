public interface IScoreHandler
{
    void Initialize(int total);
    void CollectCoin();
    int TotalCoinsCollected();
    bool CheckForGameWin();
}

public interface IBulletPool
{
    void InitializePool(Bullet bulletPrefab, int length);
    Bullet GetAvailableBullet();
}

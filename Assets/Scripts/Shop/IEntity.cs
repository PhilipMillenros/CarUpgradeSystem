public interface IEntity
{
    public float Experience { get; set; }
    public void TakeDamage(float damage, IEntity sender);
    public void OnDeath();
}
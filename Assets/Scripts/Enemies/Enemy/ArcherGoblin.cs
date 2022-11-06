using Enemies;

public class ArcherGoblin : Enemy
{
    private void Awake()
    {
        Init(EnemiesStats.AnyGoblin.ArcherGoblin);
    }
}

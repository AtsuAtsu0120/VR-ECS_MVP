using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
	protected override void Configure(IContainerBuilder builder)
	{
		builder.RegisterEntryPoint<SpawnEnemyPresenter>();
		builder.RegisterSystemFromDefaultWorld<SpawnEnemySystem>();
		builder.Register<Model>(Lifetime.Singleton);
	}
}

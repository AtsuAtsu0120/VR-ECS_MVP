using UniRx;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

public partial class SpawnEnemySystem : SystemBase
{
	public ReactiveCollection<Enemy> enemies = new();
	[BurstCompile]
	protected override void OnCreate()
	{

	}
	[BurstCompile]
	protected override void OnUpdate()
	{
		var cmb = World.GetOrCreateSystemManaged<BeginSimulationEntityCommandBufferSystem>().CreateCommandBuffer();

		foreach (var (spawnData, _, entity) in SystemAPI.Query<SpawnData, SpawnTag>().WithEntityAccess())
		{
			cmb.Instantiate(spawnData.prefab);
			cmb.RemoveComponent(entity, typeof(SpawnTag));
		}
	}
	[BurstCompile]
	public void SpawnEnemy()
	{
		var entity = SystemAPI.GetSingletonEntity<PlayerTag>();
		EntityManager.AddComponent(entity, typeof(SpawnTag));
	}
}

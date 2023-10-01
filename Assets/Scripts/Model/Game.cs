using System;
using UniRx;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

public class Game
{
	public float remainingTime;
	public ReactiveCollection<Enemy> enemies = new();
	internal Game()
	{
		remainingTime = 1000f;

		var enemyTimer = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(10))
			.Subscribe(x =>
			{
				var enemy = StartSpawnEnemyJob();
				enemies.Add(enemy);
			});
	}
	internal Enemy StartSpawnEnemyJob()
	{
		var result = new NativeArray<EnemyStruct>(1, Allocator.TempJob);
		var job = new SpawnEnemyJob { result = result }.Schedule();

		JobHandle.ScheduleBatchedJobs();

		job.Complete();

		return result[0];
	}
}
[BurstCompile]
internal struct SpawnEnemyJob : IJob
{
	public NativeArray<EnemyStruct> result;
	public void Execute()
	{
		var hp = new Random(200).NextInt(1, 100);
		var stlength = new Random(300).NextInt(1, 100);

		result[0] = new(hp, stlength);
	}
}

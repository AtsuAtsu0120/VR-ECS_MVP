using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UniRx;

public class SpawnEnemyPresenter : IInitializable
{
	public Model model;
	public SpawnEnemySystem system;

	[Inject]
	public SpawnEnemyPresenter(Model model, SpawnEnemySystem system)
	{
		this.model = model;
		this.system = system;
	}

	public void Initialize()
	{
		model.gameMaster.game.enemies.ObserveAdd().Subscribe(item => system.enemies.Add(item.Value));
		system.enemies.ObserveAdd().Subscribe(_ => system.SpawnEnemy());
	}
}

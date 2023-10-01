using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnDataAuthoring : MonoBehaviour
{
	public GameObject prefab;
	public class SpawnDataBaker : Baker<SpawnDataAuthoring>
	{
		public override void Bake(SpawnDataAuthoring authoring)
		{
			var entity = GetEntity(TransformUsageFlags.None);
			AddComponent(entity, new SpawnData
			{
				prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic)
			});
		}
	}
}

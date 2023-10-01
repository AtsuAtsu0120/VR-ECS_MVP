using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.VisualScripting.YamlDotNet.Core;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour 
{
	public class Authoring : Baker<PlayerAuthoring>
	{
		public override void Bake(PlayerAuthoring authoring)
		{
			var entity = GetEntity(TransformUsageFlags.None);
			AddComponent(entity, new PlayerTag());
		}
	}
}

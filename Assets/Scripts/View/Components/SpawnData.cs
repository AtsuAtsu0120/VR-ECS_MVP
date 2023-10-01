using Unity.Entities;

public struct SpawnTag : IComponentData
{

}
public struct SpawnData : IComponentData
{
	public Entity prefab;
}

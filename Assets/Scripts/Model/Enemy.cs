using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{
	public int hp;
	public int stlength;

	public Enemy(int hp, int stlength)
	{
		this.hp = hp;
		this.stlength = stlength;
	}

	public static implicit operator EnemyStruct(Enemy enemyStruct)
	{
		return new(enemyStruct.hp, enemyStruct.stlength);
	}

}
public struct EnemyStruct
{
	public int hp;
	public int stlength;
	
	public EnemyStruct(int hp, int stlength)
	{
		this.hp = hp;
		this.stlength = stlength;
	}

	public static implicit operator Enemy(EnemyStruct enemyStruct)
	{
		return new(enemyStruct.hp, enemyStruct.stlength);
	}
}

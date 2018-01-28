using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene
{
	public enum RPS
	{
		Rock,
		Paper,
		Scissors,
		Zero
	};

	public enum Strength
	{
		Small,
		Medium,
		Big
	};

	RPS rpsValue;
	Strength strValue;

	public Gene(RPS rps, Strength str)
	{
		rpsValue = rps;
		strValue = str;
	}

	/**
	 * returns -1 if the current gene is stronger than the new one;
	 * returns 0 if both genes are of equal strength;
	 * returns 1 if the new gene is stronger than the old one.
	 */
	public static int Equals(Gene currentGene, Gene newGene)
	{
		if (newGene.RpsValue == Gene.RPS.Zero)
		{
			return -1; //the new gene is neutral and is weaker than any other.
		}
		else if (currentGene.RpsValue == Gene.RPS.Zero)
		{
			return 1; //the old gene is neutral and is weaker than any other
		}
		else if (currentGene.RpsValue == newGene.RpsValue)
		{
            return 0; //both genes have the same values and are of equal strength.
                      //both gene types are the same; their strengths are compared.
            /*if (currentGene.StrValue == newGene.StrValue)
			{
				
			}
			else if (newGene.StrValue == Gene.Strength.Big)
			{
				return 1; //the new gene is big and the old gene is small or medium; the new gene is stronger.
			}
			else if (newGene.StrValue == Gene.Strength.Medium)
			{
				if (currentGene.StrValue == Gene.Strength.Small)
				{
					return 1; //the new gene is medium and the old gene is small; the new gene is stronger
				}
				else
				{
					return -1; //the new gene is medium and the old gene is big; the old gene is stronger.
				}
			}
			else
			{
				//the new gene is small
				return -1; //the new gene is small and the old gene is medium or big; the old gene is stronger.
			}*/
		}
		else
		{
			//gene types are different; the strengths are ignored and the types are compred
			if (newGene.RpsValue == Gene.RPS.Rock && currentGene.RpsValue == Gene.RPS.Scissors)
			{
				return 1; //rock beats scissors; the new gene is stronger.
			}
			else if (newGene.RpsValue == Gene.RPS.Scissors && currentGene.RpsValue == Gene.RPS.Paper)
			{
				return 1; //scissors beat paper; the new gene is stronger.
			}
			else if (newGene.RpsValue == Gene.RPS.Paper && currentGene.RpsValue == Gene.RPS.Rock)
			{
				return 1; //paper beats rock; the new gene is stronger.
			}
			else
			{
				return -1; //the old gene is stronger.
			}
		}

	}

	public RPS RpsValue
	{
		get { return rpsValue; }
		set { rpsValue = value; }
	}

	public Strength StrValue
	{
		get { return strValue; }
		set { strValue = value; }
	}

	public float StrengthToScale()
	{
		switch (StrValue)
		{
			case Strength.Small:
				return 0.5f;
			case Strength.Medium:
				return 1f;
			case Strength.Big:
				return 2.0f;
			default:
				return 1f;
		}
	}

}

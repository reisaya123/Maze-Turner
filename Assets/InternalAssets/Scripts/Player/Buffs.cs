using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public int buffPoints = 5;
    int duration = 10;

    public IEnumerator IncreaseMovingSpeed(Player player)
    {
        int count = 0;
        int newDuration = duration;
        if (!player.buffs.Contains("IncreaseMovingSpeed"))
        {
            player.buffs.Add("IncreaseMovingSpeed"); //Add UI
            player.animalSelected.moveSpeed += buffPoints;
        }
        else
        {
            newDuration += duration;
        }

        while (true)
        {
            if (count == newDuration)
            {
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }

    }
    public IEnumerator IncreaseDamage(Player player)
    {
        int count = 0;
        int newDuration = duration;
        if (!player.buffs.Contains("IncreaseDamage"))
        {
            player.buffs.Add("IncreaseDamage"); //Add UI
            player.animalSelected.baseDamage += buffPoints;
        }
        else
        {
            newDuration += duration;
        }



        while (true)
        {
            if (count == newDuration)
            {
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator DecreaseMovingSpeed(Player player)
    {
        int count = 0;
        int newDuration = duration;
        if (!player.buffs.Contains("DecreaseMovingSpeed"))
        {
            player.buffs.Add("DecreaseMovingSpeed"); //Add UI
            player.animalSelected.moveSpeed -= buffPoints;
        }
        else
        {
            newDuration += duration;
        }

        while (true)
        {
            if (count == newDuration)
            {
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public IEnumerator DecreaseDamage(Player player)
    {
        int count = 0;
        int newDuration = duration;
        if (!player.buffs.Contains("DecreaseDamage"))
        {
            player.buffs.Add("DecreaseDamage"); //Add UI
            player.animalSelected.baseDamage -= buffPoints;
        }
        else
        {
            newDuration += duration;
        }

        while (true)
        {
            if (count == newDuration)
            {
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}

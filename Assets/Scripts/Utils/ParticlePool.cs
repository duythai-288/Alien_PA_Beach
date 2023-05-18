using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool
{
    int particleAmount;
    ParticleSystem[] GoldParticle;

    public ParticlePool(ParticleSystem normalPartPrefab, int amount = 10)
    {
        particleAmount = amount;
        GoldParticle = new ParticleSystem[particleAmount];

        for (int i = 0; i < particleAmount; i++)
        {
            GoldParticle[i] = GameObject.Instantiate(normalPartPrefab, new Vector3(0, 0, 0), new Quaternion()) as ParticleSystem;
        }
    }

    public ParticleSystem GetAvailabeParticle()
    {
        ParticleSystem firstObject = null;
        firstObject = GoldParticle[0];
        ShiftUp();
        return firstObject;
    }

    public int GetAmount()
    {
        return particleAmount;
    }

    private void ShiftUp()
    {
        ParticleSystem firstObject;
        firstObject = GoldParticle[0];
        Array.Copy(GoldParticle, 1, GoldParticle, 0, GoldParticle.Length - 1);
        GoldParticle[GoldParticle.Length - 1] = firstObject;
    }
}

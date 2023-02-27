using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
{

    [SerializeField]private ParticleSystem [] particles;
    [SerializeField]private ParticleSystem [] constantParticles;
    public GameLogic gameLogic;
    public AsteroidController asteroidController;


    public void EndRage()
    {
        gameLogic.Ragent();
    }

    public void Eletricity()
    {
        for(int i=0; i < particles.Length; i++)
        {
            particles[i].Play();
        }
    }
    public void ConstantEletricity()
    {
        for(int i=0; i < constantParticles.Length; i++)
        {
            constantParticles[i].Play();
        }
    }

    public void AccelerateSpin()
    {
        asteroidController.RageAccelarate();
    }
    public void DecelerateSpin()
    {
        asteroidController.RageDecelarate();
    }
    public void DecelerateIdle()
    {
        asteroidController.IdleSlow();
    }
    public void AccelerateIdle()
    {
        asteroidController.IdleFast();
    }
}

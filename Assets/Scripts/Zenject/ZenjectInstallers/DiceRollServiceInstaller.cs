using Scripts.Game.Services;
using UnityEngine;
using Zenject;

public class DiceRollServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DiceRollService>().FromNew().AsSingle();
    }
}
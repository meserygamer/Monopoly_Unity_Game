using Scripts.Game.Players;
using UnityEngine;
using Zenject;

public class PlayersFactroryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerFactory>().FromComponentInHierarchy().AsSingle();
    }
}
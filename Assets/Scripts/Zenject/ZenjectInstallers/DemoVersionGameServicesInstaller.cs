using System.Collections.Generic;
using Scripts.Game.Services;
using Scripts.Game.Services.ChanceCardService;
using Scripts.Game.Services.CostOfRentServices;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class DemoVersionGameServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerMovementService>().FromNew().AsSingle();
            Container.Bind<PlayersMovesTurnService>().FromNew().AsSingle();
            Container.Bind<BankingService>().FromNew().AsSingle();
            Container.Bind<RealEstatePurchaseService>().FromNew().AsSingle();
            Container.Bind<ConstructionService>().FromNew().AsSingle();
            Container.Bind<QuestionService>().FromNew().AsSingle();

            Container.Bind<InfrastructureRentCostCalculatorService>().FromNew().AsSingle();
            Container.Bind<RailroadRentCostCalculatorService>().FromNew().AsSingle();
            Container.Bind<TangibleAssetRentCostCalculatorService>().FromNew().AsSingle();

            Container.Bind<DiceRollService>().FromFactory<DemoVersionDiceRollServiceFactory>().AsSingle();
            Container.Bind<ChanceCardService>().FromFactory<ChanceCardServiceFactory>().AsSingle();
            Container.Bind<CommunityChestCardService>().FromFactory<CommunityChestCardServiceFactory>().AsSingle();
        }


        public sealed class DemoVersionDiceRollServiceFactory : IFactory<DiceRollService>
        {
            public DiceRollService Create()
            {
                return new DiceRollService(new Queue<DiceRoll>(new DiceRoll[] 
                {
                    new DiceRoll() {FirstCameUpNumber = 1, SecondCameUpNumber = 1}, //Общественная казна 2
                    new DiceRoll() {FirstCameUpNumber = 3, SecondCameUpNumber = 1}, //Подоходный налог 4
                    new DiceRoll() {FirstCameUpNumber = 2, SecondCameUpNumber = 3}, //Станция гаусса 5
                    new DiceRoll() {FirstCameUpNumber = 4, SecondCameUpNumber = 2}, //Десятичные дроби. Сложение, вычитание 6


                    new DiceRoll() {FirstCameUpNumber = 1, SecondCameUpNumber = 2}, //Станция гаусса 5 (Демонстрация вопроса)
                    new DiceRoll() {FirstCameUpNumber = 1, SecondCameUpNumber = 1}, //Десятичные дроби. Сложение, вычитание 6 (Демонстрация вопроса)
                    new DiceRoll() {FirstCameUpNumber = 1, SecondCameUpNumber = 1}, //Шанс 7
                    new DiceRoll() {FirstCameUpNumber = 4, SecondCameUpNumber = 2}, //Электростанция 12


                    new DiceRoll() {FirstCameUpNumber = 1, SecondCameUpNumber = 4}, //Посещение тюрьмы 10
                    new DiceRoll() {FirstCameUpNumber = 4, SecondCameUpNumber = 2}, //Электростанция 12 (Демонстрация вопроса)

                    new DiceRoll() {FirstCameUpNumber = 6, SecondCameUpNumber = 6}, //Для чисел на электростанции

                    new DiceRoll() {FirstCameUpNumber = 6, SecondCameUpNumber = 3}, //1 подтема свойств степени 16
                    new DiceRoll() {FirstCameUpNumber = 6, SecondCameUpNumber = 2}, //Бесплатная стоянка 20


                    new DiceRoll() {FirstCameUpNumber = 2, SecondCameUpNumber = 4}, //1 подтема свойств степени 16 (Демонстрация вопроса)
                    new DiceRoll() {FirstCameUpNumber = 6, SecondCameUpNumber = 6}, //Последняя красная тема 24 
                    new DiceRoll() {FirstCameUpNumber = 6, SecondCameUpNumber = 6}, //Водоканал 28 
                    new DiceRoll() {FirstCameUpNumber = 5, SecondCameUpNumber = 5}, //Тюрьма 30 


                    new DiceRoll() {FirstCameUpNumber = 3, SecondCameUpNumber = 5}, //Последняя красная тема 24 (Демонстрация вопроса)
                    new DiceRoll() {FirstCameUpNumber = 1, SecondCameUpNumber = 3}, //Водоканал 28 (Демонстрация вопроса)

                    new DiceRoll() {FirstCameUpNumber = 6, SecondCameUpNumber = 6}, //Для чисел на Водоканале

                    new DiceRoll() {FirstCameUpNumber = 3, SecondCameUpNumber = 4}, //Станция эйлера 35


                    new DiceRoll() {FirstCameUpNumber = 6, SecondCameUpNumber = 5}, //Станция эйлера 35 (Демонстрация вопроса)
                    new DiceRoll() {FirstCameUpNumber = 4, SecondCameUpNumber = 4}, //Шанс 36
                    new DiceRoll() {FirstCameUpNumber = 1, SecondCameUpNumber = 2}, //Сверхналог 38

                    new DiceRoll() {FirstCameUpNumber = 2, SecondCameUpNumber = 3}, //Поле старт 40
                    new DiceRoll() {FirstCameUpNumber = 3, SecondCameUpNumber = 3}, //Общественная казна 2
                    new DiceRoll() {FirstCameUpNumber = 2, SecondCameUpNumber = 4}, //Подоходный налог
                }));
            }
        }
    }
}
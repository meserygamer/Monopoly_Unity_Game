using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Questions;

namespace Scripts.Game.GameField
{
    public class BasicGameFieldFactory
    {
        public GameBoardInfo Create()
        {
            GameBoardInfo gameBoardInfo = new GameBoardInfo();
            QuestionTheme questionTheme = new QuestionTheme("Тема №1", 1);
            QuestionSubthemeFactory questionSubthemeFactory = new QuestionSubthemeFactory();
            gameBoardInfo.GameSquares.Add(new StartGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"),
                    60,
                    new uint[] { 2, 10, 30, 90, 160, 250},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"),
                    60,
                    new uint[] { 4, 20, 60, 180, 320, 450},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(new TaxGameSquare());
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция алгебры", 200));
            questionTheme = new QuestionTheme("Тема №2", 2);
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"),
                    100,
                    new uint[] { 6, 30, 90, 270, 400, 550},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"),
                    100,
                    new uint[] { 6, 30, 90, 270, 400, 550},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"),
                    120,
                    new uint[] { 8, 40, 100, 300, 450, 600},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(new JailVisitGameSquare());
            questionTheme = new QuestionTheme("Тема №3", 3); 
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"),
                    140,
                    new uint[] { 10, 50, 150, 450, 625, 750},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(new InfrastructureGameSquare("Электричество", 150));
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"),
                    140,
                    new uint[] { 10, 50, 150, 450, 625, 750},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"),
                    160,
                    new uint[] { 12, 60, 180, 500, 700, 900},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция геометрии", 200));
            questionTheme = new QuestionTheme("Тема №4", 4);
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"),
                    180,
                    new uint[] { 14, 70, 200, 550, 700, 900},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"),
                    180,
                    new uint[] { 14, 70, 200, 550, 700, 900},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"),
                    200,
                    new uint[] { 16, 80, 220, 600, 800, 1000},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(new ParkingGameSquare());
            questionTheme = new QuestionTheme("Тема №5", 5);
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"),
                    220,
                    new uint[] { 18, 90, 250, 700, 875, 1050},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"),
                    220,
                    new uint[] { 18, 90, 250, 700, 875, 1050},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"),
                    240,
                    new uint[] { 20, 100, 300, 750, 925, 1100},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция информатики", 200));
            questionTheme = new QuestionTheme("Тема №6", 6);
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"),
                    260,
                    new uint[] { 22, 110, 330, 800, 975, 1150},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"),
                    260,
                    new uint[] { 22, 110, 330, 800, 975, 1150},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(new InfrastructureGameSquare("Водопровод", 150));
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"),
                    280,
                    new uint[] { 24, 120, 360, 850, 1025, 1200},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(new GoToJailGameSquare());
            questionTheme = new QuestionTheme("Тема №7", 7);
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"),
                    300,
                    new uint[] { 26, 130, 390, 900, 1100, 1275},
                    new uint[] { 200, 200}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"),
                    300,
                    new uint[] { 26, 130, 390, 900, 1100, 1275},
                    new uint[] { 200, 200}
                )
            );
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"),
                    320,
                    new uint[] { 28, 150, 450, 1000, 1200, 1400},
                    new uint[] { 200, 200}
                )
            );
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция физики", 200));
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            questionTheme = new QuestionTheme("Тема №8", 8);
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"),
                    350,
                    new uint[] { 35, 175, 500, 1100, 1300, 1500},
                    new uint[] { 200, 200}
                )
            );
            gameBoardInfo.GameSquares.Add(new TaxGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"),
                    400,
                    new uint[] { 50, 200, 600, 1400, 1700, 200},
                    new uint[] { 200, 200}
                )
            );
            return gameBoardInfo;
        }
    }
}
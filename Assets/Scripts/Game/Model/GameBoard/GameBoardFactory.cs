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
            QuestionTheme questionTheme = new QuestionTheme("Тема №1");
            QuestionSubthemeFactory questionSubthemeFactory = new QuestionSubthemeFactory();
            gameBoardInfo.GameSquares.Add(new StartGameSquare());
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"), 60));
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"), 60));
            gameBoardInfo.GameSquares.Add(new TaxGameSquare());
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция алгебры", 200));
            questionTheme = new QuestionTheme("Тема №2");
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"), 100));
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"), 100));
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"), 120));
            gameBoardInfo.GameSquares.Add(new JailVisitGameSquare());
            questionTheme = new QuestionTheme("Тема №3"); 
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"), 140));
            gameBoardInfo.GameSquares.Add(new InfrastructureGameSquare("Электричество", 150));
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"), 140));
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"), 160));
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция геометрии", 200));
            questionTheme = new QuestionTheme("Тема №4");
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"), 180));
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"), 180));
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"), 200));
            gameBoardInfo.GameSquares.Add(new ParkingGameSquare());
            questionTheme = new QuestionTheme("Тема №5");
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"), 220));
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"), 220));
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"), 240));
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция информатики", 200));
            questionTheme = new QuestionTheme("Тема №6");
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"), 260));
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"), 260));
            gameBoardInfo.GameSquares.Add(new InfrastructureGameSquare("Водопровод", 150));
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"), 280));
            gameBoardInfo.GameSquares.Add(new GoToJailGameSquare());
            questionTheme = new QuestionTheme("Тема №7");
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"), 300));
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"), 300));
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №3"), 320));
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция физики", 200));
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            questionTheme = new QuestionTheme("Тема №8");
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №1"), 350));
            gameBoardInfo.GameSquares.Add(new TaxGameSquare());
            gameBoardInfo.GameSquares.Add(new TangibleAssetSquare(questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Подтема №2"), 400));
            return gameBoardInfo;
        }
    }
}
using Monopoly_Unity_Game_Server.ControlThemesQuestionsGenerators;
using Monopoly_Unity_Game_Server.ThemesQuestionsGenerators;
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
            QuestionTheme questionTheme = new QuestionTheme("Устный счет", 1);
            QuestionSubthemeFactory questionSubthemeFactory = new QuestionSubthemeFactory();
            OralCountThemeQuestionsGenerator oralCountThemeQuestionsGenerator = new OralCountThemeQuestionsGenerator();
            gameBoardInfo.GameSquares.Add(new StartGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "С одним действием", oralCountThemeQuestionsGenerator.GenerateExampleWithSingleAction),
                    60,
                    new uint[] { 2, 10, 30, 90, 160, 250},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "С двумя действиями", oralCountThemeQuestionsGenerator.GenerateExampleWithDoubleAction),
                    60,
                    new uint[] { 4, 20, 60, 180, 320, 450},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(new TaxGameSquare());
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция алгебры", 200));
            questionTheme = new QuestionTheme("Десятичные дроби", 2);
            DecimalThemeQuestionsGenerator decimalThemeQuestionsGenerator = new DecimalThemeQuestionsGenerator();
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Сложение и вычитание", decimalThemeQuestionsGenerator.CalculateDecimalSimpleExampleOfAddOrSub),
                    100,
                    new uint[] { 6, 30, 90, 270, 400, 550},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Умножение и деление", decimalThemeQuestionsGenerator.CalculateDecimalSimpleExampleOfMulOrDiv),
                    100,
                    new uint[] { 6, 30, 90, 270, 400, 550},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "С двумя действиями", decimalThemeQuestionsGenerator.DecimalSimpleExampleWithTwoActions),
                    120,
                    new uint[] { 8, 40, 100, 300, 450, 600},
                    new uint[] { 50, 50}
                )
            );
            gameBoardInfo.GameSquares.Add(new JailVisitGameSquare());
            questionTheme = new QuestionTheme("Обыкновенные дроби", 3); 
            OrdinaryFractionsThemeQuestionsGenerator ordinaryFractionsThemeQuestionsGenerator = new OrdinaryFractionsThemeQuestionsGenerator();
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Пример с одинаковыми знаменателями", ordinaryFractionsThemeQuestionsGenerator.CalculateOrdinaryFractionsWithSameDenominators),
                    140,
                    new uint[] { 10, 50, 150, 450, 625, 750},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(new LightStationGameSquare("Электричество", 150));
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Пример с разными знаменателями", ordinaryFractionsThemeQuestionsGenerator.CalculateOrdinaryFractionsWithDifferentDenominators),
                    140,
                    new uint[] { 10, 50, 150, 450, 625, 750},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Пример из двух действий", ordinaryFractionsThemeQuestionsGenerator.CalculateOrdinaryFractionsWithTwoActions),
                    160,
                    new uint[] { 12, 60, 180, 500, 700, 900},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция геометрии", 200));
            questionTheme = new QuestionTheme("Степени", 4);
            DegreeThemeQuestionsGenerator degreeThemeQuestionsGenerator = new DegreeThemeQuestionsGenerator();
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Вычислить степень", degreeThemeQuestionsGenerator.CalculateDegreeWithNaturalExponent),
                    180,
                    new uint[] { 14, 70, 200, 550, 700, 900},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Свойства степени", degreeThemeQuestionsGenerator.CalculateDegreeProperties),
                    180,
                    new uint[] { 14, 70, 200, 550, 700, 900},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Свойства степеней с целым показателем", degreeThemeQuestionsGenerator.CalculateDegreeWith0andNegativeExponentProperties),
                    200,
                    new uint[] { 16, 80, 220, 600, 800, 1000},
                    new uint[] { 100, 100}
                )
            );
            gameBoardInfo.GameSquares.Add(new ParkingGameSquare());
            questionTheme = new QuestionTheme("Корни", 5);
            RootQuestionThemeQuestionsGenerator rootQuestionThemeQuestionsGenerator = new RootQuestionThemeQuestionsGenerator();
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Вычислить корень", rootQuestionThemeQuestionsGenerator.CalculateRoot2And3),
                    220,
                    new uint[] { 18, 90, 250, 700, 875, 1050},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Свойства корней", rootQuestionThemeQuestionsGenerator.PropertiesOfRoot),
                    220,
                    new uint[] { 18, 90, 250, 700, 875, 1050},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Действия с корнями", rootQuestionThemeQuestionsGenerator.ActionsWithRoot),
                    240,
                    new uint[] { 20, 100, 300, 750, 925, 1100},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция информатики", 200));
            questionTheme = new QuestionTheme("Площади фигур", 6);
            FigureAreaThemeQuestionsGenerator figureAreaThemeQuestionsGenerator = new FigureAreaThemeQuestionsGenerator();
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Треугольник, прямоугольник, квадрат", figureAreaThemeQuestionsGenerator.GenerateArea_1Question),
                    260,
                    new uint[] { 22, 110, 330, 800, 975, 1150},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Треугольник (синус), ромб, прямоугольник", figureAreaThemeQuestionsGenerator.GenerateArea_2Question),
                    260,
                    new uint[] { 22, 110, 330, 800, 975, 1150},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(new WaterStationGameSquare("Водопровод", 150));
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Трапеция, треугольник (Герон)", figureAreaThemeQuestionsGenerator.GenerateArea_3Question),
                    280,
                    new uint[] { 24, 120, 360, 850, 1025, 1200},
                    new uint[] { 150, 150}
                )
            );
            gameBoardInfo.GameSquares.Add(new GoToJailGameSquare());
            questionTheme = new QuestionTheme("Квадратные уравнения", 7);
            QuadraticEquationThemeQuestionsGenerator quadraticEquationThemeQuestionsGenerator = new QuadraticEquationThemeQuestionsGenerator();
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "пример, где a = 1", quadraticEquationThemeQuestionsGenerator.GenerateQuadraticEquationWithA1Question),
                    300,
                    new uint[] { 26, 130, 390, 900, 1100, 1275},
                    new uint[] { 200, 200}
                )
            );
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "пример, где b или c = 1", quadraticEquationThemeQuestionsGenerator.QuadraticEquationWithB0_orC0Question),
                    300,
                    new uint[] { 26, 130, 390, 900, 1100, 1275},
                    new uint[] { 200, 200}
                )
            );
            gameBoardInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "пример, где a != 1 и 0", quadraticEquationThemeQuestionsGenerator.QuadraticEquationWithANot0And1Question),
                    320,
                    new uint[] { 28, 150, 450, 1000, 1200, 1400},
                    new uint[] { 200, 200}
                )
            );
            gameBoardInfo.GameSquares.Add(new RailRoadGameSquare("Станция физики", 200));
            gameBoardInfo.GameSquares.Add(new ChanceGameSquare());
            questionTheme = new QuestionTheme("Геометр. величины", 8);
            FigureCharacteristicsThemeQuestionsGenerator figureCharacteristicsThemeQuestionsGenerator = new FigureCharacteristicsThemeQuestionsGenerator();
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Треугольник, квадрат, прямоугольник", figureCharacteristicsThemeQuestionsGenerator.CalculateTriangleSquareRectangleCharacteristics),
                    350,
                    new uint[] { 35, 175, 500, 1100, 1300, 1500},
                    new uint[] { 200, 200}
                )
            );
            gameBoardInfo.GameSquares.Add(new TaxGameSquare());
            gameBoardInfo.GameSquares.Add(
                new TangibleAssetSquare
                (
                    questionSubthemeFactory.GetQuestionSubtheme(questionTheme, "Трапеция, ромб, параллелогам", figureCharacteristicsThemeQuestionsGenerator.CalculateTrapezoidRhombusParallelogramCharacteristics),
                    400,
                    new uint[] { 50, 200, 600, 1400, 1700, 200},
                    new uint[] { 200, 200}
                )
            );
            return gameBoardInfo;
        }
    }
}
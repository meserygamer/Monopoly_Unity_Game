#nullable enable

using System;
using System.Collections.Generic;
using Monopoly_Unity_Game_Server.ControlThemesQuestionsGenerators;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.ThemesQuestionsGenerators;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Questions;

namespace Scripts.Game.GameField
{
    public class BasicGameFieldFactory
    {
        private List<QuestionSubtheme>? _questionSubthemesOnGameField = null;
        private List<QuestionTheme>? _questionThemesOnGameField = null;

        private List<Func<GameSquareExample>>? _gameSquareExampleGenerators = null;


        public GameBoardInfo Create()
        {
            GameBoardInfo gameBoardInfo = new GameBoardInfo(40);
            gameBoardInfo.GameSquares[0] = new StartGameSquare();
            InitializeTangibleAssets(gameBoardInfo);
            InitializeRailRoads(gameBoardInfo);
            InitializeCummunityChestAndChanceFields(gameBoardInfo);
            InitializeInfrastructure(gameBoardInfo);
            InitializeJailAndParkingSquares(gameBoardInfo);
            InitializeTaxSquares(gameBoardInfo);
            return gameBoardInfo;
        }

        private void InitializeQuestionsThemes()
        {
            _questionThemesOnGameField = new List<QuestionTheme>()
            {
                new QuestionTheme("Устный счет", 1),
                new QuestionTheme("Десятичные дроби", 2),
                new QuestionTheme("Обыкновенные дроби", 3),
                new QuestionTheme("Степени", 4),
                new QuestionTheme("Корни", 5),
                new QuestionTheme("Площади фигур", 6),
                new QuestionTheme("Квадратные уравнения", 7),
                new QuestionTheme("Геометр. величины", 8)
            };
        }

        private void InitializeQuestionsGenerators()
        {
            OralCountThemeQuestionsGenerator oralCountThemeQuestionsGenerator = new OralCountThemeQuestionsGenerator();
            DecimalThemeQuestionsGenerator decimalThemeQuestionsGenerator = new DecimalThemeQuestionsGenerator();
            OrdinaryFractionsThemeQuestionsGenerator ordinaryFractionsThemeQuestionsGenerator = new OrdinaryFractionsThemeQuestionsGenerator();
            DegreeThemeQuestionsGenerator degreeThemeQuestionsGenerator = new DegreeThemeQuestionsGenerator();
            RootQuestionThemeQuestionsGenerator rootQuestionThemeQuestionsGenerator = new RootQuestionThemeQuestionsGenerator();
            FigureAreaThemeQuestionsGenerator figureAreaThemeQuestionsGenerator = new FigureAreaThemeQuestionsGenerator();
            QuadraticEquationThemeQuestionsGenerator quadraticEquationThemeQuestionsGenerator = new QuadraticEquationThemeQuestionsGenerator();
            FigureCharacteristicsThemeQuestionsGenerator figureCharacteristicsThemeQuestionsGenerator = new FigureCharacteristicsThemeQuestionsGenerator();
            
            _gameSquareExampleGenerators = new List<Func<GameSquareExample>>()
            {
                oralCountThemeQuestionsGenerator.GenerateExampleWithSingleAction,
                oralCountThemeQuestionsGenerator.GenerateExampleWithDoubleAction,
                decimalThemeQuestionsGenerator.CalculateDecimalSimpleExampleOfAddOrSub,
                decimalThemeQuestionsGenerator.CalculateDecimalSimpleExampleOfMulOrDiv,
                decimalThemeQuestionsGenerator.DecimalSimpleExampleWithTwoActions,
                ordinaryFractionsThemeQuestionsGenerator.CalculateOrdinaryFractionsWithSameDenominators,
                ordinaryFractionsThemeQuestionsGenerator.CalculateOrdinaryFractionsWithDifferentDenominators,
                ordinaryFractionsThemeQuestionsGenerator.CalculateOrdinaryFractionsWithTwoActions,
                degreeThemeQuestionsGenerator.CalculateDegreeWithNaturalExponent,
                degreeThemeQuestionsGenerator.CalculateDegreeProperties,
                degreeThemeQuestionsGenerator.CalculateDegreeWith0andNegativeExponentProperties,
                rootQuestionThemeQuestionsGenerator.CalculateRoot2And3,
                rootQuestionThemeQuestionsGenerator.PropertiesOfRoot,
                rootQuestionThemeQuestionsGenerator.ActionsWithRoot,
                figureAreaThemeQuestionsGenerator.GenerateArea_1Question,
                figureAreaThemeQuestionsGenerator.GenerateArea_2Question,
                figureAreaThemeQuestionsGenerator.GenerateArea_3Question,
                quadraticEquationThemeQuestionsGenerator.GenerateQuadraticEquationWithA1Question,
                quadraticEquationThemeQuestionsGenerator.QuadraticEquationWithB0_orC0Question,
                quadraticEquationThemeQuestionsGenerator.QuadraticEquationWithANot0And1Question,
                figureCharacteristicsThemeQuestionsGenerator.CalculateTriangleSquareRectangleCharacteristics,
                figureCharacteristicsThemeQuestionsGenerator.CalculateTrapezoidRhombusParallelogramCharacteristics
            };
        }

        private void InitializeQuestionsSubthemes()
        {
            if(_questionThemesOnGameField is null)
                InitializeQuestionsThemes();
            
            if(_gameSquareExampleGenerators is null)
                InitializeQuestionsGenerators();

            QuestionSubthemeFactory questionSubthemeFactory = new QuestionSubthemeFactory();
            _questionSubthemesOnGameField = new List<QuestionSubtheme>()
            {
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[0], "С одним действием", _gameSquareExampleGenerators?[0]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[0], "С двумя действиями", _gameSquareExampleGenerators?[1]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[1], "Сложение и вычитание", _gameSquareExampleGenerators?[2]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[1], "Умножение и деление", _gameSquareExampleGenerators?[3]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[1], "С двумя действиями", _gameSquareExampleGenerators?[4]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[2], "Пример с одинаковыми знаменателями", _gameSquareExampleGenerators?[5]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[2], "Пример с разными знаменателями", _gameSquareExampleGenerators?[6]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[2], "Пример из двух действий", _gameSquareExampleGenerators?[7]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[3], "Вычислить степень", _gameSquareExampleGenerators?[8]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[3], "Свойства степени", _gameSquareExampleGenerators?[9]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[3], "Свойства степеней с целым показателем", _gameSquareExampleGenerators?[10]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[4], "Вычислить корень", _gameSquareExampleGenerators?[11]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[4], "Свойства корней", _gameSquareExampleGenerators?[12]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[4], "Действия с корнями", _gameSquareExampleGenerators?[13]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[5], "Треугольник, прямоугольник, квадрат", _gameSquareExampleGenerators?[14]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[5], "Треугольник (синус), ромб, прямоугольник", _gameSquareExampleGenerators?[15]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[5], "Трапеция, треугольник (Герон)", _gameSquareExampleGenerators?[16]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[6], "пример, где a = 1", _gameSquareExampleGenerators?[17]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[6], "пример, где b или c = 1", _gameSquareExampleGenerators?[18]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[6], "пример, где a != 1 и 0", _gameSquareExampleGenerators?[19]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[7], "Треугольник, квадрат, прямоугольник", _gameSquareExampleGenerators?[20]),
                questionSubthemeFactory.GetQuestionSubtheme(_questionThemesOnGameField?[7], "Трапеция, ромб, параллелогам", _gameSquareExampleGenerators?[21])
            };
        }
    
        private void InitializeTangibleAssets(GameBoardInfo gameBoardInfo)
        {
            if(_questionSubthemesOnGameField is null)
                InitializeQuestionsSubthemes();

            if(gameBoardInfo is null)
                throw new ArgumentNullException(nameof(gameBoardInfo));

            gameBoardInfo.GameSquares[1] = new TangibleAssetSquare (
                    _questionSubthemesOnGameField![0],
                    60,
                    new uint[] { 2, 10, 30, 90, 160, 250},
                    new uint[] { 50, 50}
                );
            gameBoardInfo.GameSquares[3] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![1],
                    60,
                    new uint[] { 4, 20, 60, 180, 320, 450},
                    new uint[] { 50, 50}
                );
            gameBoardInfo.GameSquares[6] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![2],
                    100,
                    new uint[] { 6, 30, 90, 270, 400, 550},
                    new uint[] { 50, 50}
                );
            gameBoardInfo.GameSquares[8] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![3],
                    100,
                    new uint[] { 6, 30, 90, 270, 400, 550},
                    new uint[] { 50, 50}
                );
            gameBoardInfo.GameSquares[9] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![4],
                    120,
                    new uint[] { 8, 40, 100, 300, 450, 600},
                    new uint[] { 50, 50}
                );
            gameBoardInfo.GameSquares[11] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![5],
                    140,
                    new uint[] { 10, 50, 150, 450, 625, 750},
                    new uint[] { 100, 100}
                );
            gameBoardInfo.GameSquares[13] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![6],
                    140,
                    new uint[] { 10, 50, 150, 450, 625, 750},
                    new uint[] { 100, 100}
                );
            gameBoardInfo.GameSquares[14] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![7],
                    160,
                    new uint[] { 12, 60, 180, 500, 700, 900},
                    new uint[] { 100, 100}
                );
            gameBoardInfo.GameSquares[16] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![8],
                    180,
                    new uint[] { 14, 70, 200, 550, 700, 900},
                    new uint[] { 100, 100}
                );
            gameBoardInfo.GameSquares[18] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![9],
                    180,
                    new uint[] { 14, 70, 200, 550, 700, 900},
                    new uint[] { 100, 100}
                );
            gameBoardInfo.GameSquares[19] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![10],
                    200,
                    new uint[] { 16, 80, 220, 600, 800, 1000},
                    new uint[] { 100, 100}
                );
            gameBoardInfo.GameSquares[21] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![11],
                    220,
                    new uint[] { 18, 90, 250, 700, 875, 1050},
                    new uint[] { 150, 150}
                );
            gameBoardInfo.GameSquares[23] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![12],
                    220,
                    new uint[] { 18, 90, 250, 700, 875, 1050},
                    new uint[] { 150, 150}
                );
            gameBoardInfo.GameSquares[24] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![13],
                    240,
                    new uint[] { 20, 100, 300, 750, 925, 1100},
                    new uint[] { 150, 150}
                );
            gameBoardInfo.GameSquares[26] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![14],
                    260,
                    new uint[] { 22, 110, 330, 800, 975, 1150},
                    new uint[] { 150, 150}
                );
            gameBoardInfo.GameSquares[27] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![15],
                    260,
                    new uint[] { 22, 110, 330, 800, 975, 1150},
                    new uint[] { 150, 150}
                );
            gameBoardInfo.GameSquares[29] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![16],
                    280,
                    new uint[] { 24, 120, 360, 850, 1025, 1200},
                    new uint[] { 150, 150}
                );
            gameBoardInfo.GameSquares[31] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![17],
                    300,
                    new uint[] { 26, 130, 390, 900, 1100, 1275},
                    new uint[] { 200, 200}
                );
            gameBoardInfo.GameSquares[32] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![18],
                    300,
                    new uint[] { 26, 130, 390, 900, 1100, 1275},
                    new uint[] { 200, 200}
                );
            gameBoardInfo.GameSquares[34] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![19],
                    320,
                    new uint[] { 28, 150, 450, 1000, 1200, 1400},
                    new uint[] { 200, 200}
                );
            gameBoardInfo.GameSquares[37] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![20],
                    350,
                    new uint[] { 35, 175, 500, 1100, 1300, 1500},
                    new uint[] { 200, 200}
                );
            gameBoardInfo.GameSquares[39] = new TangibleAssetSquare
                (
                    _questionSubthemesOnGameField![21],
                    400,
                    new uint[] { 50, 200, 600, 1400, 1700, 200},
                    new uint[] { 200, 200}
                );
        }
    
        private void InitializeCummunityChestAndChanceFields(GameBoardInfo gameBoardInfo)
        {
            if(gameBoardInfo is null)
                throw new ArgumentNullException(nameof(gameBoardInfo));
            
            gameBoardInfo.GameSquares[2] = new CommunityChestGameSquare();
            gameBoardInfo.GameSquares[7] = new ChanceGameSquare();
            gameBoardInfo.GameSquares[17] = new CommunityChestGameSquare();
            gameBoardInfo.GameSquares[22] = new ChanceGameSquare();
            gameBoardInfo.GameSquares[33] = new CommunityChestGameSquare();
            gameBoardInfo.GameSquares[36] = new ChanceGameSquare();
        }
    
        private void InitializeInfrastructure(GameBoardInfo gameBoardInfo)
        {
            if(gameBoardInfo is null)
                throw new ArgumentNullException(nameof(gameBoardInfo));
            
            gameBoardInfo.GameSquares[12] = new LightStationGameSquare("Электричество", 150);
            gameBoardInfo.GameSquares[28] = new WaterStationGameSquare("Водопровод", 150);
        }

        private void InitializeRailRoads(GameBoardInfo gameBoardInfo)
        {
            if(gameBoardInfo is null)
                throw new ArgumentNullException(nameof(gameBoardInfo));
            
            gameBoardInfo.GameSquares[5] = new RailRoadGameSquare("Станция алгебры", 200, _questionSubthemesOnGameField!.GetRange(0, 5));
            gameBoardInfo.GameSquares[15] = new RailRoadGameSquare("Станция геометрии", 200, _questionSubthemesOnGameField!.GetRange(5, 6));
            gameBoardInfo.GameSquares[25] = new RailRoadGameSquare("Станция информатики", 200, _questionSubthemesOnGameField!.GetRange(11, 6));
            gameBoardInfo.GameSquares[35] = new RailRoadGameSquare("Станция физики", 200, _questionSubthemesOnGameField!.GetRange(17, 5));
        }

        private void InitializeJailAndParkingSquares(GameBoardInfo gameBoardInfo)
        {
            if(gameBoardInfo is null)
                throw new ArgumentNullException(nameof(gameBoardInfo));

            gameBoardInfo.GameSquares[10] = new JailVisitGameSquare();
            gameBoardInfo.GameSquares[20] = new ParkingGameSquare();
            gameBoardInfo.GameSquares[30] = new GoToJailGameSquare();
        }
    
        private void InitializeTaxSquares(GameBoardInfo gameBoardInfo)
        {
            if(gameBoardInfo is null)
                throw new ArgumentNullException(nameof(gameBoardInfo));

            gameBoardInfo.GameSquares[4] = new TaxGameSquare();
            gameBoardInfo.GameSquares[38] = new TaxGameSquare();
        }
    }
}
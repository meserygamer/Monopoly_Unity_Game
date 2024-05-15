using UnityEngine;

namespace Scripts.Game.View.ConstructionMode
{
    public sealed class ConstructionModeVisualizer : MonoBehaviour
    {
        [SerializeField] private PurchaseOpportunityVisualizer[] _purchaseOpportunityVisualizers;
        [SerializeField] private GameSquareConstructionBulder[] _gameSquareConstructionBulders;

    
        public void EnableConstructionMode()
        {
            foreach (var purchaseOpportunityVisualizer in _purchaseOpportunityVisualizers)
                purchaseOpportunityVisualizer.IsVisualizeEnabled = true;
            foreach (var gameSquareConstructionBulder in _gameSquareConstructionBulders)
                gameSquareConstructionBulder.enabled = true;
        }

        public void DisableConstructionMode()
        {
            foreach (var purchaseOpportunityVisualizer in _purchaseOpportunityVisualizers)
                purchaseOpportunityVisualizer.IsVisualizeEnabled = false;
            foreach (var gameSquareConstructionBulder in _gameSquareConstructionBulders)
                gameSquareConstructionBulder.enabled = false;
        }
    }
}

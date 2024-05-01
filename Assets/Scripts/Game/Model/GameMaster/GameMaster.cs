namespace Scripts.Game.Model.GameMaster
{
    public class GameMaster
    {
        public GameMaster(AwardingRewardsMaster awardingRewardsMaster)
        {
            _awardingRewardsMaster = awardingRewardsMaster;
        }


        private AwardingRewardsMaster _awardingRewardsMaster;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public class PetWatcher
    {
        private FileWatcher _fileWatcher { get; }
        private BattleWatcher _battleWatcher { get; }
        private string _playerName { get; }
        public PetWatcher(FileWatcher fileWatcher, BattleWatcher battleWatcher, string playerName)
        {
            _fileWatcher = fileWatcher;
            _battleWatcher = battleWatcher;
            _playerName = playerName;
        }

        public void Start()
        {
            _fileWatcher.OnLogFileUpdateEvent += OnLogFileUpdate;
        }

        public void OnLogFileUpdate(IEnumerable<string> newLines)
        {
            foreach(string line in newLines)
            {
                if (Regex.IsMatch(line, EnumsAndConstants.PetLeaderRegex))
                {
                    Match match = Regex.Match(line, EnumsAndConstants.PetLeaderRegex);
                    if(match.Groups[3].Value == _playerName)
                    {
                        _battleWatcher.SetPet(match.Groups[2].Value);
                    }
                }
            }
        }
    }
}

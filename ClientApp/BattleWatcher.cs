﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public class BattleWatcher
    {
        public delegate void OnBattleEnd(CombatantFightInfo fightInfo);
        public event OnBattleEnd OnBattleEndEvent;
        public delegate void OnBattleUpdate(CombatantFightInfo fightInfo);
        public event OnBattleUpdate OnBattleUpdateEvent;

        private DateTime _firstInteractionTime;
        private DateTime _lastInteractionTime;
        private const int _battleTimeoutSeconds = 10;
        private string _currentOpponent;
        private string _playerName;
        private CombatantFightInfo _fightInfo;
        private bool _fightOngoing;
        private FileWatcher _fileWatcher { get; }

        private Thread _battleTimeoutThread;
        private Thread _battleUpdateThread;
        public BattleWatcher(FileWatcher fileWatcher, string playerName)
        {
            _fileWatcher = fileWatcher;
            _playerName = playerName;
        }

        public void Start()
        {
            _fileWatcher.OnLogFileUpdateEvent += OnLogFileUpdateEvent;
            _fightOngoing = false;

            _battleTimeoutThread = new Thread(() => BattleTimeoutChecker());
            _battleTimeoutThread.Start();
            _battleUpdateThread = new Thread(() => BattleUpdater());
            _battleUpdateThread.Start();
        }


        //thread wakes up and notifies all listeners of updates to _fightInfo
        private void BattleUpdater()
        {
            while (true)
            {
                if (_fightOngoing && OnBattleUpdateEvent != null)
                {
                    OnBattleUpdateEvent.Invoke(_fightInfo); //notify subscribers
                }

                Thread.Sleep(3000);
            }
        }

        //wakes up and checks how long we have gone without any melee output
        private void BattleTimeoutChecker()
        {
            while(true)
            {
                if (_currentOpponent != null)
                {
                    if (DateTime.Now.Subtract(_lastInteractionTime).Seconds > _battleTimeoutSeconds)
                    {
                        Console.WriteLine("Fight has timed out");
                        ClearBattle();
                    }
                }
                Thread.Sleep(3000);
            }
        }

        private void OnLogFileUpdateEvent(IEnumerable<string> newLines)
        {
            foreach(string line in newLines)
            {
                Interaction interaction = null;
                if(Regex.IsMatch(line, EnumsAndConstants.MeleeRegex))
                    interaction = new MeleeInteraction(line);
                else if (Regex.IsMatch(line, EnumsAndConstants.SpellRegex))
                    interaction = new SpellInteraction(line);

                if(interaction != null)
                {
                    if (_currentOpponent == null)
                    {
                        StartNewFight(interaction);
                    }
                    else if (interaction.OpponentName == _currentOpponent)
                    {
                        UpdateCurrentFight(interaction);
                    }
                }
                else 
                {
                    Match deadRegex = Regex.Match(line, EnumsAndConstants.MyKillshotRegex);
                    if (!deadRegex.Success)
                        deadRegex = Regex.Match(line, EnumsAndConstants.OtherKillshotRegex);
                    if (!deadRegex.Success)
                        deadRegex = Regex.Match(line, EnumsAndConstants.DiedRegex);

                    if(deadRegex.Success && deadRegex.Groups[1].Value == _currentOpponent)
                    {
                        Thread.Sleep(2000);
                        if (OnBattleUpdateEvent != null)
                            OnBattleUpdateEvent.Invoke(_fightInfo);
                        ClearBattle();
                    }
                }
            }
        }

        private void StartNewFight(Interaction interaction)
        {
            _fightInfo = new CombatantFightInfo(interaction, _playerName);
            _lastInteractionTime = interaction.Time;
            _currentOpponent = interaction.OpponentName;
            _fightOngoing = true;
            _firstInteractionTime = DateTime.Now;
        }

        private void UpdateCurrentFight(Interaction interaction)
        {
            _fightInfo.UpdateDamageStats(interaction.HitAmount);
            _lastInteractionTime = interaction.Time;
        }

        private void ClearBattle()
        {
            if (OnBattleEndEvent != null)
                OnBattleEndEvent.Invoke(_fightInfo);

            _firstInteractionTime = DateTime.Now;
            _lastInteractionTime = DateTime.Now;
            _currentOpponent = null;
            _fightInfo = null;
            _fightOngoing = false;
        }

        public string GetOpponentName()
        {
            return _currentOpponent;
        }

        public string GetBattleHeaderInfo()
        {
            return $"{_currentOpponent} in {DateTime.Now.Subtract(_firstInteractionTime).Seconds} seconds";
        }
    }
}
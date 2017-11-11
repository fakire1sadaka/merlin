using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Merlin.API.Direct;
using Merlin.Pathing;
using Merlin.Pathing.Worldmap;
using YinYang.CodeProject.Projects.SimplePathfinding.PathFinders.AStar;

namespace Merlin.Profiles.Gatherer
{
    public partial class Gatherer
    {
        #region Fields

        public KeyCode runningKey = KeyCode.F12;
        public KeyCode espKey = KeyCode.F11;
        public KeyCode unloadKey = KeyCode.F10;
        public KeyCode testkey = KeyCode.F9;

        private static int SpaceBetweenSides = 40;
        private static int SpaceBetweenItems = 4;

        private bool _isUIshown;
        private bool _showESP;

        #endregion Fields

        #region Properties

        private static Rect GatheringUiButtonRect { get; } = new Rect((Screen.width / 2) - 50, 0, 100, 20);

        private static Rect GatheringBotButtonRect { get; } = new Rect((Screen.width / 2) + 50, 0, 100, 20);

        private Rect GatheringWindowRect { get; set; } = new Rect((Screen.width / 2) - 506, 0, 0, 0);

        private string[] TownClusterNames
        { get { return Enum.GetNames(typeof(TownClusterName)).Select(n => n.Replace("_", " ")).ToArray(); } }

        private string[] TierNames
        { get { return Enum.GetNames(typeof(Tier)).ToArray(); } }

        private Tier SelectedMinimumTier
        { get { return (Tier)Enum.Parse(typeof(Tier), TierNames[_selectedMininumTierIndex]); } }

        #endregion Properties

        #region Methods

        private void DrawGatheringUIButton()
        {
            if (GUI.Button(GatheringUiButtonRect, "интерфейс"))
                _isUIshown = true;

            DrawRunButton(false);
        }

        private void DrawGatheringUIWindow(int windowID)
        {
            GUILayout.BeginHorizontal();
            DrawGatheringUILeft();
            GUILayout.Space(SpaceBetweenSides);
            DrawGatheringUIRight();
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }

        private void DrawGatheringUILeft()
        {
            GUILayout.BeginVertical();
            DrawGatheringUI_Buttons();
            DrawGatheringUI_Toggles();
            DragGatheringUI_Sliders();
            DrawGatheringUI_SelectionGrids();
            DrawGatheringUI_TextFields();
            GUILayout.EndVertical();
        }

        private void DrawGatheringUI_Toggles()
        {
            _allowMobHunting = GUILayout.Toggle(_allowMobHunting, "Позволено е убиването на мобове (Още се разработва - може да предизвика проблеми)");
            _skipUnrestrictedPvPZones = GUILayout.Toggle(_skipUnrestrictedPvPZones, "Внимавайте с PvP зоните");
            _skipKeeperPacks = GUILayout.Toggle(_skipKeeperPacks, "Пропускайте насъбралите се много мобове на едно място");
            _allowSiegeCampTreasure = GUILayout.Toggle(_allowSiegeCampTreasure, "Позволете използването на съкровища");
            _skipRedAndBlackZones = GUILayout.Toggle(_skipRedAndBlackZones, "Прескачайте червените и черните зони за пътуване");
            UpdateESP(GUILayout.Toggle(_showESP, "Покажете ESP"));
        }

        private void UpdateESP(bool newValue)
        {
            var oldValue = _showESP;
            _showESP = newValue;

            if (oldValue != _showESP)
            {
                if (_showESP)
                    gameObject.AddComponent<ESP.ESP>().StartESP(_gatherInformations);
                else if (gameObject.GetComponent<ESP.ESP>() != null)
                    Destroy(gameObject.GetComponent<ESP.ESP>());
            }
        }

        private void DragGatheringUI_Sliders()
        {
            if (_skipKeeperPacks)
            {
                GUILayout.Label($"Пуснете си обсега на групите от мобове: {_keeperSkipRange}");
                _keeperSkipRange = GUILayout.HorizontalSlider(_keeperSkipRange, 5, 50);
            }

            GUILayout.Label($"Минимална кръв изискана за събиране: {_minimumHealthForGathering.ToString("P2")}");
            _minimumHealthForGathering = GUILayout.HorizontalSlider(_minimumHealthForGathering, 0.01f, 1f);

            GUILayout.Label($"Ресурсите необходими за банковият сейф: {_percentageForBanking}");
            _percentageForBanking = Mathf.Round(GUILayout.HorizontalSlider(_percentageForBanking, 1, 400));

            if (_allowSiegeCampTreasure)
            {
                GUILayout.Label($"Ресурсите изискани за съкровището: {_percentageForSiegeCampTreasure}");
                _percentageForSiegeCampTreasure = Mathf.Round(GUILayout.HorizontalSlider(_percentageForSiegeCampTreasure, 1, 400));
            }
        }

        private void DrawGatheringUI_SelectionGrids()
        {
            GUILayout.Label("Избиране на банкер:");
            _selectedTownClusterIndex = GUILayout.SelectionGrid(_selectedTownClusterIndex, TownClusterNames, TownClusterNames.Length);

            GUILayout.Label("Избиране на минимални ресурси:");
            _selectedMininumTierIndex = GUILayout.SelectionGrid(_selectedMininumTierIndex, TierNames, TierNames.Length);
        }

        private void DrawGatheringUI_TextFields()
        {
            GUILayout.Label("Избиране на събирач:");
            var currentClusterInfo = _world.GetCurrentCluster() != null ? _world.GetCurrentCluster().GetName() : "Неизвестно";
            var selectedGatherCluster = string.IsNullOrEmpty(_selectedGatherCluster) ? currentClusterInfo : _selectedGatherCluster;
            _selectedGatherCluster = GUILayout.TextField(selectedGatherCluster);
        }

        private void DrawGatheringUIRight()
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Ресурси за събиране:");
            DrawGatheringUI_GatheringToggles();
            GUILayout.EndVertical();
        }

        private void DrawGatheringUI_Buttons()
        {
            if (GUILayout.Button("Затваряне на потребителския интерфейс за събиране"))
                _isUIshown = !_isUIshown;

            DrawRunButton(true);

            if (GUILayout.Button("Разтоварване"))
                Core.Unload();
        }

        private void DrawGatheringUI_GatheringToggles()
        {
            GUILayout.BeginHorizontal();
            var selectedMinimumTier = SelectedMinimumTier;
            var groupedKeys = _gatherInformations.Keys.GroupBy(i => i.ResourceType).ToArray();
            for (var i = 0; i < groupedKeys.Count(); i++)
            {
                var keys = groupedKeys[i].ToArray();

                GUILayout.BeginVertical();
                for (var j = 0; j < keys.Length; j++)
                {
                    var info = keys[j];
                    if (info.Tier < selectedMinimumTier)
                        _gatherInformations[info] = false;
                    else
                        _gatherInformations[info] = GUILayout.Toggle(_gatherInformations[info], info.ToString());
                }
                GUILayout.EndVertical();
                GUILayout.Space(SpaceBetweenItems);
            }
            GUILayout.EndHorizontal();
        }

        private void DrawRunButton(bool layouted)
        {
            var text = _isRunning ? "Спри събиране" : "Започнете събиране";
            if (layouted ? GUILayout.Button(text) : GUI.Button(GatheringBotButtonRect, text))
            {
                _isRunning = !_isRunning;
                if (_isRunning)
                {
                    ResetCriticalVariables();
                    if (_selectedGatherCluster == "Неизвестно" && _world.GetCurrentCluster() != null)
                        _selectedGatherCluster = _world.GetCurrentCluster().GetName();
                    _localPlayerCharacterView.CreateTextEffect("[Старт]");
                    if (_state.CanFire(Trigger.Failure))
                        _state.Fire(Trigger.Failure);
                }
            }
        }

        protected override void OnUI()
        {
            if (_isUIshown)
                GatheringWindowRect = GUILayout.Window(0, GatheringWindowRect, DrawGatheringUIWindow, "Събирателен потребителския интерфейс");
            else
                DrawGatheringUIButton();
        }

        protected override void HotKey()
        {
            if (Input.GetKeyDown(runningKey))
            {
                _isRunning = !_isRunning;
                if (_isRunning)
                {
                    ResetCriticalVariables();
                    if (_selectedGatherCluster == "Неизвестно" && _world.GetCurrentCluster() != null)
                        _selectedGatherCluster = _world.GetCurrentCluster().GetName();
                    _localPlayerCharacterView.CreateTextEffect("[Старт]");
                    if (_state.CanFire(Trigger.Failure))
                        _state.Fire(Trigger.Failure);
                }
            }
            else if (Input.GetKeyDown(testkey))
            {
                Vector3 playerCenter = _localPlayerCharacterView.transform.position;
                Core.Log("X: " + playerCenter.x + " Y: " + playerCenter.y + " Z: " + playerCenter.z);

                ClusterDescriptor currentWorldCluster = _world.GetCurrentCluster();
                Core.Log("City: " + currentWorldCluster.GetName().ToLowerInvariant());

            }
            else if (Input.GetKeyDown(unloadKey))
            {
                Core.Unload();
            }
            else if (Input.GetKeyDown(espKey))
            {
                var oldValue = _showESP;
                _showESP = !_showESP;

                if (oldValue != _showESP)
                {
                    if (_showESP)
                        gameObject.AddComponent<ESP.ESP>().StartESP(_gatherInformations);
                    else if (gameObject.GetComponent<ESP.ESP>() != null)
                        Destroy(gameObject.GetComponent<ESP.ESP>());
                }
            }
        }

        #endregion Methods
    }
}

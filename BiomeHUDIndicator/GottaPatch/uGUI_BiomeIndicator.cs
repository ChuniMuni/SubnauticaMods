﻿namespace BiomeHUDIndicator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Harmony;
    using Fabricator;
    using UnityEngine;
    using UnityEngine.UI;

    internal class uGUI_BiomeIndicator : MonoBehaviour
    {
        // Setting up some cached values in case I need them
        private string _cachedBiome;
        private string _cachedBiomeFriendly;
        // This space reserved for fields the class needs to work with
        private Color32 textColor = new Color32(255, 255, 255, 255);
        [Header("Biome Indicator")] public Image shadow;
        private bool _initialized;
        private bool _showing;
        private GameObject textPrefab;

        // Rather than a gajillion if/else statements, gonna use a dictionary
        private static Dictionary<string, string> biomeList = new Dictionary<string, string>()
        {
            { "safeshallows", "Safe Shallows" },
            { "kelp", "Kelp Forest" },
            { "grassyplateaus", "Grassy Plateaus" },
            { "mushroomforest", "Mushroom Forest" },
            { "jellyshroomcaves", "Jellyshroom Caves" },
            { "sparsereef", "Sparse Reef" },
            { "floatingislands" , "Floating Island" },
            { "shipspecial" , "Aurora" },
            { "shipinterior", "Aurora" },
            { "crashhome" , "Aurora" },
            { "aurora" , "Aurora" },
            { "crashzone" , "Crash Zone" },
            { "underwaterislands" , "Underwater Islands" },
            { "seatreaderpath" , "Sea Treader's Path" },
            { "grandreef" , "Grand Reef" },
            { "deepgrandreef" , "Deep Grand Reef" },
            { "mountains" , "Mountains" },
            { "dunes" , "Dunes" },
            { "lostriverjunction" , "Lost River Junction" },
            { "lostrivercorridor" , "Lost River Corridor" },
            { "skeletoncave" , "Skeleton Cave" },
            { "treecove" , "Tree Cove" },
            { "ghosttree" , "Ghost Tree" },
            { "cragfield" , "Crag Field" },
            { "bonesfield" , "Bone Field" },
            { "kooshzone" , "Bulb Zone" },
            { "bloodkelp" , "Blood Kelp Zone" },
            { "inactivelavazone" , "Inactive Lava Zone" },
            { "activelavazone" , "Active Lava Zone" },
            { "mesas" , "Mesas" },
            { "prisonaquarium" , "Primary Containment Facility" },
            { "observatory" , "Observatory" },
            { "generatorroom" , "Generator Room" },
            { "crashedship" , "Aurora" },
            { "precursorgun" , "Precursor Facility" },
            { "prison" , "Primary Containment Facility" },
            { "unassigned" , "Unassigned" },
        };

        // Putting Awake here
        private void Awake()
        {
            textPrefab = Main.biomeHUD;
            textPrefab.SetActive(true);
        }

        // Start method goes here
        private void Start()
        {
            this.shadow.material = new Material(this.shadow.material);
            _cachedBiome = "Unassigned";
        }

        // OnDisable method goes here
        private void OnDisable()
        {
            this.Deinitialize();
        }

        // LateUpdate goes here
        private void LateUpdate()
        {
            
        }

        // Initialize method
        private void Initialize()
        {
            if (this._initialized)
            {
                return;
            }
            Player main = Player.main;
            if (main == null)
            {
                return;
            }
            Language main2 = Language.main;
            if (main2 == null)
            {
                return;
            }
            
            this._initialized = true;
        }

        // Deinitialize method
        private void Deinitialize()
        {
            if(!this._initialized)
            {
                return;
            }
            this._initialized = false;
            Language main = Language.main;
            if (main != null)
            {

            }
        }

        // A method to setVisible(), will be implemented after the text is displaying on screen and updating
        public void setVisible(bool visible)
        {
            if(this._showing == visible)
            {
                return;
            }
            this._showing = visible;
        }

        // OnLanguageChanged method
        private void OnLanguageChanged()
        {

        }

        // UpdateBiome method
        private void Update()
        {
            if(!_initialized && (!uGUI_SceneLoading.IsLoadingScreenFinished || uGUI.main.loading.isLoading))
            {
                return;
            }
            Player main = Player.main;
            string curBiome = main.GetBiomeString();
            int index = curBiome.IndexOf('_');
            curBiome = curBiome.Substring(0, index);
            curBiome = curBiome.ToLower();
            // This IF tree should get almost any biome
            if (curBiome != _cachedBiome)
            {
                _cachedBiomeFriendly = biomeList[curBiome];
                UnityEngine.Debug.Log("[BiomeHUDIndicator] Value of _cachedBiome is currently: " + _cachedBiome);
                UnityEngine.Debug.Log("[BiomeHUDIndicator] Value of curBiome is currently: " + curBiome); // Remove after verifying it updates
                UnityEngine.Debug.Log("[BiomeHUDIndicator] Value of _cachedBiomeFriendly is currently: " + _cachedBiomeFriendly); // Remove after verifying it updates
                // biomeDisplay.text = _cachedBiomeFriendly;
            }
        }
    }
}

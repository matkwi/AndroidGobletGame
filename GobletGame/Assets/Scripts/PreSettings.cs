using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreSettings {

    private static bool isBatPlaying;
    private static bool isBunnyPlaying;
    private static bool isDuckPlaying;
    private static bool isChickenPlaying;
    private static bool AIBat;
    private static bool AIBunny;
    private static bool AIDuck;
    private static bool AIChicken;

    public PreSettings() {
        
    }

    public bool IsBatPlaying {
        get => isBatPlaying;
        set => isBatPlaying = value;
    }

    public bool IsBunnyPlaying {
        get => isBunnyPlaying;
        set => isBunnyPlaying = value;
    }

    public bool IsDuckPlaying {
        get => isDuckPlaying;
        set => isDuckPlaying = value;
    }

    public bool IsChickenPlaying {
        get => isChickenPlaying;
        set => isChickenPlaying = value;
    }

    public bool IsAIBat {
        get => AIBat;
        set => AIBat = value;
    }

    public bool IsAIBunny {
        get => AIBunny;
        set => AIBunny = value;
    }

    public bool IsAIDuck {
        get => AIDuck;
        set => AIDuck = value;
    }

    public bool IsAIChicken {
        get => AIChicken;
        set => AIChicken = value;
    }
}

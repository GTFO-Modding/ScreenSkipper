
Imports BepInEx
Imports BepInEx.Configuration
Imports BepInEx.IL2CPP
Imports HarmonyLib

<BepInPlugin(BepinexLoader.GUID, BepinexLoader.MODNAME, BepinexLoader.VERSION)>
Public Class BepinexLoader
    Inherits BasePlugin

    Public Const MODNAME = "ScreenSkipper"
    Public Const AUTHOR = "Endskill"
    Public Const GUID = AUTHOR + "." + MODNAME
    Public Const VERSION = "1.3.0"

    Public Shared Harmony As Harmony


    Public Shared ImprovedSkip As ConfigEntry(Of Boolean)

    Public Overrides Sub Load()
        VbLogger.DebugMessagesActive = Config.Bind("Dev Settings", "Debug Messages", False, "This settings activates/deactivates debug messages in the console for this specific plugin.").Value
        VbLogger.Logger = Log
        Patch.FastStart = Config.Bind("Faster Start", "Faster Start", False, "This settings overwrites some parts of the start screen animations and instantly puts you into the RundownPage fully loaded." +
                                      Environment.NewLine + "Some ui objects don't load because they are initialized later on, but we are already in the rundown page.").Value
        Harmony = New Harmony(GUID)
        Harmony.PatchAll(GetType(Patch))
    End Sub
End Class

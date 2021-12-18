
Imports BepInEx
Imports BepInEx.Configuration
Imports BepInEx.IL2CPP
Imports HarmonyLib

<BepInPlugin(BepinexLoader.GUID, BepinexLoader.MODNAME, BepinexLoader.VERSION)>
Public Class BepinexLoader
    Inherits BasePlugin

    Public Const MODNAME = "ScreenSkipper"
    Public Const AUTHOR = "Dex & Fixed by Endskill"
    Public Const GUID = "com.Dex.ScreenSkipper"
    Public Const VERSION = "1.1.0"

    Public Shared Harmony As Harmony

    Public Shared ImprovedSkip As ConfigEntry(Of Boolean)

    Public Overrides Sub Load()
        Harmony = New Harmony(GUID)
        Harmony.PatchAll(GetType(Patch))
    End Sub
End Class

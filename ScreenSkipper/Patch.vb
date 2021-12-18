Imports CellMenu
Imports HarmonyLib

Public Class Patch

    <HarmonyPatch(GetType(CM_PageRundown_New), NameOf(CM_PageRundown_New.Setup))>
    <HarmonyPrefix>
    Private Shared Sub Cm_PageRundown__Setup_Prefix(__instance As CM_PageRundown_New)
        __instance.m_cortexIntroIsDone = True
        __instance.m_rundownIntroIsDone = True
    End Sub

    <HarmonyPatch(GetType(CM_PageIntro), NameOf(CM_PageIntro.Setup))>
    <HarmonyPrefix>
    Private Shared Sub Cm_PageIntro_Setup_Prefix()
        Globals.Global.ShowStartupScreen = False
        Globals.Global.SkipIntro = True
    End Sub

    <HarmonyPatch(GetType(ElevatorRide), NameOf(ElevatorRide.StartPreReleaseSequence))>
    <HarmonyPostfix>
    Private Shared Sub ElevatorRide_StartPreReleaseSequence_Postfix()
        ElevatorRide.SkipPreReleaseSequence()
    End Sub

End Class

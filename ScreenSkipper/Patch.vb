Imports CellMenu
Imports HarmonyLib
Imports Player
Imports UnityEngine

Public Class Patch

    Public Shared FastStart As Boolean

    <HarmonyPatch(GetType(CM_PageRundown_New), NameOf(CM_PageRundown_New.Setup))>
    <HarmonyPrefix>
    Private Shared Sub Cm_PageRundown__Setup_Prefix(__instance As CM_PageRundown_New)
        __instance.m_cortexIntroIsDone = True
        If FastStart Then
            __instance.m_rundownIntroIsDone = True
        End If
    End Sub

    <HarmonyPatch(GetType(CM_PageRundown_New), NameOf(CM_PageRundown_New.Setup))>
    <HarmonyPostfix>
    Private Shared Sub Cm_PageRundown__Setup_Postfix(__instance As CM_PageRundown_New)
        If FastStart Then
            VbLogger.Warn("Fast start in ScreenSkipper enabled! Expect some UI elements to break.")
            __instance.m_buttonConnect.OnBtnPressCallback.Invoke(0)
            RevealRundown(__instance)
        End If
    End Sub

    <HarmonyPatch(GetType(CM_PageIntro), NameOf(CM_PageIntro.Setup))>
    <HarmonyPrefix>
    Private Shared Sub Cm_PageIntro_Setup_Prefix()
        PlayerManager.s_botAutoSpawnDelay = -30
        Globals.Global.ShowStartupScreen = False
        Globals.Global.SkipIntro = True
        Globals.Global.FastElevator = True
    End Sub

    <HarmonyPatch(GetType(ElevatorRide), NameOf(ElevatorRide.StartPreReleaseSequence))>
    <HarmonyPostfix>
    Private Shared Sub ElevatorRide_StartPreReleaseSequence_Postfix()
        ElevatorRide.SkipPreReleaseSequence()
    End Sub

    Private Shared Sub RevealRundown(page As CM_PageRundown_New)
        page.ResetElements()
        page.m_menuBar.SetVisible(True)
        page.m_cursor.SetVisible(True)

        For i As Integer = 0 To page.m_corners.Length - 1
            page.m_corners(i).gameObject.SetActive(True)
        Next
        page.m_rundownHolder.transform.localPosition = New Vector3(0.0F, 650.0F, 0.0F)
        page.m_textRundownHeader.transform.localPosition = page.m_rundownHeaderPos
        page.m_textRundownHeader.transform.localScale = New Vector3(0.6F, 0.6F, 0.6F)
        page.m_textRundownHeader.gameObject.SetActive(True)

        If page.m_rundownIntelButton <> Nothing Then
            page.m_rundownIntelButton.SetVisible(True)
        End If

        page.m_guix_Surface.transform.localScale = New Vector3(0.2F, 0.2F, 0.2F)
        page.m_guix_Surface.transform.localEulerAngles = New Vector3(70.0F, 0.0F, 0.0F)
        page.m_guix_Surface.gameObject.SetActive(True)
        page.m_guix_Tier1.gameObject.SetActive(True)
        page.m_guix_Tier2.gameObject.SetActive(True)
        page.m_guix_Tier3.gameObject.SetActive(True)
        page.m_guix_Tier4.gameObject.SetActive(True)
        page.m_guix_Tier5.gameObject.SetActive(True)
        page.m_verticalArrow.transform.localScale = New Vector3(1.0F, page.m_tierSpacing * 5.0F * page.m_tierSpaceToArrowScale, 1.0F)
        page.m_verticalArrow.SetActive(True)

        'For i As Integer = 0 To page.m_expIconsAll.Count - 1
        '    page.m_expIconsAll(i).SetVisible(True)
        'Next

        page.m_joinOnServerIdText.gameObject.SetActive(True)
        page.m_aboutTheRundownButton.SetVisible(True)

        page.m_discordButton.SetVisible(True)
        page.m_matchmakeAllButton.SetVisible(True)

        'page.m_tierMarkerSectorSummary.gameObject.SetActive(True)
        page.m_tiersAreRevealed = True
    End Sub

End Class

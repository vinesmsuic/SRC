﻿// Copyright (C) 1997-2012 Kei Sakamoto / Inui Tetsuyuki
// 本プログラムはフリーソフトであり、無保証です。
// 本プログラムはGNU General Public License(Ver.3またはそれ以降)が定める条件の下で
// 再頒布または改変することができます。

using SRCCore.VB;
using System;

namespace SRCCore.Commands
{
    public partial class Command
    {
        // 「変形」コマンド
        private void TransformCommand()
        {
            throw new NotImplementedException();
            //string[] list;
            //string[] list_id;
            //int i;
            //int ret;
            //string uname, fdata;
            //string prev_uname;

            //// MOD START MARGE
            //// If MainWidth <> 15 Then
            //if (GUI.NewGUIMode)
            //{
            //    // MOD END MARGE
            //    Status.ClearUnitStatus();
            //}

            //GUI.LockGUI();
            //object argIndex1 = "変形";
            //fdata = SelectedUnit.FeatureData(argIndex1);
            //if (string.IsNullOrEmpty(Map.MapFileName))
            //{
            //    // ユニットステータスコマンドの場合
            //    {
            //        var withBlock = SelectedUnit;
            //        list = new string[1];
            //        list_id = new string[1];
            //        // 変形可能な形態一覧を作成
            //        var loopTo = GeneralLib.LLength(fdata);
            //        for (i = 2; i <= loopTo; i++)
            //        {
            //            object argIndex2 = GeneralLib.LIndex(fdata, i);
            //            {
            //                var withBlock1 = withBlock.OtherForm(argIndex2);
            //                if (withBlock1.IsAvailable())
            //                {
            //                    Array.Resize(list, Information.UBound(list) + 1 + 1);
            //                    Array.Resize(list_id, Information.UBound(list) + 1);
            //                    list[Information.UBound(list)] = withBlock1.Nickname;
            //                    list_id[Information.UBound(list)] = withBlock1.Name;
            //                }
            //            }
            //        }

            //        GUI.ListItemFlag = new bool[Information.UBound(list) + 1];

            //        // 変形する形態を選択
            //        if (Information.UBound(list) > 1)
            //        {
            //            GUI.TopItem = 1;
            //            string arglb_caption = "変形";
            //            string arglb_info = "名前";
            //            string arglb_mode = "カーソル移動";
            //            ret = GUI.ListBox(arglb_caption, list, arglb_info, arglb_mode);
            //            if (ret == 0)
            //            {
            //                CancelCommand();
            //                GUI.UnlockGUI();
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ret = 1;
            //        }

            //        // 変形を実施
            //        Unit localOtherForm() { var tmp = list_id; object argIndex1 = tmp[ret]; var ret = withBlock.OtherForm(argIndex1); return ret; }

            //        string argnew_form = localOtherForm().Name;
            //        withBlock.Transform(argnew_form);
            //        localOtherForm().Name = argnew_form;

            //        // ユニットリストの表示を更新
            //        string argsmode = "";
            //        Event_Renamed.MakeUnitList(smode: argsmode);

            //        // ステータスウィンドウの表示を更新
            //        Status.DisplayUnitStatus(withBlock.CurrentForm());

            //        // コマンドを終了
            //        GUI.UnlockGUI();
            //        CommandState = "ユニット選択";
            //        return;
            //    }
            //}

            //// 変形可能な形態の一覧を作成
            //list = new string[1];
            //list_id = new string[1];
            //GUI.ListItemFlag = new bool[1];
            //var loopTo1 = GeneralLib.LLength(fdata);
            //for (i = 2; i <= loopTo1; i++)
            //{
            //    object argIndex3 = GeneralLib.LIndex(fdata, i);
            //    {
            //        var withBlock2 = SelectedUnit.OtherForm(argIndex3);
            //        if (withBlock2.IsAvailable())
            //        {
            //            Array.Resize(list, Information.UBound(list) + 1 + 1);
            //            Array.Resize(list_id, Information.UBound(list) + 1);
            //            Array.Resize(GUI.ListItemFlag, Information.UBound(list) + 1);
            //            list[Information.UBound(list)] = withBlock2.Nickname0;
            //            list_id[Information.UBound(list)] = withBlock2.Name;
            //            if (withBlock2.IsAbleToEnter(SelectedUnit.x, SelectedUnit.y) | string.IsNullOrEmpty(Map.MapFileName))
            //            {
            //                GUI.ListItemFlag[Information.UBound(list)] = false;
            //            }
            //            else
            //            {
            //                GUI.ListItemFlag[Information.UBound(list)] = true;
            //            }
            //        }
            //    }
            //}

            //// 変形先の形態を選択
            //if (Information.UBound(list) == 1)
            //{
            //    if (GUI.ListItemFlag[1])
            //    {
            //        Interaction.MsgBox("この地形では" + GeneralLib.LIndex(fdata, 1) + "できません");
            //        CancelCommand();
            //        GUI.UnlockGUI();
            //        return;
            //    }

            //    ret = 1;
            //}
            //else
            //{
            //    GUI.TopItem = 1;
            //    if (!SelectedUnit.IsHero())
            //    {
            //        string arglb_caption1 = "変形先";
            //        string arglb_info1 = "名前";
            //        string arglb_mode1 = "カーソル移動";
            //        ret = GUI.ListBox(arglb_caption1, list, arglb_info1, arglb_mode1);
            //    }
            //    else
            //    {
            //        string arglb_caption2 = "変身先";
            //        string arglb_info2 = "名前";
            //        string arglb_mode2 = "カーソル移動";
            //        ret = GUI.ListBox(arglb_caption2, list, arglb_info2, arglb_mode2);
            //    }

            //    if (ret == 0)
            //    {
            //        CancelCommand();
            //        GUI.UnlockGUI();
            //        return;
            //    }
            //}

            //uname = list_id[ret];
            //string BGM;
            //{
            //    var withBlock3 = SelectedUnit;
            //    // ダイアログでメッセージを表示させるため追加パイロットをあらかじめ作成
            //    object argIndex6 = uname;
            //    {
            //        var withBlock4 = SRC.UDList.Item(argIndex6);
            //        string argfname = "追加パイロット";
            //        if (withBlock4.IsFeatureAvailable(argfname))
            //        {
            //            bool localIsDefined1() { object argIndex1 = "追加パイロット"; object argIndex2 = withBlock4.FeatureData(argIndex1); var ret = SRC.PList.IsDefined(argIndex2); return ret; }

            //            if (!localIsDefined1())
            //            {
            //                bool localIsDefined() { object argIndex1 = "追加パイロット"; object argIndex2 = withBlock4.FeatureData(argIndex1); var ret = SRC.PDList.IsDefined(argIndex2); return ret; }

            //                if (!localIsDefined())
            //                {
            //                    object argIndex4 = "追加パイロット";
            //                    string argmsg = uname + "の追加パイロット「" + withBlock4.FeatureData(argIndex4) + "」のデータが見つかりません";
            //                    GUI.ErrorMessage(argmsg);
            //                    SRC.TerminateSRC();
            //                }

            //                object argIndex5 = "追加パイロット";
            //                string argpname = withBlock4.FeatureData(argIndex5);
            //                string argpparty = SelectedUnit.Party0;
            //                string arggid = "";
            //                SRC.PList.Add(argpname, SelectedUnit.MainPilot().Level, argpparty, gid: arggid);
            //                SelectedUnit.Party0 = argpparty;
            //            }
            //        }
            //    }

            //    // ＢＧＭの変更
            //    string argfname1 = "変形ＢＧＭ";
            //    if (withBlock3.IsFeatureAvailable(argfname1))
            //    {
            //        var loopTo2 = withBlock3.CountFeature();
            //        for (i = 1; i <= loopTo2; i++)
            //        {
            //            string localFeature() { object argIndex1 = i; var ret = withBlock3.Feature(argIndex1); return ret; }

            //            string localFeatureData2() { object argIndex1 = i; var ret = withBlock3.FeatureData(argIndex1); return ret; }

            //            string localLIndex() { string arglist = hs6c18ebb7075745309751cd168b7bf5f0(); var ret = GeneralLib.LIndex(arglist, 1); return ret; }

            //            if (localFeature() == "変形ＢＧＭ" & (localLIndex() ?? "") == (uname ?? ""))
            //            {
            //                string localFeatureData() { object argIndex1 = i; var ret = withBlock3.FeatureData(argIndex1); return ret; }

            //                string localFeatureData1() { object argIndex1 = i; var ret = withBlock3.FeatureData(argIndex1); return ret; }

            //                string argmidi_name = Strings.Mid(localFeatureData(), Strings.InStr(localFeatureData1(), " ") + 1);
            //                BGM = Sound.SearchMidiFile(argmidi_name);
            //                if (Strings.Len(BGM) > 0)
            //                {
            //                    Sound.ChangeBGM(BGM);
            //                    GUI.Sleep(500);
            //                }

            //                break;
            //            }
            //        }
            //    }

            //    // メッセージを表示
            //    bool localIsMessageDefined2() { string argmain_situation = "変形(" + withBlock3.Name + "=>" + uname + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //    bool localIsMessageDefined3() { string argmain_situation = "変形(" + uname + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //    bool localIsMessageDefined4() { object argIndex1 = "変形"; string argmain_situation = "変形(" + withBlock3.FeatureName(argIndex1) + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //    if (localIsMessageDefined2() | localIsMessageDefined3() | localIsMessageDefined4())
            //    {
            //        GUI.Center(withBlock3.x, withBlock3.y);
            //        GUI.RefreshScreen();
            //        Unit argu1 = null;
            //        Unit argu2 = null;
            //        GUI.OpenMessageForm(u1: argu1, u2: argu2);
            //        bool localIsMessageDefined() { string argmain_situation = "変形(" + uname + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //        bool localIsMessageDefined1() { object argIndex1 = "変形"; string argmain_situation = "変形(" + withBlock3.FeatureName(argIndex1) + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //        string argmain_situation = "変形(" + withBlock3.Name + "=>" + uname + ")";
            //        if (withBlock3.IsMessageDefined(argmain_situation))
            //        {
            //            string argSituation = "変形(" + withBlock3.Name + "=>" + uname + ")";
            //            string argmsg_mode = "";
            //            withBlock3.PilotMessage(argSituation, msg_mode: argmsg_mode);
            //        }
            //        else if (localIsMessageDefined())
            //        {
            //            string argSituation1 = "変形(" + uname + ")";
            //            string argmsg_mode1 = "";
            //            withBlock3.PilotMessage(argSituation1, msg_mode: argmsg_mode1);
            //        }
            //        else if (localIsMessageDefined1())
            //        {
            //            object argIndex7 = "変形";
            //            string argSituation2 = "変形(" + withBlock3.FeatureName(argIndex7) + ")";
            //            string argmsg_mode2 = "";
            //            withBlock3.PilotMessage(argSituation2, msg_mode: argmsg_mode2);
            //        }

            //        GUI.CloseMessageForm();
            //    }

            //    // アニメ表示
            //    bool localIsAnimationDefined() { string argmain_situation = "変形(" + uname + ")"; string argsub_situation = ""; var ret = withBlock3.IsAnimationDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    bool localIsAnimationDefined1() { object argIndex1 = "変形"; string argmain_situation = "変形(" + withBlock3.FeatureName(argIndex1) + ")"; string argsub_situation = ""; var ret = withBlock3.IsAnimationDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    bool localIsSpecialEffectDefined() { string argmain_situation = "変形(" + withBlock3.Name + "=>" + uname + ")"; string argsub_situation = ""; var ret = withBlock3.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    bool localIsSpecialEffectDefined1() { string argmain_situation = "変形(" + uname + ")"; string argsub_situation = ""; var ret = withBlock3.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    bool localIsSpecialEffectDefined2() { object argIndex1 = "変形"; string argmain_situation = "変形(" + withBlock3.FeatureName(argIndex1) + ")"; string argsub_situation = ""; var ret = withBlock3.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    string argmain_situation7 = "変形(" + withBlock3.Name + "=>" + uname + ")";
            //    string argsub_situation6 = "";
            //    if (withBlock3.IsAnimationDefined(argmain_situation7, sub_situation: argsub_situation6))
            //    {
            //        string argmain_situation1 = "変形(" + withBlock3.Name + "=>" + uname + ")";
            //        string argsub_situation = "";
            //        withBlock3.PlayAnimation(argmain_situation1, sub_situation: argsub_situation);
            //    }
            //    else if (localIsAnimationDefined())
            //    {
            //        string argmain_situation2 = "変形(" + uname + ")";
            //        string argsub_situation1 = "";
            //        withBlock3.PlayAnimation(argmain_situation2, sub_situation: argsub_situation1);
            //    }
            //    else if (localIsAnimationDefined1())
            //    {
            //        object argIndex8 = "変形";
            //        string argmain_situation3 = "変形(" + withBlock3.FeatureName(argIndex8) + ")";
            //        string argsub_situation2 = "";
            //        withBlock3.PlayAnimation(argmain_situation3, sub_situation: argsub_situation2);
            //    }
            //    else if (localIsSpecialEffectDefined())
            //    {
            //        string argmain_situation4 = "変形(" + withBlock3.Name + "=>" + uname + ")";
            //        string argsub_situation3 = "";
            //        withBlock3.SpecialEffect(argmain_situation4, sub_situation: argsub_situation3);
            //    }
            //    else if (localIsSpecialEffectDefined1())
            //    {
            //        string argmain_situation5 = "変形(" + uname + ")";
            //        string argsub_situation4 = "";
            //        withBlock3.SpecialEffect(argmain_situation5, sub_situation: argsub_situation4);
            //    }
            //    else if (localIsSpecialEffectDefined2())
            //    {
            //        object argIndex9 = "変形";
            //        string argmain_situation6 = "変形(" + withBlock3.FeatureName(argIndex9) + ")";
            //        string argsub_situation5 = "";
            //        withBlock3.SpecialEffect(argmain_situation6, sub_situation: argsub_situation5);
            //    }
            //}

            //// 変形
            //prev_uname = SelectedUnit.Name;
            //SelectedUnit.Transform(uname);
            //SelectedUnit = Map.MapDataForUnit[SelectedUnit.x, SelectedUnit.y];

            //// 変形をキャンセルする？
            //if (SelectedUnit.Action == 0)
            //{
            //    ret = Interaction.MsgBox("この形態ではこれ以上の行動が出来ません。" + Constants.vbCr + Constants.vbLf + "それでも変形しますか？", (MsgBoxStyle)(MsgBoxStyle.OkCancel + MsgBoxStyle.Question), "変形");
            //    if (ret == MsgBoxResult.Cancel)
            //    {
            //        SelectedUnit.Transform(prev_uname);
            //        SelectedUnit = Map.MapDataForUnit[SelectedUnit.x, SelectedUnit.y];
            //        object argIndex11 = "消耗";
            //        if (SelectedUnit.IsConditionSatisfied(argIndex11))
            //        {
            //            object argIndex10 = "消耗";
            //            SelectedUnit.DeleteCondition(argIndex10);
            //        }
            //    }

            //    GUI.RedrawScreen();
            //}

            //// 変形イベント
            //{
            //    var withBlock5 = SelectedUnit.CurrentForm();
            //    Event_Renamed.HandleEvent("変形", withBlock5.MainPilot().ID, withBlock5.Name);
            //}

            //if (SRC.IsScenarioFinished)
            //{
            //    SRC.IsScenarioFinished = false;
            //    Status.ClearUnitStatus();
            //    GUI.RedrawScreen();
            //    CommandState = "ユニット選択";
            //    GUI.UnlockGUI();
            //    return;
            //}

            //SRC.IsCanceled = false;

            //// ハイパーモード・ノーマルモードの自動発動をチェック
            //SelectedUnit.CurrentForm().CheckAutoHyperMode();
            //SelectedUnit.CurrentForm().CheckAutoNormalMode();

            //// カーソル自動移動
            //if (SelectedUnit.Status_Renamed == "出撃")
            //{
            //    if (SRC.AutoMoveCursor)
            //    {
            //        string argcursor_mode = "ユニット選択";
            //        GUI.MoveCursorPos(argcursor_mode, SelectedUnit);
            //    }

            //    Status.DisplayUnitStatus(SelectedUnit);
            //}

            //CommandState = "ユニット選択";
            //GUI.UnlockGUI();
        }

        // 「ハイパーモード」コマンド
        private void HyperModeCommand()
        {
            throw new NotImplementedException();
            //// MOD END MARGE
            //string uname, fname;
            //int i;

            //// MOD START MARGE
            //// If MainWidth <> 15 Then
            //if (GUI.NewGUIMode)
            //{
            //    // MOD END MARGE
            //    Status.ClearUnitStatus();
            //}

            //GUI.LockGUI();
            //object argIndex1 = "ハイパーモード";
            //string arglist = SelectedUnit.FeatureData(argIndex1);
            //uname = GeneralLib.LIndex(arglist, 2);
            //object argIndex2 = "ハイパーモード";
            //fname = SelectedUnit.FeatureName(argIndex2);
            //if (string.IsNullOrEmpty(Map.MapFileName))
            //{
            //    // ユニットステータスコマンドの場合
            //    {
            //        var withBlock = SelectedUnit;
            //        string argfname = "ハイパーモード";
            //        if (!withBlock.IsFeatureAvailable(argfname))
            //        {
            //            object argIndex3 = "ノーマルモード";
            //            string arglist1 = SelectedUnit.FeatureData(argIndex3);
            //            uname = GeneralLib.LIndex(arglist1, 1);
            //        }

            //        // ハイパーモードを発動
            //        withBlock.Transform(uname);

            //        // ユニットリストの表示を更新
            //        string argsmode = "";
            //        Event_Renamed.MakeUnitList(smode: argsmode);

            //        // ステータスウィンドウの表示を更新
            //        Status.DisplayUnitStatus(withBlock.CurrentForm());

            //        // コマンドを終了
            //        GUI.UnlockGUI();
            //        CommandState = "ユニット選択";
            //        return;
            //    }
            //}

            //// ハイパーモードを発動可能かどうかチェック
            //object argIndex4 = uname;
            //{
            //    var withBlock1 = SelectedUnit.OtherForm(argIndex4);
            //    if (!withBlock1.IsAbleToEnter(SelectedUnit.x, SelectedUnit.y) & !string.IsNullOrEmpty(Map.MapFileName))
            //    {
            //        Interaction.MsgBox("この地形では変形できません");
            //        GUI.UnlockGUI();
            //        CancelCommand();
            //        return;
            //    }
            //}

            //// ダイアログでメッセージを表示させるため追加パイロットをあらかじめ作成
            //object argIndex7 = uname;
            //{
            //    var withBlock2 = SRC.UDList.Item(argIndex7);
            //    string argfname1 = "追加パイロット";
            //    if (withBlock2.IsFeatureAvailable(argfname1))
            //    {
            //        bool localIsDefined1() { object argIndex1 = "追加パイロット"; object argIndex2 = withBlock2.FeatureData(argIndex1); var ret = SRC.PList.IsDefined(argIndex2); return ret; }

            //        if (!localIsDefined1())
            //        {
            //            bool localIsDefined() { object argIndex1 = "追加パイロット"; object argIndex2 = withBlock2.FeatureData(argIndex1); var ret = SRC.PDList.IsDefined(argIndex2); return ret; }

            //            if (!localIsDefined())
            //            {
            //                object argIndex5 = "追加パイロット";
            //                string argmsg = uname + "の追加パイロット「" + withBlock2.FeatureData(argIndex5) + "」のデータが見つかりません";
            //                GUI.ErrorMessage(argmsg);
            //                SRC.TerminateSRC();
            //            }

            //            object argIndex6 = "追加パイロット";
            //            string argpname = withBlock2.FeatureData(argIndex6);
            //            string argpparty = SelectedUnit.Party0;
            //            string arggid = "";
            //            SRC.PList.Add(argpname, SelectedUnit.MainPilot().Level, argpparty, gid: arggid);
            //            SelectedUnit.Party0 = argpparty;
            //        }
            //    }
            //}

            //string BGM;
            //{
            //    var withBlock3 = SelectedUnit;
            //    // ＢＧＭを変更
            //    string argfname2 = "ハイパーモードＢＧＭ";
            //    if (withBlock3.IsFeatureAvailable(argfname2))
            //    {
            //        var loopTo = withBlock3.CountFeature();
            //        for (i = 1; i <= loopTo; i++)
            //        {
            //            string localFeature() { object argIndex1 = i; var ret = withBlock3.Feature(argIndex1); return ret; }

            //            string localFeatureData2() { object argIndex1 = i; var ret = withBlock3.FeatureData(argIndex1); return ret; }

            //            string localLIndex() { string arglist = hs79a81f167161473a965a38e7883f62a2(); var ret = GeneralLib.LIndex(arglist, 1); return ret; }

            //            if (localFeature() == "ハイパーモードＢＧＭ" & (localLIndex() ?? "") == (uname ?? ""))
            //            {
            //                string localFeatureData() { object argIndex1 = i; var ret = withBlock3.FeatureData(argIndex1); return ret; }

            //                string localFeatureData1() { object argIndex1 = i; var ret = withBlock3.FeatureData(argIndex1); return ret; }

            //                string argmidi_name = Strings.Mid(localFeatureData(), Strings.InStr(localFeatureData1(), " ") + 1);
            //                BGM = Sound.SearchMidiFile(argmidi_name);
            //                if (Strings.Len(BGM) > 0)
            //                {
            //                    Sound.ChangeBGM(BGM);
            //                    GUI.Sleep(500);
            //                }

            //                break;
            //            }
            //        }
            //    }

            //    // メッセージを表示
            //    bool localIsMessageDefined2() { string argmain_situation = "ハイパーモード(" + withBlock3.Name + "=>" + uname + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //    bool localIsMessageDefined3() { string argmain_situation = "ハイパーモード(" + uname + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //    bool localIsMessageDefined4() { string argmain_situation = "ハイパーモード(" + fname + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //    string argmain_situation1 = "ハイパーモード";
            //    if (localIsMessageDefined2() | localIsMessageDefined3() | localIsMessageDefined4() | withBlock3.IsMessageDefined(argmain_situation1))
            //    {
            //        GUI.Center(withBlock3.x, withBlock3.y);
            //        GUI.RefreshScreen();
            //        Unit argu1 = null;
            //        Unit argu2 = null;
            //        GUI.OpenMessageForm(u1: argu1, u2: argu2);
            //        bool localIsMessageDefined() { string argmain_situation = "ハイパーモード(" + uname + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //        bool localIsMessageDefined1() { string argmain_situation = "ハイパーモード(" + fname + ")"; var ret = withBlock3.IsMessageDefined(argmain_situation); return ret; }

            //        string argmain_situation = "ハイパーモード(" + withBlock3.Name + "=>" + uname + ")";
            //        if (withBlock3.IsMessageDefined(argmain_situation))
            //        {
            //            string argSituation = "ハイパーモード(" + withBlock3.Name + "=>" + uname + ")";
            //            string argmsg_mode = "";
            //            withBlock3.PilotMessage(argSituation, msg_mode: argmsg_mode);
            //        }
            //        else if (localIsMessageDefined())
            //        {
            //            string argSituation2 = "ハイパーモード(" + uname + ")";
            //            string argmsg_mode2 = "";
            //            withBlock3.PilotMessage(argSituation2, msg_mode: argmsg_mode2);
            //        }
            //        else if (localIsMessageDefined1())
            //        {
            //            string argSituation3 = "ハイパーモード(" + fname + ")";
            //            string argmsg_mode3 = "";
            //            withBlock3.PilotMessage(argSituation3, msg_mode: argmsg_mode3);
            //        }
            //        else
            //        {
            //            string argSituation1 = "ハイパーモード";
            //            string argmsg_mode1 = "";
            //            withBlock3.PilotMessage(argSituation1, msg_mode: argmsg_mode1);
            //        }

            //        GUI.CloseMessageForm();
            //    }

            //    // アニメ表示
            //    bool localIsAnimationDefined() { string argmain_situation = "ハイパーモード(" + uname + ")"; string argsub_situation = ""; var ret = withBlock3.IsAnimationDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    bool localIsAnimationDefined1() { string argmain_situation = "ハイパーモード(" + fname + ")"; string argsub_situation = ""; var ret = withBlock3.IsAnimationDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    bool localIsSpecialEffectDefined() { string argmain_situation = "ハイパーモード(" + withBlock3.Name + "=>" + uname + ")"; string argsub_situation = ""; var ret = withBlock3.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    bool localIsSpecialEffectDefined1() { string argmain_situation = "ハイパーモード(" + uname + ")"; string argsub_situation = ""; var ret = withBlock3.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    bool localIsSpecialEffectDefined2() { string argmain_situation = "ハイパーモード(" + fname + ")"; string argsub_situation = ""; var ret = withBlock3.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //    string argmain_situation10 = "ハイパーモード(" + withBlock3.Name + "=>" + uname + ")";
            //    string argsub_situation8 = "";
            //    string argmain_situation11 = "ハイパーモード";
            //    string argsub_situation9 = "";
            //    if (withBlock3.IsAnimationDefined(argmain_situation10, sub_situation: argsub_situation8))
            //    {
            //        string argmain_situation2 = "ハイパーモード(" + withBlock3.Name + "=>" + uname + ")";
            //        string argsub_situation = "";
            //        withBlock3.PlayAnimation(argmain_situation2, sub_situation: argsub_situation);
            //    }
            //    else if (localIsAnimationDefined())
            //    {
            //        string argmain_situation4 = "ハイパーモード(" + uname + ")";
            //        string argsub_situation2 = "";
            //        withBlock3.PlayAnimation(argmain_situation4, sub_situation: argsub_situation2);
            //    }
            //    else if (localIsAnimationDefined1())
            //    {
            //        string argmain_situation5 = "ハイパーモード(" + fname + ")";
            //        string argsub_situation3 = "";
            //        withBlock3.PlayAnimation(argmain_situation5, sub_situation: argsub_situation3);
            //    }
            //    else if (withBlock3.IsAnimationDefined(argmain_situation11, sub_situation: argsub_situation9))
            //    {
            //        string argmain_situation6 = "ハイパーモード";
            //        string argsub_situation4 = "";
            //        withBlock3.PlayAnimation(argmain_situation6, sub_situation: argsub_situation4);
            //    }
            //    else if (localIsSpecialEffectDefined())
            //    {
            //        string argmain_situation7 = "ハイパーモード(" + withBlock3.Name + "=>" + uname + ")";
            //        string argsub_situation5 = "";
            //        withBlock3.SpecialEffect(argmain_situation7, sub_situation: argsub_situation5);
            //    }
            //    else if (localIsSpecialEffectDefined1())
            //    {
            //        string argmain_situation8 = "ハイパーモード(" + uname + ")";
            //        string argsub_situation6 = "";
            //        withBlock3.SpecialEffect(argmain_situation8, sub_situation: argsub_situation6);
            //    }
            //    else if (localIsSpecialEffectDefined2())
            //    {
            //        string argmain_situation9 = "ハイパーモード(" + fname + ")";
            //        string argsub_situation7 = "";
            //        withBlock3.SpecialEffect(argmain_situation9, sub_situation: argsub_situation7);
            //    }
            //    else
            //    {
            //        string argmain_situation3 = "ハイパーモード";
            //        string argsub_situation1 = "";
            //        withBlock3.SpecialEffect(argmain_situation3, sub_situation: argsub_situation1);
            //    }
            //}

            //// ハイパーモード発動
            //SelectedUnit.Transform(uname);

            //// ハイパーモード・ノーマルモードの自動発動をチェック
            //SelectedUnit.CurrentForm().CheckAutoHyperMode();
            //SelectedUnit.CurrentForm().CheckAutoNormalMode();
            //SelectedUnit = Map.MapDataForUnit[SelectedUnit.x, SelectedUnit.y];

            //// 変形イベント
            //{
            //    var withBlock4 = SelectedUnit.CurrentForm();
            //    Event_Renamed.HandleEvent("変形", withBlock4.MainPilot().ID, withBlock4.Name);
            //}

            //if (SRC.IsScenarioFinished)
            //{
            //    SRC.IsScenarioFinished = false;
            //    Status.ClearUnitStatus();
            //    GUI.RedrawScreen();
            //    CommandState = "ユニット選択";
            //    GUI.UnlockGUI();
            //    return;
            //}

            //SRC.IsCanceled = false;

            //// カーソル自動移動
            //if (SelectedUnit.Status_Renamed == "出撃")
            //{
            //    if (SRC.AutoMoveCursor)
            //    {
            //        string argcursor_mode = "ユニット選択";
            //        GUI.MoveCursorPos(argcursor_mode, SelectedUnit);
            //    }

            //    Status.DisplayUnitStatus(SelectedUnit);
            //}

            //CommandState = "ユニット選択";
            //GUI.UnlockGUI();
        }

        // 「変身解除」コマンド
        private void CancelTransformationCommand()
        {
            throw new NotImplementedException();
            //int ret;

            //// MOD START MARGE
            //// If MainWidth <> 15 Then
            //if (GUI.NewGUIMode)
            //{
            //    // MOD END MARGE
            //    Status.ClearUnitStatus();
            //}

            //GUI.LockGUI();
            //{
            //    var withBlock = SelectedUnit;
            //    if (string.IsNullOrEmpty(Map.MapFileName))
            //    {
            //        // ユニットステータスコマンドの場合
            //        string localLIndex() { object argIndex1 = "ノーマルモード"; string arglist = withBlock.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 1); return ret; }

            //        string argnew_form = localLIndex();
            //        withBlock.Transform(argnew_form);
            //        string argsmode = "";
            //        Event_Renamed.MakeUnitList(smode: argsmode);
            //        Status.DisplayUnitStatus(withBlock.CurrentForm());
            //        GUI.UnlockGUI();
            //        CommandState = "ユニット選択";
            //        return;
            //    }

            //    if (withBlock.IsHero())
            //    {
            //        ret = Interaction.MsgBox("変身を解除しますか？", (MsgBoxStyle)(MsgBoxStyle.OkCancel + MsgBoxStyle.Question), "変身解除");
            //    }
            //    else
            //    {
            //        ret = Interaction.MsgBox("特殊モードを解除しますか？", (MsgBoxStyle)(MsgBoxStyle.OkCancel + MsgBoxStyle.Question), "特殊モード解除");
            //    }

            //    if (ret == MsgBoxResult.Cancel)
            //    {
            //        GUI.UnlockGUI();
            //        CancelCommand();
            //        return;
            //    }

            //    string localLIndex1() { object argIndex1 = "ノーマルモード"; string arglist = withBlock.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 1); return ret; }

            //    string argnew_form1 = localLIndex1();
            //    withBlock.Transform(argnew_form1);
            //    SelectedUnit = Map.MapDataForUnit[withBlock.x, withBlock.y];
            //}

            //// カーソル自動移動
            //if (SRC.AutoMoveCursor)
            //{
            //    string argcursor_mode = "ユニット選択";
            //    GUI.MoveCursorPos(argcursor_mode, SelectedUnit);
            //}

            //Status.DisplayUnitStatus(SelectedUnit);
            //GUI.RedrawScreen();

            //// 変形イベント
            //Event_Renamed.HandleEvent("変形", SelectedUnit.MainPilot().ID, SelectedUnit.Name);
            //SRC.IsScenarioFinished = false;
            //SRC.IsCanceled = false;
            //CommandState = "ユニット選択";
            //GUI.UnlockGUI();
        }

        // 「分離」コマンド
        private void SplitCommand()
        {
            throw new NotImplementedException();
            //// MOD END MARGE
            //string uname, tname, fname;
            //int ret;
            //string BGM;

            //// MOD START MARGE
            //// If MainWidth <> 15 Then
            //if (GUI.NewGUIMode)
            //{
            //    // MOD END MARGE
            //    Status.ClearUnitStatus();
            //}

            //GUI.LockGUI();
            //if (string.IsNullOrEmpty(Map.MapFileName))
            //{
            //    // ユニットステータスコマンドの場合

            //    // 分離を実施
            //    {
            //        var withBlock = SelectedUnit;
            //        string argfname = "パーツ分離";
            //        if (withBlock.IsFeatureAvailable(argfname))
            //        {
            //            object argIndex1 = "パーツ分離";
            //            string arglist = withBlock.FeatureData(argIndex1);
            //            tname = GeneralLib.LIndex(arglist, 2);
            //            withBlock.Transform(tname);
            //        }
            //        else
            //        {
            //            withBlock.Split_Renamed();
            //        }

            //        SRC.UList.CheckAutoHyperMode();
            //        SRC.UList.CheckAutoNormalMode();
            //        Status.DisplayUnitStatus(Map.MapDataForUnit[withBlock.x, withBlock.y]);
            //    }

            //    // ユニットリストの表示を更新
            //    string argsmode = "";
            //    Event_Renamed.MakeUnitList(smode: argsmode);

            //    // コマンドを終了
            //    CommandState = "ユニット選択";
            //    GUI.UnlockGUI();
            //    return;
            //}

            //{
            //    var withBlock1 = SelectedUnit;
            //    string argfname3 = "パーツ分離";
            //    if (withBlock1.IsFeatureAvailable(argfname3))
            //    {
            //        // パーツ分離を行う場合

            //        ret = Interaction.MsgBox("パーツを分離しますか？", (MsgBoxStyle)(MsgBoxStyle.OkCancel + MsgBoxStyle.Question), "パーツ分離");
            //        if (ret == MsgBoxResult.Cancel)
            //        {
            //            GUI.UnlockGUI();
            //            CancelCommand();
            //            return;
            //        }

            //        object argIndex2 = "パーツ分離";
            //        string arglist1 = withBlock1.FeatureData(argIndex2);
            //        tname = GeneralLib.LIndex(arglist1, 2);
            //        Unit localOtherForm() { object argIndex1 = tname; var ret = withBlock1.OtherForm(argIndex1); return ret; }

            //        if (!localOtherForm().IsAbleToEnter(withBlock1.x, withBlock1.y))
            //        {
            //            Interaction.MsgBox("この地形では分離できません");
            //            GUI.UnlockGUI();
            //            CancelCommand();
            //            return;
            //        }

            //        // ＢＧＭ変更
            //        string argfname1 = "分離ＢＧＭ";
            //        if (withBlock1.IsFeatureAvailable(argfname1))
            //        {
            //            object argIndex3 = "分離ＢＧＭ";
            //            string argmidi_name = withBlock1.FeatureData(argIndex3);
            //            BGM = Sound.SearchMidiFile(argmidi_name);
            //            if (Strings.Len(BGM) > 0)
            //            {
            //                object argIndex4 = "分離ＢＧＭ";
            //                string argbgm_name = withBlock1.FeatureData(argIndex4);
            //                Sound.StartBGM(argbgm_name);
            //                GUI.Sleep(500);
            //            }
            //        }

            //        object argIndex5 = "パーツ分離";
            //        fname = withBlock1.FeatureName(argIndex5);

            //        // メッセージを表示
            //        bool localIsMessageDefined1() { string argmain_situation = "分離(" + withBlock1.Name + ")"; var ret = withBlock1.IsMessageDefined(argmain_situation); return ret; }

            //        bool localIsMessageDefined2() { string argmain_situation = "分離(" + fname + ")"; var ret = withBlock1.IsMessageDefined(argmain_situation); return ret; }

            //        string argmain_situation1 = "分離";
            //        if (localIsMessageDefined1() | localIsMessageDefined2() | withBlock1.IsMessageDefined(argmain_situation1))
            //        {
            //            GUI.Center(withBlock1.x, withBlock1.y);
            //            GUI.RefreshScreen();
            //            Unit argu1 = null;
            //            Unit argu2 = null;
            //            GUI.OpenMessageForm(u1: argu1, u2: argu2);
            //            bool localIsMessageDefined() { string argmain_situation = "分離(" + fname + ")"; var ret = withBlock1.IsMessageDefined(argmain_situation); return ret; }

            //            string argmain_situation = "分離(" + withBlock1.Name + ")";
            //            if (withBlock1.IsMessageDefined(argmain_situation))
            //            {
            //                string argSituation = "分離(" + withBlock1.Name + ")";
            //                string argmsg_mode = "";
            //                withBlock1.PilotMessage(argSituation, msg_mode: argmsg_mode);
            //            }
            //            else if (localIsMessageDefined())
            //            {
            //                string argSituation2 = "分離(" + fname + ")";
            //                string argmsg_mode2 = "";
            //                withBlock1.PilotMessage(argSituation2, msg_mode: argmsg_mode2);
            //            }
            //            else
            //            {
            //                string argSituation1 = "分離";
            //                string argmsg_mode1 = "";
            //                withBlock1.PilotMessage(argSituation1, msg_mode: argmsg_mode1);
            //            }

            //            GUI.CloseMessageForm();
            //        }

            //        // アニメ表示
            //        bool localIsAnimationDefined() { string argmain_situation = "分離(" + fname + ")"; string argsub_situation = ""; var ret = withBlock1.IsAnimationDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //        bool localIsSpecialEffectDefined() { string argmain_situation = "分離(" + withBlock1.Name + ")"; string argsub_situation = ""; var ret = withBlock1.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //        bool localIsSpecialEffectDefined1() { string argmain_situation = "分離(" + fname + ")"; string argsub_situation = ""; var ret = withBlock1.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //        string argmain_situation8 = "分離(" + withBlock1.Name + ")";
            //        string argsub_situation6 = "";
            //        string argmain_situation9 = "分離";
            //        string argsub_situation7 = "";
            //        if (withBlock1.IsAnimationDefined(argmain_situation8, sub_situation: argsub_situation6))
            //        {
            //            string argmain_situation2 = "分離(" + withBlock1.Name + ")";
            //            string argsub_situation = "";
            //            withBlock1.PlayAnimation(argmain_situation2, sub_situation: argsub_situation);
            //        }
            //        else if (localIsAnimationDefined())
            //        {
            //            string argmain_situation4 = "分離(" + fname + ")";
            //            string argsub_situation2 = "";
            //            withBlock1.PlayAnimation(argmain_situation4, sub_situation: argsub_situation2);
            //        }
            //        else if (withBlock1.IsAnimationDefined(argmain_situation9, sub_situation: argsub_situation7))
            //        {
            //            string argmain_situation5 = "分離";
            //            string argsub_situation3 = "";
            //            withBlock1.PlayAnimation(argmain_situation5, sub_situation: argsub_situation3);
            //        }
            //        else if (localIsSpecialEffectDefined())
            //        {
            //            string argmain_situation6 = "分離(" + withBlock1.Name + ")";
            //            string argsub_situation4 = "";
            //            withBlock1.SpecialEffect(argmain_situation6, sub_situation: argsub_situation4);
            //        }
            //        else if (localIsSpecialEffectDefined1())
            //        {
            //            string argmain_situation7 = "分離(" + fname + ")";
            //            string argsub_situation5 = "";
            //            withBlock1.SpecialEffect(argmain_situation7, sub_situation: argsub_situation5);
            //        }
            //        else
            //        {
            //            string argmain_situation3 = "分離";
            //            string argsub_situation1 = "";
            //            withBlock1.SpecialEffect(argmain_situation3, sub_situation: argsub_situation1);
            //        }

            //        // パーツ分離
            //        uname = withBlock1.Name;
            //        withBlock1.Transform(tname);
            //        SelectedUnit = Map.MapDataForUnit[withBlock1.x, withBlock1.y];
            //        Status.DisplayUnitStatus(SelectedUnit);
            //    }
            //    else
            //    {
            //        // 通常の分離を行う場合

            //        ret = Interaction.MsgBox("分離しますか？", (MsgBoxStyle)(MsgBoxStyle.OkCancel + MsgBoxStyle.Question), "分離");
            //        if (ret == MsgBoxResult.Cancel)
            //        {
            //            GUI.UnlockGUI();
            //            CancelCommand();
            //            return;
            //        }

            //        // ＢＧＭを変更
            //        string argfname2 = "分離ＢＧＭ";
            //        if (withBlock1.IsFeatureAvailable(argfname2))
            //        {
            //            object argIndex6 = "分離ＢＧＭ";
            //            string argmidi_name1 = withBlock1.FeatureData(argIndex6);
            //            BGM = Sound.SearchMidiFile(argmidi_name1);
            //            if (Strings.Len(BGM) > 0)
            //            {
            //                object argIndex7 = "分離ＢＧＭ";
            //                string argbgm_name1 = withBlock1.FeatureData(argIndex7);
            //                Sound.StartBGM(argbgm_name1);
            //                GUI.Sleep(500);
            //            }
            //        }

            //        object argIndex8 = "分離";
            //        fname = withBlock1.FeatureName(argIndex8);

            //        // メッセージを表示
            //        bool localIsMessageDefined4() { string argmain_situation = "分離(" + withBlock1.Name + ")"; var ret = withBlock1.IsMessageDefined(argmain_situation); return ret; }

            //        bool localIsMessageDefined5() { string argmain_situation = "分離(" + fname + ")"; var ret = withBlock1.IsMessageDefined(argmain_situation); return ret; }

            //        string argmain_situation11 = "分離";
            //        if (localIsMessageDefined4() | localIsMessageDefined5() | withBlock1.IsMessageDefined(argmain_situation11))
            //        {
            //            GUI.Center(withBlock1.x, withBlock1.y);
            //            GUI.RefreshScreen();
            //            Unit argu11 = null;
            //            Unit argu21 = null;
            //            GUI.OpenMessageForm(u1: argu11, u2: argu21);
            //            bool localIsMessageDefined3() { string argmain_situation = "分離(" + fname + ")"; var ret = withBlock1.IsMessageDefined(argmain_situation); return ret; }

            //            string argmain_situation10 = "分離(" + withBlock1.Name + ")";
            //            if (withBlock1.IsMessageDefined(argmain_situation10))
            //            {
            //                string argSituation3 = "分離(" + withBlock1.Name + ")";
            //                string argmsg_mode3 = "";
            //                withBlock1.PilotMessage(argSituation3, msg_mode: argmsg_mode3);
            //            }
            //            else if (localIsMessageDefined3())
            //            {
            //                string argSituation5 = "分離(" + fname + ")";
            //                string argmsg_mode5 = "";
            //                withBlock1.PilotMessage(argSituation5, msg_mode: argmsg_mode5);
            //            }
            //            else
            //            {
            //                string argSituation4 = "分離";
            //                string argmsg_mode4 = "";
            //                withBlock1.PilotMessage(argSituation4, msg_mode: argmsg_mode4);
            //            }

            //            GUI.CloseMessageForm();
            //        }

            //        // アニメ表示
            //        bool localIsAnimationDefined1() { string argmain_situation = "分離(" + fname + ")"; string argsub_situation = ""; var ret = withBlock1.IsAnimationDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //        bool localIsSpecialEffectDefined2() { string argmain_situation = "分離(" + withBlock1.Name + ")"; string argsub_situation = ""; var ret = withBlock1.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //        bool localIsSpecialEffectDefined3() { string argmain_situation = "分離(" + fname + ")"; string argsub_situation = ""; var ret = withBlock1.IsSpecialEffectDefined(argmain_situation, sub_situation: argsub_situation); return ret; }

            //        string argmain_situation18 = "分離(" + withBlock1.Name + ")";
            //        string argsub_situation14 = "";
            //        string argmain_situation19 = "分離";
            //        string argsub_situation15 = "";
            //        if (withBlock1.IsAnimationDefined(argmain_situation18, sub_situation: argsub_situation14))
            //        {
            //            string argmain_situation12 = "分離(" + withBlock1.Name + ")";
            //            string argsub_situation8 = "";
            //            withBlock1.PlayAnimation(argmain_situation12, sub_situation: argsub_situation8);
            //        }
            //        else if (localIsAnimationDefined1())
            //        {
            //            string argmain_situation14 = "分離(" + fname + ")";
            //            string argsub_situation10 = "";
            //            withBlock1.PlayAnimation(argmain_situation14, sub_situation: argsub_situation10);
            //        }
            //        else if (withBlock1.IsAnimationDefined(argmain_situation19, sub_situation: argsub_situation15))
            //        {
            //            string argmain_situation15 = "分離";
            //            string argsub_situation11 = "";
            //            withBlock1.PlayAnimation(argmain_situation15, sub_situation: argsub_situation11);
            //        }
            //        else if (localIsSpecialEffectDefined2())
            //        {
            //            string argmain_situation16 = "分離(" + withBlock1.Name + ")";
            //            string argsub_situation12 = "";
            //            withBlock1.SpecialEffect(argmain_situation16, sub_situation: argsub_situation12);
            //        }
            //        else if (localIsSpecialEffectDefined3())
            //        {
            //            string argmain_situation17 = "分離(" + fname + ")";
            //            string argsub_situation13 = "";
            //            withBlock1.SpecialEffect(argmain_situation17, sub_situation: argsub_situation13);
            //        }
            //        else
            //        {
            //            string argmain_situation13 = "分離";
            //            string argsub_situation9 = "";
            //            withBlock1.SpecialEffect(argmain_situation13, sub_situation: argsub_situation9);
            //        }

            //        // 分離
            //        uname = withBlock1.Name;
            //        withBlock1.Split_Renamed();

            //        // 選択ユニットを再設定
            //        string localLIndex() { object argIndex1 = "分離"; string arglist = withBlock1.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

            //        object argIndex9 = localLIndex();
            //        SelectedUnit = SRC.UList.Item(argIndex9);
            //        Status.DisplayUnitStatus(SelectedUnit);
            //    }
            //}

            //// 分離イベント
            //Event_Renamed.HandleEvent("分離", SelectedUnit.MainPilot().ID, uname);
            //if (SRC.IsScenarioFinished)
            //{
            //    SRC.IsScenarioFinished = false;
            //    Status.ClearUnitStatus();
            //    GUI.RedrawScreen();
            //    CommandState = "ユニット選択";
            //    GUI.UnlockGUI();
            //    return;
            //}

            //SRC.IsCanceled = false;

            //// カーソル自動移動
            //if (SRC.AutoMoveCursor)
            //{
            //    string argcursor_mode = "ユニット選択";
            //    GUI.MoveCursorPos(argcursor_mode, SelectedUnit);
            //}

            //// ハイパーモード＆ノーマルモードの自動発動チェック
            //SRC.UList.CheckAutoHyperMode();
            //SRC.UList.CheckAutoNormalMode();
            //CommandState = "ユニット選択";
            //GUI.UnlockGUI();
        }

        // 「合体」コマンド
        private void CombineCommand()
        {
            throw new NotImplementedException();
            //// MOD END MARGE
            //int i, j;
            //string[] list;
            //Unit u;

            //// MOD START MARGE
            //// If MainWidth <> 15 Then
            //if (GUI.NewGUIMode)
            //{
            //    // MOD END MARGE
            //    Status.ClearUnitStatus();
            //}

            //GUI.LockGUI();
            //list = new string[1];
            //GUI.ListItemFlag = new bool[1];
            //{
            //    var withBlock = SelectedUnit;
            //    if (string.IsNullOrEmpty(Map.MapFileName))
            //    {
            //        // ユニットステータスコマンドの時
            //        // パーツ合体ならば……
            //        string argfname = "パーツ合体";
            //        if (GUI.MainForm.mnuUnitCommandItem.Item(CombineCmdID).Caption == "パーツ合体" & withBlock.IsFeatureAvailable(argfname))
            //        {
            //            // パーツ合体を実施
            //            object argIndex1 = "パーツ合体";
            //            string argnew_form = withBlock.FeatureData(argIndex1);
            //            withBlock.Transform(argnew_form);
            //            Status.DisplayUnitStatus(Map.MapDataForUnit[withBlock.x, withBlock.y]);
            //            Map.MapDataForUnit[withBlock.x, withBlock.y].CheckAutoHyperMode();
            //            Map.MapDataForUnit[withBlock.x, withBlock.y].CheckAutoNormalMode();

            //            // ユニットリストの表示を更新
            //            string argsmode = "";
            //            Event_Renamed.MakeUnitList(smode: argsmode);

            //            // コマンドを終了
            //            CommandState = "ユニット選択";
            //            GUI.UnlockGUI();
            //            return;
            //        }
            //    }

            //    // 選択可能な合体パターンのリストを作成
            //    var loopTo = withBlock.CountFeature();
            //    for (i = 1; i <= loopTo; i++)
            //    {
            //        string localFeature() { object argIndex1 = i; var ret = withBlock.Feature(argIndex1); return ret; }

            //        string localFeatureData4() { object argIndex1 = i; var ret = withBlock.FeatureData(argIndex1); return ret; }

            //        int localLLength() { string arglist = hsdebc20cc3cfc47d3be3b16b45d9b88b4(); var ret = GeneralLib.LLength(arglist); return ret; }

            //        if (localFeature() == "合体" & (localLLength() > 3 | string.IsNullOrEmpty(Map.MapFileName)))
            //        {
            //            string localFeatureData() { object argIndex1 = i; var ret = withBlock.FeatureData(argIndex1); return ret; }

            //            string localLIndex() { string arglist = hs8ad4cb28843f4cd79e5881037333d438(); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

            //            bool localIsDefined() { object argIndex1 = (object)hs340135fe58cf47dbaf5b402aedf48d4a(); var ret = SRC.UList.IsDefined(argIndex1); return ret; }

            //            if (!localIsDefined())
            //            {
            //                goto NextLoop;
            //            }

            //            string localFeatureData2() { object argIndex1 = i; var ret = withBlock.FeatureData(argIndex1); return ret; }

            //            string arglist = localFeatureData2();
            //            var loopTo1 = GeneralLib.LLength(arglist);
            //            for (j = 3; j <= loopTo1; j++)
            //            {
            //                string localFeatureData1() { object argIndex1 = i; var ret = withBlock.FeatureData(argIndex1); return ret; }

            //                string localLIndex1() { string arglist = hs751afdc814f14f178b9bc1e2c197a85c(); var ret = GeneralLib.LIndex(arglist, j); return ret; }

            //                object argIndex2 = localLIndex1();
            //                u = SRC.UList.Item(argIndex2);
            //                if (u is null)
            //                {
            //                    goto NextLoop;
            //                }

            //                if (!u.IsOperational())
            //                {
            //                    goto NextLoop;
            //                }

            //                string argfname1 = "合体制限";
            //                if (u.Status_Renamed != "出撃" & u.CurrentForm().IsFeatureAvailable(argfname1))
            //                {
            //                    goto NextLoop;
            //                }

            //                if (!string.IsNullOrEmpty(Map.MapFileName))
            //                {
            //                    if (Math.Abs((withBlock.x - u.CurrentForm().x)) > 2 | Math.Abs((withBlock.y - u.CurrentForm().y)) > 2)
            //                    {
            //                        goto NextLoop;
            //                    }
            //                }
            //            }

            //            Array.Resize(list, Information.UBound(list) + 1 + 1);
            //            GUI.ListItemFlag = new bool[Information.UBound(list) + 1];
            //            string localFeatureData3() { object argIndex1 = i; var ret = withBlock.FeatureData(argIndex1); return ret; }

            //            string arglist1 = localFeatureData3();
            //            list[Information.UBound(list)] = GeneralLib.LIndex(arglist1, 2);
            //            GUI.ListItemFlag[Information.UBound(list)] = false;
            //        }

            //    NextLoop:
            //        ;
            //    }

            //    // どの合体を行うかを選択
            //    if (Information.UBound(list) == 1)
            //    {
            //        i = 1;
            //    }
            //    else
            //    {
            //        GUI.TopItem = 1;
            //        string arglb_caption = "合体後の形態";
            //        string arglb_info = "名前";
            //        string arglb_mode = "";
            //        i = GUI.ListBox(arglb_caption, list, arglb_info, lb_mode: arglb_mode);
            //        if (i == 0)
            //        {
            //            CancelCommand();
            //            GUI.UnlockGUI();
            //            return;
            //        }
            //    }
            //}

            //if (string.IsNullOrEmpty(Map.MapFileName))
            //{
            //    // ユニットステータスコマンドの時
            //    SelectedUnit.Combine(list[i], true);

            //    // ハイパーモード・ノーマルモードの自動発動をチェック
            //    SRC.UList.CheckAutoHyperMode();
            //    SRC.UList.CheckAutoNormalMode();

            //    // ユニットリストの表示を更新
            //    string argsmode1 = "";
            //    Event_Renamed.MakeUnitList(smode: argsmode1);

            //    // コマンドを終了
            //    CommandState = "ユニット選択";
            //    GUI.UnlockGUI();
            //    return;
            //}

            //// 合体！
            //SelectedUnit.Combine(list[i]);

            //// ハイパーモード＆ノーマルモードの自動発動
            //SRC.UList.CheckAutoHyperMode();
            //SRC.UList.CheckAutoNormalMode();

            //// 合体後のユニットを選択しておく
            //SelectedUnit = Map.MapDataForUnit[SelectedUnit.x, SelectedUnit.y];

            //// 行動数消費
            //SelectedUnit.UseAction();

            //// カーソル自動移動
            //if (SRC.AutoMoveCursor)
            //{
            //    string argcursor_mode = "ユニット選択";
            //    GUI.MoveCursorPos(argcursor_mode, SelectedUnit);
            //}

            //Status.DisplayUnitStatus(SelectedUnit);

            //// 合体イベント
            //Event_Renamed.HandleEvent("合体", SelectedUnit.MainPilot().ID, SelectedUnit.Name);
            //if (SRC.IsScenarioFinished)
            //{
            //    SRC.IsScenarioFinished = false;
            //    GUI.UnlockGUI();
            //    return;
            //}

            //if (SRC.IsCanceled)
            //{
            //    SRC.IsCanceled = false;
            //    Status.ClearUnitStatus();
            //    GUI.RedrawScreen();
            //    CommandState = "ユニット選択";
            //    GUI.UnlockGUI();
            //    return;
            //}

            //// 行動終了
            //WaitCommand(true);
        }

        // 「換装」コマンド
        public void ExchangeFormCommand()
        {
            throw new NotImplementedException();
            //// MOD END MARGE
            //string[] list;
            //string[] id_list;
            //int j, i, k;
            //int max_value;
            //int ret;
            //string fdata;
            //string[] farray;
            //GUI.LockGUI();
            //{
            //    var withBlock = SelectedUnit;
            //    object argIndex1 = "換装";
            //    fdata = withBlock.FeatureData(argIndex1);

            //    // 選択可能な換装先のリストを作成
            //    list = new string[1];
            //    id_list = new string[1];
            //    GUI.ListItemComment = new string[1];
            //    var loopTo = GeneralLib.LLength(fdata);
            //    for (i = 1; i <= loopTo; i++)
            //    {
            //        object argIndex5 = GeneralLib.LIndex(fdata, i);
            //        {
            //            var withBlock1 = withBlock.OtherForm(argIndex5);
            //            if (withBlock1.IsAvailable())
            //            {
            //                Array.Resize(list, Information.UBound(list) + 1 + 1);
            //                Array.Resize(id_list, Information.UBound(list) + 1);
            //                Array.Resize(GUI.ListItemComment, Information.UBound(list) + 1);
            //                id_list[Information.UBound(list)] = withBlock1.Name;

            //                // 各形態の表示内容を作成
            //                if ((SelectedUnit.Nickname0 ?? "") == (withBlock1.Nickname ?? ""))
            //                {
            //                    string argbuf = withBlock1.Name;
            //                    list[Information.UBound(list)] = GeneralLib.RightPaddedString(argbuf, 27);
            //                    withBlock1.Name = argbuf;
            //                }
            //                else
            //                {
            //                    string argbuf1 = withBlock1.Nickname0;
            //                    list[Information.UBound(list)] = GeneralLib.RightPaddedString(argbuf1, 27);
            //                    withBlock1.Nickname0 = argbuf1;
            //                }

            //                string localLeftPaddedString() { string argbuf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(withBlock1.MaxHP); var ret = GeneralLib.LeftPaddedString(argbuf, 6); return ret; }

            //                string localLeftPaddedString1() { string argbuf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(withBlock1.MaxEN); var ret = GeneralLib.LeftPaddedString(argbuf, 5); return ret; }

            //                string localLeftPaddedString2() { string argbuf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(withBlock1.get_Armor("")); var ret = GeneralLib.LeftPaddedString(argbuf, 5); return ret; }

            //                string localLeftPaddedString3() { string argbuf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(withBlock1.get_Mobility("")); var ret = GeneralLib.LeftPaddedString(argbuf, 5); return ret; }

            //                list[Information.UBound(list)] = list[Information.UBound(list)] + localLeftPaddedString() + localLeftPaddedString1() + localLeftPaddedString2() + localLeftPaddedString3() + " " + withBlock1.Data.Adaption;

            //                // 最大攻撃力
            //                max_value = 0;
            //                var loopTo1 = withBlock1.CountWeapon();
            //                for (j = 1; j <= loopTo1; j++)
            //                {
            //                    string argattr = "合";
            //                    if (withBlock1.IsWeaponMastered(j) & !withBlock1.IsDisabled(withBlock1.Weapon(j).Name) & !withBlock1.IsWeaponClassifiedAs(j, argattr))
            //                    {
            //                        string argtarea1 = "";
            //                        if (withBlock1.WeaponPower(j, argtarea1) > max_value)
            //                        {
            //                            string argtarea = "";
            //                            max_value = withBlock1.WeaponPower(j, argtarea);
            //                        }
            //                    }
            //                }

            //                string localLeftPaddedString4() { string argbuf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(max_value); var ret = GeneralLib.LeftPaddedString(argbuf, 7); return ret; }

            //                list[Information.UBound(list)] = list[Information.UBound(list)] + localLeftPaddedString4();

            //                // 最大射程
            //                max_value = 0;
            //                var loopTo2 = withBlock1.CountWeapon();
            //                for (j = 1; j <= loopTo2; j++)
            //                {
            //                    string argattr1 = "合";
            //                    if (withBlock1.IsWeaponMastered(j) & !withBlock1.IsDisabled(withBlock1.Weapon(j).Name) & !withBlock1.IsWeaponClassifiedAs(j, argattr1))
            //                    {
            //                        if (withBlock1.WeaponMaxRange(j) > max_value)
            //                        {
            //                            max_value = withBlock1.WeaponMaxRange(j);
            //                        }
            //                    }
            //                }

            //                string localLeftPaddedString5() { string argbuf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(max_value); var ret = GeneralLib.LeftPaddedString(argbuf, 5); return ret; }

            //                list[Information.UBound(list)] = list[Information.UBound(list)] + localLeftPaddedString5();

            //                // 換装先が持つ特殊能力一覧
            //                farray = new string[1];
            //                var loopTo3 = withBlock1.CountFeature();
            //                for (j = 1; j <= loopTo3; j++)
            //                {
            //                    object argIndex4 = j;
            //                    if (!string.IsNullOrEmpty(withBlock1.FeatureName(argIndex4)))
            //                    {
            //                        // 重複する特殊能力は表示しないようチェック
            //                        var loopTo4 = Information.UBound(farray);
            //                        for (k = 1; k <= loopTo4; k++)
            //                        {
            //                            object argIndex2 = j;
            //                            if ((withBlock1.FeatureName(argIndex2) ?? "") == (farray[k] ?? ""))
            //                            {
            //                                break;
            //                            }
            //                        }

            //                        if (k > Information.UBound(farray))
            //                        {
            //                            string localFeatureName() { object argIndex1 = j; var ret = withBlock1.FeatureName(argIndex1); return ret; }

            //                            GUI.ListItemComment[Information.UBound(list)] = GUI.ListItemComment[Information.UBound(list)] + localFeatureName() + " ";
            //                            Array.Resize(farray, Information.UBound(farray) + 1 + 1);
            //                            object argIndex3 = j;
            //                            farray[Information.UBound(farray)] = withBlock1.FeatureName(argIndex3);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    GUI.ListItemFlag = new bool[Information.UBound(list) + 1];

            //    // どの形態に換装するかを選択
            //    GUI.TopItem = 1;
            //    string arglb_caption = "変更先選択";
            //    string argtname = "ＨＰ";
            //    Unit argu = null;
            //    string argtname1 = "ＥＮ";
            //    Unit argu1 = null;
            //    string argtname2 = "装甲";
            //    Unit argu2 = null;
            //    string argtname3 = "運動";
            //    Unit argu3 = null;
            //    string arglb_info = "ユニット                     " + Expression.Term(argtname, argu, 4) + " " + Expression.Term(argtname1, argu1, 4) + " " + Expression.Term(argtname2, argu2, 4) + " " + Expression.Term(argtname3, argu3, 4) + " " + "適応 攻撃力 射程";
            //    string arglb_mode = "カーソル移動,コメント";
            //    ret = GUI.ListBox(arglb_caption, list, arglb_info, arglb_mode);
            //    if (ret == 0)
            //    {
            //        CancelCommand();
            //        GUI.UnlockGUI();
            //        return;
            //    }

            //    // 換装を実施
            //    Unit localOtherForm() { var tmp = id_list; object argIndex1 = tmp[ret]; var ret = withBlock.OtherForm(argIndex1); return ret; }

            //    string argnew_form = localOtherForm().Name;
            //    withBlock.Transform(argnew_form);
            //    localOtherForm().Name = argnew_form;

            //    // ユニットリストの再構築
            //    string argsmode = "";
            //    Event_Renamed.MakeUnitList(smode: argsmode);

            //    // カーソル自動移動
            //    if (SRC.AutoMoveCursor)
            //    {
            //        string argcursor_mode = "ユニット選択";
            //        GUI.MoveCursorPos(argcursor_mode, withBlock.CurrentForm());
            //    }

            //    Status.DisplayUnitStatus(withBlock.CurrentForm());
            //}

            //CommandState = "ユニット選択";
            //GUI.UnlockGUI();
        }
    }
}
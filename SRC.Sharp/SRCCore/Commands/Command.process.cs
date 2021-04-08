using SRCCore.Events;
using SRCCore.Extensions;
using SRCCore.Lib;
using SRCCore.Maps;
using SRCCore.Models;
using SRCCore.Units;
using SRCCore.VB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SRCCore.Commands
{
    // ユニット＆マップコマンドの実行を行うモジュール
    public partial class Command
    {
        public void ProceedInput(GuiButton button, MapCell cell, Unit unit)
        {
            if (button == GuiButton.Left)
            {
                // 左クリック
                switch (CommandState ?? "")
                {
                    case "マップコマンド":
                        {
                            CommandState = "ユニット選択";
                            break;
                        }

                    case "ユニット選択":
                        if (unit != null)
                        {
                            ProceedCommand(false, button, cell, unit);
                        }
                        break;
                    case "ターゲット選択":
                    case "移動後ターゲット選択":
                        if (cell != null && !Map.MaskData[cell.X, cell.Y])
                        {
                            ProceedCommand(false, button, cell, unit);
                        }
                        break;
                    case "コマンド選択":
                        CancelCommand();
                        // もし新しいクリック地点がユニットなら、ユニット選択の処理を進める
                        if (unit != null)
                        {
                            ProceedCommand(false, button, cell, unit);
                        }
                        break;

                    case "移動後コマンド選択":
                        CancelCommand();
                        break;

                    default:
                        ProceedCommand(false, button, cell, unit);
                        break;
                }
            }

            if (button == GuiButton.Right)
            {
                // 右クリック
                switch (CommandState ?? "")
                {
                    case "マップコマンド":
                        CommandState = "ユニット選択";
                        break;

                    case "ユニット選択":
                        ProceedCommand(true, button, cell, unit);
                        break;

                    default:
                        CancelCommand();
                        break;
                }
            }
        }

        // コマンドの処理を進める
        // by_cancel = True の場合はコマンドをキャンセルした場合の処理
        public void ProceedCommand(
            bool by_cancel = false,
            GuiButton button = GuiButton.None,
            MapCell cell = null,
            Unit unit = null)
        {
            LogDebug();

            // 閲覧モードはキャンセルで終了。それ以外の入力は無視
            if (ViewMode)
            {
                if (by_cancel)
                {
                    ViewMode = false;
                }

                return;
            }

            // 処理が行われるまでこれ以降のコマンド受付を禁止
            // (スクロール禁止にしなければならないほどの時間はないため、LockGUIは使わない)
            GUI.IsGUILocked = true;

            // コマンド実行を行うということはシナリオプレイ中ということなので毎回初期化する。
            SRC.IsScenarioFinished = false;
            SRC.IsCanceled = false;

            //// ポップアップメニュー上で押したマウスボタンが左右どちらかを判定するため、
            //// あらかじめGetAsyncKeyState()を実行しておく必要がある
            //GUI.GetAsyncKeyState(GUI.RButtonID);
            switch (CommandState ?? "")
            {
                case "ユニット選択":
                case "マップコマンド":
                    ProceedUnitSelect(by_cancel, button, cell, unit);
                    break;

                case "コマンド選択":
                    ProceedCommandSelect(by_cancel, button, cell, unit);
                    break;

                case "移動後コマンド選択":
                    ProceedAfterMoveCommandSelect(by_cancel, button, cell, unit);
                    break;

                case "ターゲット選択":
                case "移動後ターゲット選択":
                    ProceedTargetSelect(by_cancel, button, cell, unit);
                    break;

                case "マップ攻撃使用":
                case "移動後マップ攻撃使用":
                    ProceedMapAttack(by_cancel, button, cell, unit);
                    break;

            }


            // XXX ロックしたままのパターンをフォローする
            GUI.IsGUILocked = false;
        }

        private void ProceedUnitSelect(
            bool by_cancel = false,
            GuiButton button = GuiButton.None,
            MapCell cell = null,
            Unit unit = null)
        {
            LogDebug();

            SelectedUnit = unit;
            SelectedUnitMoveCost = 0;

            var mapCommands = new List<UiCommand>();

            if (SelectedUnit is null)
            {
                SelectedX = GUI.PixelToMapX((int)GUI.MouseX);
                SelectedY = GUI.PixelToMapY((int)GUI.MouseY);
                if (!Map.IsStatusView)
                {
                    // 通常のステージ
                    Status.DisplayGlobalStatus();

                    // ターン終了
                    if (ViewMode)
                    {
                        mapCommands.Add(new UiCommand(EndTurnCmdID, "部隊編成に戻る"));
                    }
                    else
                    {
                        mapCommands.Add(new UiCommand(EndTurnCmdID, "ターン終了"));
                    }

                    // 中断
                    if (Expression.IsOptionDefined("デバッグ"))
                    {
                        mapCommands.Add(new UiCommand(DumpCmdID, "中断"));
                    }
                    else
                    {
                        if (!Expression.IsOptionDefined("クイックセーブ不可"))
                        {
                            mapCommands.Add(new UiCommand(DumpCmdID, "中断"));
                        }
                    }

                    // 全体マップ
                    mapCommands.Add(new UiCommand(GlobalMapCmdID, "全体マップ"));

                    // 作戦目的
                    if (Event.IsEventDefined("勝利条件"))
                    {
                        mapCommands.Add(new UiCommand(OperationObjectCmdID, "勝利条件"));
                    }

                    // 自動反撃モード
                    mapCommands.Add(new UiCommand(AutoDefenseCmdID, "自動反撃モード"));

                    // 設定変更
                    mapCommands.Add(new UiCommand(ConfigurationCmdID, "設定変更"));

                    // リスタート
                    if (SRC.IsRestartSaveDataAvailable && !ViewMode)
                    {
                        mapCommands.Add(new UiCommand(RestartCmdID, "リスタート"));
                    }

                    // クイックロード
                    if (SRC.IsQuickSaveDataAvailable && !ViewMode)
                    {
                        mapCommands.Add(new UiCommand(QuickLoadCmdID, "クイックロード"));
                    }

                    // クイックセーブ
                    if (!ViewMode)
                    {
                        if (Expression.IsOptionDefined("デバッグ") || !Expression.IsOptionDefined("クイックセーブ不可"))
                        {
                            mapCommands.Add(new UiCommand(QuickSaveCmdID, "クイックセーブ"));
                        }
                    }
                }
                else
                {
                    // パイロットステータス・ユニットステータスのステージ
                }

                // スペシャルパワー検索
                mapCommands.Add(new UiCommand(SearchSpecialPowerCmdID, "スペシャルパワー検索"));
                // TODO 表示名と表示有無の解決
                //GUI.MainForm.mnuMapCommandItem(SearchSpecialPowerCmdID).Caption = Expression.Term("スペシャルパワー", u: null) + "検索";
                //foreach (Pilot p in SRC.PList)
                //{
                //    if (p.Party == "味方")
                //    {
                //        if (p.CountSpecialPower > 0)
                //        {
                //            GUI.MainForm.mnuMapCommandItem(SearchSpecialPowerCmdID).Visible = true;
                //            break;
                //        }
                //    }
                //}

                // イベントで定義されたマップコマンド
                if (!ViewMode)
                {
                    foreach (LabelData lab in Event.colEventLabelList.Values
                        .Where(x => x.Name == LabelType.MapCommandEventLabel && x.Enable))
                    {
                        if (lab.CountPara() == 2)
                        {
                            // 無条件で実行できるコマンド
                            mapCommands.Add(new UiCommand(MapCommandCmdID, lab.Para(2), lab));
                        }
                        else if (GeneralLib.StrToLng(lab.Para(3)) != 0)
                        {
                            // 条件を満たした場合のみ実行できるコマンド
                            mapCommands.Add(new UiCommand(MapCommandCmdID, lab.Para(2), lab));
                        }
                        // TODO 上限儲けるなら適当に打ち切る
                        //GUI.MainForm.mnuMapCommandItem(i).Caption = lab.Para(2);
                        //MapCommandLabelList[i - MapCommand1CmdID + 1] = lab.LineNum.ToString();
                        //i = (i + 1);
                        //if (i > MapCommand10CmdID)
                        //{
                        //    break;
                        //}
                    }
                }

                CommandState = "マップコマンド";
                GUI.IsGUILocked = false;
                // XXX
                //// ADD START 240a
                //// ここに来た時点でcancel=Trueはユニットのいないセルを右クリックした場合のみ
                //if (by_cancel)
                //{
                //    if (GUI.NewGUIMode && !string.IsNullOrEmpty(Map.MapFileName))
                //    {
                //        if (GUI.MouseX < GUI.MainPWidth / 2)
                //        {
                //            GUI.MainForm.picUnitStatus.Move(GUI.MainPWidth - 240, 10);
                //        }
                //        else
                //        {
                //            GUI.MainForm.picUnitStatus.Move(5, 10);
                //        }
                //        GUI.MainForm.picUnitStatus.Visible = true;
                //    }
                //}
                //// ADD  END  240a
                ///
                GUI.ShowMapCommandMenu(mapCommands);
                return;
            }

            Event.SelectedUnitForEvent = SelectedUnit;
            SelectedWeapon = 0;
            SelectedTWeapon = 0;
            SelectedAbility = 0;
            if (by_cancel)
            {
                // TODO
                //// ユニット上でキャンセルボタンを押した場合は武器一覧
                //// もしくはアビリティ一覧を表示する
                //{
                //    var withBlock2 = SelectedUnit;
                //    // 情報が隠蔽されている場合は表示しない
                //    if (Expression.IsOptionDefined("ユニット情報隠蔽") && !withBlock2.IsConditionSatisfied("識別済み") && (withBlock2.Party0 == "敵" | withBlock2.Party0 == "中立") | withBlock2.IsConditionSatisfied("ユニット情報隠蔽") | withBlock2.IsFeatureAvailable("ダミーユニット"))
                //    {
                //        GUI.IsGUILocked = false;
                //        return;
                //    }

                //    if (withBlock2.CountWeapon() == 0 && withBlock2.CountAbility() > 0)
                //    {
                //        AbilityListCommand();
                //    }
                //    else
                //    {
                //        WeaponListCommand();
                //    }
                //}

                GUI.IsGUILocked = false;
                return;
            }

            CommandState = "コマンド選択";
            ProceedCommand(by_cancel);
        }

        private void ProceedCommandSelect(
            bool by_cancel = false,
            GuiButton button = GuiButton.None,
            MapCell cell = null,
            Unit unit = null)
        {
            LogDebug();

            var unitCommands = new List<UiCommand>();

            //// MOD START 240aClearUnitStatus
            //// If MainWidth <> 15 Then
            //// DisplayUnitStatus SelectedUnit
            //// End If
            //if (!GUI.NewGUIMode)
            //{
            //    Status.DisplayUnitStatus(SelectedUnit);
            //}
            //else
            //{
            //    Status.ClearUnitStatus();
            //}
            //// MOD  END  240a

            // 武装一覧以外は一旦消しておく
            unitCommands.Add(new UiCommand(WeaponListCmdID, "武装一覧"));

            Event.SelectedUnitForEvent = SelectedUnit;
            SelectedTarget = null;
            Event.SelectedTargetForEvent = null;
            var currentUnit = SelectedUnit;
            {
                //// 特殊能力＆アビリティ一覧はどのユニットでも見れる可能性があるので
                //// 先に判定しておく

                //// 特殊能力一覧コマンド
                //var loopTo = currentUnit.CountAllFeature();
                //for (var i = 1; i <= loopTo; i++)
                //{
                //    string localAllFeature() { object argIndex1 = i; var ret = currentUnit.AllFeature(argIndex1); return ret; }

                //    string localAllFeature1() { object argIndex1 = i; var ret = currentUnit.AllFeature(argIndex1); return ret; }

                //    string localAllFeature2() { object argIndex1 = i; var ret = currentUnit.AllFeature(argIndex1); return ret; }

                //    string localAllFeature3() { object argIndex1 = i; var ret = currentUnit.AllFeature(argIndex1); return ret; }

                //    if (!string.IsNullOrEmpty(currentUnit.AllFeatureName(i)))
                //    {
                //        switch (currentUnit.AllFeature(i) ?? "")
                //        {
                //            case "合体":
                //                {
                //                    string localAllFeatureData() { object argIndex1 = i; var ret = currentUnit.AllFeatureData(argIndex1); return ret; }

                //                    string localLIndex() { string arglist = hsde8149624c274ab08211d9ffa37bf9bf(); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //                    if (SRC.UList.IsDefined(localLIndex()))
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(FeatureListCmdID).Visible = true;
                //                        break;
                //                    }

                //                    break;
                //                }

                //            default:
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(FeatureListCmdID).Visible = true;
                //                    break;
                //                }
                //        }
                //    }
                //    else if (localAllFeature() == "パイロット能力付加" | localAllFeature1() == "パイロット能力強化")
                //    {
                //        string localAllFeatureData1() { object argIndex1 = i; var ret = currentUnit.AllFeatureData(argIndex1); return ret; }

                //        if (Strings.InStr(localAllFeatureData1(), "非表示") == 0)
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(FeatureListCmdID).Visible = true;
                //            break;
                //        }
                //    }
                //    else if (localAllFeature2() == "武器クラス" | localAllFeature3() == "防具クラス")
                //    {
                //        if (Expression.IsOptionDefined("アイテム交換"))
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(FeatureListCmdID).Visible = true;
                //            break;
                //        }
                //    }
                //}

                //{
                //    var withBlock5 = currentUnit.MainPilot();
                //    var loopTo1 = withBlock5.CountSkill();
                //    for (i = 1; i <= loopTo1; i++)
                //    {
                //        string localSkillName0() { object argIndex1 = i; var ret = withBlock5.SkillName0(argIndex1); return ret; }

                //        string localSkillName01() { object argIndex1 = i; var ret = withBlock5.SkillName0(argIndex1); return ret; }

                //        if (localSkillName0() != "非表示" && !string.IsNullOrEmpty(localSkillName01()))
                //        {
                //            switch (withBlock5.Skill(i) ?? "")
                //            {
                //                case "耐久":
                //                    {
                //                        if (!Expression.IsOptionDefined("防御力成長") && !Expression.IsOptionDefined("防御力レベルアップ"))
                //                        {
                //                            GUI.MainForm.mnuUnitCommandItem(FeatureListCmdID).Visible = true;
                //                            break;
                //                        }

                //                        break;
                //                    }

                //                case "追加レベル":
                //                case "格闘ＵＰ":
                //                case "射撃ＵＰ":
                //                case "命中ＵＰ":
                //                case "回避ＵＰ":
                //                case "技量ＵＰ":
                //                case "反応ＵＰ":
                //                case "ＳＰＵＰ":
                //                case "格闘ＤＯＷＮ":
                //                case "射撃ＤＯＷＮ":
                //                case "命中ＤＯＷＮ":
                //                case "回避ＤＯＷＮ":
                //                case "技量ＤＯＷＮ":
                //                case "反応ＤＯＷＮ":
                //                case "ＳＰＤＯＷＮ":
                //                case "メッセージ":
                //                case "魔力所有":
                //                    {
                //                        break;
                //                    }

                //                default:
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(FeatureListCmdID).Visible = true;
                //                        break;
                //                    }
                //            }
                //        }
                //    }
                //}

                // アビリティ一覧コマンド
                if (currentUnit.Abilities.Any(x => x.IsAbilityMastered()
                     && currentUnit.IsDisabled(x.Data.Name)
                     && (!x.IsAbilityClassifiedAs("合") || x.IsCombinationAbilityAvailable(true))
                     && !x.Data.IsItem()
                     ))
                {
                    var caption = Expression.Term("アビリティ", SelectedUnit);
                    var unitAbilities = currentUnit.Abilities.Where(x => !x.Data.IsItem()).ToList();
                    unitCommands.Add(new UiCommand(
                        AbilityListCmdID,
                        unitAbilities.Count == 1 ? unitAbilities.First().AbilityNickname() : caption));
                }

                //// 味方じゃない場合
                //if (currentUnit.Party != "味方" | currentUnit.IsConditionSatisfied("非操作") | ViewMode)
                //{
                //    // 召喚ユニットは命令コマンドを使用可能
                //    if (currentUnit.Party == "ＮＰＣ" && currentUnit.IsFeatureAvailable("召喚ユニット") && !currentUnit.IsConditionSatisfied("魅了") && !currentUnit.IsConditionSatisfied("混乱") && !currentUnit.IsConditionSatisfied("恐怖") && !currentUnit.IsConditionSatisfied("暴走") && !currentUnit.IsConditionSatisfied("狂戦士") && !ViewMode)
                //    {
                //        if (currentUnit.Summoner is object)
                //        {
                //            if (currentUnit.Summoner.Party == "味方")
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(OrderCmdID).Caption = "命令";
                //                GUI.MainForm.mnuUnitCommandItem(OrderCmdID).Visible = true;
                //            }
                //        }
                //    }

                //    // 魅了したユニットに対しても命令コマンドを使用可能
                //    if (currentUnit.Party == "ＮＰＣ" && currentUnit.IsConditionSatisfied("魅了") && !currentUnit.IsConditionSatisfied("混乱") && !currentUnit.IsConditionSatisfied("恐怖") && !currentUnit.IsConditionSatisfied("暴走") && !currentUnit.IsConditionSatisfied("狂戦士") && !ViewMode)
                //    {
                //        if (currentUnit.Master is object)
                //        {
                //            if (currentUnit.Master.Party == "味方")
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(OrderCmdID).Caption = "命令";
                //                GUI.MainForm.mnuUnitCommandItem(OrderCmdID).Visible = true;
                //            }
                //        }
                //    }

                //    // ダミーユニットの場合はコマンド一覧を表示しない
                //    if (currentUnit.IsFeatureAvailable("ダミーユニット"))
                //    {
                //        // 特殊能力一覧
                //        if (GUI.MainForm.mnuUnitCommandItem(FeatureListCmdID).Visible)
                //        {
                //            UnitCommand(FeatureListCmdID);
                //        }
                //        else
                //        {
                //            CommandState = "ユニット選択";
                //        }

                //        GUI.IsGUILocked = false;
                //        return;
                //    }

                //    if (!string.IsNullOrEmpty(Map.MapFileName))
                //    {
                //        GUI.MainForm.mnuUnitCommandItem(MoveCmdID).Caption = "移動範囲";
                //        GUI.MainForm.mnuUnitCommandItem(MoveCmdID).Visible = true;
                //        var loopTo3 = currentUnit.CountWeapon();
                //        for (i = 1; i <= loopTo3; i++)
                //        {
                //            if (currentUnit.IsWeaponAvailable(i, "") && !currentUnit.IsWeaponClassifiedAs(i, "Ｍ"))
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(AttackCmdID).Caption = "射程範囲";
                //                GUI.MainForm.mnuUnitCommandItem(AttackCmdID).Visible = true;
                //            }
                //        }
                //    }

                //    // ユニットステータスコマンド用
                //    if (string.IsNullOrEmpty(Map.MapFileName))
                //    {
                //        // 変形コマンド
                //        if (currentUnit.IsFeatureAvailable("変形"))
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(TransformCmdID).Caption = currentUnit.FeatureName("変形");
                //            if (GUI.MainForm.mnuUnitCommandItem(TransformCmdID).Caption == "")
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(TransformCmdID).Caption = "変形";
                //            }

                //            var loopTo4 = GeneralLib.LLength(currentUnit.FeatureData("変形"));
                //            for (i = 2; i <= loopTo4; i++)
                //            {
                //                uname = GeneralLib.LIndex(currentUnit.FeatureData("変形"), i);
                //                Unit localOtherForm() { object argIndex1 = uname; var ret = currentUnit.OtherForm(argIndex1); return ret; }

                //                if (localOtherForm().IsAvailable())
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(TransformCmdID).Visible = true;
                //                    break;
                //                }
                //            }
                //        }

                //        // 分離コマンド
                //        if (currentUnit.IsFeatureAvailable("分離"))
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Visible = true;
                //            GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Caption = currentUnit.FeatureName("分離");
                //            if (GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Caption == "")
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Caption = "分離";
                //            }

                //            buf = currentUnit.FeatureData("分離");

                //            // 分離形態が利用出来ない場合は分離を行わない
                //            var loopTo5 = GeneralLib.LLength(buf);
                //            for (i = 2; i <= loopTo5; i++)
                //            {
                //                bool localIsDefined() { object argIndex1 = GeneralLib.LIndex(buf, i); var ret = SRC.UList.IsDefined(argIndex1); return ret; }

                //                if (!localIsDefined())
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Visible = false;
                //                    break;
                //                }
                //            }

                //            // パイロットが足らない場合も分離を行わない
                //            if (GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Visible)
                //            {
                //                n = 0;
                //                var loopTo6 = GeneralLib.LLength(buf);
                //                for (i = 2; i <= loopTo6; i++)
                //                {
                //                    Unit localItem() { object argIndex1 = GeneralLib.LIndex(buf, i); var ret = SRC.UList.Item(argIndex1); return ret; }

                //                    {
                //                        var withBlock6 = localItem().Data;
                //                        if (!withBlock6.IsFeatureAvailable("召喚ユニット"))
                //                        {
                //                            n = (n + Math.Abs(withBlock6.PilotNum));
                //                        }
                //                    }
                //                }

                //                if (currentUnit.CountPilot() < n)
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Visible = false;
                //                }
                //            }
                //        }

                //        if (currentUnit.IsFeatureAvailable("パーツ分離"))
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Caption = currentUnit.FeatureName("パーツ分離");
                //            if (GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Caption == "")
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Caption = "パーツ分離";
                //            }
                //            GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Visible = true;
                //        }

                //        // 合体コマンド
                //        if (currentUnit.IsFeatureAvailable("合体"))
                //        {
                //            var loopTo7 = currentUnit.CountFeature();
                //            for (i = 1; i <= loopTo7; i++)
                //            {
                //                if (currentUnit.Feature(i) == "合体")
                //                {
                //                    n = 0;
                //                    // パートナーが存在しているか？
                //                    string localFeatureData1() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //                    var loopTo8 = GeneralLib.LLength(localFeatureData1());
                //                    for (j = 3; j <= loopTo8; j++)
                //                    {
                //                        string localFeatureData() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //                        string localLIndex1() { string arglist = hse3098790f77a4c3c8e351b0c8f045435(); var ret = GeneralLib.LIndex(arglist, j); return ret; }

                //                        u = SRC.UList.Item(localLIndex1());
                //                        if (u is null)
                //                        {
                //                            break;
                //                        }

                //                        if (u.Status_Renamed != "出撃" && u.CurrentForm().IsFeatureAvailable("合体制限"))
                //                        {
                //                            break;
                //                        }

                //                        n = (n + 1);
                //                    }

                //                    // 合体先のユニットが作成されているか？
                //                    string localFeatureData2() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //                    string localLIndex2() { string arglist = hse489dc5578704b21a62d1221f27f2c9c(); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //                    bool localIsDefined1() { object argIndex1 = (object)hs2edf74710015446592f60b6fcb7267d6(); var ret = SRC.UList.IsDefined(argIndex1); return ret; }

                //                    if (!localIsDefined1())
                //                    {
                //                        n = 0;
                //                    }

                //                    // すべての条件を満たしている場合
                //                    string localFeatureData4() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //                    int localLLength() { string arglist = hs57a7b11782d04866bf1e5d24ed51c504(); var ret = GeneralLib.LLength(arglist); return ret; }

                //                    if (n == localLLength() - 2)
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Visible = true;
                //                        string localFeatureData3() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //                        GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Caption = GeneralLib.LIndex(localFeatureData3(), 1);
                //                        if (GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Caption == "非表示")
                //                        {
                //                            GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Caption = "合体";
                //                        }

                //                        break;
                //                    }
                //                }
                //            }
                //        }
                //        else if (currentUnit.IsFeatureAvailable("パーツ合体"))
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Caption = "パーツ合体";
                //            GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Visible = true;
                //        }

                //        if (!currentUnit.IsConditionSatisfied("ノーマルモード付加"))
                //        {
                //            // ハイパーモードコマンド
                //            if (currentUnit.IsFeatureAvailable("ハイパーモード"))
                //            {
                //                uname = GeneralLib.LIndex(currentUnit.FeatureData("ハイパーモード"), 2);
                //                Unit localOtherForm1() { object argIndex1 = uname; var ret = currentUnit.OtherForm(argIndex1); return ret; }

                //                if (localOtherForm1().IsAvailable())
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Visible = true;
                //                    GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = GeneralLib.LIndex(currentUnit.FeatureData("ハイパーモード"), 1);
                //                    if (GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption == "非表示")
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = "ハイパーモード";
                //                    }
                //                }
                //            }
                //            else if (currentUnit.IsFeatureAvailable("ノーマルモード"))
                //            {
                //                uname = GeneralLib.LIndex(currentUnit.FeatureData("ノーマルモード"), 1);
                //                Unit localOtherForm2() { object argIndex1 = uname; var ret = currentUnit.OtherForm(argIndex1); return ret; }

                //                if (localOtherForm2().IsAvailable())
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Visible = true;
                //                    GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = "ノーマルモード";
                //                    string localLIndex3() { object argIndex1 = "変形"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //                    if ((uname ?? "") == (localLIndex3() ?? ""))
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Visible = false;
                //                    }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            // 変身解除
                //            if (Strings.InStr(currentUnit.FeatureData("ノーマルモード"), "手動解除") > 0)
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Visible = true;
                //                if (currentUnit.IsFeatureAvailable("変身解除コマンド名"))
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = currentUnit.FeatureData("変身解除コマンド名");
                //                }
                //                else if (currentUnit.IsHero())
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = "変身解除";
                //                }
                //                else
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = "特殊モード解除";
                //                }
                //            }
                //        }

                //        // 換装コマンド
                //        if (currentUnit.IsFeatureAvailable("換装"))
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(OrderCmdID).Caption = "換装";
                //            var loopTo9 = GeneralLib.LLength(currentUnit.FeatureData("換装"));
                //            for (i = 1; i <= loopTo9; i++)
                //            {
                //                uname = GeneralLib.LIndex(currentUnit.FeatureData("換装"), i);
                //                Unit localOtherForm3() { object argIndex1 = uname; var ret = currentUnit.OtherForm(argIndex1); return ret; }

                //                if (localOtherForm3().IsAvailable())
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(OrderCmdID).Visible = true;
                //                    break;
                //                }
                //            }

                //            // エリアスで換装の名称が変更されている？
                //            {
                //                var withBlock7 = SRC.ALDList;
                //                var loopTo10 = withBlock7.Count();
                //                for (i = 1; i <= loopTo10; i++)
                //                {
                //                    {
                //                        var withBlock8 = withBlock7.Item(i);
                //                        if (withBlock8.get_AliasType(1) == "換装")
                //                        {
                //                            GUI.MainForm.mnuUnitCommandItem(OrderCmdID).Caption = withBlock8.Name;
                //                            break;
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }

                //    // ユニットコマンド
                //    if (!ViewMode)
                //    {
                //        i = UnitCommand1CmdID;
                //        foreach (LabelData currentLab1 in Event.colEventLabelList)
                //        {
                //            lab = currentLab1;
                //            if (lab.Name == Event.LabelType.UnitCommandEventLabel && lab.Enable)
                //            {
                //                buf = Expression.GetValueAsString(lab.Para(3));
                //                if (SelectedUnit.Party == "味方" && ((buf ?? "") == (SelectedUnit.MainPilot().Name ?? "") | (buf ?? "") == (SelectedUnit.MainPilot().get_Nickname(false) ?? "") | (buf ?? "") == (SelectedUnit.Name ?? "")) | (buf ?? "") == (SelectedUnit.Party ?? "") | buf == "全")
                //                {
                //                    int localGetValueAsLong() { string argexpr = lab.Para(4); var ret = Expression.GetValueAsLong(argexpr); return ret; }

                //                    if (lab.CountPara() <= 3)
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(i).Visible = true;
                //                    }
                //                    else if (localGetValueAsLong() != 0)
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(i).Visible = true;
                //                    }
                //                }

                //                if (GUI.MainForm.mnuUnitCommandItem(i).Visible)
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(i).Caption = lab.Para(2);
                //                    UnitCommandLabelList[i - UnitCommand1CmdID + 1] = lab.LineNum.ToString();
                //                    i = (i + 1);
                //                    if (i > UnitCommand10CmdID)
                //                    {
                //                        break;
                //                    }
                //                }
                //            }
                //        }
                //    }

                //    // 未確認ユニットの場合は情報を隠蔽
                //    if (Expression.IsOptionDefined("ユニット情報隠蔽") && !currentUnit.IsConditionSatisfied("識別済み") && (currentUnit.Party0 == "敵" | currentUnit.Party0 == "中立") | currentUnit.IsConditionSatisfied("ユニット情報隠蔽"))
                //    {
                //        GUI.MainForm.mnuUnitCommandItem(MoveCmdID).Visible = true;
                //        GUI.MainForm.mnuUnitCommandItem(AttackCmdID).Visible = false;
                //        GUI.MainForm.mnuUnitCommandItem(FeatureListCmdID).Visible = false;
                //        GUI.MainForm.mnuUnitCommandItem(WeaponListCmdID).Visible = false;
                //        GUI.MainForm.mnuUnitCommandItem(AbilityListCmdID).Visible = false;
                //        for (i = 1; i <= WaitCmdID; i++)
                //        {
                //            if (GUI.MainForm.mnuUnitCommandItem(i).Visible)
                //            {
                //                break;
                //            }
                //        }

                //        if (i > WaitCmdID)
                //        {
                //            // 表示可能なコマンドがなかった
                //            CommandState = "ユニット選択";
                //            GUI.IsGUILocked = false;
                //            return;
                //        }
                //        // メニューコマンドを全て殺してしまうとエラーになるのでここで非表示
                //        GUI.MainForm.mnuUnitCommandItem(MoveCmdID).Visible = false;
                //    }

                //    GUI.IsGUILocked = false;
                //    if (by_cancel)
                //    {
                //        GUI.MainForm.PopupMenu(GUI.MainForm.mnuUnitCommand, 6, GUI.MouseX, GUI.MouseY + 5f);
                //    }
                //    else
                //    {
                //        GUI.MainForm.PopupMenu(GUI.MainForm.mnuUnitCommand, 6, GUI.MouseX, GUI.MouseY - 6f);
                //    }

                //    return;
                //}

                //// 行動終了している場合
                //else if (currentUnit.Action == 0)
                //{
                //    // 発進コマンドは使用可能
                //    if (currentUnit.IsFeatureAvailable("母艦"))
                //    {
                //        if (currentUnit.Area != "地中")
                //        {
                //            if (currentUnit.CountUnitOnBoard() > 0)
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(LaunchCmdID).Visible = true;
                //            }
                //        }
                //    }

                //    // ユニットコマンド
                //    i = UnitCommand1CmdID;
                //    foreach (LabelData currentLab2 in Event.colEventLabelList)
                //    {
                //        lab = currentLab2;
                //        if (lab.Name == Event.LabelType.UnitCommandEventLabel && (lab.AsterNum == 1 | lab.AsterNum == 3))
                //        {
                //            if (lab.Enable)
                //            {
                //                buf = lab.Para(3);
                //                if (SelectedUnit.Party == "味方" && ((buf ?? "") == (SelectedUnit.MainPilot().Name ?? "") | (buf ?? "") == (SelectedUnit.MainPilot().get_Nickname(false) ?? "") | (buf ?? "") == (SelectedUnit.Name ?? "")) | (buf ?? "") == (SelectedUnit.Party ?? "") | buf == "全")
                //                {
                //                    int localStrToLng1() { string argexpr = lab.Para(4); var ret = GeneralLib.StrToLng(argexpr); return ret; }

                //                    if (lab.CountPara() <= 3)
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(i).Visible = true;
                //                    }
                //                    else if (localStrToLng1() != 0)
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(i).Visible = true;
                //                    }
                //                }
                //            }

                //            if (GUI.MainForm.mnuUnitCommandItem(i).Visible)
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(i).Caption = lab.Para(2);
                //                UnitCommandLabelList[i - UnitCommand1CmdID + 1] = lab.LineNum.ToString();
                //                i = (i + 1);
                //                if (i > UnitCommand10CmdID)
                //                {
                //                    break;
                //                }
                //            }
                //        }
                //    }

                //    GUI.IsGUILocked = false;
                //    GUI.MainForm.PopupMenu(GUI.MainForm.mnuUnitCommand, 6, GUI.MouseX, GUI.MouseY - 5f);
                //    return;
                //}
            }
            {
                // 移動コマンド
                if (currentUnit.Speed <= 0)
                {
                    unitCommands.Add(new UiCommand(WaitCmdID, "待機"));
                }
                else
                {
                    unitCommands.Add(new UiCommand(MoveCmdID, "移動"));
                } // 移動

                {
                    // テレポートコマンド
                    if (currentUnit.IsFeatureAvailable("テレポート"))
                    {
                        int enCost = 40;
                        if (GeneralLib.LLength(currentUnit.FeatureData("テレポート")) == 2)
                        {
                            enCost = Conversions.ToInteger(GeneralLib.LIndex(currentUnit.FeatureData("テレポート"), 2));
                        }
                        if (currentUnit.EN >= enCost)
                        {
                            if (Strings.Len(currentUnit.FeatureData("テレポート")) > 0)
                            {
                                unitCommands.Add(new UiCommand(TeleportCmdID, GeneralLib.LIndex(currentUnit.FeatureData("テレポート"), 1)));
                            }
                            else
                            {
                                unitCommands.Add(new UiCommand(TeleportCmdID, "テレポート"));
                            }
                        }
                        // 通常移動がテレポートの場合
                        if (currentUnit.Speed0 == 0 || currentUnit.FeatureLevel("テレポート") >= 0d && enCost == 0)
                        {
                            unitCommands.RemoveItem(x => x.Id == MoveCmdID);
                        }
                    }

                    // ジャンプコマンド
                    if (currentUnit.IsFeatureAvailable("ジャンプ") && currentUnit.Area != "空中" && currentUnit.Area != "宇宙")
                    {
                        int enCost = 0;
                        if (GeneralLib.LLength(currentUnit.FeatureData("ジャンプ")) == 2)
                        {
                            enCost = Conversions.ToInteger(GeneralLib.LIndex(currentUnit.FeatureData("ジャンプ"), 2));
                        }
                        if (currentUnit.EN >= enCost)
                        {
                            if (Strings.Len(currentUnit.FeatureData("ジャンプ")) > 0)
                            {
                                unitCommands.Add(new UiCommand(JumpCmdID, GeneralLib.LIndex(currentUnit.FeatureData("ジャンプ"), 1)));
                            }
                            else
                            {
                                unitCommands.Add(new UiCommand(JumpCmdID, "ジャンプ"));
                            }
                        }
                        // 通常移動がジャンプの場合
                        if (currentUnit.Speed0 == 0 || currentUnit.FeatureLevel("ジャンプ") >= 0d && enCost == 0)
                        {
                            unitCommands.RemoveItem(x => x.Id == MoveCmdID);
                        }
                    }
                    if (currentUnit.IsConditionSatisfied("移動不能"))
                    {
                        unitCommands.RemoveItem(x => x.Id == MoveCmdID || x.Id == TeleportCmdID || x.Id == JumpCmdID);
                    }

                    //// 会話コマンド
                    //for (i = 1; i <= 4; i++)
                    //{
                    //    // UPGRADE_NOTE: オブジェクト u をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                    //    u = null;
                    //    switch (i)
                    //    {
                    //        case 1:
                    //            {
                    //                if (currentUnit.x > 1)
                    //                {
                    //                    u = Map.MapDataForUnit[currentUnit.x - 1, currentUnit.y];
                    //                }

                    //                break;
                    //            }

                    //        case 2:
                    //            {
                    //                if (currentUnit.x < Map.MapWidth)
                    //                {
                    //                    u = Map.MapDataForUnit[currentUnit.x + 1, currentUnit.y];
                    //                }

                    //                break;
                    //            }

                    //        case 3:
                    //            {
                    //                if (currentUnit.y > 1)
                    //                {
                    //                    u = Map.MapDataForUnit[currentUnit.x, currentUnit.y - 1];
                    //                }

                    //                break;
                    //            }

                    //        case 4:
                    //            {
                    //                if (currentUnit.y < Map.MapHeight)
                    //                {
                    //                    u = Map.MapDataForUnit[currentUnit.x, currentUnit.y + 1];
                    //                }

                    //                break;
                    //            }
                    //    }

                    //    if (u is object)
                    //    {
                    //        if (Event.IsEventDefined("会話 " + currentUnit.MainPilot().ID + " " + u.MainPilot().ID))
                    //        {
                    //            GUI.MainForm.mnuUnitCommandItem(TalkCmdID).Visible = true;
                    //            break;
                    //        }
                    //    }
                    //}

                    // 攻撃コマンド
                    if (currentUnit.Weapons.Any(x => x.IsWeaponUseful("移動前")))
                    {
                        unitCommands.Add(new UiCommand(AttackCmdID, "攻撃"));
                    }

                    if (currentUnit.Area == "地中")
                    {
                        unitCommands.RemoveItem(x => x.Id == AttackCmdID);
                    }

                    //if (currentUnit.IsConditionSatisfied("攻撃不能"))
                    //{
                    //    GUI.MainForm.mnuUnitCommandItem(AttackCmdID).Visible = false;
                    //}

                    //// 修理コマンド
                    //if (currentUnit.IsFeatureAvailable("修理装置") && currentUnit.Area != "地中")
                    //{
                    //    for (i = 1; i <= 4; i++)
                    //    {
                    //        // UPGRADE_NOTE: オブジェクト u をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                    //        u = null;
                    //        switch (i)
                    //        {
                    //            case 1:
                    //                {
                    //                    if (currentUnit.x > 1)
                    //                    {
                    //                        u = Map.MapDataForUnit[currentUnit.x - 1, currentUnit.y];
                    //                    }

                    //                    break;
                    //                }

                    //            case 2:
                    //                {
                    //                    if (currentUnit.x < Map.MapWidth)
                    //                    {
                    //                        u = Map.MapDataForUnit[currentUnit.x + 1, currentUnit.y];
                    //                    }

                    //                    break;
                    //                }

                    //            case 3:
                    //                {
                    //                    if (currentUnit.y > 1)
                    //                    {
                    //                        u = Map.MapDataForUnit[currentUnit.x, currentUnit.y - 1];
                    //                    }

                    //                    break;
                    //                }

                    //            case 4:
                    //                {
                    //                    if (currentUnit.y < Map.MapHeight)
                    //                    {
                    //                        u = Map.MapDataForUnit[currentUnit.x, currentUnit.y + 1];
                    //                    }

                    //                    break;
                    //                }
                    //        }

                    //        if (u is object)
                    //        {
                    //            {
                    //                var withBlock9 = u;
                    //                if ((withBlock9.Party == "味方" | withBlock9.Party == "ＮＰＣ") && withBlock9.HP < withBlock9.MaxHP && !withBlock9.IsConditionSatisfied("ゾンビ"))
                    //                {
                    //                    GUI.MainForm.mnuUnitCommandItem(FixCmdID).Visible = true;
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //    }

                    //    if (Strings.Len(currentUnit.FeatureData("修理装置")) > 0)
                    //    {
                    //        GUI.MainForm.mnuUnitCommandItem(FixCmdID).Caption = GeneralLib.LIndex(currentUnit.FeatureData("修理装置"), 1);
                    //        string localLIndex12() { object argIndex1 = "修理装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                    //        if (Information.IsNumeric(localLIndex12()))
                    //        {
                    //            string localLIndex10() { object argIndex1 = "修理装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                    //            string localLIndex11() { object argIndex1 = "修理装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                    //            if (currentUnit.EN < Conversions.Toint(localLIndex11()))
                    //            {
                    //                GUI.MainForm.mnuUnitCommandItem(FixCmdID).Visible = false;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        GUI.MainForm.mnuUnitCommandItem(FixCmdID).Caption = "修理装置";
                    //    }
                    //}

                    //// 補給コマンド
                    //if (currentUnit.IsFeatureAvailable("補給装置") && currentUnit.Area != "地中")
                    //{
                    //    for (i = 1; i <= 4; i++)
                    //    {
                    //        // UPGRADE_NOTE: オブジェクト u をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                    //        u = null;
                    //        switch (i)
                    //        {
                    //            case 1:
                    //                {
                    //                    if (currentUnit.x > 1)
                    //                    {
                    //                        u = Map.MapDataForUnit[currentUnit.x - 1, currentUnit.y];
                    //                    }

                    //                    break;
                    //                }

                    //            case 2:
                    //                {
                    //                    if (currentUnit.x < Map.MapWidth)
                    //                    {
                    //                        u = Map.MapDataForUnit[currentUnit.x + 1, currentUnit.y];
                    //                    }

                    //                    break;
                    //                }

                    //            case 3:
                    //                {
                    //                    if (currentUnit.y > 1)
                    //                    {
                    //                        u = Map.MapDataForUnit[currentUnit.x, currentUnit.y - 1];
                    //                    }

                    //                    break;
                    //                }

                    //            case 4:
                    //                {
                    //                    if (currentUnit.y < Map.MapHeight)
                    //                    {
                    //                        u = Map.MapDataForUnit[currentUnit.x, currentUnit.y + 1];
                    //                    }

                    //                    break;
                    //                }
                    //        }

                    //        if (u is object)
                    //        {
                    //            {
                    //                var withBlock10 = u;
                    //                if (withBlock10.Party == "味方" | withBlock10.Party == "ＮＰＣ")
                    //                {
                    //                    if (withBlock10.EN < withBlock10.MaxEN && !withBlock10.IsConditionSatisfied("ゾンビ"))
                    //                    {
                    //                        GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = true;
                    //                    }
                    //                    else
                    //                    {
                    //                        var loopTo12 = withBlock10.CountWeapon();
                    //                        for (j = 1; j <= loopTo12; j++)
                    //                        {
                    //                            if (withBlock10.Bullet(j) < withBlock10.MaxBullet(j))
                    //                            {
                    //                                GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = true;
                    //                                break;
                    //                            }
                    //                        }

                    //                        var loopTo13 = withBlock10.CountAbility();
                    //                        for (j = 1; j <= loopTo13; j++)
                    //                        {
                    //                            if (withBlock10.Stock(j) < withBlock10.MaxStock(j))
                    //                            {
                    //                                GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = true;
                    //                                break;
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }

                    //    if (Strings.Len(currentUnit.FeatureData("補給装置")) > 0)
                    //    {
                    //        GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Caption = GeneralLib.LIndex(currentUnit.FeatureData("補給装置"), 1);
                    //        string localLIndex15() { object argIndex1 = "補給装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                    //        if (Information.IsNumeric(localLIndex15()))
                    //        {
                    //            string localLIndex13() { object argIndex1 = "補給装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                    //            string localLIndex14() { object argIndex1 = "補給装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                    //            if (currentUnit.EN < Conversions.Toint(localLIndex14()) | currentUnit.MainPilot().Morale < 100)
                    //            {
                    //                GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = false;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Caption = "補給装置";
                    //    }
                    //}

                    // アビリティコマンド
                    if (currentUnit.Area != "地中")
                    {
                        var displayAbilities = currentUnit.Abilities.Where(x => x.IsAbilityMastered()
                          && !x.Data.IsItem()
                          && x.IsAbilityUseful("移動前")
                          ).ToList();
                        if (displayAbilities.Count > 0)
                        {
                            var caption = Expression.Term("アビリティ", SelectedUnit);
                            var unitAbilities = currentUnit.Abilities.Where(x => !x.Data.IsItem()).ToList();
                            unitCommands.Add(new UiCommand(
                                AbilityCmdID,
                                unitAbilities.Count == 1 ? unitAbilities.First().AbilityNickname() : caption));
                        }
                    }

                    //// チャージコマンド
                    //if (!currentUnit.IsConditionSatisfied("チャージ完了"))
                    //{
                    //    var loopTo16 = currentUnit.CountWeapon();
                    //    for (i = 1; i <= loopTo16; i++)
                    //    {
                    //        if (currentUnit.IsWeaponClassifiedAs(i, "Ｃ"))
                    //        {
                    //            if (currentUnit.IsWeaponAvailable(i, "チャージ"))
                    //            {
                    //                GUI.MainForm.mnuUnitCommandItem(ChargeCmdID).Visible = true;
                    //                break;
                    //            }
                    //        }
                    //    }

                    //    var loopTo17 = currentUnit.CountAbility();
                    //    for (i = 1; i <= loopTo17; i++)
                    //    {
                    //        if (currentUnit.IsAbilityClassifiedAs(i, "Ｃ"))
                    //        {
                    //            if (currentUnit.IsAbilityAvailable(i, "チャージ"))
                    //            {
                    //                GUI.MainForm.mnuUnitCommandItem(ChargeCmdID).Visible = true;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}

                    // スペシャルパワーコマンド
                    {
                        if (!currentUnit.IsConditionSatisfied("憑依") && !currentUnit.IsConditionSatisfied("スペシャルパワー使用不能"))
                        {
                            if (currentUnit.PilotsHaveSpecialPower().Count > 0)
                            {
                                unitCommands.Add(new UiCommand(SpecialPowerCmdID, Expression.Term("スペシャルパワー", SelectedUnit)));
                            }
                        }
                    }

                    // 変形コマンド
                    if (currentUnit.IsFeatureAvailable("変形")
                        && !string.IsNullOrEmpty(currentUnit.FeatureName("変形"))
                        && !currentUnit.IsConditionSatisfied("形態固定")
                        && !currentUnit.IsConditionSatisfied("機体固定"))
                    {
                        var cmdName = currentUnit.FeatureName("変形");
                        foreach (var uname in GeneralLib.ToL(currentUnit.FeatureData("変形")).Skip(1))
                        {
                            if (currentUnit.OtherForm(uname)?.IsAvailable() ?? false)
                            {
                                unitCommands.Add(new UiCommand(TransformCmdID, cmdName));
                                break;
                            }
                        }
                    }

                    // 分離コマンド
                    if (currentUnit.IsFeatureAvailable("分離")
                        && !string.IsNullOrEmpty(currentUnit.FeatureName("分離"))
                        && !currentUnit.IsConditionSatisfied("形態固定")
                        && !currentUnit.IsConditionSatisfied("機体固定"))
                    {
                        var splitForms = GeneralLib.ToL(currentUnit.FeatureData("分離")).Skip(1).ToList();

                        // 分離形態が利用出来ない場合は分離を行わない
                        // パイロットが足らない場合も分離を行わない
                        if (splitForms.All(x => SRC.UList.IsDefined(x))
                            && currentUnit.CountPilot() >= splitForms.Select(x => SRC.UList.Item(x))
                                .Where(x => !x.IsFeatureAvailable("召喚ユニット"))
                                .Count())
                        {
                            unitCommands.Add(new UiCommand(SplitCmdID, currentUnit.FeatureName("分離")));
                        }
                    }

                    //if (currentUnit.IsFeatureAvailable("パーツ分離") && !string.IsNullOrEmpty(currentUnit.FeatureName("パーツ分離")))
                    //{
                    //    GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Caption = currentUnit.FeatureName("パーツ分離");
                    //    GUI.MainForm.mnuUnitCommandItem(SplitCmdID).Visible = true;
                    //}

                    // 合体コマンド
                    if (currentUnit.IsFeatureAvailable("合体")
                        && !currentUnit.IsConditionSatisfied("形態固定")
                        && !currentUnit.IsConditionSatisfied("機体固定"))
                    {
                        var combines = currentUnit.CombineFeatures(SRC);
                        foreach (var fd in combines)
                        {
                            unitCommands.Add(new UiCommand(CombineCmdID, fd.CombineName));
                        }
                    }

                    //if (!currentUnit.IsConditionSatisfied("ノーマルモード付加"))
                    //{
                    //    // ハイパーモードコマンド
                    //    if (currentUnit.IsFeatureAvailable("ハイパーモード") && (currentUnit.MainPilot().Morale >= (10d * currentUnit.FeatureLevel("ハイパーモード")) + 100 | currentUnit.HP <= currentUnit.MaxHP / 4 && Strings.InStr(currentUnit.FeatureData("ハイパーモード"), "気力発動") == 0) && Strings.InStr(currentUnit.FeatureData("ハイパーモード"), "自動発動") == 0 && !string.IsNullOrEmpty(currentUnit.FeatureName("ハイパーモード")) && !currentUnit.IsConditionSatisfied("形態固定") && !currentUnit.IsConditionSatisfied("機体固定"))
                    //    {
                    //        uname = GeneralLib.LIndex(currentUnit.FeatureData("ハイパーモード"), 2);
                    //        Unit localOtherForm5() { object argIndex1 = uname; var ret = currentUnit.OtherForm(argIndex1); return ret; }

                    //        Unit localOtherForm6() { object argIndex1 = uname; var ret = currentUnit.OtherForm(argIndex1); return ret; }

                    //        if (!localOtherForm5().IsConditionSatisfied("行動不能") && localOtherForm6().IsAbleToEnter(currentUnit.x, currentUnit.y))
                    //        {
                    //            GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Visible = true;
                    //            GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = GeneralLib.LIndex(currentUnit.FeatureData("ハイパーモード"), 1);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    // 変身解除
                    //    if (Strings.InStr(currentUnit.FeatureData("ノーマルモード"), "手動解除") > 0)
                    //    {
                    //        GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Visible = true;
                    //        if (currentUnit.IsFeatureAvailable("変身解除コマンド名"))
                    //        {
                    //            GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = currentUnit.FeatureData("変身解除コマンド名");
                    //        }
                    //        else if (currentUnit.IsHero())
                    //        {
                    //            GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = "変身解除";
                    //        }
                    //        else
                    //        {
                    //            GUI.MainForm.mnuUnitCommandItem(HyperModeCmdID).Caption = "特殊モード解除";
                    //        }
                    //    }
                    //}

                    // 地上コマンド
                    if (Map.Terrain(currentUnit.x, currentUnit.y).Class == "陸"
                        || Map.Terrain(currentUnit.x, currentUnit.y).Class == "屋内"
                        || Map.Terrain(currentUnit.x, currentUnit.y).Class == "月面")
                    {
                        if (currentUnit.Area != "地上" && currentUnit.IsTransAvailable("陸"))
                        {
                            unitCommands.Add(new UiCommand(GroundCmdID, "地上"));
                        }
                    }
                    else if (Map.Terrain(currentUnit.x, currentUnit.y).Class == "水"
                        || Map.Terrain(currentUnit.x, currentUnit.y).Class == "深水")
                    {
                        if (currentUnit.Area != "水上" && currentUnit.IsTransAvailable("水上"))
                        {
                            unitCommands.Add(new UiCommand(GroundCmdID, "水上"));
                        }
                    }

                    // 空中コマンド
                    switch (Map.Terrain(currentUnit.x, currentUnit.y).Class ?? "")
                    {
                        case "宇宙":
                            break;

                        case "月面":
                            if ((currentUnit.IsTransAvailable("空") || currentUnit.IsTransAvailable("宇宙")) && !(currentUnit.Area == "宇宙"))
                            {
                                unitCommands.Add(new UiCommand(SkyCmdID, "宇宙"));
                            }
                            break;

                        default:
                            if (currentUnit.IsTransAvailable("空") && !(currentUnit.Area == "空中"))
                            {
                                unitCommands.Add(new UiCommand(SkyCmdID, "空中"));
                            }
                            break;
                    }

                    // 地中コマンド
                    if (currentUnit.IsTransAvailable("地中")
                        && !(currentUnit.Area == "地中")
                        && (Map.Terrain(currentUnit.x, currentUnit.y).Class == "陸" || Map.Terrain(currentUnit.x, currentUnit.y).Class == "月面"))
                    {
                        unitCommands.Add(new UiCommand(UndergroundCmdID, "地中"));
                    }

                    // 水中コマンド
                    if (currentUnit.Area != "水中")
                    {
                        if (Map.Terrain(currentUnit.x, currentUnit.y).Class == "深水"
                            && (currentUnit.IsTransAvailable("水") || currentUnit.IsFeatureAvailable("水泳"))
                            && Strings.Mid(currentUnit.Data.Adaption, 3, 1) != "-")
                        {
                            unitCommands.Add(new UiCommand(WaterCmdID, "水中"));
                        }
                        else if (Map.Terrain(currentUnit.x, currentUnit.y).Class == "水" && Strings.Mid(currentUnit.Data.Adaption, 3, 1) != "-")
                        {
                            unitCommands.Add(new UiCommand(WaterCmdID, "水中"));
                        }
                    }

                    // 発進コマンド
                    if (currentUnit.IsFeatureAvailable("母艦") && currentUnit.Area != "地中")
                    {
                        if (currentUnit.CountUnitOnBoard() > 0)
                        {
                            unitCommands.Add(new UiCommand(LaunchCmdID, "発進"));
                        }
                    }

                    //// アイテムコマンド
                    //var loopTo25 = currentUnit.CountAbility();
                    //for (i = 1; i <= loopTo25; i++)
                    //{
                    //    if (currentUnit.IsAbilityUseful(i, "移動前") && currentUnit.Ability(i).IsItem())
                    //    {
                    //        GUI.MainForm.mnuUnitCommandItem(ItemCmdID).Visible = true;
                    //        break;
                    //    }
                    //}

                    //if (currentUnit.Area == "地中")
                    //{
                    //    GUI.MainForm.mnuUnitCommandItem(ItemCmdID).Visible = false;
                    //}

                    //// 召喚解除コマンド
                    //var loopTo26 = currentUnit.CountServant();
                    //for (i = 1; i <= loopTo26; i++)
                    //{
                    //    Unit localServant() { object argIndex1 = i; var ret = currentUnit.Servant(argIndex1); return ret; }

                    //    {
                    //        var withBlock12 = localServant().CurrentForm();
                    //        switch (withBlock12.Status_Renamed ?? "")
                    //        {
                    //            case "出撃":
                    //            case "格納":
                    //                {
                    //                    GUI.MainForm.mnuUnitCommandItem(DismissCmdID).Visible = true;
                    //                    break;
                    //                }

                    //            case "旧主形態":
                    //            case "旧形態":
                    //                {
                    //                    // 合体後の形態が出撃中なら使用不可
                    //                    GUI.MainForm.mnuUnitCommandItem(DismissCmdID).Visible = true;
                    //                    var loopTo27 = withBlock12.CountFeature();
                    //                    for (j = 1; j <= loopTo27; j++)
                    //                    {
                    //                        if (withBlock12.Feature(j) == "合体")
                    //                        {
                    //                            string localFeatureData11() { object argIndex1 = j; var ret = withBlock12.FeatureData(argIndex1); return ret; }

                    //                            uname = GeneralLib.LIndex(localFeatureData11(), 2);
                    //                            if (SRC.UList.IsDefined(uname))
                    //                            {
                    //                                Unit localItem2() { object argIndex1 = uname; var ret = SRC.UList.Item(argIndex1); return ret; }

                    //                                {
                    //                                    var withBlock13 = localItem2().CurrentForm();
                    //                                    if (withBlock13.Status_Renamed == "出撃" | withBlock13.Status_Renamed == "格納")
                    //                                    {
                    //                                        GUI.MainForm.mnuUnitCommandItem(DismissCmdID).Visible = false;
                    //                                    }
                    //                                }
                    //                            }
                    //                        }
                    //                    }

                    //                    break;
                    //                }
                    //        }
                    //    }
                    //}

                    //if (currentUnit.IsFeatureAvailable("召喚解除コマンド名"))
                    //{
                    //    GUI.MainForm.mnuUnitCommandItem(DismissCmdID).Caption = currentUnit.FeatureData("召喚解除コマンド名");
                    //}
                    //else
                    //{
                    //    GUI.MainForm.mnuUnitCommandItem(DismissCmdID).Caption = "召喚解除";
                    //}

                    // ユニットコマンド
                    foreach (LabelData lab in Event.colEventLabelList.Values
                        .Where(x => x.Name == LabelType.UnitCommandEventLabel && x.Enable))
                    {
                        var label = lab.Para(2);
                        var target = lab.Para(3);
                        if (SelectedUnit.Party == "味方" && (
                                (target ?? "") == (SelectedUnit.MainPilot().Name ?? "")
                                || (target ?? "") == (SelectedUnit.MainPilot().get_Nickname(false) ?? "")
                                || (target ?? "") == (SelectedUnit.Name ?? "")
                            )
                            || (target ?? "") == (SelectedUnit.Party ?? "")
                            || target == "全")
                        {
                            if (lab.CountPara() <= 3)
                            {
                                // 無条件で実行できるコマンド
                                unitCommands.Add(new UiCommand(UnitCommandCmdID, lab.Para(2), lab));
                            }
                            else if (GeneralLib.StrToLng(lab.Para(4)) != 0)
                            {
                                // 条件を満たした場合のみ実行できるコマンド
                                unitCommands.Add(new UiCommand(UnitCommandCmdID, lab.Para(2), lab));
                            }
                        }
                        // TODO 上限儲けるなら適当に打ち切る
                    }
                }
            }

            //if (!ReferenceEquals(SelectedUnit, Status.DisplayedUnit))
            //{
            //    // MOD START 240a
            //    // DisplayUnitStatus SelectedUnit
            //    // 新ＧＵＩ使用時はクリック時にユニットステータスを表示しない
            //    if (!GUI.NewGUIMode)
            //    {
            //        Status.DisplayUnitStatus(SelectedUnit);
            //    }
            //    // MOD  END  240a
            //}

            GUI.IsGUILocked = false;
            GUI.ShowUnitCommandMenu(unitCommands.OrderBy(x => x.Id).ToList());
            //if (by_cancel)
            //{
            //    GUI.MainForm.PopupMenu(GUI.MainForm.mnuUnitCommand, 6, GUI.MouseX, GUI.MouseY + 5f);
            //}
            //else
            //{
            //    GUI.MainForm.PopupMenu(GUI.MainForm.mnuUnitCommand, 6, GUI.MouseX, GUI.MouseY - 6f);
            //}
        }


        private void ProceedAfterMoveCommandSelect(
            bool by_cancel = false,
            GuiButton button = GuiButton.None,
            MapCell cell = null,
            Unit unit = null)
        {
            LogDebug();

            Event.SelectedUnitForEvent = SelectedUnit;
            var unitCommands = new List<UiCommand>();

            {
                var currentUnit = SelectedUnit;
                //// 移動時にＥＮを消費している場合はステータスウィンドウを更新
                //// MOD START MARGE
                //// If MainWidth = 15 Then
                //if (!GUI.NewGUIMode)
                //{
                //    // MOD END MARGE
                //    if (PrevUnitEN != currentUnit.EN)
                //    {
                //        Status.DisplayUnitStatus(SelectedUnit);
                //    }
                //}

                unitCommands.Add(new UiCommand(WaitCmdID, "待機"));

                //// 会話コマンド
                //GUI.MainForm.mnuUnitCommandItem(TalkCmdID).Visible = false;
                //for (i = 1; i <= 4; i++)
                //{
                //    // UPGRADE_NOTE: オブジェクト u をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                //    u = null;
                //    switch (i)
                //    {
                //        case 1:
                //            {
                //                if (currentUnit.x > 1)
                //                {
                //                    u = Map.MapDataForUnit[currentUnit.x - 1, currentUnit.y];
                //                }

                //                break;
                //            }

                //        case 2:
                //            {
                //                if (currentUnit.x < Map.MapWidth)
                //                {
                //                    u = Map.MapDataForUnit[currentUnit.x + 1, currentUnit.y];
                //                }

                //                break;
                //            }

                //        case 3:
                //            {
                //                if (currentUnit.y > 1)
                //                {
                //                    u = Map.MapDataForUnit[currentUnit.x, currentUnit.y - 1];
                //                }

                //                break;
                //            }

                //        case 4:
                //            {
                //                if (currentUnit.y < Map.MapHeight)
                //                {
                //                    u = Map.MapDataForUnit[currentUnit.x, currentUnit.y + 1];
                //                }

                //                break;
                //            }
                //    }

                //    if (u is object)
                //    {
                //        if (Event.IsEventDefined("会話 " + currentUnit.MainPilot().ID + " " + u.MainPilot().ID))
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(TalkCmdID).Visible = true;
                //            break;
                //        }
                //    }
                //}

                // 攻撃コマンド
                if (currentUnit.Weapons.Any(x => x.IsWeaponUseful("移動後")))
                {
                    unitCommands.Add(new UiCommand(AttackCmdID, "攻撃"));
                }

                //if (currentUnit.Area == "地中")
                //{
                //    GUI.MainForm.mnuUnitCommandItem(AttackCmdID).Visible = false;
                //}

                //if (currentUnit.IsConditionSatisfied("攻撃不能"))
                //{
                //    GUI.MainForm.mnuUnitCommandItem(AttackCmdID).Visible = false;
                //}

                //// 修理コマンド
                //GUI.MainForm.mnuUnitCommandItem(FixCmdID).Visible = false;
                //if (currentUnit.IsFeatureAvailable("修理装置") && currentUnit.Area != "地中")
                //{
                //    for (i = 1; i <= 4; i++)
                //    {
                //        // UPGRADE_NOTE: オブジェクト u をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                //        u = null;
                //        switch (i)
                //        {
                //            case 1:
                //                {
                //                    if (currentUnit.x > 1)
                //                    {
                //                        u = Map.MapDataForUnit[currentUnit.x - 1, currentUnit.y];
                //                    }

                //                    break;
                //                }

                //            case 2:
                //                {
                //                    if (currentUnit.x < Map.MapWidth)
                //                    {
                //                        u = Map.MapDataForUnit[currentUnit.x + 1, currentUnit.y];
                //                    }

                //                    break;
                //                }

                //            case 3:
                //                {
                //                    if (currentUnit.y > 1)
                //                    {
                //                        u = Map.MapDataForUnit[currentUnit.x, currentUnit.y - 1];
                //                    }

                //                    break;
                //                }

                //            case 4:
                //                {
                //                    if (currentUnit.y < Map.MapHeight)
                //                    {
                //                        u = Map.MapDataForUnit[currentUnit.x, currentUnit.y + 1];
                //                    }

                //                    break;
                //                }
                //        }

                //        if (u is object)
                //        {
                //            {
                //                var withBlock16 = u;
                //                if ((withBlock16.Party == "味方" | withBlock16.Party == "ＮＰＣ") && withBlock16.HP < withBlock16.MaxHP)
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(FixCmdID).Visible = true;
                //                    break;
                //                }
                //            }
                //        }
                //    }

                //    if (Strings.Len(currentUnit.FeatureData("修理装置")) > 0)
                //    {
                //        GUI.MainForm.mnuUnitCommandItem(FixCmdID).Caption = GeneralLib.LIndex(currentUnit.FeatureData("修理装置"), 1);
                //        string localLIndex19() { object argIndex1 = "修理装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //        if (Information.IsNumeric(localLIndex19()))
                //        {
                //            string localLIndex17() { object argIndex1 = "修理装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //            string localLIndex18() { object argIndex1 = "修理装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //            if (currentUnit.EN < Conversions.Toint(localLIndex18()))
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(FixCmdID).Visible = false;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        GUI.MainForm.mnuUnitCommandItem(FixCmdID).Caption = "修理装置";
                //    }
                //}

                //// 補給コマンド
                //GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = false;
                //if (currentUnit.IsFeatureAvailable("補給装置") && currentUnit.Area != "地中")
                //{
                //    for (i = 1; i <= 4; i++)
                //    {
                //        // UPGRADE_NOTE: オブジェクト u をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                //        u = null;
                //        switch (i)
                //        {
                //            case 1:
                //                {
                //                    if (currentUnit.x > 1)
                //                    {
                //                        u = Map.MapDataForUnit[currentUnit.x - 1, currentUnit.y];
                //                    }

                //                    break;
                //                }

                //            case 2:
                //                {
                //                    if (currentUnit.x < Map.MapWidth)
                //                    {
                //                        u = Map.MapDataForUnit[currentUnit.x + 1, currentUnit.y];
                //                    }

                //                    break;
                //                }

                //            case 3:
                //                {
                //                    if (currentUnit.y > 1)
                //                    {
                //                        u = Map.MapDataForUnit[currentUnit.x, currentUnit.y - 1];
                //                    }

                //                    break;
                //                }

                //            case 4:
                //                {
                //                    if (currentUnit.y < Map.MapHeight)
                //                    {
                //                        u = Map.MapDataForUnit[currentUnit.x, currentUnit.y + 1];
                //                    }

                //                    break;
                //                }
                //        }

                //        if (u is object)
                //        {
                //            {
                //                var withBlock17 = u;
                //                if (withBlock17.Party == "味方" | withBlock17.Party == "ＮＰＣ")
                //                {
                //                    if (withBlock17.EN < withBlock17.MaxEN)
                //                    {
                //                        GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = true;
                //                    }
                //                    else
                //                    {
                //                        var loopTo29 = withBlock17.CountWeapon();
                //                        for (j = 1; j <= loopTo29; j++)
                //                        {
                //                            if (withBlock17.Bullet(j) < withBlock17.MaxBullet(j))
                //                            {
                //                                GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = true;
                //                                break;
                //                            }
                //                        }

                //                        var loopTo30 = withBlock17.CountAbility();
                //                        for (j = 1; j <= loopTo30; j++)
                //                        {
                //                            if (withBlock17.Stock(j) < withBlock17.MaxStock(j))
                //                            {
                //                                GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = true;
                //                                break;
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }

                //    if (Strings.Len(currentUnit.FeatureData("補給装置")) > 0)
                //    {
                //        GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Caption = GeneralLib.LIndex(currentUnit.FeatureData("補給装置"), 1);
                //        string localLIndex22() { object argIndex1 = "補給装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //        if (Information.IsNumeric(localLIndex22()))
                //        {
                //            string localLIndex20() { object argIndex1 = "補給装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //            string localLIndex21() { object argIndex1 = "補給装置"; string arglist = currentUnit.FeatureData(argIndex1); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

                //            if (currentUnit.EN < Conversions.Toint(localLIndex21()) | currentUnit.MainPilot().Morale < 100)
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = false;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Caption = "補給装置";
                //    }

                //    if (Expression.IsOptionDefined("移動後補給不可") && !SelectedUnit.MainPilot().IsSkillAvailable("補給"))
                //    {
                //        GUI.MainForm.mnuUnitCommandItem(SupplyCmdID).Visible = false;
                //    }
                //}

                // アビリティコマンド
                if (currentUnit.Area != "地中")
                {
                    var displayAbilities = currentUnit.Abilities.Where(x => x.IsAbilityMastered()
                      && !x.Data.IsItem()
                      && x.IsAbilityUseful("移動後")
                      ).ToList();
                    if (displayAbilities.Count > 0)
                    {
                        var caption = Expression.Term("アビリティ", SelectedUnit);
                        var unitAbilities = currentUnit.Abilities.Where(x => !x.Data.IsItem()).ToList();
                        unitCommands.Add(new UiCommand(
                            AbilityCmdID,
                            unitAbilities.Count == 1 ? unitAbilities.First().AbilityNickname() : caption));
                    }
                }

                //{
                //    var withBlock18 = GUI.MainForm;
                //    withBlock18.mnuUnitCommandItem(ChargeCmdID).Visible = false;
                //    withBlock18.mnuUnitCommandItem(SpecialPowerCmdID).Visible = false;
                //    withBlock18.mnuUnitCommandItem(TransformCmdID).Visible = false;
                //    withBlock18.mnuUnitCommandItem(SplitCmdID).Visible = false;
                //}

                //// 合体コマンド
                //GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Visible = false;
                //if (currentUnit.IsFeatureAvailable("合体") && !currentUnit.IsConditionSatisfied("形態固定") && !currentUnit.IsConditionSatisfied("機体固定"))
                //{
                //    var loopTo33 = currentUnit.CountFeature();
                //    for (i = 1; i <= loopTo33; i++)
                //    {
                //        // 3体以上からなる合体能力を持っているか？
                //        string localFeature1() { object argIndex1 = i; var ret = currentUnit.Feature(argIndex1); return ret; }

                //        string localFeatureName1() { object argIndex1 = i; var ret = currentUnit.FeatureName(argIndex1); return ret; }

                //        string localFeatureData17() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //        int localLLength4() { string arglist = hs9469e7ffcaeb496ca82716c7891638cc(); var ret = GeneralLib.LLength(arglist); return ret; }

                //        if (localFeature1() == "合体" && !string.IsNullOrEmpty(localFeatureName1()) && localLLength4() > 3)
                //        {
                //            n = 0;
                //            string localFeatureData13() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //            var loopTo34 = GeneralLib.LLength(localFeatureData13());
                //            for (j = 3; j <= loopTo34; j++)
                //            {
                //                string localFeatureData12() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //                string localLIndex23() { string arglist = hs175f067af849438ea2ce369fbd24d08f(); var ret = GeneralLib.LIndex(arglist, j); return ret; }

                //                u = SRC.UList.Item(localLIndex23());
                //                if (u is null)
                //                {
                //                    break;
                //                }

                //                if (!u.IsOperational())
                //                {
                //                    break;
                //                }

                //                if (u.Status_Renamed != "出撃" && u.CurrentForm().IsFeatureAvailable("合体制限"))
                //                {
                //                    break;
                //                }

                //                if (Math.Abs((currentUnit.x - u.CurrentForm().x)) + Math.Abs((currentUnit.y - u.CurrentForm().y)) > 2)
                //                {
                //                    break;
                //                }

                //                n = (n + 1);
                //            }

                //            string localFeatureData14() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //            uname = GeneralLib.LIndex(localFeatureData14(), 2);
                //            u = SRC.UList.Item(uname);
                //            if (u is null)
                //            {
                //                n = 0;
                //            }
                //            else if (u.IsConditionSatisfied("行動不能"))
                //            {
                //                n = 0;
                //            }

                //            string localFeatureData16() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //            int localLLength3() { string arglist = hse55df985d6054cfe94b90350a9c471f6(); var ret = GeneralLib.LLength(arglist); return ret; }

                //            if (n == localLLength3() - 2)
                //            {
                //                GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Visible = true;
                //                string localFeatureData15() { object argIndex1 = i; var ret = currentUnit.FeatureData(argIndex1); return ret; }

                //                GUI.MainForm.mnuUnitCommandItem(CombineCmdID).Caption = GeneralLib.LIndex(localFeatureData15(), 1);
                //                break;
                //            }
                //        }
                //    }
                //}

                //{
                //    var withBlock19 = GUI.MainForm;
                //    withBlock19.mnuUnitCommandItem(HyperModeCmdID).Visible = false;
                //    withBlock19.mnuUnitCommandItem(GroundCmdID).Visible = false;
                //    withBlock19.mnuUnitCommandItem(SkyCmdID).Visible = false;
                //    withBlock19.mnuUnitCommandItem(UndergroundCmdID).Visible = false;
                //    withBlock19.mnuUnitCommandItem(WaterCmdID).Visible = false;
                //    withBlock19.mnuUnitCommandItem(LaunchCmdID).Visible = false;
                //}

                //// アイテムコマンド
                //GUI.MainForm.mnuUnitCommandItem(ItemCmdID).Visible = false;
                //var loopTo35 = currentUnit.CountAbility();
                //for (i = 1; i <= loopTo35; i++)
                //{
                //    if (currentUnit.IsAbilityUseful(i, "移動後") && currentUnit.Ability(i).IsItem())
                //    {
                //        GUI.MainForm.mnuUnitCommandItem(ItemCmdID).Visible = true;
                //        break;
                //    }
                //}

                //if (currentUnit.Area == "地中")
                //{
                //    GUI.MainForm.mnuUnitCommandItem(ItemCmdID).Visible = false;
                //}

                //{
                //    var withBlock20 = GUI.MainForm;
                //    withBlock20.mnuUnitCommandItem(DismissCmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(OrderCmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(FeatureListCmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(WeaponListCmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(AbilityListCmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand1CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand2CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand3CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand4CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand5CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand6CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand7CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand8CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand9CmdID).Visible = false;
                //    withBlock20.mnuUnitCommandItem(UnitCommand10CmdID).Visible = false;
                //}

                //// ユニットコマンド
                //i = UnitCommand1CmdID;
                //foreach (LabelData currentLab4 in Event.colEventLabelList)
                //{
                //    lab = currentLab4;
                //    if (lab.Name == Event.LabelType.UnitCommandEventLabel && lab.AsterNum >= 2)
                //    {
                //        if (lab.Enable)
                //        {
                //            buf = lab.Para(3);
                //            if (SelectedUnit.Party == "味方" && ((buf ?? "") == (SelectedUnit.MainPilot().Name ?? "") | (buf ?? "") == (SelectedUnit.MainPilot().get_Nickname(false) ?? "") | (buf ?? "") == (SelectedUnit.Name ?? "")) | (buf ?? "") == (SelectedUnit.Party ?? "") | buf == "全")
                //            {
                //                int localStrToLng3() { string argexpr = lab.Para(4); var ret = GeneralLib.StrToLng(argexpr); return ret; }

                //                if (lab.CountPara() <= 3)
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(i).Visible = true;
                //                }
                //                else if (localStrToLng3() != 0)
                //                {
                //                    GUI.MainForm.mnuUnitCommandItem(i).Visible = true;
                //                }
                //            }
                //        }

                //        if (GUI.MainForm.mnuUnitCommandItem(i).Visible)
                //        {
                //            GUI.MainForm.mnuUnitCommandItem(i).Caption = lab.Para(2);
                //            UnitCommandLabelList[i - UnitCommand1CmdID + 1] = lab.LineNum.ToString();
                //            i = (i + 1);
                //            if (i > UnitCommand10CmdID)
                //            {
                //                break;
                //            }
                //        }
                //    }
                //}
            }

            GUI.IsGUILocked = false;
            GUI.ShowUnitCommandMenu(unitCommands.OrderBy(x => x.Id).ToList());
            //if (by_cancel)
            //{
            //    GUI.MainForm.PopupMenu(GUI.MainForm.mnuUnitCommand, 6, GUI.MouseX, GUI.MouseY + 5f);
            //}
            //else
            //{
            //    GUI.MainForm.PopupMenu(GUI.MainForm.mnuUnitCommand, 6, GUI.MouseX, GUI.MouseY - 6f);
            //    Application.DoEvents();
            //    // ＰＣに負荷がかかったような状態だとポップアップメニューの選択が
            //    // うまく行えない場合があるのでやり直す
            //    while (CommandState == "移動後コマンド選択" && SelectedCommand == "移動")
            //    {
            //        GUI.MainForm.PopupMenu(GUI.MainForm.mnuUnitCommand, 6, GUI.MouseX, GUI.MouseY - 6f);
            //        Application.DoEvents();
            //    }
            //}
        }

        private void ProceedTargetSelect(
            bool by_cancel = false,
            GuiButton button = GuiButton.None,
            MapCell cell = null,
            Unit unit = null)
        {
            LogDebug();

            // TODO
            if (cell == null)
            {
                return;
            }
            if (!Map.MaskData[cell.X, cell.Y])
            {
                SelectedX = cell.X;
                SelectedY = cell.Y;

                // 自分自身を選択された場合
                if (SelectedUnit.x == SelectedX && SelectedUnit.y == SelectedY)
                {
                    //if (SelectedCommand == "スペシャルパワー")
                    //{
                    //}
                    //// 下に抜ける
                    //else if (SelectedCommand == "アビリティ" | SelectedCommand == "マップアビリティ" | SelectedCommand == "アイテム" | SelectedCommand == "マップアイテム")
                    //{
                    //    if (SelectedUnit.AbilityMinRange(SelectedAbility) > 0)
                    //    {
                    //        // 自分自身は選択不可
                    //        GUI.IsGUILocked = false;
                    //        return;
                    //    }
                    //}
                    //else if (SelectedCommand == "移動命令")
                    //{
                    //}
                    //// 下に抜ける
                    //else
                    //{
                    //    // 自分自身は選択不可
                    //    GUI.IsGUILocked = false;
                    //    return;
                    //}
                }

                // 場所を選択するコマンド
                switch (SelectedCommand ?? "")
                {
                    case "移動":
                    case "再移動":
                        FinishMoveCommand();
                        GUI.IsGUILocked = false;
                        return;

                    case "テレポート":
                        FinishTeleportCommand();
                        GUI.IsGUILocked = false;
                        return;

                    case "ジャンプ":
                        FinishJumpCommand();
                        GUI.IsGUILocked = false;
                        return;

                    //case "マップ攻撃":
                    //        MapAttackCommand();
                    //        GUI.IsGUILocked = false;
                    //        return;

                    //case "マップアビリティ":
                    //case "マップアイテム":
                    //        MapAbilityCommand();
                    //        GUI.IsGUILocked = false;
                    //        return;

                    case "発進":
                        FinishLaunchCommand();
                        GUI.IsGUILocked = false;
                        return;

                        //case "移動命令":
                        //        FinishOrderCommand();
                        //        GUI.IsGUILocked = false;
                        //        return;
                }

                // これ以降はユニットを選択するコマンド

                // 指定した地点にユニットがいる？
                if (Map.MapDataForUnit[SelectedX, SelectedY] is null)
                {
                    GUI.IsGUILocked = false;
                    return;
                }

                // ターゲットを選択
                SelectedTarget = Map.MapDataForUnit[SelectedX, SelectedY];
                switch (SelectedCommand ?? "")
                {
                    case "攻撃":
                        FinishAttackCommand();
                        break;

                        //    case "アビリティ":
                        //    case "アイテム":
                        //        FinishAbilityCommand();
                        //        break;

                        //    case "会話":
                        //        FinishTalkCommand();
                        //        break;

                        //    case "修理":
                        //        FinishFixCommand();
                        //        break;

                        //    case "補給":
                        //        FinishSupplyCommand();
                        //        break;

                        //    case "スペシャルパワー":
                        //        FinishSpecialPowerCommand();
                        //        break;

                        //    case "攻撃命令":
                        //    case "護衛命令":
                        //        FinishOrderCommand();
                        //        break;
                }
            }
        }

        private void ProceedMapAttack(
            bool by_cancel = false,
            GuiButton button = GuiButton.None,
            MapCell cell = null,
            Unit unit = null)
        {
            LogDebug();

            //if (1 <= GUI.PixelToMapX(GUI.MouseX) && GUI.PixelToMapX(GUI.MouseX) <= Map.MapWidth)
            //{
            //    if (1 <= GUI.PixelToMapY(GUI.MouseY) && GUI.PixelToMapY(GUI.MouseY) <= Map.MapHeight)
            //    {
            //        if (!Map.MaskData[GUI.PixelToMapX(GUI.MouseX), GUI.PixelToMapY(GUI.MouseY)])
            //        {
            //            // 効果範囲内でクリックされればマップ攻撃発動
            //            if (SelectedCommand == "マップ攻撃")
            //            {
            //                MapAttackCommand();
            //            }
            //            else
            //            {
            //                MapAbilityCommand();
            //            }
            //        }
            //    }
            //}
        }

        // ＧＵＩの処理をキャンセル
        public void CancelCommand()
        {
            LogDebug();

            var currentUnit = SelectedUnit;
            switch (CommandState ?? "")
            {
                case "ユニット選択":
                    break;

                case "コマンド選択":
                    CommandState = "ユニット選択";
                    // 選択したコマンドを初期化
                    SelectedCommand = "";
                    //// MOD START MARGE
                    //// If MainWidth <> 15 Then
                    //if (GUI.NewGUIMode)
                    //{
                    //    // MOD  END  MARGE
                    //    Status.ClearUnitStatus();
                    //}

                    break;

                case "ターゲット選択":
                    if (SelectedCommand == "再移動")
                    {
                        WaitCommand();
                        return;
                    }
                    CommandState = "コマンド選択";
                    Status.DisplayUnitStatus(SelectedUnit);
                    GUI.RedrawScreen();
                    ProceedCommand(true);
                    break;

                case "移動後コマンド選択":
                    CommandState = "ターゲット選択";
                    currentUnit.Area = PrevUnitArea;
                    currentUnit.Move(PrevUnitX, PrevUnitY, true, true);
                    currentUnit.EN = PrevUnitEN;
                    if (!ReferenceEquals(SelectedUnit, Map.MapDataForUnit[PrevUnitX, PrevUnitY]))
                    {
                        // 発進をキャンセルした場合
                        SelectedTarget = SelectedUnit;
                        GUI.PaintUnitBitmap(SelectedTarget);
                        SelectedUnit = Map.MapDataForUnit[PrevUnitX, PrevUnitY];
                    }
                    //// MOD START MARGE
                    //// ElseIf MainWidth = 15 Then
                    //else if (!GUI.NewGUIMode)
                    //{
                    //    // MOD END MARGE
                    //    Status.DisplayUnitStatus(SelectedUnit);
                    //}
                    //// MOD START MARGE
                    // 移動後コマンドをキャンセルした場合、MoveCostを0にリセットする
                    SelectedUnitMoveCost = 0;
                    switch (SelectedCommand ?? "")
                    {
                        case "移動":
                            StartMoveCommand();
                            break;

                        //case "テレポート":
                        //    StartTeleportCommand();
                        //    break;

                        //case "ジャンプ":
                        //    StartJumpCommand();
                        //    break;

                        case "発進":
                            GUI.PaintUnitBitmap(SelectedTarget);
                            break;
                    }

                    break;

                case "移動後ターゲット選択":
                    CommandState = "移動後コマンド選択";
                    Status.DisplayUnitStatus(SelectedUnit);
                    var tmp_x = currentUnit.x;
                    var tmp_y = currentUnit.y;
                    currentUnit.x = PrevUnitX;
                    currentUnit.y = PrevUnitY;
                    switch (PrevCommand ?? "")
                    {
                        case "移動":
                            Map.AreaInSpeed(SelectedUnit);
                            break;

                        case "テレポート":
                            Map.AreaInTeleport(SelectedUnit);
                            break;

                        case "ジャンプ":
                            Map.AreaInSpeed(SelectedUnit, true);
                            break;

                        case "発進":
                            var targetUnit = SelectedTarget;

                            if (targetUnit.IsFeatureAvailable("テレポート")
                                && (targetUnit.Data.Speed == 0
                                || GeneralLib.LIndex(targetUnit.FeatureData("テレポート"), 2) == "0"))
                            {
                                Map.AreaInTeleport(SelectedTarget);
                            }
                            else if (targetUnit.IsFeatureAvailable("ジャンプ")
                                && (targetUnit.Data.Speed == 0
                                || GeneralLib.LLength(targetUnit.FeatureData("ジャンプ")) < 2
                                || GeneralLib.LIndex(targetUnit.FeatureData("ジャンプ"), 2) == "0"))
                            {
                                Map.AreaInSpeed(SelectedTarget, true);
                            }
                            else
                            {
                                Map.AreaInSpeed(SelectedTarget);
                            }
                            break;
                    }

                    currentUnit.x = tmp_x;
                    currentUnit.y = tmp_y;
                    SelectedCommand = PrevCommand;
                    Map.MaskData[tmp_x, tmp_y] = false;
                    GUI.MaskScreen();
                    ProceedCommand(true);
                    break;

                case "マップ攻撃使用":
                case "移動後マップ攻撃使用":
                    if (CommandState == "マップ攻撃使用")
                    {
                        CommandState = "ターゲット選択";
                    }
                    else
                    {
                        CommandState = "移動後ターゲット選択";
                    }

                    //if (SelectedCommand == "マップ攻撃")
                    //{
                    //    if (currentUnit.IsWeaponClassifiedAs(SelectedWeapon, "Ｍ直"))
                    //    {
                    //        Map.AreaInCross(currentUnit.x, currentUnit.y, currentUnit.WeaponMaxRange(SelectedWeapon), currentUnit.Weapon(SelectedWeapon).MinRange);
                    //    }
                    //    else if (currentUnit.IsWeaponClassifiedAs(SelectedWeapon, "Ｍ移"))
                    //    {
                    //        Map.AreaInMoveAction(SelectedUnit, currentUnit.WeaponMaxRange(SelectedWeapon));
                    //    }
                    //    else
                    //    {
                    //        Map.AreaInRange(currentUnit.x, currentUnit.y, currentUnit.WeaponMaxRange(SelectedWeapon), currentUnit.Weapon(SelectedWeapon).MinRange, "すべて");
                    //    }
                    //}
                    //else
                    //{
                    //    if (currentUnit.IsAbilityClassifiedAs(SelectedAbility, "Ｍ直"))
                    //    {
                    //        Map.AreaInCross(currentUnit.x, currentUnit.y, currentUnit.AbilityMaxRange(SelectedAbility), currentUnit.AbilityMinRange(SelectedAbility));
                    //    }
                    //    else if (currentUnit.IsAbilityClassifiedAs(SelectedAbility, "Ｍ移"))
                    //    {
                    //        Map.AreaInMoveAction(SelectedUnit, currentUnit.AbilityMaxRange(SelectedAbility));
                    //    }
                    //    else
                    //    {
                    //        Map.AreaInRange(currentUnit.x, currentUnit.y, currentUnit.AbilityMaxRange(SelectedAbility), currentUnit.AbilityMinRange(SelectedAbility), "すべて");
                    //    }
                    //}

                    GUI.MaskScreen();
                    break;
            }
        }
    }
}

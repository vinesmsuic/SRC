// Copyright (C) 1997-2012 Kei Sakamoto / Inui Tetsuyuki
// 本プログラムはフリーソフトであり、無保証です。
// 本プログラムはGNU General Public License(Ver.3またはそれ以降)が定める条件の下で
// 再頒布または改変することができます。

using SRCCore.Lib;
using SRCCore.Units;
using SRCCore.VB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SRCCore.Commands
{
    public partial class Command
    {
        // 「特殊能力一覧」コマンド
        private void FeatureListCommand()
        {
            LogDebug();

            throw new NotImplementedException();
            //string[] list;
            //var id_list = default(string[]);
            //bool[] is_unit_feature;
            //int i, j;
            //var ret = default;
            //string fname0, fname, ftype;
            //GUI.LockGUI();

            //// 表示する特殊能力名一覧の作成
            //list = new string[1];
            //var id_ist = new object[1];
            //is_unit_feature = new bool[1];

            //// 武器・防具クラス
            //if (Expression.IsOptionDefined("アイテム交換"))
            //{
            //    {
            //        var withBlock = SelectedUnit;
            //        if (withBlock.IsFeatureAvailable("武器クラス") || withBlock.IsFeatureAvailable("武器クラス"1))
            //        {
            //            Array.Resize(list, Information.UBound(list) + 1 + 1);
            //            Array.Resize(id_list, Information.UBound(list) + 1);
            //            Array.Resize(is_unit_feature, Information.UBound(list) + 1);
            //            list[Information.UBound(list)] = "武器・防具クラス";
            //            id_list[Information.UBound(list)] = "武器・防具クラス";
            //            is_unit_feature[Information.UBound(list)] = true;
            //        }
            //    }
            //}

            //{
            //    var withBlock1 = SelectedUnit.MainPilot();
            //    // パイロット特殊能力
            //    var loopTo = withBlock1.CountSkill();
            //    for (i = 1; i <= loopTo; i++)
            //    {
            //        switch (withBlock1.Skill(i) ?? "")
            //        {
            //            case "得意技":
            //            case "不得手":
            //                {
            //                    fname = withBlock1.Skill(i);
            //                    break;
            //                }

            //            default:
            //                {
            //                    fname = withBlock1.SkillName(i);
            //                    break;
            //                }
            //        }

            //        // 非表示の能力は除く
            //        if (Strings.InStr(fname, "非表示") > 0)
            //        {
            //            goto NextSkill;
            //        }

            //        // 既に表示されていればスキップ
            //        var loopTo1 = Information.UBound(list);
            //        for (j = 1; j <= loopTo1; j++)
            //        {
            //            if ((list[j] ?? "") == (fname ?? ""))
            //            {
            //                goto NextSkill;
            //            }
            //        }

            //        // リストに追加
            //        Array.Resize(list, Information.UBound(list) + 1 + 1);
            //        Array.Resize(id_list, Information.UBound(list) + 1);
            //        list[Information.UBound(list)] = fname;
            //        id_list[Information.UBound(list)] = SrcFormatter.Format(i);
            //    NextSkill:
            //        ;
            //    }
            //}

            //{
            //    var withBlock2 = SelectedUnit;
            //    // 付加・強化されたパイロット用特殊能力
            //    var loopTo2 = withBlock2.CountCondition();
            //    for (i = 1; i <= loopTo2; i++)
            //    {
            //        // パイロット能力付加または強化？
            //        string localCondition() { object argIndex1 = i; var ret = withBlock2.Condition(argIndex1); return ret; }

            //        string localCondition1() { object argIndex1 = i; var ret = withBlock2.Condition(argIndex1); return ret; }

            //        if (Strings.Right(localCondition(), 3) != "付加２" && Strings.Right(localCondition1(), 3) != "強化２")
            //        {
            //            goto NextSkill2;
            //        }

            //        string localCondition2() { object argIndex1 = i; var ret = withBlock2.Condition(argIndex1); return ret; }

            //        string localCondition3() { object argIndex1 = i; var ret = withBlock2.Condition(argIndex1); return ret; }

            //        ftype = Strings.Left(localCondition2(), Strings.Len(localCondition3()) - 3);

            //        // 非表示の能力？
            //        string localConditionData() { object argIndex1 = i; var ret = withBlock2.ConditionData(argIndex1); return ret; }

            //        switch (GeneralLib.LIndex(localConditionData(), 1) ?? "")
            //        {
            //            case "非表示":
            //            case "解説":
            //                {
            //                    goto NextSkill2;
            //                    break;
            //                }
            //        }

            //        // 有効時間が残っている？
            //        if (withBlock2.ConditionLifetime(i) == 0)
            //        {
            //            goto NextSkill2;
            //        }

            //        // 表示名称
            //        fname = withBlock2.MainPilot().SkillName(ftype);
            //        if (Strings.InStr(fname, "非表示") > 0)
            //        {
            //            goto NextSkill2;
            //        }

            //        // 既に表示していればスキップ
            //        var loopTo3 = Information.UBound(list);
            //        for (j = 1; j <= loopTo3; j++)
            //        {
            //            if ((list[j] ?? "") == (fname ?? ""))
            //            {
            //                goto NextSkill2;
            //            }
            //        }

            //        // リストに追加
            //        Array.Resize(list, Information.UBound(list) + 1 + 1);
            //        Array.Resize(id_list, Information.UBound(list) + 1);
            //        list[Information.UBound(list)] = fname;
            //        id_list[Information.UBound(list)] = ftype;
            //    NextSkill2:
            //        ;
            //    }

            //    Array.Resize(is_unit_feature, Information.UBound(list) + 1);

            //    // ユニット用特殊能力
            //    // 付加された特殊能力より先に固有の特殊能力を表示
            //    if (withBlock2.CountAllFeature() > withBlock2.AdditionalFeaturesNum)
            //    {
            //        i = (withBlock2.AdditionalFeaturesNum + 1);
            //    }
            //    else
            //    {
            //        i = 1;
            //    }

            //    while (i <= withBlock2.CountAllFeature())
            //    {
            //        // 非表示の特殊能力を排除
            //        if (string.IsNullOrEmpty(withBlock2.AllFeatureName(i)))
            //        {
            //            goto NextFeature;
            //        }

            //        // 合体の場合は合体後の形態が作成されていなければならない
            //        string localAllFeature() { object argIndex1 = i; var ret = withBlock2.AllFeature(argIndex1); return ret; }

            //        string localAllFeatureData() { object argIndex1 = i; var ret = withBlock2.AllFeatureData(argIndex1); return ret; }

            //        string localLIndex() { string arglist = hs7afb75fef08b43c283a05523ef7388cb(); var ret = GeneralLib.LIndex(arglist, 2); return ret; }

            //        bool localIsDefined() { object argIndex1 = (object)hse6256782c58b487b8147a3f247066e6f(); var ret = SRC.UList.IsDefined(argIndex1); return ret; }

            //        if (localAllFeature() == "合体" && !localIsDefined())
            //        {
            //            goto NextFeature;
            //        }

            //        // 既に表示していればスキップ
            //        var loopTo4 = Information.UBound(list);
            //        for (j = 1; j <= loopTo4; j++)
            //        {
            //            string localAllFeatureName() { object argIndex1 = i; var ret = withBlock2.AllFeatureName(argIndex1); return ret; }

            //            if ((list[j] ?? "") == (localAllFeatureName() ?? ""))
            //            {
            //                goto NextFeature;
            //            }
            //        }

            //        // リストに追加
            //        Array.Resize(list, Information.UBound(list) + 1 + 1);
            //        Array.Resize(id_list, Information.UBound(list) + 1);
            //        Array.Resize(is_unit_feature, Information.UBound(list) + 1);
            //        list[Information.UBound(list)] = withBlock2.AllFeatureName(i);
            //        id_list[Information.UBound(list)] = SrcFormatter.Format(i);
            //        is_unit_feature[Information.UBound(list)] = true;
            //    NextFeature:
            //        ;
            //        if (i == withBlock2.AdditionalFeaturesNum)
            //        {
            //            break;
            //        }
            //        else if (i == withBlock2.CountFeature())
            //        {
            //            // 付加された特殊能力は後から表示
            //            if (withBlock2.AdditionalFeaturesNum > 0)
            //            {
            //                i = 0;
            //            }
            //        }

            //        i = (i + 1);
            //    }

            //    // アビリティで付加・強化されたパイロット用特殊能力
            //    var loopTo5 = withBlock2.CountCondition();
            //    for (i = 1; i <= loopTo5; i++)
            //    {
            //        // パイロット能力付加または強化？
            //        string localCondition4() { object argIndex1 = i; var ret = withBlock2.Condition(argIndex1); return ret; }

            //        string localCondition5() { object argIndex1 = i; var ret = withBlock2.Condition(argIndex1); return ret; }

            //        if (Strings.Right(localCondition4(), 2) != "付加" && Strings.Right(localCondition5(), 2) != "強化")
            //        {
            //            goto NextSkill3;
            //        }

            //        string localCondition6() { object argIndex1 = i; var ret = withBlock2.Condition(argIndex1); return ret; }

            //        string localCondition7() { object argIndex1 = i; var ret = withBlock2.Condition(argIndex1); return ret; }

            //        ftype = Strings.Left(localCondition6(), Strings.Len(localCondition7()) - 2);

            //        // 非表示の能力？
            //        if (ftype == "メッセージ")
            //        {
            //            goto NextSkill3;
            //        }

            //        string localConditionData1() { object argIndex1 = i; var ret = withBlock2.ConditionData(argIndex1); return ret; }

            //        switch (GeneralLib.LIndex(localConditionData1(), 1) ?? "")
            //        {
            //            case "非表示":
            //            case "解説":
            //                {
            //                    goto NextSkill3;
            //                    break;
            //                }
            //        }

            //        // 有効時間が残っている？
            //        if (withBlock2.ConditionLifetime(i) == 0)
            //        {
            //            goto NextSkill3;
            //        }

            //        // 表示名称
            //        if (string.IsNullOrEmpty(withBlock2.FeatureName0(ftype)))
            //        {
            //            goto NextSkill3;
            //        }

            //        fname = withBlock2.MainPilot().SkillName0(ftype);
            //        if (Strings.InStr(fname, "非表示") > 0)
            //        {
            //            goto NextSkill3;
            //        }

            //        // 付加されたユニット用特殊能力として既に表示していればスキップ
            //        var loopTo6 = Information.UBound(list);
            //        for (j = 1; j <= loopTo6; j++)
            //        {
            //            if ((list[j] ?? "") == (fname ?? ""))
            //            {
            //                goto NextSkill3;
            //            }
            //        }

            //        fname = withBlock2.MainPilot().SkillName(ftype);
            //        if (Strings.InStr(fname, "Lv") > 0)
            //        {
            //            fname0 = Strings.Left(fname, Strings.InStr(fname, "Lv") - 1);
            //        }
            //        else
            //        {
            //            fname0 = fname;
            //        }

            //        // パイロット用特殊能力として既に表示していればスキップ
            //        var loopTo7 = Information.UBound(list);
            //        for (j = 1; j <= loopTo7; j++)
            //        {
            //            if ((list[j] ?? "") == (fname ?? "") || (list[j] ?? "") == (fname0 ?? ""))
            //            {
            //                goto NextSkill3;
            //            }
            //        }

            //        // リストに追加
            //        Array.Resize(list, Information.UBound(list) + 1 + 1);
            //        Array.Resize(id_list, Information.UBound(list) + 1);
            //        Array.Resize(is_unit_feature, Information.UBound(list) + 1);
            //        list[Information.UBound(list)] = fname;
            //        id_list[Information.UBound(list)] = ftype;
            //        is_unit_feature[Information.UBound(list)] = false;
            //    NextSkill3:
            //        ;
            //    }
            //}

            //GUI.ListItemFlag = new bool[Information.UBound(list) + 1];
            //switch (Information.UBound(list))
            //{
            //    case 0:
            //        {
            //            break;
            //        }

            //    case 1:
            //        {
            //            if (SRC.AutoMoveCursor)
            //            {
            //                GUI.SaveCursorPos();
            //            }

            //            if (id_list[ret] == "武器・防具クラス")
            //            {
            //                Help.FeatureHelp(SelectedUnit, id_list[1], false);
            //            }
            //            else if (is_unit_feature[1])
            //            {
            //                Help.FeatureHelp(SelectedUnit, id_list[1], GeneralLib.StrToLng(id_list[1]) <= SelectedUnit.AdditionalFeaturesNum);
            //            }
            //            else
            //            {
            //                Help.SkillHelp(SelectedUnit.MainPilot(), id_list[1]);
            //            }

            //            if (SRC.AutoMoveCursor)
            //            {
            //                GUI.RestoreCursorPos();
            //            }

            //            break;
            //        }

            //    default:
            //        {
            //            GUI.TopItem = 1;
            //            ret = GUI.ListBox("特殊能力一覧", list, "能力名", "表示のみ");
            //            if (SRC.AutoMoveCursor)
            //            {
            //                GUI.MoveCursorPos("ダイアログ");
            //            }

            //            while (true)
            //            {
            //                ret = GUI.ListBox("特殊能力一覧", list, "能力名", "連続表示");
            //                // listが一定なので連続表示を流用
            //                My.MyProject.Forms.frmListBox.Hide();
            //                if (ret == 0)
            //                {
            //                    break;
            //                }

            //                if (id_list[ret] == "武器・防具クラス")
            //                {
            //                    Help.FeatureHelp(SelectedUnit, id_list[ret], false);
            //                }
            //                else if (is_unit_feature[ret])
            //                {
            //                    Help.FeatureHelp(SelectedUnit, id_list[ret], Conversions.ToDouble(id_list[ret]) <= SelectedUnit.AdditionalFeaturesNum);
            //                }
            //                else
            //                {
            //                    Help.SkillHelp(SelectedUnit.MainPilot(), id_list[ret]);
            //                }
            //            }

            //            if (SRC.AutoMoveCursor)
            //            {
            //                GUI.RestoreCursorPos();
            //            }

            //            break;
            //        }
            //}

            //CommandState = "ユニット選択";
            //GUI.UnlockGUI();
        }

        // 「武器一覧」コマンド
        private void WeaponListCommand()
        {
            LogDebug();

            GUI.LockGUI();
            while (true)
            {
                var u = SelectedUnit;
                var selectedWeapon = GUI.WeaponListBox(SelectedUnit, new Units.UnitWeaponList(Units.WeaponListMode.List, SelectedUnit), "武装一覧", "一覧", "");
                if (selectedWeapon == null)
                {
                    // キャンセル
                    if (SRC.AutoMoveCursor)
                    {
                        GUI.RestoreCursorPos();
                    }

                    // TODO リストボックス消す
                    //My.MyProject.Forms.frmListBox.Hide();
                    GUI.UnlockGUI();
                    CommandState = "ユニット選択";
                    return;
                }
                SelectedWeapon = selectedWeapon.WeaponNo();

                // 選択した武器の情報を表示
                // 指定された武器の属性一覧を作成
                {
                    var list = new List<string>();
                    var i = 0;
                    var wclass = selectedWeapon.WeaponClass();
                    while (i <= Strings.Len(wclass))
                    {
                        i = (i + 1);
                        var buf = GeneralLib.GetClassBundle(wclass, ref i);
                        var atype = "";
                        var alevel = "";

                        // 非表示？
                        if (buf == "|")
                        {
                            break;
                        }

                        // Ｍ属性
                        if (Strings.Mid(wclass, i, 1) == "Ｍ")
                        {
                            i = (i + 1);
                            buf = buf + Strings.Mid(wclass, i, 1);
                        }

                        // レベル指定
                        if (Strings.Mid(wclass, i + 1, 1) == "L")
                        {
                            i = (i + 2);
                            var c = Strings.Mid(wclass, i, 1);
                            while (Information.IsNumeric(c) || c == "." || c == "-")
                            {
                                alevel = alevel + c;
                                i = (i + 1);
                                c = Strings.Mid(wclass, i, 1);
                            }

                            i = (i - 1);
                        }

                        // 属性の名称
                        atype = Help.AttributeName(SelectedUnit, buf);
                        if (Strings.Len(atype) > 0)
                        {
                            if (Strings.Len(alevel) > 0)
                            {
                                list.Add(GeneralLib.RightPaddedString(buf + "L" + alevel, 8) + atype + "レベル" + alevel);
                            }
                            else
                            {
                                list.Add(GeneralLib.RightPaddedString(buf, 8) + atype);
                            }
                        }
                    }

                    if (!Map.IsStatusView)
                    {
                        list.Add("射程範囲");
                    }

                    if (list.Count > 0)
                    {
                        GUI.TopItem = 1;
                        while (true)
                        {
                            if (list.Count == 1 && list[0] == "射程範囲")
                            {
                                i = 1;
                            }
                            else
                            {
                                i = GUI.ListBox(new ListBoxArgs
                                {
                                    lb_caption = "アビリティ属性一覧",
                                    Items = list.Select(x => new ListBoxItem(x)).ToList(),
                                    lb_info = "属性    効果",
                                    lb_mode = "連続表示",
                                });
                            }

                            if (i == 0)
                            {
                                // キャンセル
                                break;
                            }
                            else if (list[i - 1] == "射程範囲")
                            {
                                GUI.CloseListBox();

                                // 武器の射程を求めておく
                                var min_range = selectedWeapon.WeaponMinRange();
                                var max_range = selectedWeapon.WeaponMaxRange();
                                // 射程範囲表示
                                if ((max_range == 1 || selectedWeapon.IsWeaponClassifiedAs("Ｐ")) && !selectedWeapon.IsWeaponClassifiedAs("Ｑ"))
                                {
                                    Map.AreaInReachable(SelectedUnit, max_range, u.Party + "の敵");
                                }
                                else if (selectedWeapon.IsWeaponClassifiedAs("Ｍ直"))
                                {
                                    Map.AreaInCross(u.x, u.y, min_range, max_range);
                                }
                                else if (selectedWeapon.IsWeaponClassifiedAs("Ｍ拡"))
                                {
                                    Map.AreaInWideCross(u.x, u.y, min_range, max_range);
                                }
                                else if (selectedWeapon.IsWeaponClassifiedAs("Ｍ扇"))
                                {
                                    Map.AreaInSectorCross(u.x, u.y, min_range, max_range, (int)selectedWeapon.WeaponLevel("Ｍ扇"));
                                }
                                else if (selectedWeapon.IsWeaponClassifiedAs("Ｍ全") || selectedWeapon.IsWeaponClassifiedAs("Ｍ線"))
                                {
                                    Map.AreaInRange(u.x, u.y, max_range, min_range, "すべて");
                                }
                                else if (selectedWeapon.IsWeaponClassifiedAs("Ｍ投"))
                                {
                                    max_range = ((int)(max_range + selectedWeapon.WeaponLevel("Ｍ投")));
                                    min_range = ((int)(min_range - selectedWeapon.WeaponLevel("Ｍ投")));
                                    min_range = GeneralLib.MaxLng(min_range, 1);
                                    Map.AreaInRange(u.x, u.y, max_range, min_range, "すべて");
                                }
                                else if (selectedWeapon.IsWeaponClassifiedAs("Ｍ移"))
                                {
                                    Map.AreaInMoveAction(SelectedUnit, max_range);
                                }
                                else
                                {
                                    Map.AreaInRange(u.x, u.y, max_range, min_range, u.Party + "の敵");
                                }

                                GUI.Center(u.x, u.y);
                                GUI.MaskScreen();

                                // 先行入力されていたクリックイベントを解消
                                GUI.DoEvents();
                                WaitClickMode = true;
                                GUI.IsFormClicked = false;

                                // クリックされるまで待つ
                                while (!GUI.IsFormClicked)
                                {
                                    GUI.Sleep(25);
                                    if (GUI.IsRButtonPressed(true))
                                    {
                                        break;
                                    }
                                }

                                GUI.RedrawScreen();
                                if (list.Count == 1)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                // 指定された属性の解説を表示
                                GUI.CloseListBox();
                                Help.AttributeHelp(SelectedUnit, GeneralLib.LIndex(list[i - 1], 1), selectedWeapon.WeaponNo());
                            }
                        }
                    }
                }
            }
        }

        // 「アビリティ一覧」コマンド
        private void AbilityListCommand()
        {
            LogDebug();

            GUI.LockGUI();
            while (true)
            {
                var currentAbility = GUI.AbilityListBox(SelectedUnit, new UnitAbilityList(AbilityListMode.List, SelectedUnit), Expression.Term("アビリティ", SelectedUnit) + "一覧", "一覧");
                if (currentAbility == null)
                {
                    SelectedAbility = 0;
                    // キャンセル
                    if (SRC.AutoMoveCursor)
                    {
                        GUI.RestoreCursorPos();
                    }

                    // TODO リストボックス消す
                    //My.MyProject.Forms.frmListBox.Hide();
                    GUI.UnlockGUI();
                    CommandState = "ユニット選択";
                    return;
                }

                SelectedAbility = currentAbility.AbilityNo();
                // 指定されたアビリティの属性一覧を作成
                {
                    var list = new List<string>();
                    var i = 0;
                    var u = SelectedUnit;
                    var aclass = currentAbility.Data.Class;
                    while (i <= Strings.Len(aclass))
                    {
                        i = (i + 1);
                        var buf = GeneralLib.GetClassBundle(aclass, ref i);
                        var atype = "";
                        var alevel = "";

                        // 非表示？
                        if (buf == "|")
                        {
                            break;
                        }

                        // Ｍ属性
                        if (Strings.Mid(aclass, i, 1) == "Ｍ")
                        {
                            i = (i + 1);
                            buf = buf + Strings.Mid(aclass, i, 1);
                        }

                        // レベル指定
                        if (Strings.Mid(aclass, i + 1, 1) == "L")
                        {
                            i = (i + 2);
                            var c = Strings.Mid(aclass, i, 1);
                            while (Information.IsNumeric(c) || c == "." || c == "-")
                            {
                                alevel = alevel + c;
                                i = (i + 1);
                                c = Strings.Mid(aclass, i, 1);
                            }

                            i = (i - 1);
                        }

                        // 属性の名称
                        atype = Help.AttributeName(SelectedUnit, buf);
                        if (Strings.Len(atype) > 0)
                        {
                            if (Strings.Len(alevel) > 0)
                            {
                                list.Add(GeneralLib.RightPaddedString(buf + "L" + alevel, 8) + atype + "レベル" + alevel);
                            }
                            else
                            {
                                list.Add(GeneralLib.RightPaddedString(buf, 8) + atype);
                            }
                        }
                    }

                    if (!Map.IsStatusView)
                    {
                        list.Add("射程範囲");
                    }

                    if (list.Count > 0)
                    {
                        GUI.TopItem = 1;
                        while (true)
                        {
                            if (list.Count == 1 && list[0] == "射程範囲")
                            {
                                i = 1;
                            }
                            else
                            {
                                i = GUI.ListBox(new ListBoxArgs
                                {
                                    lb_caption = "武器属性一覧",
                                    Items = list.Select(x => new ListBoxItem(x)).ToList(),
                                    lb_info = "属性    効果",
                                    lb_mode = "連続表示",
                                });
                            }

                            if (i == 0)
                            {
                                // キャンセル
                                break;
                            }
                            else if (list[i - 1] == "射程範囲")
                            {
                                GUI.CloseListBox();

                                // 武器の射程を求めておく
                                var min_range = currentAbility.AbilityMinRange();
                                var max_range = currentAbility.AbilityMaxRange();
                                // 射程範囲表示
                                if ((max_range == 1 || currentAbility.IsAbilityClassifiedAs("Ｐ")) && !currentAbility.IsAbilityClassifiedAs("Ｑ"))
                                {
                                    Map.AreaInReachable(SelectedUnit, max_range, u.Party + "の敵");
                                }
                                else if (currentAbility.IsAbilityClassifiedAs("Ｍ直"))
                                {
                                    Map.AreaInCross(u.x, u.y, min_range, max_range);
                                }
                                else if (currentAbility.IsAbilityClassifiedAs("Ｍ拡"))
                                {
                                    Map.AreaInWideCross(u.x, u.y, min_range, max_range);
                                }
                                else if (currentAbility.IsAbilityClassifiedAs("Ｍ扇"))
                                {
                                    Map.AreaInSectorCross(u.x, u.y, min_range, max_range, (int)currentAbility.AbilityLevel("Ｍ扇"));
                                }
                                else if (currentAbility.IsAbilityClassifiedAs("Ｍ全") || currentAbility.IsAbilityClassifiedAs("Ｍ線"))
                                {
                                    Map.AreaInRange(u.x, u.y, max_range, min_range, "すべて");
                                }
                                else if (currentAbility.IsAbilityClassifiedAs("Ｍ投"))
                                {
                                    max_range = ((int)(max_range + currentAbility.AbilityLevel("Ｍ投")));
                                    min_range = ((int)(min_range - currentAbility.AbilityLevel("Ｍ投")));
                                    min_range = GeneralLib.MaxLng(min_range, 1);
                                    Map.AreaInRange(u.x, u.y, max_range, min_range, "すべて");
                                }
                                else if (currentAbility.IsAbilityClassifiedAs("Ｍ移"))
                                {
                                    Map.AreaInMoveAction(SelectedUnit, max_range);
                                }
                                else
                                {
                                    Map.AreaInRange(u.x, u.y, max_range, min_range, u.Party + "の敵");
                                }

                                GUI.Center(u.x, u.y);
                                GUI.MaskScreen();

                                // 先行入力されていたクリックイベントを解消
                                GUI.DoEvents();
                                WaitClickMode = true;
                                GUI.IsFormClicked = false;

                                // クリックされるまで待つ
                                while (!GUI.IsFormClicked)
                                {
                                    GUI.Sleep(25);
                                    if (GUI.IsRButtonPressed(true))
                                    {
                                        break;
                                    }
                                }

                                GUI.RedrawScreen();
                                if (list.Count == 1)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                // 指定された属性の解説を表示
                                GUI.CloseListBox();
                                Help.AttributeHelp(SelectedUnit, GeneralLib.LIndex(list[i - 1], 1), currentAbility.AbilityNo());
                            }
                        }
                    }
                }
            }
        }

        // 「移動範囲」コマンド
        private void ShowAreaInSpeedCommand()
        {
            LogDebug();

            SelectedCommand = "移動範囲";
            //// If MainWidth <> 15 Then
            //if (GUI.NewGUIMode)
            //{
            //    // MOD END MARGE
            //    Status.ClearUnitStatus();
            //}

            Map.AreaInSpeed(SelectedUnit);
            GUI.Center(SelectedUnit.x, SelectedUnit.y);
            GUI.MaskScreen();
            CommandState = "ターゲット選択";
        }

        // 「射程範囲」コマンド
        private void ShowAreaInRangeCommand()
        {
            LogDebug();

            SelectedCommand = "射程範囲";

            //// If MainWidth <> 15 Then
            //if (GUI.NewGUIMode)
            //{
            //    // MOD END MARGE
            //    Status.ClearUnitStatus();
            //}

            {
                var currentUnit = SelectedUnit;
                // 最大の射程を持つ武器を探す
                var max_range = currentUnit.Weapons
                       .Where(uw => uw.IsWeaponAvailable("ステータス") && !uw.IsWeaponClassifiedAs("Ｍ"))
                       .Select(uw => uw.WeaponMaxRange())
                       .Append(0)
                       .Max();

                // 見つかった最大の射程を持つ武器の射程範囲を選択
                Map.AreaInRange(currentUnit.x, currentUnit.y, max_range, 1, currentUnit.Party + "の敵");

                // 射程範囲を表示
                GUI.Center(currentUnit.x, currentUnit.y);
                GUI.MaskScreen();
            }

            CommandState = "ターゲット選択";
        }
    }
}

﻿// Copyright (C) 1997-2012 Kei Sakamoto / Inui Tetsuyuki
// 本プログラムはフリーソフトであり、無保証です。
// 本プログラムはGNU General Public License(Ver.3またはそれ以降)が定める条件の下で
// 再頒布または改変することができます。
using SRCCore.Maps;
using SRCCore.Models;
using SRCCore.Pilots;
using SRCCore.VB;
using System.Collections.Generic;

namespace SRCCore.Units
{
    // === 武器関連処理 ===
    public partial class Unit
    {
        // 武器
        public WeaponData Weapon(short w)
        {
            WeaponData WeaponRet = default;
            WeaponRet = WData[w];
            return WeaponRet;
        }

        // 武器の総数
        public short CountWeapon()
        {
            short CountWeaponRet = default;
            CountWeaponRet = (short)Information.UBound(WData);
            return CountWeaponRet;
        }

        // 武器の愛称
        public string WeaponNickname(short w)
        {
            string WeaponNicknameRet = default;
            Unit u;

            // 愛称内の式置換のため、デフォルトユニットを一時的に変更する
            u = Event_Renamed.SelectedUnitForEvent;
            Event_Renamed.SelectedUnitForEvent = this;
            WeaponNicknameRet = WData[w].Nickname();
            Event_Renamed.SelectedUnitForEvent = u;
            return WeaponNicknameRet;
        }

        // 武器の攻撃力
        // tarea は敵のいる地形
        public int WeaponPower(short w, ref string tarea)
        {
            int WeaponPowerRet = default;
            int pat;
            // 攻撃補正一時保存
            double ed_atk;
            WeaponPowerRet = lngWeaponPower[w];

            // 「体」属性を持つ武器は残りＨＰに応じて攻撃力が増える
            string argattr1 = "体";
            if (IsWeaponClassifiedAs(w, ref argattr1))
            {
                string argattr = "体";
                WeaponPowerRet = (int)(WeaponPowerRet + HP / (double)MaxHP * 100d * WeaponLevel(w, ref argattr));
            }

            // 「尽」属性を持つ武器は残りＥＮに応じて攻撃力が増える
            string argattr3 = "尽";
            if (IsWeaponClassifiedAs(w, ref argattr3))
            {
                if (EN >= WeaponENConsumption(w))
                {
                    string argattr2 = "尽";
                    WeaponPowerRet = (int)(WeaponPowerRet + (EN - WeaponENConsumption(w)) * WeaponLevel(w, ref argattr2));
                }
            }

            // ダメージ固定武器
            double wad;
            string argattr5 = "固";
            if (IsWeaponClassifiedAs(w, ref argattr5))
            {

                // 武器一覧の場合は攻撃力をそのまま表示
                if (string.IsNullOrEmpty(tarea))
                {
                    return WeaponPowerRet;
                }

                // マップ攻撃は攻撃開始時に保存した攻撃力をそのまま使う
                string argattr4 = "Ｍ";
                if (IsWeaponClassifiedAs(w, ref argattr4))
                {
                    if (SelectedMapAttackPower > 0)
                    {
                        WeaponPowerRet = SelectedMapAttackPower;
                    }
                }

                // 地形適応による修正のみを適用
                wad = WeaponAdaption(w, ref tarea);

                // 地形適応修正繰り下げオプションの効果は適用しない
                string argoname1 = "地形適応修正繰り下げ";
                if (Expression.IsOptionDefined(ref argoname1))
                {
                    string argoname = "地形適応修正緩和";
                    if (Expression.IsOptionDefined(ref argoname))
                    {
                        wad = wad + 0.1d;
                    }
                    else
                    {
                        wad = wad + 0.2d;
                    }
                }

                // 地形適応がＡの場合に攻撃力と同じダメージを与えるようにする
                string argoname2 = "地形適応修正緩和";
                if (Expression.IsOptionDefined(ref argoname2))
                {
                    wad = wad - 0.1d;
                }
                else
                {
                    wad = wad - 0.2d;
                }

                if (wad > 0d)
                {
                    WeaponPowerRet = (int)(WeaponPowerRet * wad);
                }
                else
                {
                    WeaponPowerRet = 0;
                }

                return WeaponPowerRet;
            }

            // 部隊ユニットはダメージを受けると攻撃力が低下
            string argfname = "部隊ユニット";
            if (IsFeatureAvailable(ref argfname))
            {
                WeaponPowerRet = (int)((long)(WeaponPowerRet * (50d + 50 * HP / (double)MaxHP)) / 100L);
            }

            // 標的のいる地形が設定されていないときは武器の一覧表示用なので各種補正を省く
            if (string.IsNullOrEmpty(tarea))
            {
                return WeaponPowerRet;
            }

            {
                var withBlock = MainPilot();
                object argIndex2 = "攻撃補正";
                if (SRC.BCList.IsDefined(ref argIndex2))
                {
                    // バトルコンフィグデータの設定による修正
                    string argattr6 = "複";
                    string argattr7 = "格闘系";
                    if (IsWeaponClassifiedAs(w, ref argattr6))
                    {
                        pat = (withBlock.Infight + withBlock.Shooting) / 2;
                    }
                    else if (IsWeaponClassifiedAs(w, ref argattr7))
                    {
                        pat = withBlock.Infight;
                    }
                    else
                    {
                        pat = withBlock.Shooting;
                    }

                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = this;
                    BCVariable.AtkUnit = this;
                    // UPGRADE_NOTE: オブジェクト BCVariable.DefUnit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                    BCVariable.DefUnit = null;
                    BCVariable.WeaponNumber = w;
                    BCVariable.AttackExp = pat;
                    BCVariable.WeaponPower = WeaponPowerRet;
                    string argIndex1 = "攻撃補正";
                    WeaponPowerRet = (int)SRC.BCList.Item(ref argIndex1).Calculate();
                }
                else
                {
                    // パイロットの攻撃力による修正

                    string argattr8 = "複";
                    string argattr9 = "格闘系";
                    if (IsWeaponClassifiedAs(w, ref argattr8))
                    {
                        WeaponPowerRet = WeaponPowerRet * (withBlock.Infight + withBlock.Shooting) / 200;
                    }
                    else if (IsWeaponClassifiedAs(w, ref argattr9))
                    {
                        WeaponPowerRet = WeaponPowerRet * withBlock.Infight / 100;
                    }
                    else
                    {
                        WeaponPowerRet = WeaponPowerRet * withBlock.Shooting / 100;
                    }

                    // 気力による修正
                    string argoname3 = "気力効果小";
                    if (Expression.IsOptionDefined(ref argoname3))
                    {
                        WeaponPowerRet = WeaponPowerRet * (50 + (withBlock.Morale + withBlock.MoraleMod) / 2) / 100;
                    }
                    else
                    {
                        WeaponPowerRet = WeaponPowerRet * (withBlock.Morale + withBlock.MoraleMod) / 100;
                    }
                }

                // 覚悟
                if (HP <= MaxHP / 4)
                {
                    string argsname = "覚悟";
                    if (withBlock.IsSkillAvailable(ref argsname))
                    {
                        string argoname4 = "ダメージ倍率低下";
                        if (Expression.IsOptionDefined(ref argoname4))
                        {
                            WeaponPowerRet = (int)(1.1d * WeaponPowerRet);
                        }
                        else
                        {
                            WeaponPowerRet = (int)(1.2d * WeaponPowerRet);
                        }
                    }
                }
            }

            // マップ攻撃用に攻撃力算出
            if (tarea == "初期値")
            {
                return WeaponPowerRet;
            }

            // マップ攻撃は攻撃開始時に保存した攻撃力をそのまま使う
            string argattr10 = "Ｍ";
            if (IsWeaponClassifiedAs(w, ref argattr10))
            {
                if (SelectedMapAttackPower > 0)
                {
                    WeaponPowerRet = SelectedMapAttackPower;
                }
            }

            // 地形補正
            object argIndex4 = "攻撃地形補正";
            if (SRC.BCList.IsDefined(ref argIndex4))
            {
                // 事前にデータを登録
                BCVariable.DataReset();
                BCVariable.MeUnit = this;
                BCVariable.AtkUnit = this;
                // UPGRADE_NOTE: オブジェクト BCVariable.DefUnit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                BCVariable.DefUnit = null;
                BCVariable.WeaponNumber = w;
                BCVariable.AttackExp = WeaponPowerRet;
                BCVariable.TerrainAdaption = WeaponAdaption(w, ref tarea);
                string argIndex3 = "攻撃地形補正";
                WeaponPowerRet = (int)SRC.BCList.Item(ref argIndex3).Calculate();
            }
            else
            {
                WeaponPowerRet = (int)(WeaponPowerRet * WeaponAdaption(w, ref tarea));
            }

            return WeaponPowerRet;
        }

        // 武器 w の地形 tarea におけるダメージ修正値
        public double WeaponAdaption(short w, ref string tarea)
        {
            double WeaponAdaptionRet = default;
            short wad = default, uad, xad;
            short ind;

            // 武器の地形適応値の計算に使用する適応値を決定
            switch (tarea ?? "")
            {
                case "空中":
                    {
                        ind = 1;
                        break;
                    }

                case "地上":
                    {
                        if (Map.TerrainClass(x, y) == "月面")
                        {
                            ind = 4;
                        }
                        else
                        {
                            ind = 2;
                        }

                        break;
                    }

                case "水上":
                    {
                        if (Strings.Mid(Weapon(w).Adaption, 3, 1) == "A")
                        {
                            ind = 3;
                        }
                        else
                        {
                            ind = 2;
                        }

                        break;
                    }

                case "水中":
                    {
                        ind = 3;
                        break;
                    }

                case "宇宙":
                    {
                        ind = 4;
                        break;
                    }

                case "地中":
                    {
                        WeaponAdaptionRet = 0d;
                        return WeaponAdaptionRet;
                    }

                default:
                    {
                        xad = 4;
                        goto CalcAdaption;
                        break;
                    }
            }

            // 武器の地形適応値
            switch (Strings.Mid(Weapon(w).Adaption, ind, 1) ?? "")
            {
                case "S":
                    {
                        wad = 5;
                        break;
                    }

                case "A":
                    {
                        wad = 4;
                        break;
                    }

                case "B":
                    {
                        wad = 3;
                        break;
                    }

                case "C":
                    {
                        wad = 2;
                        break;
                    }

                case "D":
                    {
                        wad = 1;
                        break;
                    }

                case "-":
                    {
                        WeaponAdaptionRet = 0d;
                        return WeaponAdaptionRet;
                    }
            }

            // ユニットの地形適応値の計算に使用する適応値を決定
            string argattr4 = "武";
            string argattr5 = "突";
            string argattr6 = "接";
            if (!IsWeaponClassifiedAs(w, ref argattr4) & !IsWeaponClassifiedAs(w, ref argattr5) & !IsWeaponClassifiedAs(w, ref argattr6))
            {
                // 格闘戦以外の場合はユニットがいる地形を参照
                switch (Area ?? "")
                {
                    case "空中":
                        {
                            ind = 1;
                            break;
                        }

                    case "地上":
                        {
                            if (Map.TerrainClass(x, y) == "月面")
                            {
                                ind = 4;
                            }
                            else
                            {
                                ind = 2;
                            }

                            break;
                        }

                    case "水上":
                        {
                            ind = 2;
                            break;
                        }

                    case "水中":
                        {
                            ind = 3;
                            break;
                        }

                    case "宇宙":
                        {
                            ind = 4;
                            break;
                        }

                    case "地中":
                        {
                            WeaponAdaptionRet = 0d;
                            return WeaponAdaptionRet;
                        }
                }
                // ユニットの地形適応値
                uad = get_Adaption(ind);
            }
            else
            {
                // 格闘戦の場合はターゲットがいる地形を参照
                switch (tarea ?? "")
                {
                    case "空中":
                        {
                            uad = get_Adaption(1);
                            // ジャンプ攻撃
                            string argattr1 = "Ｊ";
                            if (IsWeaponClassifiedAs(w, ref argattr1))
                            {
                                string argattr = "Ｊ";
                                uad = (short)(uad + WeaponLevel(w, ref argattr));
                            }

                            break;
                        }

                    case "地上":
                        {
                            if (get_Adaption(2) > 0)
                            {
                                uad = get_Adaption(2);
                            }
                            else
                            {
                                // 空中専用ユニットが地上のユニットに格闘戦をしかけられるようにする
                                uad = (short)GeneralLib.MaxLng(get_Adaption(1) - 1, 0);
                            }

                            break;
                        }

                    case "水上":
                        {
                            // 水中専用ユニットが水上のユニットに格闘戦をしかけられるようにする
                            uad = (short)GeneralLib.MaxDbl(get_Adaption(2), get_Adaption(3));
                            if (uad <= 0)
                            {
                                // 空中専用ユニットが地上のユニットに格闘戦をしかけられるようにする
                                uad = (short)GeneralLib.MaxLng(get_Adaption(1) - 1, 0);
                            }

                            break;
                        }

                    case "水中":
                        {
                            uad = get_Adaption(3);
                            break;
                        }

                    case "宇宙":
                        {
                            uad = get_Adaption(4);
                            if (Area == "地上" & Map.TerrainClass(x, y) == "月面")
                            {
                                // 月面からのジャンプ攻撃
                                string argattr3 = "Ｊ";
                                if (IsWeaponClassifiedAs(w, ref argattr3))
                                {
                                    string argattr2 = "Ｊ";
                                    uad = (short)(uad + WeaponLevel(w, ref argattr2));
                                }
                            }

                            break;
                        }

                    default:
                        {
                            uad = get_Adaption(ind);
                            break;
                        }
                }
            }

            // 地形適応が命中率に適応される場合、ユニットの地形適応は攻撃可否の判定にのみ用いる
            string argoname = "地形適応命中率修正";
            if (Expression.IsOptionDefined(ref argoname))
            {
                if (uad > 0)
                {
                    xad = wad;
                    goto CalcAdaption;
                }
                else
                {
                    WeaponAdaptionRet = 0d;
                    return WeaponAdaptionRet;
                }
            }

            // 武器側とユニット側の地形適応の低い方を優先
            if (uad > wad)
            {
                xad = wad;
            }
            else
            {
                xad = uad;
            }

        CalcAdaption:
            ;


            // Optionコマンドの設定に従って地形適応値を算出
            string argoname3 = "地形適応修正緩和";
            if (Expression.IsOptionDefined(ref argoname3))
            {
                string argoname1 = "地形適応修正繰り下げ";
                if (Expression.IsOptionDefined(ref argoname1))
                {
                    switch (xad)
                    {
                        case 5:
                            {
                                WeaponAdaptionRet = 1.1d;
                                break;
                            }

                        case 4:
                            {
                                WeaponAdaptionRet = 1d;
                                break;
                            }

                        case 3:
                            {
                                WeaponAdaptionRet = 0.9d;
                                break;
                            }

                        case 2:
                            {
                                WeaponAdaptionRet = 0.8d;
                                break;
                            }

                        case 1:
                            {
                                WeaponAdaptionRet = 0.7d;
                                break;
                            }

                        default:
                            {
                                WeaponAdaptionRet = 0d;
                                break;
                            }
                    }
                }
                else
                {
                    switch (xad)
                    {
                        case 5:
                            {
                                WeaponAdaptionRet = 1.2d;
                                break;
                            }

                        case 4:
                            {
                                WeaponAdaptionRet = 1.1d;
                                break;
                            }

                        case 3:
                            {
                                WeaponAdaptionRet = 1d;
                                break;
                            }

                        case 2:
                            {
                                WeaponAdaptionRet = 0.9d;
                                break;
                            }

                        case 1:
                            {
                                WeaponAdaptionRet = 0.8d;
                                break;
                            }

                        default:
                            {
                                WeaponAdaptionRet = 0d;
                                break;
                            }
                    }
                }
            }
            else
            {
                string argoname2 = "地形適応修正繰り下げ";
                if (Expression.IsOptionDefined(ref argoname2))
                {
                    switch (xad)
                    {
                        case 5:
                            {
                                WeaponAdaptionRet = 1.2d;
                                break;
                            }

                        case 4:
                            {
                                WeaponAdaptionRet = 1d;
                                break;
                            }

                        case 3:
                            {
                                WeaponAdaptionRet = 0.8d;
                                break;
                            }

                        case 2:
                            {
                                WeaponAdaptionRet = 0.6d;
                                break;
                            }

                        case 1:
                            {
                                WeaponAdaptionRet = 0.4d;
                                break;
                            }

                        default:
                            {
                                WeaponAdaptionRet = 0d;
                                break;
                            }
                    }
                }
                else
                {
                    switch (xad)
                    {
                        case 5:
                            {
                                WeaponAdaptionRet = 1.4d;
                                break;
                            }

                        case 4:
                            {
                                WeaponAdaptionRet = 1.2d;
                                break;
                            }

                        case 3:
                            {
                                WeaponAdaptionRet = 1d;
                                break;
                            }

                        case 2:
                            {
                                WeaponAdaptionRet = 0.8d;
                                break;
                            }

                        case 1:
                            {
                                WeaponAdaptionRet = 0.6d;
                                break;
                            }

                        default:
                            {
                                WeaponAdaptionRet = 0d;
                                break;
                            }
                    }
                }
            }

            return WeaponAdaptionRet;
        }

        // 武器 w の最大射程
        public short WeaponMaxRange(short w)
        {
            short WeaponMaxRangeRet = default;
            WeaponMaxRangeRet = intWeaponMaxRange[w];

            // 最大射程がもともと１ならそれ以上変化しない
            if (WeaponMaxRangeRet == 1)
            {
                return WeaponMaxRangeRet;
            }

            // マップ攻撃には適用されない
            string argattr = "Ｍ";
            if (IsWeaponClassifiedAs(w, ref argattr))
            {
                return WeaponMaxRangeRet;
            }

            // 接近戦武器には適用されない
            string argattr1 = "武";
            string argattr2 = "突";
            string argattr3 = "接";
            if (IsWeaponClassifiedAs(w, ref argattr1) | IsWeaponClassifiedAs(w, ref argattr2) | IsWeaponClassifiedAs(w, ref argattr3))
            {
                return WeaponMaxRangeRet;
            }

            // 有線式誘導攻撃には適用されない
            string argattr4 = "有";
            if (IsWeaponClassifiedAs(w, ref argattr4))
            {
                return WeaponMaxRangeRet;
            }

            // スペシャルパワーによる射程延長
            string argsptype = "射程延長";
            if (IsUnderSpecialPowerEffect(ref argsptype))
            {
                string argsname = "射程延長";
                WeaponMaxRangeRet = (short)(WeaponMaxRangeRet + SpecialPowerEffectLevel(ref argsname));
            }

            return WeaponMaxRangeRet;
        }

        // 武器 w の消費ＥＮ
        public short WeaponENConsumption(short w)
        {
            short WeaponENConsumptionRet = default;
            // UPGRADE_NOTE: rate は rate_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
            double rate_Renamed;
            short i;
            {
                var withBlock = Weapon(w);
                WeaponENConsumptionRet = withBlock.ENConsumption;

                // パイロットの能力によって術及び技の消費ＥＮは減少する
                if (CountPilot() > 0)
                {
                    // 術に該当するか？
                    if (IsSpellWeapon(w))
                    {
                        // 術に該当する場合は術技能によってＥＮ消費量を変える
                        object argIndex1 = "術";
                        string argref_mode = "";
                        switch (MainPilot().SkillLevel(ref argIndex1, ref_mode: ref argref_mode))
                        {
                            case 1d:
                                {
                                    break;
                                }

                            case 2d:
                                {
                                    WeaponENConsumptionRet = (short)(0.9d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 3d:
                                {
                                    WeaponENConsumptionRet = (short)(0.8d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 4d:
                                {
                                    WeaponENConsumptionRet = (short)(0.7d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 5d:
                                {
                                    WeaponENConsumptionRet = (short)(0.6d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 6d:
                                {
                                    WeaponENConsumptionRet = (short)(0.5d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 7d:
                                {
                                    WeaponENConsumptionRet = (short)(0.45d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 8d:
                                {
                                    WeaponENConsumptionRet = (short)(0.4d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 9d:
                                {
                                    WeaponENConsumptionRet = (short)(0.35d * WeaponENConsumptionRet);
                                    break;
                                }

                            case var @case when @case >= 10d:
                                {
                                    WeaponENConsumptionRet = (short)(0.3d * WeaponENConsumptionRet);
                                    break;
                                }
                        }

                        WeaponENConsumptionRet = (short)GeneralLib.MinLng(GeneralLib.MaxLng(WeaponENConsumptionRet, 5), withBlock.ENConsumption);
                    }

                    // 技に該当するか？
                    if (IsFeatWeapon(w))
                    {
                        // 技に該当する場合は技技能によってＥＮ消費量を変える
                        object argIndex2 = "技";
                        string argref_mode1 = "";
                        switch (MainPilot().SkillLevel(ref argIndex2, ref_mode: ref argref_mode1))
                        {
                            case 1d:
                                {
                                    break;
                                }

                            case 2d:
                                {
                                    WeaponENConsumptionRet = (short)(0.9d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 3d:
                                {
                                    WeaponENConsumptionRet = (short)(0.8d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 4d:
                                {
                                    WeaponENConsumptionRet = (short)(0.7d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 5d:
                                {
                                    WeaponENConsumptionRet = (short)(0.6d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 6d:
                                {
                                    WeaponENConsumptionRet = (short)(0.5d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 7d:
                                {
                                    WeaponENConsumptionRet = (short)(0.45d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 8d:
                                {
                                    WeaponENConsumptionRet = (short)(0.4d * WeaponENConsumptionRet);
                                    break;
                                }

                            case 9d:
                                {
                                    WeaponENConsumptionRet = (short)(0.35d * WeaponENConsumptionRet);
                                    break;
                                }

                            case var case1 when case1 >= 10d:
                                {
                                    WeaponENConsumptionRet = (short)(0.3d * WeaponENConsumptionRet);
                                    break;
                                }
                        }

                        WeaponENConsumptionRet = (short)GeneralLib.MinLng(GeneralLib.MaxLng(WeaponENConsumptionRet, 5), withBlock.ENConsumption);
                    }
                }

                // ＥＮ消費減少能力による修正
                rate_Renamed = 1d;
                string argfname = "ＥＮ消費減少";
                if (IsFeatureAvailable(ref argfname))
                {
                    var loopTo = CountFeature();
                    for (i = 1; i <= loopTo; i++)
                    {
                        object argIndex3 = i;
                        if (Feature(ref argIndex3) == "ＥＮ消費減少")
                        {
                            double localFeatureLevel() { object argIndex1 = i; var ret = FeatureLevel(ref argIndex1); return ret; }

                            rate_Renamed = rate_Renamed - 0.1d * localFeatureLevel();
                        }
                    }
                }

                if (rate_Renamed < 0.1d)
                {
                    rate_Renamed = 0.1d;
                }

                WeaponENConsumptionRet = (short)(rate_Renamed * WeaponENConsumptionRet);
            }

            return WeaponENConsumptionRet;
        }

        // 武器 w の命中率
        public short WeaponPrecision(short w)
        {
            short WeaponPrecisionRet = default;
            WeaponPrecisionRet = intWeaponPrecision[w];
            return WeaponPrecisionRet;
        }

        // 武器 w のＣＴ率
        public short WeaponCritical(short w)
        {
            short WeaponCriticalRet = default;
            WeaponCriticalRet = intWeaponCritical[w];
            return WeaponCriticalRet;
        }

        // 武器 w の属性
        public string WeaponClass(short w)
        {
            string WeaponClassRet = default;
            WeaponClassRet = strWeaponClass[w];
            return WeaponClassRet;
        }

        // 武器 w が武器属性 attr を持っているかどうか
        public bool IsWeaponClassifiedAs(short w, ref string attr)
        {
            bool IsWeaponClassifiedAsRet = default;
            string wclass;
            wclass = strWeaponClass[w];

            // 属性が２文字以下ならそのまま判定
            if (Strings.Len(attr) <= 2)
            {
                if (GeneralLib.InStrNotNest(ref wclass, ref attr) > 0)
                {
                    IsWeaponClassifiedAsRet = true;
                }
                else
                {
                    IsWeaponClassifiedAsRet = false;
                }

                return IsWeaponClassifiedAsRet;
            }

            // 属性の頭文字が弱攻剋ならそのまま判定
            if (Strings.InStr("弱効剋", Strings.Left(attr, 1)) > 0)
            {
                if (GeneralLib.InStrNotNest(ref wclass, ref attr) > 0)
                {
                    IsWeaponClassifiedAsRet = true;
                }
                else
                {
                    IsWeaponClassifiedAsRet = false;
                }

                return IsWeaponClassifiedAsRet;
            }

            // 条件が複雑な場合
            switch (attr ?? "")
            {
                case "格闘系":
                    {
                        string argstring2 = "格";
                        string argstring21 = "射";
                        if (GeneralLib.InStrNotNest(ref wclass, ref argstring2) > 0)
                        {
                            IsWeaponClassifiedAsRet = true;
                        }
                        else if (GeneralLib.InStrNotNest(ref wclass, ref argstring21) > 0)
                        {
                            IsWeaponClassifiedAsRet = false;
                        }
                        else if (this.Weapon(w).MaxRange == 1)
                        {
                            IsWeaponClassifiedAsRet = true;
                        }
                        else
                        {
                            IsWeaponClassifiedAsRet = false;
                        }

                        return IsWeaponClassifiedAsRet;
                    }

                case "射撃系":
                    {
                        string argstring22 = "格";
                        string argstring23 = "射";
                        if (GeneralLib.InStrNotNest(ref wclass, ref argstring22) > 0)
                        {
                            IsWeaponClassifiedAsRet = false;
                        }
                        else if (GeneralLib.InStrNotNest(ref wclass, ref argstring23) > 0)
                        {
                            IsWeaponClassifiedAsRet = true;
                        }
                        else if (this.Weapon(w).MaxRange == 1)
                        {
                            IsWeaponClassifiedAsRet = false;
                        }
                        else
                        {
                            IsWeaponClassifiedAsRet = true;
                        }

                        break;
                    }

                case "移動後攻撃可":
                    {
                        string argsptype = "全武器移動後使用可能";
                        string argstring25 = "Ｍ";
                        string argstring26 = "Ｑ";
                        string argstring27 = "Ｐ";
                        if (IsUnderSpecialPowerEffect(ref argsptype) & GeneralLib.InStrNotNest(ref wclass, ref argstring25) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring26) == 0)
                        {
                            IsWeaponClassifiedAsRet = true;
                        }
                        else if (this.Weapon(w).MaxRange == 1)
                        {
                            string argstring24 = "Ｑ";
                            if (GeneralLib.InStrNotNest(ref wclass, ref argstring24) == 0)
                            {
                                IsWeaponClassifiedAsRet = true;
                            }
                            else
                            {
                                IsWeaponClassifiedAsRet = false;
                            }
                        }
                        else if (GeneralLib.InStrNotNest(ref wclass, ref argstring27) > 0)
                        {
                            IsWeaponClassifiedAsRet = true;
                        }

                        break;
                    }
            }

            return IsWeaponClassifiedAsRet;
        }

        // 武器 w の属性 attr におけるレベル
        public double WeaponLevel(short w, ref string attr)
        {
            double WeaponLevelRet = default;
            string attrlv, wclass;
            short start_idx, i;
            string c;
            ;
#error Cannot convert OnErrorGoToStatementSyntax - see comment for details
            /* Cannot convert OnErrorGoToStatementSyntax, CONVERSION ERROR: Conversion for OnErrorGoToLabelStatement not implemented, please report this issue in 'On Error GoTo ErrorHandler' at character 164587


            Input:

                    On Error GoTo ErrorHandler

             */
            attrlv = attr + "L";

            // 武器属性を調べてみる
            wclass = strWeaponClass[w];

            // レベル指定があるか？
            start_idx = GeneralLib.InStrNotNest(ref wclass, ref attrlv);
            if (start_idx == 0)
            {
                return WeaponLevelRet;
            }

            // レベル指定部分の切り出し
            start_idx = (short)(start_idx + Strings.Len(attrlv));
            i = start_idx;
            while (true)
            {
                c = Strings.Mid(wclass, i, 1);
                if (string.IsNullOrEmpty(c))
                {
                    break;
                }

                switch (Strings.Asc(c))
                {
                    case var @case when 45 <= @case && @case <= 46:
                    case var case1 when 48 <= case1 && case1 <= 57: // "-", ".", 0-9
                        {
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }

                i = (short)(i + 1);
            }

            WeaponLevelRet = Conversions.ToDouble(Strings.Mid(wclass, start_idx, i - start_idx));
            return WeaponLevelRet;
        ErrorHandler:
            ;
            string argmsg = Name + "の" + "武装「" + Weapon(w).Name + "」の" + "属性「" + attr + "」のレベル指定が不正です";
            GUI.ErrorMessage(ref argmsg);
        }

        // 武器 w の属性 attr にレベル指定がなされているか
        public bool IsWeaponLevelSpecified(short w, ref string attr)
        {
            bool IsWeaponLevelSpecifiedRet = default;
            if (Strings.InStr(strWeaponClass[w], attr + "L") > 0)
            {
                IsWeaponLevelSpecifiedRet = true;
                return IsWeaponLevelSpecifiedRet;
            }

            return IsWeaponLevelSpecifiedRet;
        }

        // 武器 w が通常武器かどうか
        public bool IsNormalWeapon(short w)
        {
            bool IsNormalWeaponRet = default;
            short i;
            string wclass;
            short ret;

            // 特殊効果属性を持つ？
            wclass = strWeaponClass[w];
            var loopTo = (short)Strings.Len(wclass);
            for (i = 1; i <= loopTo; i++)
            {
                ret = (short)Strings.InStr("Ｓ縛劣中石凍痺眠乱魅恐踊狂ゾ害憑盲毒撹不止黙除即告脱Ｄ低吹Ｋ引転衰滅盗習写化弱効剋", Strings.Mid(wclass, i, 1));
                if (ret > 0)
                {
                    return IsNormalWeaponRet;
                }
            }

            IsNormalWeaponRet = true;
            return IsNormalWeaponRet;
        }

        // 武器が持つ特殊効果の数を返す
        public short CountWeaponEffect(short w)
        {
            short CountWeaponEffectRet = default;
            string wclass, wattr;
            short i, ret;
            wclass = strWeaponClass[w];
            var loopTo = (short)Strings.Len(wclass);
            for (i = 1; i <= loopTo; i++)
            {
                // 弱Ｓのような入れ子があれば、入れ子の分カウントを進める
                wattr = GeneralLib.GetClassBundle(ref wclass, ref i, 1);

                // 非表示部分は無視
                if (wattr == "|")
                {
                    break;
                }

                // ＣＴ時発動系
                ret = (short)Strings.InStr("Ｓ縛劣中石凍痺眠乱魅恐踊狂ゾ害憑盲毒撹不止黙除即告脱Ｄ低吹Ｋ引転衰滅盗習写化弱効剋", wattr);
                if (ret > 0)
                {
                    CountWeaponEffectRet = (short)(CountWeaponEffectRet + 1);
                }

                // それ以外
                ret = (short)Strings.InStr("先再忍貫固殺無浸破間浄吸減奪", wattr);
                if (ret > 0)
                {
                    CountWeaponEffectRet = (short)(CountWeaponEffectRet + 1);
                }
            }

            return CountWeaponEffectRet;
        }

        // 武器 w が術かどうか
        public bool IsSpellWeapon(short w)
        {
            bool IsSpellWeaponRet = default;
            short i;
            string nskill;
            string argattr = "術";
            if (IsWeaponClassifiedAs(w, ref argattr))
            {
                IsSpellWeaponRet = true;
                return IsSpellWeaponRet;
            }

            {
                var withBlock = MainPilot();
                var loopTo = GeneralLib.LLength(ref Weapon(w).NecessarySkill);
                for (i = 1; i <= loopTo; i++)
                {
                    nskill = GeneralLib.LIndex(ref Weapon(w).NecessarySkill, i);
                    if (Strings.InStr(nskill, "Lv") > 0)
                    {
                        nskill = Strings.Left(nskill, Strings.InStr(nskill, "Lv") - 1);
                    }

                    if (withBlock.SkillType(ref nskill) == "術")
                    {
                        IsSpellWeaponRet = true;
                        return IsSpellWeaponRet;
                    }
                }
            }

            return IsSpellWeaponRet;
        }

        // 武器 w が技かどうか
        public bool IsFeatWeapon(short w)
        {
            bool IsFeatWeaponRet = default;
            short i;
            string nskill;
            string argattr = "技";
            if (IsWeaponClassifiedAs(w, ref argattr))
            {
                IsFeatWeaponRet = true;
                return IsFeatWeaponRet;
            }

            {
                var withBlock = MainPilot();
                var loopTo = GeneralLib.LLength(ref Weapon(w).NecessarySkill);
                for (i = 1; i <= loopTo; i++)
                {
                    nskill = GeneralLib.LIndex(ref Weapon(w).NecessarySkill, i);
                    if (Strings.InStr(nskill, "Lv") > 0)
                    {
                        nskill = Strings.Left(nskill, Strings.InStr(nskill, "Lv") - 1);
                    }

                    if (withBlock.SkillType(ref nskill) == "技")
                    {
                        IsFeatWeaponRet = true;
                        return IsFeatWeaponRet;
                    }
                }
            }

            return IsFeatWeaponRet;
        }

        // 武器 w が使用可能かどうか
        // ref_mode はユニットの状態（移動前、移動後）を示す
        public bool IsWeaponAvailable(short w, ref string ref_mode)
        {
            bool IsWeaponAvailableRet = default;
            short i;
            WeaponData wd;
            string wclass;
            IsWeaponAvailableRet = false;

            // ADD START MARGE
            // 武器が取得できない場合はFalse（防御や無抵抗の場合、wが0や-1になる）
            if (!(w > 0))
            {
                return IsWeaponAvailableRet;
            }
            // ADD END MARGE

            wd = Weapon(w);
            wclass = WeaponClass(w);

            // イベントコマンド「Disable」で封印されている？
            if (IsDisabled(ref wd.Name))
            {
                return IsWeaponAvailableRet;
            }

            // パイロットが乗っていなければ常に使用可能と判定
            if (CountPilot() == 0)
            {
                IsWeaponAvailableRet = true;
                return IsWeaponAvailableRet;
            }

            // 必要技能＆必要条件
            if (ref_mode != "必要技能無視")
            {
                if (!IsWeaponMastered(w))
                {
                    return IsWeaponAvailableRet;
                }

                if (!IsWeaponEnabled(w))
                {
                    return IsWeaponAvailableRet;
                }
            }

            // ステータス表示では必要技能だけ満たしていればＯＫ
            if (ref_mode == "インターミッション" | string.IsNullOrEmpty(ref_mode))
            {
                IsWeaponAvailableRet = true;
                return IsWeaponAvailableRet;
            }

            {
                var withBlock = MainPilot();
                // 必要気力
                if (wd.NecessaryMorale > 0)
                {
                    if (withBlock.Morale < wd.NecessaryMorale)
                    {
                        return IsWeaponAvailableRet;
                    }
                }

                // 霊力消費攻撃
                string argstring2 = "霊";
                string argstring21 = "プ";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring2) > 0)
                {
                    string argattr = "霊";
                    if (withBlock.Plana < WeaponLevel(w, ref argattr) * 5d)
                    {
                        return IsWeaponAvailableRet;
                    }
                }
                else if (GeneralLib.InStrNotNest(ref wclass, ref argstring21) > 0)
                {
                    string argattr1 = "プ";
                    if (withBlock.Plana < WeaponLevel(w, ref argattr1) * 5d)
                    {
                        return IsWeaponAvailableRet;
                    }
                }
            }

            // 属性使用不能状態
            object argIndex1 = "オーラ使用不能";
            if (ConditionLifetime(ref argIndex1) > 0)
            {
                string argattr2 = "オ";
                if (IsWeaponClassifiedAs(w, ref argattr2))
                {
                    return IsWeaponAvailableRet;
                }
            }

            object argIndex2 = "超能力使用不能";
            if (ConditionLifetime(ref argIndex2) > 0)
            {
                string argattr3 = "超";
                if (IsWeaponClassifiedAs(w, ref argattr3))
                {
                    return IsWeaponAvailableRet;
                }
            }

            object argIndex3 = "同調率使用不能";
            if (ConditionLifetime(ref argIndex3) > 0)
            {
                string argattr4 = "シ";
                if (IsWeaponClassifiedAs(w, ref argattr4))
                {
                    return IsWeaponAvailableRet;
                }
            }

            object argIndex4 = "超感覚使用不能";
            if (ConditionLifetime(ref argIndex4) > 0)
            {
                string argattr5 = "サ";
                if (IsWeaponClassifiedAs(w, ref argattr5))
                {
                    return IsWeaponAvailableRet;
                }
            }

            object argIndex5 = "知覚強化使用不能";
            if (ConditionLifetime(ref argIndex5) > 0)
            {
                string argattr6 = "サ";
                if (IsWeaponClassifiedAs(w, ref argattr6))
                {
                    return IsWeaponAvailableRet;
                }
            }

            object argIndex6 = "霊力使用不能";
            if (ConditionLifetime(ref argIndex6) > 0)
            {
                string argattr7 = "霊";
                if (IsWeaponClassifiedAs(w, ref argattr7))
                {
                    return IsWeaponAvailableRet;
                }
            }

            object argIndex7 = "術使用不能";
            if (ConditionLifetime(ref argIndex7) > 0)
            {
                string argattr8 = "術";
                if (IsWeaponClassifiedAs(w, ref argattr8))
                {
                    return IsWeaponAvailableRet;
                }
            }

            object argIndex8 = "技使用不能";
            if (ConditionLifetime(ref argIndex8) > 0)
            {
                string argattr9 = "技";
                if (IsWeaponClassifiedAs(w, ref argattr9))
                {
                    return IsWeaponAvailableRet;
                }
            }

            var loopTo = CountCondition();
            for (i = 1; i <= loopTo; i++)
            {
                string localCondition3() { object argIndex1 = i; var ret = Condition(ref argIndex1); return ret; }

                if (Strings.Len(localCondition3()) > 6)
                {
                    string localCondition2() { object argIndex1 = i; var ret = Condition(ref argIndex1); return ret; }

                    if (Strings.Right(localCondition2(), 6) == "属性使用不能")
                    {
                        string localCondition() { object argIndex1 = i; var ret = Condition(ref argIndex1); return ret; }

                        string localCondition1() { object argIndex1 = i; var ret = Condition(ref argIndex1); return ret; }

                        string argstring1 = WeaponClass(w);
                        string argstring22 = Strings.Left(localCondition(), Strings.Len(localCondition1()) - 6);
                        if (GeneralLib.InStrNotNest(ref argstring1, ref argstring22) > 0)
                        {
                            return IsWeaponAvailableRet;
                        }
                    }
                }
            }

            // 弾数が足りるか
            if (wd.Bullet > 0)
            {
                if (Bullet(w) < 1)
                {
                    return IsWeaponAvailableRet;
                }
            }

            // ＥＮが足りるか
            if (wd.ENConsumption > 0)
            {
                if (EN < WeaponENConsumption(w))
                {
                    return IsWeaponAvailableRet;
                }
            }

            // お金が足りるか……
            if (Party == "味方")
            {
                string argstring23 = "銭";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring23) > 0)
                {
                    string argattr10 = "銭";
                    if (SRC.Money < GeneralLib.MaxLng((int)WeaponLevel(w, ref argattr10), 1) * Value / 10)
                    {
                        return IsWeaponAvailableRet;
                    }
                }
            }

            // 攻撃不能？
            if (ref_mode != "ステータス")
            {
                object argIndex9 = "攻撃不能";
                if (IsConditionSatisfied(ref argIndex9))
                {
                    return IsWeaponAvailableRet;
                }
            }

            if (Area == "地中")
            {
                return IsWeaponAvailableRet;
            }

            // 移動不能時には移動型マップ攻撃は使用不能
            object argIndex10 = "移動不能";
            if (IsConditionSatisfied(ref argIndex10))
            {
                string argstring24 = "Ｍ移";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring24) > 0)
                {
                    return IsWeaponAvailableRet;
                }
            }

            // 術および音は沈黙状態では使用不能
            object argIndex11 = "沈黙";
            if (IsConditionSatisfied(ref argIndex11))
            {
                string argstring25 = "音";
                if (IsSpellWeapon(w) | GeneralLib.InStrNotNest(ref wclass, ref argstring25) > 0)
                {
                    return IsWeaponAvailableRet;
                }
            }

            // 合体技の処理
            string argstring26 = "合";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring26) > 0)
            {
                if (!IsCombinationAttackAvailable(w))
                {
                    return IsWeaponAvailableRet;
                }
            }

            // 変形技の場合は今いる地形で変形できる必要あり
            string argstring27 = "変";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring27) > 0)
            {
                string argfname = "変形技";
                string argfname1 = "ノーマルモード";
                if (IsFeatureAvailable(ref argfname))
                {
                    var loopTo1 = CountFeature();
                    for (i = 1; i <= loopTo1; i++)
                    {
                        string localFeature() { object argIndex1 = i; var ret = Feature(ref argIndex1); return ret; }

                        string localFeatureData1() { object argIndex1 = i; var ret = FeatureData(ref argIndex1); return ret; }

                        string localLIndex1() { string arglist = hs333745e4b9954fad9f002aac9fe60516(); var ret = GeneralLib.LIndex(ref arglist, 1); return ret; }

                        if (localFeature() == "変形技" & (localLIndex1() ?? "") == (wd.Name ?? ""))
                        {
                            string localFeatureData() { object argIndex1 = i; var ret = FeatureData(ref argIndex1); return ret; }

                            string localLIndex() { string arglist = hsabc0da5e677a47f9bc7fb2c4e22fffab(); var ret = GeneralLib.LIndex(ref arglist, 2); return ret; }

                            Unit localOtherForm() { object argIndex1 = (object)hs70465cd27baa4b1bac8f45eec4036bb3(); var ret = OtherForm(ref argIndex1); return ret; }

                            if (!localOtherForm().IsAbleToEnter(x, y))
                            {
                                return IsWeaponAvailableRet;
                            }
                        }
                    }
                }
                else if (IsFeatureAvailable(ref argfname1))
                {
                    string localLIndex2() { object argIndex1 = "ノーマルモード"; string arglist = FeatureData(ref argIndex1); var ret = GeneralLib.LIndex(ref arglist, 1); return ret; }

                    Unit localOtherForm1() { object argIndex1 = (object)hs8f54e202dcbe4b6290740ebc209beb99(); var ret = OtherForm(ref argIndex1); return ret; }

                    if (!localOtherForm1().IsAbleToEnter(x, y))
                    {
                        return IsWeaponAvailableRet;
                    }
                }

                object argIndex12 = "形態固定";
                if (IsConditionSatisfied(ref argIndex12))
                {
                    return IsWeaponAvailableRet;
                }

                object argIndex13 = "機体固定";
                if (IsConditionSatisfied(ref argIndex13))
                {
                    return IsWeaponAvailableRet;
                }
            }

            // 瀕死時限定
            string argstring28 = "瀕";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring28) > 0)
            {
                if (HP > MaxHP / 4)
                {
                    return IsWeaponAvailableRet;
                }
            }

            // 自動チャージ攻撃を再充填中
            object argIndex14 = WeaponNickname(w) + "充填中";
            if (IsConditionSatisfied(ref argIndex14))
            {
                return IsWeaponAvailableRet;
            }
            // 共有武器＆アビリティが充填中の場合も使用不可
            short lv;
            string argstring29 = "共";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring29) > 0)
            {
                string argattr11 = "共";
                lv = (short)WeaponLevel(w, ref argattr11);
                var loopTo2 = CountWeapon();
                for (i = 1; i <= loopTo2; i++)
                {
                    string argattr13 = "共";
                    if (IsWeaponClassifiedAs(i, ref argattr13))
                    {
                        string argattr12 = "共";
                        if (lv == WeaponLevel(i, ref argattr12))
                        {
                            object argIndex15 = WeaponNickname(i) + "充填中";
                            if (IsConditionSatisfied(ref argIndex15))
                            {
                                return IsWeaponAvailableRet;
                            }
                        }
                    }
                }

                var loopTo3 = CountAbility();
                for (i = 1; i <= loopTo3; i++)
                {
                    string argattr15 = "共";
                    if (IsAbilityClassifiedAs(i, ref argattr15))
                    {
                        string argattr14 = "共";
                        if (lv == AbilityLevel(i, ref argattr14))
                        {
                            object argIndex16 = AbilityNickname(i) + "充填中";
                            if (IsConditionSatisfied(ref argIndex16))
                            {
                                return IsWeaponAvailableRet;
                            }
                        }
                    }
                }
            }

            // 能力コピー
            string argstring210 = "写";
            string argstring211 = "化";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring210) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring211) > 0)
            {
                string argfname2 = "ノーマルモード";
                if (IsFeatureAvailable(ref argfname2))
                {
                    // 既に変身済みの場合はコピー出来ない
                    return IsWeaponAvailableRet;
                }
            }

            // 使用禁止
            string argstring212 = "禁";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring212) > 0)
            {
                return IsWeaponAvailableRet;
            }

            // チャージ判定であればここまででＯＫ
            if (ref_mode == "チャージ")
            {
                IsWeaponAvailableRet = true;
                return IsWeaponAvailableRet;
            }

            // チャージ式攻撃
            string argstring213 = "Ｃ";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring213) > 0)
            {
                object argIndex17 = "チャージ完了";
                if (!IsConditionSatisfied(ref argIndex17))
                {
                    return IsWeaponAvailableRet;
                }
            }

            if (ref_mode == "ステータス")
            {
                IsWeaponAvailableRet = true;
                return IsWeaponAvailableRet;
            }

            // 反撃かどうかの判定
            // 自軍のフェイズでなければ反撃時である
            if ((Party ?? "") != (SRC.Stage ?? ""))
            {
                // 反撃ではマップ攻撃、合体技は使用できない
                string argstring214 = "Ｍ";
                string argstring215 = "合";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring214) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring215) > 0)
                {
                    return IsWeaponAvailableRet;
                }

                // 攻撃専用武器
                string argstring216 = "攻";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring216) > 0)
                {
                    var loopTo4 = (short)Strings.Len(wclass);
                    for (i = 1; i <= loopTo4; i++)
                    {
                        if (Strings.Mid(wclass, i, 1) == "攻")
                        {
                            if (i == 1)
                            {
                                return IsWeaponAvailableRet;
                            }

                            if (Strings.Mid(wclass, i - 1, 1) != "低")
                            {
                                return IsWeaponAvailableRet;
                            }
                        }
                    }
                }
            }
            else
            {
                // 反撃専用攻撃
                string argstring217 = "反";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring217) > 0)
                {
                    return IsWeaponAvailableRet;
                }
            }

            // 移動前か後か……
            if (ref_mode == "移動前" | ref_mode == "必要技能無視" | !ReferenceEquals(Commands.SelectedUnit, this))
            {
                IsWeaponAvailableRet = true;
                return IsWeaponAvailableRet;
            }

            // 移動後の場合
            string argsptype = "全武器移動後使用可能";
            string argstring220 = "Ｍ";
            if (IsUnderSpecialPowerEffect(ref argsptype) & !(GeneralLib.InStrNotNest(ref wclass, ref argstring220) > 0))
            {
                IsWeaponAvailableRet = true;
            }
            else if (WeaponMaxRange(w) > 1)
            {
                string argstring219 = "Ｐ";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring219) > 0)
                {
                    IsWeaponAvailableRet = true;
                }
                else
                {
                    IsWeaponAvailableRet = false;
                }
            }
            else
            {
                string argstring218 = "Ｑ";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring218) > 0)
                {
                    IsWeaponAvailableRet = false;
                }
                else
                {
                    IsWeaponAvailableRet = true;
                }
            }

            return IsWeaponAvailableRet;
        }

        // 武器 w の使用技能を満たしているか。
        public bool IsWeaponMastered(short w)
        {
            bool IsWeaponMasteredRet = default;
            Pilot argp = null;
            IsWeaponMasteredRet = IsNecessarySkillSatisfied(ref Weapon(w).NecessarySkill, p: ref argp);
            return IsWeaponMasteredRet;
        }

        // 武器 w の使用条件を満たしているか。
        public bool IsWeaponEnabled(short w)
        {
            bool IsWeaponEnabledRet = default;
            Pilot argp = null;
            IsWeaponEnabledRet = IsNecessarySkillSatisfied(ref Weapon(w).NecessaryCondition, p: ref argp);
            return IsWeaponEnabledRet;
        }

        // 武器が使用可能であり、かつ射程内に敵がいるかどうか
        public bool IsWeaponUseful(short w, ref string ref_mode)
        {
            bool IsWeaponUsefulRet = default;
            short i, j;
            Unit u;
            short max_range;

            // 武器が使用可能か？
            if (!IsWeaponAvailable(w, ref ref_mode))
            {
                IsWeaponUsefulRet = false;
                return IsWeaponUsefulRet;
            }

            // 扇型マップ攻撃は特殊なので判定ができない
            // 移動型マップ攻撃は移動手段として使うことを考慮
            string argattr = "Ｍ扇";
            string argattr1 = "Ｍ移";
            if (IsWeaponClassifiedAs(w, ref argattr) | IsWeaponClassifiedAs(w, ref argattr1))
            {
                IsWeaponUsefulRet = true;
                return IsWeaponUsefulRet;
            }

            max_range = WeaponMaxRange(w);

            // 投下型マップ攻撃は効果範囲が広い
            string argattr2 = "Ｍ投";
            max_range = (short)(max_range + WeaponLevel(w, ref argattr2));

            // 敵の存在判定
            var loopTo = (short)GeneralLib.MinLng(x + max_range, Map.MapWidth);
            for (i = (short)GeneralLib.MaxLng(x - max_range, 1); i <= loopTo; i++)
            {
                var loopTo1 = (short)GeneralLib.MinLng(y + max_range, Map.MapHeight);
                for (j = (short)GeneralLib.MaxLng(y - max_range, 1); j <= loopTo1; j++)
                {
                    u = Map.MapDataForUnit[i, j];
                    if (u is null)
                    {
                        goto NextUnit;
                    }

                    {
                        var withBlock = u;
                        switch (Party ?? "")
                        {
                            case "味方":
                            case "ＮＰＣ":
                                {
                                    switch (withBlock.Party ?? "")
                                    {
                                        case "味方":
                                        case "ＮＰＣ":
                                            {
                                                // ステータス異常の場合は味方ユニットでも排除可能
                                                object argIndex1 = "暴走";
                                                object argIndex2 = "混乱";
                                                object argIndex3 = "魅了";
                                                object argIndex4 = "憑依";
                                                object argIndex5 = "睡眠";
                                                if (!withBlock.IsConditionSatisfied(ref argIndex1) & !withBlock.IsConditionSatisfied(ref argIndex2) & !withBlock.IsConditionSatisfied(ref argIndex3) & !withBlock.IsConditionSatisfied(ref argIndex4) & !withBlock.IsConditionSatisfied(ref argIndex5))
                                                {
                                                    goto NextUnit;
                                                }

                                                break;
                                            }
                                    }

                                    break;
                                }

                            default:
                                {
                                    if ((Party ?? "") == (withBlock.Party ?? ""))
                                    {
                                        // ステータス異常の場合は味方ユニットでも排除可能
                                        object argIndex6 = "暴走";
                                        object argIndex7 = "混乱";
                                        object argIndex8 = "魅了";
                                        object argIndex9 = "憑依";
                                        if (!withBlock.IsConditionSatisfied(ref argIndex6) & !withBlock.IsConditionSatisfied(ref argIndex7) & !withBlock.IsConditionSatisfied(ref argIndex8) & !withBlock.IsConditionSatisfied(ref argIndex9))
                                        {
                                            goto NextUnit;
                                        }
                                    }

                                    break;
                                }
                        }
                    }

                    if (IsTargetWithinRange(w, ref u))
                    {
                        if (this.Weapon(w).Power > 0)
                        {
                            if (Damage(w, ref u, true) != 0)
                            {
                                IsWeaponUsefulRet = true;
                                return IsWeaponUsefulRet;
                            }
                        }
                        else if (CriticalProbability(w, ref u) > 0)
                        {
                            IsWeaponUsefulRet = true;
                            return IsWeaponUsefulRet;
                        }
                    }

                NextUnit:
                    ;
                }
            }

            // 敵は見つからなかった
            IsWeaponUsefulRet = false;
            return IsWeaponUsefulRet;
        }


        // ユニット t が武器 w の射程範囲内にいるかをチェック
        public bool IsTargetWithinRange(short w, ref Unit t)
        {
            bool IsTargetWithinRangeRet = default;
            short max_range, distance, range_mod;
            short lv;
            IsTargetWithinRangeRet = true;
            var partners = default(Unit[]);
            // 距離を算出
            distance = (short)(Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y)));

            // Ｍ投武器は目標地点からさらに効果範囲が伸びるので射程修正を行う
            string argattr = "Ｍ投";
            range_mod = (short)WeaponLevel(w, ref argattr);

            // 最大射程チェック
            max_range = WeaponMaxRange(w);
            if (distance > (short)(max_range + range_mod))
            {
                IsTargetWithinRangeRet = false;
                return IsTargetWithinRangeRet;
            }

            // 最小射程チェック
            if (distance < (short)(this.Weapon(w).MinRange - range_mod))
            {
                IsTargetWithinRangeRet = false;
                return IsTargetWithinRangeRet;
            }

            // 敵がステルスの場合
            string argfname1 = "ステルス";
            if (t.IsFeatureAvailable(ref argfname1))
            {
                object argIndex2 = "ステルス";
                if (t.IsFeatureLevelSpecified(ref argIndex2))
                {
                    object argIndex1 = "ステルス";
                    lv = (short)t.FeatureLevel(ref argIndex1);
                }
                else
                {
                    lv = 3;
                }

                object argIndex3 = "ステルス無効";
                string argfname = "ステルス無効化";
                if (!t.IsConditionSatisfied(ref argIndex3) & !IsFeatureAvailable(ref argfname) & distance > lv)
                {
                    IsTargetWithinRangeRet = false;
                    return IsTargetWithinRangeRet;
                }
            }

            // 隠れ身中？
            string argsptype1 = "隠れ身";
            if (t.IsUnderSpecialPowerEffect(ref argsptype1))
            {
                string argsptype = "無防備";
                if (!t.IsUnderSpecialPowerEffect(ref argsptype))
                {
                    IsTargetWithinRangeRet = false;
                    return IsTargetWithinRangeRet;
                }
            }

            // 攻撃できない地形にいる場合は射程外とみなす
            if (WeaponAdaption(w, ref t.Area) == 0d)
            {
                IsTargetWithinRangeRet = false;
                return IsTargetWithinRangeRet;
            }

            // 合体技で射程が１の場合は相手を囲んでいる必要がある
            string argattr1 = "合";
            string argattr2 = "Ｍ";
            if (IsWeaponClassifiedAs(w, ref argattr1) & !IsWeaponClassifiedAs(w, ref argattr2) & max_range == 1)
            {
                string argctype_Renamed = "武装";
                CombinationPartner(ref argctype_Renamed, w, ref partners, t.x, t.y);
                if (Information.UBound(partners) == 0)
                {
                    IsTargetWithinRangeRet = false;
                    return IsTargetWithinRangeRet;
                }
            }

            return IsTargetWithinRangeRet;
        }

        // 移動を併用した場合にユニット t が武器 w の射程範囲内にいるかをチェック
        public bool IsTargetReachable(short w, ref Unit t)
        {
            bool IsTargetReachableRet = default;
            short i, j;
            short max_range, min_range;
            var partners = default(Unit[]);
            // 地形適応をチェック
            if (WeaponAdaption(w, ref t.Area) == 0d)
            {
                IsTargetReachableRet = false;
                return IsTargetReachableRet;
            }

            // 隠れ身使用中？
            string argsptype1 = "隠れ身";
            if (t.IsUnderSpecialPowerEffect(ref argsptype1))
            {
                string argsptype = "無防備";
                if (!t.IsUnderSpecialPowerEffect(ref argsptype))
                {
                    IsTargetReachableRet = false;
                    return IsTargetReachableRet;
                }
            }

            // 射程計算
            min_range = Weapon(w).MinRange;
            max_range = WeaponMaxRange(w);
            // 敵がステルスの場合
            string argfname = "ステルス";
            object argIndex3 = "ステルス無効";
            string argfname1 = "ステルス無効化";
            if (t.IsFeatureAvailable(ref argfname) & !t.IsConditionSatisfied(ref argIndex3) & !IsFeatureAvailable(ref argfname1))
            {
                object argIndex2 = "ステルス";
                if (t.IsFeatureLevelSpecified(ref argIndex2))
                {
                    object argIndex1 = "ステルス";
                    max_range = (short)GeneralLib.MinLng(max_range, (int)(t.FeatureLevel(ref argIndex1) + 1d));
                }
                else
                {
                    max_range = (short)GeneralLib.MinLng(max_range, 4);
                }
            }

            // 隣接していれば必ず届く
            if (min_range == 1 & Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y)) == 1)
            {
                // ただし合体技の場合は例外……
                // 合体技で射程が１の場合は相手を囲んでいる必要がある
                string argattr = "合";
                string argattr1 = "Ｍ";
                if (IsWeaponClassifiedAs(w, ref argattr) & !IsWeaponClassifiedAs(w, ref argattr1) & WeaponMaxRange(w) == 1)
                {
                    string argctype_Renamed = "武装";
                    CombinationPartner(ref argctype_Renamed, w, ref partners, t.x, t.y);
                    if (Information.UBound(partners) == 0)
                    {
                        IsTargetReachableRet = false;
                        return IsTargetReachableRet;
                    }
                }

                IsTargetReachableRet = true;
                return IsTargetReachableRet;
            }

            // 移動範囲から敵に攻撃が届くかをチェック
            var loopTo = (short)GeneralLib.MinLng(t.x + max_range, Map.MapWidth);
            for (i = (short)GeneralLib.MaxLng(t.x - max_range, 1); i <= loopTo; i++)
            {
                var loopTo1 = (short)GeneralLib.MinLng(t.y + (short)(max_range - Math.Abs((short)(t.x - i))), Map.MapHeight);
                for (j = (short)GeneralLib.MaxLng(t.y - (short)(max_range - Math.Abs((short)(t.x - i))), 1); j <= loopTo1; j++)
                {
                    if (min_range <= (short)(Math.Abs((short)(t.x - i)) + Math.Abs((short)(t.y - i))))
                    {
                        if (!Map.MaskData[i, j])
                        {
                            IsTargetReachableRet = true;
                            return IsTargetReachableRet;
                        }
                    }
                }
            }

            IsTargetReachableRet = false;
            return IsTargetReachableRet;
        }

        // 武器 w のユニット t に対する命中率
        // 敵ユニットはスペシャルパワー等による補正を考慮しないので
        // is_true_value によって補正を省くかどうかを指定できるようにしている
        public short HitProbability(short w, ref Unit t, bool is_true_value)
        {
            short HitProbabilityRet = default;
            int prob;
            short mpskill;
            short i, j;
            Unit u;
            var wclass = default(string);
            double ecm_lv = default, eccm_lv = default;
            string buf;
            string fdata;
            double flevel, prob_mod;
            short nmorale;
            // 命中、回避、地形補正、サイズ補正の数値を定義
            int ed_hit, ed_avd;
            double ed_aradap, ed_size = default;

            // 初期値
            ed_aradap = 1d;

            // スペシャルパワーによる捨て身状態
            string argsptype = "無防備";
            if (t.IsUnderSpecialPowerEffect(ref argsptype))
            {
                HitProbabilityRet = 100;
                return HitProbabilityRet;
            }

            // パイロットの技量によって命中率を正確に予測できるか左右される
            mpskill = MainPilot().TacticalTechnique();

            // スペシャルパワーによる影響
            if (is_true_value | mpskill >= 160)
            {
                string argsptype1 = "絶対回避";
                if (t.IsUnderSpecialPowerEffect(ref argsptype1))
                {
                    HitProbabilityRet = 0;
                    return HitProbabilityRet;
                }

                string argsptype2 = "絶対命中";
                if (IsUnderSpecialPowerEffect(ref argsptype2))
                {
                    HitProbabilityRet = 1000;
                    return HitProbabilityRet;
                }
            }

            // 自ユニットによる修正
            {
                var withBlock = MainPilot();
                object argIndex2 = "命中補正";
                if (SRC.BCList.IsDefined(ref argIndex2))
                {
                    // 命中を一時保存
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = this;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    BCVariable.AttackExp = WeaponPrecision(w);
                    string argIndex1 = "命中補正";
                    ed_hit = (int)SRC.BCList.Item(ref argIndex1).Calculate();
                }
                else
                {
                    // 命中を一時保存
                    ed_hit = 100 + withBlock.Hit + withBlock.Intuition + get_Mobility("") + WeaponPrecision(w);
                }
            }

            // 敵ユニットによる修正
            {
                var withBlock1 = t.MainPilot();
                object argIndex4 = "回避補正";
                if (SRC.BCList.IsDefined(ref argIndex4))
                {
                    // 回避を一時保存
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = t;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    string argIndex3 = "回避補正";
                    ed_avd = (int)SRC.BCList.Item(ref argIndex3).Calculate();
                }
                else
                {
                    // 回避を一時保存
                    ed_avd = (short)(withBlock1.Dodge + withBlock1.Intuition) + t.get_Mobility("");
                }
            }

            // 地形適応、サイズ修正の位置を変更
            var uadaption = default(double);
            string tarea;
            short tx, ty;
            {
                var withBlock2 = t;
                // 地形修正
                if (withBlock2.Area != "空中" & (withBlock2.Area != "宇宙" | Map.TerrainClass(withBlock2.x, withBlock2.y) != "月面"))
                {
                    // 地形修正を一時保存
                    ed_aradap = ed_aradap * (100 - Map.TerrainEffectForHit(withBlock2.x, withBlock2.y)) / 100d;
                }

                // 地形適応修正
                string argoname = "地形適応命中率修正";
                if (Expression.IsOptionDefined(ref argoname))
                {

                    // 接近戦攻撃の場合はターゲット側の地形を参照
                    string argattr = "武";
                    string argattr1 = "突";
                    string argattr2 = "接";
                    if (IsWeaponClassifiedAs(w, ref argattr) | IsWeaponClassifiedAs(w, ref argattr1) | IsWeaponClassifiedAs(w, ref argattr2))
                    {
                        tarea = withBlock2.Area;
                        tx = withBlock2.x;
                        ty = withBlock2.y;
                    }
                    else
                    {
                        tarea = Area;
                        tx = x;
                        ty = y;
                    }

                    switch (tarea ?? "")
                    {
                        case "空中":
                            {
                                uadaption = get_AdaptionMod(1, 0);
                                // ジャンプ攻撃の場合はＪ属性による修正を加える
                                string argarea_name = "空";
                                if ((withBlock2.Area == "空中" | withBlock2.Area == "宇宙") & Area != "空中" & Area != "宇宙" & !IsTransAvailable(ref argarea_name))
                                {
                                    string argstring2 = "武";
                                    string argstring21 = "突";
                                    string argstring22 = "接";
                                    if (Conversions.ToBoolean(GeneralLib.InStrNotNest(ref wclass, ref argstring2) | GeneralLib.InStrNotNest(ref wclass, ref argstring21) | GeneralLib.InStrNotNest(ref wclass, ref argstring22)))
                                    {
                                        string argattr3 = "Ｊ";
                                        uadaption = get_AdaptionMod(1, (short)WeaponLevel(w, ref argattr3));
                                    }
                                }

                                break;
                            }

                        case "地上":
                            {
                                if (Map.TerrainClass(tx, ty) == "月面")
                                {
                                    uadaption = get_AdaptionMod(4, 0);
                                }
                                else
                                {
                                    uadaption = get_AdaptionMod(2, 0);
                                }

                                break;
                            }

                        case "水上":
                            {
                                uadaption = get_AdaptionMod(2, 0);
                                break;
                            }

                        case "水中":
                            {
                                uadaption = get_AdaptionMod(3, 0);
                                break;
                            }

                        case "宇宙":
                            {
                                uadaption = get_AdaptionMod(4, 0);
                                break;
                            }

                        case "地中":
                            {
                                HitProbabilityRet = 0;
                                return HitProbabilityRet;
                            }
                    }

                    // 地形修正を一時保存
                    ed_aradap = ed_aradap * uadaption;
                }

                // サイズ補正
                switch (withBlock2.Size ?? "")
                {
                    case "M":
                        {
                            ed_size = 1d;
                            break;
                        }

                    case "L":
                        {
                            ed_size = 1.2d;
                            break;
                        }

                    case "S":
                        {
                            ed_size = 0.8d;
                            break;
                        }

                    case "LL":
                        {
                            ed_size = 1.4d;
                            break;
                        }

                    case "SS":
                        {
                            ed_size = 0.5d;
                            break;
                        }

                    case "XL":
                        {
                            ed_size = 2d;
                            break;
                        }
                }
            }

            // 命中率計算実行
            object argIndex6 = "命中率";
            if (SRC.BCList.IsDefined(ref argIndex6))
            {
                // 事前にデータを登録
                BCVariable.DataReset();
                BCVariable.MeUnit = this;
                BCVariable.AtkUnit = this;
                BCVariable.DefUnit = t;
                BCVariable.WeaponNumber = w;
                BCVariable.AttackVariable = ed_hit;
                BCVariable.DffenceVariable = ed_avd;
                BCVariable.TerrainAdaption = ed_aradap;
                BCVariable.SizeMod = ed_size;
                string argIndex5 = "命中率";
                prob = (int)SRC.BCList.Item(ref argIndex5).Calculate();
            }
            else
            {
                prob = (int)((ed_hit - ed_avd) * ed_aradap * ed_size);
            }

            // 不意打ち
            string argfname = "ステルス";
            object argIndex7 = "ステルス無効";
            string argfname1 = "ステルス無効化";
            if (IsFeatureAvailable(ref argfname) & !IsConditionSatisfied(ref argIndex7) & !t.IsFeatureAvailable(ref argfname1))
            {
                prob = prob + 20;
            }

            wclass = WeaponClass(w);
            short uad;
            {
                var withBlock3 = t;
                // 散属性武器は指定したレベル以上離れるほど命中がアップ
                string argstring23 = "散";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring23) > 0)
                {
                    switch ((short)(Math.Abs((short)(x - withBlock3.x)) + Math.Abs((short)(y - withBlock3.y))))
                    {
                        case 1:
                            {
                                break;
                            }
                        // 修正なし
                        case 2:
                            {
                                prob = prob + 5;
                                break;
                            }

                        case 3:
                            {
                                prob = prob + 10;
                                break;
                            }

                        case 4:
                            {
                                prob = prob + 15;
                                break;
                            }

                        default:
                            {
                                prob = prob + 20;
                                break;
                            }
                    }
                }

                string argstring27 = "サ";
                string argstring28 = "有";
                string argstring29 = "誘";
                string argstring210 = "追";
                string argstring211 = "武";
                string argstring212 = "突";
                string argstring213 = "接";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring27) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring28) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring29) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring210) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring211) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring212) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring213) == 0)
                {
                    // 距離修正
                    string argoname3 = "距離修正";
                    if (Expression.IsOptionDefined(ref argoname3))
                    {
                        string argstring24 = "Ｈ";
                        string argstring25 = "Ｍ";
                        if (GeneralLib.InStrNotNest(ref wclass, ref argstring24) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring25) == 0)
                        {
                            string argoname1 = "大型マップ";
                            string argoname2 = "小型マップ";
                            if (Expression.IsOptionDefined(ref argoname1))
                            {
                                switch ((short)(Math.Abs((short)(x - withBlock3.x)) + Math.Abs((short)(y - withBlock3.y))))
                                {
                                    case var @case when 1 <= @case && @case <= 4:
                                        {
                                            break;
                                        }
                                    // 修正なし
                                    case 5:
                                    case 6:
                                        {
                                            prob = (int)(0.9d * prob);
                                            break;
                                        }

                                    case 7:
                                    case 8:
                                        {
                                            prob = (int)(0.8d * prob);
                                            break;
                                        }

                                    case 9:
                                    case 10:
                                        {
                                            prob = (int)(0.7d * prob);
                                            break;
                                        }

                                    default:
                                        {
                                            prob = (int)(0.6d * prob);
                                            break;
                                        }
                                }
                            }
                            else if (Expression.IsOptionDefined(ref argoname2))
                            {
                                switch ((short)(Math.Abs((short)(x - withBlock3.x)) + Math.Abs((short)(y - withBlock3.y))))
                                {
                                    case 1:
                                        {
                                            break;
                                        }
                                    // 修正なし
                                    case 2:
                                        {
                                            prob = (int)(0.9d * prob);
                                            break;
                                        }

                                    case 3:
                                        {
                                            prob = (int)(0.8d * prob);
                                            break;
                                        }

                                    case 4:
                                        {
                                            prob = (int)(0.75d * prob);
                                            break;
                                        }

                                    case 5:
                                        {
                                            prob = (int)(0.7d * prob);
                                            break;
                                        }

                                    case 6:
                                        {
                                            prob = (int)(0.65d * prob);
                                            break;
                                        }

                                    default:
                                        {
                                            prob = (int)(0.6d * prob);
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch ((short)(Math.Abs((short)(x - withBlock3.x)) + Math.Abs((short)(y - withBlock3.y))))
                                {
                                    case var case1 when 1 <= case1 && case1 <= 3:
                                        {
                                            break;
                                        }
                                    // 修正なし
                                    case 4:
                                        {
                                            prob = (int)(0.9d * prob);
                                            break;
                                        }

                                    case 5:
                                        {
                                            prob = (int)(0.8d * prob);
                                            break;
                                        }

                                    case 6:
                                        {
                                            prob = (int)(0.7d * prob);
                                            break;
                                        }

                                    default:
                                        {
                                            prob = (int)(0.6d * prob);
                                            break;
                                        }
                                }
                            }
                        }
                    }

                    // ＥＣＭ
                    var loopTo = (short)GeneralLib.MinLng(withBlock3.x + 2, Map.MapWidth);
                    for (i = (short)GeneralLib.MaxLng(withBlock3.x - 2, 1); i <= loopTo; i++)
                    {
                        var loopTo1 = (short)GeneralLib.MinLng(withBlock3.y + 2, Map.MapHeight);
                        for (j = (short)GeneralLib.MaxLng(withBlock3.y - 2, 1); j <= loopTo1; j++)
                        {
                            if (Math.Abs((short)(withBlock3.x - i)) + Math.Abs((short)(withBlock3.y - j)) <= 3)
                            {
                                u = Map.MapDataForUnit[i, j];
                                if (u is object)
                                {
                                    var argt = this;
                                    if (u.IsAlly(ref t))
                                    {
                                        object argIndex8 = "ＥＣＭ";
                                        ecm_lv = GeneralLib.MaxDbl(ecm_lv, u.FeatureLevel(ref argIndex8));
                                    }
                                    else if (u.IsAlly(ref argt))
                                    {
                                        object argIndex9 = "ＥＣＭ";
                                        eccm_lv = GeneralLib.MaxDbl(eccm_lv, u.FeatureLevel(ref argIndex9));
                                    }
                                }
                            }
                        }
                    }
                    // ホーミング攻撃はＥＣＭの影響を強く受ける
                    string argstring26 = "Ｈ";
                    if (GeneralLib.InStrNotNest(ref wclass, ref argstring26) > 0)
                    {
                        prob = (int)((long)(prob * (100d - 10d * GeneralLib.MaxDbl(ecm_lv - eccm_lv, 0d))) / 100L);
                    }
                    else
                    {
                        prob = (int)((long)(prob * (100d - 5d * GeneralLib.MaxDbl(ecm_lv - eccm_lv, 0d))) / 100L);
                    }
                }

                // ステルスによる補正
                string argfname2 = "ステルス";
                string argfname3 = "ステルス無効化";
                if (withBlock3.IsFeatureAvailable(ref argfname2) & !IsFeatureAvailable(ref argfname3))
                {
                    object argIndex11 = "ステルス";
                    if (withBlock3.IsFeatureLevelSpecified(ref argIndex11))
                    {
                        object argIndex10 = "ステルス";
                        if (Math.Abs((short)(x - withBlock3.x)) + Math.Abs((short)(y - withBlock3.y)) > withBlock3.FeatureLevel(ref argIndex10))
                        {
                            prob = (int)(prob * 0.8d);
                        }
                    }
                    else if (Math.Abs((short)(x - withBlock3.x)) + Math.Abs((short)(y - withBlock3.y)) > 3)
                    {
                        prob = (int)(prob * 0.8d);
                    }
                }

                // 地上から空中の敵に攻撃する
                if ((withBlock3.Area == "空中" | withBlock3.Area == "宇宙") & Area != "空中" & Area != "宇宙")
                {
                    string argstring216 = "武";
                    string argstring217 = "突";
                    string argstring218 = "接";
                    if (Conversions.ToBoolean(GeneralLib.InStrNotNest(ref wclass, ref argstring216) | GeneralLib.InStrNotNest(ref wclass, ref argstring217) | GeneralLib.InStrNotNest(ref wclass, ref argstring218)))
                    {
                        // ジャンプ攻撃
                        string argoname4 = "地形適応命中率修正";
                        if (!Expression.IsOptionDefined(ref argoname4))
                        {
                            string argarea_name1 = "空";
                            if (!IsTransAvailable(ref argarea_name1))
                            {
                                uad = get_Adaption(1);
                                string argstring214 = "Ｊ";
                                if (GeneralLib.InStrNotNest(ref wclass, ref argstring214) > 0)
                                {
                                    string argattr4 = "Ｊ";
                                    uad = (short)GeneralLib.MinLng((int)(uad + WeaponLevel(w, ref argattr4)), 4);
                                }

                                uad = (short)GeneralLib.MinLng(uad, 4);
                                prob = (uad + 6) * prob / 10;
                            }
                        }
                    }
                    else
                    {
                        // 通常攻撃
                        string argoname5 = "高度修正";
                        if (Expression.IsOptionDefined(ref argoname5))
                        {
                            string argstring215 = "空";
                            if (GeneralLib.InStrNotNest(ref wclass, ref argstring215) == 0)
                            {
                                prob = (int)(0.7d * prob);
                            }
                        }
                    }
                }

                // 局地戦能力
                string argfname4 = "地形適応";
                if (withBlock3.IsFeatureAvailable(ref argfname4))
                {
                    var loopTo2 = withBlock3.CountFeature();
                    for (i = 1; i <= loopTo2; i++)
                    {
                        object argIndex13 = i;
                        if (withBlock3.Feature(ref argIndex13) == "地形適応")
                        {
                            object argIndex12 = i;
                            buf = withBlock3.FeatureData(ref argIndex12);
                            var loopTo3 = GeneralLib.LLength(ref buf);
                            for (j = 2; j <= loopTo3; j++)
                            {
                                if ((Map.TerrainName(withBlock3.x, withBlock3.y) ?? "") == (GeneralLib.LIndex(ref buf, j) ?? ""))
                                {
                                    prob = prob - 10;
                                    break;
                                }
                            }
                        }
                    }
                }

                // 攻撃回避
                string argfname5 = "攻撃回避";
                if (withBlock3.IsFeatureAvailable(ref argfname5))
                {
                    prob_mod = 0d;
                    var loopTo4 = withBlock3.CountFeature();
                    for (i = 1; i <= loopTo4; i++)
                    {
                        object argIndex16 = i;
                        if (withBlock3.Feature(ref argIndex16) == "攻撃回避")
                        {
                            object argIndex14 = i;
                            fdata = withBlock3.FeatureData(ref argIndex14);
                            object argIndex15 = i;
                            flevel = withBlock3.FeatureLevel(ref argIndex15);

                            // 必要条件
                            if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 3)))
                            {
                                nmorale = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 3));
                            }
                            else
                            {
                                nmorale = 0;
                            }

                            // 発動可能？
                            bool localIsAttributeClassified() { string argaclass1 = GeneralLib.LIndex(ref fdata, 2); var ret = withBlock3.IsAttributeClassified(ref argaclass1, ref wclass); return ret; }

                            if (withBlock3.MainPilot().Morale >= nmorale & localIsAttributeClassified())
                            {
                                // 攻撃回避発動
                                prob_mod = prob_mod + flevel;
                            }
                        }
                    }

                    prob = (int)((long)(prob * (10d - prob_mod)) / 10L);
                }

                // 動けなければ絶対に命中
                object argIndex17 = "行動不能";
                object argIndex18 = "麻痺";
                object argIndex19 = "睡眠";
                object argIndex20 = "石化";
                object argIndex21 = "凍結";
                string argsptype3 = "行動不能";
                if (withBlock3.IsConditionSatisfied(ref argIndex17) | withBlock3.IsConditionSatisfied(ref argIndex18) | withBlock3.IsConditionSatisfied(ref argIndex19) | withBlock3.IsConditionSatisfied(ref argIndex20) | withBlock3.IsConditionSatisfied(ref argIndex21) | withBlock3.IsUnderSpecialPowerEffect(ref argsptype3))
                {
                    HitProbabilityRet = 1000;
                    return HitProbabilityRet;
                }

                // ステータス異常による修正
                string argstring219 = "Ｈ";
                string argstring220 = "追";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring219) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring220) == 0)
                {
                    object argIndex22 = "撹乱";
                    if (IsConditionSatisfied(ref argIndex22))
                    {
                        prob = prob / 2;
                    }

                    object argIndex23 = "恐怖";
                    if (IsConditionSatisfied(ref argIndex23))
                    {
                        prob = prob / 2;
                    }

                    object argIndex24 = "盲目";
                    if (IsConditionSatisfied(ref argIndex24))
                    {
                        prob = prob / 2;
                    }
                }

                // ターゲットのステータス異常による修正
                object argIndex25 = "盲目";
                if (withBlock3.IsConditionSatisfied(ref argIndex25))
                {
                    prob = (int)(1.5d * prob);
                }

                object argIndex26 = "チャージ";
                if (withBlock3.IsConditionSatisfied(ref argIndex26))
                {
                    prob = (int)(1.5d * prob);
                }

                object argIndex27 = "消耗";
                if (withBlock3.IsConditionSatisfied(ref argIndex27))
                {
                    prob = (int)(1.5d * prob);
                }

                object argIndex28 = "狂戦士";
                if (withBlock3.IsConditionSatisfied(ref argIndex28))
                {
                    prob = (int)(1.5d * prob);
                }

                object argIndex29 = "移動不能";
                if (withBlock3.IsConditionSatisfied(ref argIndex29))
                {
                    prob = (int)(1.5d * prob);
                }

                // 底力
                if (HP <= MaxHP / 4)
                {
                    {
                        var withBlock4 = MainPilot();
                        string argsname = "超底力";
                        string argsname1 = "底力";
                        if (withBlock4.IsSkillAvailable(ref argsname))
                        {
                            prob = prob + 50;
                        }
                        else if (withBlock4.IsSkillAvailable(ref argsname1))
                        {
                            prob = prob + 30;
                        }
                    }
                }

                if (withBlock3.HP <= withBlock3.MaxHP / 4)
                {
                    {
                        var withBlock5 = withBlock3.MainPilot();
                        string argsname2 = "超底力";
                        string argsname3 = "底力";
                        if (withBlock5.IsSkillAvailable(ref argsname2))
                        {
                            prob = prob - 50;
                        }
                        else if (withBlock5.IsSkillAvailable(ref argsname3))
                        {
                            prob = prob - 30;
                        }
                    }
                }

                // スペシャルパワー及び特殊状態による補正
                if (is_true_value | mpskill >= 160)
                {
                    string argsptype4 = "命中強化";
                    object argIndex30 = "運動性ＵＰ";
                    if (IsUnderSpecialPowerEffect(ref argsptype4))
                    {
                        string argsname4 = "命中強化";
                        prob = (int)(prob + 10d * SpecialPowerEffectLevel(ref argsname4));
                    }
                    else if (IsConditionSatisfied(ref argIndex30))
                    {
                        prob = prob + 15;
                    }

                    string argsptype5 = "回避強化";
                    object argIndex31 = "運動性ＵＰ";
                    if (withBlock3.IsUnderSpecialPowerEffect(ref argsptype5))
                    {
                        string argsname5 = "回避強化";
                        prob = (int)(prob - 10d * withBlock3.SpecialPowerEffectLevel(ref argsname5));
                    }
                    else if (withBlock3.IsConditionSatisfied(ref argIndex31))
                    {
                        prob = prob - 15;
                    }

                    object argIndex32 = "運動性ＤＯＷＮ";
                    if (IsConditionSatisfied(ref argIndex32))
                    {
                        prob = prob - 15;
                    }

                    object argIndex33 = "運動性ＤＯＷＮ";
                    if (withBlock3.IsConditionSatisfied(ref argIndex33))
                    {
                        prob = prob + 15;
                    }

                    string argsptype6 = "命中低下";
                    if (IsUnderSpecialPowerEffect(ref argsptype6))
                    {
                        string argsname6 = "命中低下";
                        prob = (int)(prob - 10d * SpecialPowerEffectLevel(ref argsname6));
                    }

                    string argsptype7 = "回避低下";
                    if (withBlock3.IsUnderSpecialPowerEffect(ref argsptype7))
                    {
                        string argsname7 = "回避低下";
                        prob = (int)(prob + 10d * withBlock3.SpecialPowerEffectLevel(ref argsname7));
                    }

                    string argsptype8 = "命中率低下";
                    if (IsUnderSpecialPowerEffect(ref argsptype8))
                    {
                        string argsname8 = "命中率低下";
                        prob = (int)((long)(prob * (10d - SpecialPowerEffectLevel(ref argsname8))) / 10L);
                    }
                }
            }

            // 最終命中率を定義する。これがないときは何もしない
            object argIndex35 = "最終命中率";
            if (SRC.BCList.IsDefined(ref argIndex35))
            {
                // 事前にデータを登録
                BCVariable.DataReset();
                BCVariable.MeUnit = this;
                BCVariable.AtkUnit = this;
                BCVariable.DefUnit = t;
                BCVariable.WeaponNumber = w;
                BCVariable.LastVariable = prob;
                string argIndex34 = "最終命中率";
                prob = (int)SRC.BCList.Item(ref argIndex34).Calculate();
            }

            if (prob < 0)
            {
                HitProbabilityRet = 0;
            }
            else
            {
                HitProbabilityRet = (short)prob;
            }

            return HitProbabilityRet;
        }

        // 武器 w のユニット t に対するダメージ
        // 敵ユニットはスペシャルパワー等による補正を考慮しないので
        // is_true_value によって補正を省くかどうかを指定できるようにしている
        public int Damage(short w, ref Unit t, bool is_true_value, bool is_support_attack = false)
        {
            int DamageRet = default;
            int arm, arm_mod;
            short j, i, idx;
            string ch, wclass, buf;
            short mpskill;
            string fname, fdata;
            double flevel;
            double slevel;
            string sdata;
            short nmorale;
            bool neautralize;
            double lv_mod;
            string opt;
            string tname;
            double dmg_mod, uadaption = default;
            // 装甲、装甲補正一時保存
            double ed_amr;
            double ed_amr_fix;
            wclass = WeaponClass(w);

            // パイロットの技量によってダメージを正確に予測できるか左右される
            mpskill = MainPilot().TacticalTechnique();
            // 武器攻撃力
            DamageRet = WeaponPower(w, ref t.Area);
            // 攻撃力が0の場合は常にダメージ0
            if (DamageRet == 0)
            {
                return DamageRet;
            }

            // 基本装甲値
            arm = t.get_Armor("");

            // アーマー能力
            string argfname = "アーマー";
            if (!t.IsFeatureAvailable(ref argfname))
            {
                goto SkipArmor;
            }
            // ザコはアーマーを考慮しない
            if (!is_true_value & mpskill < 150)
            {
                goto SkipArmor;
            }

            arm_mod = 0;
            var loopTo = t.CountFeature();
            for (i = 1; i <= loopTo; i++)
            {
                object argIndex6 = i;
                if (t.Feature(ref argIndex6) == "アーマー")
                {
                    object argIndex1 = i;
                    fname = t.FeatureName0(ref argIndex1);
                    object argIndex2 = i;
                    fdata = t.FeatureData(ref argIndex2);
                    object argIndex3 = i;
                    flevel = t.FeatureLevel(ref argIndex3);

                    // 必要条件
                    if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 3)))
                    {
                        nmorale = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 3));
                    }
                    else
                    {
                        nmorale = 0;
                    }

                    // オプション
                    neautralize = false;
                    slevel = 0d;
                    var loopTo1 = GeneralLib.LLength(ref fdata);
                    for (j = 4; j <= loopTo1; j++)
                    {
                        opt = GeneralLib.LIndex(ref fdata, j);
                        idx = (short)Strings.InStr(opt, "*");
                        if (idx > 0)
                        {
                            string argexpr = Strings.Mid(opt, idx + 1);
                            lv_mod = GeneralLib.StrToDbl(ref argexpr);
                            opt = Strings.Left(opt, idx - 1);
                        }
                        else
                        {
                            lv_mod = -1;
                        }

                        switch (opt ?? "")
                        {
                            case "能力必要":
                                {
                                    break;
                                }
                            // スキップ
                            case "同調率":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 5d;
                                    }

                                    slevel = lv_mod * (t.MainPilot().SynchroRate() - 30);
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == -30 * lv_mod)
                                        {
                                            neautralize = true;
                                        }
                                    }
                                    else if (slevel == -30 * lv_mod)
                                    {
                                        slevel = 0d;
                                    }

                                    break;
                                }

                            case "霊力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 2d;
                                    }

                                    slevel = lv_mod * t.MainPilot().Plana;
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "オーラ":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 50d;
                                    }

                                    slevel = lv_mod * t.AuraLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "超能力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 50d;
                                    }

                                    slevel = lv_mod * t.PsychicLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "超感覚":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 50d;
                                    }

                                    object argIndex4 = "超感覚";
                                    string argref_mode = "";
                                    object argIndex5 = "知覚強化";
                                    string argref_mode1 = "";
                                    slevel = lv_mod * (t.MainPilot().SkillLevel(ref argIndex4, ref_mode: ref argref_mode) + t.MainPilot().SkillLevel(ref argIndex5, ref_mode: ref argref_mode1));
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            default:
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 50d;
                                    }

                                    double localSkillLevel() { object argIndex1 = opt; string argref_mode = ""; var ret = t.MainPilot().SkillLevel(ref argIndex1, ref_mode: ref argref_mode); return ret; }

                                    slevel = lv_mod * localSkillLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }
                        }
                    }

                    // 発動可能？
                    bool localIsAttributeClassified() { string argaclass1 = GeneralLib.LIndex(ref fdata, 2); var ret = t.IsAttributeClassified(ref argaclass1, ref wclass); return ret; }

                    if (t.MainPilot().Morale >= nmorale & localIsAttributeClassified() & !neautralize)
                    {
                        // アーマー発動
                        arm_mod = (int)(arm_mod + 100d * flevel + slevel);
                    }
                }
            }

            // 装甲が劣化している場合はアーマーによる装甲追加も半減
            object argIndex7 = "装甲劣化";
            if (t.IsConditionSatisfied(ref argIndex7))
            {
                arm_mod = arm_mod / 2;
            }

            arm = arm + arm_mod;
        SkipArmor:
            ;


            // 地形適応による装甲修正
            string argoname = "地形適応命中率修正";
            if (!Expression.IsOptionDefined(ref argoname))
            {
                switch (t.Area ?? "")
                {
                    case "空中":
                        {
                            uadaption = t.get_AdaptionMod(1, 0);
                            break;
                        }

                    case "地上":
                        {
                            if (Map.TerrainClass(t.x, t.y) == "月面")
                            {
                                uadaption = t.get_AdaptionMod(4, 0);
                            }
                            else
                            {
                                uadaption = t.get_AdaptionMod(2, 0);
                            }

                            break;
                        }

                    case "水上":
                        {
                            uadaption = t.get_AdaptionMod(2, 0);
                            break;
                        }

                    case "水中":
                        {
                            uadaption = t.get_AdaptionMod(3, 0);
                            break;
                        }

                    case "宇宙":
                        {
                            uadaption = t.get_AdaptionMod(4, 0);
                            break;
                        }

                    case "地中":
                        {
                            DamageRet = 0;
                            return DamageRet;
                        }
                }

                if (uadaption == 0d)
                {
                    uadaption = 0.6d;
                }
            }
            else if (t.Area == "地中")
            {
                DamageRet = 0;
                return DamageRet;
            }
            else
            {
                uadaption = 1d;
            }

            // 不屈による装甲修正
            string argsname = "不屈";
            if (t.MainPilot().IsSkillAvailable(ref argsname))
            {
                string argoname1 = "防御力倍率低下";
                if (Expression.IsOptionDefined(ref argoname1))
                {
                    if (t.HP <= t.MaxHP / 8)
                    {
                        arm = (int)(1.15d * arm);
                    }
                    else if (t.HP <= t.MaxHP / 4)
                    {
                        arm = (int)(1.1d * arm);
                    }
                    else if (t.HP <= t.MaxHP / 2)
                    {
                        arm = (int)(1.05d * arm);
                    }
                }
                else if (t.HP <= t.MaxHP / 8)
                {
                    arm = (int)(1.3d * arm);
                }
                else if (t.HP <= t.MaxHP / 4)
                {
                    arm = (int)(1.2d * arm);
                }
                else if (t.HP <= t.MaxHP / 2)
                {
                    arm = (int)(1.1d * arm);
                }
            }

            // スペシャルパワーによる無防備状態
            string argsptype = "無防備";
            if (t.IsUnderSpecialPowerEffect(ref argsptype))
            {
                arm = 0;
            }

            if (is_true_value | mpskill >= 160)
            {
                // スペシャルパワーによる修正
                string argsptype1 = "装甲強化";
                // 装甲強化
                object argIndex8 = "防御力ＵＰ";
                if (t.IsUnderSpecialPowerEffect(ref argsptype1))
                {
                    string argsname1 = "装甲強化";
                    arm = (int)(arm * (1d + 0.1d * t.SpecialPowerEffectLevel(ref argsname1)));
                }
                else if (t.IsConditionSatisfied(ref argIndex8))
                {
                    string argoname2 = "防御力倍率低下";
                    if (Expression.IsOptionDefined(ref argoname2))
                    {
                        arm = (int)(1.25d * arm);
                    }
                    else
                    {
                        arm = (int)(1.5d * arm);
                    }
                }

                string argsptype2 = "装甲低下";
                object argIndex9 = "防御力ＤＯＷＮ";
                if (t.IsUnderSpecialPowerEffect(ref argsptype2))
                {
                    string argsname2 = "装甲低下";
                    arm = (int)(arm * (1d + 0.1d * t.SpecialPowerEffectLevel(ref argsname2)));
                }
                else if (t.IsConditionSatisfied(ref argIndex9))
                {
                    arm = (int)(0.75d * arm);
                }
            }

            // 貫通型攻撃
            string argsptype3 = "貫通攻撃";
            string argattr2 = "貫";
            if (IsUnderSpecialPowerEffect(ref argsptype3))
            {
                arm = arm / 2;
            }
            else if (IsWeaponClassifiedAs(w, ref argattr2))
            {
                string argattr1 = "貫";
                if (IsWeaponLevelSpecified(w, ref argattr1))
                {
                    string argattr = "貫";
                    arm = (int)((long)(arm * (10d - WeaponLevel(w, ref argattr))) / 10L);
                }
                else
                {
                    arm = arm / 2;
                }
            }

            if (is_true_value | mpskill >= 140)
            {
                // 弱点
                if (t.Weakness(ref wclass))
                {
                    arm = arm / 2;
                }
                // 吸収する場合は装甲を無視して判定
                else if (!t.Effective(ref wclass) & t.Absorb(ref wclass))
                {
                    arm = 0;
                }
            }

            object argIndex11 = "防御補正";
            if (SRC.BCList.IsDefined(ref argIndex11))
            {
                // バトルコンフィグデータによる計算実行
                BCVariable.DataReset();
                BCVariable.MeUnit = t;
                BCVariable.AtkUnit = this;
                BCVariable.DefUnit = t;
                BCVariable.WeaponNumber = w;
                BCVariable.Armor = arm;
                BCVariable.TerrainAdaption = uadaption;
                string argIndex10 = "防御補正";
                arm = (int)SRC.BCList.Item(ref argIndex10).Calculate();
            }
            else
            {
                {
                    var withBlock = t.MainPilot();
                    // 気力による装甲修正
                    string argoname3 = "気力効果小";
                    if (Expression.IsOptionDefined(ref argoname3))
                    {
                        arm = arm * (50 + (withBlock.Morale + withBlock.MoraleMod) / 2) / 100;
                    }
                    else
                    {
                        arm = arm * (withBlock.Morale + withBlock.MoraleMod) / 100;
                    }

                    // レベルアップによる装甲修正＋耐久能力
                    arm = arm * withBlock.Defense / 100;
                }

                // 地形適応による装甲修正
                arm = (int)(arm * uadaption);
            }

            // ダメージ固定武器の場合は装甲と地形＆距離修正を無視
            string argstring2 = "固";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring2) > 0)
            {
                goto SkipDamageMod;
            }

            object argIndex13 = "ダメージ";
            if (SRC.BCList.IsDefined(ref argIndex13))
            {
                // バトルコンフィグデータによる計算実行
                // 事前にデータを登録
                BCVariable.DataReset();
                BCVariable.MeUnit = this;
                BCVariable.AtkUnit = this;
                BCVariable.DefUnit = t;
                BCVariable.WeaponNumber = w;
                BCVariable.AttackVariable = DamageRet;
                BCVariable.DffenceVariable = arm;
                if (Map.TerrainClass(t.x, t.y) == "月面")
                {
                    if (t.Area == "地上")
                    {
                        BCVariable.TerrainAdaption = (100 - Map.TerrainEffectForDamage(t.x, t.y)) / 100d;
                    }
                    else
                    {
                        BCVariable.TerrainAdaption = 1d;
                    }
                }
                else if (t.Area != "空中")
                {
                    BCVariable.TerrainAdaption = (100 - Map.TerrainEffectForDamage(t.x, t.y)) / 100d;
                }
                else
                {
                    BCVariable.TerrainAdaption = 1d;
                }

                string argIndex12 = "ダメージ";
                DamageRet = (int)SRC.BCList.Item(ref argIndex12).Calculate();
            }
            else
            {
                // 装甲値によってダメージを軽減
                DamageRet = DamageRet - arm;

                // 地形補正
                if (Map.TerrainClass(t.x, t.y) == "月面")
                {
                    if (t.Area == "地上")
                    {
                        DamageRet = (int)(DamageRet * ((100 - Map.TerrainEffectForDamage(t.x, t.y)) / 100d));
                    }
                }
                else if (t.Area != "空中")
                {
                    DamageRet = (int)(DamageRet * ((100 - Map.TerrainEffectForDamage(t.x, t.y)) / 100d));
                }
            }

            // 散属性武器は離れるほどダメージダウン
            string argstring21 = "散";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring21) > 0)
            {
                switch ((short)(Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y))))
                {
                    case 1:
                        {
                            break;
                        }
                    // 修正なし
                    case 2:
                        {
                            DamageRet = (int)(0.95d * DamageRet);
                            break;
                        }

                    case 3:
                        {
                            DamageRet = (int)(0.9d * DamageRet);
                            break;
                        }

                    case 4:
                        {
                            DamageRet = (int)(0.85d * DamageRet);
                            break;
                        }

                    default:
                        {
                            DamageRet = (int)(0.8d * DamageRet);
                            break;
                        }
                }
            }

            // 距離修正
            string argoname6 = "距離修正";
            if (Expression.IsOptionDefined(ref argoname6))
            {
                string argstring22 = "実";
                string argstring23 = "武";
                string argstring24 = "突";
                string argstring25 = "接";
                string argstring26 = "爆";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring22) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring23) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring24) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring25) == 0 & GeneralLib.InStrNotNest(ref wclass, ref argstring26) == 0)
                {
                    string argoname4 = "大型マップ";
                    string argoname5 = "小型マップ";
                    if (Expression.IsOptionDefined(ref argoname4))
                    {
                        switch ((short)(Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y))))
                        {
                            case var @case when 1 <= @case && @case <= 4:
                                {
                                    break;
                                }
                            // 修正なし
                            case 5:
                            case 6:
                                {
                                    DamageRet = (int)(0.95d * DamageRet);
                                    break;
                                }

                            case 7:
                            case 8:
                                {
                                    DamageRet = (int)(0.9d * DamageRet);
                                    break;
                                }

                            case 9:
                            case 10:
                                {
                                    DamageRet = (int)(0.85d * DamageRet);
                                    break;
                                }

                            default:
                                {
                                    DamageRet = (int)(0.8d * DamageRet);
                                    break;
                                }
                        }
                    }
                    else if (Expression.IsOptionDefined(ref argoname5))
                    {
                        switch ((short)(Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y))))
                        {
                            case 1:
                                {
                                    break;
                                }
                            // 修正なし
                            case 2:
                                {
                                    DamageRet = (int)(0.95d * DamageRet);
                                    break;
                                }

                            case 3:
                                {
                                    DamageRet = (int)(0.9d * DamageRet);
                                    break;
                                }

                            case 4:
                                {
                                    DamageRet = (int)(0.85d * DamageRet);
                                    break;
                                }

                            case 5:
                                {
                                    DamageRet = (int)(0.8d * DamageRet);
                                    break;
                                }

                            case 6:
                                {
                                    DamageRet = (int)(0.75d * DamageRet);
                                    break;
                                }

                            default:
                                {
                                    DamageRet = (int)(0.7d * DamageRet);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch ((short)(Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y))))
                        {
                            case var case1 when 1 <= case1 && case1 <= 3:
                                {
                                    break;
                                }
                            // 修正なし
                            case 4:
                                {
                                    DamageRet = (int)(0.95d * DamageRet);
                                    break;
                                }

                            case 5:
                                {
                                    DamageRet = (int)(0.9d * DamageRet);
                                    break;
                                }

                            case 6:
                                {
                                    DamageRet = (int)(0.85d * DamageRet);
                                    break;
                                }

                            default:
                                {
                                    DamageRet = (int)(0.8d * DamageRet);
                                    break;
                                }
                        }
                    }
                }
            }

        SkipDamageMod:
            ;


            // 封印攻撃は弱点もしくは有効を持つユニット以外には効かない
            string argstring27 = "封";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring27) > 0)
            {
                buf = t.strWeakness + t.strEffective;
                var loopTo2 = (short)Strings.Len(buf);
                for (i = 1; i <= loopTo2; i++)
                {
                    // 属性をひとまとめずつ取得
                    ch = GeneralLib.GetClassBundle(ref buf, ref i);
                    if (ch != "物" & ch != "魔")
                    {
                        if (GeneralLib.InStrNotNest(ref wclass, ref ch) > 0)
                        {
                            break;
                        }
                    }
                }

                if (i > Strings.Len(buf))
                {
                    DamageRet = 0;
                    return DamageRet;
                }
            }

            // 限定攻撃は指定属性に対して弱点もしくは有効を持つユニット以外には効かない
            string argstring28 = "限";
            idx = GeneralLib.InStrNotNest(ref wclass, ref argstring28);
            if (idx > 0)
            {
                buf = t.strWeakness + t.strEffective;
                var loopTo3 = (short)Strings.Len(buf);
                for (i = 1; i <= loopTo3; i++)
                {
                    // 属性をひとまとめずつ取得
                    ch = GeneralLib.GetClassBundle(ref buf, ref i);
                    if (ch != "物" & ch != "魔")
                    {
                        if (GeneralLib.InStrNotNest(ref wclass, ref ch) > idx)
                        {
                            break;
                        }
                    }
                }

                if (i > Strings.Len(buf))
                {
                    DamageRet = 0;
                    return DamageRet;
                }
            }

            // 特定レベル限定攻撃
            string argattr4 = "対";
            if (WeaponLevel(w, ref argattr4) > 0d)
            {
                // UPGRADE_WARNING: Mod に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                string argattr3 = "対";
                if (t.MainPilot().Level % WeaponLevel(w, ref argattr3) != 0d)
                {
                    DamageRet = 0;
                    return DamageRet;
                }
            }

            if (is_true_value | mpskill >= 140)
            {
                // 弱点、有効、吸収を優先
                if (!t.Weakness(ref wclass) & !t.Effective(ref wclass) & !t.Absorb(ref wclass))
                {
                    // 無効化
                    if (t.Immune(ref wclass))
                    {
                        DamageRet = 0;
                        return DamageRet;
                    }
                    // 耐性
                    else if (t.Resist(ref wclass))
                    {
                        DamageRet = DamageRet / 2;
                    }
                }
            }

            // 盲目状態には視覚攻撃は効かない
            if (is_true_value | mpskill >= 140)
            {
                string argstring29 = "視";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring29) > 0)
                {
                    object argIndex14 = "盲目";
                    if (t.IsConditionSatisfied(ref argIndex14))
                    {
                        DamageRet = 0;
                        return DamageRet;
                    }
                }
            }

            // 機械には精神攻撃は効かない
            if (is_true_value | mpskill >= 140)
            {
                string argstring210 = "精";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring210) > 0)
                {
                    if (t.MainPilot().Personality == "機械")
                    {
                        DamageRet = 0;
                        return DamageRet;
                    }
                }
            }

            // 性別限定武器
            string argstring211 = "♂";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring211) > 0)
            {
                if (t.MainPilot().Sex != "男性")
                {
                    DamageRet = 0;
                    return DamageRet;
                }
            }

            string argstring212 = "♀";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring212) > 0)
            {
                if (t.MainPilot().Sex != "女性")
                {
                    DamageRet = 0;
                    return DamageRet;
                }
            }

            // 寝こみを襲うとダメージ1.5倍
            object argIndex15 = "睡眠";
            if (t.IsConditionSatisfied(ref argIndex15))
            {
                DamageRet = (int)(1.5d * DamageRet);
            }

            {
                var withBlock1 = MainPilot();
                // 高気力時のダメージ増加能力
                if (withBlock1.Morale >= 130)
                {
                    string argoname7 = "ダメージ倍率低下";
                    if (Expression.IsOptionDefined(ref argoname7))
                    {
                        string argsname3 = "潜在力開放";
                        if (withBlock1.IsSkillAvailable(ref argsname3))
                        {
                            DamageRet = (int)(1.2d * DamageRet);
                        }

                        string argfname1 = "ブースト";
                        if (IsFeatureAvailable(ref argfname1))
                        {
                            DamageRet = (int)(1.2d * DamageRet);
                        }
                    }
                    else
                    {
                        string argsname4 = "潜在力開放";
                        if (withBlock1.IsSkillAvailable(ref argsname4))
                        {
                            DamageRet = (int)(1.25d * DamageRet);
                        }

                        string argfname2 = "ブースト";
                        if (IsFeatureAvailable(ref argfname2))
                        {
                            DamageRet = (int)(1.25d * DamageRet);
                        }
                    }
                }

                // 得意技
                string argsname5 = "得意技";
                if (withBlock1.IsSkillAvailable(ref argsname5))
                {
                    object argIndex16 = "得意技";
                    sdata = withBlock1.SkillData(ref argIndex16);
                    var loopTo4 = (short)Strings.Len(sdata);
                    for (i = 1; i <= loopTo4; i++)
                    {
                        string argstring213 = Strings.Mid(sdata, i, 1);
                        if (GeneralLib.InStrNotNest(ref wclass, ref argstring213) > 0)
                        {
                            DamageRet = (int)(1.2d * DamageRet);
                            break;
                        }
                    }
                }

                // 不得手
                string argsname6 = "不得手";
                if (withBlock1.IsSkillAvailable(ref argsname6))
                {
                    object argIndex17 = "不得手";
                    sdata = withBlock1.SkillData(ref argIndex17);
                    var loopTo5 = (short)Strings.Len(sdata);
                    for (i = 1; i <= loopTo5; i++)
                    {
                        string argstring214 = Strings.Mid(sdata, i, 1);
                        if (GeneralLib.InStrNotNest(ref wclass, ref argstring214) > 0)
                        {
                            DamageRet = (int)(0.8d * DamageRet);
                            break;
                        }
                    }
                }
            }

            // ハンター能力
            // (ターゲットのMainPilotを参照するため、「With .MainPilot」は使えない)
            string argsname7 = "ハンター";
            if (MainPilot().IsSkillAvailable(ref argsname7))
            {
                var loopTo6 = MainPilot().CountSkill();
                for (i = 1; i <= loopTo6; i++)
                {
                    object argIndex19 = i;
                    if (MainPilot().Skill(ref argIndex19) == "ハンター")
                    {
                        object argIndex18 = i;
                        sdata = MainPilot().SkillData(ref argIndex18);
                        var loopTo7 = GeneralLib.LLength(ref sdata);
                        for (j = 2; j <= loopTo7; j++)
                        {
                            tname = GeneralLib.LIndex(ref sdata, j);
                            if ((t.Name ?? "") == (tname ?? "") | (t.Class0 ?? "") == (tname ?? "") | (t.Size + "サイズ" ?? "") == (tname ?? "") | (t.MainPilot().Name ?? "") == (tname ?? "") | (t.MainPilot().Sex ?? "") == (tname ?? ""))
                            {
                                break;
                            }
                        }

                        if (j <= GeneralLib.LLength(ref sdata))
                        {
                            double localSkillLevel1() { object argIndex1 = i; string argref_mode = ""; var ret = MainPilot().SkillLevel(ref argIndex1, ref_mode: ref argref_mode); return ret; }

                            DamageRet = (int)((long)((10d + localSkillLevel1()) * DamageRet) / 10L);
                            break;
                        }
                    }
                }

                object argIndex22 = "ハンター付加";
                object argIndex23 = "ハンター付加２";
                if (IsConditionSatisfied(ref argIndex22) | IsConditionSatisfied(ref argIndex23))
                {
                    object argIndex20 = "ハンター";
                    sdata = MainPilot().SkillData(ref argIndex20);
                    var loopTo8 = GeneralLib.LLength(ref sdata);
                    for (i = 2; i <= loopTo8; i++)
                    {
                        tname = GeneralLib.LIndex(ref sdata, i);
                        if ((t.Name ?? "") == (tname ?? "") | (t.Class0 ?? "") == (tname ?? "") | (t.Size + "サイズ" ?? "") == (tname ?? "") | (t.MainPilot().Name ?? "") == (tname ?? "") | (t.MainPilot().Sex ?? "") == (tname ?? ""))
                        {
                            break;
                        }
                    }

                    if (i <= GeneralLib.LLength(ref sdata))
                    {
                        object argIndex21 = "ハンター";
                        string argref_mode2 = "";
                        DamageRet = (int)((long)((10d + MainPilot().SkillLevel(ref argIndex21, ref_mode: ref argref_mode2)) * DamageRet) / 10L);
                    }
                }
            }

            // スペシャルパワー、特殊状態によるダメージ増加
            dmg_mod = 1d;
            object argIndex24 = "攻撃力ＵＰ";
            object argIndex25 = "狂戦士";
            if (IsConditionSatisfied(ref argIndex24) | IsConditionSatisfied(ref argIndex25))
            {
                string argoname8 = "ダメージ倍率低下";
                if (Expression.IsOptionDefined(ref argoname8))
                {
                    dmg_mod = 1.2d;
                }
                else
                {
                    dmg_mod = 1.25d;
                }
            }
            // サポートアタックの場合はスペシャルパワーによる修正が無い
            if (!is_support_attack)
            {
                if (is_true_value | mpskill >= 160)
                {
                    // スペシャルパワーによるダメージ増加は特殊状態による増加と重複しない
                    string argsname8 = "ダメージ増加";
                    dmg_mod = GeneralLib.MaxDbl(dmg_mod, 1d + 0.1d * SpecialPowerEffectLevel(ref argsname8));
                    string argsname9 = "被ダメージ増加";
                    dmg_mod = dmg_mod + 0.1d * t.SpecialPowerEffectLevel(ref argsname9);
                }
            }

            DamageRet = (int)(dmg_mod * DamageRet);

            // スペシャルパワー、特殊状態、サポートアタックによるダメージ低下
            if (is_true_value | mpskill >= 160)
            {
                dmg_mod = 1d;
                string argsname10 = "ダメージ低下";
                dmg_mod = dmg_mod - 0.1d * SpecialPowerEffectLevel(ref argsname10);
                string argsname11 = "被ダメージ低下";
                dmg_mod = dmg_mod - 0.1d * t.SpecialPowerEffectLevel(ref argsname11);
                DamageRet = (int)(dmg_mod * DamageRet);
            }

            object argIndex26 = "攻撃力ＤＯＷＮ";
            if (IsConditionSatisfied(ref argIndex26))
            {
                DamageRet = (int)(0.75d * DamageRet);
            }

            object argIndex27 = "恐怖";
            if (IsConditionSatisfied(ref argIndex27))
            {
                DamageRet = (int)(0.8d * DamageRet);
            }

            if (is_support_attack)
            {
                // サポートアタックダメージ低下
                string argoname9 = "サポートアタックダメージ低下";
                if (Expression.IsOptionDefined(ref argoname9))
                {
                    DamageRet = (int)(0.7d * DamageRet);
                }
            }

            // レジスト能力
            dmg_mod = 0d;
            string argfname3 = "レジスト";
            if (!t.IsFeatureAvailable(ref argfname3))
            {
                goto SkipResist;
            }
            // ザコはレジストを考慮しない
            if (!is_true_value & mpskill < 150)
            {
                goto SkipResist;
            }

            var loopTo9 = t.CountFeature();
            for (i = 1; i <= loopTo9; i++)
            {
                object argIndex33 = i;
                if (t.Feature(ref argIndex33) == "レジスト")
                {
                    object argIndex28 = i;
                    fname = t.FeatureName0(ref argIndex28);
                    object argIndex29 = i;
                    fdata = t.FeatureData(ref argIndex29);
                    object argIndex30 = i;
                    flevel = t.FeatureLevel(ref argIndex30);

                    // 必要条件
                    if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 3)))
                    {
                        nmorale = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 3));
                    }
                    else
                    {
                        nmorale = 0;
                    }

                    // オプション
                    neautralize = false;
                    slevel = 0d;
                    var loopTo10 = GeneralLib.LLength(ref fdata);
                    for (j = 4; j <= loopTo10; j++)
                    {
                        opt = GeneralLib.LIndex(ref fdata, j);
                        idx = (short)Strings.InStr(opt, "*");
                        if (idx > 0)
                        {
                            string argexpr1 = Strings.Mid(opt, idx + 1);
                            lv_mod = GeneralLib.StrToDbl(ref argexpr1);
                            opt = Strings.Left(opt, idx - 1);
                        }
                        else
                        {
                            lv_mod = -1;
                        }

                        switch (opt ?? "")
                        {
                            case "能力必要":
                                {
                                    break;
                                }
                            // スキップ
                            case "同調率":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 0.5d;
                                    }

                                    slevel = lv_mod * (t.MainPilot().SynchroRate() - 30);
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == -30 * lv_mod)
                                        {
                                            neautralize = true;
                                        }
                                    }
                                    else if (slevel == -30 * lv_mod)
                                    {
                                        slevel = 0d;
                                    }

                                    break;
                                }

                            case "霊力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 0.2d;
                                    }

                                    slevel = lv_mod * t.MainPilot().Plana;
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "オーラ":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 5d;
                                    }

                                    slevel = lv_mod * t.AuraLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "超能力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 5d;
                                    }

                                    slevel = lv_mod * t.PsychicLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "超感覚":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 5d;
                                    }

                                    object argIndex31 = "超感覚";
                                    string argref_mode3 = "";
                                    object argIndex32 = "知覚強化";
                                    string argref_mode4 = "";
                                    slevel = lv_mod * (t.MainPilot().SkillLevel(ref argIndex31, ref_mode: ref argref_mode3) + t.MainPilot().SkillLevel(ref argIndex32, ref_mode: ref argref_mode4));
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            default:
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 5d;
                                    }

                                    double localSkillLevel2() { object argIndex1 = opt; string argref_mode = ""; var ret = t.MainPilot().SkillLevel(ref argIndex1, ref_mode: ref argref_mode); return ret; }

                                    slevel = lv_mod * localSkillLevel2();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }
                        }
                    }

                    // 発動可能？
                    bool localIsAttributeClassified1() { string argaclass1 = GeneralLib.LIndex(ref fdata, 2); var ret = t.IsAttributeClassified(ref argaclass1, ref wclass); return ret; }

                    if (t.MainPilot().Morale >= nmorale & localIsAttributeClassified1() & !neautralize)
                    {
                        // レジスト発動
                        dmg_mod = dmg_mod + 10d * flevel + slevel;
                    }
                }
            }

            DamageRet = (int)((long)(DamageRet * (100d - dmg_mod)) / 100L);
        SkipResist:
            ;
            object argIndex35 = "最終ダメージ";
            if (SRC.BCList.IsDefined(ref argIndex35))
            {
                // バトルコンフィグデータによる計算実行
                BCVariable.DataReset();
                BCVariable.MeUnit = this;
                BCVariable.AtkUnit = this;
                BCVariable.DefUnit = t;
                BCVariable.WeaponNumber = w;
                BCVariable.LastVariable = DamageRet;
                string argIndex34 = "最終ダメージ";
                DamageRet = (int)SRC.BCList.Item(ref argIndex34).Calculate();
            }

            // 最低ダメージは10
            if (dmg_mod < 100d)
            {
                if (DamageRet < 10)
                {
                    // MOD START MARGE
                    // Damage = 10
                    string argoname10 = "ダメージ下限解除";
                    string argoname11 = "ダメージ下限１";
                    if (Expression.IsOptionDefined(ref argoname10))
                    {
                        DamageRet = GeneralLib.MaxLng(DamageRet, 0);
                    }
                    else if (Expression.IsOptionDefined(ref argoname11))
                    {
                        DamageRet = GeneralLib.MaxLng(DamageRet, 1);
                    }
                    else
                    {
                        DamageRet = 10;
                    }
                    // MOD END MARGE
                }
            }

            // ダメージを吸収する場合は最後に反転
            if (is_true_value | mpskill >= 140)
            {
                // 弱点、有効を優先
                if (!t.Weakness(ref wclass) & !t.Effective(ref wclass))
                {
                    // 吸収
                    if (DamageRet > 0 & t.Absorb(ref wclass))
                    {
                        DamageRet = -DamageRet / 2;
                    }
                }
            }

            return DamageRet;
        }

        // クリティカルの発生率
        public short CriticalProbability(short w, ref Unit t, string def_mode = "")
        {
            short CriticalProbabilityRet = default;
            short i, prob, idx;
            string wclass;
            string buf, c;
            var is_special = default(bool);
            // クリティカル攻撃、防御の一時保存変数
            short ed_crtatk, ed_crtdfe;
            if (IsNormalWeapon(w))
            {
                // 通常攻撃

                // スペシャルパワーとの効果の重ね合わせが禁止されている場合
                string argoname = "スペシャルパワー使用時クリティカル無効";
                string argoname1 = "精神コマンド使用時クリティカル無効";
                if (Expression.IsOptionDefined(ref argoname) | Expression.IsOptionDefined(ref argoname1))
                {
                    string argsptype = "ダメージ増加";
                    if (IsUnderSpecialPowerEffect(ref argsptype))
                    {
                        return CriticalProbabilityRet;
                    }
                }

                // 攻撃側による補正
                object argIndex2 = "クリティカル攻撃補正";
                if (SRC.BCList.IsDefined(ref argIndex2))
                {
                    // バトルコンフィグデータの設定による修正
                    // 一時保存変数に一時保存
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = this;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    BCVariable.AttackExp = WeaponCritical(w);
                    string argIndex1 = "クリティカル攻撃補正";
                    ed_crtatk = (short)SRC.BCList.Item(ref argIndex1).Calculate();
                }
                else
                {
                    // 一時保存変数に一時保存
                    ed_crtatk = (short)(WeaponCritical(w) + this.MainPilot().Technique);
                }

                // 防御側による補正
                object argIndex4 = "クリティカル防御補正";
                if (SRC.BCList.IsDefined(ref argIndex4))
                {
                    // バトルコンフィグデータの設定による修正
                    // 一時保存変数に一時保存
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = t;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    string argIndex3 = "クリティカル防御補正";
                    ed_crtdfe = (short)SRC.BCList.Item(ref argIndex3).Calculate();
                }
                else
                {
                    // 一時保存変数に一時保存
                    ed_crtdfe = t.MainPilot().Technique;
                }

                // クリティカル発生率計算
                object argIndex6 = "クリティカル発生率";
                if (SRC.BCList.IsDefined(ref argIndex6))
                {
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = this;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    BCVariable.AttackVariable = ed_crtatk;
                    BCVariable.DffenceVariable = ed_crtdfe;
                    string argIndex5 = "クリティカル発生率";
                    prob = (short)SRC.BCList.Item(ref argIndex5).Calculate();
                }
                else
                {
                    prob = (short)(ed_crtatk - ed_crtdfe);
                }

                // 超反応による修正
                object argIndex7 = "超反応";
                string argref_mode = "";
                object argIndex8 = "超反応";
                string argref_mode1 = "";
                prob = (short)(prob + 2d * MainPilot().SkillLevel(ref argIndex7, ref_mode: ref argref_mode) - 2d * t.MainPilot().SkillLevel(ref argIndex8, ref_mode: ref argref_mode1));

                // 超能力による修正
                string argsname = "超能力";
                if (MainPilot().IsSkillAvailable(ref argsname))
                {
                    prob = (short)(prob + 5);
                }

                // 底力、超底力、覚悟による修正
                if (HP <= MaxHP / 4)
                {
                    string argsname1 = "底力";
                    string argsname2 = "超底力";
                    string argsname3 = "覚悟";
                    if (MainPilot().IsSkillAvailable(ref argsname1) | MainPilot().IsSkillAvailable(ref argsname2) | MainPilot().IsSkillAvailable(ref argsname3))
                    {
                        prob = (short)(prob + 50);
                    }
                }

                // スペシャルパワーにる修正
                string argsname4 = "クリティカル率増加";
                prob = (short)(prob + 10d * SpecialPowerEffectLevel(ref argsname4));
            }
            else
            {
                // 特殊効果を伴う攻撃
                is_special = true;

                // 攻撃側による補正
                object argIndex10 = "特殊効果攻撃補正";
                if (SRC.BCList.IsDefined(ref argIndex10))
                {
                    // バトルコンフィグデータの設定による修正
                    // 一時保存変数に一時保存
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = this;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    BCVariable.AttackExp = WeaponCritical(w);
                    string argIndex9 = "特殊効果攻撃補正";
                    ed_crtatk = (short)SRC.BCList.Item(ref argIndex9).Calculate();
                }
                else
                {
                    // 一時保存変数に一時保存
                    ed_crtatk = (short)(WeaponCritical(w) + this.MainPilot().Technique / 2);
                }

                // 防御側による補正
                object argIndex12 = "特殊効果防御補正";
                if (SRC.BCList.IsDefined(ref argIndex12))
                {
                    // バトルコンフィグデータの設定による修正
                    // 一時保存変数に一時保存
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = t;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    // 特殊効果の場合は相手がザコの時に確率が増加
                    if (Strings.InStr(t.MainPilot().Name, "(ザコ)") > 0)
                    {
                        BCVariable.CommonEnemy = 30;
                    }

                    string argIndex11 = "特殊効果防御補正";
                    ed_crtdfe = (short)SRC.BCList.Item(ref argIndex11).Calculate();
                }
                else
                {
                    // 一時保存変数に一時保存
                    ed_crtdfe = (short)(t.MainPilot().Technique / 2);

                    // 特殊効果の場合は相手がザコの時に確率が増加
                    if (Strings.InStr(t.MainPilot().Name, "(ザコ)") > 0)
                    {
                        // 一時保存変数に一時保存
                        ed_crtdfe = (short)(ed_crtdfe - 30);
                    }
                }

                // 特殊効果発生率計算
                object argIndex14 = "特殊効果発生率";
                if (SRC.BCList.IsDefined(ref argIndex14))
                {
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = this;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    BCVariable.AttackVariable = ed_crtatk;
                    BCVariable.DffenceVariable = ed_crtdfe;
                    string argIndex13 = "特殊効果発生率";
                    prob = (short)SRC.BCList.Item(ref argIndex13).Calculate();
                }
                else
                {
                    prob = (short)(ed_crtatk - ed_crtdfe);
                }

                // 抵抗力による修正
                object argIndex15 = "抵抗力";
                prob = (short)(prob - 10d * t.FeatureLevel(ref argIndex15));
            }

            // 不意打ち
            string argfname = "ステルス";
            object argIndex16 = "ステルス無効";
            string argfname1 = "ステルス無効化";
            string argattr = "忍";
            if (IsFeatureAvailable(ref argfname) & !IsConditionSatisfied(ref argIndex16) & !t.IsFeatureAvailable(ref argfname1) & IsWeaponClassifiedAs(w, ref argattr))
            {
                prob = (short)(prob + 10);
            }

            // 相手が動けなければ確率アップ
            object argIndex17 = "行動不能";
            object argIndex18 = "石化";
            object argIndex19 = "凍結";
            object argIndex20 = "麻痺";
            object argIndex21 = "睡眠";
            string argsptype1 = "行動不能";
            if (t.IsConditionSatisfied(ref argIndex17) | t.IsConditionSatisfied(ref argIndex18) | t.IsConditionSatisfied(ref argIndex19) | t.IsConditionSatisfied(ref argIndex20) | t.IsConditionSatisfied(ref argIndex21) | t.IsUnderSpecialPowerEffect(ref argsptype1))
            {
                prob = (short)(prob + 10);
            }

            // 以下の修正は特殊効果発動確率にのみ影響
            if (is_special)
            {
                wclass = WeaponClass(w);

                // 封印攻撃は弱点、有効を持つユニット以外には効かない
                string argstring2 = "封";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring2) > 0)
                {
                    buf = t.strWeakness + t.strEffective;
                    var loopTo = (short)Strings.Len(buf);
                    for (i = 1; i <= loopTo; i++)
                    {
                        // 属性をひとまとめずつ取得
                        c = GeneralLib.GetClassBundle(ref buf, ref i);
                        if (c != "物" & c != "魔")
                        {
                            if (GeneralLib.InStrNotNest(ref wclass, ref c) > 0)
                            {
                                break;
                            }
                        }
                    }

                    if (i > Strings.Len(buf))
                    {
                        CriticalProbabilityRet = 0;
                        return CriticalProbabilityRet;
                    }
                }

                // 限定攻撃は弱点、有効を持つユニット以外には効かない
                string argstring21 = "限";
                idx = GeneralLib.InStrNotNest(ref wclass, ref argstring21);
                if (idx > 0)
                {
                    buf = t.strWeakness + t.strEffective;
                    var loopTo1 = (short)Strings.Len(buf);
                    for (i = 1; i <= loopTo1; i++)
                    {
                        // 属性をひとまとめずつ取得
                        c = GeneralLib.GetClassBundle(ref buf, ref i);
                        if (c != "物" & c != "魔")
                        {
                            if (GeneralLib.InStrNotNest(ref wclass, ref c) > idx)
                            {
                                break;
                            }
                        }
                    }

                    if (i > Strings.Len(buf))
                    {
                        CriticalProbabilityRet = 0;
                        return CriticalProbabilityRet;
                    }
                }

                // 特定レベル限定攻撃
                string argstring22 = "対";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring22) > 0)
                {
                    // UPGRADE_WARNING: Mod に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                    string argattr1 = "対";
                    if (t.MainPilot().Level % WeaponLevel(w, ref argattr1) != 0d)
                    {
                        CriticalProbabilityRet = 0;
                        return CriticalProbabilityRet;
                    }
                }

                // クリティカル率については、
                // 弱、効属性の指定属性に対しての防御特性を考慮する。
                buf = "";
                string argstring23 = "弱";
                i = GeneralLib.InStrNotNest(ref wclass, ref argstring23);
                while (i > 0)
                {
                    buf = buf + Strings.Mid(GeneralLib.GetClassBundle(ref wclass, ref i), 2);
                    string argstring24 = "弱";
                    i = GeneralLib.InStrNotNest(ref wclass, ref argstring24, (short)(i + 1));
                }

                string argstring25 = "効";
                i = GeneralLib.InStrNotNest(ref wclass, ref argstring25);
                while (i > 0)
                {
                    buf = buf + Strings.Mid(GeneralLib.GetClassBundle(ref wclass, ref i), 2);
                    string argstring26 = "効";
                    i = GeneralLib.InStrNotNest(ref wclass, ref argstring26, (short)(i + 1));
                }

                buf = buf + wclass;

                // 弱点
                // 変化なし
                // 封印技
                string argstring27 = "封";
                // 限定技
                string argstring28 = "限";
                if (t.Weakness(ref buf))
                {
                    prob = (short)(prob + 10);
                }
                // 有効
                else if (t.Effective(ref buf))
                {
                }
                else if (GeneralLib.InStrNotNest(ref wclass, ref argstring27) > 0)
                {
                    CriticalProbabilityRet = 0;
                    return CriticalProbabilityRet;
                }
                else if (GeneralLib.InStrNotNest(ref wclass, ref argstring28) > 0)
                {
                    CriticalProbabilityRet = 0;
                    return CriticalProbabilityRet;
                }
                // 吸収
                else if (t.Absorb(ref buf))
                {
                    CriticalProbabilityRet = 0;
                    return CriticalProbabilityRet;
                }
                // 無効化
                else if (t.Immune(ref buf))
                {
                    CriticalProbabilityRet = 0;
                    return CriticalProbabilityRet;
                }
                // 耐性
                else if (t.Resist(ref buf))
                {
                    prob = (short)(prob / 2);
                }

                // 盲目状態には視覚攻撃は効かない
                string argstring29 = "視";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring29) > 0)
                {
                    object argIndex22 = "盲目";
                    if (t.IsConditionSatisfied(ref argIndex22))
                    {
                        CriticalProbabilityRet = 0;
                        return CriticalProbabilityRet;
                    }
                }

                // 機械には精神攻撃は効かない
                string argstring210 = "精";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring210) > 0)
                {
                    if (t.MainPilot().Personality == "機械")
                    {
                        CriticalProbabilityRet = 0;
                        return CriticalProbabilityRet;
                    }
                }

                // 性別限定武器
                string argstring211 = "♂";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring211) > 0)
                {
                    if (t.MainPilot().Sex != "男性")
                    {
                        CriticalProbabilityRet = 0;
                        return CriticalProbabilityRet;
                    }
                }

                string argstring212 = "♀";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring212) > 0)
                {
                    if (t.MainPilot().Sex != "女性")
                    {
                        CriticalProbabilityRet = 0;
                        return CriticalProbabilityRet;
                    }
                }
            }

            // 防御時はクリティカル発生確率が半減
            if (def_mode == "防御")
            {
                prob = (short)(prob / 2);
            }

            // 最終クリティカル/特殊効果を定義する。これがないときは何もしない
            if (IsNormalWeapon(w))
            {
                // クリティカル
                object argIndex24 = "最終クリティカル発生率";
                if (SRC.BCList.IsDefined(ref argIndex24))
                {
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = this;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    BCVariable.LastVariable = prob;
                    string argIndex23 = "最終クリティカル発生率";
                    prob = (short)SRC.BCList.Item(ref argIndex23).Calculate();
                }
            }
            else
            {
                // 特殊効果
                object argIndex26 = "最終特殊効果発生率";
                if (SRC.BCList.IsDefined(ref argIndex26))
                {
                    // 事前にデータを登録
                    BCVariable.DataReset();
                    BCVariable.MeUnit = this;
                    BCVariable.AtkUnit = this;
                    BCVariable.DefUnit = t;
                    BCVariable.WeaponNumber = w;
                    BCVariable.LastVariable = prob;
                    string argIndex25 = "最終特殊効果発生率";
                    prob = (short)SRC.BCList.Item(ref argIndex25).Calculate();
                }
            }

            if (prob > 100)
            {
                CriticalProbabilityRet = 100;
            }
            else if (prob < 1)
            {
                CriticalProbabilityRet = 1;
            }
            else
            {
                CriticalProbabilityRet = prob;
            }

            return CriticalProbabilityRet;
        }

        // 武器wでユニットtに攻撃をかけた時のダメージの期待値
        public int ExpDamage(short w, ref Unit t, bool is_true_value, double dmg_mod = 0d)
        {
            int ExpDamageRet = default;
            int dmg;
            short j, i, idx;
            double slevel;
            string wclass;
            string fname, fdata;
            double flevel;
            int ecost, nmorale;
            bool neautralize;
            double lv_mod;
            string opt;
            wclass = WeaponClass(w);

            // 攻撃力が0であれば常にダメージ0
            string argtarea = "";
            if (WeaponPower(w, ref argtarea) <= 0)
            {
                return ExpDamageRet;
            }

            // ダメージ
            dmg = Damage(w, ref t, is_true_value);

            // ダメージに修正を加える場合
            if (dmg_mod > 0d)
            {
                string argstring2 = "殺";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring2) == 0)
                {
                    dmg = (int)(dmg * dmg_mod);
                }
            }

            // 抹殺攻撃は一撃で相手を倒せない限り効果がない
            string argstring21 = "殺";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring21) > 0)
            {
                if (t.HP > dmg)
                {
                    return ExpDamageRet;
                }
            }

            // ダメージが与えられない場合
            if (dmg <= 0)
            {
                // 地形適応や封印武器、限定武器、性別限定武器、無効化、吸収が原因であれば期待値は0
                string argstring22 = "封";
                string argstring23 = "限";
                string argstring24 = "♂";
                string argstring25 = "♀";
                if (WeaponAdaption(w, ref t.Area) == 0d | GeneralLib.InStrNotNest(ref wclass, ref argstring22) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring23) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring24) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring25) > 0 | t.Immune(ref wclass) | t.Absorb(ref wclass))
                {
                    return ExpDamageRet;
                }

                // それ以外の要因であればダミーでダメージwとする。
                // こうしておかないと敵が攻撃が無駄の場合はまったく自分から
                // 攻撃しなくなってしまうので。
                // 単純にExpDamage=1などとしないのは攻撃力の高い武器を優先させて使わせるため
                ExpDamageRet = w;
                return ExpDamageRet;
            }

            // バリア無効化
            string argstring27 = "無";
            string argsptype = "防御能力無効化";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring27) > 0 | IsUnderSpecialPowerEffect(ref argsptype))
            {
                // 抹殺攻撃は一撃で相手を倒せない限り効果がない
                string argstring26 = "殺";
                if (GeneralLib.InStrNotNest(ref wclass, ref argstring26) > 0)
                {
                    if (t.HP > dmg)
                    {
                        return ExpDamageRet;
                    }
                }

                ExpDamageRet = dmg;
                return ExpDamageRet;
            }

            // 技量の低い敵はバリアを考慮せず攻撃をかける
            {
                var withBlock = MainPilot();
                if (!is_true_value & withBlock.TacticalTechnique() < 150)
                {
                    // 抹殺攻撃は一撃で相手を倒せない限り効果がない
                    string argstring28 = "殺";
                    if (GeneralLib.InStrNotNest(ref wclass, ref argstring28) > 0)
                    {
                        if (t.HP > dmg)
                        {
                            return ExpDamageRet;
                        }
                    }

                    ExpDamageRet = dmg;
                    return ExpDamageRet;
                }
            }
            // バリア能力
            var loopTo = t.CountFeature();
            for (i = 1; i <= loopTo; i++)
            {
                object argIndex8 = i;
                if (t.Feature(ref argIndex8) == "バリア")
                {
                    object argIndex1 = i;
                    fname = t.FeatureName0(ref argIndex1);
                    object argIndex2 = i;
                    fdata = t.FeatureData(ref argIndex2);
                    object argIndex3 = i;
                    flevel = t.FeatureLevel(ref argIndex3);

                    // 必要条件
                    if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 3)))
                    {
                        ecost = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 3));
                    }
                    else
                    {
                        ecost = 10;
                    }

                    if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 4)))
                    {
                        nmorale = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 4));
                    }
                    else
                    {
                        nmorale = 0;
                    }

                    // オプション
                    neautralize = false;
                    slevel = 0d;
                    var loopTo1 = GeneralLib.LLength(ref fdata);
                    for (j = 5; j <= loopTo1; j++)
                    {
                        opt = GeneralLib.LIndex(ref fdata, j);
                        idx = (short)Strings.InStr(opt, "*");
                        if (idx > 0)
                        {
                            string argexpr = Strings.Mid(opt, idx + 1);
                            lv_mod = GeneralLib.StrToDbl(ref argexpr);
                            opt = Strings.Left(opt, idx - 1);
                        }
                        else
                        {
                            lv_mod = -1;
                        }

                        switch (opt ?? "")
                        {
                            case "相殺":
                                {
                                    object argIndex4 = "バリア";
                                    string argfdata2 = FeatureData(ref argIndex4);
                                    if (IsSameCategory(ref fdata, ref argfdata2) & Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y)) == 1)
                                    {
                                        neautralize = true;
                                    }

                                    break;
                                }

                            case "中和":
                                {
                                    object argIndex6 = "バリア";
                                    string argfdata21 = FeatureData(ref argIndex6);
                                    if (IsSameCategory(ref fdata, ref argfdata21) & Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y)) == 1)
                                    {
                                        object argIndex5 = "バリア";
                                        flevel = flevel - FeatureLevel(ref argIndex5);
                                        if (flevel <= 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "近接無効":
                                {
                                    string argstring29 = "武";
                                    string argstring210 = "突";
                                    string argstring211 = "接";
                                    if (GeneralLib.InStrNotNest(ref wclass, ref argstring29) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring210) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring211) > 0)
                                    {
                                        neautralize = true;
                                    }

                                    break;
                                }

                            case "手動":
                                {
                                    neautralize = true;
                                    break;
                                }

                            case "能力必要":
                                {
                                    break;
                                }
                            // スキップ
                            case "同調率":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 20d;
                                    }

                                    slevel = lv_mod * (t.SyncLevel() - 30d);
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == -30 * lv_mod)
                                        {
                                            neautralize = true;
                                        }
                                    }
                                    else if (slevel == -30 * lv_mod)
                                    {
                                        slevel = 0d;
                                    }

                                    break;
                                }

                            case "霊力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 10d;
                                    }

                                    slevel = lv_mod * t.PlanaLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "オーラ":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 200d;
                                    }

                                    slevel = lv_mod * t.AuraLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "超能力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 200d;
                                    }

                                    slevel = lv_mod * t.PsychicLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            default:
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 200d;
                                    }

                                    slevel = lv_mod * t.SkillLevel(opt);
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }
                        }
                    }

                    // バリア無効化で無効化されている？
                    object argIndex7 = "バリア無効化";
                    if (t.IsConditionSatisfied(ref argIndex7))
                    {
                        if (Strings.InStr(fdata, "バリア無効化無効") == 0)
                        {
                            neautralize = true;
                        }
                    }

                    // 発動可能？
                    bool localIsAttributeClassified() { string argaclass1 = GeneralLib.LIndex(ref fdata, 2); var ret = t.IsAttributeClassified(ref argaclass1, ref wclass); return ret; }

                    if (t.EN >= ecost & t.MainPilot().Morale >= nmorale & localIsAttributeClassified() & !neautralize)
                    {
                        // バリア発動
                        if (dmg <= 1000d * flevel + slevel)
                        {
                            ExpDamageRet = w;
                            return ExpDamageRet;
                        }
                    }
                }
            }

            // フィールド能力
            var loopTo2 = t.CountFeature();
            for (i = 1; i <= loopTo2; i++)
            {
                object argIndex16 = i;
                if (t.Feature(ref argIndex16) == "フィールド")
                {
                    object argIndex9 = i;
                    fname = t.FeatureName0(ref argIndex9);
                    object argIndex10 = i;
                    fdata = t.FeatureData(ref argIndex10);
                    object argIndex11 = i;
                    flevel = t.FeatureLevel(ref argIndex11);

                    // 必要条件
                    if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 3)))
                    {
                        ecost = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 3));
                    }
                    else
                    {
                        ecost = 0;
                    }

                    if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 4)))
                    {
                        nmorale = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 4));
                    }
                    else
                    {
                        nmorale = 0;
                    }

                    // オプション
                    neautralize = false;
                    slevel = 0d;
                    var loopTo3 = GeneralLib.LLength(ref fdata);
                    for (j = 5; j <= loopTo3; j++)
                    {
                        opt = GeneralLib.LIndex(ref fdata, j);
                        idx = (short)Strings.InStr(opt, "*");
                        if (idx > 0)
                        {
                            string argexpr1 = Strings.Mid(opt, idx + 1);
                            lv_mod = GeneralLib.StrToDbl(ref argexpr1);
                            opt = Strings.Left(opt, idx - 1);
                        }
                        else
                        {
                            lv_mod = -1;
                        }

                        switch (opt ?? "")
                        {
                            case "相殺":
                                {
                                    object argIndex12 = "フィールド";
                                    string argfdata22 = FeatureData(ref argIndex12);
                                    if (IsSameCategory(ref fdata, ref argfdata22) & Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y)) == 1)
                                    {
                                        neautralize = true;
                                    }

                                    break;
                                }

                            case "中和":
                                {
                                    object argIndex14 = "フィールド";
                                    string argfdata23 = FeatureData(ref argIndex14);
                                    if (IsSameCategory(ref fdata, ref argfdata23) & Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y)) == 1)
                                    {
                                        object argIndex13 = "フィールド";
                                        flevel = flevel - FeatureLevel(ref argIndex13);
                                        if (flevel <= 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "近接無効":
                                {
                                    string argstring212 = "武";
                                    string argstring213 = "突";
                                    string argstring214 = "接";
                                    if (GeneralLib.InStrNotNest(ref wclass, ref argstring212) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring213) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring214) > 0)
                                    {
                                        neautralize = true;
                                    }

                                    break;
                                }

                            case "手動":
                                {
                                    neautralize = true;
                                    break;
                                }

                            case "能力必要":
                                {
                                    break;
                                }
                            // スキップ
                            case "同調率":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 20d;
                                    }

                                    slevel = lv_mod * (t.SyncLevel() - 30d);
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == -30 * lv_mod)
                                        {
                                            neautralize = true;
                                        }
                                    }
                                    else if (slevel == -30 * lv_mod)
                                    {
                                        slevel = 0d;
                                    }

                                    break;
                                }

                            case "霊力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 10d;
                                    }

                                    slevel = lv_mod * t.PlanaLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "オーラ":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 200d;
                                    }

                                    slevel = lv_mod * t.AuraLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "超能力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 200d;
                                    }

                                    slevel = lv_mod * t.PsychicLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            default:
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 200d;
                                    }

                                    slevel = lv_mod * t.SkillLevel(opt);
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }
                        }
                    }

                    // バリア無効化で無効化されている？
                    object argIndex15 = "バリア無効化";
                    if (t.IsConditionSatisfied(ref argIndex15))
                    {
                        if (Strings.InStr(fdata, "バリア無効化無効") == 0)
                        {
                            neautralize = true;
                        }
                    }

                    // 発動可能？
                    bool localIsAttributeClassified1() { string argaclass1 = GeneralLib.LIndex(ref fdata, 2); var ret = t.IsAttributeClassified(ref argaclass1, ref wclass); return ret; }

                    if (t.EN >= ecost & t.MainPilot().Morale >= nmorale & localIsAttributeClassified1() & !neautralize)
                    {
                        // フィールド発動
                        if (dmg <= 500d * flevel + slevel)
                        {
                            ExpDamageRet = w;
                            return ExpDamageRet;
                        }
                        else if (flevel > 0d | slevel > 0d)
                        {
                            dmg = (int)(dmg - 500d * flevel - slevel);
                        }
                    }
                }
            }

            // プロテクション能力
            var loopTo4 = t.CountFeature();
            for (i = 1; i <= loopTo4; i++)
            {
                object argIndex24 = i;
                if (t.Feature(ref argIndex24) == "プロテクション")
                {
                    object argIndex17 = i;
                    fname = t.FeatureName0(ref argIndex17);
                    object argIndex18 = i;
                    fdata = t.FeatureData(ref argIndex18);
                    object argIndex19 = i;
                    flevel = t.FeatureLevel(ref argIndex19);

                    // 必要条件
                    if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 3)))
                    {
                        ecost = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 3));
                    }
                    else
                    {
                        ecost = 10;
                    }

                    if (Information.IsNumeric(GeneralLib.LIndex(ref fdata, 4)))
                    {
                        nmorale = Conversions.ToShort(GeneralLib.LIndex(ref fdata, 4));
                    }
                    else
                    {
                        nmorale = 0;
                    }

                    // オプション
                    neautralize = false;
                    slevel = 0d;
                    var loopTo5 = GeneralLib.LLength(ref fdata);
                    for (j = 5; j <= loopTo5; j++)
                    {
                        opt = GeneralLib.LIndex(ref fdata, j);
                        idx = (short)Strings.InStr(opt, "*");
                        if (idx > 0)
                        {
                            string argexpr2 = Strings.Mid(opt, idx + 1);
                            lv_mod = GeneralLib.StrToDbl(ref argexpr2);
                            opt = Strings.Left(opt, idx - 1);
                        }
                        else
                        {
                            lv_mod = -1;
                        }

                        switch (opt ?? "")
                        {
                            case "相殺":
                                {
                                    object argIndex20 = "プロテクション";
                                    string argfdata24 = FeatureData(ref argIndex20);
                                    if (IsSameCategory(ref fdata, ref argfdata24) & Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y)) == 1)
                                    {
                                        neautralize = true;
                                    }

                                    break;
                                }

                            case "中和":
                                {
                                    object argIndex22 = "プロテクション";
                                    string argfdata25 = FeatureData(ref argIndex22);
                                    if (IsSameCategory(ref fdata, ref argfdata25) & Math.Abs((short)(x - t.x)) + Math.Abs((short)(y - t.y)) == 1)
                                    {
                                        object argIndex21 = "プロテクション";
                                        flevel = flevel - FeatureLevel(ref argIndex21);
                                        if (flevel <= 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "近接無効":
                                {
                                    string argstring215 = "武";
                                    string argstring216 = "突";
                                    string argstring217 = "接";
                                    if (GeneralLib.InStrNotNest(ref wclass, ref argstring215) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring216) > 0 | GeneralLib.InStrNotNest(ref wclass, ref argstring217) > 0)
                                    {
                                        neautralize = true;
                                    }

                                    break;
                                }

                            case "手動":
                                {
                                    neautralize = true;
                                    break;
                                }

                            case "能力必要":
                                {
                                    break;
                                }
                            // スキップ
                            case "同調率":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 0.5d;
                                    }

                                    slevel = lv_mod * (t.SyncLevel() - 30d);
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == -30 * lv_mod)
                                        {
                                            neautralize = true;
                                        }
                                    }
                                    else if (slevel == -30 * lv_mod)
                                    {
                                        slevel = 0d;
                                    }

                                    break;
                                }

                            case "霊力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 0.2d;
                                    }

                                    slevel = lv_mod * t.PlanaLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "オーラ":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 5d;
                                    }

                                    slevel = lv_mod * t.AuraLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            case "超能力":
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 5d;
                                    }

                                    slevel = lv_mod * t.PsychicLevel();
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }

                            default:
                                {
                                    if (lv_mod == -1)
                                    {
                                        lv_mod = 5d;
                                    }

                                    slevel = lv_mod * t.SkillLevel(opt);
                                    if (Strings.InStr(fdata, "能力必要") > 0)
                                    {
                                        if (slevel == 0d)
                                        {
                                            neautralize = true;
                                        }
                                    }

                                    break;
                                }
                        }
                    }

                    // バリア無効化で無効化されている？
                    object argIndex23 = "バリア無効化";
                    if (t.IsConditionSatisfied(ref argIndex23))
                    {
                        if (Strings.InStr(fdata, "バリア無効化無効") == 0)
                        {
                            neautralize = true;
                        }
                    }

                    // 発動可能？
                    bool localIsAttributeClassified2() { string argaclass1 = GeneralLib.LIndex(ref fdata, 2); var ret = t.IsAttributeClassified(ref argaclass1, ref wclass); return ret; }

                    if (t.EN >= ecost & t.MainPilot().Morale >= nmorale & localIsAttributeClassified2() & !neautralize)
                    {
                        // プロテクション発動
                        dmg = (int)((long)(dmg * (100d - 10d * flevel - slevel)) / 100L);
                        if (dmg <= 0)
                        {
                            ExpDamageRet = w;
                            return ExpDamageRet;
                        }
                    }
                }
            }

            // 対ビーム用防御能力
            string argstring218 = "Ｂ";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring218) > 0)
            {
                // ビーム吸収
                string argfname = "ビーム吸収";
                if (t.IsFeatureAvailable(ref argfname))
                {
                    ExpDamageRet = w;
                    return ExpDamageRet;
                }
            }

            // 抹殺攻撃は一撃で相手を倒せる場合にのみ有効
            string argstring219 = "殺";
            if (GeneralLib.InStrNotNest(ref wclass, ref argstring219) > 0)
            {
                if (dmg < t.HP)
                {
                    dmg = 0;
                }
            }

            // 盾防御
            string argfname1 = "盾";
            string argsname = "Ｓ防御";
            string argattr1 = "精";
            string argattr2 = "浸";
            string argattr3 = "殺";
            object argIndex27 = "盾付加";
            object argIndex28 = "盾";
            object argIndex29 = "盾ダメージ";
            if (t.IsFeatureAvailable(ref argfname1) & t.MainPilot().IsSkillAvailable(ref argsname) & t.MaxAction() > 0 & !IsWeaponClassifiedAs(w, ref argattr1) & !IsWeaponClassifiedAs(w, ref argattr2) & !IsWeaponClassifiedAs(w, ref argattr3) & (t.IsConditionSatisfied(ref argIndex27) | t.FeatureLevel(ref argIndex28) > t.ConditionLevel(ref argIndex29)))
            {
                string argattr = "破";
                if (IsWeaponClassifiedAs(w, ref argattr))
                {
                    object argIndex25 = "Ｓ防御";
                    string argref_mode = "";
                    dmg = (int)(dmg - 50d * (t.MainPilot().SkillLevel(ref argIndex25, ref_mode: ref argref_mode) + 4d));
                }
                else
                {
                    object argIndex26 = "Ｓ防御";
                    string argref_mode1 = "";
                    dmg = (int)(dmg - 100d * (t.MainPilot().SkillLevel(ref argIndex26, ref_mode: ref argref_mode1) + 4d));
                }
            }

            // ダメージが減少されて0以下になった場合もダミーで1ダメージ
            if (dmg <= 0)
            {
                dmg = 1;
            }

            // 抹殺攻撃は一撃で相手を倒せない限り効果がない
            if (Strings.InStr(w.ToString(), "殺") > 0)
            {
                if (t.HP > dmg)
                {
                    return ExpDamageRet;
                }
            }

            ExpDamageRet = dmg;
            return ExpDamageRet;
        }
    }
}

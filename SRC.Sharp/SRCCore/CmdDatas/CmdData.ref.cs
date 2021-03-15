﻿//        private int ExecArcCmd()
//        {
//            int ExecArcCmdRet = default;
//            PictureBox pic, pic2 = default;
//            short y1, x1, rad;
//            double start_angle, end_angle;
//            string opt;
//            string cname;
//            int clr;
//            short i;
//            if ((int)ArgNum < 6)
//            {
//                Event_Renamed.EventErrorMessage = "Arcコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 64979


//                Input:
//                            Error(0)

//                 */
//            }

//            x1 = (short)(GetArgAsLong(2) + Event_Renamed.BaseX);
//            y1 = (short)(GetArgAsLong(3) + Event_Renamed.BaseY);
//            rad = (short)GetArgAsLong(4);
//            start_angle = 3.1415926535d * GetArgAsDouble(5) / 180d;
//            end_angle = 3.1415926535d * GetArgAsDouble(6) / 180d;

//            // 塗りつぶしの際は角度を負の値にする必要がある
//            if (Event_Renamed.ObjFillStyle != vbFSTransparent)
//            {
//                start_angle = -start_angle;
//                if (start_angle == 0d)
//                {
//                    start_angle = -0.000001d;
//                }

//                end_angle = -end_angle;
//                if (end_angle == 0d)
//                {
//                    end_angle = -0.000001d;
//                }
//            }

//            GUI.SaveScreen();

//            // 描画先
//            switch (Event_Renamed.ObjDrawOption ?? "")
//            {
//                case "背景":
//                    {
//                        pic = GUI.MainForm.picBack;
//                        pic2 = GUI.MainForm.picMaskedBack;
//                        Map.IsMapDirty = true;
//                        break;
//                    }

//                case "保持":
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        pic2 = GUI.MainForm.picMain(1);
//                        break;
//                    }

//                default:
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        break;
//                    }
//            }

//            // 描画領域
//            short tmp;
//            if (Event_Renamed.ObjDrawOption != "背景")
//            {
//                GUI.IsPictureVisible = true;
//                tmp = (short)(rad + Event_Renamed.ObjDrawWidth - 1);
//                GUI.PaintedAreaX1 = (short)GeneralLib.MinLng(GUI.PaintedAreaX1, GeneralLib.MaxLng(x1 - tmp, 0));
//                GUI.PaintedAreaY1 = (short)GeneralLib.MinLng(GUI.PaintedAreaY1, GeneralLib.MaxLng(y1 - tmp, 0));
//                GUI.PaintedAreaX2 = (short)GeneralLib.MaxLng(GUI.PaintedAreaX2, GeneralLib.MinLng(x1 + tmp, GUI.MainPWidth - 1));
//                GUI.PaintedAreaY2 = (short)GeneralLib.MaxLng(GUI.PaintedAreaY2, GeneralLib.MinLng(y1 + tmp, GUI.MainPHeight - 1));
//            }

//            clr = Event_Renamed.ObjColor;
//            var loopTo = ArgNum;
//            for (i = (short)7; i <= loopTo; i++)
//            {
//                opt = GetArgAsString(i);
//                if (Strings.Asc(opt) == 35) // #
//                {
//                    if (Strings.Len(opt) != 7)
//                    {
//                        Event_Renamed.EventErrorMessage = "色指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 68421


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                    StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                    var midTmp = Strings.Mid(opt, 6, 2);
//                    StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                    var midTmp1 = Strings.Mid(opt, 4, 2);
//                    StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                    var midTmp2 = Strings.Mid(opt, 2, 2);
//                    StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                    if (!Information.IsNumeric(cname))
//                    {
//                        Event_Renamed.EventErrorMessage = "色指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 68931


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    clr = Conversions.ToInteger(cname);
//                }
//                else
//                {
//                    Event_Renamed.EventErrorMessage = "Arcコマンドに不正なオプション「" + opt + "」が使われています";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 69084


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }
//            pic.DrawWidth = Event_Renamed.ObjDrawWidth;
//            pic.FillColor = Event_Renamed.ObjFillColor;
//            pic.FillStyle = Event_Renamed.ObjFillStyle;

//            pic.Circle(x1, y1);/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//            pic.DrawWidth = 1;
//            pic.FillColor = ColorTranslator.ToOle(Color.White);
//            pic.FillStyle = vbFSTransparent;
//            if (pic2 is object)
//            {
//                pic2.DrawWidth = Event_Renamed.ObjDrawWidth;
//                pic2.FillColor = Event_Renamed.ObjFillColor;
//                pic2.FillStyle = Event_Renamed.ObjFillStyle;

//                pic2.Circle(x1, y1);/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                pic2.DrawWidth = 1;
//                pic2.FillColor = ColorTranslator.ToOle(Color.White);
//                pic2.FillStyle = vbFSTransparent;
//            }

//            ExecArcCmdRet = LineNum + 1;
//            return ExecArcCmdRet;
//        }

//        private int ExecArrayCmd()
//        {
//            int ExecArrayCmdRet = default;
//            object array_buf;
//            var array_buf2 = default(string[]);
//            string buf;
//            string var_name, vname;
//            int i;
//            short num;
//            bool IsList;
//            Expression.ValueType etype;
//            string str_value;
//            double num_value;
//            string sep;
//            if ((int)ArgNum != 4)
//            {
//                Event_Renamed.EventErrorMessage = "Arrayコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 73625


//                Input:
//                            Error(0)

//                 */
//            }
//            else if (GetArgAsString((short)4) == "リスト")
//            {
//                IsList = true;
//            }
//            else
//            {
//                IsList = false;
//            }

//            // 代入先の変数名
//            var_name = GetArg(2);
//            if (Strings.Left(var_name, 1) == "$")
//            {
//                var_name = Strings.Mid(var_name, 2);
//            }
//            // Eval関数
//            if (Strings.LCase(Strings.Left(var_name, 5)) == "eval(")
//            {
//                if (Strings.Right(var_name, 1) == ")")
//                {
//                    var_name = Strings.Mid(var_name, 6, Strings.Len(var_name) - 6);
//                    var_name = Expression.GetValueAsString(ref var_name);
//                }
//            }

//            // 代入先の変数を初期化した上で再設定
//            // サブルーチンローカル変数の場合
//            if (Expression.IsSubLocalVariableDefined(ref var_name))
//            {
//                Expression.UndefineVariable(ref var_name);
//                Event_Renamed.VarIndex = (short)(Event_Renamed.VarIndex + 1);
//                {
//                    var withBlock = Event_Renamed.VarStack[Event_Renamed.VarIndex];
//                    withBlock.Name = var_name;
//                    withBlock.VariableType = Expression.ValueType.NumericType;
//                    withBlock.StringValue = "";
//                    withBlock.NumericValue = 0d;
//                }
//            }
//            // ローカル変数の場合
//            else if (Expression.IsLocalVariableDefined(ref var_name))
//            {
//                Expression.UndefineVariable(ref var_name);
//                Expression.DefineLocalVariable(ref var_name);
//            }
//            // グローバル変数の場合
//            else if (Expression.IsGlobalVariableDefined(ref var_name))
//            {
//                Expression.UndefineVariable(ref var_name);
//                Expression.DefineGlobalVariable(ref var_name);
//            }

//            if (IsList)
//            {
//                // リストを配列に変換
//                string arglist = GetArgAsString((short)3);
//                num = GeneralLib.ListSplit(ref arglist, ref array_buf2);
//                // UPGRADE_WARNING: オブジェクト array_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                array_buf = Microsoft.VisualBasic.Compatibility.VB6.Support.CopyArray(array_buf2);
//            }
//            // 文字列を分割して配列に代入
//            else
//            {
//                ;
//#error Cannot convert ReDimStatementSyntax - see comment for details
//                /* Cannot convert ReDimStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Symbols.Metadata.PE.PENamedTypeSymbolWithEmittedNamespaceName' のオブジェクトを型 'Microsoft.CodeAnalysis.IArrayTypeSymbol' にキャストできません。
//                   場所 ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.CreateNewArrayAssignment(ExpressionSyntax vbArrayExpression, ExpressionSyntax csArrayExpression, List`1 convertedBounds, Int32 nodeSpanStart)
//                   場所 ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<ConvertRedimClauseAsync>d__41.MoveNext()
//                --- 直前に例外がスローされた場所からのスタック トレースの終わり ---
//                   場所 ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<<VisitReDimStatement>b__40_0>d.MoveNext()
//                --- 直前に例外がスローされた場所からのスタック トレースの終わり ---
//                   場所 ICSharpCode.CodeConverter.Shared.AsyncEnumerableTaskExtensions.<SelectAsync>d__3`2.MoveNext()
//                --- 直前に例外がスローされた場所からのスタック トレースの終わり ---
//                   場所 ICSharpCode.CodeConverter.Shared.AsyncEnumerableTaskExtensions.<SelectManyAsync>d__0`2.MoveNext()
//                --- 直前に例外がスローされた場所からのスタック トレースの終わり ---
//                   場所 ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitReDimStatement>d__40.MoveNext()
//                --- 直前に例外がスローされた場所からのスタック トレースの終わり ---
//                   場所 ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
//                --- 直前に例外がスローされた場所からのスタック トレースの終わり ---
//                   場所 ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

//                Input:
//                            '文字列を分割して配列に代入
//                            ReDim array_buf(0)

//                 */
//                buf = GetArgAsString((short)3);
//                sep = GetArgAsString((short)4);
//                i = Strings.InStr(buf, sep);
//                while (i > 0)
//                {
//                    Array.Resize(ref array_buf, Information.UBound((Array)array_buf) + 1 + 1);
//                    // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                    array_buf((object)Information.UBound((Array)array_buf)) = Strings.Left(buf, i - 1);
//                    buf = Strings.Mid(buf, i + Strings.Len(sep));
//                    i = Strings.InStr(buf, sep);
//                }

//                Array.Resize(ref array_buf, Information.UBound((Array)array_buf) + 1 + 1);
//                // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                array_buf((object)Information.UBound((Array)array_buf)) = buf;
//            }

//            var loopTo = Information.UBound((Array)array_buf);
//            for (i = 1; i <= loopTo; i++)
//            {
//                // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                buf = Conversions.ToString(array_buf((object)i));
//                GeneralLib.TrimString(ref buf);
//                if (Information.IsNumeric(buf))
//                {
//                    etype = Expression.ValueType.NumericType;
//                    str_value = "";
//                    num_value = GeneralLib.StrToDbl(ref buf);
//                }
//                else
//                {
//                    etype = Expression.ValueType.StringType;
//                    str_value = buf;
//                    num_value = 0d;
//                }

//                vname = var_name + "[" + i.ToString() + "]";
//                Expression.SetVariable(ref vname, ref etype, ref str_value, ref num_value);
//            }

//            ExecArrayCmdRet = LineNum + 1;
//            return ExecArrayCmdRet;
//        }

//        private int ExecAskCmd()
//        {
//            int ExecAskCmdRet = default;
//            var use_normal_list = default(bool);
//            var use_large_list = default(bool);
//            var use_continuous_mode = default(bool);
//            var enable_rbutton_cancel = default(bool);
//            string[] list;
//            string msg;
//            string vname;
//            int i;
//            string buf;
//            VarData var;
//            list = new string[1];
//            GUI.ListItemID = new string[1];
//            GUI.ListItemFlag = new bool[1];

//            // 表示オプションの処理
//            i = ArgNum;
//            while (i > 1)
//            {
//                switch (GetArg((short)i) ?? "")
//                {
//                    case "通常":
//                        {
//                            use_normal_list = true;
//                            break;
//                        }

//                    case "拡大":
//                        {
//                            use_large_list = true;
//                            break;
//                        }

//                    case "連続表示":
//                        {
//                            use_continuous_mode = true;
//                            break;
//                        }

//                    case "キャンセル可":
//                        {
//                            enable_rbutton_cancel = true;
//                            break;
//                        }

//                    case "終了":
//                        {
//                            My.MyProject.Forms.frmListBox.Hide();
//                            if (SRC.AutoMoveCursor)
//                            {
//                                GUI.RestoreCursorPos();
//                            }

//                            GUI.ReduceListBoxHeight();
//                            ExecAskCmdRet = LineNum + 1;
//                            return ExecAskCmdRet;
//                        }

//                    default:
//                        {
//                            break;
//                        }
//                }

//                i = i - 1;
//            }

//            // オプションではない引数の数で書式タイプを判別
//            switch (i)
//            {
//                // イベントデータ中に選択肢を列挙している場合
//                case 1:
//                case 2:
//                    {
//                        if ((int)ArgNum == 1)
//                        {
//                            msg = "いずれかを選んでください";
//                        }
//                        else
//                        {
//                            msg = GetArgAsString((short)2);
//                        }

//                        GUI.ListItemID[0] = "0";

//                        // 選択肢の読みこみ
//                        var loopTo = Information.UBound(Event_Renamed.EventData);
//                        for (i = LineNum + 1; i <= loopTo; i++)
//                        {
//                            buf = Event_Renamed.EventData[i];
//                            Expression.FormatMessage(ref buf);
//                            if (Strings.Len(buf) > 0)
//                            {
//                                if (Event_Renamed.EventCmd[i].Name == Event_Renamed.CmdType.EndCmd)
//                                {
//                                    break;
//                                }

//                                Array.Resize(ref list, Information.UBound(list) + 1 + 1);
//                                Array.Resize(ref GUI.ListItemID, Information.UBound(list) + 1);
//                                Array.Resize(ref GUI.ListItemFlag, Information.UBound(list) + 1);
//                                list[Information.UBound(list)] = buf;
//                                GUI.ListItemID[Information.UBound(list)] = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)(i - LineNum));
//                                GUI.ListItemFlag[Information.UBound(list)] = false;
//                            }
//                        }

//                        if (i > Information.UBound(Event_Renamed.EventData))
//                        {
//                            Event_Renamed.EventErrorMessage = "AskとEndが対応していません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 80314


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        ExecAskCmdRet = i + 1;
//                        break;
//                    }

//                // 選択肢を配列で指定する場合
//                case 3:
//                    {
//                        vname = GetArg((short)2);
//                        msg = GetArgAsString((short)3);
//                        GUI.ListItemID[0] = "";

//                        // 配列の検索
//                        if (Expression.IsSubLocalVariableDefined(ref vname))
//                        {
//                            if (Strings.Left(vname, 1) == "$")
//                            {
//                                vname = Strings.Mid(vname, 2) + "[";
//                            }
//                            else
//                            {
//                                vname = vname + "[";
//                            }

//                            var loopTo1 = (int)Event_Renamed.VarIndex;
//                            for (i = (int)Event_Renamed.VarIndexStack[(int)Event_Renamed.CallDepth - 1] + 1; i <= loopTo1; i++)
//                            {
//                                {
//                                    var withBlock = Event_Renamed.VarStack[i];
//                                    if (Strings.InStr(withBlock.Name, vname) == 1)
//                                    {
//                                        if (withBlock.VariableType == Expression.ValueType.StringType)
//                                        {
//                                            buf = withBlock.StringValue;
//                                        }
//                                        else
//                                        {
//                                            buf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)withBlock.NumericValue);
//                                        }

//                                        if (Strings.Len(buf) > 0)
//                                        {
//                                            Array.Resize(ref list, Information.UBound(list) + 1 + 1);
//                                            Array.Resize(ref GUI.ListItemID, Information.UBound(list) + 1);
//                                            Array.Resize(ref GUI.ListItemFlag, Information.UBound(list) + 1);
//                                            Expression.FormatMessage(ref buf);
//                                            list[Information.UBound(list)] = buf;
//                                            GUI.ListItemID[Information.UBound(list)] = Strings.Mid(withBlock.Name, Strings.Len(vname) + 1, Strings.Len(withBlock.Name) - Strings.Len(vname) - 1);
//                                            GUI.ListItemFlag[Information.UBound(list)] = false;
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        else if (Expression.IsLocalVariableDefined(ref vname))
//                        {
//                            if (Strings.Left(vname, 1) == "$")
//                            {
//                                vname = Strings.Mid(vname, 2) + "[";
//                            }
//                            else
//                            {
//                                vname = vname + "[";
//                            }

//                            foreach (VarData currentVar in Event_Renamed.LocalVariableList)
//                            {
//                                var = currentVar;
//                                if (Strings.InStr(var.Name, vname) == 1)
//                                {
//                                    if (var.VariableType == Expression.ValueType.StringType)
//                                    {
//                                        buf = var.StringValue;
//                                    }
//                                    else
//                                    {
//                                        buf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)var.NumericValue);
//                                    }

//                                    if (Strings.Len(buf) > 0)
//                                    {
//                                        Array.Resize(ref list, Information.UBound(list) + 1 + 1);
//                                        Array.Resize(ref GUI.ListItemID, Information.UBound(list) + 1);
//                                        Array.Resize(ref GUI.ListItemFlag, Information.UBound(list) + 1);
//                                        Expression.FormatMessage(ref buf);
//                                        list[Information.UBound(list)] = buf;
//                                        GUI.ListItemID[Information.UBound(list)] = Strings.Mid(var.Name, Strings.Len(vname) + 1, Strings.Len(var.Name) - Strings.Len(vname) - 1);
//                                        GUI.ListItemFlag[Information.UBound(list)] = false;
//                                    }
//                                }
//                            }
//                        }
//                        else if (Expression.IsGlobalVariableDefined(ref vname))
//                        {
//                            if (Strings.Left(vname, 1) == "$")
//                            {
//                                vname = Strings.Mid(vname, 2) + "[";
//                            }
//                            else
//                            {
//                                vname = vname + "[";
//                            }

//                            foreach (VarData currentVar1 in Event_Renamed.GlobalVariableList)
//                            {
//                                var = currentVar1;
//                                if (Strings.InStr(var.Name, vname) == 1)
//                                {
//                                    if (var.VariableType == Expression.ValueType.StringType)
//                                    {
//                                        buf = var.StringValue;
//                                    }
//                                    else
//                                    {
//                                        buf = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)var.NumericValue);
//                                    }

//                                    if (Strings.Len(buf) > 0)
//                                    {
//                                        Array.Resize(ref list, Information.UBound(list) + 1 + 1);
//                                        Array.Resize(ref GUI.ListItemID, Information.UBound(list) + 1);
//                                        Array.Resize(ref GUI.ListItemFlag, Information.UBound(list) + 1);
//                                        Expression.FormatMessage(ref buf);
//                                        list[Information.UBound(list)] = buf;
//                                        GUI.ListItemID[Information.UBound(list)] = Strings.Mid(var.Name, Strings.Len(vname) + 1, Strings.Len(var.Name) - Strings.Len(vname) - 1);
//                                        GUI.ListItemFlag[Information.UBound(list)] = false;
//                                    }
//                                }
//                            }
//                        }

//                        ExecAskCmdRet = LineNum + 1;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Askコマンドのオプションが不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 85714


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // 選択肢がなければそのまま終了
//            if (Information.UBound(list) == 0)
//            {
//                Event_Renamed.SelectedAlternative = 0.ToString();
//                return ExecAskCmdRet;
//            }

//            // ダイアログを拡大するか
//            if (!use_normal_list & (Information.UBound(list) > 6 | use_large_list))
//            {
//                GUI.EnlargeListBoxHeight();
//            }
//            else
//            {
//                GUI.ReduceListBoxHeight();
//            }

//            if (SRC.AutoMoveCursor)
//            {
//                GUI.TopItem = 1;
//                string arglb_caption = "選択";
//                string arglb_mode = "表示のみ";
//                Commands.SelectedItem = GUI.ListBox(ref arglb_caption, ref list, ref msg, ref arglb_mode);
//                string argcursor_mode = "ダイアログ";
//                GUI.MoveCursorPos(ref argcursor_mode);
//            }

//            // 選択肢の入力
//            do
//            {
//                GUI.TopItem = 1;
//                if (use_continuous_mode)
//                {
//                    string arglb_caption1 = "選択";
//                    string arglb_mode1 = "連続表示";
//                    Commands.SelectedItem = GUI.ListBox(ref arglb_caption1, ref list, ref msg, ref arglb_mode1);
//                }
//                else
//                {
//                    string arglb_caption2 = "選択";
//                    string arglb_mode2 = "";
//                    Commands.SelectedItem = GUI.ListBox(ref arglb_caption2, ref list, ref msg, lb_mode: ref arglb_mode2);
//                }

//                if (enable_rbutton_cancel)
//                {
//                    if (Commands.SelectedItem == 0)
//                    {
//                        break;
//                    }
//                }
//            }
//            while (Commands.SelectedItem == 0);
//            Event_Renamed.SelectedAlternative = GUI.ListItemID[Commands.SelectedItem];
//            GUI.ListItemID = new string[1];
//            if (!use_continuous_mode)
//            {
//                if (SRC.AutoMoveCursor)
//                {
//                    GUI.RestoreCursorPos();
//                }
//            }

//            // ダイアログを標準の大きさに戻す
//            if (!use_normal_list & !use_continuous_mode & (Information.UBound(list) > 6 | use_large_list))
//            {
//                GUI.ReduceListBoxHeight();
//            }

//            return ExecAskCmdRet;
//        }

//        private int ExecAttackCmd()
//        {
//            int ExecAttackCmdRet = default;
//            Unit u1, u2;
//            short w1, w2 = default;
//            Unit prev_su, prev_st;
//            short prev_w, prev_tw;
//            string def_mode, cur_stage;
//            bool is_event;
//            string def_option;
//            is_event = true;
//            switch (ArgNum)
//            {
//                case 5:
//                    {
//                        break;
//                    }
//                // ＯＫ
//                case 6:
//                    {
//                        if (GetArgAsString((short)6) == "通常戦闘")
//                        {
//                            is_event = false;
//                        }
//                        else
//                        {
//                            Event_Renamed.EventErrorMessage = "Attackコマンドのオプションが不正です";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 87971


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Attackコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 88089


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            u1 = GetArgAsUnit(2);
//            u2 = GetArgAsUnit(4);
//            if (u1.Status_Renamed == "出撃" & u2.Status_Renamed == "出撃")
//            {
//                if (GetArgAsString((short)3) == "自動")
//                {
//                    string argamode = "イベント";
//                    int argmax_prob = 0;
//                    int argmax_dmg = 0;
//                    w1 = COM.SelectWeapon(ref u1, ref u2, ref argamode, max_prob: ref argmax_prob, max_dmg: ref argmax_dmg);
//                }
//                else
//                {
//                    var loopTo = u1.CountWeapon();
//                    for (w1 = (short)1; w1 <= loopTo; w1++)
//                    {
//                        string argattr = "マップ攻撃";
//                        if ((GetArgAsString((short)3) ?? "") == (u1.Weapon(w1).Name ?? "") & !u1.IsWeaponClassifiedAs(w1, ref argattr))
//                        {
//                            break;
//                        }
//                    }

//                    if (w1 > u1.CountWeapon())
//                    {
//                        Event_Renamed.EventErrorMessage = "ユニット「" + u1.Name + "」には武装「" + GetArgAsString((short)3) + "」は存在しません";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 88682


//                        Input:
//                                            Error(0)

//                         */
//                    }
//                }

//                def_option = GetArgAsString((short)5);
//                switch (def_option ?? "")
//                {
//                    case "防御":
//                    case "回避":
//                    case "無抵抗":
//                        {
//                            def_mode = GetArgAsString((short)5);
//                            break;
//                        }

//                    case "反撃不能":
//                        {
//                            def_mode = "反撃";
//                            w2 = (short)0;
//                            break;
//                        }

//                    case "自動":
//                        {
//                            def_mode = "反撃";
//                            string argamode1 = "反撃 イベント";
//                            int argmax_prob1 = 0;
//                            int argmax_dmg1 = 0;
//                            w2 = COM.SelectWeapon(ref u2, ref u1, ref argamode1, max_prob: ref argmax_prob1, max_dmg: ref argmax_dmg1);
//                            break;
//                        }

//                    default:
//                        {
//                            def_mode = "反撃";
//                            var loopTo1 = u2.CountWeapon();
//                            for (w2 = (short)1; w2 <= loopTo1; w2++)
//                            {
//                                string argattr1 = "マップ攻撃";
//                                if ((GetArgAsString((short)5) ?? "") == (u2.Weapon(w2).Name ?? "") & !u2.IsWeaponClassifiedAs(w2, ref argattr1))
//                                {
//                                    break;
//                                }
//                            }

//                            if (w2 > u2.CountWeapon())
//                            {
//                                Event_Renamed.EventErrorMessage = "ユニット「" + u2.Name + "」には武装「" + GetArgAsString((short)5) + "」は存在しません";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 89382


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }
//                }

//                if ((int)w1 > 0)
//                {
//                    prev_su = Commands.SelectedUnit;
//                    prev_st = Commands.SelectedTarget;
//                    prev_w = Commands.SelectedWeapon;
//                    prev_tw = Commands.SelectedTWeapon;
//                    Commands.SelectedUnit = u1;
//                    Commands.SelectedTarget = u2;
//                    Commands.SelectedWeapon = w1;
//                    Commands.SelectedTWeapon = w2;
//                    if (u1.Party0 == "味方" | u1.Party0 == "ＮＰＣ")
//                    {
//                        GUI.OpenMessageForm(ref u2, ref u1);
//                    }
//                    else
//                    {
//                        GUI.OpenMessageForm(ref u1, ref u2);
//                    }

//                    // 攻撃を実行
//                    cur_stage = SRC.Stage;
//                    SRC.Stage = u1.Party;
//                    u1.Attack(w1, u2, "", def_mode, is_event);
//                    u1 = u1.CurrentForm();

//                    // 反撃用武器がまだ使用可能かチェック
//                    // MOD START マージ
//                    // If def_option = "自動" Then
//                    // If Not u2.IsTargetWithinRange(w2, u1) Then
//                    // w2 = SelectWeapon(u2, u1, "反撃 イベント")
//                    // SelectedTWeapon = w2
//                    // End If
//                    // End If
//                    if (def_option == "自動" & u2.Status_Renamed == "出撃")
//                    {
//                        string argref_mode = "移動前";
//                        if (!u2.IsTargetWithinRange(w2, ref u1) | !u2.IsWeaponAvailable(w2, ref argref_mode))
//                        {
//                            string argamode2 = "反撃 イベント";
//                            int argmax_prob2 = 0;
//                            int argmax_dmg2 = 0;
//                            w2 = COM.SelectWeapon(ref u2, ref u1, ref argamode2, max_prob: ref argmax_prob2, max_dmg: ref argmax_dmg2);
//                            Commands.SelectedTWeapon = w2;
//                        }
//                    }
//                    // MOD END マージ

//                    // 反撃を実行
//                    // MOD START マージ
//                    // If def_mode = "反撃" _
//                    // '                And u2.Status = "出撃" _
//                    // '                And Not u2.IsConditionSatisfied("行動不能") _
//                    // '            Then
//                    object argIndex1 = (object)"攻撃不能";
//                    if (def_mode == "反撃" & u2.Status_Renamed == "出撃" & (int)u2.MaxAction() > 0 & !u2.IsConditionSatisfied(ref argIndex1))
//                    {
//                        // MOD END マージ
//                        if ((int)w2 > 0)
//                        {
//                            u2.Attack(w2, u1, "", "", is_event);
//                        }
//                        else
//                        {
//                            string argSituation = "射程外";
//                            string argmsg_mode = "";
//                            u2.PilotMessage(ref argSituation, msg_mode: ref argmsg_mode);
//                        }
//                    }

//                    SRC.Stage = cur_stage;
//                    GUI.CloseMessageForm();
//                    u1.CurrentForm().UpdateCondition();
//                    u2.CurrentForm().UpdateCondition();
//                    u1.CurrentForm().CheckAutoHyperMode();
//                    u1.CurrentForm().CheckAutoNormalMode();
//                    u2.CurrentForm().CheckAutoHyperMode();
//                    u2.CurrentForm().CheckAutoNormalMode();
//                    Commands.SelectedUnit = prev_su;
//                    Commands.SelectedTarget = prev_st;
//                    Commands.SelectedWeapon = prev_w;
//                    Commands.SelectedTWeapon = prev_tw;
//                }
//            }

//            GUI.RedrawScreen();
//            ExecAttackCmdRet = LineNum + 1;
//            return ExecAttackCmdRet;
//        }

//        private int ExecAutoTalkCmd()
//        {
//            int ExecAutoTalkCmdRet = default;
//            string pname, current_pname = default;
//            Unit u;
//            short ux, uy;
//            int i;
//            short j;
//            short lnum;
//            int prev_msg_wait;
//            var without_cursor = default(bool);
//            string options = default, opt;
//            string buf;

//            // メッセージ表示速度を「普通」の値に設定
//            prev_msg_wait = GUI.MessageWait;
//            GUI.MessageWait = 700;
//            short counter;
//            counter = (short)LineNum;
//            string cname;
//            int tcolor;
//            var loopTo = Information.UBound(Event_Renamed.EventData);
//            for (i = (int)counter; i <= loopTo; i++)
//            {
//                {
//                    var withBlock = Event_Renamed.EventCmd[i];
//                    switch (withBlock.Name)
//                    {
//                        case Event_Renamed.CmdType.AutoTalkCmd:
//                            {
//                                if ((int)withBlock.ArgNum > 1)
//                                {
//                                    pname = withBlock.GetArgAsString((short)2);
//                                }
//                                else
//                                {
//                                    pname = "";
//                                }

//                                if (Strings.Left(pname, 1) == "@")
//                                {
//                                    // メインパイロットの強制指定
//                                    pname = Strings.Mid(pname, 2);
//                                    object argIndex2 = (object)pname;
//                                    if (SRC.PList.IsDefined(ref argIndex2))
//                                    {
//                                        object argIndex1 = (object)pname;
//                                        {
//                                            var withBlock1 = SRC.PList.Item(ref argIndex1);
//                                            if (withBlock1.Unit_Renamed is object)
//                                            {
//                                                pname = withBlock1.Unit_Renamed.MainPilot().Name;
//                                            }
//                                        }
//                                    }
//                                }

//                                // 話者名チェック
//                                bool localIsDefined() { object argIndex1 = (object)pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//                                bool localIsDefined1() { object argIndex1 = (object)pname; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//                                bool localIsDefined2() { object argIndex1 = (object)pname; var ret = SRC.NPDList.IsDefined(ref argIndex1); return ret; }

//                                if (!localIsDefined() & !localIsDefined1() & !localIsDefined2() & !(pname == "システム") & !string.IsNullOrEmpty(pname))
//                                {
//                                    Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが定義されていません";
//                                    LineNum = i;
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 93710


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                if ((int)withBlock.ArgNum > 1)
//                                {
//                                    options = "";
//                                    without_cursor = false;
//                                    j = (short)2;
//                                    lnum = (short)1;
//                                    while (j <= withBlock.ArgNum)
//                                    {
//                                        opt = withBlock.GetArgAsString(j);
//                                        switch (opt ?? "")
//                                        {
//                                            case "非表示":
//                                                {
//                                                    without_cursor = true;
//                                                    break;
//                                                }

//                                            case "枠外":
//                                                {
//                                                    GUI.MessageWindowIsOut = true;
//                                                    break;
//                                                }

//                                            case "白黒":
//                                            case "セピア":
//                                            case "明":
//                                            case "暗":
//                                            case "上下反転":
//                                            case "左右反転":
//                                            case "上半分":
//                                            case "下半分":
//                                            case "右半分":
//                                            case "左半分":
//                                            case "右上":
//                                            case "左上":
//                                            case "右下":
//                                            case "左下":
//                                            case "ネガポジ反転":
//                                            case "シルエット":
//                                            case "夕焼け":
//                                            case "水中":
//                                            case "通常":
//                                                {
//                                                    if ((int)j > 2)
//                                                    {
//                                                        // これらのパイロット画像描画に関するオプションは
//                                                        // パイロット名が指定されている場合にのみ有効
//                                                        options = options + opt + " ";
//                                                    }
//                                                    else
//                                                    {
//                                                        lnum = j;
//                                                    }

//                                                    break;
//                                                }

//                                            case "右回転":
//                                                {
//                                                    j = (short)((int)j + 1);
//                                                    options = options + "右回転 " + withBlock.GetArgAsString(j) + " ";
//                                                    break;
//                                                }

//                                            case "左回転":
//                                                {
//                                                    j = (short)((int)j + 1);
//                                                    options = options + "左回転 " + withBlock.GetArgAsString(j) + " ";
//                                                    break;
//                                                }

//                                            case "フィルタ":
//                                                {
//                                                    j = (short)((int)j + 1);
//                                                    buf = withBlock.GetArgAsString(j);
//                                                    cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                                                    StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                                                    var midTmp = Strings.Mid(buf, 6, 2);
//                                                    StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                                                    var midTmp1 = Strings.Mid(buf, 4, 2);
//                                                    StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                                                    var midTmp2 = Strings.Mid(buf, 2, 2);
//                                                    StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                                                    tcolor = Conversions.ToInteger(cname);
//                                                    j = (short)((int)j + 1);
//                                                    // 空白のオプションをスキップ
//                                                    options = options + "フィルタ " + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)tcolor) + " " + withBlock.GetArgAsString(j) + " ";
//                                                    break;
//                                                }

//                                            case var @case when @case == "":
//                                                {
//                                                    break;
//                                                }

//                                            default:
//                                                {
//                                                    // 通常の引数をスキップ
//                                                    lnum = j;
//                                                    break;
//                                                }
//                                        }

//                                        j = (short)((int)j + 1);
//                                    }
//                                }
//                                else
//                                {
//                                    lnum = (short)1;
//                                }

//                                switch (lnum)
//                                {
//                                    case 0:
//                                    case 1:
//                                        {
//                                            // 引数なし

//                                            if (!My.MyProject.Forms.frmMessage.Visible)
//                                            {
//                                                Unit argu1 = null;
//                                                Unit argu2 = null;
//                                                GUI.OpenMessageForm(u1: ref argu1, u2: ref argu2);
//                                            }

//                                            // メッセージウィンドウのパイロット画像を以前指定された
//                                            // ものに確定させる
//                                            if (!string.IsNullOrEmpty(current_pname))
//                                            {
//                                                GUI.DisplayBattleMessage(ref current_pname, "", ref options);
//                                            }

//                                            current_pname = "";
//                                            break;
//                                        }

//                                    case 2:
//                                        {
//                                            // パイロット名のみ指定
//                                            current_pname = pname;

//                                            // 話者中心に画面位置を変更

//                                            // プロローグイベントやエピローグイベント時はキャンセル
//                                            if (SRC.Stage == "プロローグ" | SRC.Stage == "エピローグ")
//                                            {
//                                                goto NextLoop;
//                                            }

//                                            // 画面書き換え可能？
//                                            if (!GUI.MainForm.Visible)
//                                            {
//                                                goto NextLoop;
//                                            }

//                                            if (GUI.IsPictureVisible)
//                                            {
//                                                goto NextLoop;
//                                            }

//                                            if (string.IsNullOrEmpty(Map.MapFileName))
//                                            {
//                                                goto NextLoop;
//                                            }

//                                            // 話者を中央表示
//                                            CenterUnit(pname, without_cursor);
//                                            break;
//                                        }

//                                    case 3:
//                                        {
//                                            current_pname = pname;
//                                            switch (withBlock.GetArgAsString((short)3) ?? "")
//                                            {
//                                                case "母艦":
//                                                    {
//                                                        // 母艦の中央表示
//                                                        CenterUnit("母艦", without_cursor);
//                                                        break;
//                                                    }

//                                                case "中央":
//                                                    {
//                                                        // 話者を中央表示
//                                                        CenterUnit(pname, without_cursor);
//                                                        break;
//                                                    }

//                                                case "固定":
//                                                    {
//                                                        break;
//                                                    }
//                                                    // 表示位置固定
//                                            }

//                                            break;
//                                        }

//                                    case 4:
//                                        {
//                                            // 表示の座標指定あり
//                                            current_pname = pname;
//                                            CenterUnit("", without_cursor, (short)withBlock.GetArgAsLong((short)3), (short)withBlock.GetArgAsLong((short)4));
//                                            break;
//                                        }

//                                    case -1:
//                                        {
//                                            Event_Renamed.EventErrorMessage = "AutoTalkコマンドのパラメータの括弧の対応が取れていません";
//                                            LineNum = i;
//                                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 97215


//                                            Input:
//                                                                            Error(0)

//                                             */
//                                            break;
//                                        }

//                                    default:
//                                        {
//                                            Event_Renamed.EventErrorMessage = "AutoTalkコマンドの引数の数が違います";
//                                            LineNum = i;
//                                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 97369


//                                            Input:
//                                                                            Error(0)

//                                             */
//                                            break;
//                                        }
//                                }

//                                if (!My.MyProject.Forms.frmMessage.Visible)
//                                {
//                                    Unit argu11 = null;
//                                    Unit argu21 = null;
//                                    GUI.OpenMessageForm(u1: ref argu11, u2: ref argu21);
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.EndCmd:
//                            {
//                                GUI.CloseMessageForm();
//                                if ((int)withBlock.ArgNum != 1)
//                                {
//                                    Event_Renamed.EventErrorMessage = "End部分の引数の数が違います";
//                                    LineNum = i;
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 97766


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.SuspendCmd:
//                            {
//                                if ((int)withBlock.ArgNum != 1)
//                                {
//                                    Event_Renamed.EventErrorMessage = "Suspend部分の引数の数が違います";
//                                    LineNum = i;
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 98012


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                break;
//                            }

//                        default:
//                            {
//                                if (!My.MyProject.Forms.frmMessage.Visible)
//                                {
//                                    Unit argu12 = null;
//                                    Unit argu22 = null;
//                                    GUI.OpenMessageForm(u1: ref argu12, u2: ref argu22);
//                                }

//                                GUI.DisplayBattleMessage(ref current_pname, Event_Renamed.EventData[i], ref options);
//                                break;
//                            }
//                    }
//                }

//                NextLoop:
//                ;
//            }

//            // メッセージ表示速度を元に戻す
//            GUI.MessageWait = prev_msg_wait;
//            if (i > Information.UBound(Event_Renamed.EventData))
//            {
//                GUI.CloseMessageForm();
//                Event_Renamed.EventErrorMessage = "AutoTalkとEndが対応していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 98673


//                Input:
//                            Error(0)

//                 */
//            }

//            ExecAutoTalkCmdRet = i + 1;
//            return ExecAutoTalkCmdRet;
//        }

//        // 話者の中央表示用サブルーチン
//        private void CenterUnit(string pname, bool without_cursor, short X = 0, short Y = 0)
//        {
//            short xx, yy;

//            // 座標が指定されている場合
//            if (X != 0 & Y != 0)
//            {
//                if (X < 1 | Map.MapWidth < X | Y < 1 | Map.MapHeight < Y)
//                {
//                    // マップ外
//                    return;
//                }

//                xx = X;
//                yy = Y;
//                goto FoundPoint;
//            }

//            if (pname == "母艦")
//            {
//                // 母艦を中央表示
//                foreach (Unit u in SRC.UList)
//                {
//                    if (u.Party0 == "味方" & u.Status_Renamed == "出撃")
//                    {
//                        string argfname = "母艦";
//                        if (u.IsFeatureAvailable(ref argfname))
//                        {
//                            xx = u.x;
//                            yy = u.y;
//                            goto FoundPoint;
//                        }
//                    }
//                }

//                return;
//            }

//            // 表情パターン名での指定はパイロット名に変換しておく
//            bool localIsDefined() { object argIndex1 = pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined() & Strings.InStr(pname, "(") > 0)
//            {
//                object argIndex1 = Strings.Left(pname, Strings.InStr(pname, "(") - 1);
//                if (SRC.PList.IsDefined(ref argIndex1))
//                {
//                    pname = Strings.Left(pname, Strings.InStr(pname, "(") - 1);
//                }
//            }

//            bool localIsDefined1() { object argIndex1 = pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//            bool localIsDefined2() { object argIndex1 = pname; var ret = SRC.NPDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined1() & localIsDefined2())
//            {
//                NonPilotData localItem() { object argIndex1 = pname; var ret = SRC.NPDList.Item(ref argIndex1); return ret; }

//                pname = localItem().Nickname;
//            }

//            // 話者はパイロット？
//            bool localIsDefined3() { object argIndex1 = pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined3())
//            {
//                return;
//            }

//            object argIndex2 = pname;
//            {
//                var withBlock = SRC.PList.Item(ref argIndex2);
//                if (withBlock.Unit_Renamed is object)
//                {
//                    // パイロットが乗っているユニットを中央表示
//                    {
//                        var withBlock1 = withBlock.Unit_Renamed;
//                        if (withBlock1.Status_Renamed == "出撃" | withBlock1.Status_Renamed == "格納")
//                        {
//                            xx = withBlock1.x;
//                            yy = withBlock1.y;
//                            goto FoundPoint;
//                        }
//                    }
//                }

//                // 話者が味方でかつ出撃中でない場合は母艦を中央表示
//                if (withBlock.Party == "味方")
//                {
//                    CenterUnit("母艦", without_cursor);
//                }
//            }

//            return;
//            FoundPoint:
//            ;
//            if (GUI.MapX != xx | GUI.MapY != yy)
//            {
//                GUI.Center(xx, yy);
//                GUI.RefreshScreen(false, true);
//            }

//            bool tmp;
//            if (!GUI.IsCursorVisible & !without_cursor)
//            {
//                tmp = GUI.IsPictureVisible;
//                string argfname1 = @"Event\cursor.bmp";
//                string argdraw_option = "透過";
//                GUI.DrawPicture(ref argfname1, SRC.DEFAULT_LEVEL, SRC.DEFAULT_LEVEL, SRC.DEFAULT_LEVEL, SRC.DEFAULT_LEVEL, 0, 0, 0, 0, ref argdraw_option);
//                GUI.IsPictureVisible = tmp;
//                GUI.IsCursorVisible = true;
//            }

//            GUI.MainForm.picMain(0).Refresh();
//        }

//        private int ExecBossRankCmd()
//        {
//            int ExecBossRankCmdRet = default;
//            Unit u;
//            string buf;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        buf = GetArgAsString((short)3);
//                        if (!Information.IsNumeric(buf))
//                        {
//                            Event_Renamed.EventErrorMessage = "ボスランクが不正です";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 101976


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        buf = GetArgAsString((short)2);
//                        if (!Information.IsNumeric(buf))
//                        {
//                            Event_Renamed.EventErrorMessage = "ボスランクが不正です";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 102254


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "BossRankコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 102374


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is object)
//            {
//                u.BossRank = Conversions.ToShort(buf);
//                u.HP = u.MaxHP;
//                u.FullSupply();
//            }

//            ExecBossRankCmdRet = LineNum + 1;
//            return ExecBossRankCmdRet;
//        }

//        private int ExecBreakCmd()
//        {
//            int ExecBreakCmdRet = default;
//            int i;
//            short depth;

//            // 対応するLoopもしくはNextコマンドを探す
//            depth = 1;
//            var loopTo = Information.UBound(Event_Renamed.EventCmd);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                switch (Event_Renamed.EventCmd[i].Name)
//                {
//                    case Event_Renamed.CmdType.DoCmd:
//                    case Event_Renamed.CmdType.ForCmd:
//                    case Event_Renamed.CmdType.ForEachCmd:
//                        {
//                            depth = (short)(depth + 1);
//                            break;
//                        }

//                    case Event_Renamed.CmdType.LoopCmd:
//                        {
//                            depth = (short)(depth - 1);
//                            if (depth == 0)
//                            {
//                                break;
//                            }

//                            break;
//                        }

//                    case Event_Renamed.CmdType.NextCmd:
//                        {
//                            depth = (short)(depth - 1);
//                            if (depth == 0)
//                            {
//                                Event_Renamed.ForIndex = (short)(Event_Renamed.ForIndex - 1);
//                                break;
//                            }

//                            break;
//                        }
//                }
//            }

//            if (i > Information.UBound(Event_Renamed.EventCmd))
//            {
//                Event_Renamed.EventErrorMessage = "Breakコマンドがループの外で使われています";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 103645


//                Input:
//                            Error(0)

//                 */
//            }

//            ExecBreakCmdRet = i + 1;
//            return ExecBreakCmdRet;
//        }

//        private int ExecCallCmd()
//        {
//            int ExecCallCmdRet = default;
//            int ret;
//            short i;
//            var @params = new string[(Event_Renamed.MaxArgIndex + 1)];

//            // サブルーチンを探す
//            string arglname = GetArgAsString(2);
//            ret = Event_Renamed.FindNormalLabel(ref arglname);

//            // 見つかった？
//            if (ret == 0)
//            {
//                Event_Renamed.EventErrorMessage = "サブルーチンの呼び出し先ラベルである「" + GetArgAsString((short)2) + "」がみつかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 104107


//                Input:
//                            Error(0)

//                 */
//            }

//            // 呼び出し階層をチェック
//            if (Event_Renamed.CallDepth > Event_Renamed.MaxCallDepth)
//            {
//                Event_Renamed.CallDepth = Event_Renamed.MaxCallDepth;
//                Event_Renamed.EventErrorMessage = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)Event_Renamed.MaxCallDepth) + "階層を越えるサブルーチンの呼び出しは出来ません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 104515


//                Input:
//                            Error(0)

//                 */
//            }

//            // 引数用スタックが溢れないかチェック
//            if (Event_Renamed.ArgIndex + ArgNum - 2 > (int)Event_Renamed.MaxArgIndex)
//            {
//                Event_Renamed.EventErrorMessage = "サブルーチンの引数の総数が" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)Event_Renamed.MaxArgIndex) + "個を超えています";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 104856


//                Input:
//                            Error(0)

//                 */
//            }

//            // 引数の値を先に求めておく
//            // (スタックに積みながら計算すると、引数での関数呼び出しで不正になる)
//            var loopTo = ArgNum;
//            for (i = 3; i <= loopTo; i++)
//                @params[i] = GetArgAsString(i);

//            // 現在の状態を保存
//            Event_Renamed.CallStack[Event_Renamed.CallDepth] = LineNum;
//            Event_Renamed.ArgIndexStack[Event_Renamed.CallDepth] = Event_Renamed.ArgIndex;
//            Event_Renamed.VarIndexStack[Event_Renamed.CallDepth] = Event_Renamed.VarIndex;
//            Event_Renamed.ForIndexStack[Event_Renamed.CallDepth] = Event_Renamed.ForIndex;

//            // UpVarが実行された場合、UpVar実行数は累計する
//            if (Event_Renamed.UpVarLevel > 0)
//            {
//                Event_Renamed.UpVarLevelStack[Event_Renamed.CallDepth] = (short)(Event_Renamed.UpVarLevel + Event_Renamed.UpVarLevelStack[Event_Renamed.CallDepth - 1]);
//            }
//            else
//            {
//                Event_Renamed.UpVarLevelStack[Event_Renamed.CallDepth] = 0;
//            }

//            // UpVarの階層数を初期化
//            Event_Renamed.UpVarLevel = 0;

//            // 引数をスタックに積む
//            var loopTo1 = ArgNum;
//            for (i = 3; i <= loopTo1; i++)
//                Event_Renamed.ArgStack[(short)(Event_Renamed.ArgIndex + ArgNum) - i + 1] = @params[i];
//            Event_Renamed.ArgIndex = (short)(Event_Renamed.ArgIndex + ArgNum - 2);

//            // 呼び出し階層数をインクリメント
//            Event_Renamed.CallDepth = (short)(Event_Renamed.CallDepth + 1);
//            ExecCallCmdRet = ret + 1;
//            return ExecCallCmdRet;
//        }

//        private int ExecReturnCmd()
//        {
//            int ExecReturnCmdRet = default;
//            if ((int)Event_Renamed.CallDepth <= 0)
//            {
//                Event_Renamed.EventErrorMessage = "CallコマンドとReturnコマンドが対応していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 106629


//                Input:
//                            Error(0)

//                 */
//            }
//            else if ((int)Event_Renamed.CallDepth == 1 & Event_Renamed.CallStack[(int)Event_Renamed.CallDepth] == 0)
//            {
//                Event_Renamed.EventErrorMessage = "CallコマンドとReturnコマンドが対応していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 106876


//                Input:
//                            Error(0)

//                 */
//            }

//            // 呼び出し階層数をデクリメント
//            Event_Renamed.CallDepth = (short)(Event_Renamed.CallDepth - 1);

//            // サブルーチン実行前の状態に復帰
//            Event_Renamed.ArgIndex = Event_Renamed.ArgIndexStack[Event_Renamed.CallDepth];
//            Event_Renamed.VarIndex = Event_Renamed.VarIndexStack[Event_Renamed.CallDepth];
//            Event_Renamed.ForIndex = Event_Renamed.ForIndexStack[Event_Renamed.CallDepth];
//            Event_Renamed.UpVarLevel = Event_Renamed.UpVarLevelStack[Event_Renamed.CallDepth];
//            ExecReturnCmdRet = Event_Renamed.CallStack[Event_Renamed.CallDepth] + 1;
//            return ExecReturnCmdRet;
//        }

//        private int ExecCallInterMissionCommandCmd()
//        {
//            int ExecCallInterMissionCommandCmdRet = default;
//            string fname, save_path = default;
//            short ret;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "CallInterMissionCommandコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 107922


//                Input:
//                            Error(0)

//                 */
//            }

//            // 選択されたインターミッションコマンドを実行
//            switch (GetArgAsString(2) ?? "")
//            {
//                case "データセーブ":
//                    {
//                        // 一旦「常に手前に表示」を解除
//                        if (My.MyProject.Forms.frmListBox.Visible)
//                        {
//                            ret = (short)GUI.SetWindowPos(My.MyProject.Forms.frmListBox.Handle.ToInt32(), -2, 0, 0, 0, 0, 0x3);
//                        }

//                        string argdtitle = "データセーブ";
//                        string argexpr = "セーブデータファイル名";
//                        string argdefault_file = Expression.GetValueAsString(ref argexpr);
//                        string argftype = "ｾｰﾌﾞﾃﾞｰﾀ";
//                        string argfsuffix = "src";
//                        string argftype2 = "";
//                        string argfsuffix2 = "";
//                        string argftype3 = "";
//                        string argfsuffix3 = "";
//                        fname = FileDialog.SaveFileDialog(ref argdtitle, ref SRC.ScenarioPath, ref argdefault_file, 2, ref argftype, ref argfsuffix, ftype2: ref argftype2, fsuffix2: ref argfsuffix2, ftype3: ref argftype3, fsuffix3: ref argfsuffix3);

//                        // 再び「常に手前に表示」
//                        if (My.MyProject.Forms.frmListBox.Visible)
//                        {
//                            ret = (short)GUI.SetWindowPos(My.MyProject.Forms.frmListBox.Handle.ToInt32(), -1, 0, 0, 0, 0, 0x3);
//                        }

//                        // キャンセル？
//                        if (string.IsNullOrEmpty(fname))
//                        {
//                            ExecCallInterMissionCommandCmdRet = LineNum + 1;
//                            return ExecCallInterMissionCommandCmdRet;
//                        }

//                        // セーブ先はシナリオフォルダ？
//                        if (Strings.InStr(fname, @"\") > 0)
//                        {
//                            string argstr2 = @"\";
//                            save_path = Strings.Left(fname, GeneralLib.InStr2(ref fname, ref argstr2));
//                        }
//                        // UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
//                        if ((FileSystem.Dir(save_path) ?? "") != (FileSystem.Dir(SRC.ScenarioPath) ?? ""))
//                        {
//                            if ((int)Interaction.MsgBox("セーブファイルはシナリオフォルダにないと読み込めません。" + Constants.vbCr + Constants.vbLf + "このままセーブしますか？", (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Question)) != 1)
//                            {
//                                ExecCallInterMissionCommandCmdRet = LineNum + 1;
//                                return ExecCallInterMissionCommandCmdRet;
//                            }
//                        }

//                        if (!string.IsNullOrEmpty(fname))
//                        {
//                            SRC.UList.Update(); // 追加パイロットを消去
//                            SRC.SaveData(ref fname);
//                        }

//                        break;
//                    }

//                case "機体改造":
//                case "ユニットの強化":
//                    {
//                        // 選択用ダイアログを拡大
//                        GUI.EnlargeListBoxHeight();
//                        InterMission.RankUpCommand();

//                        // 選択用リストボックスを元に戻す
//                        GUI.ReduceListBoxHeight();
//                        break;
//                    }

//                case "乗り換え":
//                    {
//                        // 選択用ダイアログを拡大
//                        GUI.EnlargeListBoxHeight();
//                        InterMission.ExchangeUnitCommand();

//                        // 選択用リストボックスを元に戻す
//                        GUI.ReduceListBoxHeight();
//                        break;
//                    }

//                case "アイテム交換":
//                    {
//                        // 選択用ダイアログを拡大
//                        GUI.EnlargeListBoxHeight();
//                        Unit argselected_unit = null;
//                        string argselected_part = "";
//                        InterMission.ExchangeItemCommand(selected_unit: ref argselected_unit, selected_part: ref argselected_part);

//                        // 選択用リストボックスを元に戻す
//                        GUI.ReduceListBoxHeight();
//                        break;
//                    }

//                case "換装":
//                    {
//                        // 選択用ダイアログを拡大
//                        GUI.EnlargeListBoxHeight();
//                        Commands.ExchangeFormCommand();

//                        // 選択用リストボックスを元に戻す
//                        GUI.ReduceListBoxHeight();
//                        break;
//                    }

//                case "パイロットステータス":
//                    {
//                        My.MyProject.Forms.frmListBox.Hide();
//                        GUI.ReduceListBoxHeight();
//                        SRC.IsSubStage = true;
//                        bool localFileExists() { string argfname = SRC.ExtDataPath + @"Lib\パイロットステータス表示.eve"; var ret = GeneralLib.FileExists(ref argfname); return ret; }

//                        bool localFileExists1() { string argfname = SRC.ExtDataPath2 + @"Lib\パイロットステータス表示.eve"; var ret = GeneralLib.FileExists(ref argfname); return ret; }

//                        string argfname = SRC.ScenarioPath + @"Lib\パイロットステータス表示.eve";
//                        if (GeneralLib.FileExists(ref argfname))
//                        {
//                            SRC.StartScenario(SRC.ScenarioPath + @"Lib\パイロットステータス表示.eve");
//                        }
//                        else if (localFileExists())
//                        {
//                            SRC.StartScenario(SRC.ExtDataPath + @"Lib\パイロットステータス表示.eve");
//                        }
//                        else if (localFileExists1())
//                        {
//                            SRC.StartScenario(SRC.ExtDataPath2 + @"Lib\パイロットステータス表示.eve");
//                        }
//                        else
//                        {
//                            SRC.StartScenario(SRC.AppPath + @"Lib\パイロットステータス表示.eve");
//                        }
//                        // サブステージを通常のステージとして実行
//                        SRC.IsSubStage = true;
//                        return ExecCallInterMissionCommandCmdRet;
//                    }

//                case "ユニットステータス":
//                    {
//                        My.MyProject.Forms.frmListBox.Hide();
//                        GUI.ReduceListBoxHeight();
//                        SRC.IsSubStage = true;
//                        bool localFileExists2() { string argfname = SRC.ExtDataPath + @"Lib\ユニットステータス表示.eve"; var ret = GeneralLib.FileExists(ref argfname); return ret; }

//                        bool localFileExists3() { string argfname = SRC.ExtDataPath2 + @"Lib\ユニットステータス表示.eve"; var ret = GeneralLib.FileExists(ref argfname); return ret; }

//                        string argfname1 = SRC.ScenarioPath + @"Lib\ユニットステータス表示.eve";
//                        if (GeneralLib.FileExists(ref argfname1))
//                        {
//                            SRC.StartScenario(SRC.ScenarioPath + @"Lib\ユニットステータス表示.eve");
//                        }
//                        else if (localFileExists2())
//                        {
//                            SRC.StartScenario(SRC.ExtDataPath + @"Lib\ユニットステータス表示.eve");
//                        }
//                        else if (localFileExists3())
//                        {
//                            SRC.StartScenario(SRC.ExtDataPath2 + @"Lib\ユニットステータス表示.eve");
//                        }
//                        else
//                        {
//                            SRC.StartScenario(SRC.AppPath + @"Lib\ユニットステータス表示.eve");
//                        }
//                        // サブステージを通常のステージとして実行
//                        SRC.IsSubStage = true;
//                        return ExecCallInterMissionCommandCmdRet;
//                    }
//            }

//            ExecCallInterMissionCommandCmdRet = LineNum + 1;
//            return ExecCallInterMissionCommandCmdRet;
//        }

//        private int ExecCancelCmd()
//        {
//            int ExecCancelCmdRet = default;
//            SRC.IsCanceled = true;
//            ExecCancelCmdRet = LineNum + 1;
//            return ExecCancelCmdRet;
//        }

//        private int ExecCenterCmd()
//        {
//            int ExecCenterCmdRet = default;
//            short num;
//            short ux, uy;
//            Unit u;
//            var late_refresh = default(bool);
//            num = ArgNum;
//            if (num > 1)
//            {
//                if (GetArgAsString(num) == "非同期")
//                {
//                    late_refresh = true;
//                    num = (short)(num - 1);
//                }
//            }

//            switch (num)
//            {
//                case 3:
//                    {
//                        ux = (short)GetArgAsLong((short)2);
//                        if ((int)ux < 1)
//                        {
//                            ux = (short)1;
//                        }
//                        else if (ux > Map.MapWidth)
//                        {
//                            ux = Map.MapWidth;
//                        }

//                        uy = (short)GetArgAsLong((short)3);
//                        if ((int)uy < 1)
//                        {
//                            uy = (short)1;
//                        }
//                        else if (uy > Map.MapHeight)
//                        {
//                            uy = Map.MapHeight;
//                        }

//                        GUI.Center(ux, uy);
//                        break;
//                    }

//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2, true);
//                        if (u is object)
//                        {
//                            if (u.Status_Renamed == "出撃")
//                            {
//                                GUI.Center(u.x, u.y);
//                                Event_Renamed.IsUnitCenter = true;
//                            }
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Centerコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 114024


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            GUI.RedrawScreen(late_refresh);
//            ExecCenterCmdRet = LineNum + 1;
//            return ExecCenterCmdRet;
//        }

//        private int ExecChangeAreaCmd()
//        {
//            int ExecChangeAreaCmdRet = default;
//            string new_area;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        new_area = GetArgAsString((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        new_area = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ChangeAreaコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 114580


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            {
//                var withBlock = u;
//                switch (Map.TerrainClass(withBlock.x, withBlock.y) ?? "")
//                {
//                    case "陸":
//                        {
//                            if (new_area != "地上" & new_area != "空中" & new_area != "地中")
//                            {
//                                Event_Renamed.EventErrorMessage = "場所の種類が不正です";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 114838


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }

//                    case "屋内":
//                        {
//                            if (new_area != "地上" & new_area != "空中")
//                            {
//                                Event_Renamed.EventErrorMessage = "場所の種類が不正です";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 115004


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }

//                    case "月面":
//                        {
//                            if (new_area != "地上" & new_area != "宇宙" & new_area != "地中")
//                            {
//                                Event_Renamed.EventErrorMessage = "場所の種類が不正です";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 115191


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }

//                    case "水":
//                    case "深水":
//                        {
//                            if (new_area != "水中" & new_area != "水上" & new_area != "空中")
//                            {
//                                Event_Renamed.EventErrorMessage = "場所の種類が不正です";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 115383


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }

//                    case "空中":
//                        {
//                            if (new_area != "空中")
//                            {
//                                Event_Renamed.EventErrorMessage = "場所の種類が不正です";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 115528


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }

//                    case "宇宙":
//                        {
//                            if (new_area != "宇宙")
//                            {
//                                Event_Renamed.EventErrorMessage = "場所の種類が不正です";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 115673


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }
//                }

//                withBlock.Area = new_area;
//                withBlock.Update();
//                if (withBlock.Status_Renamed == "出撃")
//                {
//                    GUI.PaintUnitBitmap(ref u);
//                }
//            }

//            GUI.RedrawScreen();
//            ExecChangeAreaCmdRet = LineNum + 1;
//            return ExecChangeAreaCmdRet;
//        }

//        // ADD START 240a
//        // ChangeLayerコマンド
//        // ChangeLayer X Y Name Number [Option]
//        private int ExecChangeLayerCmd()
//        {
//            int ExecChangeLayerCmdRet = default;
//            var B = default(object);
//            short X, Y;
//            string lname, ltypename;
//            short lid = default, lbitmap;
//            Map.BoxTypes ltype;
//            string fname2, fname, fname1, fname3;
//            string basefname;
//            int ret;
//            short i;
//            bool isPaintBmp;
//            if ((int)ArgNum != 5 & (int)ArgNum != 6)
//            {
//                Event_Renamed.EventErrorMessage = "ChangeTerrainコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 116506


//                Input:
//                            Error(0)

//                 */
//            }

//            // 対象座標を取得
//            X = (short)GetArgAsLong(2);
//            Y = (short)GetArgAsLong(3);
//            if ((int)X < 1 | X > Map.MapWidth)
//            {
//                Event_Renamed.EventErrorMessage = "Ｘ座標の値は1～" + Map.MapWidth + "で指定してください";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 116760


//                Input:
//                            Error(0)

//                 */
//            }

//            if ((int)Y < 1 | Y > Map.MapHeight)
//            {
//                Event_Renamed.EventErrorMessage = "Ｙ座標の値は1～" + Map.MapHeight + "で指定してください";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 116948


//                Input:
//                            Error(0)

//                 */
//            }

//            // レイヤー情報・画像を取得
//            lname = GetArgAsString(4);
//            lbitmap = (short)GetArgAsLong(5);
//            if (Strings.Right(lname, 6) == "(ローカル)")
//            {
//                lname = Strings.Left(lname, Strings.Len(lname) - 6);
//            }

//            {
//                var withBlock = SRC.TDList;
//                var loopTo = withBlock.Count;
//                for (i = 1; i <= loopTo; i++)
//                {
//                    lid = withBlock.OrderedID(i);
//                    if ((lname ?? "") == (withBlock.Name(lid) ?? ""))
//                    {
//                        break;
//                    }
//                }

//                if (i > withBlock.Count)
//                {
//                    Event_Renamed.EventErrorMessage = "「" + lname + "」という地形は存在しません";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 117517


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }

//            Map.MapData[X, Y, Map.MapDataIndex.LayerType] = lid;
//            Map.MapData[X, Y, Map.MapDataIndex.LayerBitmapNo] = lbitmap;

//            // マス情報を取得
//            isPaintBmp = true;
//            if ((int)ArgNum == 6)
//            {
//                ltypename = GetArgAsString((short)6);
//                if ("通常" == ltypename)
//                {
//                    ltype = Map.BoxTypes.Upper;
//                }
//                else if ("情報限定" == ltypename)
//                {
//                    isPaintBmp = false;
//                    ltype = Map.BoxTypes.UpperDataOnly;
//                }
//                else if ("画像限定" == ltypename)
//                {
//                    ltype = Map.BoxTypes.UpperBmpOnly;
//                }
//                else
//                {
//                    Event_Renamed.EventErrorMessage = "ChangeLayerコマンドのOptionが不正です";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 118213


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }
//            else
//            {
//                ltype = Map.BoxTypes.Upper;
//            }

//            Map.MapData[X, Y, Map.MapDataIndex.BoxType] = ltype;
//            if (isPaintBmp)
//            {
//                // マップ画像を検索
//                basefname = Map.SearchTerrainImageFile(Map.MapData[X, Y, Map.MapDataIndex.TerrainType], Map.MapData[X, Y, Map.MapDataIndex.BitmapNo], X, Y);
//                fname = Map.SearchTerrainImageFile(lid, lbitmap, X, Y);
//                if (string.IsNullOrEmpty(fname))
//                {
//                    Event_Renamed.EventErrorMessage = "マップビットマップ「" + SRC.TDList.Bitmap(lid) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)lbitmap) + ".bmp" + "」が見つかりません";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 118934


//                    Input:
//                                    Error(0)

//                     */
//                }

//                {
//                    var withBlock1 = GUI.MainForm;
//                    // マップ画像を背景へ書き込み
//                    withBlock1.picTmp32(0) = Image.FromFile(basefname);
//                    switch (Map.MapDrawMode ?? "")
//                    {
//                        case "夜":
//                            {
//                                var argpic = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic);
//                                Graphics.Dark();
//                                var argpic1 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic1);
//                                break;
//                            }

//                        case "セピア":
//                            {
//                                var argpic2 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic2);
//                                Graphics.Sepia();
//                                var argpic3 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic3);
//                                break;
//                            }

//                        case "白黒":
//                            {
//                                var argpic4 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic4);
//                                Graphics.Monotone();
//                                var argpic5 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic5);
//                                break;
//                            }

//                        case "夕焼け":
//                            {
//                                var argpic6 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic6);
//                                Graphics.Sunset();
//                                var argpic7 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic7);
//                                break;
//                            }

//                        case "水中":
//                            {
//                                var argpic8 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic8);
//                                Graphics.Water();
//                                var argpic9 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic9);
//                                break;
//                            }

//                        case "フィルタ":
//                            {
//                                var argpic10 = withBlock1.picTmp32(0);
//                                Graphics.GetImage(ref argpic10);
//                                Graphics.ColorFilter(ref Map.MapDrawFilterColor, ref Map.MapDrawFilterTransPercent);
//                                var argpic11 = withBlock1.picTmp32(0);
//                                Graphics.SetImage(ref argpic11);
//                                break;
//                            }
//                    }
//                    ret = GUI.BitBlt(withBlock1.picBack.hDC, 32 * ((int)X - 1), 32 * ((int)Y - 1), 32, 32, withBlock1.picTmp32(0).hDC, 0, 0, GUI.SRCCOPY);

//                    // レイヤー画像を背景へ書き込み
//                    withBlock1.picTmp32(0) = Image.FromFile(fname);
//                    GUI.BGColor = ColorTranslator.ToOle(Color.White);
//                    switch (Map.MapDrawMode ?? "")
//                    {
//                        case "夜":
//                            {
//                                var argpic12 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic12);
//                                Graphics.Dark(true);
//                                var argpic13 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic13);
//                                break;
//                            }

//                        case "セピア":
//                            {
//                                var argpic14 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic14);
//                                Graphics.Sepia(true);
//                                var argpic15 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic15);
//                                break;
//                            }

//                        case "白黒":
//                            {
//                                var argpic16 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic16);
//                                Graphics.Monotone(true);
//                                var argpic17 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic17);
//                                break;
//                            }

//                        case "夕焼け":
//                            {
//                                var argpic18 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic18);
//                                Graphics.Sunset(true);
//                                var argpic19 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic19);
//                                break;
//                            }

//                        case "水中":
//                            {
//                                var argpic20 = GUI.MainForm.picTmp32(0);
//                                Graphics.GetImage(ref argpic20);
//                                Graphics.Water(true);
//                                var argpic21 = GUI.MainForm.picTmp32(0);
//                                Graphics.SetImage(ref argpic21);
//                                break;
//                            }

//                        case "フィルタ":
//                            {
//                                var argpic22 = withBlock1.picTmp32(0);
//                                Graphics.GetImage(ref argpic22);
//                                Graphics.ColorFilter(ref Map.MapDrawFilterColor, ref Map.MapDrawFilterTransPercent, true);
//                                var argpic23 = withBlock1.picTmp32(0);
//                                Graphics.SetImage(ref argpic23);
//                                break;
//                            }
//                    }
//                    // レイヤーは透過処理をする
//                    ret = GUI.TransparentBlt(withBlock1.picBack.hDC, 32 * ((int)X - 1), 32 * ((int)Y - 1), 32, 32, withBlock1.picTmp32(0).hDC, 0, 0, 32, 32, GUI.BGColor);

//                    // マス目の表示
//                    if (SRC.ShowSquareLine)
//                    {
//                        withBlock1.picBack.Line((32 * ((int)X - 1), 32 * ((int)Y - 1)) - (32 * (int)X, 32 * ((int)Y - 1)), Information.RGB(100, 100, 100), B);
//                        withBlock1.picBack.Line((32 * ((int)X - 1), 32 * ((int)Y - 1)) - (32 * ((int)X - 1), 32 * (int)Y), Information.RGB(100, 100, 100), B);
//                    }

//                    // マスク入り背景画面を作成しておく
//                    ret = GUI.BitBlt(withBlock1.picMaskedBack.hDC, 32 * ((int)X - 1), 32 * ((int)Y - 1), 32, 32, withBlock1.picBack.hDC, 32 * ((int)X - 1), 32 * ((int)Y - 1), GUI.SRCCOPY);
//                    ret = GUI.BitBlt(withBlock1.picMaskedBack.hDC, 32 * ((int)X - 1), 32 * ((int)Y - 1), 32, 32, withBlock1.picMask.hDC, 0, 0, GUI.SRCAND);
//                    ret = GUI.BitBlt(withBlock1.picMaskedBack.hDC, 32 * ((int)X - 1), 32 * ((int)Y - 1), 32, 32, withBlock1.picMask2.hDC, 0, 0, GUI.SRCINVERT);
//                }

//                // 変更された地形にいたユニットを再表示（ついでにバックバッファからフロントに描画）
//                if (Map.MapDataForUnit[X, Y] is object)
//                {
//                    {
//                        var withBlock2 = Map.MapDataForUnit[X, Y];
//                        // UPGRADE_NOTE: オブジェクト MapDataForUnit() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                        Map.MapDataForUnit[X, Y] = null;
//                        GUI.EraseUnitBitmap(X, Y, false);
//                        withBlock2.StandBy(X, Y, "非同期");
//                    }
//                }
//                else
//                {
//                    {
//                        var withBlock3 = GUI.MainForm;
//                        ret = GUI.TransparentBlt(withBlock3.picMain(0).hDC, GUI.MapToPixelX(X), GUI.MapToPixelY(Y), 32, 32, withBlock3.picTmp32(0).hDC, 0, 0, 32, 32, ColorTranslator.ToOle(Color.White));
//                    }
//                }
//            }

//            ExecChangeLayerCmdRet = LineNum + 1;
//            return ExecChangeLayerCmdRet;
//        }
//        // ADD  END  240a

//        private int ExecChangeMapCmd()
//        {
//            int ExecChangeMapCmdRet = default;
//            string fname;
//            var late_refresh = default(bool);
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        break;
//                    }
//                // ＯＫ
//                case 3:
//                    {
//                        if (GetArgAsString((short)3) == "非同期")
//                        {
//                            late_refresh = true;
//                        }
//                        else
//                        {
//                            Event_Renamed.EventErrorMessage = "ChangeMapコマンドのオプションが不正です";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 131856


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ChangeMapコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 131977


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;

//            // 出撃中のユニットを撤退させる
//            foreach (Unit u in SRC.UList)
//            {
//                if (u.Status_Renamed == "出撃" | u.Status_Renamed == "格納")
//                {
//                    if (late_refresh)
//                    {
//                        u.Escape("非同期");
//                    }
//                    else
//                    {
//                        u.Escape();
//                    }
//                }
//            }

//            fname = GetArgAsString(2);
//            if (Strings.Len(fname) > 0)
//            {
//                string argfname = SRC.ScenarioPath + fname;
//                Map.LoadMapData(ref argfname);
//            }
//            else
//            {
//                string argfname1 = "";
//                Map.LoadMapData(ref argfname1);
//            }

//            if (late_refresh)
//            {
//                string argdraw_mode = "";
//                string argdraw_option = "非同期";
//                int argfilter_color = 0;
//                double argfilter_trans_par = 0d;
//                GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, filter_color: ref argfilter_color, filter_trans_par: ref argfilter_trans_par);
//                GUI.RedrawScreen(true);
//            }
//            else
//            {
//                string argdraw_mode1 = "";
//                string argdraw_option1 = "";
//                int argfilter_color1 = 0;
//                double argfilter_trans_par1 = 0d;
//                GUI.SetupBackground(draw_mode: ref argdraw_mode1, draw_option: ref argdraw_option1, filter_color: ref argfilter_color1, filter_trans_par: ref argfilter_trans_par1);
//                GUI.RedrawScreen();
//            }

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecChangeMapCmdRet = LineNum + 1;
//            return ExecChangeMapCmdRet;
//        }

//        private int ExecChangeModeCmd()
//        {
//            int ExecChangeModeCmdRet = default;
//            Unit[] uarrary;
//            Unit u;
//            string new_mode;
//            string pname;
//            short i;
//            short dst_x, dst_y;
//            var uarray = new object[2];
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        uarray[1] = Event_Renamed.SelectedUnitForEvent;
//                        new_mode = GetArgAsString((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        if (GetArgAsLong((short)2) > 0 & GetArgAsLong((short)3) > 0)
//                        {
//                            uarray[1] = Event_Renamed.SelectedUnitForEvent;
//                            dst_x = (short)GetArgAsLong((short)2);
//                            dst_y = (short)GetArgAsLong((short)3);
//                            if ((int)dst_x < 1 | Map.MapWidth < dst_x | (int)dst_y < 1 | Map.MapHeight < dst_y)
//                            {
//                                Event_Renamed.EventErrorMessage = "ChangeModeコマンドの目的地の座標が不正です";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 134202


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            new_mode = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)dst_x) + " " + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)dst_y);
//                        }
//                        else
//                        {
//                            pname = GetArgAsString((short)2);
//                            switch (pname ?? "")
//                            {
//                                case "味方":
//                                case "ＮＰＣ":
//                                case "敵":
//                                case "中立":
//                                    {
//                                        uarray = new object[1];
//                                        foreach (Unit currentU in SRC.UList)
//                                        {
//                                            u = currentU;
//                                            if ((u.Party0 ?? "") == (pname ?? ""))
//                                            {
//                                                Array.Resize(ref uarray, Information.UBound(uarray) + 1 + 1);
//                                                uarray[Information.UBound(uarray)] = u;
//                                            }
//                                        }

//                                        break;
//                                    }

//                                default:
//                                    {
//                                        object argIndex1 = (object)pname;
//                                        uarray[1] = SRC.UList.Item2(ref argIndex1);
//                                        if (uarray[1] is null)
//                                        {
//                                            {
//                                                var withBlock = SRC.PList;
//                                                bool localIsDefined() { object argIndex1 = (object)pname; var ret = withBlock.IsDefined(ref argIndex1); return ret; }

//                                                if (!localIsDefined())
//                                                {
//                                                    Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 135082


//                                                    Input:
//                                                                                            Error(0)

//                                                     */
//                                                }

//                                                Pilot localItem() { object argIndex1 = (object)pname; var ret = withBlock.Item(ref argIndex1); return ret; }

//                                                uarray[1] = localItem().Unit_Renamed;
//                                                i = (short)2;
//                                                object argIndex2 = (object)(pname + ":" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)i));
//                                                while (withBlock.IsDefined(ref argIndex2))
//                                                {
//                                                    Array.Resize(ref uarray, Information.UBound(uarray) + 1 + 1);
//                                                    Pilot localItem1() { object argIndex1 = (object)(pname + ":" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)i)); var ret = withBlock.Item(ref argIndex1); return ret; }

//                                                    uarray[Information.UBound(uarray)] = localItem1().Unit_Renamed;
//                                                    i = (short)((int)i + 1);
//                                                }
//                                            }
//                                        }

//                                        break;
//                                    }
//                            }

//                            new_mode = GetArgAsString((short)3);
//                        }

//                        break;
//                    }

//                case 4:
//                    {
//                        pname = GetArgAsString((short)2);
//                        switch (pname ?? "")
//                        {
//                            case "味方":
//                            case "ＮＰＣ":
//                            case "敵":
//                            case "中立":
//                                {
//                                    uarray = new object[1];
//                                    foreach (Unit currentU1 in SRC.UList)
//                                    {
//                                        u = currentU1;
//                                        if ((u.Party0 ?? "") == (pname ?? ""))
//                                        {
//                                            Array.Resize(ref uarray, Information.UBound(uarray) + 1 + 1);
//                                            uarray[Information.UBound(uarray)] = u;
//                                        }
//                                    }

//                                    break;
//                                }

//                            default:
//                                {
//                                    object argIndex3 = (object)pname;
//                                    uarray[1] = SRC.UList.Item2(ref argIndex3);
//                                    if (uarray[1] is null)
//                                    {
//                                        {
//                                            var withBlock1 = SRC.PList;
//                                            bool localIsDefined1() { object argIndex1 = (object)pname; var ret = withBlock1.IsDefined(ref argIndex1); return ret; }

//                                            if (!localIsDefined1())
//                                            {
//                                                Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 136368


//                                                Input:
//                                                                                    Error(0)

//                                                 */
//                                            }

//                                            Pilot localItem2() { object argIndex1 = (object)pname; var ret = withBlock1.Item(ref argIndex1); return ret; }

//                                            uarray[1] = localItem2().Unit_Renamed;
//                                            i = (short)2;
//                                            object argIndex4 = (object)(pname + ":" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)i));
//                                            while (withBlock1.IsDefined(ref argIndex4))
//                                            {
//                                                Array.Resize(ref uarray, Information.UBound(uarray) + 1 + 1);
//                                                Pilot localItem3() { object argIndex1 = (object)(pname + ":" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)i)); var ret = withBlock1.Item(ref argIndex1); return ret; }

//                                                uarray[Information.UBound(uarray)] = localItem3().Unit_Renamed;
//                                                i = (short)((int)i + 1);
//                                            }
//                                        }
//                                    }

//                                    break;
//                                }
//                        }

//                        dst_x = (short)GetArgAsLong((short)3);
//                        dst_y = (short)GetArgAsLong((short)4);
//                        if ((int)dst_x < 1 | Map.MapWidth < dst_x | (int)dst_y < 1 | Map.MapHeight < dst_y)
//                        {
//                            Event_Renamed.EventErrorMessage = "ChangeModeコマンドの目的地の座標が不正です";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 137170


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        new_mode = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)dst_x) + " " + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)dst_y);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ChangeModeコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 137438


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            var loopTo = (short)Information.UBound(uarray);
//            for (i = 1; i <= loopTo; i++)
//            {
//                if (uarray[i] is object)
//                {
//                    // UPGRADE_WARNING: オブジェクト uarray().Mode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                    uarray[i].Mode = new_mode;
//                }
//            }

//            ExecChangeModeCmdRet = LineNum + 1;
//            return ExecChangeModeCmdRet;
//        }

//        private int ExecChangePartyCmd()
//        {
//            int ExecChangePartyCmdRet = default;
//            string new_party;
//            string pname;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        new_party = GetArgAsString((short)2);
//                        if (new_party != "味方" & new_party != "ＮＰＣ" & new_party != "敵" & new_party != "中立")
//                        {
//                            Event_Renamed.EventErrorMessage = "陣営の指定が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 138260


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        Event_Renamed.SelectedUnitForEvent.ChangeParty(ref new_party);
//                        break;
//                    }

//                case 3:
//                    {
//                        new_party = GetArgAsString((short)3);
//                        if (new_party != "味方" & new_party != "ＮＰＣ" & new_party != "敵" & new_party != "中立")
//                        {
//                            Event_Renamed.EventErrorMessage = "陣営の指定が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 138590


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        pname = GetArgAsString((short)2);
//                        object argIndex1 = (object)pname;
//                        u = SRC.UList.Item2(ref argIndex1);
//                        if (u is null)
//                        {
//                            bool localIsDefined() { object argIndex1 = (object)pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//                            if (!localIsDefined())
//                            {
//                                Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 138884


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            object argIndex2 = (object)pname;
//                            {
//                                var withBlock = SRC.PList.Item(ref argIndex2);
//                                if (withBlock.Unit_Renamed is null)
//                                {
//                                    withBlock.Party = new_party;
//                                }
//                                else
//                                {
//                                    withBlock.Unit_Renamed.ChangeParty(ref new_party);
//                                }
//                            }
//                        }
//                        else
//                        {
//                            u.ChangeParty(ref new_party);
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ChangePartyコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 139270


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // カーソルが陣営変更されたユニット上にあるとカーソルは消去されるので
//            GUI.IsCursorVisible = false;
//            ExecChangePartyCmdRet = LineNum + 1;
//            return ExecChangePartyCmdRet;
//        }

//        private int ExecChangeTerrainCmd()
//        {
//            int ExecChangeTerrainCmdRet = default;
//            var B = default(object);
//            short tx, ty;
//            string tname;
//            short tid = default, tbitmap;
//            string fname2, fname, fname1, fname3;
//            int ret;
//            short i;
//            if ((int)ArgNum != 5)
//            {
//                Event_Renamed.EventErrorMessage = "ChangeTerrainコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 139795


//                Input:
//                            Error(0)

//                 */
//            }

//            tx = (short)GetArgAsLong(2);
//            if ((int)tx < 1 | tx > Map.MapWidth)
//            {
//                Event_Renamed.EventErrorMessage = "Ｘ座標の値は1～" + Map.MapWidth + "で指定してください";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 140014


//                Input:
//                            Error(0)

//                 */
//            }

//            ty = (short)GetArgAsLong(3);
//            if ((int)ty < 1 | ty > Map.MapHeight)
//            {
//                Event_Renamed.EventErrorMessage = "Ｙ座標の値は1～" + Map.MapHeight + "で指定してください";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 140235


//                Input:
//                            Error(0)

//                 */
//            }

//            tname = GetArgAsString(4);
//            if (Strings.Right(tname, 6) != "(ローカル)")
//            {
//                {
//                    var withBlock = SRC.TDList;
//                    var loopTo = withBlock.Count;
//                    for (i = (short)1; i <= loopTo; i++)
//                    {
//                        tid = withBlock.OrderedID(i);
//                        if ((tname ?? "") == (withBlock.Name(tid) ?? ""))
//                        {
//                            break;
//                        }
//                    }

//                    if (i > withBlock.Count)
//                    {
//                        Event_Renamed.EventErrorMessage = "「" + tname + "」という地形は存在しません";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 140642


//                        Input:
//                                            Error(0)

//                         */
//                    }
//                }

//                // MOD START 240a
//                // MapData(tx, ty, 0) = tid
//                Map.MapData[tx, ty, Map.MapDataIndex.TerrainType] = tid;
//                // MOD  END  240a

//                tbitmap = (short)GetArgAsLong((short)5);
//                // MOD START 240a
//                // MapData(tx, ty, 1) = tbitmap
//                Map.MapData[tx, ty, Map.MapDataIndex.BitmapNo] = tbitmap;
//            }
//            // MOD  END  240a
//            else
//            {
//                tname = Strings.Left(tname, Strings.Len(tname) - 6);
//                {
//                    var withBlock1 = SRC.TDList;
//                    var loopTo1 = withBlock1.Count;
//                    for (i = (short)1; i <= loopTo1; i++)
//                    {
//                        tid = withBlock1.OrderedID(i);
//                        if ((tname ?? "") == (withBlock1.Name(tid) ?? ""))
//                        {
//                            break;
//                        }
//                    }

//                    if (i > withBlock1.Count)
//                    {
//                        Event_Renamed.EventErrorMessage = "「" + tname + "」という地形は存在しません";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 141467


//                        Input:
//                                            Error(0)

//                         */
//                    }
//                }

//                // MOD START 240a
//                // MapData(tx, ty, 0) = tid
//                Map.MapData[tx, ty, Map.MapDataIndex.TerrainType] = tid;
//                // MOD  END  240a

//                tbitmap = (short)-GetArgAsLong((short)5);
//                // MOD START 240a
//                // MapData(tx, ty, 1) = tbitmap
//                Map.MapData[tx, ty, Map.MapDataIndex.BitmapNo] = tbitmap;
//                // MOD  END  240a
//            }

//            // マップ画像を検索
//            fname = Map.SearchTerrainImageFile(tid, tbitmap, tx, ty);
//            if (string.IsNullOrEmpty(fname))
//            {
//                Event_Renamed.EventErrorMessage = "マップビットマップ「" + SRC.TDList.Bitmap(tid) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)tbitmap) + ".bmp" + "」が見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 142219


//                Input:
//                            Error(0)

//                 */
//            }

//            {
//                var withBlock2 = GUI.MainForm;
//                withBlock2.picTmp32(0) = Image.FromFile(fname);
//                switch (Map.MapDrawMode ?? "")
//                {
//                    case "夜":
//                        {
//                            var argpic = GUI.MainForm.picTmp32(0);
//                            Graphics.GetImage(ref argpic);
//                            Graphics.Dark();
//                            var argpic1 = GUI.MainForm.picTmp32(0);
//                            Graphics.SetImage(ref argpic1);
//                            break;
//                        }

//                    case "セピア":
//                        {
//                            var argpic2 = GUI.MainForm.picTmp32(0);
//                            Graphics.GetImage(ref argpic2);
//                            Graphics.Sepia();
//                            var argpic3 = GUI.MainForm.picTmp32(0);
//                            Graphics.SetImage(ref argpic3);
//                            break;
//                        }

//                    case "白黒":
//                        {
//                            var argpic4 = GUI.MainForm.picTmp32(0);
//                            Graphics.GetImage(ref argpic4);
//                            Graphics.Monotone();
//                            var argpic5 = GUI.MainForm.picTmp32(0);
//                            Graphics.SetImage(ref argpic5);
//                            break;
//                        }

//                    case "夕焼け":
//                        {
//                            var argpic6 = GUI.MainForm.picTmp32(0);
//                            Graphics.GetImage(ref argpic6);
//                            Graphics.Sunset();
//                            var argpic7 = GUI.MainForm.picTmp32(0);
//                            Graphics.SetImage(ref argpic7);
//                            break;
//                        }

//                    case "水中":
//                        {
//                            var argpic8 = GUI.MainForm.picTmp32(0);
//                            Graphics.GetImage(ref argpic8);
//                            Graphics.Water();
//                            var argpic9 = GUI.MainForm.picTmp32(0);
//                            Graphics.SetImage(ref argpic9);
//                            break;
//                        }

//                    case "フィルタ":
//                        {
//                            var argpic10 = withBlock2.picTmp32(0);
//                            Graphics.GetImage(ref argpic10);
//                            Graphics.ColorFilter(ref Map.MapDrawFilterColor, ref Map.MapDrawFilterTransPercent);
//                            var argpic11 = withBlock2.picTmp32(0);
//                            Graphics.SetImage(ref argpic11);
//                            break;
//                        }
//                }

//                // 背景への書き込み
//                ret = GUI.BitBlt(withBlock2.picBack.hDC, 32 * (tx - 1), 32 * (ty - 1), 32, 32, withBlock2.picTmp32(0).hDC, 0, 0, GUI.SRCCOPY);

//                // マス目の表示
//                if (SRC.ShowSquareLine)
//                {
//                    withBlock2.picBack.Line((32 * (tx - 1), 32 * (ty - 1)) - (32 * tx, 32 * (ty - 1)), Information.RGB(100, 100, 100), B);
//                    withBlock2.picBack.Line((32 * (tx - 1), 32 * (ty - 1)) - (32 * (tx - 1), 32 * ty), Information.RGB(100, 100, 100), B);
//                }

//                // マスク入り背景画面を作成
//                ret = GUI.BitBlt(withBlock2.picMaskedBack.hDC, 32 * (tx - 1), 32 * (ty - 1), 32, 32, withBlock2.picBack.hDC, 32 * (tx - 1), 32 * (ty - 1), GUI.SRCCOPY);
//                ret = GUI.BitBlt(withBlock2.picMaskedBack.hDC, 32 * (tx - 1), 32 * (ty - 1), 32, 32, withBlock2.picMask.hDC, 0, 0, GUI.SRCAND);
//                ret = GUI.BitBlt(withBlock2.picMaskedBack.hDC, 32 * (tx - 1), 32 * (ty - 1), 32, 32, withBlock2.picMask2.hDC, 0, 0, GUI.SRCINVERT);
//            }

//            // 変更された地形にいたユニットを再表示
//            if (Map.MapDataForUnit[tx, ty] is object)
//            {
//                {
//                    var withBlock3 = Map.MapDataForUnit[tx, ty];
//                    // UPGRADE_NOTE: オブジェクト MapDataForUnit() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                    Map.MapDataForUnit[tx, ty] = null;
//                    GUI.EraseUnitBitmap(tx, ty, false);
//                    withBlock3.StandBy(tx, ty, "非同期");
//                }
//            }
//            else
//            {
//                {
//                    var withBlock4 = GUI.MainForm;
//                    ret = GUI.BitBlt(withBlock4.picMain(0).hDC, GUI.MapToPixelX(tx), GUI.MapToPixelY(ty), 32, 32, withBlock4.picTmp32(0).hDC, 0, 0, GUI.SRCCOPY);
//                }
//            }

//            ExecChangeTerrainCmdRet = LineNum + 1;
//            return ExecChangeTerrainCmdRet;
//        }

//        private int ExecChangeUnitBitmapCmd()
//        {
//            int ExecChangeUnitBitmapCmdRet = default;
//            string new_bmp, prev_bmp;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        new_bmp = GetArgAsString((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        new_bmp = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ChangeUnitBitmapコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 150606


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            {
//                var withBlock = u;
//                prev_bmp = withBlock.get_Bitmap(false);
//                if (Strings.LCase(Strings.Right(new_bmp, 4)) == ".bmp")
//                {
//                    string argcname = "ユニット画像";
//                    string argcdata = "非表示 " + new_bmp;
//                    withBlock.AddCondition(ref argcname, (short)-1, 0d, ref argcdata);
//                }
//                else if (new_bmp == "-")
//                {
//                    object argIndex2 = (object)"ユニット画像";
//                    if (withBlock.IsConditionSatisfied(ref argIndex2))
//                    {
//                        object argIndex1 = (object)"ユニット画像";
//                        withBlock.DeleteCondition(ref argIndex1);
//                    }
//                }
//                else if (new_bmp == "非表示")
//                {
//                    string argcname1 = "非表示付加";
//                    string argcdata1 = "非表示";
//                    withBlock.AddCondition(ref argcname1, (short)-1, 0d, ref argcdata1);
//                    withBlock.BitmapID = (short)-1;
//                    GUI.EraseUnitBitmap(withBlock.x, withBlock.y, false);
//                }
//                else if (new_bmp == "非表示解除")
//                {
//                    object argIndex4 = (object)"非表示付加";
//                    if (withBlock.IsConditionSatisfied(ref argIndex4))
//                    {
//                        object argIndex3 = (object)"非表示付加";
//                        withBlock.DeleteCondition(ref argIndex3);
//                    }

//                    withBlock.BitmapID = GUI.MakeUnitBitmap(ref u);
//                }
//                else
//                {
//                    Event_Renamed.EventErrorMessage = "ビットマップファイル名が不正です";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 151378


//                    Input:
//                                    Error(0)

//                     */
//                }

//                if ((withBlock.get_Bitmap(false) ?? "") != (prev_bmp ?? ""))
//                {
//                    withBlock.BitmapID = GUI.MakeUnitBitmap(ref u);
//                }

//                GUI.PaintUnitBitmap(ref u, "リフレッシュ無し");
//            }

//            ExecChangeUnitBitmapCmdRet = LineNum + 1;
//            return ExecChangeUnitBitmapCmdRet;
//        }

//        private int ExecChargeCmd()
//        {
//            int ExecChargeCmdRet = default;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        break;
//                    }

//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Chargeコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 151949


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            string argcname = "チャージ";
//            string argcdata = "";
//            u.AddCondition(ref argcname, 1, cdata: ref argcdata);
//            ExecChargeCmdRet = LineNum + 1;
//            return ExecChargeCmdRet;
//        }

//        private int ExecCircleCmd()
//        {
//            int ExecCircleCmdRet = default;
//            PictureBox pic, pic2 = default;
//            short y1, x1, rad;
//            string opt;
//            string cname;
//            int clr;
//            short i;
//            if ((int)ArgNum < 4)
//            {
//                Event_Renamed.EventErrorMessage = "Circleコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 152388


//                Input:
//                            Error(0)

//                 */
//            }

//            x1 = (short)(GetArgAsLong(2) + Event_Renamed.BaseX);
//            y1 = (short)(GetArgAsLong(3) + Event_Renamed.BaseY);
//            rad = (short)GetArgAsLong(4);
//            GUI.SaveScreen();

//            // 描画先
//            switch (Event_Renamed.ObjDrawOption ?? "")
//            {
//                case "背景":
//                    {
//                        pic = GUI.MainForm.picBack;
//                        pic2 = GUI.MainForm.picMaskedBack;
//                        Map.IsMapDirty = true;
//                        break;
//                    }

//                case "保持":
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        pic2 = GUI.MainForm.picMain(1);
//                        break;
//                    }

//                default:
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        break;
//                    }
//            }

//            // 描画領域
//            short tmp;
//            if (Event_Renamed.ObjDrawOption != "背景")
//            {
//                GUI.IsPictureVisible = true;
//                tmp = (short)(rad + Event_Renamed.ObjDrawWidth - 1);
//                GUI.PaintedAreaX1 = (short)GeneralLib.MinLng(GUI.PaintedAreaX1, GeneralLib.MaxLng(x1 - tmp, 0));
//                GUI.PaintedAreaY1 = (short)GeneralLib.MinLng(GUI.PaintedAreaY1, GeneralLib.MaxLng(y1 - tmp, 0));
//                GUI.PaintedAreaX2 = (short)GeneralLib.MaxLng(GUI.PaintedAreaX2, GeneralLib.MinLng(x1 + tmp, GUI.MapPWidth - 1));
//                GUI.PaintedAreaY2 = (short)GeneralLib.MaxLng(GUI.PaintedAreaY2, GeneralLib.MinLng(y1 + tmp, GUI.MapPHeight - 1));
//            }

//            clr = Event_Renamed.ObjColor;
//            var loopTo = ArgNum;
//            for (i = (short)5; i <= loopTo; i++)
//            {
//                opt = GetArgAsString(i);
//                if (Strings.Asc(opt) == 35) // #
//                {
//                    if (Strings.Len(opt) != 7)
//                    {
//                        Event_Renamed.EventErrorMessage = "色指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 155229


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                    StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                    var midTmp = Strings.Mid(opt, 6, 2);
//                    StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                    var midTmp1 = Strings.Mid(opt, 4, 2);
//                    StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                    var midTmp2 = Strings.Mid(opt, 2, 2);
//                    StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                    if (!Information.IsNumeric(cname))
//                    {
//                        Event_Renamed.EventErrorMessage = "色指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 155739


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    clr = Conversions.ToInteger(cname);
//                }
//                else
//                {
//                    Event_Renamed.EventErrorMessage = "Circleコマンドに不正なオプション「" + opt + "」が使われています";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 155895


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }
//            pic.DrawWidth = Event_Renamed.ObjDrawWidth;
//            pic.FillColor = Event_Renamed.ObjFillColor;
//            pic.FillStyle = Event_Renamed.ObjFillStyle;

//            pic.Circle(x1, y1);/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//            pic.DrawWidth = 1;
//            pic.FillColor = ColorTranslator.ToOle(Color.White);
//            pic.FillStyle = vbFSTransparent;
//            if (pic2 is object)
//            {
//                pic2.DrawWidth = Event_Renamed.ObjDrawWidth;
//                pic2.FillColor = Event_Renamed.ObjFillColor;
//                pic2.FillStyle = Event_Renamed.ObjFillStyle;

//                pic2.Circle(x1, y1);/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                pic2.DrawWidth = 1;
//                pic2.FillColor = ColorTranslator.ToOle(Color.White);
//                pic2.FillStyle = vbFSTransparent;
//            }

//            ExecCircleCmdRet = LineNum + 1;
//            return ExecCircleCmdRet;
//        }

//        private int ExecClearEventCmd()
//        {
//            int ExecClearEventCmdRet = default;
//            int ret;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        string arglname = GetArgAsString((short)2);
//                        ret = Event_Renamed.FindLabel(ref arglname);
//                        if (ret > 0)
//                        {
//                            Event_Renamed.ClearLabel(ret);
//                        }

//                        break;
//                    }

//                case 1:
//                    {
//                        if (Event_Renamed.CurrentLabel > 0)
//                        {
//                            Event_Renamed.ClearLabel(Event_Renamed.CurrentLabel);
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ClearEventコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 160477


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecClearEventCmdRet = LineNum + 1;
//            return ExecClearEventCmdRet;
//        }

//        // 互換性維持のために残している
//        private int ExecClearImageCmd()
//        {
//            int ExecClearImageCmdRet = default;
//            GUI.ClearPicture();
//            GUI.MainForm.picMain(0).Refresh();
//            ExecClearImageCmdRet = LineNum + 1;
//            return ExecClearImageCmdRet;
//        }

//        // ADD START 240a
//        // ExecClearLayerCmd
//        // 書式１ 全てのLayer情報を削除
//        // ClearLayer [Option]
//        // 書式２ 指定した座標のLayer情報を削除 情報限定・画像限定を選択可能
//        // ClearLayer X Y [Option]
//        // このモジュールにおいては、 DataOnly＝データのみ消す の意
//        private int ExecClearLayerCmd()
//        {
//            int ExecClearLayerCmdRet = default;
//            var B = default(object);
//            short i, X = default, Y = default, j;
//            bool isDataOnly, isAllClear, isBitmapOnly;
//            string fname, loption;
//            int ret;
//            // 引数チェック
//            if (4 < (int)ArgNum)
//            {
//                Event_Renamed.EventErrorMessage = "ClearLayerコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 161481


//                Input:
//                            Error(0)

//                 */
//            }
//            // 全体クリアフラグ取得
//            if (ArgNum < 3)
//            {
//                isAllClear = true;
//            }
//            else
//            {
//                isAllClear = false;
//            }
//            // オプション取得
//            isDataOnly = false;
//            isBitmapOnly = false;
//            loption = "";
//            if (2 == ArgNum)
//            {
//                loption = GetArgAsString(2);
//            }
//            else if (4 == ArgNum)
//            {
//                loption = GetArgAsString(4);
//            }

//            if (!string.IsNullOrEmpty(loption))
//            {
//                if ("情報限定" == loption)
//                {
//                    isDataOnly = true;
//                }
//                else if ("画像限定" == loption)
//                {
//                    isBitmapOnly = true;
//                }
//                else if ("通常" != loption)
//                {
//                    Event_Renamed.EventErrorMessage = "ClearLayerコマンドの引数Optionが不正です";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 162072


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }
//            // 座標取得
//            if (!isAllClear)
//            {
//                X = (short)GetArgAsLong((short)2);
//                Y = (short)GetArgAsLong((short)3);
//                if ((int)X < 1 | X > Map.MapWidth)
//                {
//                    Event_Renamed.EventErrorMessage = "Ｘ座標の値は1～" + Map.MapWidth + "で指定してください";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 162361


//                    Input:
//                                    Error(0)

//                     */
//                }

//                if ((int)Y < 1 | Y > Map.MapHeight)
//                {
//                    Event_Renamed.EventErrorMessage = "Ｙ座標の値は1～" + Map.MapHeight + "で指定してください";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 162553


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }
//            // 処理開始
//            if (isAllClear)
//            {
//                // 全削除実行
//                var loopTo = Map.MapWidth;
//                for (i = 1; i <= loopTo; i++)
//                {
//                    var loopTo1 = Map.MapHeight;
//                    for (j = 1; j <= loopTo1; j++)
//                    {
//                        // レイヤー情報を更新する
//                        if (isDataOnly)
//                        {
//                            Map.MapData[i, j, Map.MapDataIndex.BoxType] = Map.BoxTypes.UpperBmpOnly;
//                        }
//                        else if (isBitmapOnly)
//                        {
//                            Map.MapData[i, j, Map.MapDataIndex.BoxType] = Map.BoxTypes.UpperDataOnly;
//                        }
//                        else
//                        {
//                            // 両方ともfalseならレイヤー丸ごと削除
//                            Map.MapData[i, j, Map.MapDataIndex.LayerType] = Map.NO_LAYER_NUM;
//                            Map.MapData[i, j, Map.MapDataIndex.LayerBitmapNo] = Map.NO_LAYER_NUM;
//                            Map.MapData[i, j, Map.MapDataIndex.BoxType] = Map.BoxTypes.Under;
//                        }
//                        // レイヤー画像だけを消すことはできないので、下層レイヤーを再描画することで処理する
//                        fname = Map.SearchTerrainImageFile(Map.MapData[i, j, Map.MapDataIndex.TerrainType], Map.MapData[i, j, Map.MapDataIndex.BitmapNo], i, j);

//                        // データのみ削除の場合は再描画処理をスキップする
//                        if (!isDataOnly)
//                        {
//                            {
//                                var withBlock = GUI.MainForm;
//                                // マップ画像を背景へ書き込み
//                                withBlock.picTmp32(0) = Image.FromFile(fname);
//                                switch (Map.MapDrawMode ?? "")
//                                {
//                                    case "夜":
//                                        {
//                                            var argpic = GUI.MainForm.picTmp32(0);
//                                            Graphics.GetImage(ref argpic);
//                                            Graphics.Dark();
//                                            var argpic1 = GUI.MainForm.picTmp32(0);
//                                            Graphics.SetImage(ref argpic1);
//                                            break;
//                                        }

//                                    case "セピア":
//                                        {
//                                            var argpic2 = GUI.MainForm.picTmp32(0);
//                                            Graphics.GetImage(ref argpic2);
//                                            Graphics.Sepia();
//                                            var argpic3 = GUI.MainForm.picTmp32(0);
//                                            Graphics.SetImage(ref argpic3);
//                                            break;
//                                        }

//                                    case "白黒":
//                                        {
//                                            var argpic4 = GUI.MainForm.picTmp32(0);
//                                            Graphics.GetImage(ref argpic4);
//                                            Graphics.Monotone();
//                                            var argpic5 = GUI.MainForm.picTmp32(0);
//                                            Graphics.SetImage(ref argpic5);
//                                            break;
//                                        }

//                                    case "夕焼け":
//                                        {
//                                            var argpic6 = GUI.MainForm.picTmp32(0);
//                                            Graphics.GetImage(ref argpic6);
//                                            Graphics.Sunset();
//                                            var argpic7 = GUI.MainForm.picTmp32(0);
//                                            Graphics.SetImage(ref argpic7);
//                                            break;
//                                        }

//                                    case "水中":
//                                        {
//                                            var argpic8 = GUI.MainForm.picTmp32(0);
//                                            Graphics.GetImage(ref argpic8);
//                                            Graphics.Water();
//                                            var argpic9 = GUI.MainForm.picTmp32(0);
//                                            Graphics.SetImage(ref argpic9);
//                                            break;
//                                        }

//                                    case "フィルタ":
//                                        {
//                                            var argpic10 = withBlock.picTmp32(0);
//                                            Graphics.GetImage(ref argpic10);
//                                            Graphics.ColorFilter(ref Map.MapDrawFilterColor, ref Map.MapDrawFilterTransPercent);
//                                            var argpic11 = withBlock.picTmp32(0);
//                                            Graphics.SetImage(ref argpic11);
//                                            break;
//                                        }
//                                }
//                                ret = GUI.BitBlt(withBlock.picBack.hDC, 32 * (i - 1), 32 * (j - 1), 32, 32, withBlock.picTmp32(0).hDC, 0, 0, GUI.SRCCOPY);
//                                // マス目の表示
//                                if (SRC.ShowSquareLine)
//                                {
//                                    withBlock.picBack.Line((32 * (i - 1), 32 * (j - 1)) - (32 * i, 32 * (j - 1)), Information.RGB(100, 100, 100), B);
//                                    withBlock.picBack.Line((32 * (i - 1), 32 * (j - 1)) - (32 * (i - 1), 32 * j), Information.RGB(100, 100, 100), B);
//                                }
//                                // マスク入り背景画面を作成
//                                ret = GUI.BitBlt(withBlock.picMaskedBack.hDC, 32 * (i - 1), 32 * (j - 1), 32, 32, withBlock.picBack.hDC, 32 * (i - 1), 32 * (j - 1), GUI.SRCCOPY);
//                                ret = GUI.BitBlt(withBlock.picMaskedBack.hDC, 32 * (i - 1), 32 * (j - 1), 32, 32, withBlock.picMask.hDC, 0, 0, GUI.SRCAND);
//                                ret = GUI.BitBlt(withBlock.picMaskedBack.hDC, 32 * (i - 1), 32 * (j - 1), 32, 32, withBlock.picMask2.hDC, 0, 0, GUI.SRCINVERT);
//                            }
//                            // 変更された地形にいたユニットを再表示
//                            if (Map.MapDataForUnit[i, j] is object)
//                            {
//                                // 一旦ユニットをどかして再配置（変更後の地形が入れない地形の場合に対処）
//                                // UPGRADE_NOTE: オブジェクト MapDataForUnit() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                Map.MapDataForUnit[i, j] = null;
//                                GUI.EraseUnitBitmap(i, j, false);
//                                Map.MapDataForUnit[i, j].StandBy(i, j, "非同期");
//                            }
//                            else
//                            {
//                                {
//                                    var withBlock1 = GUI.MainForm;
//                                    ret = GUI.TransparentBlt(withBlock1.picMain(0).hDC, GUI.MapToPixelX(i), GUI.MapToPixelY(j), 32, 32, withBlock1.picTmp32(0).hDC, 0, 0, 32, 32, ColorTranslator.ToOle(Color.White));
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            else
//            {
//                // 指定した座標のみレイヤー情報を更新する
//                if (isDataOnly)
//                {
//                    Map.MapData[X, Y, Map.MapDataIndex.BoxType] = Map.BoxTypes.UpperBmpOnly;
//                }
//                else if (isBitmapOnly)
//                {
//                    Map.MapData[X, Y, Map.MapDataIndex.BoxType] = Map.BoxTypes.UpperDataOnly;
//                }
//                else
//                {
//                    // 両方ともfalseならレイヤー丸ごと削除
//                    Map.MapData[X, Y, Map.MapDataIndex.LayerType] = Map.NO_LAYER_NUM;
//                    Map.MapData[X, Y, Map.MapDataIndex.LayerBitmapNo] = Map.NO_LAYER_NUM;
//                    Map.MapData[X, Y, Map.MapDataIndex.BoxType] = Map.BoxTypes.Under;
//                }

//                // データのみの場合は再描画処理をスキップ
//                if (!isDataOnly)
//                {
//                    fname = Map.SearchTerrainImageFile(Map.MapData[X, Y, Map.MapDataIndex.TerrainType], Map.MapData[X, Y, Map.MapDataIndex.BitmapNo], X, Y);
//                    {
//                        var withBlock2 = GUI.MainForm;
//                        // マップ画像を背景へ書き込み
//                        withBlock2.picTmp32(0) = Image.FromFile(fname);
//                        switch (Map.MapDrawMode ?? "")
//                        {
//                            case "夜":
//                                {
//                                    var argpic12 = GUI.MainForm.picTmp32(0);
//                                    Graphics.GetImage(ref argpic12);
//                                    Graphics.Dark();
//                                    var argpic13 = GUI.MainForm.picTmp32(0);
//                                    Graphics.SetImage(ref argpic13);
//                                    break;
//                                }

//                            case "セピア":
//                                {
//                                    var argpic14 = GUI.MainForm.picTmp32(0);
//                                    Graphics.GetImage(ref argpic14);
//                                    Graphics.Sepia();
//                                    var argpic15 = GUI.MainForm.picTmp32(0);
//                                    Graphics.SetImage(ref argpic15);
//                                    break;
//                                }

//                            case "白黒":
//                                {
//                                    var argpic16 = GUI.MainForm.picTmp32(0);
//                                    Graphics.GetImage(ref argpic16);
//                                    Graphics.Monotone();
//                                    var argpic17 = GUI.MainForm.picTmp32(0);
//                                    Graphics.SetImage(ref argpic17);
//                                    break;
//                                }

//                            case "夕焼け":
//                                {
//                                    var argpic18 = GUI.MainForm.picTmp32(0);
//                                    Graphics.GetImage(ref argpic18);
//                                    Graphics.Sunset();
//                                    var argpic19 = GUI.MainForm.picTmp32(0);
//                                    Graphics.SetImage(ref argpic19);
//                                    break;
//                                }

//                            case "水中":
//                                {
//                                    var argpic20 = GUI.MainForm.picTmp32(0);
//                                    Graphics.GetImage(ref argpic20);
//                                    Graphics.Water();
//                                    var argpic21 = GUI.MainForm.picTmp32(0);
//                                    Graphics.SetImage(ref argpic21);
//                                    break;
//                                }

//                            case "フィルタ":
//                                {
//                                    var argpic22 = withBlock2.picTmp32(0);
//                                    Graphics.GetImage(ref argpic22);
//                                    Graphics.ColorFilter(ref Map.MapDrawFilterColor, ref Map.MapDrawFilterTransPercent);
//                                    var argpic23 = withBlock2.picTmp32(0);
//                                    Graphics.SetImage(ref argpic23);
//                                    break;
//                                }
//                        }
//                        ret = GUI.BitBlt(withBlock2.picBack.hDC, 32 * (X - 1), 32 * (Y - 1), 32, 32, withBlock2.picTmp32(0).hDC, 0, 0, GUI.SRCCOPY);
//                        // マス目の表示
//                        if (SRC.ShowSquareLine)
//                        {
//                            withBlock2.picBack.Line((32 * (X - 1), 32 * (Y - 1)) - (32 * X, 32 * (Y - 1)), Information.RGB(100, 100, 100), B);
//                            withBlock2.picBack.Line((32 * (X - 1), 32 * (Y - 1)) - (32 * (X - 1), 32 * Y), Information.RGB(100, 100, 100), B);
//                        }
//                        // マスク入り背景画面を作成
//                        ret = GUI.BitBlt(withBlock2.picMaskedBack.hDC, 32 * (X - 1), 32 * (Y - 1), 32, 32, withBlock2.picBack.hDC, 32 * (X - 1), 32 * (Y - 1), GUI.SRCCOPY);
//                        ret = GUI.BitBlt(withBlock2.picMaskedBack.hDC, 32 * (X - 1), 32 * (Y - 1), 32, 32, withBlock2.picMask.hDC, 0, 0, GUI.SRCAND);
//                        ret = GUI.BitBlt(withBlock2.picMaskedBack.hDC, 32 * (X - 1), 32 * (Y - 1), 32, 32, withBlock2.picMask2.hDC, 0, 0, GUI.SRCINVERT);
//                    }
//                    // 変更された地形にいたユニットを再表示
//                    if (Map.MapDataForUnit[X, Y] is object)
//                    {
//                        // UPGRADE_NOTE: オブジェクト MapDataForUnit() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                        Map.MapDataForUnit[X, Y] = null;
//                        GUI.EraseUnitBitmap(X, Y, false);
//                        Map.MapDataForUnit[X, Y].StandBy(X, Y, "非同期");
//                    }
//                    else
//                    {
//                        {
//                            var withBlock3 = GUI.MainForm;
//                            ret = GUI.TransparentBlt(withBlock3.picMain(0).hDC, GUI.MapToPixelX(X), GUI.MapToPixelY(Y), 32, 32, withBlock3.picTmp32(0).hDC, 0, 0, 32, 32, ColorTranslator.ToOle(Color.White));
//                        }
//                    }
//                }
//            }

//            ExecClearLayerCmdRet = LineNum + 1;
//            return ExecClearLayerCmdRet;
//        }
//        // ADD  END  240a

//        private int ExecClearObjCmd()
//        {
//            int ExecClearObjCmdRet = default;
//            short j, i, n;
//            string oname;
//            var without_refresh = default(bool);
//            n = ArgNum;
//            if (n > 1)
//            {
//                if (GetArgAsString(n) == "非同期")
//                {
//                    n = (short)(n - 1);
//                    without_refresh = true;
//                }
//            }

//            switch (n)
//            {
//                case 2:
//                    {
//                        oname = GetArgAsString((short)2);
//                        var loopTo = (short)Information.UBound(Event_Renamed.HotPointList);
//                        for (i = (short)1; i <= loopTo; i++)
//                        {
//                            if ((Event_Renamed.HotPointList[(int)i].Name ?? "") == (oname ?? ""))
//                            {
//                                break;
//                            }
//                        }

//                        if ((int)i <= Information.UBound(Event_Renamed.HotPointList))
//                        {
//                            {
//                                var withBlock = Event_Renamed.HotPointList[(int)i];
//                                if (My.MyProject.Forms.frmToolTip.Visible & (Event_Renamed.SelectedAlternative ?? "") == (withBlock.Name ?? ""))
//                                {
//                                    // ツールチップを消す
//                                    My.MyProject.Forms.frmToolTip.Hide();
//                                    // マウスカーソルを元に戻す
//                                    GUI.MainForm.picMain(0).MousePointer = 0;
//                                }
//                            }

//                            var loopTo1 = (short)(Information.UBound(Event_Renamed.HotPointList) - 1);
//                            for (j = i; j <= loopTo1; j++)
//                                // UPGRADE_WARNING: オブジェクト HotPointList(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                Event_Renamed.HotPointList[(int)j] = Event_Renamed.HotPointList[(int)j + 1];
//                            Array.Resize(ref Event_Renamed.HotPointList, Information.UBound(Event_Renamed.HotPointList));
//                        }

//                        break;
//                    }

//                case 1:
//                    {
//                        Event_Renamed.HotPointList = new Event_Renamed.HotPoint[1];
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ClearObjコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 183065


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecClearObjCmdRet = LineNum + 1;

//            // まだマウスカーソルがホットポイント上にあるか？
//            var loopTo2 = (short)Information.UBound(Event_Renamed.HotPointList);
//            for (i = 1; i <= loopTo2; i++)
//            {
//                {
//                    var withBlock1 = Event_Renamed.HotPointList[i];
//                    if (withBlock1.Left_Renamed <= GUI.MouseX & GUI.MouseX < withBlock1.Left_Renamed + withBlock1.width & withBlock1.Top <= GUI.MouseY & GUI.MouseY < withBlock1.Top + withBlock1.Height)
//                    {
//                        return ExecClearObjCmdRet;
//                    }
//                }
//            }

//            // ツールチップを消す
//            My.MyProject.Forms.frmToolTip.Hide();
//            if (!without_refresh)
//            {
//                GUI.MainForm.picMain(0).Refresh();
//            }

//            // マウスカーソルを元に戻す
//            GUI.MainForm.picMain(0).MousePointer = 0;
//            return ExecClearObjCmdRet;
//        }

//        private int ExecClearPictureCmd()
//        {
//            int ExecClearPictureCmdRet = default;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        GUI.ClearPicture();
//                        break;
//                    }

//                case 5:
//                    {
//                        GUI.ClearPicture2(GetArgAsLong((short)2) + Event_Renamed.BaseX, GetArgAsLong((short)3) + Event_Renamed.BaseY, GetArgAsLong((short)4) + Event_Renamed.BaseX, GetArgAsLong((short)5) + Event_Renamed.BaseY);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ClearPictureコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 184725


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecClearPictureCmdRet = LineNum + 1;
//            return ExecClearPictureCmdRet;
//        }

//        private int ExecClearSkillCmd()
//        {
//            int ExecClearSkillCmdRet = default;
//            string pname;
//            string slist, sname, sname2, buf;
//            string[] sarray;
//            string vname, vname2;
//            short i, j;
//            pname = GetArgAsString(2);
//            bool localIsDefined() { object argIndex1 = pname; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//            object argIndex1 = pname;
//            if (SRC.PList.IsDefined(ref argIndex1))
//            {
//                Pilot localItem() { object argIndex1 = (object)pname; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                pname = localItem().ID;
//            }
//            else if (localIsDefined())
//            {
//                PilotData localItem1() { object argIndex1 = (object)pname; var ret = SRC.PDList.Item(ref argIndex1); return ret; }

//                pname = localItem1().Name;
//            }
//            else
//            {
//                Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 185363


//                Input:
//                            Error(0)

//                 */
//            }

//            sname = GetArgAsString(3);

//            // エリアスが定義されている？
//            object argIndex3 = sname;
//            if (SRC.ALDList.IsDefined(ref argIndex3))
//            {
//                object argIndex2 = sname;
//                {
//                    var withBlock = SRC.ALDList.Item(ref argIndex2);
//                    sarray = new string[(withBlock.Count + 1)];
//                    var loopTo = withBlock.Count;
//                    for (i = 1; i <= loopTo; i++)
//                        sarray[i] = withBlock.get_AliasType(i);
//                }
//            }
//            else
//            {
//                sarray = new string[2];
//                sarray[1] = sname;
//            }

//            var loopTo1 = (short)Information.UBound(sarray);
//            for (i = 1; i <= loopTo1; i++)
//            {
//                sname = sarray[i];
//                sname2 = "";
//                vname = "Ability(" + pname + "," + sname + ")";
//                string arglist1 = Expression.GetValueAsString(ref vname);
//                if (GeneralLib.LLength(ref arglist1) >= 2)
//                {
//                    // 必要技能用変数を削除
//                    string arglist = Expression.GetValueAsString(ref vname);
//                    sname2 = GeneralLib.LIndex(ref arglist, 2);
//                    vname2 = "Ability(" + pname + "," + sname2 + ")";
//                    Expression.UndefineVariable(ref vname2);
//                }

//                // レベル設定用変数を削除
//                Expression.UndefineVariable(ref vname);

//                // 特殊能力一覧作成用変数を削除
//                vname = "Ability(" + pname + ")";
//                if (Expression.IsGlobalVariableDefined(ref vname))
//                {
//                    buf = Expression.GetValueAsString(ref vname);
//                    slist = "";
//                    var loopTo2 = GeneralLib.LLength(ref buf);
//                    for (j = 1; j <= loopTo2; j++)
//                    {
//                        if ((GeneralLib.LIndex(ref buf, j) ?? "") != (sname ?? "") & (GeneralLib.LIndex(ref buf, j) ?? "") != (sname2 ?? ""))
//                        {
//                            slist = slist + " " + GeneralLib.LIndex(ref buf, j);
//                        }
//                    }

//                    if (GeneralLib.LLength(ref slist) > 0)
//                    {
//                        slist = Strings.Trim(slist);
//                        Expression.SetVariableAsString(ref vname, ref slist);
//                    }
//                    else
//                    {
//                        Expression.UndefineVariable(ref vname);
//                    }
//                }
//            }

//            // パイロットやユニットのステータスをアップデート
//            object argIndex5 = pname;
//            if (SRC.PList.IsDefined(ref argIndex5))
//            {
//                object argIndex4 = pname;
//                {
//                    var withBlock1 = SRC.PList.Item(ref argIndex4);
//                    withBlock1.Update();
//                    if (withBlock1.Unit_Renamed is object)
//                    {
//                        withBlock1.Unit_Renamed.Update();
//                        if (withBlock1.Unit_Renamed.Status_Renamed == "出撃")
//                        {
//                            SRC.PList.UpdateSupportMod(withBlock1.Unit_Renamed);
//                        }
//                    }
//                }
//            }

//            ExecClearSkillCmdRet = LineNum + 1;
//            return ExecClearSkillCmdRet;
//        }

//        private int ExecClearSpecialPowerCmd()
//        {
//            int ExecClearSpecialPowerCmdRet = default;
//            string sname;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        sname = GetArgAsString((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        sname = GetArgAsString((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ClearSpecialPowerコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 187952


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u.IsSpecialPowerInEffect(ref sname))
//            {
//                object argIndex1 = sname;
//                u.RemoveSpecialPowerInEffect2(ref argIndex1);
//            }

//            ExecClearSpecialPowerCmdRet = LineNum + 1;
//            return ExecClearSpecialPowerCmdRet;
//        }

//        private int ExecClearStatusCmd()
//        {
//            int ExecClearStatusCmdRet = default;
//            string sname;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        sname = GetArgAsString((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        sname = GetArgAsString((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ClearStatusコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 188579


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            {
//                var withBlock = u;
//                object argIndex2 = sname;
//                if (withBlock.IsConditionSatisfied(ref argIndex2))
//                {
//                    object argIndex1 = sname;
//                    withBlock.DeleteCondition(ref argIndex1);
//                    withBlock.Update();
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        GUI.PaintUnitBitmap(ref u);
//                    }
//                }
//            }

//            ExecClearStatusCmdRet = LineNum + 1;
//            return ExecClearStatusCmdRet;
//        }

//        private int ExecCloseCmd()
//        {
//            int ExecCloseCmdRet = default;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Closeコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 189029


//                Input:
//                            Error(0)

//                 */
//            }

//            FileSystem.FileClose(GetArgAsLong(2));
//            ExecCloseCmdRet = LineNum + 1;
//            return ExecCloseCmdRet;
//        }

//        private int ExecClsCmd()
//        {
//            int ExecClsCmdRet = default;
//            var BF = default(object);
//            string cname, buf;
//            int ret;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        buf = GetArgAsString((short)2);
//                        if (Strings.Asc(buf) != 35 | Strings.Len(buf) != 7)
//                        {
//                            Event_Renamed.EventErrorMessage = "色指定が不正です";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 189557


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                        StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                        var midTmp = Strings.Mid(buf, 6, 2);
//                        StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                        var midTmp1 = Strings.Mid(buf, 4, 2);
//                        StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                        var midTmp2 = Strings.Mid(buf, 2, 2);
//                        StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                        if (!Information.IsNumeric(cname))
//                        {
//                            Event_Renamed.EventErrorMessage = "色指定が不正です";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 190067


//                            Input:
//                                                Error(0)

//                             */
//                        }
//                        GUI.MainForm.picMain(0).Line((0, 0) - ((int)GUI.MainPWidth - 1, (int)GUI.MainPHeight - 1), Conversions.ToInteger(cname), BF);
//                        GUI.MainForm.picMain(1).Line((0, 0) - ((int)GUI.MainPWidth - 1, (int)GUI.MainPHeight - 1), Conversions.ToInteger(cname), BF);
//                        GUI.ScreenIsSaved = true;
//                        break;
//                    }

//                case 1:
//                    {
//                        {
//                            var withBlock = GUI.MainForm;
//                            ret = GUI.PatBlt(withBlock.picMain(0).hDC, 0, 0, GUI.MainPWidth, GUI.MainPHeight, GUI.BLACKNESS);
//                            ret = GUI.PatBlt(withBlock.picMain(1).hDC, 0, 0, GUI.MainPWidth, GUI.MainPHeight, GUI.BLACKNESS);
//                        }

//                        GUI.ScreenIsSaved = true;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Clsコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 191690


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            GUI.IsPictureVisible = true;
//            GUI.IsCursorVisible = false;
//            GUI.PaintedAreaX1 = GUI.MainPWidth;
//            GUI.PaintedAreaY1 = GUI.MainPHeight;
//            GUI.PaintedAreaX2 = -1;
//            GUI.PaintedAreaY2 = -1;
//            ExecClsCmdRet = LineNum + 1;
//            return ExecClsCmdRet;
//        }

//        private int ExecColorCmd()
//        {
//            int ExecColorCmdRet = default;
//            string opt, cname;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Colorコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 192276


//                Input:
//                            Error(0)

//                 */
//            }

//            opt = GetArgAsString(2);
//            if (Strings.Asc(opt) != 35 | Strings.Len(opt) != 7)
//            {
//                Event_Renamed.EventErrorMessage = "色指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 192515


//                Input:
//                            Error(0)

//                 */
//            }

//            cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//            StringType.MidStmtStr(ref cname, 1, 2, "&H");
//            var midTmp = Strings.Mid(opt, 6, 2);
//            StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//            var midTmp1 = Strings.Mid(opt, 4, 2);
//            StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//            var midTmp2 = Strings.Mid(opt, 2, 2);
//            StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//            if (!Information.IsNumeric(cname))
//            {
//                Event_Renamed.EventErrorMessage = "色指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 193007


//                Input:
//                            Error(0)

//                 */
//            }

//            Event_Renamed.ObjColor = Conversions.ToInteger(cname);
//            ExecColorCmdRet = LineNum + 1;
//            return ExecColorCmdRet;
//        }

//        private int ExecColorFilterCmd()
//        {
//            int ExecColorFilterCmdRet = default;
//            short prev_x, prev_y;
//            bool late_refresh;
//            string buf;
//            int fcolor;
//            short i;
//            double trans_par;
//            if ((int)ArgNum < 2)
//            {
//                Event_Renamed.EventErrorMessage = "ColorFilterコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 193493


//                Input:
//                            Error(0)

//                 */
//            }

//            late_refresh = false;
//            Map.MapDrawIsMapOnly = false;
//            trans_par = 0.5d;
//            var loopTo = ArgNum;
//            for (i = (short)3; i <= loopTo; i++)
//            {
//                buf = GetArgAsString(i);
//                switch (buf ?? "")
//                {
//                    case "非同期":
//                        {
//                            late_refresh = true;
//                            break;
//                        }

//                    case "マップ限定":
//                        {
//                            Map.MapDrawIsMapOnly = true;
//                            break;
//                        }

//                    default:
//                        {
//                            if (Strings.Right(buf, 1) == "%" & Information.IsNumeric(Strings.Left(buf, Strings.Len(buf) - 1)))
//                            {
//                                trans_par = GeneralLib.MaxDbl(0d, GeneralLib.MinDbl(1d, Conversions.ToDouble(Strings.Left(buf, Strings.Len(buf) - 1)) / 100d));
//                            }
//                            else
//                            {
//                                Event_Renamed.EventErrorMessage = "ColorFilterコマンドに不正なオプション「" + buf + "」が使われています";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 194362


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }
//                }
//            }

//            buf = GetArgAsString(2);
//            buf = "&H" + Strings.Mid(buf, 6, 2) + Strings.Mid(buf, 4, 2) + Strings.Mid(buf, 2, 2);
//            if (Information.IsNumeric(buf))
//            {
//                fcolor = Conversions.ToInteger(buf);
//            }
//            else
//            {
//                Event_Renamed.EventErrorMessage = "ColorFilterコマンドのカラー指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 194809


//                Input:
//                            Error(0)

//                 */
//            }

//            prev_x = GUI.MapX;
//            prev_y = GUI.MapY;

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;
//            string argdraw_mode = "フィルタ";
//            string argdraw_option = "非同期";
//            GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, ref fcolor, ref trans_par);
//            foreach (Unit u in SRC.UList)
//            {
//                {
//                    var withBlock = u;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        if (withBlock.BitmapID == 0)
//                        {
//                            object argIndex1 = withBlock.Name;
//                            {
//                                var withBlock1 = SRC.UList.Item(ref argIndex1);
//                                string argfname = "ダミーユニット";
//                                if ((u.Party0 ?? "") == (withBlock1.Party0 ?? "") & withBlock1.BitmapID != 0 & (u.get_Bitmap(false) ?? "") == (withBlock1.get_Bitmap(false) ?? "") & !withBlock1.IsFeatureAvailable(ref argfname))
//                                {
//                                    u.BitmapID = withBlock1.BitmapID;
//                                }
//                                else
//                                {
//                                    u.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                }
//                            }

//                            withBlock.Name = Conversions.ToString(argIndex1);
//                        }
//                    }
//                }
//            }

//            GUI.Center(prev_x, prev_y);
//            GUI.RedrawScreen(late_refresh);

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecColorFilterCmdRet = LineNum + 1;
//            return ExecColorFilterCmdRet;
//        }

//        private int ExecCombineCmd()
//        {
//            int ExecCombineCmdRet = default;
//            Unit u;
//            string uname;
//            short anum;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        uname = GetArgAsString((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        uname = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Combineコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 196660


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            bool localIsDefined() { object argIndex1 = uname; var ret = SRC.UList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined())
//            {
//                Event_Renamed.EventErrorMessage = "「" + uname + "」というユニットが見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 196836


//                Input:
//                            Error(0)

//                 */
//            }

//            Unit localItem() { object argIndex1 = uname; var ret = SRC.UList.Item(ref argIndex1); return ret; }

//            if ((u.CurrentForm().ID ?? "") != (localItem().CurrentForm().ID ?? ""))
//            {
//                anum = u.UsedAction;
//                u.Combine(ref uname, true);
//                if (Commands.SelectedUnit is object)
//                {
//                    if ((u.ID ?? "") == (Commands.SelectedUnit.ID ?? ""))
//                    {
//                        object argIndex1 = uname;
//                        Commands.SelectedUnit = SRC.UList.Item(ref argIndex1);
//                    }
//                }

//                if (Event_Renamed.SelectedUnitForEvent is object)
//                {
//                    if ((u.ID ?? "") == (Event_Renamed.SelectedUnitForEvent.ID ?? ""))
//                    {
//                        object argIndex2 = uname;
//                        Event_Renamed.SelectedUnitForEvent = SRC.UList.Item(ref argIndex2);
//                    }
//                }

//                if (Commands.SelectedTarget is object)
//                {
//                    if ((u.ID ?? "") == (Commands.SelectedTarget.ID ?? ""))
//                    {
//                        object argIndex3 = uname;
//                        Commands.SelectedTarget = SRC.UList.Item(ref argIndex3);
//                    }
//                }

//                if (Event_Renamed.SelectedTargetForEvent is object)
//                {
//                    if ((u.ID ?? "") == (Event_Renamed.SelectedTargetForEvent.ID ?? ""))
//                    {
//                        object argIndex4 = uname;
//                        Event_Renamed.SelectedTargetForEvent = SRC.UList.Item(ref argIndex4);
//                    }
//                }

//                object argIndex5 = uname;
//                {
//                    var withBlock = SRC.UList.Item(ref argIndex5);
//                    withBlock.UsedAction = anum;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        GUI.RedrawScreen();
//                    }
//                }
//            }

//            ExecCombineCmdRet = LineNum + 1;
//            return ExecCombineCmdRet;
//        }

//        private int ExecConfirmCmd()
//        {
//            int ExecConfirmCmdRet = default;
//            short ret;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Confirmコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 198480


//                Input:
//                            Error(0)

//                 */
//            }

//            // 一度イベントを解消しておかないとMsgBoxを連続で使用したときに
//            // 動作がおかしくなる（ＶＢのバグ？）
//            Application.DoEvents();
//            ret = (short)Interaction.MsgBox(GetArgAsString(2), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Question), "選択");
//            if (ret == 1)
//            {
//                Event_Renamed.SelectedAlternative = 1.ToString();
//            }
//            else
//            {
//                Event_Renamed.SelectedAlternative = 0.ToString();
//            }

//            ExecConfirmCmdRet = LineNum + 1;
//            return ExecConfirmCmdRet;
//        }

//        private int ExecContinueCmd()
//        {
//            int ExecContinueCmdRet = default;
//            string msg;
//            short n, i;
//            short plevel;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        string argvname1 = "次ステージ";
//                        if (!Expression.IsGlobalVariableDefined(ref argvname1))
//                        {
//                            string argvname = "次ステージ";
//                            Expression.DefineGlobalVariable(ref argvname);
//                        }

//                        string argvname2 = "次ステージ";
//                        string argnew_value = GetArgAsString((short)2);
//                        Expression.SetVariableAsString(ref argvname2, ref argnew_value);
//                        break;
//                    }

//                case 1:
//                    {
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Continueコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 199596


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            Status.ClearUnitStatus();

//            // 追加経験値を得るパイロットや破壊されたユニットがいなければ処理をスキップ
//            n = 0;
//            foreach (Unit currentU in SRC.UList)
//            {
//                u = currentU;
//                if (u.Party0 == "味方")
//                {
//                    if (u.Status_Renamed == "出撃" | u.Status_Renamed == "格納" | u.Status_Renamed == "破壊")
//                    {
//                        n = 1;
//                        break;
//                    }
//                }
//            }

//            if (n == 0)
//            {
//                SRC.Turn = 0;
//            }

//            // 追加経験値を収得
//            string argoname = "追加経験値無効";
//            if (SRC.Turn > 0 & !Expression.IsOptionDefined(ref argoname))
//            {
//                Unit argu1 = null;
//                Unit argu2 = null;
//                GUI.OpenMessageForm(u1: ref argu1, u2: ref argu2);
//                n = 0;
//                msg = "";
//                foreach (Pilot p in SRC.PList)
//                {
//                    if (p.Party != "味方")
//                    {
//                        goto NextPilot;
//                    }

//                    if (p.MaxSP == 0)
//                    {
//                        goto NextPilot;
//                    }

//                    if (p.Unit_Renamed is null)
//                    {
//                        goto NextPilot;
//                    }

//                    if (p.Unit_Renamed.Status_Renamed != "出撃" & p.Unit_Renamed.Status_Renamed != "格納")
//                    {
//                        goto NextPilot;
//                    }

//                    plevel = p.Level;
//                    p.Exp = p.Exp + 2 * p.SP;

//                    // 追加パイロットや暴走時パイロットに関する処理
//                    if (p.Unit_Renamed.CountPilot() > 0 & !p.IsSupport(ref p.Unit_Renamed))
//                    {
//                        // 追加パイロットがメインパイロットの場合
//                        object argIndex1 = 1;
//                        if (ReferenceEquals(p, p.Unit_Renamed.Pilot(ref argIndex1)) & !ReferenceEquals(p, p.Unit_Renamed.MainPilot()) & p.Unit_Renamed.MainPilot().MaxSP > 0)
//                        {
//                            goto NextPilot;
//                        }

//                        // 追加パイロットがメインパイロットではなくなった場合
//                        if (!ReferenceEquals(p, p.Unit_Renamed.MainPilot()))
//                        {
//                            // 自分がユニットのパイロット一覧に含まれているか判定
//                            var loopTo = p.Unit_Renamed.CountPilot();
//                            for (i = 1; i <= loopTo; i++)
//                            {
//                                Pilot localPilot() { object argIndex1 = i; var ret = p.Unit_Renamed.Pilot(ref argIndex1); return ret; }

//                                if (ReferenceEquals(p, localPilot()))
//                                {
//                                    break;
//                                }
//                            }

//                            if (i > p.Unit_Renamed.CountPilot())
//                            {
//                                goto NextPilot;
//                            }
//                        }
//                    }

//                    if (plevel == p.Level)
//                    {
//                        msg = msg + ";" + p.get_Nickname(false) + " 経験値 +" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(2 * p.SP);
//                    }
//                    else
//                    {
//                        msg = msg + ";" + p.get_Nickname(false) + " 経験値 +" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(2 * p.SP) + " レベルアップ！（Lv" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(p.Level) + "）";
//                    }

//                    n = (short)(n + 1);
//                    if (n == 4)
//                    {
//                        string argpname = "システム";
//                        GUI.DisplayMessage(ref argpname, Strings.Mid(msg, 2));
//                        msg = "";
//                        n = 0;
//                    }

//                    NextPilot:
//                    ;
//                }

//                if (n > 0)
//                {
//                    string argpname1 = "システム";
//                    GUI.DisplayMessage(ref argpname1, Strings.Mid(msg, 2));
//                }

//                GUI.CloseMessageForm();
//            }

//            GUI.MainForm.Hide();

//            // エピローグイベントを実行
//            string arglname1 = "エピローグ";
//            if (Event_Renamed.IsEventDefined(ref arglname1))
//            {
//                // ハイパーモードや変身、能力コピーを解除
//                foreach (Unit currentU1 in SRC.UList)
//                {
//                    u = currentU1;
//                    if (u.Status_Renamed != "他形態" & u.Status_Renamed != "旧主形態" & u.Status_Renamed != "旧形態")
//                    {
//                        string argfname = "ノーマルモード";
//                        if (u.IsFeatureAvailable(ref argfname))
//                        {
//                            string localLIndex() { object argIndex1 = "ノーマルモード"; string arglist = u.FeatureData(ref argIndex1); var ret = GeneralLib.LIndex(ref arglist, 1); return ret; }

//                            string argnew_form = localLIndex();
//                            u.Transform(ref argnew_form);
//                        }
//                    }
//                }

//                string arglname = "エピローグ";
//                if (Event_Renamed.IsEventDefined(ref arglname, true))
//                {
//                    Sound.StopBGM();
//                    string argbgm_name = "Briefing";
//                    string argbgm_name1 = Sound.BGMName(ref argbgm_name);
//                    Sound.StartBGM(ref argbgm_name1);
//                }

//                SRC.Stage = "エピローグ";
//                Event_Renamed.HandleEvent("エピローグ");
//            }

//            GUI.MainForm.Hide();

//            // インターミッションに移行
//            if (!SRC.IsSubStage)
//            {
//                // 
//                InterMission.InterMissionCommand();
//                if (!SRC.IsSubStage)
//                {
//                    string argexpr = "次ステージ";
//                    if (string.IsNullOrEmpty(Expression.GetValueAsString(ref argexpr)))
//                    {
//                        Event_Renamed.EventErrorMessage = "次のステージのファイル名が設定されていません";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 203307


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    string argexpr1 = "次ステージ";
//                    SRC.StartScenario(Expression.GetValueAsString(ref argexpr1));
//                }
//                else
//                {
//                    SRC.IsSubStage = false;
//                }
//            }

//            SRC.IsScenarioFinished = true;
//            ExecContinueCmdRet = 0;
//            return ExecContinueCmdRet;
//        }

//        private int ExecCopyArrayCmd()
//        {
//            int ExecCopyArrayCmdRet = default;
//            int i;
//            short j;
//            string buf;
//            VarData var;
//            string name1, name2;
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "CopyArrayコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 203889


//                Input:
//                            Error(0)

//                 */
//            }

//            // コピー元の変数名
//            name1 = GetArg(2);
//            if (Strings.Left(name1, 1) == "$")
//            {
//                name1 = Strings.Mid(name1, 2);
//            }
//            // Eval関数
//            if (Strings.LCase(Strings.Left(name1, 5)) == "eval(")
//            {
//                if (Strings.Right(name1, 1) == ")")
//                {
//                    name1 = Strings.Mid(name1, 6, Strings.Len(name1) - 6);
//                    name1 = Expression.GetValueAsString(ref name1);
//                }
//            }

//            // コピー先の変数名
//            name2 = GetArg(3);
//            if (Strings.Left(name2, 1) == "$")
//            {
//                name1 = Strings.Mid(name2, 2);
//            }
//            // Eval関数
//            if (Strings.LCase(Strings.Left(name2, 5)) == "eval(")
//            {
//                if (Strings.Right(name2, 1) == ")")
//                {
//                    name2 = Strings.Mid(name2, 6, Strings.Len(name2) - 6);
//                    name2 = Expression.GetValueAsString(ref name2);
//                }
//            }

//            // コピー先の変数を初期化
//            // サブルーチンローカル変数の場合
//            if (Expression.IsSubLocalVariableDefined(ref name2))
//            {
//                Expression.UndefineVariable(ref name2);
//                Event_Renamed.VarIndex = (short)(Event_Renamed.VarIndex + 1);
//                {
//                    var withBlock = Event_Renamed.VarStack[Event_Renamed.VarIndex];
//                    withBlock.Name = name2;
//                    withBlock.VariableType = Expression.ValueType.StringType;
//                    withBlock.StringValue = "";
//                }
//            }
//            // ローカル変数の場合
//            else if (Expression.IsLocalVariableDefined(ref name2))
//            {
//                Expression.UndefineVariable(ref name2);
//                Expression.DefineLocalVariable(ref name2);
//            }
//            // グローバル変数の場合
//            else if (Expression.IsGlobalVariableDefined(ref name2))
//            {
//                Expression.UndefineVariable(ref name2);
//                Expression.DefineGlobalVariable(ref name2);
//            }

//            // 配列を検索し、配列要素を見つける
//            buf = "";
//            if (Expression.IsSubLocalVariableDefined(ref name1))
//            {
//                // サブルーチンローカルな配列に対するCopyArray
//                var loopTo = (int)Event_Renamed.VarIndex;
//                for (i = Event_Renamed.VarIndexStack[Event_Renamed.CallDepth - 1] + 1; i <= loopTo; i++)
//                {
//                    {
//                        var withBlock1 = Event_Renamed.VarStack[i];
//                        if (Strings.InStr(withBlock1.Name, name1 + "[") == 1)
//                        {
//                            buf = name2 + Strings.Mid(withBlock1.Name, Strings.InStr(withBlock1.Name, "["));
//                            Expression.SetVariable(ref buf, ref withBlock1.VariableType, ref withBlock1.StringValue, ref withBlock1.NumericValue);
//                        }
//                    }
//                }

//                if (string.IsNullOrEmpty(buf))
//                {
//                    var = Expression.GetVariableObject(ref name1);
//                    {
//                        var withBlock2 = var;
//                        Expression.SetVariable(ref name2, ref withBlock2.VariableType, ref withBlock2.StringValue, ref withBlock2.NumericValue);
//                    }
//                }
//            }
//            else if (Expression.IsLocalVariableDefined(ref name1))
//            {
//                // ローカルな配列に対するCopyArray
//                foreach (VarData currentVar in Event_Renamed.LocalVariableList)
//                {
//                    var = currentVar;
//                    {
//                        var withBlock3 = var;
//                        if (Strings.InStr(withBlock3.Name, name1 + "[") == 1)
//                        {
//                            buf = name2 + Strings.Mid(withBlock3.Name, Strings.InStr(withBlock3.Name, "["));
//                            Expression.SetVariable(ref buf, ref withBlock3.VariableType, ref withBlock3.StringValue, ref withBlock3.NumericValue);
//                        }
//                    }
//                }

//                if (string.IsNullOrEmpty(buf))
//                {
//                    var = Expression.GetVariableObject(ref name1);
//                    {
//                        var withBlock4 = var;
//                        Expression.SetVariable(ref name2, ref withBlock4.VariableType, ref withBlock4.StringValue, ref withBlock4.NumericValue);
//                    }
//                }
//            }
//            else if (Expression.IsGlobalVariableDefined(ref name1))
//            {
//                // グローバルな配列に対するCopyArray
//                foreach (VarData currentVar1 in Event_Renamed.GlobalVariableList)
//                {
//                    var = currentVar1;
//                    {
//                        var withBlock5 = var;
//                        if (Strings.InStr(withBlock5.Name, name1 + "[") == 1)
//                        {
//                            buf = name2 + Strings.Mid(withBlock5.Name, Strings.InStr(withBlock5.Name, "["));
//                            Expression.SetVariable(ref buf, ref withBlock5.VariableType, ref withBlock5.StringValue, ref withBlock5.NumericValue);
//                        }
//                    }
//                }

//                if (string.IsNullOrEmpty(buf))
//                {
//                    var = Expression.GetVariableObject(ref name1);
//                    {
//                        var withBlock6 = var;
//                        Expression.SetVariable(ref name2, ref withBlock6.VariableType, ref withBlock6.StringValue, ref withBlock6.NumericValue);
//                    }
//                }
//            }

//            // UPGRADE_NOTE: オブジェクト var をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            var = null;
//            ExecCopyArrayCmdRet = LineNum + 1;
//            return ExecCopyArrayCmdRet;
//        }

//        private int ExecCopyFileCmd()
//        {
//            int ExecCopyFileCmdRet = default;
//            string fname1, fname2;
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "CopyFileコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 208824


//                Input:
//                            Error(0)

//                 */
//            }

//            fname1 = GetArgAsString(2);
//            bool localFileExists() { string argfname = SRC.ExtDataPath + fname1; var ret = GeneralLib.FileExists(ref argfname); return ret; }

//            bool localFileExists1() { string argfname = SRC.ExtDataPath2 + fname1; var ret = GeneralLib.FileExists(ref argfname); return ret; }

//            bool localFileExists2() { string argfname = SRC.AppPath + fname1; var ret = GeneralLib.FileExists(ref argfname); return ret; }

//            string argfname = SRC.ScenarioPath + fname1;
//            if (GeneralLib.FileExists(ref argfname))
//            {
//                fname1 = SRC.ScenarioPath + fname1;
//            }
//            else if (localFileExists())
//            {
//                fname1 = SRC.ExtDataPath + fname1;
//            }
//            else if (localFileExists1())
//            {
//                fname1 = SRC.ExtDataPath2 + fname1;
//            }
//            else if (localFileExists2())
//            {
//                fname1 = SRC.AppPath + fname1;
//            }
//            else
//            {
//                ExecCopyFileCmdRet = LineNum + 1;
//                return ExecCopyFileCmdRet;
//            }

//            if (Strings.InStr(fname1, @"..\") > 0)
//            {
//                Event_Renamed.EventErrorMessage = @"ファイル指定に「..\」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 209700


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname1, "../") > 0)
//            {
//                Event_Renamed.EventErrorMessage = "ファイル指定に「../」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 209871


//                Input:
//                            Error(0)

//                 */
//            }

//            fname2 = SRC.ScenarioPath + GetArgAsString(3);
//            if (Strings.InStr(fname2, @"..\") > 0)
//            {
//                Event_Renamed.EventErrorMessage = @"ファイル指定に「..\」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 210118


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname2, "../") > 0)
//            {
//                Event_Renamed.EventErrorMessage = "ファイル指定に「../」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 210289


//                Input:
//                            Error(0)

//                 */
//            }

//            FileSystem.FileCopy(fname1, fname2);
//            ExecCopyFileCmdRet = LineNum + 1;
//            return ExecCopyFileCmdRet;
//        }

//        private int ExecCreateCmd()
//        {
//            int ExecCreateCmdRet = default;
//            string uname, uparty;
//            short urank;
//            string pname;
//            short plevel;
//            short ux, uy;
//            Unit u;
//            Pilot p;
//            string buf;
//            short i, num;
//            string opt;
//            num = ArgNum;
//            switch (GetArgAsString(num) ?? "")
//            {
//                case "非同期":
//                    {
//                        opt = "非同期";
//                        num = (short)(num - 1);
//                        break;
//                    }

//                case "アニメ非表示":
//                    {
//                        opt = "";
//                        num = (short)(num - 1);
//                        break;
//                    }

//                default:
//                    {
//                        opt = "出撃";
//                        break;
//                    }
//            }

//            if ((int)num < 0)
//            {
//                Event_Renamed.EventErrorMessage = "Createコマンドのパラメータの括弧の対応が取れていません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 211063


//                Input:
//                            Error(0)

//                 */
//            }
//            else if ((int)num != 8 & (int)num != 9)
//            {
//                Event_Renamed.EventErrorMessage = "Createコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 211191


//                Input:
//                            Error(0)

//                 */
//            }

//            uparty = GetArgAsString(2);
//            if (!(uparty == "味方" | uparty == "ＮＰＣ" | uparty == "敵" | uparty == "中立"))
//            {
//                Event_Renamed.EventErrorMessage = "所属の指定「" + uparty + "」が間違っています";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 211419


//                Input:
//                            Error(0)

//                 */
//            }

//            uname = GetArgAsString(3);
//            bool localIsDefined() { object argIndex1 = uname; var ret = SRC.UDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined())
//            {
//                Event_Renamed.EventErrorMessage = "指定したユニット「" + uname + "」のデータが見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 211629


//                Input:
//                            Error(0)

//                 */
//            }

//            buf = GetArgAsString(4);
//            if (!Information.IsNumeric(buf))
//            {
//                Event_Renamed.EventErrorMessage = "ユニットのランクが不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 211827


//                Input:
//                            Error(0)

//                 */
//            }

//            urank = Conversions.ToShort(buf);
//            pname = GetArgAsString(5);
//            bool localIsDefined1() { object argIndex1 = pname; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined1())
//            {
//                Event_Renamed.EventErrorMessage = "指定したパイロット「" + pname + "」のデータが見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 212061


//                Input:
//                            Error(0)

//                 */
//            }

//            buf = GetArgAsString(6);
//            if (!Information.IsNumeric(buf))
//            {
//                Event_Renamed.EventErrorMessage = "パイロットのレベルが不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 212260


//                Input:
//                            Error(0)

//                 */
//            }

//            plevel = Conversions.ToShort(buf);
//            string argoname = "レベル限界突破";
//            if (Expression.IsOptionDefined(ref argoname))
//            {
//                if (plevel > 999)
//                {
//                    plevel = 999;
//                }
//            }
//            else if (plevel > 99)
//            {
//                plevel = 99;
//            }

//            if (plevel < 1)
//            {
//                plevel = 1;
//            }

//            buf = GetArgAsString(7);
//            if (!Information.IsNumeric(buf))
//            {
//                Event_Renamed.EventErrorMessage = "Ｘ座標の値が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 212715


//                Input:
//                            Error(0)

//                 */
//            }

//            ux = Conversions.ToShort(buf);
//            if (ux < 1)
//            {
//                ux = 1;
//            }
//            else if (ux > Map.MapWidth)
//            {
//                ux = Map.MapWidth;
//            }

//            buf = GetArgAsString(8);
//            if (!Information.IsNumeric(buf))
//            {
//                Event_Renamed.EventErrorMessage = "Ｙ座標の値が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 213057


//                Input:
//                            Error(0)

//                 */
//            }

//            uy = Conversions.ToShort(buf);
//            if (uy < 1)
//            {
//                uy = 1;
//            }
//            else if (uy > Map.MapHeight)
//            {
//                uy = Map.MapHeight;
//            }

//            u = SRC.UList.Add(ref uname, urank, ref uparty);
//            if (u is null)
//            {
//                Event_Renamed.EventErrorMessage = uname + "のデータが不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 213390


//                Input:
//                            Error(0)

//                 */
//            }

//            if (num == 9)
//            {
//                string arggid = GetArgAsString(9);
//                p = SRC.PList.Add(ref pname, plevel, ref uparty, ref arggid);
//            }
//            else
//            {
//                string arggid1 = "";
//                p = SRC.PList.Add(ref pname, plevel, ref uparty, gid: ref arggid1);
//            }

//            p.Ride(ref u);
//            if (opt != "非同期" & GUI.MainForm.Visible & !GUI.IsPictureVisible)
//            {
//                GUI.Center(ux, uy);
//                GUI.RefreshScreen();
//            }

//            u.FullRecover();
//            var loopTo = u.CountOtherForm();
//            for (i = 1; i <= loopTo; i++)
//            {
//                Unit localOtherForm() { object argIndex1 = i; var ret = u.OtherForm(ref argIndex1); return ret; }

//                localOtherForm().FullSupply();
//            }

//            u.UsedAction = 0;
//            u.StandBy(ux, uy, opt);
//            u.CheckAutoHyperMode();
//            Event_Renamed.SelectedUnitForEvent = u.CurrentForm();
//            ExecCreateCmdRet = LineNum + 1;
//            return ExecCreateCmdRet;
//        }

//        private int ExecCreateFolderCmd()
//        {
//            int ExecCreateFolderCmdRet = default;
//            string fname;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "CreateFolderコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 214334


//                Input:
//                            Error(0)

//                 */
//            }

//            fname = SRC.ScenarioPath + GetArgAsString(2);
//            if (Strings.InStr(fname, @"..\") > 0)
//            {
//                Event_Renamed.EventErrorMessage = @"フォルダ指定に「..\」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 214579


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname, "../") > 0)
//            {
//                Event_Renamed.EventErrorMessage = "フォルダ指定に「../」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 214749


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.Right(fname, 1) == @"\")
//            {
//                fname = Strings.Left(fname, Strings.Len(fname) - 1);
//            }

//            if (!GeneralLib.FileExists(ref fname))
//            {
//                FileSystem.MkDir(fname);
//            }

//            ExecCreateFolderCmdRet = LineNum + 1;
//            return ExecCreateFolderCmdRet;
//        }

//        private int ExecDebugCmd()
//        {
//            int ExecDebugCmdRet = default;
//            short i;
//            var loopTo = ArgNum;
//            for (i = 2; i <= loopTo; i++)
//            {
//                if (i > 2)
//                {
//                    Debug.Write(", ");
//                }

//                Debug.Write(GetArgAsString(i));
//            }

//            Debug.Print("");
//            ExecDebugCmdRet = LineNum + 1;
//            return ExecDebugCmdRet;
//        }

//        private int ExecDestroyCmd()
//        {
//            int ExecDestroyCmdRet = default;
//            Unit u;
//            string uparty;
//            short i;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        break;
//                    }

//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Destroyコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 215862


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // 破壊キャンセル状態にある場合は解除しておく
//            object argIndex2 = "破壊キャンセル";
//            if (u.IsConditionSatisfied(ref argIndex2))
//            {
//                object argIndex1 = "破壊キャンセル";
//                u.DeleteCondition(ref argIndex1);
//            }

//            switch (u.Status_Renamed ?? "")
//            {
//                case "出撃":
//                    {
//                        u.Die();
//                        break;
//                    }

//                case "格納":
//                    {
//                        u.Escape();
//                        u.Status_Renamed = "破壊";
//                        break;
//                    }

//                case "破壊":
//                    {
//                        if (ReferenceEquals(Map.MapDataForUnit[u.x, u.y], u))
//                        {
//                            u.Die();
//                            // 既に破壊イベントが発生しているはずなので、ここで終了
//                            ExecDestroyCmdRet = LineNum + 1;
//                            return ExecDestroyCmdRet;
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        u.Status_Renamed = "破壊";
//                        break;
//                    }
//            }

//            // ステータス表示中の場合は表示を解除
//            if (ReferenceEquals(u, Status.DisplayedUnit))
//            {
//                Status.ClearUnitStatus();
//            }

//            // Destroyコマンドによって全滅したかを判定
//            uparty = u.Party0;
//            foreach (Unit currentU in SRC.UList)
//            {
//                u = currentU;
//                object argIndex3 = "憑依";
//                if ((u.Party0 ?? "") == (uparty ?? "") & (u.Status_Renamed == "出撃" | u.Status_Renamed == "格納") & !u.IsConditionSatisfied(ref argIndex3))
//                {
//                    ExecDestroyCmdRet = LineNum + 1;
//                    return ExecDestroyCmdRet;
//                }
//            }

//            // 戦闘時以外のイベント中の破壊は無視
//            var loopTo = (short)Information.UBound(Event_Renamed.EventQue);
//            for (i = 1; i <= loopTo; i++)
//            {
//                if (Event_Renamed.EventQue[i] == "プロローグ" | Event_Renamed.EventQue[i] == "エピローグ" | Event_Renamed.EventQue[i] == "スタート" | Event_Renamed.EventQue[i] == "全滅")
//                {
//                    ExecDestroyCmdRet = LineNum + 1;
//                    return ExecDestroyCmdRet;
//                }
//            }

//            // 後で全滅イベントを実行
//            Event_Renamed.RegisterEvent("全滅", uparty);
//            ExecDestroyCmdRet = LineNum + 1;
//            return ExecDestroyCmdRet;
//        }

//        private int ExecDisableCmd()
//        {
//            int ExecDisableCmdRet = default;
//            string vname, aname, uname = default;
//            short i;
//            bool need_update;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        aname = GetArgAsString((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        uname = GetArgAsString((short)2);
//                        aname = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Disableコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 217817


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (string.IsNullOrEmpty(aname))
//            {
//                Event_Renamed.EventErrorMessage = "Disableコマンドに指定された能力名が空文字列です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 217954


//                Input:
//                            Error(0)

//                 */
//            }

//            if (!string.IsNullOrEmpty(uname))
//            {
//                vname = "Disable(" + uname + "," + aname + ")";
//            }
//            else
//            {
//                vname = "Disable(" + aname + ")";
//            }

//            // Disable用変数を設定
//            if (!Expression.IsGlobalVariableDefined(ref vname))
//            {
//                Expression.DefineGlobalVariable(ref vname);
//                Expression.SetVariableAsLong(ref vname, 1);
//            }
//            else
//            {
//                // 既に設定済みであればそのまま終了
//                ExecDisableCmdRet = LineNum + 1;
//                return ExecDisableCmdRet;
//            }

//            // ユニットのステータスを更新
//            if (!string.IsNullOrEmpty(uname))
//            {
//                {
//                    var withBlock = SRC.UList;
//                    object argIndex1 = uname;
//                    if (withBlock.IsDefined(ref argIndex1))
//                    {
//                        Unit localItem() { object argIndex1 = uname; var ret = withBlock.Item(ref argIndex1); return ret; }

//                        localItem().CurrentForm().Update();
//                    }
//                }
//            }
//            else
//            {
//                foreach (Unit u in SRC.UList)
//                {
//                    if (u.Status_Renamed == "出撃")
//                    {
//                        // ステータスを更新する必要があるかどうかチェックする
//                        need_update = false;
//                        if (u.IsFeatureAvailable(ref aname))
//                        {
//                            need_update = true;
//                        }
//                        else
//                        {
//                            var loopTo = u.CountItem();
//                            for (i = 1; i <= loopTo; i++)
//                            {
//                                Item localItem1() { object argIndex1 = i; var ret = u.Item(ref argIndex1); return ret; }

//                                if ((localItem1().Name ?? "") == (aname ?? ""))
//                                {
//                                    need_update = true;
//                                    break;
//                                }
//                            }
//                        }

//                        // 必要がある場合はステータスを更新
//                        if (need_update)
//                        {
//                            u.Update();
//                        }
//                    }
//                }
//            }

//            ExecDisableCmdRet = LineNum + 1;
//            return ExecDisableCmdRet;
//        }

//        private int ExecDoCmd()
//        {
//            int ExecDoCmdRet = default;
//            int i;
//            short depth;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        ExecDoCmdRet = LineNum + 1;
//                        return ExecDoCmdRet;
//                    }

//                case 3:
//                    {
//                        switch (GetArg((short)2) ?? "")
//                        {
//                            case "while":
//                                {
//                                    if (GetArgAsLong((short)3) != 0)
//                                    {
//                                        ExecDoCmdRet = LineNum + 1;
//                                        return ExecDoCmdRet;
//                                    }

//                                    break;
//                                }

//                            case "until":
//                                {
//                                    if (GetArgAsLong((short)3) == 0)
//                                    {
//                                        ExecDoCmdRet = LineNum + 1;
//                                        return ExecDoCmdRet;
//                                    }

//                                    break;
//                                }

//                            default:
//                                {
//                                    Event_Renamed.EventErrorMessage = "Doコマンドの書式が間違っています";
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 219765


//                                    Input:
//                                                            Error(0)

//                                     */
//                                    break;
//                                }
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Doコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 219883


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // 条件式がFalseのため本体をスキップ
//            depth = 1;
//            var loopTo = Information.UBound(Event_Renamed.EventCmd);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                switch (Event_Renamed.EventCmd[i].Name)
//                {
//                    case Event_Renamed.CmdType.DoCmd:
//                        {
//                            depth = (short)(depth + 1);
//                            break;
//                        }

//                    case Event_Renamed.CmdType.LoopCmd:
//                        {
//                            depth = (short)(depth - 1);
//                            if (depth == 0)
//                            {
//                                ExecDoCmdRet = i + 1;
//                                return ExecDoCmdRet;
//                            }

//                            break;
//                        }
//                }
//            }

//            Event_Renamed.EventErrorMessage = "DoとLoopが対応していません";
//            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 220471


//            Input:
//                    Error(0)

//             */
//        }

//        private int ExecLoopCmd()
//        {
//            int ExecLoopCmdRet = default;
//            int i;
//            short depth;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        break;
//                    }

//                case 3:
//                    {
//                        switch (GetArg((short)2) ?? "")
//                        {
//                            case "while":
//                                {
//                                    if (GetArgAsLong((short)3) == 0)
//                                    {
//                                        ExecLoopCmdRet = LineNum + 1;
//                                        return ExecLoopCmdRet;
//                                    }

//                                    break;
//                                }

//                            case "until":
//                                {
//                                    if (GetArgAsLong((short)3) != 0)
//                                    {
//                                        ExecLoopCmdRet = LineNum + 1;
//                                        return ExecLoopCmdRet;
//                                    }

//                                    break;
//                                }

//                            default:
//                                {
//                                    Event_Renamed.EventErrorMessage = "Loop文の書式が間違っています";
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 221025


//                                    Input:
//                                                            Error(0)

//                                     */
//                                    break;
//                                }
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Loop文の引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 221142


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // 条件式がTrueのため先頭に戻る
//            i = LineNum;
//            depth = 1;
//            while (i > 1)
//            {
//                i = i - 1;
//                switch (Event_Renamed.EventCmd[i].Name)
//                {
//                    case Event_Renamed.CmdType.DoCmd:
//                        {
//                            depth = (short)(depth - 1);
//                            if (depth == 0)
//                            {
//                                ExecLoopCmdRet = i;
//                                return ExecLoopCmdRet;
//                            }

//                            break;
//                        }

//                    case Event_Renamed.CmdType.LoopCmd:
//                        {
//                            depth = (short)(depth + 1);
//                            break;
//                        }
//                }
//            }

//            Event_Renamed.EventErrorMessage = "DoとLoopが対応していません";
//            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 221658


//            Input:
//                    Error(0)

//             */
//        }

//        private int ExecDrawOptionCmd()
//        {
//            int ExecDrawOptionCmdRet = default;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "DrawOptionコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 221846


//                Input:
//                            Error(0)

//                 */
//            }

//            Event_Renamed.ObjDrawOption = GetArgAsString(2);
//            ExecDrawOptionCmdRet = LineNum + 1;
//            return ExecDrawOptionCmdRet;
//        }

//        private int ExecDrawWidthCmd()
//        {
//            int ExecDrawWidthCmdRet = default;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "DrawWidthコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 222158


//                Input:
//                            Error(0)

//                 */
//            }

//            Event_Renamed.ObjDrawWidth = GetArgAsLong(2);
//            ExecDrawWidthCmdRet = LineNum + 1;
//            return ExecDrawWidthCmdRet;
//        }

//        private int ExecEnableCmd()
//        {
//            int ExecEnableCmdRet = default;
//            string vname, aname, uname = default;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        aname = GetArgAsString((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        uname = GetArgAsString((short)2);
//                        aname = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Enableコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 222673


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (!string.IsNullOrEmpty(uname))
//            {
//                vname = "Disable(" + uname + "," + aname + ")";
//            }
//            else
//            {
//                vname = "Disable(" + aname + ")";
//            }

//            // Disable用変数を削除
//            if (Expression.IsGlobalVariableDefined(ref vname))
//            {
//                Expression.UndefineVariable(ref vname);
//            }
//            else
//            {
//                // 既に設定済みであればそのまま終了
//                ExecEnableCmdRet = LineNum + 1;
//                return ExecEnableCmdRet;
//            }

//            // ユニットのステータスを更新
//            if (!string.IsNullOrEmpty(uname))
//            {
//                {
//                    var withBlock = SRC.UList;
//                    object argIndex1 = uname;
//                    if (withBlock.IsDefined(ref argIndex1))
//                    {
//                        Unit localItem() { object argIndex1 = uname; var ret = withBlock.Item(ref argIndex1); return ret; }

//                        localItem().CurrentForm().Update();
//                    }
//                }
//            }
//            else
//            {
//                foreach (Unit u in SRC.UList)
//                {
//                    if (u.Status_Renamed == "出撃")
//                    {
//                        u.Update();
//                    }
//                }
//            }

//            ExecEnableCmdRet = LineNum + 1;
//            return ExecEnableCmdRet;
//        }

//        private int ExecEquipCmd()
//        {
//            int ExecEquipCmdRet = default;
//            Unit u;
//            string iname;
//            Item itm;
//            short i;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        iname = GetArgAsString((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        iname = GetArgAsString((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Equipコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 223923


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // 大文字・小文字、ひらがな・かたかなの違いを正しく判定できるように、
//            // 名前をデータのそれとあわせる
//            object argIndex1 = iname;
//            if (SRC.IDList.IsDefined(ref argIndex1))
//            {
//                ItemData localItem() { object argIndex1 = iname; var ret = SRC.IDList.Item(ref argIndex1); return ret; }

//                iname = localItem().Name;
//            }

//            // 装備するアイテムを検索 or 作成
//            bool localIsDefined() { object argIndex1 = iname; var ret = SRC.IDList.IsDefined(ref argIndex1); return ret; }

//            object argIndex3 = iname;
//            if (SRC.IList.IsDefined(ref argIndex3))
//            {
//                Item localItem1() { object argIndex1 = (object)iname; var ret = SRC.IList.Item(ref argIndex1); return ret; }

//                if ((iname ?? "") == (localItem1().Name ?? ""))
//                {
//                    // アイテム名で指定した場合
//                    if (u.Party0 == "味方")
//                    {
//                        // まずは装備されてないものを探す
//                        foreach (Item currentItm in SRC.IList)
//                        {
//                            itm = currentItm;
//                            {
//                                var withBlock = itm;
//                                if ((withBlock.Name ?? "") == (iname ?? "") & withBlock.Unit_Renamed is null & withBlock.Exist)
//                                {
//                                    goto EquipItem;
//                                }
//                            }
//                        }
//                        // なかったら装備されているものを…
//                        foreach (Item currentItm1 in SRC.IList)
//                        {
//                            itm = currentItm1;
//                            {
//                                var withBlock1 = itm;
//                                if ((withBlock1.Name ?? "") == (iname ?? "") & withBlock1.Unit_Renamed is object & withBlock1.Exist)
//                                {
//                                    if (withBlock1.Unit_Renamed.Party0 == "味方")
//                                    {
//                                        goto EquipItem;
//                                    }
//                                }
//                            }
//                        }
//                        // それでもなければ新たに作成
//                        itm = SRC.IList.Add(ref iname);
//                    }
//                    else
//                    {
//                        itm = SRC.IList.Add(ref iname);
//                    }
//                }
//                else
//                {
//                    // アイテムＩＤで指定した場合
//                    object argIndex2 = (object)iname;
//                    itm = SRC.IList.Item(ref argIndex2);
//                }
//            }
//            else if (localIsDefined())
//            {
//                itm = SRC.IList.Add(ref iname);
//            }
//            else
//            {
//                Event_Renamed.EventErrorMessage = "「" + iname + "」というアイテムは存在しません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 225275


//                Input:
//                            Error(0)

//                 */
//            }

//            EquipItem:
//            ;

//            // アイテムを装備
//            string ubitmap;
//            short rank_lv = default, cmd_lv = default, support_lv = default;
//            if (itm is object)
//            {
//                {
//                    var withBlock2 = itm;
//                    if (withBlock2.Exist)
//                    {
//                        if (withBlock2.Unit_Renamed is object)
//                        {
//                            object argIndex4 = withBlock2.ID;
//                            withBlock2.Unit_Renamed.DeleteItem(ref argIndex4);
//                        }

//                        {
//                            var withBlock3 = u;
//                            ubitmap = withBlock3.get_Bitmap(false);
//                            if (withBlock3.CountPilot() > 0)
//                            {
//                                {
//                                    var withBlock4 = withBlock3.MainPilot();
//                                    object argIndex5 = "指揮";
//                                    string argref_mode = "";
//                                    cmd_lv = (short)withBlock4.SkillLevel(ref argIndex5, ref_mode: ref argref_mode);
//                                    object argIndex6 = "階級";
//                                    string argref_mode1 = "";
//                                    rank_lv = (short)withBlock4.SkillLevel(ref argIndex6, ref_mode: ref argref_mode1);
//                                    object argIndex7 = "広域サポート";
//                                    string argref_mode2 = "";
//                                    support_lv = (short)withBlock4.SkillLevel(ref argIndex7, ref_mode: ref argref_mode2);
//                                }
//                            }

//                            withBlock3.AddItem(ref itm);

//                            // ユニット画像が変化した？
//                            if ((ubitmap ?? "") != (withBlock3.get_Bitmap(false) ?? ""))
//                            {
//                                withBlock3.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                var loopTo = withBlock3.CountOtherForm();
//                                for (i = 1; i <= loopTo; i++)
//                                {
//                                    Unit localOtherForm() { object argIndex1 = i; var ret = withBlock3.OtherForm(ref argIndex1); return ret; }

//                                    localOtherForm().BitmapID = 0;
//                                }

//                                if (withBlock3.Status_Renamed == "出撃")
//                                {
//                                    if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                    {
//                                        GUI.PaintUnitBitmap(ref u);
//                                    }
//                                }
//                            }

//                            // 支援効果が変化した？
//                            if (withBlock3.CountPilot() > 0)
//                            {
//                                {
//                                    var withBlock5 = withBlock3.MainPilot();
//                                    object argIndex8 = "指揮";
//                                    string argref_mode3 = "";
//                                    object argIndex9 = "階級";
//                                    string argref_mode4 = "";
//                                    object argIndex10 = "広域サポート";
//                                    string argref_mode5 = "";
//                                    if (cmd_lv != withBlock5.SkillLevel(ref argIndex8, ref_mode: ref argref_mode3) | rank_lv != withBlock5.SkillLevel(ref argIndex9, ref_mode: ref argref_mode4) | support_lv != withBlock5.SkillLevel(ref argIndex10, ref_mode: ref argref_mode5))
//                                    {
//                                        if (u.Status_Renamed == "出撃")
//                                        {
//                                            SRC.PList.UpdateSupportMod(u);
//                                        }
//                                    }
//                                }
//                            }

//                            // 最大弾数が変化した？
//                            string argfname = "最大弾数増加";
//                            if (itm.IsFeatureAvailable(ref argfname))
//                            {
//                                withBlock3.FullSupply();
//                            }
//                        }
//                    }
//                }
//            }

//            ExecEquipCmdRet = LineNum + 1;
//            return ExecEquipCmdRet;
//        }

//        private int ExecEscapeCmd()
//        {
//            int ExecEscapeCmdRet = default;
//            string pname, uparty = default;
//            Unit u;
//            short i, num;
//            var opt = default(string);
//            var ucount = default(short);
//            num = ArgNum;
//            if (num > 1)
//            {
//                if (GetArgAsString(num) == "非同期")
//                {
//                    opt = "非同期";
//                    num = (short)(num - 1);
//                }
//            }

//            switch (num)
//            {
//                case 2:
//                    {
//                        pname = GetArgAsString((short)2);
//                        if (pname == "味方" | pname == "ＮＰＣ" | pname == "敵" | pname == "中立")
//                        {
//                            uparty = pname;
//                            foreach (Unit currentU in SRC.UList)
//                            {
//                                u = currentU;
//                                {
//                                    var withBlock = u;
//                                    if ((withBlock.Party0 ?? "") == (uparty ?? ""))
//                                    {
//                                        if (withBlock.Status_Renamed == "出撃")
//                                        {
//                                            withBlock.Escape(opt);
//                                            ucount = (short)((int)ucount + 1);
//                                        }
//                                        else if (withBlock.Status_Renamed == "破壊")
//                                        {
//                                            if (1 <= (int)withBlock.x & withBlock.x <= Map.MapWidth & 1 <= (int)withBlock.y & withBlock.y <= Map.MapHeight)
//                                            {
//                                                if (ReferenceEquals(u, Map.MapDataForUnit[withBlock.x, withBlock.y]))
//                                                {
//                                                    // 破壊キャンセルで画面上に残っていた
//                                                    withBlock.Escape(opt);
//                                                }
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        else
//                        {
//                            object argIndex1 = (object)pname;
//                            u = SRC.UList.Item2(ref argIndex1);
//                            if (u is null)
//                            {
//                                {
//                                    var withBlock1 = SRC.PList;
//                                    bool localIsDefined() { object argIndex1 = (object)pname; var ret = withBlock1.IsDefined(ref argIndex1); return ret; }

//                                    if (!localIsDefined())
//                                    {
//                                        Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 228167


//                                        Input:
//                                                                        Error(0)

//                                         */
//                                    }

//                                    Pilot localItem() { object argIndex1 = (object)pname; var ret = withBlock1.Item(ref argIndex1); return ret; }

//                                    u = localItem().Unit_Renamed;
//                                }
//                            }

//                            if (u is object)
//                            {
//                                if (u.Status_Renamed == "出撃")
//                                {
//                                    ucount = (short)1;
//                                }

//                                u.Escape(opt);
//                                uparty = u.Party0;
//                            }
//                        }

//                        break;
//                    }

//                case 1:
//                    {
//                        {
//                            var withBlock2 = Event_Renamed.SelectedUnitForEvent;
//                            if (withBlock2.Status_Renamed == "出撃")
//                            {
//                                ucount = (short)1;
//                            }

//                            withBlock2.Escape(opt);
//                            uparty = withBlock2.Party0;
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Escapeコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 228757


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // Escapeコマンドによって全滅したかを判定
//            if (uparty != "ＮＰＣ" & uparty != "味方" & ucount > 0)
//            {
//                foreach (Unit currentU1 in SRC.UList)
//                {
//                    u = currentU1;
//                    object argIndex2 = "憑依";
//                    if ((u.Party0 ?? "") == (uparty ?? "") & (u.Status_Renamed == "出撃" | u.Status_Renamed == "格納") & !u.IsConditionSatisfied(ref argIndex2))
//                    {
//                        ExecEscapeCmdRet = LineNum + 1;
//                        return ExecEscapeCmdRet;
//                    }
//                }

//                // 戦闘時以外のイベント中の撤退は無視
//                var loopTo = (short)Information.UBound(Event_Renamed.EventQue);
//                for (i = 1; i <= loopTo; i++)
//                {
//                    if (Event_Renamed.EventQue[i] == "プロローグ" | Event_Renamed.EventQue[i] == "エピローグ" | Event_Renamed.EventQue[i] == "スタート" | GeneralLib.LIndex(ref Event_Renamed.EventQue[i], 1) == "マップ攻撃破壊")
//                    {
//                        ExecEscapeCmdRet = LineNum + 1;
//                        return ExecEscapeCmdRet;
//                    }
//                }

//                // 後で全滅イベントを実行
//                Event_Renamed.RegisterEvent("全滅", uparty);
//            }

//            ExecEscapeCmdRet = LineNum + 1;
//            return ExecEscapeCmdRet;
//        }

//        private int ExecExecCmd()
//        {
//            int ExecExecCmdRet = default;
//            string fname, opt = default;
//            string msg;
//            short i, n, j;
//            short plevel;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        fname = GetArgAsString((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        fname = GetArgAsString((short)2);
//                        opt = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Execコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 230231


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            Status.ClearUnitStatus();

//            // 追加経験値を得るパイロットや破壊されたユニットがいなければ処理をスキップ
//            n = 0;
//            foreach (Unit currentU in SRC.UList)
//            {
//                u = currentU;
//                if (u.Party0 == "味方")
//                {
//                    if (u.Status_Renamed == "出撃" | u.Status_Renamed == "格納" | u.Status_Renamed == "破壊")
//                    {
//                        n = 1;
//                        break;
//                    }
//                }
//            }

//            if (n == 0)
//            {
//                SRC.Turn = 0;
//            }

//            // 追加経験値を収得
//            string argoname = "追加経験値無効";
//            if (SRC.Turn > 0 & !Expression.IsOptionDefined(ref argoname))
//            {
//                Unit argu1 = null;
//                Unit argu2 = null;
//                GUI.OpenMessageForm(u1: ref argu1, u2: ref argu2);
//                n = 0;
//                msg = "";
//                foreach (Pilot p in SRC.PList)
//                {
//                    if (p.Party != "味方")
//                    {
//                        goto NextPilot;
//                    }

//                    if (p.MaxSP == 0)
//                    {
//                        goto NextPilot;
//                    }

//                    if (p.Unit_Renamed is null)
//                    {
//                        goto NextPilot;
//                    }

//                    if (p.Unit_Renamed.Status_Renamed != "出撃" & p.Unit_Renamed.Status_Renamed != "格納")
//                    {
//                        goto NextPilot;
//                    }

//                    plevel = p.Level;
//                    p.Exp = p.Exp + 2 * p.SP;

//                    // 追加パイロットや暴走時パイロットに関する処理
//                    if (p.Unit_Renamed.CountPilot() > 0 & !p.IsSupport(ref p.Unit_Renamed))
//                    {
//                        // 追加パイロットがメインパイロットの場合
//                        object argIndex1 = 1;
//                        if (ReferenceEquals(p, p.Unit_Renamed.Pilot(ref argIndex1)) & !ReferenceEquals(p, p.Unit_Renamed.MainPilot()) & p.Unit_Renamed.MainPilot().MaxSP > 0)
//                        {
//                            goto NextPilot;
//                        }

//                        // 追加パイロットがメインパイロットではなくなった場合
//                        if (!ReferenceEquals(p, p.Unit_Renamed.MainPilot()))
//                        {
//                            // 自分がユニットのパイロット一覧に含まれているか判定
//                            var loopTo = p.Unit_Renamed.CountPilot();
//                            for (i = 1; i <= loopTo; i++)
//                            {
//                                Pilot localPilot() { object argIndex1 = i; var ret = p.Unit_Renamed.Pilot(ref argIndex1); return ret; }

//                                if (ReferenceEquals(p, localPilot()))
//                                {
//                                    break;
//                                }
//                            }

//                            if (i > p.Unit_Renamed.CountPilot())
//                            {
//                                goto NextPilot;
//                            }
//                        }
//                    }

//                    if (plevel == p.Level)
//                    {
//                        msg = msg + ";" + p.get_Nickname(false) + " 経験値 +" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(2 * p.SP);
//                    }
//                    else
//                    {
//                        msg = msg + ";" + p.get_Nickname(false) + " 経験値 +" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(2 * p.SP) + " レベルアップ！（Lv" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(p.Level) + "）";
//                    }

//                    n = (short)(n + 1);
//                    if (n == 4)
//                    {
//                        string argpname = "システム";
//                        GUI.DisplayMessage(ref argpname, Strings.Mid(msg, 2));
//                        msg = "";
//                        n = 0;
//                    }

//                    NextPilot:
//                    ;
//                }

//                if (n > 0)
//                {
//                    string argpname1 = "システム";
//                    GUI.DisplayMessage(ref argpname1, Strings.Mid(msg, 2));
//                }

//                GUI.CloseMessageForm();
//            }

//            GUI.MainForm.Hide();

//            // エピローグイベントを実行
//            string arglname1 = "エピローグ";
//            if (Event_Renamed.IsEventDefined(ref arglname1))
//            {
//                // ハイパーモードや変身、能力コピーを解除
//                foreach (Unit currentU1 in SRC.UList)
//                {
//                    u = currentU1;
//                    if (u.Status_Renamed != "他形態" & u.Status_Renamed != "旧主形態" & u.Status_Renamed != "旧形態")
//                    {
//                        string argfname = "ノーマルモード";
//                        if (u.IsFeatureAvailable(ref argfname))
//                        {
//                            string localLIndex() { object argIndex1 = "ノーマルモード"; string arglist = u.FeatureData(ref argIndex1); var ret = GeneralLib.LIndex(ref arglist, 1); return ret; }

//                            string argnew_form = localLIndex();
//                            u.Transform(ref argnew_form);
//                        }
//                    }
//                }

//                string arglname = "エピローグ";
//                if (Event_Renamed.IsEventDefined(ref arglname, true))
//                {
//                    Sound.StopBGM();
//                    string argbgm_name = "Briefing";
//                    string argbgm_name1 = Sound.BGMName(ref argbgm_name);
//                    Sound.StartBGM(ref argbgm_name1);
//                }

//                SRC.Stage = "エピローグ";
//                Event_Renamed.HandleEvent("エピローグ");
//            }

//            GUI.MainForm.Hide();

//            // マップをクリア
//            var loopTo1 = Map.MapWidth;
//            for (i = 1; i <= loopTo1; i++)
//            {
//                var loopTo2 = Map.MapHeight;
//                for (j = 1; j <= loopTo2; j++)
//                    // UPGRADE_NOTE: オブジェクト MapDataForUnit() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                    Map.MapDataForUnit[i, j] = null;
//            }

//            // 各種データをアップデート
//            SRC.UList.Update();
//            SRC.PList.Update();
//            SRC.IList.Update();
//            Event_Renamed.ClearEventData();
//            Map.ClearMap();

//            // 通常ステージとして実行する？
//            if (opt == "通常ステージ")
//            {
//                SRC.IsSubStage = false;
//            }
//            else
//            {
//                SRC.IsSubStage = true;
//            }

//            // イベントファイルを実行
//            SRC.StartScenario(fname);
//            SRC.IsScenarioFinished = true;
//            ExecExecCmdRet = 0;
//            return ExecExecCmdRet;
//        }

//        private int ExecExitCmd()
//        {
//            int ExecExitCmdRet = default;
//            ExecExitCmdRet = 0;
//            return ExecExitCmdRet;
//        }

//        private int ExecExchangeItemCmd()
//        {
//            int ExecExchangeItemCmdRet = default;
//            Unit u;
//            var ipart = default(string);
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        ipart = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ExchangeItemコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 235024


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            InterMission.ExchangeItemCommand(ref u, ref ipart);
//            ExecExchangeItemCmdRet = LineNum + 1;
//            return ExecExchangeItemCmdRet;
//        }

//        private int ExecExplodeCmd()
//        {
//            int ExecExplodeCmdRet = default;
//            string esize;
//            short tx, ty;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        esize = GetArgAsString((short)2);
//                        tx = GUI.MapX;
//                        ty = GUI.MapY;
//                        break;
//                    }

//                case 4:
//                    {
//                        esize = GetArgAsString((short)2);
//                        tx = (short)GetArgAsLong((short)3);
//                        ty = (short)GetArgAsLong((short)4);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Explodeコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 235613


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // 爆発の表示
//            Effect.ExplodeAnimation(ref esize, tx, ty);
//            ExecExplodeCmdRet = LineNum + 1;
//            return ExecExplodeCmdRet;
//        }

//        private int ExecExpUpCmd()
//        {
//            int ExecExpUpCmdRet = default;
//            string pname;
//            Pilot p;
//            short prev_lv;
//            double hp_ratio = default, en_ratio = default;
//            short num;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        p = GetArgAsPilot((short)2);
//                        num = (short)GetArgAsLong((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        {
//                            var withBlock = Event_Renamed.SelectedUnitForEvent;
//                            if ((int)withBlock.CountPilot() > 0)
//                            {
//                                object argIndex1 = (object)1;
//                                p = withBlock.Pilot(ref argIndex1);
//                            }
//                            else
//                            {
//                                ExecExpUpCmdRet = LineNum + 1;
//                                return ExecExpUpCmdRet;
//                            }
//                        }

//                        num = (short)GetArgAsLong((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ExpUpコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 236403


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (p.Unit_Renamed is object)
//            {
//                {
//                    var withBlock1 = p.Unit_Renamed;
//                    hp_ratio = 100 * withBlock1.HP / (double)withBlock1.MaxHP;
//                    en_ratio = 100 * withBlock1.EN / (double)withBlock1.MaxEN;
//                }
//            }

//            prev_lv = p.Level;
//            p.Exp = p.Exp + num;
//            if (p.Level == prev_lv)
//            {
//                ExecExpUpCmdRet = LineNum + 1;
//                return ExecExpUpCmdRet;
//            }

//            p.Update();

//            // ＳＰ＆霊力をアップデート
//            p.SP = p.SP;
//            p.Plana = p.Plana;
//            if (p.Unit_Renamed is object)
//            {
//                {
//                    var withBlock2 = p.Unit_Renamed;
//                    withBlock2.Update();
//                    withBlock2.HP = (int)(withBlock2.MaxHP * hp_ratio / 100d);
//                    withBlock2.EN = (int)(withBlock2.MaxEN * en_ratio / 100d);
//                }

//                SRC.PList.UpdateSupportMod(p.Unit_Renamed);
//            }

//            ExecExpUpCmdRet = LineNum + 1;
//            return ExecExpUpCmdRet;
//        }

//        private int ExecFadeInCmd()
//        {
//            int ExecFadeInCmdRet = default;
//            int cur_time, start_time, wait_time;
//            int i, ret;
//            short num;
//            if (GUI.IsRButtonPressed())
//            {
//                GUI.MainForm.picMain(0).Refresh();
//                ExecFadeInCmdRet = LineNum + 1;
//                return ExecFadeInCmdRet;
//            }

//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        num = (short)10;
//                        break;
//                    }

//                case 2:
//                    {
//                        num = (short)GetArgAsLong((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "FadeInコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 237839


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            GUI.SaveScreen();
//            {
//                var withBlock = GUI.MainForm;
//                {
//                    var withBlock1 = withBlock.picTmp;
//                    withBlock1.Picture = Image.FromFile("");
//                    withBlock1.width = GUI.MainPWidth;
//                    withBlock1.Height = GUI.MainPHeight;
//                }

//                // MOD START マージ
//                // ret = BitBlt(.picTmp.hDC, _
//                // '            0, 0, MapPWidth, MapPHeight, _
//                // '            .picMain(0).hDC, 0, 0, SRCCOPY)
//                ret = GUI.BitBlt(withBlock.picTmp.hDC, 0, 0, GUI.MainPWidth, GUI.MainPHeight, withBlock.picMain(0).hDC, 0, 0, GUI.SRCCOPY);
//                // MOD END マージ

//                var argpic = withBlock.picMain(0);
//                Graphics.InitFade(ref argpic, num);
//                start_time = GeneralLib.timeGetTime();
//                wait_time = 50;
//                var loopTo = (int)num;
//                for (i = 0; i <= loopTo; i++)
//                {
//                    if (i % 4 == 0)
//                    {
//                        if (GUI.IsRButtonPressed())
//                        {
//                            break;
//                        }
//                    }

//                    var argpic1 = withBlock.picMain(0);
//                    Graphics.DoFade(ref argpic1, i);
//                    withBlock.picMain(0).Refresh();
//                    cur_time = GeneralLib.timeGetTime();
//                    while (cur_time < start_time + wait_time * (i + 1))
//                    {
//                        Application.DoEvents();
//                        cur_time = GeneralLib.timeGetTime();
//                    }
//                }

//                Graphics.FinishFade();

//                ret = GUI.BitBlt(withBlock.picMain(0).hDC, 0, 0, GUI.MapPWidth, GUI.MapPHeight, withBlock.picTmp.hDC, 0, 0, GUI.SRCCOPY);
//                withBlock.picMain(0).Refresh();

//                {
//                    var withBlock2 = withBlock.picTmp;
//                    withBlock2.Picture = Image.FromFile("");
//                    withBlock2.width = 32;
//                    withBlock2.Height = 32;
//                }
//            }

//            ExecFadeInCmdRet = LineNum + 1;
//            return ExecFadeInCmdRet;
//        }

//        private int ExecFadeOutCmd()
//        {
//            int ExecFadeOutCmdRet = default;
//            int cur_time, start_time, wait_time;
//            int i, ret;
//            short num;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        num = (short)10;
//                        break;
//                    }

//                case 2:
//                    {
//                        num = (short)GetArgAsLong((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "FadeOutコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 242903


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            GUI.SaveScreen();
//            {
//                var withBlock = GUI.MainForm;
//                var argpic = withBlock.picMain(0);
//                Graphics.InitFade(ref argpic, num);
//                start_time = GeneralLib.timeGetTime();
//                wait_time = 50;
//                var loopTo = (int)num;
//                for (i = 0; i <= loopTo; i++)
//                {
//                    if (i % 4 == 0)
//                    {
//                        if (GUI.IsRButtonPressed())
//                        {
//                            {
//                                var withBlock1 = withBlock.picMain(0);
//                                ret = GUI.PatBlt(withBlock1.hDC, 0, 0, withBlock1.width, withBlock1.Height, GUI.BLACKNESS);
//                                withBlock1.Refresh();
//                            }

//                            break;
//                        }
//                    }

//                    var argpic1 = withBlock.picMain(0);
//                    Graphics.DoFade(ref argpic1, (int)num - i);
//                    withBlock.picMain(0).Refresh();
//                    cur_time = GeneralLib.timeGetTime();
//                    while (cur_time < start_time + wait_time * (i + 1))
//                    {
//                        Application.DoEvents();
//                        cur_time = GeneralLib.timeGetTime();
//                    }
//                }

//                Graphics.FinishFade();
//            }

//            GUI.IsPictureVisible = true;
//            GUI.PaintedAreaX1 = GUI.MainPWidth;
//            GUI.PaintedAreaY1 = GUI.MainPHeight;
//            GUI.PaintedAreaX2 = -1;
//            GUI.PaintedAreaY2 = -1;
//            ExecFadeOutCmdRet = LineNum + 1;
//            return ExecFadeOutCmdRet;
//        }

//        private int ExecFillColorCmd()
//        {
//            int ExecFillColorCmdRet = default;
//            string opt, cname;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "FillColorコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 245472


//                Input:
//                            Error(0)

//                 */
//            }

//            opt = GetArgAsString(2);
//            if (Strings.Asc(opt) != 35 | Strings.Len(opt) != 7)
//            {
//                Event_Renamed.EventErrorMessage = "色指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 245711


//                Input:
//                            Error(0)

//                 */
//            }

//            cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//            StringType.MidStmtStr(ref cname, 1, 2, "&H");
//            var midTmp = Strings.Mid(opt, 6, 2);
//            StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//            var midTmp1 = Strings.Mid(opt, 4, 2);
//            StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//            var midTmp2 = Strings.Mid(opt, 2, 2);
//            StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//            if (!Information.IsNumeric(cname))
//            {
//                Event_Renamed.EventErrorMessage = "色指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 246203


//                Input:
//                            Error(0)

//                 */
//            }

//            Event_Renamed.ObjFillColor = Conversions.ToInteger(cname);
//            ExecFillColorCmdRet = LineNum + 1;
//            return ExecFillColorCmdRet;
//        }

//        private int ExecFillStyleCmd()
//        {
//            int ExecFillStyleCmdRet = default;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "FillStyleコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 246504


//                Input:
//                            Error(0)

//                 */
//            }

//            switch (GetArgAsString((short)2) ?? "")
//            {
//                case "塗りつぶし":
//                    {
//                        Event_Renamed.ObjFillStyle = vbFSSolid;
//                        break;
//                    }

//                case "透明":
//                    {
//                        Event_Renamed.ObjFillStyle = vbFSTransparent;
//                        break;
//                    }

//                case "横線":
//                    {
//                        Event_Renamed.ObjFillStyle = vbHorizontalLine;
//                        break;
//                    }

//                case "縦線":
//                    {
//                        Event_Renamed.ObjFillStyle = vbVerticalLine;
//                        break;
//                    }

//                case "斜線":
//                    {
//                        Event_Renamed.ObjFillStyle = vbUpwardDiagonal;
//                        break;
//                    }

//                case "斜線２":
//                    {
//                        Event_Renamed.ObjFillStyle = vbDownwardDiagonal;
//                        break;
//                    }

//                case "クロス":
//                    {
//                        Event_Renamed.ObjFillStyle = vbCross;
//                        break;
//                    }

//                case "網かけ":
//                    {
//                        Event_Renamed.ObjFillStyle = vbDiagonalCross;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "背景描画方法の指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 248728


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecFillStyleCmdRet = LineNum + 1;
//            return ExecFillStyleCmdRet;
//        }

//        private int ExecFinishCmd()
//        {
//            int ExecFinishCmdRet = default;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2, true);
//                        break;
//                    }

//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Finishコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 249131


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is object)
//            {
//                {
//                    var withBlock = u;
//                    switch (withBlock.Action)
//                    {
//                        case 1:
//                            {
//                                withBlock.UseAction();
//                                if (withBlock.Status_Renamed == "出撃")
//                                {
//                                    GUI.PaintUnitBitmap(ref u);
//                                }

//                                break;
//                            }
//                        // なにもしない
//                        case 0:
//                            {
//                                break;
//                            }

//                        default:
//                            {
//                                withBlock.UseAction();
//                                break;
//                            }
//                    }
//                }
//            }

//            ExecFinishCmdRet = LineNum + 1;
//            return ExecFinishCmdRet;
//        }

//        private int ExecFixCmd()
//        {
//            int ExecFixCmdRet = default;
//            string buf;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        object argIndex1 = (object)1;
//                        buf = Event_Renamed.SelectedUnitForEvent.Pilot(ref argIndex1).Name;
//                        break;
//                    }

//                case 2:
//                    {
//                        buf = GetArgAsString((short)2);
//                        bool localIsDefined() { object argIndex1 = (object)buf; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//                        bool localIsDefined1() { object argIndex1 = (object)buf; var ret = SRC.IList.IsDefined(ref argIndex1); return ret; }

//                        if (!localIsDefined() & !localIsDefined1())
//                        {
//                            Event_Renamed.EventErrorMessage = "パイロット名またはアイテム名" + buf + "が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 249941


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        object argIndex2 = (object)buf;
//                        if (SRC.PList.IsDefined(ref argIndex2))
//                        {
//                            Pilot localItem() { object argIndex1 = (object)buf; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                            buf = localItem().Name;
//                        }
//                        else
//                        {
//                            Item localItem1() { object argIndex1 = (object)buf; var ret = SRC.IList.Item(ref argIndex1); return ret; }

//                            buf = localItem1().Name;
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Fixコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 250238


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            buf = "Fix(" + buf + ")";
//            if (!Expression.IsGlobalVariableDefined(ref buf))
//            {
//                Expression.DefineGlobalVariable(ref buf);
//            }

//            Expression.SetVariableAsLong(ref buf, 1);
//            ExecFixCmdRet = LineNum + 1;
//            return ExecFixCmdRet;
//        }

//        private int ExecFontCmd()
//        {
//            int ExecFontCmdRet = default;
//            string cname, opt, fname;
//            short i;
//            Font sf;
//            ExecFontCmdRet = LineNum + 1;

//            {
//                var withBlock = GUI.MainForm.picMain(0);
//                fname = withBlock.Font.Name;

//                // デフォルトの設定
//                if (ArgNum == 1)
//                {
//                    withBlock.ForeColor = ColorTranslator.ToOle(Color.White);
//                    {
//                        var withBlock1 = withBlock.Font;
//                        fname = "ＭＳ Ｐ明朝";
//                        withBlock1.Size = 16;
//                        withBlock1.Bold = true;
//                        withBlock1.Italic = false;
//                    }

//                    GUI.PermanentStringMode = false;
//                    GUI.KeepStringMode = false;
//                }
//                else
//                {
//                    var loopTo = ArgNum;
//                    for (i = 2; i <= loopTo; i++)
//                    {
//                        opt = GetArgAsString(i);
//                        switch (opt ?? "")
//                        {
//                            case "Ｐ明朝":
//                                {
//                                    fname = "ＭＳ Ｐ明朝";
//                                    break;
//                                }

//                            case "Ｐゴシック":
//                                {
//                                    fname = "ＭＳ Ｐゴシック";
//                                    break;
//                                }

//                            case "明朝":
//                                {
//                                    fname = "ＭＳ 明朝";
//                                    break;
//                                }

//                            case "ゴシック":
//                                {
//                                    fname = "ＭＳ ゴシック";
//                                    break;
//                                }

//                            case "Bold":
//                                {
//                                    withBlock.Font.Bold = true;
//                                    break;
//                                }

//                            case "Italic":
//                                {
//                                    withBlock.Font.Italic = true;
//                                    break;
//                                }

//                            case "Regular":
//                                {
//                                    withBlock.Font.Bold = false;
//                                    withBlock.Font.Italic = false;
//                                    break;
//                                }

//                            case "通常":
//                                {
//                                    GUI.PermanentStringMode = false;
//                                    GUI.KeepStringMode = false;
//                                    break;
//                                }

//                            case "背景":
//                                {
//                                    GUI.PermanentStringMode = true;
//                                    break;
//                                }

//                            case "保持":
//                                {
//                                    GUI.KeepStringMode = true;
//                                    break;
//                                }
//                            // 無視
//                            case " ":
//                            case var @case when @case == "":
//                                {
//                                    break;
//                                }

//                            default:
//                                {
//                                    if (Strings.Right(opt, 2) == "pt")
//                                    {
//                                        // 文字サイズ
//                                        opt = Strings.Left(opt, Strings.Len(opt) - 2);
//                                        withBlock.Font.Size = Conversions.ToShort(opt);
//                                    }
//                                    else if (Strings.Asc(opt) == 35 & Strings.Len(opt) == 7)
//                                    {
//                                        // 文字色
//                                        cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                                        StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                                        var midTmp = Strings.Mid(opt, 6, 2);
//                                        StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                                        var midTmp1 = Strings.Mid(opt, 4, 2);
//                                        StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                                        var midTmp2 = Strings.Mid(opt, 2, 2);
//                                        StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                                        if (Information.IsNumeric(cname))
//                                        {
//                                            withBlock.ForeColor = Conversions.ToInteger(cname);
//                                        }
//                                    }
//                                    else
//                                    {
//                                        // その他のフォント
//                                        fname = opt;
//                                    }

//                                    break;
//                                }
//                        }
//                    }
//                }

//                // フォント名が変更されている？
//                if (fname != withBlock.Font.Name)
//                {
//                    sf = (Font)Control.DefaultFont.Clone();
//                    {
//                        var withBlock2 = withBlock.Font;
//                        sf = Microsoft.VisualBasic.Compatibility.VB6.Support.FontChangeName(sf, fname);
//                        sf = Microsoft.VisualBasic.Compatibility.VB6.Support.FontChangeSize(sf, withBlock2.Size);
//                        sf = Microsoft.VisualBasic.Compatibility.VB6.Support.FontChangeBold(sf, withBlock2.Bold);
//                        sf = Microsoft.VisualBasic.Compatibility.VB6.Support.FontChangeItalic(sf, withBlock2.Italic);
//                    }
//                    withBlock.Font = sf;
//                }
//            }

//            return ExecFontCmdRet;
//        }

//        private int ExecForCmd()
//        {
//            int ExecForCmdRet = default;
//            string vname;
//            int idx, i, limit;
//            short depth;
//            short isincr;
//            if ((int)ArgNum != 6 & (int)ArgNum != 8)
//            {
//                Event_Renamed.EventErrorMessage = "Forコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 257375


//                Input:
//                            Error(0)

//                 */
//            }

//            // インデックス変数に初期値を設定
//            vname = GetArg(2);
//            idx = GetArgAsLong(4);
//            Expression.SetVariableAsLong(ref vname, idx);

//            // ループの終端値
//            limit = GetArgAsLong(6);

//            // ArgNumが8かつ引数8が<0の場合、インデックスが減算されるループとして
//            // ループ終了の条件式の不等号を逆にします
//            // (idxおよびlimitの値に-1を乗算することで、擬似的に不等号を反対にしています)
//            // ExecNextCmdでも同様の処理をしています
//            isincr = 1;
//            if (ArgNum == 8)
//            {
//                if (GetArgAsLong(8) < 0)
//                {
//                    isincr = -1;
//                }
//            }

//            if (idx * (int)isincr <= limit * (int)isincr)
//            {
//                // 終端値をスタックに格納
//                Event_Renamed.ForIndex = (short)((int)Event_Renamed.ForIndex + 1);
//                Event_Renamed.ForLimitStack[(int)Event_Renamed.ForIndex] = limit;
//                // 初回のループを実行
//                ExecForCmdRet = LineNum + 1;
//            }
//            else
//            {
//                // 最初から条件式を満たしていない場合

//                // 対応するNextコマンドを探す
//                depth = (short)1;
//                var loopTo = Information.UBound(Event_Renamed.EventCmd);
//                for (i = LineNum + 1; i <= loopTo; i++)
//                {
//                    switch (Event_Renamed.EventCmd[i].Name)
//                    {
//                        case Event_Renamed.CmdType.ForCmd:
//                        case Event_Renamed.CmdType.ForEachCmd:
//                            {
//                                depth = (short)((int)depth + 1);
//                                break;
//                            }

//                        case Event_Renamed.CmdType.NextCmd:
//                            {
//                                depth = (short)((int)depth - 1);
//                                if ((int)depth == 0)
//                                {
//                                    ExecForCmdRet = i + 1;
//                                    return ExecForCmdRet;
//                                }

//                                break;
//                            }
//                    }
//                }

//                Event_Renamed.EventErrorMessage = "ForまたはForEachとNextが対応していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 258803


//                Input:
//                            Error(0)

//                 */
//            }

//            return ExecForCmdRet;
//        }

//        private int ExecForEachCmd()
//        {
//            int ExecForEachCmdRet = default;
//            string uparty;
//            string ustatus;
//            string ugroup;
//            Unit u;
//            Pilot p;
//            int i;
//            short j, depth;
//            string vname, aname;
//            string buf;
//            VarData var;
//            string key_type;
//            int[] key_list;
//            string[] strkey_list;
//            int max_value;
//            string max_str;
//            short max_item;
//            Event_Renamed.ForEachSet = new string[1];
//            switch (ArgNum)
//            {
//                // ユニットに対するForEach
//                case 2:
//                case 3:
//                    {
//                        if ((int)ArgNum == 2)
//                        {
//                            ustatus = "出撃 格納";
//                        }
//                        else
//                        {
//                            ustatus = GetArgAsString((short)3);
//                            if (ustatus == "全て")
//                            {
//                                ustatus = "全";
//                            }
//                        }

//                        switch (GetArgAsString((short)2) ?? "")
//                        {
//                            case "全":
//                                {
//                                    if (ustatus == "全")
//                                    {
//                                        foreach (Unit currentU in SRC.UList)
//                                        {
//                                            u = currentU;
//                                            if (u.Status_Renamed != "他形態" & u.Status_Renamed != "旧主形態" & u.Status_Renamed != "旧形態" & u.Status_Renamed != "破棄")
//                                            {
//                                                Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                                Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = u.ID;
//                                            }
//                                        }
//                                    }
//                                    else
//                                    {
//                                        foreach (Unit currentU1 in SRC.UList)
//                                        {
//                                            u = currentU1;
//                                            if (Strings.InStr(ustatus, u.Status_Renamed) > 0)
//                                            {
//                                                Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                                Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = u.ID;
//                                            }
//                                        }
//                                    }

//                                    break;
//                                }

//                            case "味方":
//                            case "ＮＰＣ":
//                            case "敵":
//                            case "中立":
//                                {
//                                    uparty = GetArgAsString((short)2);
//                                    if (ustatus == "全")
//                                    {
//                                        foreach (Unit currentU2 in SRC.UList)
//                                        {
//                                            u = currentU2;
//                                            if ((u.Party0 ?? "") == (uparty ?? ""))
//                                            {
//                                                if (u.Status_Renamed != "他形態" & u.Status_Renamed != "旧主形態" & u.Status_Renamed != "旧形態" & u.Status_Renamed != "破棄")
//                                                {
//                                                    Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                                    Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = u.ID;
//                                                }
//                                            }
//                                        }
//                                    }
//                                    else
//                                    {
//                                        foreach (Unit currentU3 in SRC.UList)
//                                        {
//                                            u = currentU3;
//                                            if ((u.Party0 ?? "") == (uparty ?? ""))
//                                            {
//                                                if (Strings.InStr(ustatus, u.Status_Renamed) > 0)
//                                                {
//                                                    Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                                    Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = u.ID;
//                                                }
//                                            }
//                                        }
//                                    }

//                                    break;
//                                }

//                            default:
//                                {
//                                    ugroup = GetArgAsString((short)2);
//                                    if (ustatus == "全て")
//                                    {
//                                        ustatus = "全";
//                                    }

//                                    foreach (Unit currentU4 in SRC.UList)
//                                    {
//                                        u = currentU4;
//                                        if ((int)u.CountPilot() > 0)
//                                        {
//                                            if ((u.MainPilot().ID ?? "") == (ugroup ?? "") | Strings.InStr(u.MainPilot().ID, ugroup + ":") == 1)
//                                            {
//                                                if (ustatus == "全")
//                                                {
//                                                    if (u.Status_Renamed != "他形態" & u.Status_Renamed != "旧主形態" & u.Status_Renamed != "旧形態" & u.Status_Renamed != "破棄")
//                                                    {
//                                                        Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                                        Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = u.ID;
//                                                    }
//                                                }
//                                                else if (Strings.InStr(ustatus, u.Status_Renamed) > 0)
//                                                {
//                                                    Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                                    Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = u.ID;
//                                                }
//                                            }
//                                        }
//                                    }

//                                    break;
//                                }
//                        }

//                        break;
//                    }

//                // 配列の要素に対するForEach
//                case 4:
//                    {
//                        // インデックス用変数名
//                        vname = GetArg((short)2);
//                        if (Strings.Left(vname, 1) == "$")
//                        {
//                            vname = Strings.Mid(vname, 2);
//                        }

//                        // 配列の変数名
//                        aname = GetArg((short)4);
//                        if (Strings.Left(aname, 1) == "$")
//                        {
//                            aname = Strings.Mid(aname, 2);
//                        }
//                        // Eval関数
//                        if (Strings.LCase(Strings.Left(aname, 5)) == "eval(")
//                        {
//                            if (Strings.Right(aname, 1) == ")")
//                            {
//                                aname = Strings.Mid(aname, 6, Strings.Len(aname) - 6);
//                                aname = Expression.GetValueAsString(ref aname);
//                            }
//                        }

//                        // 配列を検索し、配列要素を見つける
//                        string argstring24 = "パイロット一覧(";
//                        string argstring25 = "ユニット一覧(";
//                        if ((int)GeneralLib.InStrNotNest(ref aname, ref argstring24) == 1)
//                        {
//                            string argstring2 = "(";
//                            string argstring21 = "(";
//                            key_type = Strings.Mid(aname, (int)GeneralLib.InStrNotNest(ref aname, ref argstring2) + 1, Strings.Len(aname) - (int)GeneralLib.InStrNotNest(ref aname, ref argstring21) - 1);
//                            key_type = Expression.GetValueAsString(ref key_type);
//                            if (key_type != "名称")
//                            {
//                                // 配列作成
//                                Event_Renamed.ForEachSet = new string[(int)(SRC.PList.Count() + 1)];
//                                key_list = new int[(int)(SRC.PList.Count() + 1)];
//                                i = 0;
//                                foreach (Pilot currentP in SRC.PList)
//                                {
//                                    p = currentP;
//                                    if (!p.Alive | p.Away)
//                                    {
//                                        goto NextPilot1;
//                                    }

//                                    if (p.Unit_Renamed is object)
//                                    {
//                                        {
//                                            var withBlock = p.Unit_Renamed;
//                                            if ((int)withBlock.CountPilot() > 0)
//                                            {
//                                                object argIndex1 = (object)1;
//                                                object argIndex2 = (object)1;
//                                                if (ReferenceEquals(p, withBlock.MainPilot()) & !ReferenceEquals(p, withBlock.Pilot(ref argIndex2)))
//                                                {
//                                                    goto NextPilot1;
//                                                }
//                                            }
//                                        }
//                                    }

//                                    i = i + 1;
//                                    Event_Renamed.ForEachSet[i] = p.ID;
//                                    switch (key_type ?? "")
//                                    {
//                                        case "レベル":
//                                            {
//                                                key_list[i] = 500 * (int)p.Level + p.Exp;
//                                                break;
//                                            }

//                                        case "ＳＰ":
//                                            {
//                                                key_list[i] = p.MaxSP;
//                                                break;
//                                            }

//                                        case "格闘":
//                                            {
//                                                key_list[i] = (int)p.Infight;
//                                                break;
//                                            }

//                                        case "射撃":
//                                            {
//                                                key_list[i] = (int)p.Shooting;
//                                                break;
//                                            }

//                                        case "命中":
//                                            {
//                                                key_list[i] = (int)p.Hit;
//                                                break;
//                                            }

//                                        case "回避":
//                                            {
//                                                key_list[i] = (int)p.Dodge;
//                                                break;
//                                            }

//                                        case "技量":
//                                            {
//                                                key_list[i] = (int)p.Technique;
//                                                break;
//                                            }

//                                        case "反応":
//                                            {
//                                                key_list[i] = (int)p.Intuition;
//                                                break;
//                                            }
//                                    }

//                                    NextPilot1:
//                                    ;
//                                }

//                                Array.Resize(ref Event_Renamed.ForEachSet, i + 1);
//                                Array.Resize(ref key_list, i + 1);

//                                // ソート
//                                var loopTo = Information.UBound(Event_Renamed.ForEachSet) - 1;
//                                for (i = 1; i <= loopTo; i++)
//                                {
//                                    max_item = (short)i;
//                                    max_value = key_list[i];
//                                    var loopTo1 = (short)Information.UBound(Event_Renamed.ForEachSet);
//                                    for (j = (short)(i + 1); j <= loopTo1; j++)
//                                    {
//                                        if (key_list[(int)j] > max_value)
//                                        {
//                                            max_item = j;
//                                            max_value = key_list[(int)j];
//                                        }
//                                    }

//                                    if ((int)max_item != i)
//                                    {
//                                        buf = Event_Renamed.ForEachSet[i];
//                                        Event_Renamed.ForEachSet[i] = Event_Renamed.ForEachSet[(int)max_item];
//                                        Event_Renamed.ForEachSet[(int)max_item] = buf;
//                                        key_list[(int)max_item] = key_list[i];
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                // 配列作成
//                                Event_Renamed.ForEachSet = new string[(int)(SRC.PList.Count() + 1)];
//                                strkey_list = new string[(int)(SRC.PList.Count() + 1)];
//                                i = 0;
//                                foreach (Pilot currentP1 in SRC.PList)
//                                {
//                                    p = currentP1;
//                                    if (!p.Alive | p.Away)
//                                    {
//                                        goto NextPilot2;
//                                    }

//                                    if (p.Unit_Renamed is object)
//                                    {
//                                        {
//                                            var withBlock1 = p.Unit_Renamed;
//                                            if ((int)withBlock1.CountPilot() > 0)
//                                            {
//                                                object argIndex3 = (object)1;
//                                                object argIndex4 = (object)1;
//                                                if (ReferenceEquals(p, withBlock1.MainPilot()) & !ReferenceEquals(p, withBlock1.Pilot(ref argIndex4)))
//                                                {
//                                                    goto NextPilot2;
//                                                }
//                                            }
//                                        }
//                                    }

//                                    i = i + 1;
//                                    Event_Renamed.ForEachSet[i] = p.ID;
//                                    strkey_list[i] = p.KanaName;
//                                    NextPilot2:
//                                    ;
//                                }

//                                Array.Resize(ref Event_Renamed.ForEachSet, i + 1);
//                                Array.Resize(ref strkey_list, i + 1);

//                                // ソート
//                                var loopTo2 = Information.UBound(Event_Renamed.ForEachSet) - 1;
//                                for (i = 1; i <= loopTo2; i++)
//                                {
//                                    max_item = (short)i;
//                                    max_str = strkey_list[i];
//                                    var loopTo3 = (short)Information.UBound(Event_Renamed.ForEachSet);
//                                    for (j = (short)(i + 1); j <= loopTo3; j++)
//                                    {
//                                        if (Strings.StrComp(strkey_list[(int)j], max_str, (CompareMethod)1) == -1)
//                                        {
//                                            max_item = j;
//                                            max_str = strkey_list[(int)j];
//                                        }
//                                    }

//                                    if ((int)max_item != i)
//                                    {
//                                        buf = Event_Renamed.ForEachSet[i];
//                                        Event_Renamed.ForEachSet[i] = Event_Renamed.ForEachSet[(int)max_item];
//                                        Event_Renamed.ForEachSet[(int)max_item] = buf;
//                                        strkey_list[(int)max_item] = strkey_list[i];
//                                    }
//                                }
//                            }
//                        }
//                        else if ((int)GeneralLib.InStrNotNest(ref aname, ref argstring25) == 1)
//                        {
//                            string argstring22 = "(";
//                            string argstring23 = "(";
//                            key_type = Strings.Mid(aname, (int)GeneralLib.InStrNotNest(ref aname, ref argstring22) + 1, Strings.Len(aname) - (int)GeneralLib.InStrNotNest(ref aname, ref argstring23) - 1);
//                            key_type = Expression.GetValueAsString(ref key_type);
//                            if (key_type != "名称")
//                            {
//                                // 配列作成
//                                Event_Renamed.ForEachSet = new string[(int)(SRC.UList.Count() + 1)];
//                                key_list = new int[(int)(SRC.UList.Count() + 1)];
//                                i = 0;
//                                foreach (Unit currentU5 in SRC.UList)
//                                {
//                                    u = currentU5;
//                                    if (u.Status_Renamed == "出撃" | u.Status_Renamed == "格納" | u.Status_Renamed == "待機")
//                                    {
//                                        i = i + 1;
//                                        Event_Renamed.ForEachSet[i] = u.ID;
//                                        switch (key_type ?? "")
//                                        {
//                                            case "ランク":
//                                                {
//                                                    key_list[i] = (int)u.Rank;
//                                                    break;
//                                                }

//                                            case "ＨＰ":
//                                                {
//                                                    key_list[i] = u.HP;
//                                                    break;
//                                                }

//                                            case "ＥＮ":
//                                                {
//                                                    key_list[i] = u.EN;
//                                                    break;
//                                                }

//                                            case "装甲":
//                                                {
//                                                    key_list[i] = u.get_Armor("");
//                                                    break;
//                                                }

//                                            case "運動性":
//                                                {
//                                                    key_list[i] = (int)u.get_Mobility("");
//                                                    break;
//                                                }

//                                            case "移動力":
//                                                {
//                                                    key_list[i] = (int)u.Speed;
//                                                    break;
//                                                }

//                                            case "最大攻撃力":
//                                                {
//                                                    var loopTo4 = u.CountWeapon();
//                                                    for (j = (short)1; j <= loopTo4; j++)
//                                                    {
//                                                        string argattr = "合";
//                                                        if (u.IsWeaponMastered(j) & !u.IsDisabled(ref u.Weapon(j).Name) & !u.IsWeaponClassifiedAs(j, ref argattr))
//                                                        {
//                                                            string argtarea1 = "";
//                                                            if (u.WeaponPower(j, ref argtarea1) > key_list[i])
//                                                            {
//                                                                string argtarea = "";
//                                                                key_list[i] = u.WeaponPower(j, ref argtarea);
//                                                            }
//                                                        }
//                                                    }

//                                                    break;
//                                                }

//                                            case "最長射程":
//                                                {
//                                                    var loopTo5 = u.CountWeapon();
//                                                    for (j = (short)1; j <= loopTo5; j++)
//                                                    {
//                                                        string argattr1 = "合";
//                                                        if (u.IsWeaponMastered(j) & !u.IsDisabled(ref u.Weapon(j).Name) & !u.IsWeaponClassifiedAs(j, ref argattr1))
//                                                        {
//                                                            if ((int)u.WeaponMaxRange(j) > key_list[i])
//                                                            {
//                                                                key_list[i] = (int)u.WeaponMaxRange(j);
//                                                            }
//                                                        }
//                                                    }

//                                                    break;
//                                                }
//                                        }
//                                    }
//                                }

//                                Array.Resize(ref Event_Renamed.ForEachSet, i + 1);
//                                Array.Resize(ref key_list, i + 1);

//                                // ソート
//                                var loopTo6 = Information.UBound(Event_Renamed.ForEachSet) - 1;
//                                for (i = 1; i <= loopTo6; i++)
//                                {
//                                    max_item = (short)i;
//                                    max_value = key_list[i];
//                                    var loopTo7 = (short)Information.UBound(Event_Renamed.ForEachSet);
//                                    for (j = (short)(i + 1); j <= loopTo7; j++)
//                                    {
//                                        if (key_list[(int)j] > max_value)
//                                        {
//                                            max_item = j;
//                                            max_value = key_list[(int)j];
//                                        }
//                                    }

//                                    if ((int)max_item != i)
//                                    {
//                                        buf = Event_Renamed.ForEachSet[i];
//                                        Event_Renamed.ForEachSet[i] = Event_Renamed.ForEachSet[(int)max_item];
//                                        Event_Renamed.ForEachSet[(int)max_item] = buf;
//                                        key_list[(int)max_item] = key_list[i];
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                // 配列作成
//                                Event_Renamed.ForEachSet = new string[(int)(SRC.UList.Count() + 1)];
//                                strkey_list = new string[(int)(SRC.UList.Count() + 1)];
//                                i = 0;
//                                foreach (Unit currentU6 in SRC.UList)
//                                {
//                                    u = currentU6;
//                                    if (u.Status_Renamed == "出撃" | u.Status_Renamed == "格納" | u.Status_Renamed == "待機")
//                                    {
//                                        i = i + 1;
//                                        Event_Renamed.ForEachSet[i] = u.ID;
//                                        strkey_list[i] = u.KanaName;
//                                    }
//                                }

//                                Array.Resize(ref Event_Renamed.ForEachSet, i + 1);
//                                Array.Resize(ref strkey_list, i + 1);

//                                // ソート
//                                var loopTo8 = Information.UBound(Event_Renamed.ForEachSet) - 1;
//                                for (i = 1; i <= loopTo8; i++)
//                                {
//                                    max_item = (short)i;
//                                    max_str = strkey_list[i];
//                                    var loopTo9 = (short)Information.UBound(Event_Renamed.ForEachSet);
//                                    for (j = (short)(i + 1); j <= loopTo9; j++)
//                                    {
//                                        if (Strings.StrComp(strkey_list[(int)j], max_str, (CompareMethod)1) == -1)
//                                        {
//                                            max_item = j;
//                                            max_str = strkey_list[(int)j];
//                                        }
//                                    }

//                                    if ((int)max_item != i)
//                                    {
//                                        buf = Event_Renamed.ForEachSet[i];
//                                        Event_Renamed.ForEachSet[i] = Event_Renamed.ForEachSet[(int)max_item];
//                                        Event_Renamed.ForEachSet[(int)max_item] = buf;
//                                        strkey_list[(int)max_item] = strkey_list[i];
//                                    }
//                                }
//                            }
//                        }
//                        else if (Expression.IsSubLocalVariableDefined(ref aname))
//                        {
//                            // サブルーチンローカルな配列に対するForEach
//                            var loopTo10 = (int)Event_Renamed.VarIndex;
//                            for (i = (int)Event_Renamed.VarIndexStack[(int)Event_Renamed.CallDepth - 1] + 1; i <= loopTo10; i++)
//                            {
//                                {
//                                    var withBlock2 = Event_Renamed.VarStack[i];
//                                    if (Strings.InStr(withBlock2.Name, aname + "[") == 1)
//                                    {
//                                        Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                        buf = withBlock2.Name;
//                                        var loopTo11 = (short)Strings.Len(buf);
//                                        for (j = (short)1; j <= loopTo11; j++)
//                                        {
//                                            if (Strings.Mid(buf, Strings.Len(buf) - (int)j + 1, 1) == "]")
//                                            {
//                                                break;
//                                            }
//                                        }

//                                        buf = Strings.Mid(buf, Strings.InStr(buf, "[") + 1);
//                                        buf = Strings.Left(buf, Strings.Len(buf) - (int)j);
//                                        Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = buf;
//                                    }
//                                }
//                            }

//                            if (Information.UBound(Event_Renamed.ForEachSet) == 0)
//                            {
//                                buf = Expression.GetValueAsString(ref aname);
//                                Event_Renamed.ForEachSet = new string[(int)(GeneralLib.ListLength(ref buf) + 1)];
//                                var loopTo12 = (int)GeneralLib.ListLength(ref buf);
//                                for (i = 1; i <= loopTo12; i++)
//                                    Event_Renamed.ForEachSet[i] = GeneralLib.ListIndex(ref buf, (short)i);
//                            }
//                        }
//                        else if (Expression.IsLocalVariableDefined(ref aname))
//                        {
//                            // ローカルな配列に対するForEach
//                            foreach (VarData currentVar in Event_Renamed.LocalVariableList)
//                            {
//                                var = currentVar;
//                                if (Strings.InStr(var.Name, aname + "[") == 1)
//                                {
//                                    Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                    buf = var.Name;
//                                    var loopTo13 = Strings.Len(buf);
//                                    for (i = 1; i <= loopTo13; i++)
//                                    {
//                                        if (Strings.Mid(buf, Strings.Len(buf) - i + 1, 1) == "]")
//                                        {
//                                            break;
//                                        }
//                                    }

//                                    buf = Strings.Mid(buf, Strings.InStr(buf, "[") + 1);
//                                    buf = Strings.Left(buf, Strings.Len(buf) - i);
//                                    Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = buf;
//                                }
//                            }

//                            if (Information.UBound(Event_Renamed.ForEachSet) == 0)
//                            {
//                                buf = Expression.GetValueAsString(ref aname);
//                                Event_Renamed.ForEachSet = new string[(int)(GeneralLib.ListLength(ref buf) + 1)];
//                                var loopTo14 = (int)GeneralLib.ListLength(ref buf);
//                                for (i = 1; i <= loopTo14; i++)
//                                    Event_Renamed.ForEachSet[i] = GeneralLib.ListIndex(ref buf, (short)i);
//                            }
//                        }
//                        else if (Expression.IsGlobalVariableDefined(ref aname))
//                        {
//                            // グローバルな配列に対するForEach
//                            foreach (VarData currentVar1 in Event_Renamed.GlobalVariableList)
//                            {
//                                var = currentVar1;
//                                if (Strings.InStr(var.Name, aname + "[") == 1)
//                                {
//                                    Array.Resize(ref Event_Renamed.ForEachSet, Information.UBound(Event_Renamed.ForEachSet) + 1 + 1);
//                                    buf = var.Name;
//                                    var loopTo15 = Strings.Len(buf);
//                                    for (i = 1; i <= loopTo15; i++)
//                                    {
//                                        if (Strings.Mid(buf, Strings.Len(buf) - i + 1, 1) == "]")
//                                        {
//                                            break;
//                                        }
//                                    }

//                                    buf = Strings.Mid(buf, Strings.InStr(buf, "[") + 1);
//                                    buf = Strings.Left(buf, Strings.Len(buf) - i);
//                                    Event_Renamed.ForEachSet[Information.UBound(Event_Renamed.ForEachSet)] = buf;
//                                }
//                            }

//                            if (Information.UBound(Event_Renamed.ForEachSet) == 0)
//                            {
//                                buf = Expression.GetValueAsString(ref aname);
//                                Event_Renamed.ForEachSet = new string[(int)(GeneralLib.ListLength(ref buf) + 1)];
//                                var loopTo16 = (int)GeneralLib.ListLength(ref buf);
//                                for (i = 1; i <= loopTo16; i++)
//                                    Event_Renamed.ForEachSet[i] = GeneralLib.ListIndex(ref buf, (short)i);
//                            }
//                        }
//                        else if (Strings.Left(aname, 1) == "(" & Strings.Right(aname, 1) == ")" | Strings.Left(aname, 1) == "\"" & Strings.Right(aname, 1) == "\"" | Strings.Left(aname, 1) == "`" & Strings.Right(aname, 1) == "`" | Strings.InStr(Strings.LCase(aname), "list(") == 1 & Strings.Right(aname, 1) == ")")
//                        {
//                            // リストに対するForEach
//                            buf = Expression.GetValueAsString(ref aname);
//                            Event_Renamed.ForEachSet = new string[(int)(GeneralLib.ListLength(ref buf) + 1)];
//                            var loopTo17 = (int)GeneralLib.ListLength(ref buf);
//                            for (i = 1; i <= loopTo17; i++)
//                                Event_Renamed.ForEachSet[i] = GeneralLib.ListIndex(ref buf, (short)i);
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ForEachコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 278769


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (Information.UBound(Event_Renamed.ForEachSet) > 0)
//            {
//                // ForEachの実行要素がある場合

//                Event_Renamed.ForEachIndex = (short)1;
//                Event_Renamed.ForIndex = (short)((int)Event_Renamed.ForIndex + 1);
//                if ((int)ArgNum < 4)
//                {
//                    var tmp = Event_Renamed.ForEachSet;
//                    object argIndex5 = (object)tmp[1];
//                    Event_Renamed.SelectedUnitForEvent = SRC.UList.Item(ref argIndex5);
//                }
//                else
//                {
//                    string argvname = GetArg((short)2);
//                    Expression.SetVariableAsString(ref argvname, ref Event_Renamed.ForEachSet[1]);
//                }

//                ExecForEachCmdRet = LineNum + 1;
//            }
//            else
//            {
//                // ForEachの実行要素がない場合

//                // 対応するNextを探す
//                depth = (short)1;
//                var loopTo18 = Information.UBound(Event_Renamed.EventCmd);
//                for (i = LineNum + 1; i <= loopTo18; i++)
//                {
//                    switch (Event_Renamed.EventCmd[i].Name)
//                    {
//                        case Event_Renamed.CmdType.ForCmd:
//                        case Event_Renamed.CmdType.ForEachCmd:
//                            {
//                                depth = (short)((int)depth + 1);
//                                break;
//                            }

//                        case Event_Renamed.CmdType.NextCmd:
//                            {
//                                depth = (short)((int)depth - 1);
//                                if ((int)depth == 0)
//                                {
//                                    ExecForEachCmdRet = i + 1;
//                                    return ExecForEachCmdRet;
//                                }

//                                break;
//                            }
//                    }
//                }

//                Event_Renamed.EventErrorMessage = "ForまたはForEachとNextが対応していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 280073


//                Input:
//                            Error(0)

//                 */
//            }

//            return ExecForEachCmdRet;
//        }

//        private int ExecNextCmd()
//        {
//            int ExecNextCmdRet = default;
//            int i;
//            short depth;
//            double idx;
//            string vname, buf;
//            short isincr;

//            // 対応するForまたはForEachを探す
//            i = LineNum;
//            depth = 1;
//            while (i > 1)
//            {
//                i = i - 1;
//                {
//                    var withBlock = Event_Renamed.EventCmd[i];
//                    switch (withBlock.Name)
//                    {
//                        case Event_Renamed.CmdType.ForCmd:
//                            {
//                                depth = (short)(depth - 1);
//                                if (depth == 0)
//                                {
//                                    // インデックス変数の値を1増やす
//                                    vname = withBlock.GetArg(2);

//                                    // Step句が設定されている場合、インデックス変数に引数8の値を加算
//                                    if (withBlock.ArgNum == 6)
//                                    {
//                                        idx = Expression.GetValueAsDouble(ref vname, true) + 1d;
//                                    }
//                                    else
//                                    {
//                                        idx = Expression.GetValueAsDouble(ref vname, true) + withBlock.GetArgAsLong(8);
//                                    }

//                                    Expression.SetVariableAsDouble(ref vname, idx);

//                                    // インデックス変数の値は範囲内？
//                                    isincr = 1;
//                                    if (withBlock.ArgNum == 8)
//                                    {
//                                        if (withBlock.GetArgAsLong(8) < 0)
//                                        {
//                                            isincr = -1;
//                                        }
//                                    }

//                                    if (idx * isincr > Event_Renamed.ForLimitStack[Event_Renamed.ForIndex] * isincr)
//                                    {
//                                        // ループ終了
//                                        i = LineNum;
//                                        Event_Renamed.ForIndex = (short)(Event_Renamed.ForIndex - 1);
//                                    }

//                                    ExecNextCmdRet = i + 1;
//                                    return ExecNextCmdRet;
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.ForEachCmd:
//                            {
//                                depth = (short)(depth - 1);
//                                if (depth == 0)
//                                {
//                                    Event_Renamed.ForEachIndex = (short)(Event_Renamed.ForEachIndex + 1);
//                                    if (Event_Renamed.ForEachIndex > Information.UBound(Event_Renamed.ForEachSet))
//                                    {
//                                        // ループ終了
//                                        i = LineNum;
//                                        Event_Renamed.ForIndex = (short)(Event_Renamed.ForIndex - 1);
//                                    }
//                                    else if (withBlock.ArgNum < 4)
//                                    {
//                                        // ユニット＆パイロットに対するForEach
//                                        var tmp = Event_Renamed.ForEachSet;
//                                        object argIndex1 = tmp[Event_Renamed.ForEachIndex];
//                                        Event_Renamed.SelectedUnitForEvent = SRC.UList.Item(ref argIndex1);
//                                    }
//                                    else
//                                    {
//                                        // 配列に対するForEach
//                                        string argvname = withBlock.GetArg(2);
//                                        Expression.SetVariableAsString(ref argvname, ref Event_Renamed.ForEachSet[Event_Renamed.ForEachIndex]);
//                                    }

//                                    ExecNextCmdRet = i + 1;
//                                    return ExecNextCmdRet;
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.NextCmd:
//                            {
//                                depth = (short)(depth + 1);
//                                break;
//                            }
//                    }
//                }
//            }

//            Event_Renamed.EventErrorMessage = "ForまたはForEachとNextが対応していません";
//            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 282690


//            Input:
//                    Error(0)

//             */
//        }

//        private int ExecForgetCmd()
//        {
//            int ExecForgetCmdRet = default;
//            string tname;
//            short i, j;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Forgetコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 282918


//                Input:
//                            Error(0)

//                 */
//            }

//            tname = GetArgAsString(2);
//            var loopTo = (short)Information.UBound(SRC.Titles);
//            for (i = 1; i <= loopTo; i++)
//            {
//                if ((tname ?? "") == (SRC.Titles[i] ?? ""))
//                {
//                    break;
//                }
//            }

//            if (i <= Information.UBound(SRC.Titles))
//            {
//                var loopTo1 = (short)Information.UBound(SRC.Titles);
//                for (j = (short)(i + 1); j <= loopTo1; j++)
//                    SRC.Titles[j - 1] = SRC.Titles[j];
//                Array.Resize(ref SRC.Titles, Information.UBound(SRC.Titles));
//            }

//            ExecForgetCmdRet = LineNum + 1;
//            return ExecForgetCmdRet;
//        }

//        private int ExecFreeMemoryCmd()
//        {
//            int ExecFreeMemoryCmdRet = default;
//            SRC.UList.Clean();
//            SRC.PList.Clean();
//            SRC.IList.Update();
//            ExecFreeMemoryCmdRet = LineNum + 1;
//            return ExecFreeMemoryCmdRet;
//        }

//        private int ExecGameClearCmd()
//        {
//            if ((int)ArgNum != 1)
//            {
//                Event_Renamed.EventErrorMessage = "GameClearコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 283989


//                Input:
//                            Error(0)

//                 */
//            }

//            SRC.GameClear();
//            return default;
//        }

//        private int ExecGameOverCmd()
//        {
//            int ExecGameOverCmdRet = default;
//            if ((int)ArgNum != 1)
//            {
//                Event_Renamed.EventErrorMessage = "GameOverコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 284222


//                Input:
//                            Error(0)

//                 */
//            }

//            SRC.GameOver();
//            SRC.IsScenarioFinished = true;
//            ExecGameOverCmdRet = 0;
//            return ExecGameOverCmdRet;
//        }

//        private int ExecGetOffCmd()
//        {
//            int ExecGetOffCmdRet = default;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2, true);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "GetOffコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 284690


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is object)
//            {
//                if (u.CountPilot() > 0)
//                {
//                    if (u.Status_Renamed == "出撃")
//                    {
//                        // ユニットをマップ上から削除した状態で支援効果を更新
//                        // UPGRADE_NOTE: オブジェクト MapDataForUnit() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                        Map.MapDataForUnit[u.x, u.y] = null;
//                        SRC.PList.UpdateSupportMod(u);
//                    }

//                    // パイロットを下ろす
//                    object argIndex1 = 1;
//                    u.Pilot(ref argIndex1).GetOff(true);
//                    if (u.Status_Renamed == "出撃")
//                    {
//                        // ユニットをマップ上に戻す
//                        Map.MapDataForUnit[u.x, u.y] = u;
//                    }
//                }
//            }

//            ExecGetOffCmdRet = LineNum + 1;
//            return ExecGetOffCmdRet;
//        }

//        private int ExecGlobalCmd()
//        {
//            int ExecGlobalCmdRet = default;
//            string vname;
//            short i;
//            var loopTo = ArgNum;
//            for (i = (short)2; i <= loopTo; i++)
//            {
//                vname = GetArg(i);
//                if (Strings.InStr(vname, "\"") > 0)
//                {
//                    Event_Renamed.EventErrorMessage = "変数名「" + vname + "」が不正です";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 285764


//                    Input:
//                                    Error(0)

//                     */
//                }

//                if (Strings.Asc(vname) == 36) // $
//                {
//                    vname = Strings.Mid(vname, 2);
//                }

//                if (!Expression.IsGlobalVariableDefined(ref vname))
//                {
//                    Expression.DefineGlobalVariable(ref vname);
//                }
//            }

//            ExecGlobalCmdRet = LineNum + 1;
//            return ExecGlobalCmdRet;
//        }

//        private int ExecGotoCmd()
//        {
//            int ExecGotoCmdRet = default;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Gotoコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 286293


//                Input:
//                            Error(0)

//                 */
//            }

//            // ラベルが式でないと仮定
//            string arglname = GetArg(2);
//            ExecGotoCmdRet = Event_Renamed.FindLabel(ref arglname);

//            // ラベルが見つかった？
//            if (ExecGotoCmdRet > 0)
//            {
//                ExecGotoCmdRet = ExecGotoCmdRet + 1;
//                return ExecGotoCmdRet;
//            }

//            // ラベルは式？
//            string arglname1 = GetArgAsString(2);
//            ExecGotoCmdRet = Event_Renamed.FindLabel(ref arglname1);
//            if (ExecGotoCmdRet == 0)
//            {
//                Event_Renamed.EventErrorMessage = "ラベル「" + GetArg((short)2) + "」がみつかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 286730


//                Input:
//                            Error(0)

//                 */
//            }

//            ExecGotoCmdRet = ExecGotoCmdRet + 1;
//            return ExecGotoCmdRet;
//        }

//        private int ExecHideCmd()
//        {
//            int ExecHideCmdRet = default;
//            GUI.MainForm.Hide();
//            ExecHideCmdRet = LineNum + 1;
//            return ExecHideCmdRet;
//        }

//        private int ExecHotPointCmd()
//        {
//            int ExecHotPointCmdRet = default;
//            string hname, hcaption;
//            short hx, hy;
//            short hw, hh;
//            switch (ArgNum)
//            {
//                case 6:
//                    {
//                        hname = GetArgAsString((short)2);
//                        hx = (short)(GetArgAsLong((short)3) + Event_Renamed.BaseX);
//                        hy = (short)(GetArgAsLong((short)4) + Event_Renamed.BaseY);
//                        hw = (short)GetArgAsLong((short)5);
//                        hh = (short)GetArgAsLong((short)6);
//                        hcaption = hname;
//                        break;
//                    }

//                case 7:
//                    {
//                        hname = GetArgAsString((short)2);
//                        hx = (short)(GetArgAsLong((short)3) + Event_Renamed.BaseX);
//                        hy = (short)(GetArgAsLong((short)4) + Event_Renamed.BaseY);
//                        hw = (short)GetArgAsLong((short)5);
//                        hh = (short)GetArgAsLong((short)6);
//                        hcaption = GetArgAsString((short)7);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "HotPointコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 287729


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            Array.Resize(ref Event_Renamed.HotPointList, Information.UBound(Event_Renamed.HotPointList) + 1 + 1);
//            {
//                var withBlock = Event_Renamed.HotPointList[Information.UBound(Event_Renamed.HotPointList)];
//                withBlock.Name = hname;
//                withBlock.Left_Renamed = hx;
//                withBlock.Top = hy;
//                withBlock.width = hw;
//                withBlock.Height = hh;
//                withBlock.Caption = hcaption;
//            }

//            ExecHotPointCmdRet = LineNum + 1;
//            return ExecHotPointCmdRet;
//        }

//        private int ExecIfCmd()
//        {
//            int ExecIfCmdRet = default;
//            string expr;
//            int i;
//            short depth;
//            string pname;
//            bool flag;
//            int ret;
//            expr = GetArg(2);

//            // Ifコマンドはあらかじめ構文解析されていて、第3引数に条件式の項数
//            // が入っている
//            switch (GetArgAsLong(3))
//            {
//                case 1:
//                    {
//                        object argIndex2 = expr;
//                        if (SRC.PList.IsDefined(ref argIndex2))
//                        {
//                            object argIndex1 = expr;
//                            {
//                                var withBlock = SRC.PList.Item(ref argIndex1);
//                                if (withBlock.Unit_Renamed is null)
//                                {
//                                    flag = false;
//                                }
//                                else
//                                {
//                                    {
//                                        var withBlock1 = withBlock.Unit_Renamed;
//                                        if (withBlock1.Status_Renamed == "出撃" | withBlock1.Status_Renamed == "格納")
//                                        {
//                                            flag = true;
//                                        }
//                                        else
//                                        {
//                                            flag = false;
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        else if (Expression.GetValueAsLong(ref expr, true) != 0)
//                        {
//                            flag = true;
//                        }
//                        else
//                        {
//                            flag = false;
//                        }

//                        break;
//                    }

//                case 2:
//                    {
//                        pname = GeneralLib.ListIndex(ref expr, 2);
//                        object argIndex4 = pname;
//                        if (SRC.PList.IsDefined(ref argIndex4))
//                        {
//                            object argIndex3 = pname;
//                            {
//                                var withBlock2 = SRC.PList.Item(ref argIndex3);
//                                if (withBlock2.Unit_Renamed is null)
//                                {
//                                    flag = true;
//                                }
//                                else
//                                {
//                                    {
//                                        var withBlock3 = withBlock2.Unit_Renamed;
//                                        if (withBlock3.Status_Renamed == "出撃" | withBlock3.Status_Renamed == "格納")
//                                        {
//                                            flag = false;
//                                        }
//                                        else
//                                        {
//                                            flag = true;
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        else if (Expression.GetValueAsLong(ref pname, true) == 0)
//                        {
//                            flag = true;
//                        }
//                        else
//                        {
//                            flag = false;
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        if (Expression.GetValueAsLong(ref expr) != 0)
//                        {
//                            flag = true;
//                        }
//                        else
//                        {
//                            flag = false;
//                        }

//                        break;
//                    }
//            }

//            switch (GetArg((short)4) ?? "")
//            {
//                case "exit":
//                    {
//                        if (flag)
//                        {
//                            ExecIfCmdRet = 0;
//                        }
//                        else
//                        {
//                            ExecIfCmdRet = LineNum + 1;
//                        }

//                        break;
//                    }

//                case "goto":
//                    {
//                        if (flag)
//                        {
//                            string arglname = GetArg((short)5);
//                            ret = Event_Renamed.FindLabel(ref arglname);
//                            if (ret == 0)
//                            {
//                                string arglname1 = GetArgAsString((short)5);
//                                ret = Event_Renamed.FindLabel(ref arglname1);
//                                if (ret == 0)
//                                {
//                                    Event_Renamed.EventErrorMessage = "ラベル「" + GetArg((short)5) + "」がみつかりません";
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 290328


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }
//                            }

//                            ExecIfCmdRet = ret + 1;
//                        }
//                        else
//                        {
//                            ExecIfCmdRet = LineNum + 1;
//                        }

//                        break;
//                    }

//                case "then":
//                    {
//                        if (flag)
//                        {
//                            // Then節をそのまま実行
//                            ExecIfCmdRet = LineNum + 1;
//                            return ExecIfCmdRet;
//                        }

//                        // 条件式が成り立たない場合はElse節もしくはEndIfを探す
//                        depth = (short)1;
//                        var loopTo = Information.UBound(Event_Renamed.EventCmd);
//                        for (i = LineNum + 1; i <= loopTo; i++)
//                        {
//                            {
//                                var withBlock4 = Event_Renamed.EventCmd[i];
//                                switch (withBlock4.Name)
//                                {
//                                    case Event_Renamed.CmdType.IfCmd:
//                                        {
//                                            if (withBlock4.GetArg((short)4) == "then")
//                                            {
//                                                depth = (short)((int)depth + 1);
//                                            }

//                                            break;
//                                        }

//                                    case Event_Renamed.CmdType.ElseCmd:
//                                        {
//                                            if ((int)depth == 1)
//                                            {
//                                                break;
//                                            }

//                                            break;
//                                        }

//                                    case Event_Renamed.CmdType.ElseIfCmd:
//                                        {
//                                            if ((int)depth != 1)
//                                            {
//                                                goto NextLoop;
//                                            }
//                                            // 条件式が成り立つか判定
//                                            expr = withBlock4.GetArg((short)2);
//                                            switch (withBlock4.GetArgAsLong((short)3))
//                                            {
//                                                case 1:
//                                                    {
//                                                        object argIndex6 = (object)expr;
//                                                        if (SRC.PList.IsDefined(ref argIndex6))
//                                                        {
//                                                            object argIndex5 = (object)expr;
//                                                            {
//                                                                var withBlock5 = SRC.PList.Item(ref argIndex5);
//                                                                if (withBlock5.Unit_Renamed is null)
//                                                                {
//                                                                    flag = false;
//                                                                }
//                                                                else
//                                                                {
//                                                                    {
//                                                                        var withBlock6 = withBlock5.Unit_Renamed;
//                                                                        if (withBlock6.Status_Renamed == "出撃" | withBlock6.Status_Renamed == "格納")
//                                                                        {
//                                                                            flag = true;
//                                                                        }
//                                                                        else
//                                                                        {
//                                                                            flag = false;
//                                                                        }
//                                                                    }
//                                                                }
//                                                            }
//                                                        }
//                                                        else if (Expression.GetValueAsLong(ref expr, true) != 0)
//                                                        {
//                                                            flag = true;
//                                                        }
//                                                        else
//                                                        {
//                                                            flag = false;
//                                                        }

//                                                        break;
//                                                    }

//                                                case 2:
//                                                    {
//                                                        pname = GeneralLib.ListIndex(ref expr, (short)2);
//                                                        object argIndex8 = (object)pname;
//                                                        if (SRC.PList.IsDefined(ref argIndex8))
//                                                        {
//                                                            object argIndex7 = (object)pname;
//                                                            {
//                                                                var withBlock7 = SRC.PList.Item(ref argIndex7);
//                                                                if (withBlock7.Unit_Renamed is null)
//                                                                {
//                                                                    flag = true;
//                                                                }
//                                                                else
//                                                                {
//                                                                    {
//                                                                        var withBlock8 = withBlock7.Unit_Renamed;
//                                                                        if (withBlock8.Status_Renamed == "出撃" | withBlock8.Status_Renamed == "格納")
//                                                                        {
//                                                                            flag = false;
//                                                                        }
//                                                                        else
//                                                                        {
//                                                                            flag = true;
//                                                                        }
//                                                                    }
//                                                                }
//                                                            }
//                                                        }
//                                                        else if (Expression.GetValueAsLong(ref pname, true) == 0)
//                                                        {
//                                                            flag = true;
//                                                        }
//                                                        else
//                                                        {
//                                                            flag = false;
//                                                        }

//                                                        break;
//                                                    }

//                                                default:
//                                                    {
//                                                        if (Expression.GetValueAsLong(ref expr) != 0)
//                                                        {
//                                                            flag = true;
//                                                        }
//                                                        else
//                                                        {
//                                                            flag = false;
//                                                        }

//                                                        break;
//                                                    }
//                                            }

//                                            if (flag)
//                                            {
//                                                break;
//                                            }

//                                            break;
//                                        }

//                                    case Event_Renamed.CmdType.EndIfCmd:
//                                        {
//                                            depth = (short)((int)depth - 1);
//                                            if ((int)depth == 0)
//                                            {
//                                                break;
//                                            }

//                                            break;
//                                        }
//                                }
//                            }

//                            NextLoop:
//                            ;
//                        }

//                        if (i > Information.UBound(Event_Renamed.EventData))
//                        {
//                            Event_Renamed.EventErrorMessage = "IfとEndIfが対応していません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 293399


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        ExecIfCmdRet = i + 1;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "If行には Goto, Exit, Then のいずれかを指定して下さい";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 293568


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            return ExecIfCmdRet;
//        }

//        private int ExecElseCmd()
//        {
//            int ExecElseCmdRet = default;
//            int i;
//            short depth;

//            // EndIfを探す
//            depth = 1;
//            var loopTo = Information.UBound(Event_Renamed.EventCmd);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                {
//                    var withBlock = Event_Renamed.EventCmd[i];
//                    switch (withBlock.Name)
//                    {
//                        case Event_Renamed.CmdType.IfCmd:
//                            {
//                                if (withBlock.GetArg(4) == "then")
//                                {
//                                    depth = (short)(depth + 1);
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.EndIfCmd:
//                            {
//                                depth = (short)(depth - 1);
//                                if (depth == 0)
//                                {
//                                    ExecElseCmdRet = i + 1;
//                                    return ExecElseCmdRet;
//                                }

//                                break;
//                            }
//                    }
//                }
//            }

//            Event_Renamed.EventErrorMessage = "IfとEndIfが対応していません";
//            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 294336


//            Input:
//                    Error(0)

//             */
//        }

//        private int ExecIncrCmd()
//        {
//            int ExecIncrCmdRet = default;
//            string vname, buf = default;
//            var num = default(double);
//            vname = GetArg(2);
//            Expression.GetVariable(ref vname, ref Expression.ValueType.NumericType, ref buf, ref num);
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        Expression.SetVariableAsDouble(ref vname, num + GetArgAsDouble((short)3));
//                        break;
//                    }

//                case 2:
//                    {
//                        Expression.SetVariableAsDouble(ref vname, num + 1d);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Incrコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 294890


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecIncrCmdRet = LineNum + 1;
//            return ExecIncrCmdRet;
//        }

//        private int ExecIncreaseMoraleCmd()
//        {
//            int ExecIncreaseMoraleCmdRet = default;
//            Unit u;
//            string num;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2, true);
//                        num = GetArgAsLong((short)3).ToString();
//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        num = GetArgAsLong((short)2).ToString();
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "IncreaseMoraleコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 295397


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is object)
//            {
//                u.IncreaseMorale(Conversions.ToShort(num), true);
//                u.CurrentForm().CheckAutoHyperMode();
//                u.CurrentForm().CheckAutoNormalMode();
//            }

//            ExecIncreaseMoraleCmdRet = LineNum + 1;
//            return ExecIncreaseMoraleCmdRet;
//        }

//        private int ExecInputCmd()
//        {
//            int ExecInputCmdRet = default;
//            // UPGRADE_NOTE: str は str_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
//            string str_Renamed;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        str_Renamed = Interaction.InputBox(GetArgAsString((short)3), "SRC");
//                        break;
//                    }

//                case 4:
//                    {
//                        str_Renamed = Interaction.InputBox(GetArgAsString((short)3), "SRC", GetArgAsString((short)4));
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Inputコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 296282


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            string argvname = GetArg(2);
//            Expression.SetVariableAsString(ref argvname, ref str_Renamed);
//            ExecInputCmdRet = LineNum + 1;
//            return ExecInputCmdRet;
//        }

//        // MOD START マージ
//        // Private Function ExecInterMissionCommandCmd() As Long
//        private int ExecIntermissionCommandCmd()
//        {
//            int ExecIntermissionCommandCmdRet = default;
//            // MOD END マージ
//            string vname;
//            if ((int)ArgNum != 3)
//            {
//                // MOD START マージ
//                // EventErrorMessage = "InterMissionCommandコマンドの引数の数が違います"
//                // MOD END マージ
//                Event_Renamed.EventErrorMessage = "IntermissionCommandコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 296846


//                Input:
//                            ' MOD END マージ
//                            Error(0)

//                 */
//            }

//            // MOD START マージ
//            // vname = "InterMissionCommand(" & GetArgAsString(2) & ")"
//            vname = "IntermissionCommand(" + GetArgAsString(2) + ")";
//            // MOD END マージ

//            if (GetArg(3) == "削除")
//            {
//                Expression.UndefineVariable(ref vname);
//            }
//            else
//            {
//                if (!Expression.IsGlobalVariableDefined(ref vname))
//                {
//                    Expression.DefineGlobalVariable(ref vname);
//                }

//                string argnew_value = GetArgAsString(3);
//                Expression.SetVariableAsString(ref vname, ref argnew_value);
//            }

//            // MOD START マージ
//            // ExecInterMissionCommandCmd = LineNum + 1
//            ExecIntermissionCommandCmdRet = LineNum + 1;
//            return ExecIntermissionCommandCmdRet;
//            // MOD END マージ
//        }

//        private int ExecItemCmd()
//        {
//            int ExecItemCmdRet = default;
//            string iname;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        iname = GetArgAsString((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Itemコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 297756


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            bool localIsDefined() { object argIndex1 = iname; var ret = SRC.IDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined())
//            {
//                Event_Renamed.EventErrorMessage = "「" + iname + "」というアイテムは存在しません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 297928


//                Input:
//                            Error(0)

//                 */
//            }

//            SRC.IList.Add(ref iname);
//            ExecItemCmdRet = LineNum + 1;
//            return ExecItemCmdRet;
//        }

//        private int ExecJoinCmd()
//        {
//            int ExecJoinCmdRet = default;
//            var pname = default(string);
//            var u = default(Unit);
//            short i;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        pname = GetArgAsString((short)2);
//                        bool localIsDefined() { object argIndex1 = (object)pname; var ret = SRC.NPDList.IsDefined(ref argIndex1); return ret; }

//                        bool localIsDefined1() { object argIndex1 = (object)pname; var ret = SRC.UList.IsDefined(ref argIndex1); return ret; }

//                        object argIndex2 = (object)pname;
//                        if (SRC.PList.IsDefined(ref argIndex2))
//                        {
//                            Pilot localItem() { object argIndex1 = (object)pname; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                            u = localItem().Unit_Renamed;
//                        }
//                        else if (localIsDefined())
//                        {
//                            NonPilotData localItem1() { object argIndex1 = (object)pname; var ret = SRC.NPDList.Item(ref argIndex1); return ret; }

//                            pname = "IsAway(" + localItem1().Name + ")";
//                            if (Expression.IsGlobalVariableDefined(ref pname))
//                            {
//                                Expression.UndefineVariable(ref pname);
//                            }

//                            ExecJoinCmdRet = LineNum + 1;
//                            return ExecJoinCmdRet;
//                        }
//                        else if (localIsDefined1())
//                        {
//                            Unit localItem2() { object argIndex1 = (object)pname; var ret = SRC.UList.Item(ref argIndex1); return ret; }

//                            if ((pname ?? "") == (localItem2().ID ?? ""))
//                            {
//                                // UPGRADE_WARNING: オブジェクト u の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                object argIndex1 = (object)pname;
//                                u = SRC.UList.Item(ref argIndex1);
//                            }
//                            else
//                            {
//                                foreach (Unit currentU in SRC.UList)
//                                {
//                                    u = currentU;
//                                    {
//                                        var withBlock = u;
//                                        if ((withBlock.Name ?? "") == (pname ?? "") & withBlock.Party0 == "味方" & withBlock.CurrentForm().Status_Renamed == "離脱")
//                                        {
//                                            u = withBlock.CurrentForm();
//                                            break;
//                                        }
//                                    }
//                                }

//                                if ((u.Name ?? "") != (pname ?? ""))
//                                {
//                                    // UPGRADE_NOTE: オブジェクト u をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                    u = null;
//                                }
//                            }
//                        }
//                        else
//                        {
//                            Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットまたはユニットが見つかりません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 299677


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        break;
//                    }

//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Joinコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 299864


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is null)
//            {
//                object argIndex3 = pname;
//                if (SRC.PList.IsDefined(ref argIndex3))
//                {
//                    Pilot localItem3() { object argIndex1 = pname; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                    localItem3().Away = false;
//                }
//            }
//            else
//            {
//                u.Status_Renamed = "待機";
//                var loopTo = u.CountPilot();
//                for (i = 1; i <= loopTo; i++)
//                {
//                    Pilot localPilot() { object argIndex1 = i; var ret = u.Pilot(ref argIndex1); return ret; }

//                    localPilot().Away = false;
//                }

//                var loopTo1 = u.CountSupport();
//                for (i = 1; i <= loopTo1; i++)
//                {
//                    Pilot localSupport() { object argIndex1 = i; var ret = u.Support(ref argIndex1); return ret; }

//                    localSupport().Away = false;
//                }
//            }

//            ExecJoinCmdRet = LineNum + 1;
//            return ExecJoinCmdRet;
//        }

//        private int ExecKeepBGMCmd()
//        {
//            int ExecKeepBGMCmdRet = default;
//            if ((int)ArgNum != 1)
//            {
//                Event_Renamed.EventErrorMessage = "KeepBGMコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 300460


//                Input:
//                            Error(0)

//                 */
//            }

//            Sound.KeepBGM = true;
//            ExecKeepBGMCmdRet = LineNum + 1;
//            return ExecKeepBGMCmdRet;
//        }

//        private int ExecLandCmd()
//        {
//            int ExecLandCmdRet = default;
//            Unit u1, u2;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u1 = Event_Renamed.SelectedUnitForEvent;
//                        u2 = GetArgAsUnit((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        u1 = GetArgAsUnit((short)2);
//                        u2 = GetArgAsUnit((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Landコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 300956


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            string argfname = "母艦";
//            if (u1.IsFeatureAvailable(ref argfname))
//            {
//                Event_Renamed.EventErrorMessage = u1.Name + "は母艦なので格納出来ません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 301106


//                Input:
//                            Error(0)

//                 */
//            }

//            string argfname1 = "母艦";
//            if (!u2.IsFeatureAvailable(ref argfname1))
//            {
//                Event_Renamed.EventErrorMessage = u2.Name + "は母艦能力を持っていません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 301252


//                Input:
//                            Error(0)

//                 */
//            }

//            u1.Land(ref u2, true, true);
//            ExecLandCmdRet = LineNum + 1;
//            return ExecLandCmdRet;
//        }

//        private int ExecLaunchCmd()
//        {
//            int ExecLaunchCmdRet = default;
//            Unit u;
//            short uy, ux, num;
//            string opt;
//            num = ArgNum;
//            switch (GetArgAsString(num) ?? "")
//            {
//                case "非同期":
//                    {
//                        opt = "非同期";
//                        num = (short)(num - 1);
//                        break;
//                    }

//                case "アニメ非表示":
//                    {
//                        opt = "";
//                        num = (short)(num - 1);
//                        break;
//                    }

//                default:
//                    {
//                        opt = "出撃";
//                        break;
//                    }
//            }

//            switch (num)
//            {
//                case 3:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        ux = (short)GetArgAsLong((short)2);
//                        if ((int)ux < 1)
//                        {
//                            ux = (short)1;
//                        }
//                        else if (ux > Map.MapWidth)
//                        {
//                            ux = Map.MapWidth;
//                        }

//                        uy = (short)GetArgAsLong((short)3);
//                        if ((int)uy < 1)
//                        {
//                            uy = (short)1;
//                        }
//                        else if (uy > Map.MapHeight)
//                        {
//                            uy = Map.MapHeight;
//                        }

//                        break;
//                    }

//                case 4:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        ux = (short)GetArgAsLong((short)3);
//                        if ((int)ux < 1)
//                        {
//                            ux = (short)1;
//                        }
//                        else if (ux > Map.MapWidth)
//                        {
//                            ux = Map.MapWidth;
//                        }

//                        uy = (short)GetArgAsLong((short)4);
//                        if ((int)uy < 1)
//                        {
//                            uy = (short)1;
//                        }
//                        else if (uy > Map.MapHeight)
//                        {
//                            uy = Map.MapHeight;
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Launchコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 302617


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (opt != "非同期" & GUI.MainForm.Visible & !GUI.IsPictureVisible)
//            {
//                GUI.Center(ux, uy);
//                GUI.RefreshScreen();
//            }

//            switch (u.Status_Renamed ?? "")
//            {
//                case "出撃":
//                    {
//                        Event_Renamed.EventErrorMessage = u.MainPilot().get_Nickname(false) + "はすでに出撃しています";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 303002


//                        Input:
//                                            Error(0)

//                         */
//                        break;
//                    }

//                case "離脱":
//                    {
//                        Event_Renamed.EventErrorMessage = u.MainPilot().get_Nickname(false) + "はまだ離脱しています";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 303123


//                        Input:
//                                            Error(0)

//                         */
//                        break;
//                    }
//            }

//            u.UsedAction = 0;
//            u.UsedSupportAttack = 0;
//            u.UsedSupportGuard = 0;
//            u.UsedSyncAttack = 0;
//            u.UsedCounterAttack = 0;
//            if (u.HP <= 0)
//            {
//                u.HP = 1;
//            }

//            u.StandBy(ux, uy, opt);
//            u.CheckAutoHyperMode();
//            Event_Renamed.SelectedUnitForEvent = u.CurrentForm();
//            ExecLaunchCmdRet = LineNum + 1;
//            return ExecLaunchCmdRet;
//        }

//        private int ExecLeaveCmd()
//        {
//            int ExecLeaveCmdRet = default;
//            string pname = default, vname;
//            var u = default(Unit);
//            short i, num;
//            var opt = default(string);
//            num = ArgNum;
//            if (num > 1)
//            {
//                if (GetArgAsString(num) == "非同期")
//                {
//                    opt = "非同期";
//                    num = (short)(num - 1);
//                }
//            }

//            switch (num)
//            {
//                case 2:
//                    {
//                        pname = GetArgAsString((short)2);
//                        bool localIsDefined() { object argIndex1 = (object)pname; var ret = SRC.NPDList.IsDefined(ref argIndex1); return ret; }

//                        bool localIsDefined1() { object argIndex1 = (object)pname; var ret = SRC.UList.IsDefined(ref argIndex1); return ret; }

//                        object argIndex2 = (object)pname;
//                        if (SRC.PList.IsDefined(ref argIndex2))
//                        {
//                            Pilot localItem() { object argIndex1 = (object)pname; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                            u = localItem().Unit_Renamed;
//                        }
//                        else if (localIsDefined())
//                        {
//                            NonPilotData localItem1() { object argIndex1 = (object)pname; var ret = SRC.NPDList.Item(ref argIndex1); return ret; }

//                            vname = "IsAway(" + localItem1().Name + ")";
//                            if (!Expression.IsGlobalVariableDefined(ref vname))
//                            {
//                                Expression.DefineGlobalVariable(ref vname);
//                            }

//                            Expression.SetVariableAsLong(ref vname, 1);
//                            ExecLeaveCmdRet = LineNum + 1;
//                            return ExecLeaveCmdRet;
//                        }
//                        else if (localIsDefined1())
//                        {
//                            Unit localItem2() { object argIndex1 = (object)pname; var ret = SRC.UList.Item(ref argIndex1); return ret; }

//                            if ((pname ?? "") == (localItem2().ID ?? ""))
//                            {
//                                object argIndex1 = (object)pname;
//                                u = SRC.UList.Item(ref argIndex1);
//                            }
//                            else
//                            {
//                                foreach (Unit currentU in SRC.UList)
//                                {
//                                    u = currentU;
//                                    if ((u.Name ?? "") == (pname ?? "") & u.Party0 == "味方" & u.CurrentForm().Status_Renamed != "離脱")
//                                    {
//                                        u = u.CurrentForm();
//                                        break;
//                                    }
//                                }

//                                if ((u.Name ?? "") != (pname ?? ""))
//                                {
//                                    // UPGRADE_NOTE: オブジェクト u をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                    u = null;
//                                }
//                            }
//                        }
//                        else
//                        {
//                            Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットまたはユニットが見つかりません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 305201


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        break;
//                    }

//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Leaveコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 305389


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is null)
//            {
//                Pilot localItem3() { object argIndex1 = pname; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                localItem3().Away = true;
//            }
//            else
//            {
//                if (u.Status_Renamed == "出撃" | u.Status_Renamed == "格納")
//                {
//                    u.Escape(opt);
//                }

//                if (u.Party0 != "味方")
//                {
//                    string argnew_party = "味方";
//                    u.ChangeParty(ref argnew_party);
//                }

//                if (u.Status_Renamed != "他形態" & u.Status_Renamed != "旧主形態" & u.Status_Renamed != "旧形態")
//                {
//                    u.Status_Renamed = "離脱";
//                }

//                var loopTo = u.CountPilot();
//                for (i = 1; i <= loopTo; i++)
//                {
//                    Pilot localPilot() { object argIndex1 = i; var ret = u.Pilot(ref argIndex1); return ret; }

//                    localPilot().Away = true;
//                }

//                var loopTo1 = u.CountSupport();
//                for (i = 1; i <= loopTo1; i++)
//                {
//                    Pilot localSupport() { object argIndex1 = i; var ret = u.Support(ref argIndex1); return ret; }

//                    localSupport().Away = true;
//                }
//            }

//            ExecLeaveCmdRet = LineNum + 1;
//            return ExecLeaveCmdRet;
//        }

//        private int ExecLevelUpCmd()
//        {
//            int ExecLevelUpCmdRet = default;
//            var p = default(Pilot);
//            short num;
//            double hp_ratio = default, en_ratio = default;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        p = GetArgAsPilot((short)2);
//                        num = (short)GetArgAsLong((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        {
//                            var withBlock = Event_Renamed.SelectedUnitForEvent;
//                            if ((int)withBlock.CountPilot() > 0)
//                            {
//                                object argIndex1 = (object)1;
//                                p = withBlock.Pilot(ref argIndex1);
//                            }
//                        }

//                        num = (short)GetArgAsLong((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "LevelUpコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 306544


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (p is object)
//            {
//                if (p.Unit_Renamed is object)
//                {
//                    {
//                        var withBlock1 = p.Unit_Renamed;
//                        hp_ratio = 100 * withBlock1.HP / (double)withBlock1.MaxHP;
//                        en_ratio = 100 * withBlock1.EN / (double)withBlock1.MaxEN;
//                    }
//                }

//                string argoname = "レベル限界突破";
//                if (Expression.IsOptionDefined(ref argoname))
//                {
//                    p.Level = (short)GeneralLib.MinLng(GeneralLib.MaxLng(p.Level + num, 1), 999);
//                }
//                else
//                {
//                    p.Level = (short)GeneralLib.MinLng(GeneralLib.MaxLng(p.Level + num, 1), 99);
//                }

//                // 闘争本能入手？
//                string argsname = "闘争本能";
//                if (p.IsSkillAvailable(ref argsname))
//                {
//                    if (p.MinMorale > 100)
//                    {
//                        if (p.Morale == p.MinMorale)
//                        {
//                            object argIndex2 = "闘争本能";
//                            string argref_mode = "";
//                            p.Morale = (short)(p.MinMorale + 5d * p.SkillLevel(ref argIndex2, ref_mode: ref argref_mode));
//                        }
//                    }
//                    else if (p.Morale == 100)
//                    {
//                        object argIndex3 = "闘争本能";
//                        string argref_mode1 = "";
//                        p.Morale = (short)(100d + 5d * p.SkillLevel(ref argIndex3, ref_mode: ref argref_mode1));
//                    }
//                }

//                // ＳＰ＆霊力をアップデート
//                p.SP = p.SP;
//                p.Plana = p.Plana;
//                if (p.Unit_Renamed is object)
//                {
//                    {
//                        var withBlock2 = p.Unit_Renamed;
//                        withBlock2.Update();
//                        withBlock2.HP = (int)(withBlock2.MaxHP * hp_ratio / 100d);
//                        withBlock2.EN = (int)(withBlock2.MaxEN * en_ratio / 100d);
//                    }

//                    SRC.PList.UpdateSupportMod(p.Unit_Renamed);
//                }
//            }

//            ExecLevelUpCmdRet = LineNum + 1;
//            return ExecLevelUpCmdRet;
//        }

//        private int ExecLineCmd()
//        {
//            int ExecLineCmdRet = default;
//            PictureBox pic, pic2 = default;
//            short x1, y1;
//            short x2, y2;
//            string opt, dtype = default;
//            string cname;
//            int clr;
//            short i;
//            if ((int)ArgNum < 5)
//            {
//                Event_Renamed.EventErrorMessage = "Lineコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 308150


//                Input:
//                            Error(0)

//                 */
//            }

//            x1 = (short)(GetArgAsLong(2) + Event_Renamed.BaseX);
//            y1 = (short)(GetArgAsLong(3) + Event_Renamed.BaseY);
//            x2 = (short)(GetArgAsLong(4) + Event_Renamed.BaseX);
//            y2 = (short)(GetArgAsLong(5) + Event_Renamed.BaseY);
//            GUI.SaveScreen();

//            // 描画先
//            switch (Event_Renamed.ObjDrawOption ?? "")
//            {
//                case "背景":
//                    {
//                        pic = GUI.MainForm.picBack;
//                        pic2 = GUI.MainForm.picMaskedBack;
//                        Map.IsMapDirty = true;
//                        break;
//                    }

//                case "保持":
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        pic2 = GUI.MainForm.picMain(1);
//                        GUI.IsPictureVisible = true;
//                        break;
//                    }

//                default:
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        break;
//                    }
//            }

//            // 描画領域
//            short tmp;
//            if (Event_Renamed.ObjDrawOption != "背景")
//            {
//                GUI.IsPictureVisible = true;
//                tmp = (short)(Event_Renamed.ObjDrawWidth - 1);
//                GUI.PaintedAreaX1 = (short)GeneralLib.MaxLng(GeneralLib.MinLng(GUI.PaintedAreaX1, GeneralLib.MinLng(x1 - tmp, x2 - tmp)), 0);
//                GUI.PaintedAreaY1 = (short)GeneralLib.MaxLng(GeneralLib.MinLng(GUI.PaintedAreaY1, GeneralLib.MinLng(y1 - tmp, y2 - tmp)), 0);
//                GUI.PaintedAreaX2 = (short)GeneralLib.MaxLng(GeneralLib.MinLng(GUI.PaintedAreaX2, GeneralLib.MinLng(x1 + tmp, x2 + tmp)), GUI.MapPWidth - 1);
//                GUI.PaintedAreaY2 = (short)GeneralLib.MaxLng(GeneralLib.MinLng(GUI.PaintedAreaY2, GeneralLib.MinLng(y1 + tmp, y2 + tmp)), GUI.MapPHeight - 1);
//            }

//            clr = Event_Renamed.ObjColor;
//            var loopTo = ArgNum;
//            for (i = (short)6; i <= loopTo; i++)
//            {
//                opt = GetArgAsString(i);
//                if (Strings.Asc(opt) == 35) // #
//                {
//                    if (Strings.Len(opt) != 7)
//                    {
//                        Event_Renamed.EventErrorMessage = "色指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 311316


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                    StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                    var midTmp = Strings.Mid(opt, 6, 2);
//                    StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                    var midTmp1 = Strings.Mid(opt, 4, 2);
//                    StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                    var midTmp2 = Strings.Mid(opt, 2, 2);
//                    StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                    if (!Information.IsNumeric(cname))
//                    {
//                        Event_Renamed.EventErrorMessage = "色指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 311826


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    clr = Conversions.ToInteger(cname);
//                }
//                else
//                {
//                    if (opt != "B" & opt != "BF")
//                    {
//                        Event_Renamed.EventErrorMessage = "Lineコマンドに不正なオプション「" + opt + "」が使われています";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 312022


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    dtype = opt;
//                }
//            }
//            pic.DrawWidth = Event_Renamed.ObjDrawWidth;
//            pic.FillColor = Event_Renamed.ObjFillColor;
//            pic.FillStyle = Event_Renamed.ObjFillStyle;
//            switch (dtype ?? "")
//            {
//                case "B":
//                    {
//                        pic.Line(x1, y1); /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                        break;
//                    }

//                case "BF":
//                    {
//                        pic.Line(x1, y1); /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                        break;
//                    }

//                default:
//                    {
//                        pic.Line(x1, y1); /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                        break;
//                    }
//            }
//            pic.DrawWidth = 1;
//            pic.FillColor = ColorTranslator.ToOle(Color.White);
//            pic.FillStyle = vbFSTransparent;
//            if (pic2 is object)
//            {
//                pic2.DrawWidth = Event_Renamed.ObjDrawWidth;
//                pic2.FillColor = Event_Renamed.ObjFillColor;
//                pic2.FillStyle = Event_Renamed.ObjFillStyle;
//                switch (dtype ?? "")
//                {
//                    case "B":
//                        {
//                            pic2.Line(x1, y1); /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                            break;
//                        }

//                    case "BF":
//                        {
//                            pic2.Line(x1, y1); /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                            break;
//                        }

//                    default:
//                        {
//                            pic2.Line(x1, y1); /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                            break;
//                        }
//                }
//                pic2.DrawWidth = 1;
//                pic2.FillColor = ColorTranslator.ToOle(Color.White);
//                pic2.FillStyle = vbFSTransparent;
//            }

//            ExecLineCmdRet = LineNum + 1;
//            return ExecLineCmdRet;
//        }

//        private int ExecLineReadCmd()
//        {
//            int ExecLineReadCmdRet = default;
//            string buf;
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "LineReadコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 317363


//                Input:
//                            Error(0)

//                 */
//            }

//            buf = FileSystem.LineInput(GetArgAsLong(2));
//            string argvname = GetArg(3);
//            Expression.SetVariableAsString(ref argvname, ref buf);
//            ExecLineReadCmdRet = LineNum + 1;
//            return ExecLineReadCmdRet;
//        }

//        private int ExecLoadCmd()
//        {
//            int ExecLoadCmdRet = default;
//            string[] new_titles;
//            string tname, tfolder;
//            int i;
//            short j;
//            int cur_data_size;
//            bool flag;
//            new_titles = new string[1];
//            var loopTo = (int)ArgNum;
//            for (i = 2; i <= loopTo; i++)
//            {
//                tname = GetArgAsString((short)i);
//                flag = false;
//                var loopTo1 = (short)Information.UBound(SRC.Titles);
//                for (j = 1; j <= loopTo1; j++)
//                {
//                    if ((tname ?? "") == (SRC.Titles[j] ?? ""))
//                    {
//                        flag = true;
//                        break;
//                    }
//                }

//                if (!flag)
//                {
//                    Array.Resize(ref new_titles, Information.UBound(new_titles) + 1 + 1);
//                    Array.Resize(ref SRC.Titles, Information.UBound(SRC.Titles) + 1 + 1);
//                    new_titles[Information.UBound(new_titles)] = tname;
//                    SRC.Titles[Information.UBound(SRC.Titles)] = tname;
//                }
//            }

//            // 新規のデータがなかった？
//            if (Information.UBound(new_titles) == 0)
//            {
//                ExecLoadCmdRet = LineNum + 1;
//                return ExecLoadCmdRet;
//            }

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;
//            cur_data_size = Information.UBound(Event_Renamed.EventData);

//            // 使用しているタイトルのデータをロード
//            var loopTo2 = Information.UBound(new_titles);
//            for (i = 1; i <= loopTo2; i++)
//            {
//                SRC.IncludeData(ref new_titles[i]);
//                tfolder = SRC.SearchDataFolder(ref new_titles[i]);
//                string argfname1 = tfolder + @"\include.eve";
//                if (GeneralLib.FileExists(ref argfname1))
//                {
//                    string argfname = tfolder + @"\include.eve";
//                    Event_Renamed.LoadEventData2(ref argfname, Information.UBound(Event_Renamed.EventData));
//                }
//            }

//            // ローカルデータの読みこみ
//            string argfname3 = SRC.ScenarioPath + @"Data\alias.txt";
//            if (GeneralLib.FileExists(ref argfname3))
//            {
//                string argfname2 = SRC.ScenarioPath + @"Data\alias.txt";
//                SRC.ALDList.Load(ref argfname2);
//            }

//            bool localFileExists() { string argfname = SRC.ScenarioPath + @"Data\mind.txt"; var ret = GeneralLib.FileExists(ref argfname); return ret; }

//            string argfname6 = SRC.ScenarioPath + @"Data\sp.txt";
//            if (GeneralLib.FileExists(ref argfname6))
//            {
//                string argfname4 = SRC.ScenarioPath + @"Data\sp.txt";
//                SRC.SPDList.Load(ref argfname4);
//            }
//            else if (localFileExists())
//            {
//                string argfname5 = SRC.ScenarioPath + @"Data\mind.txt";
//                SRC.SPDList.Load(ref argfname5);
//            }

//            string argfname8 = SRC.ScenarioPath + @"Data\pilot.txt";
//            if (GeneralLib.FileExists(ref argfname8))
//            {
//                string argfname7 = SRC.ScenarioPath + @"Data\pilot.txt";
//                SRC.PDList.Load(ref argfname7);
//            }

//            string argfname10 = SRC.ScenarioPath + @"Data\non_pilot.txt";
//            if (GeneralLib.FileExists(ref argfname10))
//            {
//                string argfname9 = SRC.ScenarioPath + @"Data\non_pilot.txt";
//                SRC.NPDList.Load(ref argfname9);
//            }

//            string argfname12 = SRC.ScenarioPath + @"Data\robot.txt";
//            if (GeneralLib.FileExists(ref argfname12))
//            {
//                string argfname11 = SRC.ScenarioPath + @"Data\robot.txt";
//                SRC.UDList.Load(ref argfname11);
//            }

//            string argfname14 = SRC.ScenarioPath + @"Data\unit.txt";
//            if (GeneralLib.FileExists(ref argfname14))
//            {
//                string argfname13 = SRC.ScenarioPath + @"Data\unit.txt";
//                SRC.UDList.Load(ref argfname13);
//            }

//            string argfname16 = SRC.ScenarioPath + @"Data\pilot_message.txt";
//            if (GeneralLib.FileExists(ref argfname16))
//            {
//                string argfname15 = SRC.ScenarioPath + @"Data\pilot_message.txt";
//                SRC.MDList.Load(ref argfname15);
//            }

//            string argfname18 = SRC.ScenarioPath + @"Data\pilot_dialog.txt";
//            if (GeneralLib.FileExists(ref argfname18))
//            {
//                string argfname17 = SRC.ScenarioPath + @"Data\pilot_dialog.txt";
//                SRC.DDList.Load(ref argfname17);
//            }

//            string argfname20 = SRC.ScenarioPath + @"Data\item.txt";
//            if (GeneralLib.FileExists(ref argfname20))
//            {
//                string argfname19 = SRC.ScenarioPath + @"Data\item.txt";
//                SRC.IDList.Load(ref argfname19);
//            }

//            var loopTo3 = Information.UBound(Event_Renamed.EventData);
//            for (i = cur_data_size + 1; i <= loopTo3; i++)
//            {
//                // 複数行に分割されたコマンドを結合
//                if (Strings.Right(Event_Renamed.EventData[i], 1) == "_")
//                {
//                    if (Information.UBound(Event_Renamed.EventData) > i)
//                    {
//                        Event_Renamed.EventData[i + 1] = Strings.Left(Event_Renamed.EventData[i], Strings.Len(Event_Renamed.EventData[i]) - 1) + Event_Renamed.EventData[i + 1];
//                        Event_Renamed.EventData[i] = " ";
//                    }
//                }
//            }

//            // ラベルの登録
//            var loopTo4 = Information.UBound(Event_Renamed.EventData);
//            for (i = cur_data_size + 1; i <= loopTo4; i++)
//            {
//                if (Strings.Right(Event_Renamed.EventData[i], 1) == ":")
//                {
//                    string arglname = Strings.Left(Event_Renamed.EventData[i], Strings.Len(Event_Renamed.EventData[i]) - 1);
//                    Event_Renamed.AddLabel(ref arglname, i);
//                }
//            }

//            // コマンドデータ配列を増やす
//            if (Information.UBound(Event_Renamed.EventData) > Information.UBound(Event_Renamed.EventCmd))
//            {
//                Array.Resize(ref Event_Renamed.EventCmd, Information.UBound(Event_Renamed.EventData) + 1);
//            }

//            // イベントデータの構文解析
//            var loopTo5 = Information.UBound(Event_Renamed.EventData);
//            for (i = cur_data_size + 1; i <= loopTo5; i++)
//            {
//                if (Event_Renamed.EventCmd[i] is null)
//                {
//                    Event_Renamed.EventCmd[i] = new CmdData();
//                }

//                {
//                    var withBlock = Event_Renamed.EventCmd[i];
//                    withBlock.LineNum = i;
//                    withBlock.Parse(ref Event_Renamed.EventData[i]);
//                }
//            }

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecLoadCmdRet = LineNum + 1;
//            return ExecLoadCmdRet;
//        }

//        private int ExecLocalCmd()
//        {
//            int ExecLocalCmdRet = default;
//            string vname;
//            short i;
//            Expression.ValueType etype;
//            var str_result = default(string);
//            var num_result = default(double);

//            // 代入式付きの変数定義？
//            if ((int)ArgNum >= 4)
//            {
//                if (GetArg((short)3) == "=")
//                {
//                    if (Event_Renamed.VarIndex >= Event_Renamed.MaxVarIndex)
//                    {
//                        Event_Renamed.VarIndex = Event_Renamed.MaxVarIndex;
//                        Event_Renamed.EventErrorMessage = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)Event_Renamed.MaxVarIndex) + "個を超えるサブルーチンローカル変数は作成できません";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 324715


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    vname = GetArg((short)2);
//                    if (Strings.InStr(vname, "\"") > 0)
//                    {
//                        Event_Renamed.EventErrorMessage = "変数名「" + vname + "」が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 324929


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    if (Strings.Asc(vname) == 36) // $
//                    {
//                        vname = Strings.Mid(vname, 2);
//                    }

//                    if ((int)ArgNum == 4)
//                    {
//                        switch (ArgsType[4])
//                        {
//                            case Expression.ValueType.UndefinedType:
//                                {
//                                    etype = Expression.EvalTerm(ref strArgs[4], ref Expression.ValueType.UndefinedType, ref str_result, ref num_result);
//                                    Event_Renamed.VarIndex = (short)((int)Event_Renamed.VarIndex + 1);
//                                    {
//                                        var withBlock = Event_Renamed.VarStack[(int)Event_Renamed.VarIndex];
//                                        withBlock.Name = vname;
//                                        withBlock.VariableType = etype;
//                                        withBlock.StringValue = str_result;
//                                        withBlock.NumericValue = num_result;
//                                    }

//                                    break;
//                                }

//                            case Expression.ValueType.StringType:
//                                {
//                                    Event_Renamed.VarIndex = (short)((int)Event_Renamed.VarIndex + 1);
//                                    {
//                                        var withBlock1 = Event_Renamed.VarStack[(int)Event_Renamed.VarIndex];
//                                        withBlock1.Name = vname;
//                                        withBlock1.VariableType = Expression.ValueType.StringType;
//                                        withBlock1.StringValue = strArgs[4];
//                                        withBlock1.NumericValue = num_result;
//                                    }

//                                    break;
//                                }

//                            case Expression.ValueType.NumericType:
//                                {
//                                    Event_Renamed.VarIndex = (short)((int)Event_Renamed.VarIndex + 1);
//                                    {
//                                        var withBlock2 = Event_Renamed.VarStack[(int)Event_Renamed.VarIndex];
//                                        withBlock2.Name = vname;
//                                        withBlock2.VariableType = Expression.ValueType.NumericType;
//                                        withBlock2.StringValue = str_result;
//                                        withBlock2.NumericValue = dblArgs[4];
//                                    }

//                                    break;
//                                }
//                        }
//                    }
//                    else
//                    {
//                        etype = Expression.EvalTerm(ref strArgs[4], ref Expression.ValueType.UndefinedType, ref str_result, ref num_result);
//                        Event_Renamed.VarIndex = (short)((int)Event_Renamed.VarIndex + 1);
//                        {
//                            var withBlock3 = Event_Renamed.VarStack[(int)Event_Renamed.VarIndex];
//                            withBlock3.Name = vname;
//                            withBlock3.VariableType = Expression.ValueType.NumericType;
//                            withBlock3.StringValue = str_result;
//                            withBlock3.NumericValue = dblArgs[4];
//                        }
//                    }

//                    ExecLocalCmdRet = LineNum + 1;
//                    return ExecLocalCmdRet;
//                }
//            }

//            Event_Renamed.VarIndex = (short)(Event_Renamed.VarIndex + ArgNum - 1);
//            if (Event_Renamed.VarIndex > Event_Renamed.MaxVarIndex)
//            {
//                Event_Renamed.VarIndex = Event_Renamed.MaxVarIndex;
//                Event_Renamed.EventErrorMessage = Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)Event_Renamed.MaxVarIndex) + "個を超えるサブルーチンローカル変数は作成できません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 327659


//                Input:
//                            Error(0)

//                 */
//            }

//            var loopTo = ArgNum;
//            for (i = (short)2; i <= loopTo; i++)
//            {
//                {
//                    var withBlock4 = Event_Renamed.VarStack[Event_Renamed.VarIndex - i + 2];
//                    vname = GetArg(i);
//                    if (Strings.InStr(vname, "\"") > 0)
//                    {
//                        Event_Renamed.EventErrorMessage = "変数名「" + vname + "」が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 327991


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    if (Strings.Asc(vname) == 36) // $
//                    {
//                        vname = Strings.Mid(vname, 2);
//                    }

//                    withBlock4.Name = vname;
//                    withBlock4.VariableType = Expression.ValueType.StringType;
//                    withBlock4.StringValue = "";
//                }
//            }

//            ExecLocalCmdRet = LineNum + 1;
//            return ExecLocalCmdRet;
//        }

//        private int ExecMakePilotListCmd()
//        {
//            int ExecMakePilotListCmdRet = default;
//            Unit u;
//            Pilot p;
//            short xx, yy;
//            string key_type;
//            var key_list = default(int[]);
//            string[] strkey_list;
//            short max_item;
//            int max_value;
//            string max_str;
//            Pilot[] pilot_list;
//            short i, j;
//            string buf;

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;

//            // パイロットがどのユニットに乗っていたか記録しておく
//            foreach (Unit currentU in SRC.UList)
//            {
//                u = currentU;
//                {
//                    var withBlock = u;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        // あらかじめ撤退させておく
//                        withBlock.Escape("非同期");
//                    }

//                    if (withBlock.Status_Renamed == "待機")
//                    {
//                        if (Strings.InStr(withBlock.Name, "ステータス表示用") == 0)
//                        {
//                            var loopTo = withBlock.CountPilot();
//                            for (i = 1; i <= loopTo; i++)
//                            {
//                                Pilot localPilot() { object argIndex1 = i; var ret = withBlock.Pilot(ref argIndex1); return ret; }

//                                string argvname = "搭乗ユニット[" + localPilot().ID + "]";
//                                Expression.SetVariableAsString(ref argvname, ref withBlock.ID);
//                            }

//                            var loopTo1 = withBlock.CountSupport();
//                            for (i = 1; i <= loopTo1; i++)
//                            {
//                                Pilot localSupport() { object argIndex1 = i; var ret = withBlock.Support(ref argIndex1); return ret; }

//                                string argvname1 = "搭乗ユニット[" + localSupport().ID + "]";
//                                Expression.SetVariableAsString(ref argvname1, ref withBlock.ID);
//                            }
//                        }
//                    }
//                }
//            }

//            // マップをクリア
//            string argfname = "";
//            Map.LoadMapData(ref argfname);
//            string argdraw_mode = "";
//            string argdraw_option = "ステータス";
//            int argfilter_color = 0;
//            double argfilter_trans_par = 0d;
//            GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, filter_color: ref argfilter_color, filter_trans_par: ref argfilter_trans_par);

//            // ユニット一覧を作成
//            key_type = GetArgAsString(2);
//            if (key_type != "名称")
//            {
//                // 配列作成
//                pilot_list = new Pilot[(SRC.PList.Count() + 1)];
//                key_list = new int[(SRC.PList.Count() + 1)];
//                i = 0;
//                foreach (Pilot currentP in SRC.PList)
//                {
//                    p = currentP;
//                    {
//                        var withBlock1 = p;
//                        if (!withBlock1.Alive | withBlock1.Away)
//                        {
//                            goto NextPilot1;
//                        }

//                        if (withBlock1.Unit_Renamed is object)
//                        {
//                            if (withBlock1.IsAdditionalPilot)
//                            {
//                                // 追加パイロットは勘定に入れない
//                                goto NextPilot1;
//                            }

//                            if (withBlock1.IsAdditionalSupport)
//                            {
//                                // 追加サポートは勘定に入れない
//                                goto NextPilot1;
//                            }
//                        }

//                        i = (short)(i + 1);
//                        pilot_list[i] = p;
//                        switch (key_type ?? "")
//                        {
//                            case "レベル":
//                                {
//                                    key_list[i] = withBlock1.Level;
//                                    break;
//                                }

//                            case "ＳＰ":
//                                {
//                                    key_list[i] = withBlock1.MaxSP;
//                                    break;
//                                }

//                            case "格闘":
//                                {
//                                    key_list[i] = withBlock1.Infight;
//                                    break;
//                                }

//                            case "射撃":
//                                {
//                                    key_list[i] = withBlock1.Shooting;
//                                    break;
//                                }

//                            case "命中":
//                                {
//                                    key_list[i] = withBlock1.Hit;
//                                    break;
//                                }

//                            case "回避":
//                                {
//                                    key_list[i] = withBlock1.Dodge;
//                                    break;
//                                }

//                            case "技量":
//                                {
//                                    key_list[i] = withBlock1.Technique;
//                                    break;
//                                }

//                            case "反応":
//                                {
//                                    key_list[i] = withBlock1.Intuition;
//                                    break;
//                                }
//                        }
//                    }

//                    NextPilot1:
//                    ;
//                }

//                Array.Resize(ref pilot_list, i + 1);
//                Array.Resize(ref key_list, i + 1);

//                // ソート
//                var loopTo2 = (short)(Information.UBound(pilot_list) - 1);
//                for (i = 1; i <= loopTo2; i++)
//                {
//                    max_item = i;
//                    max_value = key_list[i];
//                    var loopTo3 = (short)Information.UBound(pilot_list);
//                    for (j = (short)(i + 1); j <= loopTo3; j++)
//                    {
//                        if (key_list[j] > max_value)
//                        {
//                            max_item = j;
//                            max_value = key_list[j];
//                        }
//                    }

//                    if (max_item != i)
//                    {
//                        p = pilot_list[i];
//                        pilot_list[i] = pilot_list[max_item];
//                        pilot_list[max_item] = p;
//                        max_value = key_list[max_item];
//                        key_list[max_item] = key_list[i];
//                        key_list[i] = max_value;
//                    }
//                }
//            }
//            else
//            {
//                // 配列作成
//                pilot_list = new Pilot[(SRC.PList.Count() + 1)];
//                strkey_list = new string[(SRC.PList.Count() + 1)];
//                i = 0;
//                foreach (Pilot currentP1 in SRC.PList)
//                {
//                    p = currentP1;
//                    {
//                        var withBlock2 = p;
//                        if (!withBlock2.Alive | withBlock2.Away)
//                        {
//                            goto NextPilot2;
//                        }

//                        if (withBlock2.Unit_Renamed is object)
//                        {
//                            object argIndex1 = "追加パイロット";
//                            if ((withBlock2.Name ?? "") == (withBlock2.Unit_Renamed.FeatureData(ref argIndex1) ?? ""))
//                            {
//                                // 追加パイロットは勘定に入れない
//                                goto NextPilot2;
//                            }
//                        }

//                        i = (short)(i + 1);
//                        pilot_list[i] = p;
//                        strkey_list[i] = p.KanaName;
//                    }

//                    NextPilot2:
//                    ;
//                }

//                Array.Resize(ref pilot_list, i + 1);
//                Array.Resize(ref strkey_list, i + 1);

//                // ソート
//                var loopTo4 = (short)(Information.UBound(pilot_list) - 1);
//                for (i = 1; i <= loopTo4; i++)
//                {
//                    max_item = i;
//                    max_str = strkey_list[max_item];
//                    var loopTo5 = (short)Information.UBound(pilot_list);
//                    for (j = (short)(i + 1); j <= loopTo5; j++)
//                    {
//                        if (Strings.StrComp(strkey_list[j], max_str, (CompareMethod)1) == -1)
//                        {
//                            max_item = j;
//                            max_str = strkey_list[j];
//                        }
//                    }

//                    if (max_item != i)
//                    {
//                        p = pilot_list[i];
//                        pilot_list[i] = pilot_list[max_item];
//                        pilot_list[max_item] = p;
//                        strkey_list[max_item] = strkey_list[i];
//                    }
//                }
//            }

//            // Font Regular 9pt 背景
//            {
//                var withBlock3 = GUI.MainForm.picMain(0).Font;
//                withBlock3.Size = 9;
//                withBlock3.Bold = false;
//                withBlock3.Italic = false;
//            }

//            GUI.PermanentStringMode = true;
//            GUI.HCentering = false;
//            GUI.VCentering = false;
//            xx = 1;
//            yy = 1;
//            var loopTo6 = (short)Information.UBound(pilot_list);
//            for (i = 1; i <= loopTo6; i++)
//            {
//                p = pilot_list[i];
//                // ユニット出撃位置を折り返す
//                if (xx > 15)
//                {
//                    xx = 1;
//                    yy = (short)(yy + 1);
//                    if (yy > 40)
//                    {
//                        // パイロット数が多すぎるため、一部のパイロットが表示出来ません
//                        break;
//                    }
//                }

//                // ダミーユニットに載せる
//                string argfname1 = "ダミーユニット";
//                if (p.Unit_Renamed is null)
//                {
//                    object argIndex2 = p.Name + "ステータス表示用ユニット";
//                    if (SRC.UDList.IsDefined(ref argIndex2))
//                    {
//                        string arguname = p.Name + "ステータス表示用ユニット";
//                        string arguparty = "味方";
//                        u = SRC.UList.Add(ref arguname, 0, ref arguparty);
//                    }
//                    else
//                    {
//                        string arguname1 = "ステータス表示用ダミーユニット";
//                        string arguparty1 = "味方";
//                        u = SRC.UList.Add(ref arguname1, 0, ref arguparty1);
//                    }

//                    p.Ride(ref u);
//                }
//                else if (!p.Unit_Renamed.IsFeatureAvailable(ref argfname1))
//                {
//                    p.GetOff();
//                    object argIndex3 = p.Name + "ステータス表示用ユニット";
//                    if (SRC.UDList.IsDefined(ref argIndex3))
//                    {
//                        string arguname2 = p.Name + "ステータス表示用ユニット";
//                        string arguparty2 = "味方";
//                        u = SRC.UList.Add(ref arguname2, 0, ref arguparty2);
//                    }
//                    else
//                    {
//                        string arguname3 = "ステータス表示用ダミーユニット";
//                        string arguparty3 = "味方";
//                        u = SRC.UList.Add(ref arguname3, 0, ref arguparty3);
//                    }

//                    p.Ride(ref u);
//                }
//                else
//                {
//                    u = p.Unit_Renamed;
//                }

//                // 出撃
//                u.UsedAction = 0;
//                u.StandBy(xx, yy, "非同期");

//                // プレイヤーが操作できないように
//                string argcname = "非操作";
//                string argcdata = "";
//                u.AddCondition(ref argcname, -1, cdata: ref argcdata);

//                // パイロットの愛称を表示
//                string argmsg = p.get_Nickname(false);
//                GUI.DrawString(ref argmsg, 32 * xx + 2, 32 * yy - 31);
//                p.get_Nickname(false) = argmsg;
//                switch (key_type ?? "")
//                {
//                    case "レベル":
//                    case "名称":
//                        {
//                            string argmsg1 = "Lv" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(p.Level);
//                            GUI.DrawString(ref argmsg1, 32 * xx + 2, 32 * yy - 15);
//                            break;
//                        }

//                    case "ＳＰ":
//                        {
//                            string argtname = "SP";
//                            string argmsg2 = Expression.Term(ref argtname, ref u) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(key_list[i]);
//                            GUI.DrawString(ref argmsg2, 32 * xx + 2, 32 * yy - 15);
//                            break;
//                        }

//                    case "格闘":
//                        {
//                            string argtname1 = "格闘";
//                            string argmsg3 = Strings.Left(Expression.Term(ref argtname1, ref u), 1) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(key_list[i]);
//                            GUI.DrawString(ref argmsg3, 32 * xx + 2, 32 * yy - 15);
//                            break;
//                        }

//                    case "射撃":
//                        {
//                            if (p.HasMana())
//                            {
//                                string argtname2 = "魔力";
//                                string argmsg4 = Strings.Left(Expression.Term(ref argtname2, ref u), 1) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(key_list[i]);
//                                GUI.DrawString(ref argmsg4, 32 * xx + 2, 32 * yy - 15);
//                            }
//                            else
//                            {
//                                string argtname3 = "射撃";
//                                string argmsg5 = Strings.Left(Expression.Term(ref argtname3, ref u), 1) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(key_list[i]);
//                                GUI.DrawString(ref argmsg5, 32 * xx + 2, 32 * yy - 15);
//                            }

//                            break;
//                        }

//                    case "命中":
//                        {
//                            string argtname4 = "命中";
//                            string argmsg6 = Strings.Left(Expression.Term(ref argtname4, ref u), 1) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(key_list[i]);
//                            GUI.DrawString(ref argmsg6, 32 * xx + 2, 32 * yy - 15);
//                            break;
//                        }

//                    case "回避":
//                        {
//                            string argtname5 = "回避";
//                            string argmsg7 = Strings.Left(Expression.Term(ref argtname5, ref u), 1) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(key_list[i]);
//                            GUI.DrawString(ref argmsg7, 32 * xx + 2, 32 * yy - 15);
//                            break;
//                        }

//                    case "技量":
//                        {
//                            string argtname6 = "技量";
//                            string argmsg8 = Strings.Left(Expression.Term(ref argtname6, ref u), 1) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(key_list[i]);
//                            GUI.DrawString(ref argmsg8, 32 * xx + 2, 32 * yy - 15);
//                            break;
//                        }

//                    case "反応":
//                        {
//                            string argtname7 = "反応";
//                            string argmsg9 = Strings.Left(Expression.Term(ref argtname7, ref u), 1) + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(key_list[i]);
//                            GUI.DrawString(ref argmsg9, 32 * xx + 2, 32 * yy - 15);
//                            break;
//                        }
//                }

//                // 表示位置を右に3マスずらす
//                xx = (short)(xx + 3);
//            }

//            // フォントの設定を戻しておく
//            {
//                var withBlock4 = GUI.MainForm.picMain(0).Font;
//                withBlock4.Size = 16;
//                withBlock4.Bold = true;
//                withBlock4.Italic = false;
//            }

//            GUI.PermanentStringMode = false;
//            GUI.RedrawScreen();

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecMakePilotListCmdRet = LineNum + 1;
//            return ExecMakePilotListCmdRet;
//        }

//        private int ExecMakeUnitListCmd()
//        {
//            int ExecMakeUnitListCmdRet = default;
//            // ユニット一覧を作成
//            string argsmode = GetArgAsString(2);
//            Event_Renamed.MakeUnitList(ref argsmode);
//            ExecMakeUnitListCmdRet = LineNum + 1;
//            return ExecMakeUnitListCmdRet;
//        }

//        private int ExecMapAbilityCmd()
//        {
//            int ExecMapAbilityCmdRet = default;
//            Unit u;
//            short tx, ty;
//            short a;
//            switch (ArgNum)
//            {
//                case 5:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        {
//                            var withBlock = u;
//                            var loopTo = withBlock.CountAbility();
//                            for (a = (short)1; a <= loopTo; a++)
//                            {
//                                string argattr = "Ｍ";
//                                if ((GetArgAsString((short)3) ?? "") == (withBlock.Ability(a).Name ?? "") & withBlock.IsAbilityClassifiedAs(a, ref argattr))
//                                {
//                                    break;
//                                }
//                            }

//                            if (a > withBlock.CountAbility())
//                            {
//                                Event_Renamed.EventErrorMessage = "アビリティ名が間違っています";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 339287


//                                Input:
//                                                        Error(0)

//                                 */
//                            }
//                        }

//                        tx = (short)GetArgAsLong((short)4);
//                        if ((int)tx < 1)
//                        {
//                            tx = (short)1;
//                        }
//                        else if (tx > Map.MapWidth)
//                        {
//                            tx = Map.MapWidth;
//                        }

//                        ty = (short)GetArgAsLong((short)5);
//                        if ((int)ty < 1)
//                        {
//                            ty = (short)1;
//                        }
//                        else if (ty > Map.MapHeight)
//                        {
//                            ty = Map.MapHeight;
//                        }

//                        break;
//                    }

//                case 4:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        var loopTo1 = u.CountAbility();
//                        for (a = (short)1; a <= loopTo1; a++)
//                        {
//                            string argattr1 = "Ｍ";
//                            if ((GetArgAsString((short)2) ?? "") == (u.Ability(a).Name ?? "") & u.IsAbilityClassifiedAs(a, ref argattr1))
//                            {
//                                break;
//                            }
//                        }

//                        if (a > u.CountAbility())
//                        {
//                            Event_Renamed.EventErrorMessage = "アビリティ名が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 340037


//                            Input:
//                                                    Error(0)

//                             */
//                        }

//                        tx = (short)GetArgAsLong((short)3);
//                        if ((int)tx < 1)
//                        {
//                            tx = (short)1;
//                        }
//                        else if (tx > Map.MapWidth)
//                        {
//                            tx = Map.MapWidth;
//                        }

//                        ty = (short)GetArgAsLong((short)4);
//                        if ((int)ty < 1)
//                        {
//                            ty = (short)1;
//                        }
//                        else if (ty > Map.MapHeight)
//                        {
//                            ty = Map.MapHeight;
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "MapAbilityコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 340520


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u.Status_Renamed != "出撃")
//            {
//                Event_Renamed.EventErrorMessage = u.Nickname + "は出撃していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 340677


//                Input:
//                                Error(0)

//                 */
//            }

//            Unit argu1 = null;
//            Unit argu2 = null;
//            GUI.OpenMessageForm(u1: ref argu1, u2: ref argu2);
//            u.ExecuteMapAbility(a, tx, ty, true);
//            GUI.CloseMessageForm();
//            GUI.RedrawScreen();
//            ExecMapAbilityCmdRet = LineNum + 1;
//            return ExecMapAbilityCmdRet;
//        }

//        private int ExecMapAttackCmd()
//        {
//            int ExecMapAttackCmdRet = default;
//            Unit u;
//            short tx, ty;
//            short w;
//            short prev_w, prev_tw;
//            string cur_stage;
//            bool is_event;
//            short num;
//            num = ArgNum;
//            is_event = true;
//            if (num <= 6)
//            {
//                if (GetArgAsString(num) == "通常戦闘")
//                {
//                    is_event = false;
//                    num = (short)(num - 1);
//                }
//            }

//            switch (num)
//            {
//                case 5:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        {
//                            var withBlock = u;
//                            var loopTo = withBlock.CountWeapon();
//                            for (w = (short)1; w <= loopTo; w++)
//                            {
//                                string argattr = "Ｍ";
//                                if ((GetArgAsString((short)3) ?? "") == (withBlock.Weapon(w).Name ?? "") & withBlock.IsWeaponClassifiedAs(w, ref argattr))
//                                {
//                                    break;
//                                }
//                            }

//                            if (w > withBlock.CountWeapon())
//                            {
//                                Event_Renamed.EventErrorMessage = "マップ攻撃名が間違っています";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 341692


//                                Input:
//                                                        Error(0)

//                                 */
//                            }
//                        }

//                        tx = (short)GetArgAsLong((short)4);
//                        if ((int)tx < 1)
//                        {
//                            tx = (short)1;
//                        }
//                        else if (tx > Map.MapWidth)
//                        {
//                            tx = Map.MapWidth;
//                        }

//                        ty = (short)GetArgAsLong((short)5);
//                        if ((int)ty < 1)
//                        {
//                            ty = (short)1;
//                        }
//                        else if (ty > Map.MapHeight)
//                        {
//                            ty = Map.MapHeight;
//                        }

//                        break;
//                    }

//                case 4:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        var loopTo1 = u.CountWeapon();
//                        for (w = (short)1; w <= loopTo1; w++)
//                        {
//                            string argattr1 = "Ｍ";
//                            if ((GetArgAsString((short)2) ?? "") == (u.Weapon(w).Name ?? "") & u.IsWeaponClassifiedAs(w, ref argattr1))
//                            {
//                                break;
//                            }
//                        }

//                        if (w > u.CountWeapon())
//                        {
//                            Event_Renamed.EventErrorMessage = "マップ攻撃名が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 342439


//                            Input:
//                                                    Error(0)

//                             */
//                        }

//                        tx = (short)GetArgAsLong((short)3);
//                        if ((int)tx < 1)
//                        {
//                            tx = (short)1;
//                        }
//                        else if (tx > Map.MapWidth)
//                        {
//                            tx = Map.MapWidth;
//                        }

//                        ty = (short)GetArgAsLong((short)4);
//                        if ((int)ty < 1)
//                        {
//                            ty = (short)1;
//                        }
//                        else if (ty > Map.MapHeight)
//                        {
//                            ty = Map.MapHeight;
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "MapAttackコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 342921


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u.Status_Renamed != "出撃")
//            {
//                Event_Renamed.EventErrorMessage = u.Nickname + "は出撃していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 343078


//                Input:
//                                Error(0)

//                 */
//            }

//            // ステージを仮想的に変更しておく
//            cur_stage = SRC.Stage;
//            SRC.Stage = u.Party;
//            prev_w = Commands.SelectedWeapon;
//            prev_tw = Commands.SelectedTWeapon;
//            Commands.SelectedWeapon = w;
//            Commands.SelectedTWeapon = 0;
//            Commands.SelectedX = tx;
//            Commands.SelectedY = ty;
//            u.MapAttack(w, tx, ty, is_event);
//            Commands.SelectedWeapon = prev_w;
//            Commands.SelectedTWeapon = prev_tw;
//            SRC.Stage = cur_stage;
//            GUI.RedrawScreen();
//            ExecMapAttackCmdRet = LineNum + 1;
//            return ExecMapAttackCmdRet;
//        }

//        private int ExecMoneyCmd()
//        {
//            int ExecMoneyCmdRet = default;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Moneyコマンドの引数の数が間違っています";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 343971


//                Input:
//                            Error(0)

//                 */
//            }

//            SRC.IncrMoney(GetArgAsLong(2));
//            ExecMoneyCmdRet = LineNum + 1;
//            return ExecMoneyCmdRet;
//        }

//        private int ExecMonotoneCmd()
//        {
//            int ExecMonotoneCmdRet = default;
//            short prev_x, prev_y;
//            bool late_refresh;
//            short i;
//            string buf;
//            late_refresh = false;
//            Map.MapDrawIsMapOnly = false;
//            var loopTo = ArgNum;
//            for (i = (short)2; i <= loopTo; i++)
//            {
//                buf = GetArgAsString(i);
//                switch (buf ?? "")
//                {
//                    case "非同期":
//                        {
//                            late_refresh = true;
//                            break;
//                        }

//                    case "マップ限定":
//                        {
//                            Map.MapDrawIsMapOnly = true;
//                            break;
//                        }

//                    default:
//                        {
//                            Event_Renamed.EventErrorMessage = "Monotoneコマンドに不正なオプション「" + buf + "」が使われています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 344669


//                            Input:
//                                                Error(0)

//                             */
//                            break;
//                        }
//                }
//            }

//            prev_x = GUI.MapX;
//            prev_y = GUI.MapY;

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;
//            string argdraw_mode = "白黒";
//            string argdraw_option = "非同期";
//            int argfilter_color = 0;
//            double argfilter_trans_par = 0d;
//            GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, filter_color: ref argfilter_color, filter_trans_par: ref argfilter_trans_par);
//            foreach (Unit u in SRC.UList)
//            {
//                {
//                    var withBlock = u;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        if (withBlock.BitmapID == 0)
//                        {
//                            object argIndex1 = withBlock.Name;
//                            {
//                                var withBlock1 = SRC.UList.Item(ref argIndex1);
//                                string argfname = "ダミーユニット";
//                                if ((u.Party0 ?? "") == (withBlock1.Party0 ?? "") & withBlock1.BitmapID != 0 & (u.get_Bitmap(false) ?? "") == (withBlock1.get_Bitmap(false) ?? "") & !withBlock1.IsFeatureAvailable(ref argfname))
//                                {
//                                    u.BitmapID = withBlock1.BitmapID;
//                                }
//                                else
//                                {
//                                    u.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                }
//                            }

//                            withBlock.Name = Conversions.ToString(argIndex1);
//                        }
//                    }
//                }
//            }

//            GUI.Center(prev_x, prev_y);
//            GUI.RedrawScreen(late_refresh);

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecMonotoneCmdRet = LineNum + 1;
//            return ExecMonotoneCmdRet;
//        }

//        private int ExecMoveCmd()
//        {
//            int ExecMoveCmdRet = default;
//            Unit u;
//            short ux, uy;
//            short tx, ty;
//            var opt = default(string);
//            short idx;
//            if (!Information.IsNumeric(GetArgAsString(2)))
//            {
//                idx = 3;
//                u = GetArgAsUnit(2);
//            }
//            else
//            {
//                idx = 2;
//                u = Event_Renamed.SelectedUnitForEvent;
//            }

//            tx = (short)GetArgAsLong(idx);
//            if (tx < 1)
//            {
//                tx = 1;
//            }
//            else if (tx > Map.MapWidth)
//            {
//                tx = Map.MapWidth;
//            }

//            idx = (short)(idx + 1);
//            ty = (short)GetArgAsLong(idx);
//            if (ty < 1)
//            {
//                ty = 1;
//            }
//            else if (ty > Map.MapHeight)
//            {
//                ty = Map.MapHeight;
//            }

//            idx = (short)(idx + 1);
//            if (idx <= ArgNum)
//            {
//                opt = GetArgAsString(idx);
//            }

//            {
//                var withBlock = u;
//                switch (u.Status_Renamed ?? "")
//                {
//                    case "出撃":
//                        {
//                            if (Strings.InStr(opt, "アニメ表示") == 1)
//                            {
//                                // 現在位置を記録
//                                ux = withBlock.x;
//                                uy = withBlock.y;

//                                // 目的地にユニットがいて入れない場合があるので
//                                // 実際に移動させて到着地点を確かめる
//                                withBlock.Jump(tx, ty, false);
//                                tx = withBlock.x;
//                                ty = withBlock.y;

//                                // 一旦元の位置に戻す
//                                withBlock.Jump(ux, uy, false);

//                                // 移動アニメ表示
//                                GUI.MoveUnitBitmap(ref u, ux, uy, tx, ty, 20);
//                            }

//                            withBlock.Jump(tx, ty, false);
//                            break;
//                        }

//                    case "格納":
//                        {
//                            withBlock.StandBy(tx, ty, opt);
//                            break;
//                        }

//                    default:
//                        {
//                            Event_Renamed.EventErrorMessage = withBlock.MainPilot().get_Nickname(false) + "は出撃していません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 347546


//                            Input:
//                                                Error(0)

//                             */
//                            break;
//                        }
//                }
//            }

//            if (string.IsNullOrEmpty(opt) | Strings.InStr(opt, "アニメ表示") == 1)
//            {
//                if (GUI.MainForm.Visible & !GUI.IsPictureVisible)
//                {
//                    GUI.RedrawScreen();
//                }
//            }
//            else if (opt == "非同期")
//            {
//            }
//            // 画面更新しない
//            else
//            {
//                Event_Renamed.EventErrorMessage = "Moveコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 347943


//                Input:
//                            Error(0)

//                 */
//            }

//            ExecMoveCmdRet = LineNum + 1;
//            return ExecMoveCmdRet;
//        }

//        private int ExecNightCmd()
//        {
//            int ExecNightCmdRet = default;
//            short prev_x, prev_y;
//            bool late_refresh;
//            short i;
//            string buf;
//            late_refresh = false;
//            Map.MapDrawIsMapOnly = false;
//            var loopTo = ArgNum;
//            for (i = (short)2; i <= loopTo; i++)
//            {
//                buf = GetArgAsString(i);
//                switch (buf ?? "")
//                {
//                    case "非同期":
//                        {
//                            late_refresh = true;
//                            break;
//                        }

//                    case "マップ限定":
//                        {
//                            Map.MapDrawIsMapOnly = true;
//                            break;
//                        }

//                    default:
//                        {
//                            Event_Renamed.EventErrorMessage = "Nightコマンドに不正なオプション「" + buf + "」が使われています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 348577


//                            Input:
//                                                Error(0)

//                             */
//                            break;
//                        }
//                }
//            }

//            prev_x = GUI.MapX;
//            prev_y = GUI.MapY;

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;
//            string argdraw_mode = "夜";
//            string argdraw_option = "非同期";
//            int argfilter_color = 0;
//            double argfilter_trans_par = 0d;
//            GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, filter_color: ref argfilter_color, filter_trans_par: ref argfilter_trans_par);
//            foreach (Unit u in SRC.UList)
//            {
//                {
//                    var withBlock = u;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        if (withBlock.BitmapID == 0)
//                        {
//                            object argIndex1 = withBlock.Name;
//                            {
//                                var withBlock1 = SRC.UList.Item(ref argIndex1);
//                                string argfname = "ダミーユニット";
//                                if ((u.Party0 ?? "") == (withBlock1.Party0 ?? "") & withBlock1.BitmapID != 0 & (u.get_Bitmap(false) ?? "") == (withBlock1.get_Bitmap(false) ?? "") & !withBlock1.IsFeatureAvailable(ref argfname))
//                                {
//                                    u.BitmapID = withBlock1.BitmapID;
//                                }
//                                else
//                                {
//                                    u.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                }
//                            }

//                            withBlock.Name = Conversions.ToString(argIndex1);
//                        }
//                    }
//                }
//            }

//            GUI.Center(prev_x, prev_y);
//            GUI.RedrawScreen(late_refresh);

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecNightCmdRet = LineNum + 1;
//            return ExecNightCmdRet;
//        }

//        private int ExecNoonCmd()
//        {
//            int ExecNoonCmdRet = default;
//            short prev_x, prev_y;
//            var late_refresh = default(bool);
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        break;
//                    }
//                // ＯＫ
//                case 2:
//                    {
//                        if (GetArgAsString((short)2) == "非同期")
//                        {
//                            late_refresh = true;
//                        }
//                        else
//                        {
//                            Event_Renamed.EventErrorMessage = "Noonコマンドのオプションが不正です";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 350346


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Noonコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 350462


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            Map.MapDrawIsMapOnly = false;
//            prev_x = GUI.MapX;
//            prev_y = GUI.MapY;

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;
//            string argdraw_mode = "";
//            string argdraw_option = "非同期";
//            int argfilter_color = 0;
//            double argfilter_trans_par = 0d;
//            GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, filter_color: ref argfilter_color, filter_trans_par: ref argfilter_trans_par);
//            foreach (Unit u in SRC.UList)
//            {
//                {
//                    var withBlock = u;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        if (withBlock.BitmapID == 0)
//                        {
//                            object argIndex1 = withBlock.Name;
//                            {
//                                var withBlock1 = SRC.UList.Item(ref argIndex1);
//                                string argfname = "ダミーユニット";
//                                if ((u.Party0 ?? "") == (withBlock1.Party0 ?? "") & withBlock1.BitmapID != 0 & (u.get_Bitmap(false) ?? "") == (withBlock1.get_Bitmap(false) ?? "") & !withBlock1.IsFeatureAvailable(ref argfname))
//                                {
//                                    u.BitmapID = withBlock1.BitmapID;
//                                }
//                                else
//                                {
//                                    u.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                }
//                            }

//                            withBlock.Name = Conversions.ToString(argIndex1);
//                        }
//                    }
//                }
//            }

//            GUI.Center(prev_x, prev_y);
//            GUI.RedrawScreen(late_refresh);

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecNoonCmdRet = LineNum + 1;
//            return ExecNoonCmdRet;
//        }

//        private int ExecOpenCmd()
//        {
//            int ExecOpenCmdRet = default;
//            string fname;
//            string vname;
//            string opt;
//            short f;
//            if ((int)ArgNum != 6)
//            {
//                Event_Renamed.EventErrorMessage = "Openコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 352148


//                Input:
//                            Error(0)

//                 */
//            }

//            fname = SRC.ScenarioPath + GetArgAsString(2);
//            if (Strings.InStr(fname, @"..\") > 0)
//            {
//                Event_Renamed.EventErrorMessage = @"ファイル指定に「..\」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 352393


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname, "../") > 0)
//            {
//                Event_Renamed.EventErrorMessage = "ファイル指定に「../」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 352563


//                Input:
//                            Error(0)

//                 */
//            }

//            opt = GetArgAsString(4);
//            vname = GetArg(6);
//            f = (short)FileSystem.FreeFile();
//            Expression.SetVariableAsLong(ref vname, f);
//            switch (opt ?? "")
//            {
//                case "出力":
//                    {
//                        FileSystem.FileOpen((int)f, fname, OpenMode.Output, OpenAccess.Write);
//                        break;
//                    }

//                case "追加出力":
//                    {
//                        FileSystem.FileOpen((int)f, fname, OpenMode.Append, OpenAccess.Write);
//                        break;
//                    }

//                case "入力":
//                    {
//                        if (!GeneralLib.FileExists(ref fname))
//                        {
//                            Event_Renamed.EventErrorMessage = fname + "というファイルは存在しません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 353284


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        FileSystem.FileOpen((int)f, fname, OpenMode.Input, OpenAccess.Read);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ファイルの入出力モードが不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 353553


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecOpenCmdRet = LineNum + 1;
//            return ExecOpenCmdRet;
//        }

//        private int ExecOptionCmd()
//        {
//            int ExecOptionCmdRet = default;
//            string vname;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        vname = GetArgAsString((short)2);
//                        vname = "Option(" + vname + ")";
//                        if (!Expression.IsGlobalVariableDefined(ref vname))
//                        {
//                            Expression.DefineGlobalVariable(ref vname);
//                        }

//                        Expression.SetVariableAsLong(ref vname, 1);
//                        // ADD START MARGE
//                        if (vname == "Option(新ＧＵＩ)")
//                        {
//                            // 新ＧＵＩが指定されたら即反映するためにメイン画面をロードしなおす
//                            GUI.LoadForms();
//                        }

//                        break;
//                    }
//                // ADD END MARGE
//                case 3:
//                    {
//                        vname = GetArgAsString((short)2);
//                        vname = "Option(" + vname + ")";
//                        if (Expression.IsGlobalVariableDefined(ref vname))
//                        {
//                            Expression.UndefineVariable(ref vname);
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Optionコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 354508


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecOptionCmdRet = LineNum + 1;
//            return ExecOptionCmdRet;
//        }

//        private int ExecOrganizeCmd()
//        {
//            int ExecOrganizeCmdRet = default;
//            short unum;
//            short ux, uy;
//            var uclass = default(string);
//            string buf, opt = default;
//            short j, i, num;
//            int tmp;
//            int min_value;
//            short max_item;
//            int max_value;
//            int[] lv_list;
//            string[] list;
//            short ret;
//            bool without_refresh;
//            bool without_animation;
//            num = ArgNum;
//            var loopTo = num;
//            for (i = 5; i <= loopTo; i++)
//            {
//                // MOD START MARGE
//                // Select Case GetArgAsString(num)
//                switch (GetArgAsString(i) ?? "")
//                {
//                    // MOD END MARGE
//                    case "密集":
//                        {
//                            opt = opt + " 出撃";
//                            break;
//                        }
//                    // num = num - 1
//                    case "非同期":
//                        {
//                            opt = opt + " 非同期";
//                            break;
//                        }
//                    // num = num - 1
//                    case "アニメ非表示":
//                        {
//                            opt = opt + " アニメ非表示";
//                            break;
//                        }
//                        // num = num - 1
//                }
//            }
//            // MOD START MARGE
//            // If InStr(opt, "出撃") = 0 Then
//            if (Strings.InStr(opt, "出撃") <= 0)
//            {
//                // MOD END MARGE
//                opt = opt + " 部隊配置";
//            }

//            if ((int)num < 4)
//            {
//                Event_Renamed.EventErrorMessage = "Organizeコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 355755


//                Input:
//                            Error(0)

//                 */
//            }

//            unum = (short)GetArgAsLong(2);
//            if ((int)unum < 1)
//            {
//                Event_Renamed.EventErrorMessage = "ユニット数が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 355898


//                Input:
//                            Error(0)

//                 */
//            }

//            ux = (short)GetArgAsLong(3);
//            if (ux < 1)
//            {
//                ux = 1;
//            }
//            else if (ux > Map.MapWidth)
//            {
//                ux = Map.MapWidth;
//            }

//            uy = (short)GetArgAsLong(4);
//            if (uy < 1)
//            {
//                uy = 1;
//            }
//            else if (uy > Map.MapHeight)
//            {
//                uy = Map.MapHeight;
//            }

//            if (num < 5)
//            {
//                uclass = "全て";
//            }
//            else
//            {
//                var loopTo1 = num;
//                for (i = 5; i <= loopTo1; i++)
//                    uclass = uclass + " " + GetArgAsString(i);
//                uclass = Strings.Trim(uclass);
//            }

//            Beginning:
//            ;
//            list = new string[1];
//            GUI.ListItemID = new string[1];
//            foreach (Unit u in SRC.UList)
//            {
//                if (u.Party0 != "味方" | u.Status_Renamed != "待機" | u.CountPilot() == 0)
//                {
//                    goto NextOrganizeLoop;
//                }

//                // パイロット数のチェック
//                string argfname = "１人乗り可能";
//                if ((u.Data.PilotNum == 1 | Math.Abs(u.Data.PilotNum) == 2) & u.CountPilot() < Math.Abs(u.Data.PilotNum) & !u.IsFeatureAvailable(ref argfname))
//                {
//                    goto NextOrganizeLoop;
//                }

//                switch (Map.TerrainClass(1, 1) ?? "")
//                {
//                    case "宇宙":
//                    case "月面":
//                        {
//                            if (u.get_Adaption(4) == 0)
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }

//                    default:
//                        {
//                            // 宇宙専用ユニットは宇宙でしか活動できない
//                            if (u.Transportation == "宇宙")
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            // 空中マップか？
//                            if (Map.TerrainName(1, 1) == "空" & Map.TerrainName((short)(Map.MapWidth / 2), (short)(Map.MapHeight / 2)) == "空" & Map.TerrainName(Map.MapWidth, Map.MapHeight) == "空")
//                            {
//                                string argarea_name = "空";
//                                if (!u.IsTransAvailable(ref argarea_name))
//                                {
//                                    goto NextOrganizeLoop;
//                                }
//                            }

//                            break;
//                        }
//                }

//                switch (uclass ?? "")
//                {
//                    case "全て":
//                    case var @case when @case == "":
//                        {
//                            break;
//                        }
//                    // 全てのユニット
//                    case "通常ユニット":
//                        {
//                            string argfname1 = "母艦";
//                            if (u.IsFeatureAvailable(ref argfname1))
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }

//                    case "母艦ユニット":
//                        {
//                            string argfname2 = "母艦";
//                            if (!u.IsFeatureAvailable(ref argfname2))
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }

//                    case "LL":
//                        {
//                            if (u.Size == "XL")
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }

//                    case "L":
//                        {
//                            if (u.Size == "XL" | u.Size == "LL")
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }

//                    case "M":
//                        {
//                            if (u.Size == "XL" | u.Size == "LL" | u.Size == "L")
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }

//                    case "S":
//                        {
//                            if (u.Size == "XL" | u.Size == "LL" | u.Size == "L" | u.Size == "M")
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }

//                    case "SS":
//                        {
//                            if (u.Size == "XL" | u.Size == "LL" | u.Size == "L" | u.Size == "M" | u.Size == "S")
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }

//                    default:
//                        {
//                            // ユニットクラス指定した場合

//                            // 指定されたクラスに該当するか
//                            var loopTo2 = GeneralLib.ListLength(ref uclass);
//                            for (i = 1; i <= loopTo2; i++)
//                            {
//                                if ((GeneralLib.ListIndex(ref uclass, i) ?? "") == (u.Class0 ?? ""))
//                                {
//                                    break;
//                                }
//                            }

//                            if (i > GeneralLib.ListLength(ref uclass))
//                            {
//                                goto NextOrganizeLoop;
//                            }

//                            break;
//                        }
//                }

//                Array.Resize(ref list, Information.UBound(list) + 1 + 1);
//                Array.Resize(ref GUI.ListItemID, Information.UBound(list) + 1);
//                string argoname = "等身大基準";
//                if (Expression.IsOptionDefined(ref argoname))
//                {
//                    string localLeftPaddedString() { string argbuf = u.MainPilot().Level.ToString(); var ret = GeneralLib.LeftPaddedString(ref argbuf, 2); return ret; }

//                    list[Information.UBound(list)] = u.Nickname0 + Strings.Space(GeneralLib.MaxLng(52 - LenB(Strings.StrConv(u.Nickname0, vbFromUnicode)), 1)) + localLeftPaddedString();
//                }
//                else
//                {
//                    string localLeftPaddedString1() { string argbuf = u.MainPilot().Level.ToString(); var ret = GeneralLib.LeftPaddedString(ref argbuf, 2); return ret; }

//                    list[Information.UBound(list)] = u.Nickname0 + Strings.Space(GeneralLib.MaxLng(36 - LenB(Strings.StrConv(u.Nickname0, vbFromUnicode)), 1)) + u.MainPilot().get_Nickname(false) + Strings.Space(GeneralLib.MaxLng(17 - LenB(Strings.StrConv(u.MainPilot().get_Nickname(false), vbFromUnicode)), 1)) + localLeftPaddedString1();
//                }

//                GUI.ListItemID[Information.UBound(list)] = u.ID;
//                NextOrganizeLoop:
//                ;
//            }

//            GUI.ListItemFlag = new bool[Information.UBound(list) + 1];

//            // レベルの一覧と最大値・最小値を求める
//            lv_list = new int[Information.UBound(list) + 1];
//            min_value = 100000;
//            max_value = 0;
//            var loopTo3 = (short)Information.UBound(list);
//            for (i = 1; i <= loopTo3; i++)
//            {
//                Unit localItem() { var tmp1 = GUI.ListItemID; object argIndex1 = tmp1[i]; var ret = SRC.UList.Item(ref argIndex1); return ret; }

//                {
//                    var withBlock = localItem().MainPilot();
//                    lv_list[i] = 500 * withBlock.Level + withBlock.Exp;
//                }

//                if (lv_list[i] > max_value)
//                {
//                    max_value = lv_list[i];
//                }

//                if (lv_list[i] < min_value)
//                {
//                    min_value = lv_list[i];
//                }
//            }

//            // レベルにばらつきがある時にのみレベルでソート
//            if (min_value != max_value)
//            {
//                var loopTo4 = (short)(Information.UBound(list) - 1);
//                for (i = 1; i <= loopTo4; i++)
//                {
//                    max_item = i;
//                    max_value = lv_list[i];
//                    var loopTo5 = (short)Information.UBound(list);
//                    for (j = (short)(i + 1); j <= loopTo5; j++)
//                    {
//                        if (lv_list[j] > max_value)
//                        {
//                            max_item = j;
//                            max_value = lv_list[j];
//                        }
//                    }

//                    if (max_item != i)
//                    {
//                        buf = list[i];
//                        list[i] = list[max_item];
//                        list[max_item] = buf;
//                        buf = GUI.ListItemID[i];
//                        GUI.ListItemID[i] = GUI.ListItemID[max_item];
//                        GUI.ListItemID[max_item] = buf;
//                        lv_list[max_item] = lv_list[i];
//                    }
//                }
//            }

//            if (Information.UBound(list) > 0)
//            {
//                do
//                {
//                    string argoname1 = "等身大基準";
//                    if (Expression.IsOptionDefined(ref argoname1))
//                    {
//                        ret = GUI.MultiSelectListBox("出撃ユニット選択", ref list, "ユニット                                            Lv", unum);
//                    }
//                    else
//                    {
//                        ret = GUI.MultiSelectListBox("出撃ユニット選択", ref list, "ユニット                            パイロット       Lv", unum);
//                    }

//                    if (ret == 0)
//                    {
//                        Commands.CommandState = "ユニット選択";
//                        GUI.UnlockGUI();
//                        Commands.ViewMode = true;
//                        while (Commands.ViewMode)
//                        {
//                            GUI.Sleep(50);
//                            Application.DoEvents();
//                        }

//                        GUI.LockGUI();
//                        goto Beginning;
//                    }
//                }
//                while (ret == 0);
//                if (Strings.InStr(opt, "非同期") > 0)
//                {
//                    GUI.Center(ux, uy);
//                    GUI.RefreshScreen();
//                }

//                var loopTo6 = (short)Information.UBound(list);
//                for (i = 1; i <= loopTo6; i++)
//                {
//                    if (GUI.ListItemFlag[i])
//                    {
//                        var tmp1 = GUI.ListItemID;
//                        object argIndex1 = tmp1[i];
//                        {
//                            var withBlock1 = SRC.UList.Item(ref argIndex1);
//                            withBlock1.UsedAction = 0;
//                            withBlock1.UsedSupportAttack = 0;
//                            withBlock1.UsedSupportGuard = 0;
//                            withBlock1.UsedSyncAttack = 0;
//                            withBlock1.UsedCounterAttack = 0;
//                            withBlock1.StandBy(ux, uy, opt);
//                        }
//                    }
//                }
//            }

//            SRC.UList.CheckAutoHyperMode();
//            GUI.ListItemID = new string[1];
//            ExecOrganizeCmdRet = LineNum + 1;
//            return ExecOrganizeCmdRet;
//        }

//        private int ExecOvalCmd()
//        {
//            int ExecOvalCmdRet = default;
//            PictureBox pic, pic2 = default;
//            short y1, x1, rad;
//            double oval_ratio;
//            string opt;
//            string cname;
//            int clr;
//            short i;
//            if ((int)ArgNum < 5)
//            {
//                Event_Renamed.EventErrorMessage = "Ovalコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 363804


//                Input:
//                            Error(0)

//                 */
//            }

//            x1 = (short)(GetArgAsLong(2) + Event_Renamed.BaseX);
//            y1 = (short)(GetArgAsLong(3) + Event_Renamed.BaseY);
//            rad = (short)GetArgAsLong(4);
//            oval_ratio = GetArgAsDouble(5);
//            GUI.SaveScreen();

//            // 描画先
//            switch (Event_Renamed.ObjDrawOption ?? "")
//            {
//                case "背景":
//                    {
//                        pic = GUI.MainForm.picBack;
//                        pic2 = GUI.MainForm.picMaskedBack;
//                        Map.IsMapDirty = true;
//                        break;
//                    }

//                case "保持":
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        pic2 = GUI.MainForm.picMain(1);
//                        GUI.IsPictureVisible = true;
//                        break;
//                    }

//                default:
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        break;
//                    }
//            }

//            // 描画領域
//            short tmp;
//            if (Event_Renamed.ObjDrawOption != "背景")
//            {
//                GUI.IsPictureVisible = true;
//                tmp = (short)(rad + Event_Renamed.ObjDrawWidth - 1);
//                GUI.PaintedAreaX1 = (short)GeneralLib.MinLng(GUI.PaintedAreaX1, GeneralLib.MaxLng(x1 - tmp, 0));
//                GUI.PaintedAreaY1 = (short)GeneralLib.MinLng(GUI.PaintedAreaY1, GeneralLib.MaxLng(y1 - tmp, 0));
//                GUI.PaintedAreaX2 = (short)GeneralLib.MaxLng(GUI.PaintedAreaX2, GeneralLib.MinLng(x1 + tmp, GUI.MapPWidth - 1));
//                GUI.PaintedAreaY2 = (short)GeneralLib.MaxLng(GUI.PaintedAreaY2, GeneralLib.MinLng(y1 + tmp, GUI.MapPHeight - 1));
//            }

//            clr = Event_Renamed.ObjColor;
//            var loopTo = ArgNum;
//            for (i = (short)6; i <= loopTo; i++)
//            {
//                opt = GetArgAsString(i);
//                if (Strings.Asc(opt) == 35) // #
//                {
//                    if (Strings.Len(opt) != 7)
//                    {
//                        Event_Renamed.EventErrorMessage = "色指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 366731


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                    StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                    var midTmp = Strings.Mid(opt, 6, 2);
//                    StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                    var midTmp1 = Strings.Mid(opt, 4, 2);
//                    StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                    var midTmp2 = Strings.Mid(opt, 2, 2);
//                    StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                    if (!Information.IsNumeric(cname))
//                    {
//                        Event_Renamed.EventErrorMessage = "色指定が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 367241


//                        Input:
//                                            Error(0)

//                         */
//                    }

//                    clr = Conversions.ToInteger(cname);
//                }
//                else
//                {
//                    Event_Renamed.EventErrorMessage = "Ovalコマンドに不正なオプション「" + opt + "」が使われています";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 367395


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }
//            pic.DrawWidth = Event_Renamed.ObjDrawWidth;
//            pic.FillColor = Event_Renamed.ObjFillColor;
//            pic.FillStyle = Event_Renamed.ObjFillStyle;

//            pic.Circle(x1, y1);/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//            pic.DrawWidth = 1;
//            pic.FillColor = ColorTranslator.ToOle(Color.White);
//            pic.FillStyle = vbFSTransparent;
//            if (pic2 is object)
//            {
//                pic.DrawWidth = Event_Renamed.ObjDrawWidth;
//                pic.FillColor = Event_Renamed.ObjFillColor;
//                pic.FillStyle = Event_Renamed.ObjFillStyle;

//                pic.Circle(x1, y1);/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//                pic.DrawWidth = 1;
//                pic.FillColor = ColorTranslator.ToOle(Color.White);
//                pic.FillStyle = vbFSTransparent;
//            }

//            ExecOvalCmdRet = LineNum + 1;
//            return ExecOvalCmdRet;
//        }

//        private int ExecPaintPictureCmd()
//        {
//            int ExecPaintPictureCmdRet = default;
//            string fname;
//            int dx, dy;
//            int dw, dh;
//            int sx, sy;
//            int sw, sh;
//            short i, opt_n;
//            short ret;
//            string buf, options = default;
//            string cname;
//            int tcolor;
//            if ((int)ArgNum < 4)
//            {
//                Event_Renamed.EventErrorMessage = "PaintPictureコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 371870


//                Input:
//                            Error(0)

//                 */
//            }

//            tcolor = ColorTranslator.ToOle(Color.White);
//            i = 5;
//            opt_n = 4;
//            while (i <= ArgNum)
//            {
//                buf = GetArgAsString(i);
//                switch (buf ?? "")
//                {
//                    case "透過":
//                    case "背景":
//                    case "白黒":
//                    case "セピア":
//                    case "明":
//                    case "暗":
//                    case "上下反転":
//                    case "左右反転":
//                    case "上半分":
//                    case "下半分":
//                    case "右半分":
//                    case "左半分":
//                    case "右上":
//                    case "左上":
//                    case "右下":
//                    case "左下":
//                    case "ネガポジ反転":
//                    case "シルエット":
//                    case "夕焼け":
//                    case "水中":
//                    case "保持":
//                    case "フィルタ":
//                        {
//                            options = options + buf + " ";
//                            break;
//                        }

//                    case "右回転":
//                        {
//                            i = (short)((int)i + 1);
//                            options = options + "右回転 " + GetArgAsString(i) + " ";
//                            break;
//                        }

//                    case "左回転":
//                        {
//                            i = (short)((int)i + 1);
//                            options = options + "左回転 " + GetArgAsString(i) + " ";
//                            break;
//                        }

//                    case "-":
//                        {
//                            // スキップ
//                            // スキップ
//                            opt_n = i;
//                            break;
//                        }

//                    case var @case when @case == "":
//                        {
//                            break;
//                        }

//                    default:
//                        {
//                            if (Strings.Asc(buf) == 35 & Strings.Len(buf) == 7)
//                            {
//                                cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                                StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                                var midTmp = Strings.Mid(buf, 6, 2);
//                                StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                                var midTmp1 = Strings.Mid(buf, 4, 2);
//                                StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                                var midTmp2 = Strings.Mid(buf, 2, 2);
//                                StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                                if (Information.IsNumeric(cname))
//                                {
//                                    tcolor = Conversions.ToInteger(cname);
//                                    if (tcolor != ColorTranslator.ToOle(Color.White) | GetArgAsString((short)((int)i - 1)) == "フィルタ")
//                                    {
//                                        options = options + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)tcolor) + " ";
//                                    }
//                                }
//                            }
//                            else if (Information.IsNumeric(buf))
//                            {
//                                // スキップ
//                                opt_n = i;
//                            }
//                            else if (Strings.InStr(buf, " ") > 0)
//                            {
//                                options = options + buf + " ";
//                            }
//                            else if (Strings.Right(buf, 1) == "%" & Information.IsNumeric(Strings.Left(buf, Strings.Len(buf) - 1)))
//                            {
//                                options = options + buf + " ";
//                            }
//                            else
//                            {
//                                Event_Renamed.EventErrorMessage = "PaintPictureコマンドの" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)i) + "番目のパラメータ「" + buf + "」が不正です";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 374062


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            break;
//                        }
//                }

//                i = (short)((int)i + 1);
//            }

//            fname = GetArgAsString(2);
//            switch (Strings.Right(Strings.LCase(fname), 4) ?? "")
//            {
//                // 正しい画像ファイル名
//                case ".bmp":
//                case ".jpg":
//                case ".gif":
//                case ".png":
//                    {
//                        break;
//                    }

//                default:
//                    {
//                        bool localIsDefined() { object argIndex1 = (object)fname; var ret = SRC.NPDList.IsDefined(ref argIndex1); return ret; }

//                        bool localIsDefined1() { object argIndex1 = (object)fname; var ret = SRC.UDList.IsDefined(ref argIndex1); return ret; }

//                        object argIndex1 = (object)fname;
//                        if (SRC.PDList.IsDefined(ref argIndex1))
//                        {
//                            PilotData localItem() { object argIndex1 = (object)fname; var ret = SRC.PDList.Item(ref argIndex1); return ret; }

//                            fname = @"Pilot\" + localItem().Bitmap;
//                        }
//                        else if (localIsDefined())
//                        {
//                            NonPilotData localItem1() { object argIndex1 = (object)fname; var ret = SRC.NPDList.Item(ref argIndex1); return ret; }

//                            fname = @"Pilot\" + localItem1().Bitmap;
//                        }
//                        else if (localIsDefined1())
//                        {
//                            UnitData localItem2() { object argIndex1 = (object)fname; var ret = SRC.UDList.Item(ref argIndex1); return ret; }

//                            fname = @"Unit\" + localItem2().Bitmap;
//                        }
//                        else
//                        {
//                            Event_Renamed.EventErrorMessage = "不正な画像ファイル名「" + fname + "」が指定されています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 374845


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        break;
//                    }
//            }

//            // 描画先の画像
//            buf = GetArgAsString(3);
//            if (buf == "-")
//            {
//                dx = SRC.DEFAULT_LEVEL;
//            }
//            else
//            {
//                dx = GeneralLib.StrToLng(ref buf) + Event_Renamed.BaseX;
//            }

//            buf = GetArgAsString(4);
//            if (buf == "-")
//            {
//                dy = SRC.DEFAULT_LEVEL;
//            }
//            else
//            {
//                dy = GeneralLib.StrToLng(ref buf) + Event_Renamed.BaseY;
//            }

//            // 描画サイズ
//            if (opt_n >= 6)
//            {
//                buf = GetArgAsString(5);
//                if (buf == "-")
//                {
//                    dw = SRC.DEFAULT_LEVEL;
//                }
//                else
//                {
//                    dw = GeneralLib.StrToLng(ref buf);
//                    if (dw <= 0)
//                    {
//                        ExecPaintPictureCmdRet = LineNum + 1;
//                        return ExecPaintPictureCmdRet;
//                    }
//                }

//                buf = GetArgAsString(6);
//                if (buf == "-")
//                {
//                    dh = SRC.DEFAULT_LEVEL;
//                }
//                else
//                {
//                    dh = GeneralLib.StrToLng(ref buf);
//                    if (dh <= 0)
//                    {
//                        ExecPaintPictureCmdRet = LineNum + 1;
//                        return ExecPaintPictureCmdRet;
//                    }
//                }
//            }
//            else
//            {
//                dw = SRC.DEFAULT_LEVEL;
//                dh = SRC.DEFAULT_LEVEL;
//            }

//            // 原画像における転送元座標＆サイズ
//            if (opt_n == 10)
//            {
//                buf = GetArgAsString(7);
//                if (buf == "-")
//                {
//                    sx = SRC.DEFAULT_LEVEL;
//                }
//                else
//                {
//                    sx = GeneralLib.StrToLng(ref buf);
//                }

//                buf = GetArgAsString(8);
//                if (buf == "-")
//                {
//                    sy = SRC.DEFAULT_LEVEL;
//                }
//                else
//                {
//                    sy = GeneralLib.StrToLng(ref buf);
//                }

//                sw = GetArgAsLong(9);
//                sh = GetArgAsLong(10);
//            }
//            else
//            {
//                sx = 0;
//                sy = 0;
//                sw = 0;
//                sh = 0;
//            }

//            ret = Conversions.ToShort(GUI.DrawPicture(ref fname, dx, dy, dw, dh, sx, sy, sw, sh, ref options));
//            ExecPaintPictureCmdRet = LineNum + 1;
//            return ExecPaintPictureCmdRet;
//        }

//        private int ExecPaintStringCmd()
//        {
//            int ExecPaintStringCmdRet = default;
//            string sx, sy;
//            short xx, yy;
//            var without_cr = default(bool);
//            if (CmdName != Event_Renamed.CmdType.PaintStringCmd)
//            {
//                without_cr = true;
//            }

//            // PaintStringはあらかじめ構文解析済み
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        // 座標指定がないことが確定
//                        // MOD START マージ
//                        // DrawString GetArgAsString(2), -1, -1, without_cr
//                        string argmsg = GetArgAsString(2);
//                        GUI.DrawString(ref argmsg, SRC.DEFAULT_LEVEL, SRC.DEFAULT_LEVEL, without_cr);
//                        break;
//                    }
//                // MOD END マージ
//                case 4:
//                    {
//                        // 座標指定付きであることが確定
//                        sx = GetArgAsString(2);
//                        sy = GetArgAsString(3);
//                        if (sx == "-")
//                        {
//                            GUI.HCentering = true;
//                            xx = -1;
//                        }
//                        else
//                        {
//                            GUI.HCentering = false;
//                            xx = (short)(Conversions.ToShort(sx) + Event_Renamed.BaseX);
//                        }

//                        if (sy == "-")
//                        {
//                            GUI.VCentering = true;
//                            yy = -1;
//                        }
//                        else
//                        {
//                            GUI.VCentering = false;
//                            yy = (short)(Conversions.ToShort(sy) + Event_Renamed.BaseY);
//                        }

//                        string argmsg1 = GetArgAsString(4);
//                        GUI.DrawString(ref argmsg1, xx, yy, without_cr);
//                        break;
//                    }

//                case 5:
//                    {
//                        // 座標指定付きかどうか実行時まで不明
//                        sx = GetArgAsString(2);
//                        sy = GetArgAsString(3);

//                        // 最初の2引数が有効な座標指定かどうかで判断する
//                        if ((Information.IsNumeric(sx) | sx == "-") & (Information.IsNumeric(sy) | sy == "-"))
//                        {
//                            if (sx == "-")
//                            {
//                                GUI.HCentering = true;
//                                xx = -1;
//                            }
//                            else
//                            {
//                                GUI.HCentering = false;
//                                xx = (short)(Conversions.ToShort(sx) + Event_Renamed.BaseX);
//                            }

//                            if (sy == "-")
//                            {
//                                GUI.VCentering = true;
//                                yy = -1;
//                            }
//                            else
//                            {
//                                GUI.VCentering = false;
//                                yy = (short)(Conversions.ToShort(sy) + Event_Renamed.BaseY);
//                            }

//                            string argmsg2 = GetArgAsString(4);
//                            GUI.DrawString(ref argmsg2, xx, yy, without_cr);
//                        }
//                        else
//                        {
//                            string argmsg3 = GetArgAsString(5);
//                            GUI.DrawString(ref argmsg3, -1, -1, without_cr);
//                        }

//                        break;
//                    }
//            }

//            ExecPaintStringCmdRet = LineNum + 1;
//            return ExecPaintStringCmdRet;
//        }

//        private int ExecPaintSysStringCmd()
//        {
//            int ExecPaintSysStringCmdRet = default;
//            var without_refresh = default(bool);
//            if ((int)ArgNum != 4 & (int)ArgNum != 5)
//            {
//                Event_Renamed.EventErrorMessage = "PaintSysStringコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 378997


//                Input:
//                            Error(0)

//                 */
//            }

//            if (ArgNum == 5)
//            {
//                if (GetArgAsString(5) == "非同期")
//                {
//                    without_refresh = true;
//                }
//            }

//            string argmsg = GetArgAsString(4);
//            GUI.DrawSysString((short)GetArgAsLong(2), (short)GetArgAsLong(3), ref argmsg, without_refresh);
//            ExecPaintSysStringCmdRet = LineNum + 1;
//            return ExecPaintSysStringCmdRet;
//        }

//        private int ExecPilotCmd()
//        {
//            int ExecPilotCmdRet = default;
//            string pname;
//            short plevel;
//            if ((int)ArgNum < 0)
//            {
//                Event_Renamed.EventErrorMessage = "Pilotコマンドのパラメータの括弧の対応が取れていません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 379529


//                Input:
//                            Error(0)

//                 */
//            }
//            else if ((int)ArgNum != 3 & (int)ArgNum != 4)
//            {
//                Event_Renamed.EventErrorMessage = "Pilotコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 379668


//                Input:
//                            Error(0)

//                 */
//            }

//            pname = GetArgAsString(2);
//            bool localIsDefined() { object argIndex1 = pname; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined())
//            {
//                Event_Renamed.EventErrorMessage = "指定したパイロット「" + pname + "」のデータが見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 379879


//                Input:
//                            Error(0)

//                 */
//            }

//            plevel = (short)GetArgAsLong(3);
//            string argoname = "レベル限界突破";
//            if (Expression.IsOptionDefined(ref argoname))
//            {
//                if (plevel > 999)
//                {
//                    plevel = 999;
//                }
//            }
//            else if (plevel > 99)
//            {
//                plevel = 99;
//            }

//            if (plevel < 1)
//            {
//                plevel = 1;
//            }

//            if (ArgNum == 3)
//            {
//                string argpparty = "味方";
//                string arggid = "";
//                {
//                    var withBlock = SRC.PList.Add(ref pname, plevel, ref argpparty, gid: ref arggid);
//                    withBlock.FullRecover();
//                }
//            }
//            else
//            {
//                string argpparty1 = "味方";
//                string arggid1 = GetArgAsString(4);
//                {
//                    var withBlock1 = SRC.PList.Add(ref pname, plevel, ref argpparty1, ref arggid1);
//                    withBlock1.FullRecover();
//                }
//            }

//            ExecPilotCmdRet = LineNum + 1;
//            return ExecPilotCmdRet;
//        }

//        private int ExecPlayMIDICmd()
//        {
//            int ExecPlayMIDICmdRet = default;
//            var fname = default(string);
//            int play_bgm_end;
//            int i;

//            // PlayMIDIコマンドが連続してる場合、最後のPlayMIDIコマンドの位置を検索
//            var loopTo = Information.UBound(Event_Renamed.EventCmd);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                if (Event_Renamed.EventCmd[i].Name != Event_Renamed.CmdType.PlayMIDICmd)
//                {
//                    break;
//                }
//            }

//            play_bgm_end = i - 1;

//            // 最後のSPlayMIDIから順にMIDIファイルを検索
//            var loopTo1 = LineNum;
//            for (i = play_bgm_end; i >= loopTo1; i -= 1)
//            {
//                fname = GeneralLib.ListTail(ref Event_Renamed.EventData[i], 2);
//                if (GeneralLib.ListLength(ref fname) == 1)
//                {
//                    if (Strings.Left(fname, 2) == "$(")
//                    {
//                        fname = "\"" + fname + "\"";
//                    }

//                    fname = Expression.GetValueAsString(ref fname, true);
//                }
//                else
//                {
//                    fname = "(" + fname + ")";
//                }

//                fname = Sound.SearchMidiFile(ref fname);
//                if (!string.IsNullOrEmpty(fname))
//                {
//                    // MIDIファイルが存在したので選択
//                    break;
//                }
//            }

//            // MIDIファイルを再生
//            Sound.KeepBGM = false;
//            Sound.BossBGM = false;
//            Sound.StartBGM(ref fname, false);

//            // 次のコマンド実行位置は最後のPlayMIDIコマンドの後
//            ExecPlayMIDICmdRet = play_bgm_end + 1;
//            return ExecPlayMIDICmdRet;
//        }

//        private int ExecPlaySoundCmd()
//        {
//            int ExecPlaySoundCmdRet = default;
//            string fname;
//            fname = GeneralLib.ListTail(ref Event_Renamed.EventData[LineNum], 2);
//            if (GeneralLib.ListLength(ref fname) == 1)
//            {
//                fname = Expression.GetValueAsString(ref fname);
//            }

//            Sound.PlayWave(ref fname);
//            ExecPlaySoundCmdRet = LineNum + 1;
//            return ExecPlaySoundCmdRet;
//        }

//        private int ExecPolygonCmd()
//        {
//            int ExecPolygonCmdRet = default;
//            PictureBox pic, pic2 = default;
//            var points = default(GUI.POINTAPI[]);
//            short pnum;
//            short xx, yy;
//            short x1, y1;
//            short x2, y2;
//            int prev_clr;
//            x1 = GUI.MainPWidth;
//            y1 = GUI.MainPHeight;
//            x2 = 0;
//            y2 = 0;
//            pnum = 1;
//            while (2 * pnum < ArgNum)
//            {
//                Array.Resize(ref points, pnum);
//                xx = (short)(GetArgAsLong((short)(2 * pnum)) + Event_Renamed.BaseX);
//                yy = (short)(GetArgAsLong((short)(2 * pnum + 1)) + Event_Renamed.BaseY);
//                points[pnum - 1].X = xx;
//                points[pnum - 1].Y = yy;
//                if (xx < x1)
//                {
//                    x1 = xx;
//                }

//                if (xx > x2)
//                {
//                    x2 = xx;
//                }

//                if (yy < y1)
//                {
//                    y1 = yy;
//                }

//                if (yy > y2)
//                {
//                    y2 = yy;
//                }

//                pnum = (short)(pnum + 1);
//            }

//            if ((int)pnum == 1)
//            {
//                Event_Renamed.EventErrorMessage = "頂点数が少なすぎます";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 383198


//                Input:
//                            Error(0)

//                 */
//            }

//            GUI.SaveScreen();

//            // 描画先
//            switch (Event_Renamed.ObjDrawOption ?? "")
//            {
//                case "背景":
//                    {
//                        pic = GUI.MainForm.picBack;
//                        pic2 = GUI.MainForm.picMaskedBack;
//                        Map.IsMapDirty = true;
//                        break;
//                    }

//                case "保持":
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        pic2 = GUI.MainForm.picMain(1);
//                        break;
//                    }

//                default:
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        break;
//                    }
//            }

//            // 描画領域
//            short tmp;
//            if (Event_Renamed.ObjDrawOption != "背景")
//            {
//                GUI.IsPictureVisible = true;
//                tmp = (short)(Event_Renamed.ObjDrawWidth - 1);
//                GUI.PaintedAreaX1 = (short)GeneralLib.MinLng(GUI.PaintedAreaX1, GeneralLib.MaxLng(x1 - tmp, 0));
//                GUI.PaintedAreaY1 = (short)GeneralLib.MinLng(GUI.PaintedAreaY1, GeneralLib.MaxLng(y1 - tmp, 0));
//                GUI.PaintedAreaX2 = (short)GeneralLib.MaxLng(GUI.PaintedAreaX2, GeneralLib.MinLng(x2 + tmp, GUI.MapPWidth - 1));
//                GUI.PaintedAreaY2 = (short)GeneralLib.MaxLng(GUI.PaintedAreaY2, GeneralLib.MinLng(y2 + tmp, GUI.MapPHeight - 1));
//            }

//            prev_clr = ColorTranslator.ToOle(pic.ForeColor);
//            pic.ForeColor = ColorTranslator.FromOle(Event_Renamed.ObjColor);
//            pic.DrawWidth = Event_Renamed.ObjDrawWidth;
//            pic.FillColor = Event_Renamed.ObjFillColor;
//            pic.FillStyle = Event_Renamed.ObjFillStyle;

//            GUI.Polygon(pic.hDC, ref points[0], (int)pnum - 1);
//            pic.ForeColor = ColorTranslator.FromOle(prev_clr);
//            pic.DrawWidth = 1;
//            pic.FillColor = ColorTranslator.ToOle(Color.White);
//            pic.FillStyle = vbFSTransparent;
//            if (pic2 is object)
//            {
//                prev_clr = ColorTranslator.ToOle(pic2.ForeColor);
//                pic2.ForeColor = ColorTranslator.FromOle(Event_Renamed.ObjColor);
//                pic2.DrawWidth = Event_Renamed.ObjDrawWidth;
//                pic2.FillColor = Event_Renamed.ObjFillColor;
//                pic2.FillStyle = Event_Renamed.ObjFillStyle;

//                GUI.Polygon(pic2.hDC, ref points[0], (int)pnum - 1);
//                pic2.ForeColor = ColorTranslator.FromOle(prev_clr);
//                pic2.DrawWidth = 1;
//                pic2.FillColor = ColorTranslator.ToOle(Color.White);
//                pic2.FillStyle = vbFSTransparent;
//            }

//            ExecPolygonCmdRet = LineNum + 1;
//            return ExecPolygonCmdRet;
//        }

//        private int ExecPrintCmd()
//        {
//            int ExecPrintCmdRet = default;
//            short f;
//            string msg;
//            if ((int)ArgNum == 1)
//            {
//                Event_Renamed.EventErrorMessage = "Printコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 390280


//                Input:
//                            Error(0)

//                 */
//            }

//            f = (short)GetArgAsLong(2);
//            msg = GeneralLib.ListTail(ref Event_Renamed.EventData[LineNum], 3);
//            if (Strings.Right(msg, 1) != ";")
//            {
//                if (Strings.Left(msg, 1) != "`" | Strings.Right(msg, 1) != "`")
//                {
//                    if (Strings.Left(msg, 2) == "$(")
//                    {
//                        if (Strings.Right(msg, 1) == ")")
//                        {
//                            string argexpr = Strings.Mid(msg, 3, Strings.Len(msg) - 3);
//                            msg = Expression.GetValueAsString(ref argexpr);
//                        }
//                    }
//                    else if (GeneralLib.ListLength(ref msg) == 1)
//                    {
//                        msg = Expression.GetValueAsString(ref msg);
//                    }

//                    Expression.ReplaceSubExpression(ref msg);
//                }
//                else
//                {
//                    msg = Strings.Mid(msg, 2, Strings.Len(msg) - 2);
//                }

//                FileSystem.PrintLine(f, msg);
//            }
//            else
//            {
//                msg = Strings.Left(msg, Strings.Len(msg) - 1);
//                if (Strings.Left(msg, 1) != "`" | Strings.Right(msg, 1) != "`")
//                {
//                    if (Strings.Left(msg, 2) == "$(")
//                    {
//                        if (Strings.Right(msg, 1) == ")")
//                        {
//                            string argexpr1 = Strings.Mid(msg, 3, Strings.Len(msg) - 3);
//                            msg = Expression.GetValueAsString(ref argexpr1);
//                        }
//                    }
//                    else if (GeneralLib.ListLength(ref msg) == 1)
//                    {
//                        msg = Expression.GetValueAsString(ref msg);
//                    }

//                    Expression.ReplaceSubExpression(ref msg);
//                }
//                else
//                {
//                    msg = Strings.Mid(msg, 2, Strings.Len(msg) - 2);
//                }

//                FileSystem.Print(f, msg);
//            }

//            ExecPrintCmdRet = LineNum + 1;
//            return ExecPrintCmdRet;
//        }

//        private int ExecPSetCmd()
//        {
//            int ExecPSetCmdRet = default;
//            PictureBox pic, pic2 = default;
//            short xx, yy;
//            string opt;
//            string cname;
//            int clr;
//            if ((int)ArgNum < 3)
//            {
//                Event_Renamed.EventErrorMessage = "PSetコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 392694


//                Input:
//                            Error(0)

//                 */
//            }

//            // 座標
//            xx = (short)(GetArgAsLong(2) + Event_Renamed.BaseX);
//            yy = (short)(GetArgAsLong(3) + Event_Renamed.BaseY);

//            // 座標は画面上にある？
//            if (xx < 0 | GUI.MapPWidth <= xx | yy < 0 | GUI.MapPHeight <= yy)
//            {
//                ExecPSetCmdRet = LineNum + 1;
//                return ExecPSetCmdRet;
//            }

//            GUI.SaveScreen();

//            // 描画先
//            switch (Event_Renamed.ObjDrawOption ?? "")
//            {
//                case "背景":
//                    {
//                        pic = GUI.MainForm.picBack;
//                        pic2 = GUI.MainForm.picMaskedBack;
//                        Map.IsMapDirty = true;
//                        break;
//                    }

//                case "保持":
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        pic2 = GUI.MainForm.picMain(1);
//                        break;
//                    }

//                default:
//                    {
//                        pic = GUI.MainForm.picMain(0);
//                        break;
//                    }
//            }

//            // 描画領域
//            short tmp;
//            if (Event_Renamed.ObjDrawOption != "背景")
//            {
//                GUI.IsPictureVisible = true;
//                tmp = (short)(Event_Renamed.ObjDrawWidth - 1);
//                if ((short)(xx - tmp) < GUI.PaintedAreaX1)
//                {
//                    GUI.PaintedAreaX1 = (short)(xx - tmp);
//                }
//                else if ((short)(xx + tmp) > GUI.PaintedAreaX2)
//                {
//                    GUI.PaintedAreaX2 = (short)(xx + tmp);
//                }

//                if ((short)(yy - tmp) < GUI.PaintedAreaY1)
//                {
//                    GUI.PaintedAreaY1 = (short)(yy - tmp);
//                }
//                else if ((short)(yy + tmp) > GUI.PaintedAreaY2)
//                {
//                    GUI.PaintedAreaY2 = (short)(yy + tmp);
//                }
//            }

//            // 描画色
//            if ((int)ArgNum == 4)
//            {
//                opt = GetArgAsString((short)4);
//                if (Strings.Asc(opt) != 35 | Strings.Len(opt) != 7)
//                {
//                    Event_Renamed.EventErrorMessage = "色指定が不正です";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 395407


//                    Input:
//                                    Error(0)

//                     */
//                }

//                cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                var midTmp = Strings.Mid(opt, 6, 2);
//                StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                var midTmp1 = Strings.Mid(opt, 4, 2);
//                StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                var midTmp2 = Strings.Mid(opt, 2, 2);
//                StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                if (!Information.IsNumeric(cname))
//                {
//                    Event_Renamed.EventErrorMessage = "色指定が不正です";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 395908


//                    Input:
//                                    Error(0)

//                     */
//                }

//                clr = Conversions.ToInteger(cname);
//            }
//            else
//            {
//                clr = Event_Renamed.ObjColor;
//            }

//            pic.DrawWidth = Event_Renamed.ObjDrawWidth;

//            // 点を描画
//            pic.PSet(xx, yy);/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */

//            pic.DrawWidth = 1;
//            if (pic2 is object)
//            {
//                pic2.DrawWidth = Event_Renamed.ObjDrawWidth;

//                // 点を描画
//                pic2.PSet(xx, yy);/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */

//                pic2.DrawWidth = 1;
//            }

//            ExecPSetCmdRet = LineNum + 1;
//            return ExecPSetCmdRet;
//        }

//        private int ExecQuestionCmd()
//        {
//            int ExecQuestionCmdRet = default;
//            string[] list;
//            int i;
//            string buf;
//            list = new string[1];
//            GUI.ListItemID = new string[1];
//            GUI.ListItemFlag = new bool[1];
//            GUI.ListItemID[0] = "0";
//            var loopTo = Information.UBound(Event_Renamed.EventData);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                buf = Event_Renamed.EventData[i];
//                Expression.FormatMessage(ref buf);
//                if (Strings.Len(buf) > 0)
//                {
//                    if (Strings.LCase(buf) == "end")
//                    {
//                        break;
//                    }

//                    Array.Resize(ref list, Information.UBound(list) + 1 + 1);
//                    Array.Resize(ref GUI.ListItemID, Information.UBound(list) + 1);
//                    Array.Resize(ref GUI.ListItemFlag, Information.UBound(list) + 1);
//                    list[Information.UBound(list)] = buf;
//                    GUI.ListItemID[Information.UBound(list)] = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(i - LineNum);
//                    GUI.ListItemFlag[Information.UBound(list)] = false;
//                }
//            }

//            if (i == Information.UBound(Event_Renamed.EventData))
//            {
//                Event_Renamed.EventErrorMessage = "QuestionとEndが対応していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 399008


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Information.UBound(list) > 0)
//            {
//                switch (ArgNum)
//                {
//                    case 3:
//                        {
//                            string arglb_caption = "選択";
//                            string arglb_info = GetArgAsString((short)3);
//                            Commands.SelectedItem = GUI.LIPS(ref arglb_caption, ref list, ref arglb_info, (short)GetArgAsLong((short)2));
//                            break;
//                        }

//                    case 2:
//                        {
//                            string arglb_caption1 = "選択";
//                            string arglb_info1 = "さあ、どうする？";
//                            Commands.SelectedItem = GUI.LIPS(ref arglb_caption1, ref list, ref arglb_info1, (short)GetArgAsLong((short)2));
//                            break;
//                        }

//                    default:
//                        {
//                            Event_Renamed.EventErrorMessage = "Questionコマンドの引数の数が違います";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 399492


//                            Input:
//                                                Error(0)

//                             */
//                            break;
//                        }
//                }
//            }
//            else
//            {
//                Commands.SelectedItem = (short)0;
//            }

//            Event_Renamed.SelectedAlternative = GUI.ListItemID[Commands.SelectedItem];
//            GUI.ListItemID = new string[1];
//            ExecQuestionCmdRet = i + 1;
//            return ExecQuestionCmdRet;
//        }

//        private int ExecQuickLoadCmd()
//        {
//            int ExecQuickLoadCmdRet = default;
//            GUI.LockGUI();
//            Status.ClearUnitStatus();
//            Sound.StopBGM();
//            if (GeneralLib.FileExists(ref SRC.LastSaveDataFileName))
//            {
//                // セーブしたファイルが存在すればそれをロード
//                bool argquick_load = true;
//                SRC.RestoreData(ref SRC.LastSaveDataFileName, ref argquick_load);
//            }
//            else
//            {
//                // セーブファイルが見つからなければ強制終了
//                string argmsg = "セーブデータが見つかりません";
//                GUI.ErrorMessage(ref argmsg);
//                SRC.TerminateSRC();
//            }

//            // 詰まないように乱数系列をリセット
//            GeneralLib.RndSeed = GeneralLib.RndSeed + 1;
//            GeneralLib.RndReset();

//            // 再開イベントによるマップ画像の書き換え処理を行う
//            Event_Renamed.HandleEvent("再開");
//            Map.IsMapDirty = false;

//            // 画面を書き直してステータスを表示
//            GUI.RedrawScreen();
//            Status.DisplayGlobalStatus();
//            GUI.MainForm.Show();

//            // 操作可能にする
//            Commands.CommandState = "ユニット選択";
//            GUI.UnlockGUI();
//            SRC.IsScenarioFinished = true;
//            ExecQuickLoadCmdRet = 0;
//            return ExecQuickLoadCmdRet;
//        }

//        private int ExecQuitCmd()
//        {
//            SRC.TerminateSRC();
//            return default;
//        }

//        private int ExecRankUpCmd()
//        {
//            int ExecRankUpCmdRet = default;
//            string uname;
//            Unit u;
//            short rk;
//            double hp_ratio, en_ratio;
//            short i, j;
//            string buf;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        uname = GetArgAsString((short)2);
//                        object argIndex1 = (object)uname;
//                        u = SRC.UList.Item(ref argIndex1);
//                        if (u is null)
//                        {
//                            Event_Renamed.EventErrorMessage = uname + "というユニットは存在しません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 401470


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        rk = (short)GetArgAsLong((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        rk = (short)GetArgAsLong((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "RankUpコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 401717


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            hp_ratio = 100 * u.HP / (double)u.MaxHP;
//            en_ratio = 100 * u.EN / (double)u.MaxEN;
//            u.Rank = (short)(u.Rank + rk);
//            u.HP = (int)(u.MaxHP * hp_ratio / 100d);
//            u.EN = (int)(u.MaxEN * en_ratio / 100d);
//            var loopTo = u.CountOtherForm();
//            for (i = 1; i <= loopTo; i++)
//            {
//                object argIndex2 = i;
//                {
//                    var withBlock = u.OtherForm(ref argIndex2);
//                    hp_ratio = 100 * withBlock.HP / (double)withBlock.MaxHP;
//                    en_ratio = 100 * withBlock.EN / (double)withBlock.MaxEN;
//                    withBlock.Rank = (short)(withBlock.Rank + rk);
//                    withBlock.HP = (int)(withBlock.MaxHP * hp_ratio / 100d);
//                    withBlock.EN = (int)(withBlock.MaxEN * en_ratio / 100d);
//                }
//            }

//            // 合体できる場合は他の分離ユニットのユニットランクを上げる
//            string argfname2 = "合体";
//            if (u.IsFeatureAvailable(ref argfname2))
//            {
//                // 合体後の形態を検索
//                var loopTo1 = u.CountFeature();
//                for (i = 1; i <= loopTo1; i++)
//                {
//                    object argIndex5 = i;
//                    if (u.Feature(ref argIndex5) == "合体")
//                    {
//                        string localFeatureData() { object argIndex1 = i; var ret = u.FeatureData(ref argIndex1); return ret; }

//                        string arglist = localFeatureData();
//                        buf = GeneralLib.LIndex(ref arglist, 2);
//                        string localFeatureData1() { object argIndex1 = i; var ret = u.FeatureData(ref argIndex1); return ret; }

//                        string arglist1 = localFeatureData1();
//                        if (GeneralLib.LLength(ref arglist1) == 3)
//                        {
//                            object argIndex3 = buf;
//                            if (SRC.UDList.IsDefined(ref argIndex3))
//                            {
//                                UnitData localItem() { object argIndex1 = buf; var ret = SRC.UDList.Item(ref argIndex1); return ret; }

//                                string argfname = "主形態";
//                                if (localItem().IsFeatureAvailable(ref argfname))
//                                {
//                                    break;
//                                }
//                            }
//                        }
//                        else
//                        {
//                            object argIndex4 = buf;
//                            if (SRC.UDList.IsDefined(ref argIndex4))
//                            {
//                                UnitData localItem1() { object argIndex1 = buf; var ret = SRC.UDList.Item(ref argIndex1); return ret; }

//                                string argfname1 = "制限時間";
//                                if (!localItem1().IsFeatureAvailable(ref argfname1))
//                                {
//                                    break;
//                                }
//                            }
//                        }
//                    }
//                }

//                if (i <= u.CountFeature())
//                {
//                    string localFeatureData2() { object argIndex1 = i; var ret = u.FeatureData(ref argIndex1); return ret; }

//                    string localLIndex() { string arglist = hs2a2f208e052147729d34e3cbaff37f7f(); var ret = GeneralLib.LIndex(ref arglist, 2); return ret; }

//                    UnitData localItem2() { object argIndex1 = (object)hse505f2f9d761474e89617a2bf6851fa7(); var ret = SRC.UDList.Item(ref argIndex1); return ret; }

//                    object argIndex6 = "分離";
//                    buf = localItem2().FeatureData(ref argIndex6);
//                    var loopTo2 = GeneralLib.LLength(ref buf);
//                    for (i = 2; i <= loopTo2; i++)
//                    {
//                        object argIndex9 = GeneralLib.LIndex(ref buf, i);
//                        if (SRC.UList.IsDefined(ref argIndex9))
//                        {
//                            object argIndex8 = GeneralLib.LIndex(ref buf, i);
//                            {
//                                var withBlock1 = SRC.UList.Item(ref argIndex8);
//                                if (!u.IsEqual(withBlock1.Name))
//                                {
//                                    // 他の分離形態のユニットランクを上げる
//                                    hp_ratio = 100 * withBlock1.HP / (double)withBlock1.MaxHP;
//                                    en_ratio = 100 * withBlock1.EN / (double)withBlock1.MaxEN;
//                                    withBlock1.Rank = (short)(withBlock1.Rank + rk);
//                                    withBlock1.HP = (int)(withBlock1.MaxHP * hp_ratio / 100d);
//                                    withBlock1.EN = (int)(withBlock1.MaxEN * en_ratio / 100d);
//                                    var loopTo3 = withBlock1.CountOtherForm();
//                                    for (j = 1; j <= loopTo3; j++)
//                                    {
//                                        object argIndex7 = j;
//                                        {
//                                            var withBlock2 = withBlock1.OtherForm(ref argIndex7);
//                                            hp_ratio = 100 * withBlock2.HP / (double)withBlock2.MaxHP;
//                                            en_ratio = 100 * withBlock2.EN / (double)withBlock2.MaxEN;
//                                            withBlock2.Rank = (short)(withBlock2.Rank + rk);
//                                            withBlock2.HP = (int)(withBlock2.MaxHP * hp_ratio / 100d);
//                                            withBlock2.EN = (int)(withBlock2.MaxEN * en_ratio / 100d);
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }

//            // 分離できる場合は分離ユニットのユニットランクを上げる
//            string argfname3 = "分離";
//            if (u.IsFeatureAvailable(ref argfname3))
//            {
//                object argIndex10 = "分離";
//                buf = u.FeatureData(ref argIndex10);
//                var loopTo4 = GeneralLib.LLength(ref buf);
//                for (i = 2; i <= loopTo4; i++)
//                {
//                    object argIndex13 = GeneralLib.LIndex(ref buf, i);
//                    if (SRC.UList.IsDefined(ref argIndex13))
//                    {
//                        object argIndex12 = GeneralLib.LIndex(ref buf, i);
//                        {
//                            var withBlock3 = SRC.UList.Item(ref argIndex12);
//                            withBlock3.Rank = (short)GeneralLib.MaxLng(withBlock3.Rank, u.Rank);
//                            withBlock3.HP = withBlock3.MaxHP;
//                            withBlock3.EN = withBlock3.MaxEN;
//                            var loopTo5 = withBlock3.CountOtherForm();
//                            for (j = 1; j <= loopTo5; j++)
//                            {
//                                object argIndex11 = j;
//                                {
//                                    var withBlock4 = withBlock3.OtherForm(ref argIndex11);
//                                    hp_ratio = 100 * withBlock4.HP / (double)withBlock4.MaxHP;
//                                    en_ratio = 100 * withBlock4.EN / (double)withBlock4.MaxEN;
//                                    withBlock4.Rank = (short)(withBlock4.Rank + rk);
//                                    withBlock4.HP = (int)(withBlock4.MaxHP * hp_ratio / 100d);
//                                    withBlock4.EN = (int)(withBlock4.MaxEN * en_ratio / 100d);
//                                }
//                            }
//                        }
//                    }
//                }
//            }

//            ExecRankUpCmdRet = LineNum + 1;
//            return ExecRankUpCmdRet;
//        }

//        private int ExecReadCmd()
//        {
//            int ExecReadCmdRet = default;
//            short f;
//            short i;
//            var buf = default(string);
//            if ((int)ArgNum < 3)
//            {
//                Event_Renamed.EventErrorMessage = "Readコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 405001


//                Input:
//                            Error(0)

//                 */
//            }

//            f = (short)GetArgAsLong(2);
//            var loopTo = ArgNum;
//            for (i = 3; i <= loopTo; i++)
//            {
//                FileSystem.Input(f, ref buf);
//                string argvname = GetArg(i);
//                Expression.SetVariableAsString(ref argvname, ref buf);
//            }

//            ExecReadCmdRet = LineNum + 1;
//            return ExecReadCmdRet;
//        }

//        private int ExecRecoverENCmd()
//        {
//            int ExecRecoverENCmdRet = default;
//            Unit u;
//            double per;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2, true);
//                        per = GetArgAsDouble((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        per = GetArgAsDouble((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "RecoverENコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 405679


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is object)
//            {
//                {
//                    var withBlock = u;
//                    withBlock.RecoverEN(per);
//                    withBlock.Update();
//                    if (withBlock.EN == 0 & withBlock.Status_Renamed == "出撃")
//                    {
//                        GUI.PaintUnitBitmap(ref u);
//                    }

//                    withBlock.CheckAutoHyperMode();
//                    withBlock.CheckAutoNormalMode();
//                }
//            }

//            ExecRecoverENCmdRet = LineNum + 1;
//            return ExecRecoverENCmdRet;
//        }

//        private int ExecRecoverHPCmd()
//        {
//            int ExecRecoverHPCmdRet = default;
//            Unit u;
//            double per;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2, true);
//                        per = GetArgAsDouble((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        per = GetArgAsDouble((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "RecoverHPコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 406435


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is object)
//            {
//                u.RecoverHP(per);
//                u.Update();
//                u.CheckAutoHyperMode();
//                u.CheckAutoNormalMode();
//            }

//            ExecRecoverHPCmdRet = LineNum + 1;
//            return ExecRecoverHPCmdRet;
//        }

//        private int ExecRecoverPlanaCmd()
//        {
//            int ExecRecoverPlanaCmdRet = default;
//            Pilot p;
//            double per;
//            double hp_ratio = default, en_ratio = default;

//            // UPGRADE_NOTE: オブジェクト p をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            p = null;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        p = GetArgAsPilot((short)2);
//                        per = GetArgAsDouble((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        {
//                            var withBlock = Event_Renamed.SelectedUnitForEvent;
//                            if ((int)withBlock.CountPilot() > 0)
//                            {
//                                p = withBlock.MainPilot();
//                            }
//                        }

//                        per = GetArgAsDouble((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "RecoverPlanaコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 407406


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecRecoverPlanaCmdRet = LineNum + 1;
//            if (p is null)
//            {
//                return ExecRecoverPlanaCmdRet;
//            }

//            if (p.MaxPlana() == 0)
//            {
//                return ExecRecoverPlanaCmdRet;
//            }

//            if (p.Unit_Renamed is object)
//            {
//                {
//                    var withBlock1 = p.Unit_Renamed;
//                    hp_ratio = 100 * withBlock1.HP / (double)withBlock1.MaxHP;
//                    en_ratio = 100 * withBlock1.EN / (double)withBlock1.MaxEN;
//                }
//            }

//            p.Plana = (int)(p.Plana + per * p.MaxPlana() / 100d);
//            if (p.Unit_Renamed is object)
//            {
//                {
//                    var withBlock2 = p.Unit_Renamed;
//                    withBlock2.HP = (int)(withBlock2.MaxHP * hp_ratio / 100d);
//                    withBlock2.EN = (int)(withBlock2.MaxEN * en_ratio / 100d);
//                }
//            }

//            return ExecRecoverPlanaCmdRet;
//        }

//        private int ExecRecoverSPCmd()
//        {
//            int ExecRecoverSPCmdRet = default;
//            Pilot p;
//            double per;

//            // UPGRADE_NOTE: オブジェクト p をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            p = null;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        p = GetArgAsPilot((short)2);
//                        per = GetArgAsDouble((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        {
//                            var withBlock = Event_Renamed.SelectedUnitForEvent;
//                            if ((int)withBlock.CountPilot() > 0)
//                            {
//                                p = withBlock.MainPilot();
//                            }
//                        }

//                        per = GetArgAsDouble((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "RecoverSPコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 408702


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (p is object)
//            {
//                if (p.MaxSP > 0)
//                {
//                    p.SP = (int)(p.SP + per * p.MaxSP / 100d);
//                }
//            }

//            ExecRecoverSPCmdRet = LineNum + 1;
//            return ExecRecoverSPCmdRet;
//        }

//        private int ExecRedrawCmd()
//        {
//            int ExecRedrawCmdRet = default;
//            var late_refresh = default(bool);
//            if (ArgNum == 2)
//            {
//                if (GetArgAsString(2) == "非同期")
//                {
//                    late_refresh = true;
//                }
//            }

//            GUI.RedrawScreen(late_refresh);
//            ExecRedrawCmdRet = LineNum + 1;
//            return ExecRedrawCmdRet;
//        }

//        private int ExecRefreshCmd()
//        {
//            int ExecRefreshCmdRet = default;
//            GUI.MainForm.picMain(0).Refresh();
//            ExecRefreshCmdRet = LineNum + 1;
//            return ExecRefreshCmdRet;
//        }

//        private int ExecReleaseCmd()
//        {
//            int ExecReleaseCmdRet = default;
//            string buf;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        buf = Event_Renamed.SelectedUnitForEvent.MainPilot().Name;
//                        break;
//                    }

//                case 2:
//                    {
//                        buf = GetArgAsString((short)2);
//                        bool localIsDefined() { object argIndex1 = (object)buf; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//                        bool localIsDefined1() { object argIndex1 = (object)buf; var ret = SRC.IList.IsDefined(ref argIndex1); return ret; }

//                        if (!localIsDefined() & !localIsDefined1())
//                        {
//                            Event_Renamed.EventErrorMessage = "パイロット名またはアイテム名" + buf + "が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 409999


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        object argIndex1 = (object)buf;
//                        if (SRC.PList.IsDefined(ref argIndex1))
//                        {
//                            Pilot localItem() { object argIndex1 = (object)buf; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                            buf = localItem().Name;
//                        }
//                        else
//                        {
//                            Item localItem1() { object argIndex1 = (object)buf; var ret = SRC.IList.Item(ref argIndex1); return ret; }

//                            buf = localItem1().Name;
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Releaseコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 410300


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            buf = "Fix(" + buf + ")";
//            if (Expression.IsGlobalVariableDefined(ref buf))
//            {
//                Event_Renamed.GlobalVariableList.Remove(buf);
//            }

//            ExecReleaseCmdRet = LineNum + 1;
//            return ExecReleaseCmdRet;
//        }

//        private int ExecRemoveFileCmd()
//        {
//            int ExecRemoveFileCmdRet = default;
//            string fname;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "RemoveFileコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 410742


//                Input:
//                            Error(0)

//                 */
//            }

//            fname = SRC.ScenarioPath + GetArgAsString(2);
//            if (Strings.InStr(fname, @"..\") > 0)
//            {
//                Event_Renamed.EventErrorMessage = @"ファイル指定に「..\」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 410987


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname, "../") > 0)
//            {
//                Event_Renamed.EventErrorMessage = "ファイル指定に「../」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 411157


//                Input:
//                            Error(0)

//                 */
//            }

//            if (GeneralLib.FileExists(ref fname))
//            {
//                FileSystem.Kill(fname);
//            }

//            ExecRemoveFileCmdRet = LineNum + 1;
//            return ExecRemoveFileCmdRet;
//        }

//        private int ExecRemoveFolderCmd()
//        {
//            int ExecRemoveFolderCmdRet = default;
//            string fname;
//            object fso;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "RemoveFolderコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 411575


//                Input:
//                            Error(0)

//                 */
//            }

//            fname = SRC.ScenarioPath + GetArgAsString(2);
//            if (Strings.InStr(fname, @"..\") > 0)
//            {
//                Event_Renamed.EventErrorMessage = @"ファイル指定に「..\」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 411820


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname, "../") > 0)
//            {
//                Event_Renamed.EventErrorMessage = "ファイル指定に「../」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 411990


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.Right(fname, 1) == @"\")
//            {
//                fname = Strings.Left(fname, Strings.Len(fname) - 1);
//            }

//            if (GeneralLib.FileExists(ref fname))
//            {
//                fso = Interaction.CreateObject("Scripting.FileSystemObject");

//                // UPGRADE_WARNING: オブジェクト fso.DeleteFolder の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                fso.DeleteFolder(fname);

//                // UPGRADE_NOTE: オブジェクト fso をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                fso = null;
//            }

//            ExecRemoveFolderCmdRet = LineNum + 1;
//            return ExecRemoveFolderCmdRet;
//        }

//        private int ExecRemoveItemCmd()
//        {
//            int ExecRemoveItemCmdRet = default;
//            string pname;
//            Unit u;
//            string iname;
//            short inumber;
//            var itm = default(Item);
//            short i, j;
//            var item_with_image = default(bool);
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        // 指定したユニットが装備しているアイテムすべてを外す
//                        {
//                            var withBlock = Event_Renamed.SelectedUnitForEvent;
//                            while ((int)withBlock.CountItem() > 0)
//                            {
//                                object argIndex1 = (object)1;
//                                string argfname = "ユニット画像";
//                                if (withBlock.Item(ref argIndex1).IsFeatureAvailable(ref argfname))
//                                {
//                                    item_with_image = true;
//                                }

//                                if (withBlock.Party0 != "味方")
//                                {
//                                    object argIndex2 = (object)1;
//                                    withBlock.Item(ref argIndex2).Exist = false;
//                                }

//                                object argIndex3 = (object)1;
//                                withBlock.DeleteItem(ref argIndex3);
//                            }

//                            if (item_with_image)
//                            {
//                                withBlock.BitmapID = GUI.MakeUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                var loopTo = withBlock.CountOtherForm();
//                                for (i = (short)1; i <= loopTo; i++)
//                                {
//                                    Unit localOtherForm() { object argIndex1 = (object)i; var ret = withBlock.OtherForm(ref argIndex1); return ret; }

//                                    localOtherForm().BitmapID = (short)0;
//                                }

//                                if (withBlock.Status_Renamed == "出撃")
//                                {
//                                    if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                    {
//                                        GUI.PaintUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                    }
//                                }
//                            }
//                        }

//                        break;
//                    }

//                case 2:
//                    {
//                        pname = GetArgAsString((short)2);
//                        bool localIsDefined() { object argIndex1 = (object)pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//                        object argIndex17 = (object)pname;
//                        if (SRC.UList.IsDefined(ref argIndex17))
//                        {
//                            // 指定したユニットが装備しているアイテムすべてを外す
//                            Unit localItem() { object argIndex1 = (object)pname; var ret = SRC.UList.Item(ref argIndex1); return ret; }

//                            u = localItem().CurrentForm();
//                            {
//                                var withBlock1 = u;
//                                while ((int)withBlock1.CountItem() > 0)
//                                {
//                                    object argIndex4 = (object)1;
//                                    string argfname1 = "ユニット画像";
//                                    if (withBlock1.Item(ref argIndex4).IsFeatureAvailable(ref argfname1))
//                                    {
//                                        item_with_image = true;
//                                    }

//                                    if (withBlock1.Party0 != "味方")
//                                    {
//                                        object argIndex5 = (object)1;
//                                        withBlock1.Item(ref argIndex5).Exist = false;
//                                    }

//                                    object argIndex6 = (object)1;
//                                    withBlock1.DeleteItem(ref argIndex6);
//                                }

//                                if (item_with_image)
//                                {
//                                    withBlock1.BitmapID = GUI.MakeUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                    var loopTo1 = withBlock1.CountOtherForm();
//                                    for (i = (short)1; i <= loopTo1; i++)
//                                    {
//                                        Unit localOtherForm1() { object argIndex1 = (object)i; var ret = withBlock1.OtherForm(ref argIndex1); return ret; }

//                                        localOtherForm1().BitmapID = (short)0;
//                                    }

//                                    if (withBlock1.Status_Renamed == "出撃")
//                                    {
//                                        if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                        {
//                                            GUI.PaintUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        else if (localIsDefined())
//                        {
//                            // 指定したパイロットが乗るユニットが装備しているアイテムすべてを外す
//                            Pilot localItem3() { object argIndex1 = (object)pname; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                            u = localItem3().Unit_Renamed;
//                            if (u is object)
//                            {
//                                {
//                                    var withBlock8 = u;
//                                    while ((int)withBlock8.CountItem() > 0)
//                                    {
//                                        object argIndex14 = (object)1;
//                                        string argfname5 = "ユニット画像";
//                                        if (withBlock8.Item(ref argIndex14).IsFeatureAvailable(ref argfname5))
//                                        {
//                                            item_with_image = true;
//                                        }

//                                        if (withBlock8.Party0 != "味方")
//                                        {
//                                            object argIndex15 = (object)1;
//                                            withBlock8.Item(ref argIndex15).Exist = false;
//                                        }

//                                        object argIndex16 = (object)1;
//                                        withBlock8.DeleteItem(ref argIndex16);
//                                    }

//                                    if (item_with_image)
//                                    {
//                                        withBlock8.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                        var loopTo5 = withBlock8.CountOtherForm();
//                                        for (i = (short)1; i <= loopTo5; i++)
//                                        {
//                                            Unit localOtherForm5() { object argIndex1 = (object)i; var ret = withBlock8.OtherForm(ref argIndex1); return ret; }

//                                            localOtherForm5().BitmapID = (short)0;
//                                        }

//                                        if (withBlock8.Status_Renamed == "出撃")
//                                        {
//                                            if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                            {
//                                                GUI.PaintUnitBitmap(ref u);
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        else
//                        {
//                            // 指定されたアイテムを削除
//                            iname = pname;
//                            if (Information.IsNumeric(iname))
//                            {
//                                {
//                                    var withBlock2 = Event_Renamed.SelectedUnitForEvent;
//                                    inumber = Conversions.ToShort(iname);
//                                    if ((int)inumber < 1)
//                                    {
//                                        Event_Renamed.EventErrorMessage = "指定されたアイテム番号「" + iname + "」が不正です";
//                                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 416293


//                                        Input:
//                                                                        Error(0)

//                                         */
//                                    }

//                                    if (inumber > withBlock2.CountItem())
//                                    {
//                                        Event_Renamed.EventErrorMessage = "指定されたユニットは" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)withBlock2.CountItem()) + "個のアイテムしか持っていません";
//                                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 416523


//                                        Input:
//                                                                        Error(0)

//                                         */
//                                    }

//                                    object argIndex8 = (object)inumber;
//                                    {
//                                        var withBlock3 = withBlock2.Item(ref argIndex8);
//                                        string argfname2 = "ユニット画像";
//                                        if (withBlock3.IsFeatureAvailable(ref argfname2))
//                                        {
//                                            item_with_image = true;
//                                        }

//                                        object argIndex7 = (object)withBlock3.ID;
//                                        Event_Renamed.SelectedUnitForEvent.DeleteItem(ref argIndex7);
//                                        if (item_with_image)
//                                        {
//                                            {
//                                                var withBlock4 = Event_Renamed.SelectedUnitForEvent;
//                                                withBlock4.BitmapID = GUI.MakeUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                                var loopTo2 = withBlock4.CountOtherForm();
//                                                for (i = (short)1; i <= loopTo2; i++)
//                                                {
//                                                    Unit localOtherForm2() { object argIndex1 = (object)i; var ret = withBlock4.OtherForm(ref argIndex1); return ret; }

//                                                    localOtherForm2().BitmapID = (short)0;
//                                                }

//                                                if (withBlock4.Status_Renamed == "出撃")
//                                                {
//                                                    if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                                    {
//                                                        GUI.PaintUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                                    }
//                                                }
//                                            }
//                                        }

//                                        // UPGRADE_NOTE: オブジェクト SelectedUnitForEvent.Item().Unit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                        withBlock3.Unit_Renamed = null;
//                                        withBlock3.Exist = false;
//                                        ExecRemoveItemCmdRet = LineNum + 1;
//                                        return ExecRemoveItemCmdRet;
//                                    }
//                                }
//                            }

//                            // アイテムＩＤが指定された場合はそのまま削除
//                            object argIndex11 = (object)iname;
//                            if (SRC.IList.IsDefined(ref argIndex11))
//                            {
//                                Item localItem1() { object argIndex1 = (object)iname; var ret = SRC.IList.Item(ref argIndex1); return ret; }

//                                if ((localItem1().ID ?? "") == (iname ?? ""))
//                                {
//                                    object argIndex10 = (object)iname;
//                                    {
//                                        var withBlock5 = SRC.IList.Item(ref argIndex10);
//                                        if (withBlock5.Unit_Renamed is object)
//                                        {
//                                            string argfname3 = "ユニット画像";
//                                            if (withBlock5.IsFeatureAvailable(ref argfname3))
//                                            {
//                                                item_with_image = true;
//                                            }

//                                            object argIndex9 = (object)withBlock5.ID;
//                                            withBlock5.Unit_Renamed.DeleteItem(ref argIndex9);
//                                            if (item_with_image)
//                                            {
//                                                withBlock5.Unit_Renamed.BitmapID = GUI.MakeUnitBitmap(ref withBlock5.Unit_Renamed);
//                                                {
//                                                    var withBlock6 = withBlock5.Unit_Renamed;
//                                                    var loopTo3 = withBlock6.CountOtherForm();
//                                                    for (i = (short)1; i <= loopTo3; i++)
//                                                    {
//                                                        Unit localOtherForm3() { object argIndex1 = (object)i; var ret = withBlock6.OtherForm(ref argIndex1); return ret; }

//                                                        localOtherForm3().BitmapID = (short)0;
//                                                    }

//                                                    if (withBlock6.Status_Renamed == "出撃")
//                                                    {
//                                                        if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                                        {
//                                                            GUI.PaintUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                                        }
//                                                    }
//                                                }
//                                            }
//                                        }

//                                        // UPGRADE_NOTE: オブジェクト IList.Item().Unit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                        withBlock5.Unit_Renamed = null;
//                                        withBlock5.Exist = false;
//                                        ExecRemoveItemCmdRet = LineNum + 1;
//                                        return ExecRemoveItemCmdRet;
//                                    }
//                                }
//                            }

//                            // 大文字・小文字、ひらがな・かたかなの違いを正しく判定できるように、
//                            // 名前をデータのそれとあわせる
//                            object argIndex12 = (object)iname;
//                            if (SRC.IDList.IsDefined(ref argIndex12))
//                            {
//                                ItemData localItem2() { object argIndex1 = (object)iname; var ret = SRC.IDList.Item(ref argIndex1); return ret; }

//                                iname = localItem2().Name;
//                            }

//                            // まずは装備されていないアイテムを探す
//                            foreach (Item currentItm in SRC.IList)
//                            {
//                                itm = currentItm;
//                                if ((itm.Name ?? "") == (iname ?? "") & itm.Exist & itm.Unit_Renamed is null)
//                                {
//                                    // 見つかった
//                                    itm.Exist = false;
//                                    break;
//                                }
//                            }
//                            // 見つからなかったら装備されたアイテムから
//                            if (itm is null)
//                            {
//                                foreach (Item currentItm1 in SRC.IList)
//                                {
//                                    itm = currentItm1;
//                                    if ((itm.Name ?? "") == (iname ?? "") & itm.Exist)
//                                    {
//                                        string argfname4 = "ユニット画像";
//                                        if (itm.IsFeatureAvailable(ref argfname4))
//                                        {
//                                            item_with_image = true;
//                                        }

//                                        u = itm.Unit_Renamed;
//                                        object argIndex13 = (object)itm.ID;
//                                        u.DeleteItem(ref argIndex13);
//                                        if (item_with_image)
//                                        {
//                                            u.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                            {
//                                                var withBlock7 = u;
//                                                var loopTo4 = withBlock7.CountOtherForm();
//                                                for (i = (short)1; i <= loopTo4; i++)
//                                                {
//                                                    Unit localOtherForm4() { object argIndex1 = (object)i; var ret = withBlock7.OtherForm(ref argIndex1); return ret; }

//                                                    localOtherForm4().BitmapID = (short)0;
//                                                }

//                                                if (withBlock7.Status_Renamed == "出撃")
//                                                {
//                                                    if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                                    {
//                                                        GUI.PaintUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                                    }
//                                                }
//                                            }
//                                        }

//                                        // UPGRADE_NOTE: オブジェクト itm.Unit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                        itm.Unit_Renamed = null;
//                                        itm.Exist = false;
//                                        break;
//                                    }
//                                }
//                            }
//                        }

//                        break;
//                    }

//                case 3:
//                    {
//                        // 指定されたアイテムを削除
//                        pname = GetArgAsString((short)2);
//                        bool localIsDefined1() { object argIndex1 = (object)pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//                        object argIndex18 = (object)pname;
//                        if (SRC.UList.IsDefined(ref argIndex18))
//                        {
//                            Unit localItem4() { object argIndex1 = (object)pname; var ret = SRC.UList.Item(ref argIndex1); return ret; }

//                            u = localItem4().CurrentForm();
//                        }
//                        else if (localIsDefined1())
//                        {
//                            Pilot localItem5() { object argIndex1 = (object)pname; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                            u = localItem5().Unit_Renamed;
//                            if (u is null)
//                            {
//                                Event_Renamed.EventErrorMessage = "「" + pname + "」はユニットに乗っていません";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 421350


//                                Input:
//                                                        Error(0)

//                                 */
//                            }
//                        }
//                        else
//                        {
//                            Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 421478


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        iname = GetArgAsString((short)3);
//                        {
//                            var withBlock9 = u;
//                            if (Information.IsNumeric(iname))
//                            {
//                                inumber = Conversions.ToShort(iname);
//                                if ((int)inumber < 1)
//                                {
//                                    Event_Renamed.EventErrorMessage = "指定されたアイテム番号「" + iname + "」が不正です";
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 421787


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                if (inumber > withBlock9.CountItem())
//                                {
//                                    Event_Renamed.EventErrorMessage = "指定されたユニットは" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)withBlock9.CountItem()) + "個のアイテムしか持っていません";
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 422013


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                object argIndex20 = (object)inumber;
//                                {
//                                    var withBlock10 = withBlock9.Item(ref argIndex20);
//                                    string argfname6 = "ユニット画像";
//                                    if (withBlock10.IsFeatureAvailable(ref argfname6))
//                                    {
//                                        item_with_image = true;
//                                    }

//                                    object argIndex19 = (object)withBlock10.ID;
//                                    u.DeleteItem(ref argIndex19);
//                                    if (item_with_image)
//                                    {
//                                        {
//                                            var withBlock11 = u;
//                                            withBlock11.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                            var loopTo6 = withBlock11.CountOtherForm();
//                                            for (j = (short)1; j <= loopTo6; j++)
//                                            {
//                                                Unit localOtherForm6() { object argIndex1 = (object)j; var ret = withBlock11.OtherForm(ref argIndex1); return ret; }

//                                                localOtherForm6().BitmapID = (short)0;
//                                            }

//                                            if (withBlock11.Status_Renamed == "出撃")
//                                            {
//                                                if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                                {
//                                                    GUI.PaintUnitBitmap(ref u);
//                                                }
//                                            }
//                                        }
//                                    }

//                                    // UPGRADE_NOTE: オブジェクト u.Item().Unit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                    withBlock10.Unit_Renamed = null;
//                                    withBlock10.Exist = false;
//                                    ExecRemoveItemCmdRet = LineNum + 1;
//                                    return ExecRemoveItemCmdRet;
//                                }
//                            }

//                            // 大文字・小文字、ひらがな・かたかなの違いを正しく判定できるように、
//                            // 名前をデータのそれとあわせる
//                            object argIndex21 = (object)iname;
//                            if (SRC.IDList.IsDefined(ref argIndex21))
//                            {
//                                ItemData localItem6() { object argIndex1 = (object)iname; var ret = SRC.IDList.Item(ref argIndex1); return ret; }

//                                iname = localItem6().Name;
//                            }

//                            var loopTo7 = withBlock9.CountItem();
//                            for (i = (short)1; i <= loopTo7; i++)
//                            {
//                                object argIndex23 = (object)i;
//                                {
//                                    var withBlock12 = withBlock9.Item(ref argIndex23);
//                                    if (((withBlock12.Name ?? "") == (iname ?? "") | (withBlock12.ID ?? "") == (iname ?? "")) & withBlock12.Exist)
//                                    {
//                                        string argfname7 = "ユニット画像";
//                                        if (withBlock12.IsFeatureAvailable(ref argfname7))
//                                        {
//                                            item_with_image = true;
//                                        }

//                                        object argIndex22 = (object)withBlock12.ID;
//                                        u.DeleteItem(ref argIndex22);
//                                        if (item_with_image)
//                                        {
//                                            {
//                                                var withBlock13 = u;
//                                                withBlock13.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                                var loopTo8 = withBlock13.CountOtherForm();
//                                                for (j = (short)1; j <= loopTo8; j++)
//                                                {
//                                                    Unit localOtherForm7() { object argIndex1 = (object)j; var ret = withBlock13.OtherForm(ref argIndex1); return ret; }

//                                                    localOtherForm7().BitmapID = (short)0;
//                                                }

//                                                if (withBlock13.Status_Renamed == "出撃")
//                                                {
//                                                    if (!GUI.IsPictureVisible & !string.IsNullOrEmpty(Map.MapFileName))
//                                                    {
//                                                        GUI.PaintUnitBitmap(ref u);
//                                                    }
//                                                }
//                                            }
//                                        }

//                                        // UPGRADE_NOTE: オブジェクト u.Item().Unit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                        withBlock12.Unit_Renamed = null;
//                                        withBlock12.Exist = false;
//                                        break;
//                                    }
//                                }
//                            }
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "RemoveItemコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 424422


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecRemoveItemCmdRet = LineNum + 1;
//            return ExecRemoveItemCmdRet;
//        }

//        private int ExecRemovePilotCmd()
//        {
//            int ExecRemovePilotCmdRet = default;
//            string pname;
//            short i, num;
//            Pilot p;
//            var opt = default(string);
//            num = ArgNum;
//            if (num > 1)
//            {
//                if (GetArgAsString(num) == "非同期")
//                {
//                    opt = "非同期";
//                    num = (short)(num - 1);
//                }
//            }

//            ExecRemovePilotCmdRet = LineNum + 1;
//            switch (num)
//            {
//                case 1:
//                    {
//                        {
//                            var withBlock = Event_Renamed.SelectedUnitForEvent;
//                            if ((int)withBlock.CountPilot() == 0)
//                            {
//                                Event_Renamed.EventErrorMessage = "指定されたユニットにパイロットが乗っていません";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 425061


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            if (withBlock.Status_Renamed == "出撃")
//                            {
//                                withBlock.Escape(opt);
//                            }

//                            var loopTo = withBlock.CountPilot();
//                            for (i = (short)1; i <= loopTo; i++)
//                            {
//                                Pilot localPilot() { object argIndex1 = (object)i; var ret = withBlock.Pilot(ref argIndex1); return ret; }

//                                localPilot().Alive = false;
//                            }

//                            var loopTo1 = withBlock.CountSupport();
//                            for (i = (short)1; i <= loopTo1; i++)
//                            {
//                                Pilot localSupport() { object argIndex1 = (object)i; var ret = withBlock.Support(ref argIndex1); return ret; }

//                                localSupport().Alive = false;
//                            }

//                            withBlock.Status_Renamed = "破棄";
//                            var loopTo2 = withBlock.CountOtherForm();
//                            for (i = (short)1; i <= loopTo2; i++)
//                            {
//                                Unit localOtherForm1() { object argIndex1 = (object)i; var ret = withBlock.OtherForm(ref argIndex1); return ret; }

//                                if (localOtherForm1().Status_Renamed == "他形態")
//                                {
//                                    Unit localOtherForm() { object argIndex1 = (object)i; var ret = withBlock.OtherForm(ref argIndex1); return ret; }

//                                    localOtherForm().Status_Renamed = "破棄";
//                                }
//                            }
//                        }

//                        break;
//                    }

//                case 2:
//                    {
//                        pname = GetArgAsString((short)2);
//                        bool localIsDefined() { object argIndex1 = (object)pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//                        if (!localIsDefined())
//                        {
//                            Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 425712


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        object argIndex1 = (object)pname;
//                        p = SRC.PList.Item(ref argIndex1);
//                        p.Alive = false;
//                        if (p.Unit_Renamed is object)
//                        {
//                            {
//                                var withBlock1 = p.Unit_Renamed;
//                                object argIndex4 = (object)1;
//                                if ((p.ID ?? "") == (withBlock1.MainPilot().ID ?? "") | (p.ID ?? "") == (withBlock1.Pilot(ref argIndex4).ID ?? ""))
//                                {
//                                    // メインパイロットの場合はパイロット＆サポートを全員削除
//                                    // ユニットも削除する
//                                    if (withBlock1.Status_Renamed == "出撃" | withBlock1.Status_Renamed == "格納")
//                                    {
//                                        withBlock1.Escape(opt);
//                                    }

//                                    var loopTo3 = withBlock1.CountPilot();
//                                    for (i = (short)1; i <= loopTo3; i++)
//                                    {
//                                        Pilot localPilot1() { object argIndex1 = (object)i; var ret = withBlock1.Pilot(ref argIndex1); return ret; }

//                                        localPilot1().Alive = false;
//                                    }

//                                    var loopTo4 = withBlock1.CountSupport();
//                                    for (i = (short)1; i <= loopTo4; i++)
//                                    {
//                                        Pilot localSupport1() { object argIndex1 = (object)i; var ret = withBlock1.Support(ref argIndex1); return ret; }

//                                        localSupport1().Alive = false;
//                                    }

//                                    withBlock1.Status_Renamed = "破棄";
//                                    var loopTo5 = withBlock1.CountOtherForm();
//                                    for (i = (short)1; i <= loopTo5; i++)
//                                    {
//                                        Unit localOtherForm3() { object argIndex1 = (object)i; var ret = withBlock1.OtherForm(ref argIndex1); return ret; }

//                                        if (localOtherForm3().Status_Renamed == "他形態")
//                                        {
//                                            Unit localOtherForm2() { object argIndex1 = (object)i; var ret = withBlock1.OtherForm(ref argIndex1); return ret; }

//                                            localOtherForm2().Status_Renamed = "破棄";
//                                        }
//                                    }
//                                }
//                                else
//                                {
//                                    // メインパイロットが対象でなければ指定されたパイロットのみを削除
//                                    var loopTo6 = withBlock1.CountPilot();
//                                    for (i = (short)1; i <= loopTo6; i++)
//                                    {
//                                        Pilot localPilot2() { object argIndex1 = (object)i; var ret = withBlock1.Pilot(ref argIndex1); return ret; }

//                                        if ((p.ID ?? "") == (localPilot2().ID ?? ""))
//                                        {
//                                            object argIndex2 = (object)i;
//                                            withBlock1.DeletePilot(ref argIndex2);
//                                            // UPGRADE_NOTE: オブジェクト p.Unit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                            p.Unit_Renamed = null;
//                                            return ExecRemovePilotCmdRet;
//                                        }
//                                    }

//                                    var loopTo7 = withBlock1.CountSupport();
//                                    for (i = (short)1; i <= loopTo7; i++)
//                                    {
//                                        Pilot localSupport2() { object argIndex1 = (object)i; var ret = withBlock1.Support(ref argIndex1); return ret; }

//                                        if ((p.ID ?? "") == (localSupport2().ID ?? ""))
//                                        {
//                                            object argIndex3 = (object)i;
//                                            withBlock1.DeleteSupport(ref argIndex3);
//                                            // UPGRADE_NOTE: オブジェクト p.Unit をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                                            p.Unit_Renamed = null;
//                                            return ExecRemovePilotCmdRet;
//                                        }
//                                    }
//                                }
//                            }
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "RemovePilotの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 427433


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            return ExecRemovePilotCmdRet;
//        }

//        private int ExecRemoveUnitCmd()
//        {
//            int ExecRemoveUnitCmdRet = default;
//            string uname;
//            Unit u;
//            short i, num;
//            var opt = default(string);
//            num = ArgNum;
//            if (num > 1)
//            {
//                if (GetArgAsString(num) == "非同期")
//                {
//                    opt = "非同期";
//                    num = (short)(num - 1);
//                }
//            }

//            switch (num)
//            {
//                case 1:
//                    {
//                        {
//                            var withBlock = Event_Renamed.SelectedUnitForEvent.CurrentForm();
//                            withBlock.Escape(opt);
//                            if ((int)withBlock.CountPilot() > 0)
//                            {
//                                object argIndex1 = (object)1;
//                                withBlock.Pilot(ref argIndex1).GetOff();
//                            }

//                            withBlock.Status_Renamed = "破棄";
//                            var loopTo = withBlock.CountOtherForm();
//                            for (i = (short)1; i <= loopTo; i++)
//                            {
//                                Unit localOtherForm1() { object argIndex1 = (object)i; var ret = withBlock.OtherForm(ref argIndex1); return ret; }

//                                if (localOtherForm1().Status_Renamed == "他形態")
//                                {
//                                    Unit localOtherForm() { object argIndex1 = (object)i; var ret = withBlock.OtherForm(ref argIndex1); return ret; }

//                                    localOtherForm().Status_Renamed = "破棄";
//                                }
//                            }
//                        }

//                        break;
//                    }

//                case 2:
//                    {
//                        uname = GetArgAsString((short)2);
//                        object argIndex2 = (object)uname;
//                        u = SRC.UList.Item(ref argIndex2);

//                        // ユニットが存在しなければそのまま終了
//                        if (u is null)
//                        {
//                            ExecRemoveUnitCmdRet = LineNum + 1;
//                            return ExecRemoveUnitCmdRet;
//                        }

//                        // ユニットＩＤで指定された場合
//                        if ((u.ID ?? "") == (uname ?? ""))
//                        {
//                            u.Escape(opt);
//                            if ((int)u.CountPilot() > 0)
//                            {
//                                object argIndex3 = (object)1;
//                                u.Pilot(ref argIndex3).GetOff();
//                            }

//                            u.Status_Renamed = "破棄";
//                            var loopTo1 = u.CountOtherForm();
//                            for (i = (short)1; i <= loopTo1; i++)
//                            {
//                                Unit localOtherForm3() { object argIndex1 = (object)i; var ret = u.OtherForm(ref argIndex1); return ret; }

//                                if (localOtherForm3().Status_Renamed == "他形態")
//                                {
//                                    Unit localOtherForm2() { object argIndex1 = (object)i; var ret = u.OtherForm(ref argIndex1); return ret; }

//                                    localOtherForm2().Status_Renamed = "破棄";
//                                }
//                            }

//                            ExecRemoveUnitCmdRet = LineNum + 1;
//                            return ExecRemoveUnitCmdRet;
//                        }

//                        // 大文字・小文字、ひらがな・かたかなの違いを正しく判定できるように、
//                        // 名前をデータのそれとあわせる
//                        object argIndex4 = (object)uname;
//                        if (SRC.UDList.IsDefined(ref argIndex4))
//                        {
//                            UnitData localItem() { object argIndex1 = (object)uname; var ret = SRC.UDList.Item(ref argIndex1); return ret; }

//                            uname = localItem().Name;
//                        }

//                        // パイロットが乗ってないユニットを優先
//                        foreach (Unit currentU in SRC.UList)
//                        {
//                            u = currentU;
//                            {
//                                var withBlock1 = u.CurrentForm();
//                                if ((withBlock1.Name ?? "") == (uname ?? "") & withBlock1.Status_Renamed != "破棄")
//                                {
//                                    if ((int)withBlock1.CountPilot() == 0)
//                                    {
//                                        withBlock1.Escape(opt);
//                                        withBlock1.Status_Renamed = "破棄";
//                                        var loopTo2 = withBlock1.CountOtherForm();
//                                        for (i = (short)1; i <= loopTo2; i++)
//                                        {
//                                            Unit localOtherForm5() { object argIndex1 = (object)i; var ret = withBlock1.OtherForm(ref argIndex1); return ret; }

//                                            if (localOtherForm5().Status_Renamed == "他形態")
//                                            {
//                                                Unit localOtherForm4() { object argIndex1 = (object)i; var ret = withBlock1.OtherForm(ref argIndex1); return ret; }

//                                                localOtherForm4().Status_Renamed = "破棄";
//                                            }
//                                        }

//                                        ExecRemoveUnitCmdRet = LineNum + 1;
//                                        return ExecRemoveUnitCmdRet;
//                                    }
//                                }
//                            }
//                        }

//                        // 見つからなければパイロットが乗っているユニットを削除
//                        foreach (Unit currentU1 in SRC.UList)
//                        {
//                            u = currentU1;
//                            {
//                                var withBlock2 = u.CurrentForm();
//                                if ((withBlock2.Name ?? "") == (uname ?? "") & withBlock2.Status_Renamed != "破棄")
//                                {
//                                    withBlock2.Escape(opt);
//                                    object argIndex5 = (object)1;
//                                    withBlock2.Pilot(ref argIndex5).GetOff();
//                                    withBlock2.Status_Renamed = "破棄";
//                                    var loopTo3 = withBlock2.CountOtherForm();
//                                    for (i = (short)1; i <= loopTo3; i++)
//                                    {
//                                        Unit localOtherForm7() { object argIndex1 = (object)i; var ret = withBlock2.OtherForm(ref argIndex1); return ret; }

//                                        if (localOtherForm7().Status_Renamed == "他形態")
//                                        {
//                                            Unit localOtherForm6() { object argIndex1 = (object)i; var ret = withBlock2.OtherForm(ref argIndex1); return ret; }

//                                            localOtherForm6().Status_Renamed = "破棄";
//                                        }
//                                    }

//                                    ExecRemoveUnitCmdRet = LineNum + 1;
//                                    return ExecRemoveUnitCmdRet;
//                                }
//                            }
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "RemoveUnitの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 430173


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecRemoveUnitCmdRet = LineNum + 1;
//            return ExecRemoveUnitCmdRet;
//        }

//        private int ExecRenameBGMCmd()
//        {
//            int ExecRenameBGMCmdRet = default;
//            string bname, vname;
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "RenameBGMの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 430445


//                Input:
//                            Error(0)

//                 */
//            }

//            bname = GetArgAsString(2);
//            switch (bname ?? "")
//            {
//                case "Map1":
//                case "Map2":
//                case "Map3":
//                case "Map4":
//                case "Map5":
//                case "Map6":
//                case "Briefing":
//                case "Intermission":
//                case "Subtitle":
//                case "End":
//                case "default":
//                    {
//                        vname = "BGM(" + bname + ")";
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "BGM名が不正です";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 430755


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (!Expression.IsGlobalVariableDefined(ref vname))
//            {
//                Expression.DefineGlobalVariable(ref vname);
//            }

//            string argnew_value = GetArgAsString(3);
//            Expression.SetVariableAsString(ref vname, ref argnew_value);
//            ExecRenameBGMCmdRet = LineNum + 1;
//            return ExecRenameBGMCmdRet;
//        }

//        private int ExecRenameFileCmd()
//        {
//            int ExecRenameFileCmdRet = default;
//            string fname1, fname2;
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "RenameFileコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 431259


//                Input:
//                            Error(0)

//                 */
//            }

//            fname1 = SRC.ScenarioPath + GetArgAsString(2);
//            fname2 = SRC.ScenarioPath + GetArgAsString(3);
//            if (Strings.InStr(fname1, @"..\") > 0)
//            {
//                Event_Renamed.EventErrorMessage = @"ファイル指定に「..\」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 431574


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname1, "../") > 0)
//            {
//                Event_Renamed.EventErrorMessage = "ファイル指定に「../」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 431745


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname2, @"..\") > 0)
//            {
//                Event_Renamed.EventErrorMessage = @"ファイル指定に「..\」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 431916


//                Input:
//                            Error(0)

//                 */
//            }

//            if (Strings.InStr(fname2, "../") > 0)
//            {
//                Event_Renamed.EventErrorMessage = "ファイル指定に「../」は使えません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 432087


//                Input:
//                            Error(0)

//                 */
//            }

//            if (!GeneralLib.FileExists(ref fname1))
//            {
//                Event_Renamed.EventErrorMessage = "元のファイル" + "「" + fname1 + "」が見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 432267


//                Input:
//                            Error(0)

//                 */
//            }

//            if (GeneralLib.FileExists(ref fname2))
//            {
//                Event_Renamed.EventErrorMessage = "既に" + "「" + fname2 + "」が存在しています";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 432435


//                Input:
//                            Error(0)

//                 */
//            }

//            FileSystem.Rename(fname1, fname2);
//            ExecRenameFileCmdRet = LineNum + 1;
//            return ExecRenameFileCmdRet;
//        }

//        private int ExecRenameTermCmd()
//        {
//            int ExecRenameTermCmdRet = default;
//            string tname, vname;
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "RenameTermの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 432775


//                Input:
//                            Error(0)

//                 */
//            }

//            tname = GetArgAsString(2);
//            switch (tname ?? "")
//            {
//                case "HP":
//                case "EN":
//                case "SP":
//                case "CT":
//                    {
//                        vname = "ShortTerm(" + tname + ")";
//                        break;
//                    }

//                default:
//                    {
//                        vname = "Term(" + tname + ")";
//                        break;
//                    }
//            }

//            if (!Expression.IsGlobalVariableDefined(ref vname))
//            {
//                Expression.DefineGlobalVariable(ref vname);
//            }

//            string argnew_value = GetArgAsString(3);
//            Expression.SetVariableAsString(ref vname, ref argnew_value);
//            ExecRenameTermCmdRet = LineNum + 1;
//            return ExecRenameTermCmdRet;
//        }

//        private int ExecReplacePilotCmd()
//        {
//            int ExecReplacePilotCmdRet = default;
//            string pname;
//            Pilot p1, p2;
//            short i;
//            bool is_support;
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "ReplacePilotの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 433545


//                Input:
//                            Error(0)

//                 */
//            }

//            p1 = GetArgAsPilot(2);
//            pname = GetArgAsString(3);
//            bool localIsDefined() { object argIndex1 = pname; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined())
//            {
//                Event_Renamed.EventErrorMessage = "パイロット名が間違っています";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 433766


//                Input:
//                            Error(0)

//                 */
//            }

//            string arggid = "";
//            p2 = SRC.PList.Add(ref pname, p1.Level, ref p1.Party, gid: ref arggid);
//            {
//                var withBlock = p2;
//                withBlock.FullRecover();
//                withBlock.Morale = p1.Morale;
//                withBlock.Exp = p1.Exp;
//                if (withBlock.Data.SP > 0 & p1.MaxSP > 0)
//                {
//                    withBlock.SP = withBlock.MaxSP * p1.SP / p1.MaxSP;
//                }

//                string argsname1 = "霊力";
//                if (withBlock.IsSkillAvailable(ref argsname1))
//                {
//                    string argsname = "霊力";
//                    if (p1.IsSkillAvailable(ref argsname))
//                    {
//                        withBlock.Plana = withBlock.MaxPlana() * p1.Plana / p1.MaxPlana();
//                    }
//                }
//            }

//            // 乗せ換え
//            if (p1.Unit_Renamed is object)
//            {
//                {
//                    var withBlock1 = p1.Unit_Renamed;
//                    // パイロットがサポートがどうか判定
//                    is_support = false;
//                    var loopTo = withBlock1.CountSupport();
//                    for (i = 1; i <= loopTo; i++)
//                    {
//                        object argIndex1 = i;
//                        if (ReferenceEquals(withBlock1.Support(ref argIndex1), p1))
//                        {
//                            is_support = true;
//                            break;
//                        }
//                    }

//                    string argfname = "追加サポート";
//                    if (withBlock1.IsFeatureAvailable(ref argfname))
//                    {
//                        if (ReferenceEquals(withBlock1.AdditionalSupport(), p1))
//                        {
//                            is_support = true;
//                        }
//                    }

//                    if (is_support)
//                    {
//                        withBlock1.ReplaceSupport(ref p2, ref (object)p1.ID);
//                    }
//                    else
//                    {
//                        withBlock1.ReplacePilot(ref p2, ref (object)p1.ID);
//                    }
//                }

//                SRC.PList.UpdateSupportMod(p1.Unit_Renamed);
//            }

//            p1.Alive = false;
//            ExecReplacePilotCmdRet = LineNum + 1;
//            return ExecReplacePilotCmdRet;
//        }

//        private int ExecRequireCmd()
//        {
//            int ExecRequireCmdRet = default;
//            string fname;
//            int file_head;
//            int i;
//            string buf;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Requireコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 435110


//                Input:
//                            Error(0)

//                 */
//            }

//            // LoadEventData2内でLineNumは書き換えられるのでここで設定
//            ExecRequireCmdRet = LineNum + 1;

//            // ADD START マージ
//            // Requireコマンドで読み込まれたことを記録済み？
//            var loopTo = Information.UBound(Event_Renamed.AdditionalEventFileNames);
//            for (i = 1; i <= loopTo; i++)
//            {
//                if ((GetArgAsString(2) ?? "") == (Event_Renamed.AdditionalEventFileNames[i] ?? ""))
//                {
//                    return ExecRequireCmdRet;
//                }
//            }

//            // 読み込んだイベントファイルを記録
//            Array.Resize(ref Event_Renamed.AdditionalEventFileNames, Information.UBound(Event_Renamed.AdditionalEventFileNames) + 1 + 1);
//            Event_Renamed.AdditionalEventFileNames[Information.UBound(Event_Renamed.AdditionalEventFileNames)] = GetArgAsString(2);
//            // ADD END マージ

//            // 読み込むファイル名
//            fname = SRC.ScenarioPath + GetArgAsString(2);

//            // 既に読み込まれている場合はスキップ
//            var loopTo1 = Information.UBound(Event_Renamed.EventFileNames);
//            for (i = 1; i <= loopTo1; i++)
//            {
//                if ((fname ?? "") == (Event_Renamed.EventFileNames[i] ?? ""))
//                {
//                    return ExecRequireCmdRet;
//                }
//            }

//            // ファイルが存在する？
//            if (!GeneralLib.FileExists(ref fname))
//            {
//                Event_Renamed.EventErrorMessage = "指定されたファイル「" + fname + "」が見つかりません。";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 436428


//                Input:
//                            Error(0)

//                 */
//            }

//            // ファイルをロード
//            file_head = Information.UBound(Event_Renamed.EventData) + 1;
//            Event_Renamed.LoadEventData2(ref fname, Information.UBound(Event_Renamed.EventData));

//            // エラー表示用にサイズを大きく取っておく
//            Array.Resize(ref Event_Renamed.EventData, Information.UBound(Event_Renamed.EventData) + 1 + 1);
//            Array.Resize(ref Event_Renamed.EventLineNum, Information.UBound(Event_Renamed.EventData) + 1);
//            Event_Renamed.EventData[Information.UBound(Event_Renamed.EventData)] = "";
//            Event_Renamed.EventLineNum[Information.UBound(Event_Renamed.EventData)] = (short)(Event_Renamed.EventLineNum[Information.UBound(Event_Renamed.EventData) - 1] + 1);

//            // 複数行に分割されたコマンドを結合
//            var loopTo2 = Information.UBound(Event_Renamed.EventData) - 1;
//            for (i = file_head; i <= loopTo2; i++)
//            {
//                if (Strings.Right(Event_Renamed.EventData[i], 1) == "_")
//                {
//                    Event_Renamed.EventData[i + 1] = Strings.Left(Event_Renamed.EventData[i], Strings.Len(Event_Renamed.EventData[i]) - 1) + Event_Renamed.EventData[i + 1];
//                    Event_Renamed.EventData[i] = " ";
//                }
//            }

//            // ラベルを登録
//            var loopTo3 = Information.UBound(Event_Renamed.EventData);
//            for (i = file_head; i <= loopTo3; i++)
//            {
//                buf = Event_Renamed.EventData[i];
//                if (Strings.Right(buf, 1) == ":")
//                {
//                    string arglname = Strings.Left(buf, Strings.Len(buf) - 1);
//                    Event_Renamed.AddLabel(ref arglname, i);
//                }
//            }

//            // コマンドデータ配列を設定
//            if (Information.UBound(Event_Renamed.EventData) > Information.UBound(Event_Renamed.EventCmd))
//            {
//                Array.Resize(ref Event_Renamed.EventCmd, Information.UBound(Event_Renamed.EventData) + 1);
//                i = Information.UBound(Event_Renamed.EventData);
//                while (Event_Renamed.EventCmd[i] is null)
//                {
//                    Event_Renamed.EventCmd[i] = new CmdData();
//                    Event_Renamed.EventCmd[i].LineNum = i;
//                    i = i - 1;
//                }
//            }

//            var loopTo4 = Information.UBound(Event_Renamed.EventData);
//            for (i = file_head; i <= loopTo4; i++)
//                Event_Renamed.EventCmd[i].Name = Event_Renamed.CmdType.NullCmd;

//            // 読み込んだイベントファイルを記録
//            Array.Resize(ref Event_Renamed.AdditionalEventFileNames, Information.UBound(Event_Renamed.AdditionalEventFileNames) + 1 + 1);
//            Event_Renamed.AdditionalEventFileNames[Information.UBound(Event_Renamed.AdditionalEventFileNames)] = GetArgAsString(2);
//            return ExecRequireCmdRet;
//        }

//        private int ExecRestoreEventCmd()
//        {
//            int ExecRestoreEventCmdRet = default;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "RestoreEventコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 439974


//                Input:
//                            Error(0)

//                 */
//            }

//            string arglname = GetArgAsString(2);
//            Event_Renamed.RestoreLabel(ref arglname);
//            ExecRestoreEventCmdRet = LineNum + 1;
//            return ExecRestoreEventCmdRet;
//        }

//        private int ExecRideCmd()
//        {
//            int ExecRideCmdRet = default;
//            Pilot p;
//            Unit u;
//            string uname;
//            short i;
//            p = GetArgAsPilot(2);
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        uname = GetArgAsString((short)3);

//                        // 指定したユニットに既に乗っている場合は何もしない
//                        if (p.Unit_Renamed is object)
//                        {
//                            {
//                                var withBlock = p.Unit_Renamed;
//                                if ((withBlock.Name ?? "") == (uname ?? "") | (withBlock.ID ?? "") == (uname ?? ""))
//                                {
//                                    ExecRideCmdRet = LineNum + 1;
//                                    return ExecRideCmdRet;
//                                }
//                            }
//                        }

//                        p.GetOff();
//                        object argIndex1 = (object)uname;
//                        u = SRC.UList.Item(ref argIndex1);
//                        if (u is null)
//                        {
//                            Event_Renamed.EventErrorMessage = "ユニット名が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 440813


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        // ユニットＩＤで指定された場合
//                        if ((u.ID ?? "") == (uname ?? ""))
//                        {
//                            p.Ride(ref u.CurrentForm());
//                            ExecRideCmdRet = LineNum + 1;
//                            return ExecRideCmdRet;
//                        }

//                        // 大文字・小文字、ひらがな・かたかなの違いを正しく判定できるように、
//                        // 名前をデータのそれとあわせる
//                        object argIndex2 = (object)uname;
//                        if (SRC.UDList.IsDefined(ref argIndex2))
//                        {
//                            UnitData localItem() { object argIndex1 = (object)uname; var ret = SRC.UDList.Item(ref argIndex1); return ret; }

//                            uname = localItem().Name;
//                        }

//                        // Rideコマンドで乗せ換えられたユニット＆パイロットの履歴を更新
//                        if ((uname ?? "") == (Event_Renamed.LastUnitName ?? ""))
//                        {
//                            Array.Resize(ref Event_Renamed.LastPilotID, Information.UBound(Event_Renamed.LastPilotID) + 1 + 1);
//                        }
//                        else
//                        {
//                            Event_Renamed.LastUnitName = uname;
//                            Event_Renamed.LastPilotID = new string[2];
//                        }

//                        Event_Renamed.LastPilotID[Information.UBound(Event_Renamed.LastPilotID)] = p.ID;

//                        // パイロットが足りていないものを優先
//                        foreach (Unit currentU in SRC.UList)
//                        {
//                            u = currentU;
//                            {
//                                var withBlock1 = u;
//                                if ((withBlock1.Name ?? "") == (uname ?? "") & (withBlock1.Party0 ?? "") == (p.Party ?? "") & withBlock1.Status_Renamed != "破棄")
//                                {
//                                    string argfname = "ダミーユニット";
//                                    if (p.IsSupport(ref u) & !withBlock1.IsFeatureAvailable(ref argfname))
//                                    {
//                                        p.Ride(ref withBlock1.CurrentForm());
//                                        ExecRideCmdRet = LineNum + 1;
//                                        return ExecRideCmdRet;
//                                    }

//                                    if (withBlock1.CurrentForm().CountPilot() < Math.Abs(withBlock1.Data.PilotNum))
//                                    {
//                                        p.Ride(ref withBlock1.CurrentForm());
//                                        ExecRideCmdRet = LineNum + 1;
//                                        return ExecRideCmdRet;
//                                    }
//                                }
//                            }
//                        }

//                        // 空きがなければ今までRideコマンドで指定されてないユニットに乗り込む
//                        foreach (Unit currentU1 in SRC.UList)
//                        {
//                            u = currentU1;
//                            if ((u.Name ?? "") == (uname ?? "") & (u.Party0 ?? "") == (p.Party ?? "") & u.Status_Renamed != "破棄")
//                            {
//                                if ((int)u.CurrentForm().CountPilot() > 0)
//                                {
//                                    // 今までにRideコマンドで指定されているか判定
//                                    var loopTo = (short)(Information.UBound(Event_Renamed.LastPilotID) - 1);
//                                    for (i = (short)1; i <= loopTo; i++)
//                                    {
//                                        if ((u.CurrentForm().MainPilot().ID ?? "") == (Event_Renamed.LastPilotID[(int)i] ?? ""))
//                                        {
//                                            goto NextUnit;
//                                        }
//                                    }

//                                    object argIndex3 = (object)1;
//                                    u.CurrentForm().Pilot(ref argIndex3).GetOff(true);
//                                }

//                                p.Ride(ref u.CurrentForm());
//                                ExecRideCmdRet = LineNum + 1;
//                                return ExecRideCmdRet;
//                            }

//                            NextUnit:
//                            ;
//                        }

//                        // それでも見つからなければ無差別で……
//                        foreach (Unit currentU2 in SRC.UList)
//                        {
//                            u = currentU2;
//                            if ((u.Name ?? "") == (uname ?? "") & (u.Party0 ?? "") == (p.Party ?? "") & u.Status_Renamed != "破棄")
//                            {
//                                if ((int)u.CurrentForm().CountPilot() > 0)
//                                {
//                                    object argIndex4 = (object)1;
//                                    u.CurrentForm().Pilot(ref argIndex4).GetOff(true);
//                                }

//                                p.Ride(ref u.CurrentForm());
//                                // 乗り込み履歴を初期化
//                                Event_Renamed.LastPilotID = new string[2];
//                                Event_Renamed.LastPilotID[1] = p.ID;
//                                ExecRideCmdRet = LineNum + 1;
//                                return ExecRideCmdRet;
//                            }
//                        }

//                        Event_Renamed.EventErrorMessage = p.Name + "が乗り込むための" + uname + "が存在しません";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 443670


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }

//                case 2:
//                    {
//                        // 指定したユニットに既に乗っている場合は何もしない
//                        if (ReferenceEquals(p.Unit_Renamed, Event_Renamed.SelectedUnitForEvent))
//                        {
//                            ExecRideCmdRet = LineNum + 1;
//                            return ExecRideCmdRet;
//                        }

//                        {
//                            var withBlock2 = Event_Renamed.SelectedUnitForEvent;
//                            if (withBlock2.CountPilot() == Math.Abs(withBlock2.Data.PilotNum) & !p.IsSupport(ref Event_Renamed.SelectedUnitForEvent))
//                            {
//                                // MOD START マージ
//                                // .Pilot(1).GetOff
//                                object argIndex5 = (object)1;
//                                withBlock2.Pilot(ref argIndex5).GetOff(true);
//                                // MOD END マージ
//                            }
//                        }

//                        p.GetOff();
//                        p.Ride(ref Event_Renamed.SelectedUnitForEvent);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Rideコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 444397


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecRideCmdRet = LineNum + 1;
//            return ExecRideCmdRet;
//        }

//        private int ExecSaveDataCmd()
//        {
//            int ExecSaveDataCmdRet = default;
//            string fname, save_path = default;
//            short ret;
//            if ((int)ArgNum == 2)
//            {
//                fname = GetArgAsString((short)2);
//            }
//            else if ((int)ArgNum == 1)
//            {
//                // 一旦「常に手前に表示」を解除
//                if (My.MyProject.Forms.frmListBox.Visible)
//                {
//                    ret = (short)GUI.SetWindowPos(My.MyProject.Forms.frmListBox.Handle.ToInt32(), -2, 0, 0, 0, 0, 0x3);
//                }

//                string argdtitle = "データセーブ";
//                string argexpr = "セーブデータファイル名";
//                string argdefault_file = Expression.GetValueAsString(ref argexpr);
//                string argftype = "ｾｰﾌﾞﾃﾞｰﾀ";
//                string argfsuffix = "src";
//                string argftype2 = "";
//                string argfsuffix2 = "";
//                string argftype3 = "";
//                string argfsuffix3 = "";
//                fname = FileDialog.SaveFileDialog(ref argdtitle, ref SRC.ScenarioPath, ref argdefault_file, (short)2, ref argftype, ref argfsuffix, ftype2: ref argftype2, fsuffix2: ref argfsuffix2, ftype3: ref argftype3, fsuffix3: ref argfsuffix3);

//                // 再び「常に手前に表示」
//                if (My.MyProject.Forms.frmListBox.Visible)
//                {
//                    ret = (short)GUI.SetWindowPos(My.MyProject.Forms.frmListBox.Handle.ToInt32(), -1, 0, 0, 0, 0, 0x3);
//                }

//                // キャンセル？
//                if (string.IsNullOrEmpty(fname))
//                {
//                    ExecSaveDataCmdRet = LineNum + 1;
//                    return ExecSaveDataCmdRet;
//                }

//                // セーブ先はシナリオフォルダ？
//                if (Strings.InStr(fname, @"\") > 0)
//                {
//                    string argstr2 = @"\";
//                    save_path = Strings.Left(fname, (int)GeneralLib.InStr2(ref fname, ref argstr2));
//                }
//                // UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
//                if ((FileSystem.Dir(save_path) ?? "") != (FileSystem.Dir(SRC.ScenarioPath) ?? ""))
//                {
//                    if ((int)Interaction.MsgBox("セーブファイルはシナリオフォルダにないと読み込めません。" + Constants.vbCr + Constants.vbLf + "このままセーブしますか？", (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Question)) != 1)
//                    {
//                        ExecSaveDataCmdRet = LineNum + 1;
//                        return ExecSaveDataCmdRet;
//                    }
//                }
//            }
//            else
//            {
//                Event_Renamed.EventErrorMessage = "SaveDataコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 446364


//                Input:
//                            Error(0)

//                 */
//            }

//            if (!string.IsNullOrEmpty(fname))
//            {
//                SRC.UList.Update(); // 追加パイロットを消去
//                SRC.SaveData(ref fname);
//            }

//            ExecSaveDataCmdRet = LineNum + 1;
//            return ExecSaveDataCmdRet;
//        }

//        private int ExecSelectCmd()
//        {
//            int ExecSelectCmdRet = default;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Selectコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 446722


//                Input:
//                            Error(0)

//                 */
//            }

//            Event_Renamed.SelectedUnitForEvent = GetArgAsUnit(2);
//            ExecSelectCmdRet = LineNum + 1;
//            return ExecSelectCmdRet;
//        }

//        private int ExecSelectTargetCmd()
//        {
//            int ExecSelectTargetCmdRet = default;
//            string pname;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "SelectTargetコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 447068


//                Input:
//                            Error(0)

//                 */
//            }

//            Event_Renamed.SelectedTargetForEvent = GetArgAsUnit(2);
//            ExecSelectTargetCmdRet = LineNum + 1;
//            return ExecSelectTargetCmdRet;
//        }

//        private int ExecSepiaCmd()
//        {
//            int ExecSepiaCmdRet = default;
//            short prev_x, prev_y;
//            bool late_refresh;
//            short i;
//            string buf;
//            late_refresh = false;
//            Map.MapDrawIsMapOnly = false;
//            var loopTo = ArgNum;
//            for (i = (short)2; i <= loopTo; i++)
//            {
//                buf = GetArgAsString(i);
//                switch (buf ?? "")
//                {
//                    case "非同期":
//                        {
//                            late_refresh = true;
//                            break;
//                        }

//                    case "マップ限定":
//                        {
//                            Map.MapDrawIsMapOnly = true;
//                            break;
//                        }

//                    default:
//                        {
//                            Event_Renamed.EventErrorMessage = "Sepiaコマンドに不正なオプション「" + buf + "」が使われています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 447791


//                            Input:
//                                                Error(0)

//                             */
//                            break;
//                        }
//                }
//            }

//            prev_x = GUI.MapX;
//            prev_y = GUI.MapY;

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;
//            string argdraw_mode = "セピア";
//            string argdraw_option = "非同期";
//            int argfilter_color = 0;
//            double argfilter_trans_par = 0d;
//            GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, filter_color: ref argfilter_color, filter_trans_par: ref argfilter_trans_par);
//            foreach (Unit u in SRC.UList)
//            {
//                {
//                    var withBlock = u;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        if (withBlock.BitmapID == 0)
//                        {
//                            object argIndex1 = withBlock.Name;
//                            {
//                                var withBlock1 = SRC.UList.Item(ref argIndex1);
//                                string argfname = "ダミーユニット";
//                                if ((u.Party0 ?? "") == (withBlock1.Party0 ?? "") & withBlock1.BitmapID != 0 & (u.get_Bitmap(false) ?? "") == (withBlock1.get_Bitmap(false) ?? "") & !withBlock1.IsFeatureAvailable(ref argfname))
//                                {
//                                    u.BitmapID = withBlock1.BitmapID;
//                                }
//                                else
//                                {
//                                    u.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                }
//                            }

//                            withBlock.Name = Conversions.ToString(argIndex1);
//                        }
//                    }
//                }
//            }

//            GUI.Center(prev_x, prev_y);
//            GUI.RedrawScreen(late_refresh);

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecSepiaCmdRet = LineNum + 1;
//            return ExecSepiaCmdRet;
//        }

//        private int ExecSetCmd()
//        {
//            int ExecSetCmdRet = default;
//            Expression.ValueType etype;
//            var str_result = default(string);
//            var num_result = default(double);
//            short num;
//            num = ArgNum;
//            if ((int)num > 3)
//            {
//                // 過去のバージョンのシナリオを読み込めるようにするため、
//                // Setコマンドの後ろの「#」形式のコメントは無視する
//                if (Strings.Left(GetArg((short)4), 1) == "#")
//                {
//                    num = (short)3;
//                }
//                else
//                {
//                    Event_Renamed.EventErrorMessage = "Setコマンドの引数の数が違います";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 449659


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }

//            switch (num)
//            {
//                case 2:
//                    {
//                        string argvname = GetArg(2);
//                        Expression.SetVariableAsLong(ref argvname, 1);
//                        break;
//                    }

//                case 3:
//                    {
//                        switch (ArgsType[3])
//                        {
//                            case Expression.ValueType.UndefinedType:
//                                {
//                                    etype = Expression.EvalTerm(ref strArgs[3], ref Expression.ValueType.UndefinedType, ref str_result, ref num_result);
//                                    if (etype == Expression.ValueType.NumericType)
//                                    {
//                                        string argvname1 = GetArg(2);
//                                        Expression.SetVariableAsDouble(ref argvname1, num_result);
//                                    }
//                                    else
//                                    {
//                                        string argvname2 = GetArg(2);
//                                        Expression.SetVariableAsString(ref argvname2, ref str_result);
//                                    }

//                                    break;
//                                }

//                            case Expression.ValueType.StringType:
//                                {
//                                    string argvname3 = GetArg(2);
//                                    Expression.SetVariableAsString(ref argvname3, ref strArgs[3]);
//                                    break;
//                                }

//                            case Expression.ValueType.NumericType:
//                                {
//                                    string argvname4 = GetArg(2);
//                                    Expression.SetVariableAsDouble(ref argvname4, dblArgs[3]);
//                                    break;
//                                }
//                        }

//                        break;
//                    }
//            }

//            ExecSetCmdRet = LineNum + 1;
//            return ExecSetCmdRet;
//        }

//        private int ExecSetBulletCmd()
//        {
//            int ExecSetBulletCmdRet = default;
//            string wname;
//            short wid, num;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 4:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        wname = GetArgAsString((short)3);
//                        num = (short)GetArgAsLong((short)4);
//                        break;
//                    }

//                case 3:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        wname = GetArgAsString((short)2);
//                        num = (short)GetArgAsLong((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "SetBulletコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 451174


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (Information.IsNumeric(wname))
//            {
//                wid = (short)GeneralLib.StrToLng(ref wname);
//                if ((int)wid < 1 | u.CountWeapon() < wid)
//                {
//                    Event_Renamed.EventErrorMessage = "武器の番号「" + wname + "」が間違っています";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 451471


//                    Input:
//                                        Error(0)

//                     */
//                }
//            }
//            else
//            {
//                var loopTo = u.CountWeapon();
//                for (wid = (short)1; wid <= loopTo; wid++)
//                {
//                    if ((u.Weapon(wid).Name ?? "") == (wname ?? ""))
//                    {
//                        break;
//                    }
//                }

//                if ((int)wid < 1 | u.CountWeapon() < wid)
//                {
//                    Event_Renamed.EventErrorMessage = u.Name + "は武器「" + wname + "」を持っていません";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 451756


//                    Input:
//                                        Error(0)

//                     */
//                }
//            }

//            u.SetBullet(wid, (short)GeneralLib.MinLng(num, u.MaxBullet(wid)));
//            ExecSetBulletCmdRet = LineNum + 1;
//            return ExecSetBulletCmdRet;
//        }

//        private int ExecSetMessageCmd()
//        {
//            int ExecSetMessageCmdRet = default;
//            Unit u;
//            string pname = default, pname0 = default;
//            string sit;
//            string selected_msg;
//            switch (ArgNum)
//            {
//                case 4:
//                    {
//                        pname = GetArgAsString((short)2);
//                        object argIndex1 = (object)pname;
//                        u = SRC.UList.Item2(ref argIndex1);
//                        if (u is null)
//                        {
//                            {
//                                var withBlock = SRC.PList;
//                                bool localIsDefined1() { object argIndex1 = (object)pname; var ret = withBlock.IsDefined(ref argIndex1); return ret; }

//                                if (!localIsDefined1())
//                                {
//                                    pname0 = pname;
//                                    if (Strings.InStr(pname0, "(") > 0)
//                                    {
//                                        string argstr2 = "(";
//                                        pname0 = Strings.Left(pname0, (int)GeneralLib.InStr2(ref pname0, ref argstr2) - 1);
//                                    }

//                                    bool localIsDefined() { object argIndex1 = (object)pname0; var ret = withBlock.IsDefined(ref argIndex1); return ret; }

//                                    if (!localIsDefined())
//                                    {
//                                        Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 452698


//                                        Input:
//                                                                        Error(0)

//                                         */
//                                    }

//                                    Pilot localItem() { object argIndex1 = (object)pname0; var ret = withBlock.Item(ref argIndex1); return ret; }

//                                    u = localItem().Unit_Renamed;
//                                }
//                                else
//                                {
//                                    Pilot localItem1() { object argIndex1 = (object)pname; var ret = withBlock.Item(ref argIndex1); return ret; }

//                                    u = localItem1().Unit_Renamed;
//                                }
//                            }

//                            if (u is null)
//                            {
//                                Event_Renamed.EventErrorMessage = "「" + pname + "」はユニットに乗っていません";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 452962


//                                Input:
//                                                        Error(0)

//                                 */
//                            }
//                        }
//                        else if ((int)u.CountPilot() == 0)
//                        {
//                            Event_Renamed.EventErrorMessage = "指定されたユニットにはパイロットが乗っていません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 453108


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        sit = GetArgAsString((short)3);
//                        selected_msg = GetArgAsString((short)4);
//                        break;
//                    }

//                case 3:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        if ((int)u.CountPilot() == 0)
//                        {
//                            Event_Renamed.EventErrorMessage = "指定されたユニットにはパイロットが乗っていません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 453392


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        sit = GetArgAsString((short)2);
//                        selected_msg = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "SetMessageコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 453587


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (selected_msg == "解除")
//            {
//                // メッセージ用変数を削除
//                string argvar_name = "Message(" + u.MainPilot().ID + "," + sit + ")";
//                Expression.UndefineVariable(ref argvar_name);
//            }
//            else if (!string.IsNullOrEmpty(pname0))
//            {
//                // 表情指定付きメッセージをローカル変数として登録する
//                string argvname1 = "Message(" + u.MainPilot().ID + "," + sit + ")";
//                string argnew_value = pname + "::" + selected_msg;
//                Expression.SetVariableAsString(ref argvname1, ref argnew_value);
//            }
//            else
//            {
//                // メッセージをローカル変数として登録する
//                string argvname = "Message(" + u.MainPilot().ID + "," + sit + ")";
//                Expression.SetVariableAsString(ref argvname, ref selected_msg);
//            }

//            ExecSetMessageCmdRet = LineNum + 1;
//            return ExecSetMessageCmdRet;
//        }

//        private int ExecSetRelationCmd()
//        {
//            int ExecSetRelationCmdRet = default;
//            string pname1, pname2;
//            string vname;
//            short rel;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        pname1 = Event_Renamed.SelectedUnitForEvent.MainPilot().Name;
//                        pname2 = GetArgAsString((short)2);
//                        bool localIsDefined() { object argIndex1 = (object)pname2; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//                        if (!localIsDefined())
//                        {
//                            Event_Renamed.EventErrorMessage = "キャラクター名が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 454582


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        PilotData localItem() { object argIndex1 = (object)pname2; var ret = SRC.PDList.Item(ref argIndex1); return ret; }

//                        pname2 = localItem().Name;
//                        rel = (short)GetArgAsLong((short)3);
//                        break;
//                    }

//                case 4:
//                    {
//                        pname1 = GetArgAsString((short)2);
//                        bool localIsDefined1() { object argIndex1 = (object)pname1; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//                        if (!localIsDefined1())
//                        {
//                            Event_Renamed.EventErrorMessage = "キャラクター名が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 454886


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        PilotData localItem1() { object argIndex1 = (object)pname1; var ret = SRC.PDList.Item(ref argIndex1); return ret; }

//                        pname1 = localItem1().Name;
//                        pname2 = GetArgAsString((short)3);
//                        bool localIsDefined2() { object argIndex1 = (object)pname2; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//                        if (!localIsDefined2())
//                        {
//                            Event_Renamed.EventErrorMessage = "キャラクター名が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 455149


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        PilotData localItem2() { object argIndex1 = (object)pname2; var ret = SRC.PDList.Item(ref argIndex1); return ret; }

//                        pname2 = localItem2().Name;
//                        rel = (short)GetArgAsLong((short)4);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "SetRelationコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 455367


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            vname = "関係:" + pname1 + ":" + pname2;
//            if (rel != 0)
//            {
//                if (!Expression.IsGlobalVariableDefined(ref vname))
//                {
//                    Expression.DefineGlobalVariable(ref vname);
//                }

//                Expression.SetVariableAsLong(ref vname, rel);
//            }
//            else if (Expression.IsGlobalVariableDefined(ref vname))
//            {
//                Expression.UndefineVariable(ref vname);
//            }

//            // 信頼度補正による気力修正を更新
//            string argoname = "信頼度補正";
//            if (Expression.IsOptionDefined(ref argoname))
//            {
//                object argIndex1 = pname1;
//                if (SRC.PList.IsDefined(ref argIndex1))
//                {
//                    Pilot localItem3() { object argIndex1 = pname1; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                    localItem3().UpdateSupportMod();
//                }

//                object argIndex2 = pname2;
//                if (SRC.PList.IsDefined(ref argIndex2))
//                {
//                    Pilot localItem4() { object argIndex1 = pname2; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                    localItem4().UpdateSupportMod();
//                }
//            }

//            ExecSetRelationCmdRet = LineNum + 1;
//            return ExecSetRelationCmdRet;
//        }

//        private int ExecSetSkillCmd()
//        {
//            int ExecSetSkillCmdRet = default;
//            string pname;
//            string vname;
//            string slist;
//            string sname;
//            string[] sname_array;
//            double slevel;
//            double[] slevel_array;
//            var sdata = default(string);
//            string[] sdata_array;
//            short i, j;
//            if ((int)ArgNum != 4 & (int)ArgNum != 5)
//            {
//                Event_Renamed.EventErrorMessage = "SetSkillコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 456672


//                Input:
//                            Error(0)

//                 */
//            }

//            pname = GetArgAsString(2);
//            bool localIsDefined() { object argIndex1 = pname; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//            object argIndex1 = pname;
//            if (SRC.PList.IsDefined(ref argIndex1))
//            {
//                Pilot localItem() { object argIndex1 = (object)pname; var ret = SRC.PList.Item(ref argIndex1); return ret; }

//                pname = localItem().ID;
//            }
//            else if (localIsDefined())
//            {
//                PilotData localItem1() { object argIndex1 = (object)pname; var ret = SRC.PDList.Item(ref argIndex1); return ret; }

//                pname = localItem1().Name;
//            }
//            else
//            {
//                Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 457050


//                Input:
//                            Error(0)

//                 */
//            }

//            sname = GetArgAsString(3);
//            slevel = GetArgAsDouble(4);
//            if (ArgNum == 5)
//            {
//                sdata = GetArgAsString(5);
//            }

//            // エリアスが定義されている？
//            object argIndex3 = sname;
//            if (SRC.ALDList.IsDefined(ref argIndex3))
//            {
//                object argIndex2 = sname;
//                {
//                    var withBlock = SRC.ALDList.Item(ref argIndex2);
//                    sname_array = new string[(withBlock.Count + 1)];
//                    slevel_array = new double[(withBlock.Count + 1)];
//                    sdata_array = new string[(withBlock.Count + 1)];
//                    var loopTo = withBlock.Count;
//                    for (i = 1; i <= loopTo; i++)
//                    {
//                        string localLIndex() { string arglist = withBlock.get_AliasData(i); var ret = GeneralLib.LIndex(ref arglist, 1); withBlock.get_AliasData(i) = arglist; return ret; }

//                        if (localLIndex() == "解説")
//                        {
//                            if (string.IsNullOrEmpty(sdata))
//                            {
//                                sname_array[i] = withBlock.get_AliasType(i);
//                            }
//                            else
//                            {
//                                sname_array[i] = GeneralLib.LIndex(ref sdata, 1);
//                            }

//                            if (slevel == 0d)
//                            {
//                                slevel_array[i] = 0d;
//                            }
//                            else
//                            {
//                                slevel_array[i] = SRC.DEFAULT_LEVEL;
//                            }

//                            sdata_array[i] = withBlock.get_AliasData(i);
//                        }
//                        else
//                        {
//                            sname_array[i] = withBlock.get_AliasType(i);
//                            if (slevel == -1)
//                            {
//                                slevel_array[i] = withBlock.get_AliasLevel(i);
//                            }
//                            else if (withBlock.get_AliasLevelIsPlusMod(i))
//                            {
//                                slevel_array[i] = slevel + withBlock.get_AliasLevel(i);
//                            }
//                            else if (withBlock.get_AliasLevelIsMultMod(i))
//                            {
//                                slevel_array[i] = slevel * withBlock.get_AliasLevel(i);
//                            }
//                            else
//                            {
//                                slevel_array[i] = slevel;
//                            }

//                            if (string.IsNullOrEmpty(sdata))
//                            {
//                                sdata_array[i] = withBlock.get_AliasData(i);
//                            }
//                            else
//                            {
//                                string localListTail() { string arglist = withBlock.get_AliasData(i); var ret = GeneralLib.ListTail(ref arglist, 2); withBlock.get_AliasData(i) = arglist; return ret; }

//                                sdata_array[i] = Strings.Trim(sdata + " " + localListTail());
//                            }

//                            if (withBlock.get_AliasLevelIsPlusMod(i) | withBlock.get_AliasLevelIsMultMod(i))
//                            {
//                                sdata_array[i] = GeneralLib.LIndex(ref sdata_array[i], 1) + "Lv" + Microsoft.VisualBasic.Compatibility.VB6.Support.Format(slevel) + " " + GeneralLib.ListTail(ref sdata_array[i], 2);
//                                sdata_array[i] = Strings.Trim(sdata_array[i]);
//                            }
//                        }
//                    }
//                }
//            }
//            else
//            {
//                sname_array = new string[2];
//                slevel_array = new double[2];
//                sdata_array = new string[2];
//                sname_array[1] = sname;
//                slevel_array[1] = slevel;
//                sdata_array[1] = sdata;
//            }

//            var loopTo1 = (short)Information.UBound(sname_array);
//            for (i = 1; i <= loopTo1; i++)
//            {
//                sname = sname_array[i];
//                slevel = slevel_array[i];
//                sdata = sdata_array[i];
//                if (string.IsNullOrEmpty(sname))
//                {
//                    goto NextSkill;
//                }

//                // アビリティ一覧表示用にSetSkillが適用された能力の一覧用変数を作成
//                bool localIsGlobalVariableDefined() { string argvname = "Ability(" + pname + ")"; var ret = Expression.IsGlobalVariableDefined(ref argvname); return ret; }

//                if (!localIsGlobalVariableDefined())
//                {
//                    string argvname = "Ability(" + pname + ")";
//                    Expression.DefineGlobalVariable(ref argvname);
//                    slist = sname;
//                }
//                else
//                {
//                    // UPGRADE_WARNING: オブジェクト GlobalVariableList.Item().StringValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                    slist = Conversions.ToString(Event_Renamed.GlobalVariableList["Ability(" + pname + ")"].StringValue);
//                    var loopTo2 = GeneralLib.LLength(ref slist);
//                    for (j = 1; j <= loopTo2; j++)
//                    {
//                        if ((sname ?? "") == (GeneralLib.LIndex(ref slist, j) ?? ""))
//                        {
//                            break;
//                        }
//                    }

//                    if (j > GeneralLib.LLength(ref slist))
//                    {
//                        slist = slist + " " + sname;
//                    }
//                }

//                string argvname1 = "Ability(" + pname + ")";
//                Expression.SetVariableAsString(ref argvname1, ref slist);

//                // 今回SetSkillが適用された能力sname用変数を作成
//                vname = "Ability(" + pname + "," + sname + ")";
//                if (!Expression.IsGlobalVariableDefined(ref vname))
//                {
//                    Expression.DefineGlobalVariable(ref vname);
//                }

//                if (!string.IsNullOrEmpty(sdata))
//                {
//                    // 別名指定があった場合
//                    string argnew_value = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(slevel) + " " + sdata;
//                    Expression.SetVariableAsString(ref vname, ref argnew_value);

//                    // 必要技能用
//                    if (sdata != "非表示" & GeneralLib.LIndex(ref sdata, 1) != "解説")
//                    {
//                        vname = "Ability(" + pname + "," + GeneralLib.LIndex(ref sdata, 1) + ")";
//                        if (!Expression.IsGlobalVariableDefined(ref vname))
//                        {
//                            Expression.DefineGlobalVariable(ref vname);
//                        }

//                        string argnew_value1 = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(slevel);
//                        Expression.SetVariableAsString(ref vname, ref argnew_value1);
//                    }
//                }
//                else
//                {
//                    string argnew_value2 = Microsoft.VisualBasic.Compatibility.VB6.Support.Format(slevel);
//                    Expression.SetVariableAsString(ref vname, ref argnew_value2);
//                }

//                NextSkill:
//                ;
//            }

//            // パイロットやユニットのステータスをアップデート
//            object argIndex5 = pname;
//            if (SRC.PList.IsDefined(ref argIndex5))
//            {
//                object argIndex4 = pname;
//                {
//                    var withBlock1 = SRC.PList.Item(ref argIndex4);
//                    withBlock1.Update();
//                    if (withBlock1.Unit_Renamed is object)
//                    {
//                        withBlock1.Unit_Renamed.Update();
//                        if (withBlock1.Unit_Renamed.Status_Renamed == "出撃")
//                        {
//                            SRC.PList.UpdateSupportMod(withBlock1.Unit_Renamed);
//                        }
//                    }
//                }
//            }

//            ExecSetSkillCmdRet = LineNum + 1;
//            return ExecSetSkillCmdRet;
//        }

//        private int ExecSetStatusCmd()
//        {
//            int ExecSetStatusCmdRet = default;
//            Unit u;
//            string cname;
//            switch (ArgNum)
//            {
//                case 4:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        {
//                            var withBlock = u;
//                            cname = GetArgAsString((short)3);
//                            string argcdata = "";
//                            withBlock.AddCondition(ref cname, (short)GetArgAsLong((short)4), cdata: ref argcdata);
//                            if (withBlock.Status_Renamed == "出撃")
//                            {
//                                GUI.PaintUnitBitmap(ref u);
//                            }

//                            if (cname != "非操作")
//                            {
//                                withBlock.Update();
//                            }
//                        }

//                        break;
//                    }

//                case 3:
//                    {
//                        if (Event_Renamed.SelectedUnitForEvent is object)
//                        {
//                            {
//                                var withBlock1 = Event_Renamed.SelectedUnitForEvent;
//                                cname = GetArgAsString((short)2);
//                                string argcdata1 = "";
//                                withBlock1.AddCondition(ref cname, (short)GetArgAsLong((short)3), cdata: ref argcdata1);
//                                if (withBlock1.Status_Renamed == "出撃")
//                                {
//                                    GUI.PaintUnitBitmap(ref Event_Renamed.SelectedUnitForEvent);
//                                }

//                                if (cname != "非操作")
//                                {
//                                    withBlock1.Update();
//                                }
//                            }
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "SetStatusコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 462730


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecSetStatusCmdRet = LineNum + 1;
//            return ExecSetStatusCmdRet;
//        }

//        // ADD START 240a
//        private int ExecSetStatusStringColor()
//        {
//            int ExecSetStatusStringColorRet = default;
//            string cname, opt, target;
//            int color;
//            // 引数チェック
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "StatusStringColorコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 463076


//                Input:
//                            Error(0)

//                 */
//            }

//            // 変更色を取得
//            opt = GetArgAsString(2);
//            if (Strings.Asc(opt) != 35 | Strings.Len(opt) != 7)
//            {
//                Event_Renamed.EventErrorMessage = "色指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 463326


//                Input:
//                            Error(0)

//                 */
//            }

//            cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//            StringType.MidStmtStr(ref cname, 1, 2, "&H");
//            var midTmp = Strings.Mid(opt, 6, 2);
//            StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//            var midTmp1 = Strings.Mid(opt, 4, 2);
//            StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//            var midTmp2 = Strings.Mid(opt, 2, 2);
//            StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//            if (!Information.IsNumeric(cname))
//            {
//                Event_Renamed.EventErrorMessage = "色指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 463818


//                Input:
//                            Error(0)

//                 */
//            }

//            color = Conversions.ToInteger(cname);

//            // 変更対象を取得
//            target = GetArgAsString(3);
//            if (target != "通常" & target != "能力名" & target != "有効" & target != "無効")
//            {
//                Event_Renamed.EventErrorMessage = "設定対象の指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 464066


//                Input:
//                            Error(0)

//                 */
//            }

//            // 処理実行
//            switch (target ?? "")
//            {
//                case "通常":
//                    {
//                        Status.StatusFontColorNormalString = color;
//                        // Global変数に保存
//                        string argvname1 = "StatusWindow(StringColor)";
//                        if (!Expression.IsGlobalVariableDefined(ref argvname1))
//                        {
//                            string argvname = "StatusWindow(StringColor)";
//                            Expression.DefineGlobalVariable(ref argvname);
//                        }

//                        string argvname2 = "StatusWindow(StringColor)";
//                        Expression.SetVariableAsLong(ref argvname2, color);
//                        break;
//                    }

//                case "能力名":
//                    {
//                        Status.StatusFontColorAbilityName = color;
//                        // Global変数に保存
//                        string argvname4 = "StatusWindow(ANameColor)";
//                        if (!Expression.IsGlobalVariableDefined(ref argvname4))
//                        {
//                            string argvname3 = "StatusWindow(ANameColor)";
//                            Expression.DefineGlobalVariable(ref argvname3);
//                        }

//                        string argvname5 = "StatusWindow(ANameColor)";
//                        Expression.SetVariableAsLong(ref argvname5, color);
//                        break;
//                    }

//                case "有効":
//                    {
//                        Status.StatusFontColorAbilityEnable = color;
//                        // Global変数に保存
//                        string argvname7 = "StatusWindow(EnableColor)";
//                        if (!Expression.IsGlobalVariableDefined(ref argvname7))
//                        {
//                            string argvname6 = "StatusWindow(EnableColor)";
//                            Expression.DefineGlobalVariable(ref argvname6);
//                        }

//                        string argvname8 = "StatusWindow(EnableColor)";
//                        Expression.SetVariableAsLong(ref argvname8, color);
//                        break;
//                    }

//                case "無効":
//                    {
//                        Status.StatusFontColorAbilityDisable = color;
//                        // Global変数に保存
//                        string argvname10 = "StatusWindow(DisableColor)";
//                        if (!Expression.IsGlobalVariableDefined(ref argvname10))
//                        {
//                            string argvname9 = "StatusWindow(DisableColor)";
//                            Expression.DefineGlobalVariable(ref argvname9);
//                        }

//                        string argvname11 = "StatusWindow(DisableColor)";
//                        Expression.SetVariableAsLong(ref argvname11, color);
//                        break;
//                    }
//            }

//            ExecSetStatusStringColorRet = LineNum + 1;
//            return ExecSetStatusStringColorRet;
//        }
//        // ADD  END  240a

//        private int ExecSetStockCmd()
//        {
//            int ExecSetStockCmdRet = default;
//            string aname;
//            short aid, num;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 4:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        aname = GetArgAsString((short)3);
//                        num = (short)GetArgAsLong((short)4);
//                        break;
//                    }

//                case 3:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        aname = GetArgAsString((short)2);
//                        num = (short)GetArgAsLong((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "SetStockコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 466229


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (Information.IsNumeric(aname))
//            {
//                aid = (short)GeneralLib.StrToLng(ref aname);
//                if ((int)aid < 1 | u.CountAbility() < aid)
//                {
//                    Event_Renamed.EventErrorMessage = "アビリティの番号「" + aname + "」が間違っています";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 466530


//                    Input:
//                                        Error(0)

//                     */
//                }
//            }
//            else
//            {
//                var loopTo = u.CountAbility();
//                for (aid = (short)1; aid <= loopTo; aid++)
//                {
//                    if ((u.Ability(aid).Name ?? "") == (aname ?? ""))
//                    {
//                        break;
//                    }
//                }

//                if ((int)aid < 1 | u.CountAbility() < aid)
//                {
//                    Event_Renamed.EventErrorMessage = u.Name + "はアビリティ「" + aname + "」を持っていません";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 466821


//                    Input:
//                                        Error(0)

//                     */
//                }
//            }

//            u.SetStock(aid, (short)GeneralLib.MinLng(num, u.MaxStock(aid)));
//            ExecSetStockCmdRet = LineNum + 1;
//            return ExecSetStockCmdRet;
//        }
//        // ADD START 240a
//        private int ExecSetWindowColor()
//        {
//            int ExecSetWindowColorRet = default;
//            string opt, cname, target;
//            int color;
//            bool isTargetLine, isTargetBG;

//            // 引数チェック
//            if ((int)ArgNum != 2 & (int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "SetWindowColorコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 467316


//                Input:
//                            Error(0)

//                 */
//            }

//            // 色取得
//            opt = GetArgAsString(2);
//            if (Strings.Asc(opt) != 35 | Strings.Len(opt) != 7)
//            {
//                Event_Renamed.EventErrorMessage = "色指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 467563


//                Input:
//                            Error(0)

//                 */
//            }

//            cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//            StringType.MidStmtStr(ref cname, 1, 2, "&H");
//            var midTmp = Strings.Mid(opt, 6, 2);
//            StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//            var midTmp1 = Strings.Mid(opt, 4, 2);
//            StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//            var midTmp2 = Strings.Mid(opt, 2, 2);
//            StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//            if (!Information.IsNumeric(cname))
//            {
//                Event_Renamed.EventErrorMessage = "色指定が不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 468055


//                Input:
//                            Error(0)

//                 */
//            }

//            color = Conversions.ToInteger(cname);

//            // 変更対象取得
//            isTargetLine = false;
//            isTargetBG = false;
//            if ((int)ArgNum == 3)
//            {
//                target = GetArgAsString((short)3);
//                if (target == "枠")
//                {
//                    isTargetLine = true;
//                }
//                else if (target == "背景")
//                {
//                    isTargetBG = true;
//                }
//                else
//                {
//                    Event_Renamed.EventErrorMessage = "色設定対象の指定が不正です";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 468406


//                    Input:
//                                    Error(0)

//                     */
//                }
//            }

//            // 処理開始
//            if (isTargetLine)
//            {
//                Status.StatusWindowFrameColor = color;
//                // Global変数に保存
//                string argvname1 = "StatusWindow(FrameColor)";
//                if (!Expression.IsGlobalVariableDefined(ref argvname1))
//                {
//                    string argvname = "StatusWindow(FrameColor)";
//                    Expression.DefineGlobalVariable(ref argvname);
//                }

//                string argvname2 = "StatusWindow(FrameColor)";
//                Expression.SetVariableAsLong(ref argvname2, color);
//            }
//            else if (isTargetBG)
//            {
//                Status.StatusWindowBackBolor = color;
//                // Global変数に保存
//                string argvname4 = "StatusWindow(BackBolor)";
//                if (!Expression.IsGlobalVariableDefined(ref argvname4))
//                {
//                    string argvname3 = "StatusWindow(BackBolor)";
//                    Expression.DefineGlobalVariable(ref argvname3);
//                }

//                string argvname5 = "StatusWindow(BackBolor)";
//                Expression.SetVariableAsLong(ref argvname5, color);
//            }
//            else if (!isTargetLine & !isTargetBG)
//            {
//                Status.StatusWindowFrameColor = color;
//                // Global変数に保存
//                string argvname7 = "StatusWindow(FrameColor)";
//                if (!Expression.IsGlobalVariableDefined(ref argvname7))
//                {
//                    string argvname6 = "StatusWindow(FrameColor)";
//                    Expression.DefineGlobalVariable(ref argvname6);
//                }

//                string argvname8 = "StatusWindow(FrameColor)";
//                Expression.SetVariableAsLong(ref argvname8, color);
//                Status.StatusWindowBackBolor = color;
//                // Global変数に保存
//                string argvname10 = "StatusWindow(BackBolor)";
//                if (!Expression.IsGlobalVariableDefined(ref argvname10))
//                {
//                    string argvname9 = "StatusWindow(BackBolor)";
//                    Expression.DefineGlobalVariable(ref argvname9);
//                }

//                string argvname11 = "StatusWindow(BackBolor)";
//                Expression.SetVariableAsLong(ref argvname11, color);
//            }

//            ExecSetWindowColorRet = LineNum + 1;
//            return ExecSetWindowColorRet;
//        }

//        private int ExecSetWindowFrameWidth()
//        {
//            int ExecSetWindowFrameWidthRet = default;
//            int width;
//            // 引数チェック
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "SetWindowColorコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 470209


//                Input:
//                            Error(0)

//                 */
//            }
//            // 幅取得
//            width = GetArgAsLong(2);
//            // 処理開始
//            Status.StatusWindowFrameWidth = width;
//            // Global変数に保存
//            string argvname1 = "StatusWindow(FrameWidth)";
//            if (!Expression.IsGlobalVariableDefined(ref argvname1))
//            {
//                string argvname = "StatusWindow(FrameWidth)";
//                Expression.DefineGlobalVariable(ref argvname);
//            }

//            string argvname2 = "StatusWindow(FrameWidth)";
//            Expression.SetVariableAsLong(ref argvname2, width);
//            ExecSetWindowFrameWidthRet = LineNum + 1;
//            return ExecSetWindowFrameWidthRet;
//        }
//        // ADD  END

//        private int ExecShowCmd()
//        {
//            int ExecShowCmdRet = default;
//            {
//                var withBlock = GUI.MainForm;
//                if (!withBlock.Visible)
//                {
//                    withBlock.Show();
//                    withBlock.Refresh();
//                    Application.DoEvents();
//                }
//            }

//            if (!GUI.IsPictureVisible)
//            {
//                GUI.RedrawScreen();
//            }

//            ExecShowCmdRet = LineNum + 1;
//            return ExecShowCmdRet;
//        }

//        // 互換性維持のために残している
//        private int ExecShowImageCmd()
//        {
//            int ExecShowImageCmdRet = default;
//            string fname;
//            int dw, dh;
//            short ret;
//            fname = GetArgAsString(2);
//            switch (Strings.Right(Strings.LCase(fname), 4) ?? "")
//            {
//                // 正しい画像ファイル名
//                case ".bmp":
//                case ".jpg":
//                case ".gif":
//                case ".png":
//                    {
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "不正な画像ファイル名「" + fname + "」が指定されています";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 471517


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (ArgNum > 2)
//            {
//                dw = GetArgAsLong(3);
//                dh = GetArgAsLong(4);
//            }
//            else
//            {
//                dw = SRC.DEFAULT_LEVEL;
//                dh = SRC.DEFAULT_LEVEL;
//            }

//            if (!GUI.MainForm.Visible)
//            {
//                GUI.MainForm.Show();
//            }

//            string argdraw_option = "";
//            ret = Conversions.ToShort(GUI.DrawPicture(ref fname, SRC.DEFAULT_LEVEL, SRC.DEFAULT_LEVEL, dw, dh, 0, 0, 0, 0, ref argdraw_option));
//            GUI.MainForm.picMain(0).Refresh();
//            ExecShowImageCmdRet = LineNum + 1;
//            return ExecShowImageCmdRet;
//        }

//        private int ExecShowUnitStatusCmd()
//        {
//            int ExecShowUnitStatusCmdRet = default;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                case 2:
//                    {
//                        if (GetArgAsString((short)2) == "終了")
//                        {
//                            Status.ClearUnitStatus();
//                            ExecShowUnitStatusCmdRet = LineNum + 1;
//                            return ExecShowUnitStatusCmdRet;
//                        }

//                        u = GetArgAsUnit((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "ShowUnitStatusコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 472786


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is object)
//            {
//                Status.DisplayUnitStatus(ref u);
//            }

//            ExecShowUnitStatusCmdRet = LineNum + 1;
//            return ExecShowUnitStatusCmdRet;
//        }

//        private int ExecSkipCmd()
//        {
//            int ExecSkipCmdRet = default;
//            int i;
//            short depth;

//            // 対応するループの末尾を探す
//            depth = 1;
//            var loopTo = Information.UBound(Event_Renamed.EventCmd);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                switch (Event_Renamed.EventCmd[i].Name)
//                {
//                    case Event_Renamed.CmdType.DoCmd:
//                    case Event_Renamed.CmdType.ForCmd:
//                    case Event_Renamed.CmdType.ForEachCmd:
//                        {
//                            depth = (short)(depth + 1);
//                            break;
//                        }

//                    case Event_Renamed.CmdType.LoopCmd:
//                    case Event_Renamed.CmdType.NextCmd:
//                        {
//                            depth = (short)(depth - 1);
//                            if (depth == 0)
//                            {
//                                ExecSkipCmdRet = i;
//                                return ExecSkipCmdRet;
//                            }

//                            break;
//                        }
//                }
//            }

//            Event_Renamed.EventErrorMessage = "Skipコマンドがループの外で使われています";
//            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 473755


//            Input:
//                    Error(0)

//             */
//        }

//        private object ExecSortCmd()
//        {
//            object ExecSortCmdRet = default;
//            short j, i, k;
//            bool isStringkey, isStringValue;
//            bool isSwap, isAscOrder, isKeySort;
//            string vname, buf;
//            object value_buf;
//            short num;
//            VarData var;
//            var array_buf = default(object[]);
//            var var_buf = new object[3];

//            // array_buf(opt, value)
//            // opt=0…配列の添字
//            // =1…変数のValueTyep
//            // =2…変数の値

//            if ((int)ArgNum < 2)
//            {
//                Event_Renamed.EventErrorMessage = "Sortコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 474307


//                Input:
//                            Error(0)

//                 */
//            }

//            // 初期値
//            isAscOrder = true; // ソート順を昇順似設定
//            isStringkey = false; // 配列のインデックスを数値として扱う
//            isStringValue = false; // 配列の要素を数値として扱う
//            isKeySort = false; // インデックスのみのソートではない
//            var loopTo = ArgNum;
//            for (i = (short)3; i <= loopTo; i++)
//            {
//                buf = GetArgAsString(i);
//                switch (buf ?? "")
//                {
//                    case "昇順":
//                        {
//                            isAscOrder = true;
//                            break;
//                        }

//                    case "降順":
//                        {
//                            isAscOrder = false;
//                            break;
//                        }

//                    case "数値":
//                        {
//                            isStringValue = false;
//                            break;
//                        }

//                    case "文字":
//                        {
//                            isStringValue = true;
//                            break;
//                        }

//                    case "インデックスのみ":
//                        {
//                            isKeySort = true;
//                            break;
//                        }

//                    case "文字インデックス":
//                        {
//                            isStringkey = true;
//                            break;
//                        }

//                    default:
//                        {
//                            Event_Renamed.EventErrorMessage = "Sortコマンドに不正なオプション「" + buf + "」が使われています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 474945


//                            Input:
//                                                Error(0)

//                             */
//                            break;
//                        }
//                }
//            }

//            // ソートする配列変数名
//            vname = GetArg(2);
//            if (Strings.Left(vname, 1) == "$")
//            {
//                vname = Strings.Mid(vname, 2);
//            }
//            // Eval関数
//            if (Strings.LCase(Strings.Left(vname, 5)) == "eval(")
//            {
//                if (Strings.Right(vname, 1) == ")")
//                {
//                    vname = Strings.Mid(vname, 6, Strings.Len(vname) - 6);
//                    vname = Expression.GetValueAsString(ref vname);
//                }
//            }

//            // 配列を検索し、配列要素を見つける
//            num = 0;
//            if (Expression.IsSubLocalVariableDefined(ref vname))
//            {
//                // サブルーチンローカルな配列
//                var loopTo1 = Event_Renamed.VarIndex;
//                for (i = (short)(Event_Renamed.VarIndexStack[Event_Renamed.CallDepth - 1] + 1); i <= loopTo1; i++)
//                {
//                    {
//                        var withBlock = Event_Renamed.VarStack[i];
//                        if (Strings.InStr(withBlock.Name, vname + "[") == 1)
//                        {
//                            var oldArray_buf = array_buf;
//                            array_buf = new object[3, (num + 1)];
//                            if (oldArray_buf is object)
//                                for (var i1 = 0; i1 <= oldArray_buf.Length / oldArray_buf.GetLength(1) - 1; ++i1)
//                                    Array.Copy(oldArray_buf, i1 * oldArray_buf.GetLength(1), array_buf, i1 * array_buf.GetLength(1), Math.Min(oldArray_buf.GetLength(1), array_buf.GetLength(1)));
//                            string argstr2 = "]";
//                            buf = Strings.Mid(withBlock.Name, Strings.InStr(withBlock.Name, "[") + 1, GeneralLib.InStr2(ref withBlock.Name, ref argstr2) - Strings.InStr(withBlock.Name, "[") - 1);
//                            if (!Information.IsNumeric(buf))
//                            {
//                                isStringkey = true;
//                            }

//                            if (withBlock.VariableType == Expression.ValueType.StringType)
//                            {
//                                // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                value_buf = withBlock.StringValue;
//                            }
//                            else
//                            {
//                                // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                value_buf = withBlock.NumericValue;
//                            }

//                            if (!Information.IsNumeric(value_buf))
//                            {
//                                isStringValue = true;
//                            }

//                            // UPGRADE_WARNING: オブジェクト array_buf(0, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            array_buf[0, num] = buf;
//                            // UPGRADE_WARNING: オブジェクト array_buf(1, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            array_buf[1, num] = withBlock.VariableType;
//                            // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            // UPGRADE_WARNING: オブジェクト array_buf(2, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            array_buf[2, num] = value_buf;
//                            num = (short)(num + 1);
//                        }
//                    }
//                }

//                if (num == 0)
//                {
//                    // UPGRADE_WARNING: オブジェクト ExecSortCmd の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                    ExecSortCmdRet = LineNum + 1;
//                    return ExecSortCmdRet;
//                }
//            }
//            else if (Expression.IsLocalVariableDefined(ref vname))
//            {
//                // ローカルな配列
//                foreach (VarData currentVar in Event_Renamed.LocalVariableList)
//                {
//                    var = currentVar;
//                    if (Strings.InStr(var.Name, vname + "[") == 1)
//                    {
//                        var oldArray_buf1 = array_buf;
//                        array_buf = new object[3, (num + 1)];
//                        if (oldArray_buf1 is object)
//                            for (var i2 = 0; i2 <= oldArray_buf1.Length / oldArray_buf1.GetLength(1) - 1; ++i2)
//                                Array.Copy(oldArray_buf1, i2 * oldArray_buf1.GetLength(1), array_buf, i2 * array_buf.GetLength(1), Math.Min(oldArray_buf1.GetLength(1), array_buf.GetLength(1)));
//                        string argstr21 = "]";
//                        buf = Strings.Mid(var.Name, Strings.InStr(var.Name, "[") + 1, GeneralLib.InStr2(ref var.Name, ref argstr21) - Strings.InStr(var.Name, "[") - 1);
//                        if (!Information.IsNumeric(buf))
//                        {
//                            isStringkey = true;
//                        }

//                        if (var.VariableType == Expression.ValueType.StringType)
//                        {
//                            // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            value_buf = var.StringValue;
//                        }
//                        else
//                        {
//                            // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            value_buf = var.NumericValue;
//                        }

//                        if (!Information.IsNumeric(value_buf))
//                        {
//                            isStringValue = true;
//                        }

//                        // UPGRADE_WARNING: オブジェクト array_buf(0, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                        array_buf[0, num] = buf;
//                        // UPGRADE_WARNING: オブジェクト array_buf(1, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                        array_buf[1, num] = var.VariableType;
//                        // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                        // UPGRADE_WARNING: オブジェクト array_buf(2, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                        array_buf[2, num] = value_buf;
//                        num = (short)(num + 1);
//                    }
//                }

//                if (num == 0)
//                {
//                    // UPGRADE_WARNING: オブジェクト ExecSortCmd の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                    ExecSortCmdRet = LineNum + 1;
//                    return ExecSortCmdRet;
//                }
//            }
//            else if (Expression.IsGlobalVariableDefined(ref vname))
//            {
//                // グローバルな配列
//                foreach (VarData currentVar1 in Event_Renamed.GlobalVariableList)
//                {
//                    var = currentVar1;
//                    if (Strings.InStr(var.Name, vname + "[") == 1)
//                    {
//                        var oldArray_buf2 = array_buf;
//                        array_buf = new object[3, (num + 1)];
//                        if (oldArray_buf2 is object)
//                            for (var i3 = 0; i3 <= oldArray_buf2.Length / oldArray_buf2.GetLength(1) - 1; ++i3)
//                                Array.Copy(oldArray_buf2, i3 * oldArray_buf2.GetLength(1), array_buf, i3 * array_buf.GetLength(1), Math.Min(oldArray_buf2.GetLength(1), array_buf.GetLength(1)));
//                        string argstr22 = "]";
//                        buf = Strings.Mid(var.Name, Strings.InStr(var.Name, "[") + 1, GeneralLib.InStr2(ref var.Name, ref argstr22) - Strings.InStr(var.Name, "[") - 1);
//                        if (!Information.IsNumeric(buf))
//                        {
//                            isStringkey = true;
//                        }

//                        if (var.VariableType == Expression.ValueType.StringType)
//                        {
//                            // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            value_buf = var.StringValue;
//                        }
//                        else
//                        {
//                            // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            value_buf = var.NumericValue;
//                        }

//                        if (!Information.IsNumeric(value_buf))
//                        {
//                            isStringValue = true;
//                        }

//                        // UPGRADE_WARNING: オブジェクト array_buf(0, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                        array_buf[0, num] = buf;
//                        // UPGRADE_WARNING: オブジェクト array_buf(1, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                        array_buf[1, num] = var.VariableType;
//                        // UPGRADE_WARNING: オブジェクト value_buf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                        // UPGRADE_WARNING: オブジェクト array_buf(2, num) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                        array_buf[2, num] = value_buf;
//                        num = (short)(num + 1);
//                    }
//                }

//                if (num == 0)
//                {
//                    // UPGRADE_WARNING: オブジェクト ExecSortCmd の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                    ExecSortCmdRet = LineNum + 1;
//                    return ExecSortCmdRet;
//                }
//            }

//            num = (short)(num - 1);
//            if (!isStringkey | isKeySort)
//            {
//                // 添字が数値の場合、またはインデックスのみのソートの場合、
//                // 先に添字の昇順に並び替える
//                var loopTo2 = (short)(num - 1);
//                for (i = 0; i <= loopTo2; i++)
//                {
//                    var loopTo3 = (short)(i + 1);
//                    for (j = num; j >= loopTo3; j += -1)
//                    {
//                        isSwap = false;
//                        if (isStringkey)
//                        {
//                            if (isAscOrder)
//                            {
//                                // UPGRADE_WARNING: オブジェクト array_buf(0, j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                isSwap = Conversions.ToBoolean(Interaction.IIf(Strings.StrComp(array_buf[0, i], array_buf[0, j], CompareMethod.Text) == 1, true, false));
//                            }
//                            else
//                            {
//                                // UPGRADE_WARNING: オブジェクト array_buf(0, j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                isSwap = Conversions.ToBoolean(Interaction.IIf(Strings.StrComp(array_buf[0, i], array_buf[0, j], CompareMethod.Text) == -1, true, false));
//                            }
//                        }
//                        else if (isAscOrder)
//                        {
//                            // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            isSwap = Conversions.ToBoolean(Interaction.IIf(Conversions.ToDouble(array_buf[0, i]) > Conversions.ToDouble(array_buf[0, j]), true, false));
//                        }
//                        else
//                        {
//                            // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            isSwap = Conversions.ToBoolean(Interaction.IIf(Conversions.ToDouble(array_buf[0, i]) < Conversions.ToDouble(array_buf[0, j]), true, false));
//                        }

//                        if (isSwap)
//                        {
//                            for (k = 0; k <= 2; k++)
//                            {
//                                // UPGRADE_WARNING: オブジェクト array_buf(k, i) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト var_buf(k) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                var_buf[k] = array_buf[k, i];
//                                // UPGRADE_WARNING: オブジェクト array_buf(k, j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト array_buf(k, i) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                array_buf[k, i] = array_buf[k, j];
//                                // UPGRADE_WARNING: オブジェクト var_buf(k) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト array_buf(k, j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                array_buf[k, j] = var_buf[k];
//                            }
//                        }
//                    }
//                }
//            }

//            if (!isKeySort)
//            {
//                // 改めて要素をソート
//                var loopTo4 = (short)(num - 1);
//                for (i = 0; i <= loopTo4; i++)
//                {
//                    var loopTo5 = (short)(i + 1);
//                    for (j = num; j >= loopTo5; j += -1)
//                    {
//                        isSwap = false;
//                        if (isStringValue)
//                        {
//                            if (isAscOrder)
//                            {
//                                // UPGRADE_WARNING: オブジェクト array_buf(2, j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                isSwap = Conversions.ToBoolean(Interaction.IIf(Strings.StrComp(array_buf[2, i], array_buf[2, j], CompareMethod.Text) == 1, true, false));
//                            }
//                            else
//                            {
//                                // UPGRADE_WARNING: オブジェクト array_buf(2, j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                isSwap = Conversions.ToBoolean(Interaction.IIf(Strings.StrComp(array_buf[2, i], array_buf[2, j], CompareMethod.Text) == -1, true, false));
//                            }
//                        }
//                        else if (isAscOrder)
//                        {
//                            // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            isSwap = Conversions.ToBoolean(Interaction.IIf(Conversions.ToDouble(array_buf[2, i]) > Conversions.ToDouble(array_buf[2, j]), true, false));
//                        }
//                        else
//                        {
//                            // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                            isSwap = Conversions.ToBoolean(Interaction.IIf(Conversions.ToDouble(array_buf[2, i]) < Conversions.ToDouble(array_buf[2, j]), true, false));
//                        }

//                        if (isSwap)
//                        {
//                            for (k = Conversions.ToShort(Interaction.IIf(isStringkey, 0, 1)); k <= 2; k++)
//                            {
//                                // UPGRADE_WARNING: オブジェクト array_buf(k, i) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト var_buf(k) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                var_buf[k] = array_buf[k, i];
//                                // UPGRADE_WARNING: オブジェクト array_buf(k, j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト array_buf(k, i) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                array_buf[k, i] = array_buf[k, j];
//                                // UPGRADE_WARNING: オブジェクト var_buf(k) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                // UPGRADE_WARNING: オブジェクト array_buf(k, j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                                array_buf[k, j] = var_buf[k];
//                            }
//                        }
//                    }
//                }
//            }

//            // SRC変数に再配置
//            var loopTo6 = num;
//            for (i = 0; i <= loopTo6; i++)
//            {
//                // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                buf = vname + "[" + Conversions.ToString(array_buf[0, i]) + "]";
//                Expression.UndefineVariable(ref buf);
//                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(array_buf[1, i], Expression.ValueType.StringType, false)))
//                {
//                    // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                    string argstr_value = Conversions.ToString(array_buf[2, i]);
//                    int argnum_value = 0;
//                    Expression.SetVariable(ref buf, ref Expression.ValueType.StringType, ref argstr_value, ref argnum_value);
//                }
//                else
//                {
//                    // UPGRADE_WARNING: オブジェクト array_buf() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//                    string argstr_value1 = "";
//                    double argnum_value1 = Conversions.ToDouble(array_buf[2, i]);
//                    Expression.SetVariable(ref buf, ref Expression.ValueType.NumericType, ref argstr_value1, ref argnum_value1);
//                }
//            }

//            // UPGRADE_WARNING: オブジェクト ExecSortCmd の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
//            ExecSortCmdRet = LineNum + 1;
//            return ExecSortCmdRet;
//        }

//        private int ExecSpecialPowerCmd()
//        {
//            int ExecSpecialPowerCmdRet = default;
//            Unit u, t = default;
//            string sname;
//            SpecialPowerData sd;
//            bool need_target = default, msg_window_visible;
//            short prev_action;
//            switch (ArgNum)
//            {
//                case 4:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        sname = GetArgAsString((short)3);
//                        t = GetArgAsUnit((short)4);
//                        break;
//                    }

//                case 3:
//                    {
//                        object argIndex2 = (object)GetArgAsString((short)2);
//                        if (SRC.SPDList.IsDefined(ref argIndex2))
//                        {
//                            object argIndex1 = (object)GetArgAsString((short)2);
//                            {
//                                var withBlock = SRC.SPDList.Item(ref argIndex1);
//                                string argename = "みがわり";
//                                string argename1 = "挑発";
//                                if (Conversions.ToBoolean(Operators.OrObject(withBlock.IsEffectAvailable(ref argename), withBlock.IsEffectAvailable(ref argename1))))
//                                {
//                                    need_target = true;
//                                }
//                            }
//                        }

//                        if (need_target)
//                        {
//                            u = Event_Renamed.SelectedUnitForEvent;
//                            sname = GetArgAsString((short)2);
//                            t = GetArgAsUnit((short)3);
//                        }
//                        else
//                        {
//                            u = GetArgAsUnit((short)2);
//                            sname = GetArgAsString((short)3);
//                        }

//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        sname = GetArgAsString((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "SpecialPowerコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 492305


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            bool localIsDefined() { object argIndex1 = sname; var ret = SRC.SPDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined())
//            {
//                Event_Renamed.EventErrorMessage = "SpecialPowerコマンドで指定されたスペシャルパワー「" + sname + "」が見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 492506


//                Input:
//                            Error(0)

//                 */
//            }

//            object argIndex3 = sname;
//            sd = SRC.SPDList.Item(ref argIndex3);
//            msg_window_visible = My.MyProject.Forms.frmMessage.Visible;
//            Unit prev_target;
//            if (sd.Duration == "即効")
//            {
//                prev_target = Commands.SelectedTarget;
//                if (t is object)
//                {
//                    Commands.SelectedTarget = t;
//                }
//                else
//                {
//                    Commands.SelectedTarget = Event_Renamed.SelectedTargetForEvent;
//                }

//                prev_action = u.Action;
//                sd.Execute(ref u.MainPilot(), true);
//                if (prev_target is object)
//                {
//                    Commands.SelectedTarget = prev_target.CurrentForm();
//                }

//                if (prev_action == 0 & u.Action > 0 | prev_action > 0 & u.Action == 0)
//                {
//                    GUI.RedrawScreen();
//                }
//            }
//            else if (t is object)
//            {
//                prev_action = t.Action;
//                t.MakeSpecialPowerInEffect(ref sname, ref u.MainPilot().ID);
//                if (prev_action == 0 & t.Action > 0 | prev_action > 0 & t.Action == 0)
//                {
//                    GUI.RedrawScreen();
//                }
//            }
//            else
//            {
//                prev_action = u.Action;
//                string argsdata = "";
//                u.MakeSpecialPowerInEffect(ref sname, sdata: ref argsdata);
//                if (prev_action == 0 & u.Action > 0 | prev_action > 0 & u.Action == 0)
//                {
//                    GUI.RedrawScreen();
//                }
//            }

//            if (!msg_window_visible)
//            {
//                GUI.CloseMessageForm();
//            }

//            ExecSpecialPowerCmdRet = LineNum + 1;
//            return ExecSpecialPowerCmdRet;
//        }

//        private int ExecSplitCmd()
//        {
//            int ExecSplitCmdRet = default;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Splitコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 494229


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            {
//                var withBlock = u;
//                string argfname = "分離";
//                if (!withBlock.IsFeatureAvailable(ref argfname))
//                {
//                    Event_Renamed.EventErrorMessage = withBlock.Name + "は分離できません";
//                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 494387


//                    Input:
//                                    Error(0)

//                     */
//                }

//                withBlock.Split_Renamed();

//                // 分離形態の１番目のユニットをメインユニットに設定
//                string localLIndex() { object argIndex1 = "分離"; string arglist = withBlock.FeatureData(ref argIndex1); var ret = GeneralLib.LIndex(ref arglist, 2); return ret; }

//                object argIndex1 = localLIndex();
//                u = SRC.UList.Item(ref argIndex1);

//                // 変数のアップデート
//                if (Commands.SelectedUnit is object)
//                {
//                    if ((withBlock.ID ?? "") == (Commands.SelectedUnit.ID ?? ""))
//                    {
//                        Commands.SelectedUnit = u;
//                    }
//                }

//                if (Event_Renamed.SelectedUnitForEvent is object)
//                {
//                    if ((withBlock.ID ?? "") == (Event_Renamed.SelectedUnitForEvent.ID ?? ""))
//                    {
//                        Event_Renamed.SelectedUnitForEvent = u;
//                    }
//                }

//                if (Commands.SelectedTarget is object)
//                {
//                    if ((withBlock.ID ?? "") == (Commands.SelectedTarget.ID ?? ""))
//                    {
//                        Commands.SelectedTarget = u;
//                    }
//                }

//                if (Event_Renamed.SelectedTargetForEvent is object)
//                {
//                    if ((withBlock.ID ?? "") == (Event_Renamed.SelectedTargetForEvent.ID ?? ""))
//                    {
//                        Event_Renamed.SelectedTargetForEvent = u;
//                    }
//                }
//            }

//            ExecSplitCmdRet = LineNum + 1;
//            return ExecSplitCmdRet;
//        }

//        private int ExecStartBGMCmd()
//        {
//            int ExecStartBGMCmdRet = default;
//            var fname = default(string);
//            int start_bgm_end;
//            int i;

//            // StartBGMコマンドが連続してる場合、最後のStartBGMコマンドの位置を検索
//            var loopTo = Information.UBound(Event_Renamed.EventCmd);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                if (Event_Renamed.EventCmd[i].Name != Event_Renamed.CmdType.StartBGMCmd)
//                {
//                    break;
//                }
//            }

//            start_bgm_end = i - 1;

//            // 最後のStartBGMから順にMIDIファイルを検索
//            var loopTo1 = LineNum;
//            for (i = start_bgm_end; i >= loopTo1; i -= 1)
//            {
//                fname = GeneralLib.ListTail(ref Event_Renamed.EventData[i], 2);
//                if (GeneralLib.ListLength(ref fname) == 1)
//                {
//                    if (Strings.Left(fname, 2) == "$(")
//                    {
//                        fname = "\"" + fname + "\"";
//                    }

//                    fname = Expression.GetValueAsString(ref fname, true);
//                }
//                else
//                {
//                    fname = "(" + fname + ")";
//                }

//                fname = Sound.SearchMidiFile(ref fname);
//                if (!string.IsNullOrEmpty(fname))
//                {
//                    // MIDIファイルが存在したので選択
//                    break;
//                }
//            }

//            // MIDIファイルを再生
//            Sound.KeepBGM = false;
//            Sound.BossBGM = false;
//            Sound.StartBGM(ref fname);

//            // 次のコマンド実行位置は最後のStartBGMコマンドの後
//            ExecStartBGMCmdRet = start_bgm_end + 1;
//            return ExecStartBGMCmdRet;
//        }

//        private int ExecStopBGMCmd()
//        {
//            int ExecStopBGMCmdRet = default;
//            Sound.KeepBGM = false;
//            Sound.BossBGM = false;
//            // MOD START マージ
//            // StopBGM
//            Sound.StopBGM(true);
//            // MOD END マージ
//            ExecStopBGMCmdRet = LineNum + 1;
//            return ExecStopBGMCmdRet;
//        }

//        private int ExecStopSummoningCmd()
//        {
//            int ExecStopSummoningCmdRet = default;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "StopSummoningコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 497442


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            // 召喚したユニットを解放
//            u.DismissServant();
//            ExecStopSummoningCmdRet = LineNum + 1;
//            return ExecStopSummoningCmdRet;
//        }

//        private int ExecSunsetCmd()
//        {
//            int ExecSunsetCmdRet = default;
//            short prev_x, prev_y;
//            bool late_refresh;
//            short i;
//            string buf;
//            late_refresh = false;
//            Map.MapDrawIsMapOnly = false;
//            var loopTo = ArgNum;
//            for (i = (short)2; i <= loopTo; i++)
//            {
//                buf = GetArgAsString(i);
//                switch (buf ?? "")
//                {
//                    case "非同期":
//                        {
//                            late_refresh = true;
//                            break;
//                        }

//                    case "マップ限定":
//                        {
//                            Map.MapDrawIsMapOnly = true;
//                            break;
//                        }

//                    default:
//                        {
//                            Event_Renamed.EventErrorMessage = "Sunsetコマンドに不正なオプション「" + buf + "」が使われています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 498133


//                            Input:
//                                                Error(0)

//                             */
//                            break;
//                        }
//                }
//            }

//            prev_x = GUI.MapX;
//            prev_y = GUI.MapY;

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;
//            string argdraw_mode = "夕焼け";
//            string argdraw_option = "非同期";
//            int argfilter_color = 0;
//            double argfilter_trans_par = 0d;
//            GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, filter_color: ref argfilter_color, filter_trans_par: ref argfilter_trans_par);
//            foreach (Unit u in SRC.UList)
//            {
//                {
//                    var withBlock = u;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        if (withBlock.BitmapID == 0)
//                        {
//                            object argIndex1 = withBlock.Name;
//                            {
//                                var withBlock1 = SRC.UList.Item(ref argIndex1);
//                                string argfname = "ダミーユニット";
//                                if ((u.Party0 ?? "") == (withBlock1.Party0 ?? "") & withBlock1.BitmapID != 0 & (u.get_Bitmap(false) ?? "") == (withBlock1.get_Bitmap(false) ?? "") & !withBlock1.IsFeatureAvailable(ref argfname))
//                                {
//                                    u.BitmapID = withBlock1.BitmapID;
//                                }
//                                else
//                                {
//                                    u.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                }
//                            }

//                            withBlock.Name = Conversions.ToString(argIndex1);
//                        }
//                    }
//                }
//            }

//            GUI.Center(prev_x, prev_y);
//            GUI.RedrawScreen(late_refresh);

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecSunsetCmdRet = LineNum + 1;
//            return ExecSunsetCmdRet;
//        }

//        private int ExecSupplyCmd()
//        {
//            int ExecSupplyCmdRet = default;
//            Unit u;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        break;
//                    }

//                case 1:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Supplyコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 499859


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u is object)
//            {
//                u.FullSupply();
//            }

//            ExecSupplyCmdRet = LineNum + 1;
//            return ExecSupplyCmdRet;
//        }

//        private int ExecSwapCmd()
//        {
//            int ExecSwapCmdRet = default;
//            var new_var1 = new VarData();
//            var new_var2 = new VarData();
//            VarData old_var1;
//            VarData old_var2;
//            short i;
//            if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "Swapコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 500350


//                Input:
//                            Error(0)

//                 */
//            }
//            else
//            {
//                // 入れ替える前の変数の値を保存
//                // 引数1の変数
//                string argvar_name = GetArg((short)2);
//                old_var1 = Expression.GetVariableObject(ref argvar_name);
//                if (old_var1 is object)
//                {
//                    {
//                        var withBlock = new_var2;
//                        withBlock.Name = old_var1.Name;
//                        withBlock.VariableType = old_var1.VariableType;
//                        withBlock.StringValue = old_var1.StringValue;
//                        withBlock.NumericValue = old_var1.NumericValue;
//                    }
//                }
//                // 引数2の変数
//                string argvar_name1 = GetArg((short)3);
//                old_var2 = Expression.GetVariableObject(ref argvar_name1);
//                if (old_var2 is object)
//                {
//                    {
//                        var withBlock1 = new_var1;
//                        withBlock1.Name = old_var2.Name;
//                        withBlock1.VariableType = old_var2.VariableType;
//                        withBlock1.StringValue = old_var2.StringValue;
//                        withBlock1.NumericValue = old_var2.NumericValue;
//                    }
//                }

//                // 引数2の変数を引数1の変数に代入
//                {
//                    var withBlock2 = old_var1;
//                    // 引数1がサブルーチンローカル変数の場合
//                    if ((int)Event_Renamed.CallDepth > 0)
//                    {
//                        var loopTo = Event_Renamed.VarIndex;
//                        for (i = (short)((int)Event_Renamed.VarIndexStack[(int)Event_Renamed.CallDepth - 1] + 1); i <= loopTo; i++)
//                        {
//                            if ((withBlock2.Name ?? "") == (Event_Renamed.VarStack[(int)i].Name ?? ""))
//                            {
//                                {
//                                    var withBlock3 = Event_Renamed.VarStack[(int)i];
//                                    withBlock3.VariableType = new_var1.VariableType;
//                                    withBlock3.StringValue = new_var1.StringValue;
//                                    withBlock3.NumericValue = new_var1.NumericValue;
//                                }

//                                goto Swap_Var2toVar1_End;
//                            }
//                        }
//                    }

//                    // ローカル・またはグローバル変数の場合
//                    withBlock2.VariableType = new_var1.VariableType;
//                    withBlock2.StringValue = new_var1.StringValue;
//                    withBlock2.NumericValue = new_var1.NumericValue;
//                }

//                Swap_Var2toVar1_End:
//                ;

//                // 引数1の変数を引数2の変数に代入
//                {
//                    var withBlock4 = old_var2;
//                    // 引数2がサブルーチンローカル変数の場合
//                    if ((int)Event_Renamed.CallDepth > 0)
//                    {
//                        var loopTo1 = Event_Renamed.VarIndex;
//                        for (i = (short)((int)Event_Renamed.VarIndexStack[(int)Event_Renamed.CallDepth - 1] + 1); i <= loopTo1; i++)
//                        {
//                            if ((withBlock4.Name ?? "") == (Event_Renamed.VarStack[(int)i].Name ?? ""))
//                            {
//                                {
//                                    var withBlock5 = Event_Renamed.VarStack[(int)i];
//                                    withBlock5.VariableType = new_var2.VariableType;
//                                    withBlock5.StringValue = new_var2.StringValue;
//                                    withBlock5.NumericValue = new_var2.NumericValue;
//                                }

//                                goto Swap_Var1toVar2_End;
//                            }
//                        }
//                    }

//                    // ローカル・またはグローバル変数の場合
//                    withBlock4.VariableType = new_var2.VariableType;
//                    withBlock4.StringValue = new_var2.StringValue;
//                    withBlock4.NumericValue = new_var2.NumericValue;
//                }

//                Swap_Var1toVar2_End:
//                ;
//            }

//            // オブジェクトの解放
//            // UPGRADE_NOTE: オブジェクト old_var1 をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            old_var1 = null;
//            // UPGRADE_NOTE: オブジェクト old_var2 をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            old_var2 = null;
//            // UPGRADE_NOTE: オブジェクト new_var1 をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            new_var1 = null;
//            // UPGRADE_NOTE: オブジェクト new_var2 をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            new_var2 = null;
//            ExecSwapCmdRet = LineNum + 1;
//            return ExecSwapCmdRet;
//        }

//        private int ExecSwitchCmd()
//        {
//            int ExecSwitchCmdRet = default;
//            int i;
//            short j, depth;
//            string a, b;
//            if ((int)ArgNum != 2)
//            {
//                Event_Renamed.EventErrorMessage = "Switchコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 503846


//                Input:
//                            Error(0)

//                 */
//            }

//            a = GetArgAsString(2);
//            depth = 1;
//            var loopTo = Information.UBound(Event_Renamed.EventCmd);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                {
//                    var withBlock = Event_Renamed.EventCmd[i];
//                    switch (withBlock.Name)
//                    {
//                        case Event_Renamed.CmdType.CaseCmd:
//                            {
//                                if (depth == 1)
//                                {
//                                    var loopTo1 = withBlock.ArgNum;
//                                    for (j = 2; j <= loopTo1; j++)
//                                    {
//                                        if (withBlock.GetArgsType(j) == Expression.ValueType.UndefinedType)
//                                        {
//                                            // 未識別のパラメータは式として処理する
//                                            b = withBlock.GetArgAsString(j);
//                                            if ((b ?? "") == (withBlock.GetArg(j) ?? ""))
//                                            {
//                                                // 文字列として識別済みにする
//                                                withBlock.SetArgsType(j, Expression.ValueType.StringType);
//                                            }
//                                        }
//                                        else
//                                        {
//                                            // 識別済みのパラメータは文字列としてそのまま参照する
//                                            b = withBlock.GetArg(j);
//                                        }

//                                        if ((a ?? "") == (b ?? ""))
//                                        {
//                                            ExecSwitchCmdRet = i + 1;
//                                            return ExecSwitchCmdRet;
//                                        }
//                                    }
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.CaseElseCmd:
//                            {
//                                if (depth == 1)
//                                {
//                                    ExecSwitchCmdRet = i + 1;
//                                    return ExecSwitchCmdRet;
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.EndSwCmd:
//                            {
//                                if (depth == 1)
//                                {
//                                    ExecSwitchCmdRet = i + 1;
//                                    return ExecSwitchCmdRet;
//                                }
//                                else
//                                {
//                                    depth = (short)(depth - 1);
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.SwitchCmd:
//                            {
//                                depth = (short)(depth + 1);
//                                break;
//                            }
//                    }
//                }
//            }

//            Event_Renamed.EventErrorMessage = "SwitchとEndSwが対応していません";
//            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 505287


//            Input:
//                    Error(0)

//             */
//        }

//        private int ExecCaseCmd()
//        {
//            int ExecCaseCmdRet = default;
//            int i;
//            short depth;

//            // 対応するEndSwを探す
//            depth = 1;
//            var loopTo = Information.UBound(Event_Renamed.EventCmd);
//            for (i = LineNum + 1; i <= loopTo; i++)
//            {
//                switch (Event_Renamed.EventCmd[i].Name)
//                {
//                    case Event_Renamed.CmdType.SwitchCmd:
//                        {
//                            depth = (short)(depth + 1);
//                            break;
//                        }

//                    case Event_Renamed.CmdType.EndSwCmd:
//                        {
//                            depth = (short)(depth - 1);
//                            if (depth == 0)
//                            {
//                                ExecCaseCmdRet = i + 1;
//                                return ExecCaseCmdRet;
//                            }

//                            break;
//                        }
//                }
//            }

//            Event_Renamed.EventErrorMessage = "SwitchとEndSwが対応していません";
//            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 505970


//            Input:
//                    Error(0)

//             */
//        }

//        private int ExecTalkCmd()
//        {
//            int ExecTalkCmdRet = default;
//            string pname, current_pname = default;
//            Unit u;
//            short ux, uy;
//            int i;
//            short j;
//            short lnum;
//            var without_cursor = default(bool);
//            string options = default, opt;
//            string buf;
//            short counter;
//            counter = (short)LineNum;
//            string cname;
//            int tcolor;
//            var loopTo = Information.UBound(Event_Renamed.EventData);
//            for (i = (int)counter; i <= loopTo; i++)
//            {
//                {
//                    var withBlock = Event_Renamed.EventCmd[i];
//                    switch (withBlock.Name)
//                    {
//                        case Event_Renamed.CmdType.TalkCmd:
//                            {
//                                if ((int)withBlock.ArgNum > 1)
//                                {
//                                    pname = withBlock.GetArgAsString((short)2);
//                                }
//                                else
//                                {
//                                    pname = "";
//                                }

//                                if (Strings.Left(pname, 1) == "@")
//                                {
//                                    // メインパイロットの強制指定
//                                    pname = Strings.Mid(pname, 2);
//                                    object argIndex2 = (object)pname;
//                                    if (SRC.PList.IsDefined(ref argIndex2))
//                                    {
//                                        object argIndex1 = (object)pname;
//                                        {
//                                            var withBlock1 = SRC.PList.Item(ref argIndex1);
//                                            if (withBlock1.Unit_Renamed is object)
//                                            {
//                                                pname = withBlock1.Unit_Renamed.MainPilot().Name;
//                                            }
//                                        }
//                                    }
//                                }

//                                // 話者名チェック
//                                bool localIsDefined() { object argIndex1 = (object)pname; var ret = SRC.PList.IsDefined(ref argIndex1); return ret; }

//                                bool localIsDefined1() { object argIndex1 = (object)pname; var ret = SRC.PDList.IsDefined(ref argIndex1); return ret; }

//                                bool localIsDefined2() { object argIndex1 = (object)pname; var ret = SRC.NPDList.IsDefined(ref argIndex1); return ret; }

//                                if (!localIsDefined() & !localIsDefined1() & !localIsDefined2() & !(pname == "システム") & !string.IsNullOrEmpty(pname))
//                                {
//                                    Event_Renamed.EventErrorMessage = "「" + pname + "」というパイロットが定義されていません";
//                                    LineNum = i;
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 507528


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                if ((int)withBlock.ArgNum > 1)
//                                {
//                                    options = "";
//                                    without_cursor = false;
//                                    j = (short)2;
//                                    lnum = (short)1;
//                                    while (j <= withBlock.ArgNum)
//                                    {
//                                        opt = withBlock.GetArgAsString(j);
//                                        switch (opt ?? "")
//                                        {
//                                            case "非表示":
//                                                {
//                                                    without_cursor = true;
//                                                    break;
//                                                }

//                                            case "枠外":
//                                                {
//                                                    GUI.MessageWindowIsOut = true;
//                                                    break;
//                                                }

//                                            case "白黒":
//                                            case "セピア":
//                                            case "明":
//                                            case "暗":
//                                            case "上下反転":
//                                            case "左右反転":
//                                            case "上半分":
//                                            case "下半分":
//                                            case "右半分":
//                                            case "左半分":
//                                            case "右上":
//                                            case "左上":
//                                            case "右下":
//                                            case "左下":
//                                            case "ネガポジ反転":
//                                            case "シルエット":
//                                            case "夕焼け":
//                                            case "水中":
//                                            case "通常":
//                                                {
//                                                    if ((int)j > 2)
//                                                    {
//                                                        // これらのパイロット画像描画に関するオプションは
//                                                        // パイロット名が指定されている場合にのみ有効
//                                                        options = options + opt + " ";
//                                                    }
//                                                    else
//                                                    {
//                                                        lnum = j;
//                                                    }

//                                                    break;
//                                                }

//                                            case "右回転":
//                                                {
//                                                    j = (short)((int)j + 1);
//                                                    options = options + "右回転 " + withBlock.GetArgAsString(j) + " ";
//                                                    break;
//                                                }

//                                            case "左回転":
//                                                {
//                                                    j = (short)((int)j + 1);
//                                                    options = options + "左回転 " + withBlock.GetArgAsString(j) + " ";
//                                                    break;
//                                                }

//                                            case "フィルタ":
//                                                {
//                                                    j = (short)((int)j + 1);
//                                                    buf = withBlock.GetArgAsString(j);
//                                                    cname = new string(Conversions.ToChar(Constants.vbNullChar), 8);
//                                                    StringType.MidStmtStr(ref cname, 1, 2, "&H");
//                                                    var midTmp = Strings.Mid(buf, 6, 2);
//                                                    StringType.MidStmtStr(ref cname, 3, 2, midTmp);
//                                                    var midTmp1 = Strings.Mid(buf, 4, 2);
//                                                    StringType.MidStmtStr(ref cname, 5, 2, midTmp1);
//                                                    var midTmp2 = Strings.Mid(buf, 2, 2);
//                                                    StringType.MidStmtStr(ref cname, 7, 2, midTmp2);
//                                                    tcolor = Conversions.ToInteger(cname);
//                                                    j = (short)((int)j + 1);
//                                                    // 空白のオプションをスキップ
//                                                    options = options + "フィルタ " + Microsoft.VisualBasic.Compatibility.VB6.Support.Format((object)tcolor) + " " + withBlock.GetArgAsString(j) + " ";
//                                                    break;
//                                                }

//                                            case var @case when @case == "":
//                                                {
//                                                    break;
//                                                }

//                                            default:
//                                                {
//                                                    // 通常の引数をスキップ
//                                                    lnum = j;
//                                                    break;
//                                                }
//                                        }

//                                        j = (short)((int)j + 1);
//                                    }
//                                }
//                                else
//                                {
//                                    lnum = (short)1;
//                                }

//                                switch (lnum)
//                                {
//                                    case 0:
//                                    case 1:
//                                        {
//                                            // 引数なし

//                                            if (!My.MyProject.Forms.frmMessage.Visible)
//                                            {
//                                                Unit argu1 = null;
//                                                Unit argu2 = null;
//                                                GUI.OpenMessageForm(u1: ref argu1, u2: ref argu2);
//                                            }

//                                            // メッセージウィンドウのパイロット画像を以前指定された
//                                            // ものに確定させる
//                                            if (!string.IsNullOrEmpty(current_pname))
//                                            {
//                                                GUI.DisplayMessage(ref current_pname, "", options);
//                                            }

//                                            current_pname = "";
//                                            break;
//                                        }

//                                    case 2:
//                                        {
//                                            // パイロット名のみ指定
//                                            current_pname = pname;

//                                            // 話者中心に画面位置を変更

//                                            // プロローグイベントやエピローグイベント時はキャンセル
//                                            if (SRC.Stage == "プロローグ" | SRC.Stage == "エピローグ")
//                                            {
//                                                goto NextLoop;
//                                            }

//                                            // 画面書き換え可能？
//                                            if (!GUI.MainForm.Visible)
//                                            {
//                                                goto NextLoop;
//                                            }

//                                            if (GUI.IsPictureVisible)
//                                            {
//                                                goto NextLoop;
//                                            }

//                                            if (string.IsNullOrEmpty(Map.MapFileName))
//                                            {
//                                                goto NextLoop;
//                                            }

//                                            // 話者を中央表示
//                                            CenterUnit(pname, without_cursor);
//                                            break;
//                                        }

//                                    case 3:
//                                        {
//                                            current_pname = pname;
//                                            switch (withBlock.GetArgAsString((short)3) ?? "")
//                                            {
//                                                case "母艦":
//                                                    {
//                                                        // 母艦の中央表示
//                                                        CenterUnit("母艦", without_cursor);
//                                                        break;
//                                                    }

//                                                case "中央":
//                                                    {
//                                                        // 話者の中央表示
//                                                        CenterUnit(pname, without_cursor);
//                                                        break;
//                                                    }

//                                                case "固定":
//                                                    {
//                                                        break;
//                                                    }
//                                                    // 表示位置固定
//                                            }

//                                            break;
//                                        }

//                                    case 4:
//                                        {
//                                            // 表示の座標指定あり
//                                            current_pname = pname;
//                                            CenterUnit(pname, without_cursor, (short)withBlock.GetArgAsLong((short)3), (short)withBlock.GetArgAsLong((short)4));
//                                            break;
//                                        }

//                                    case -1:
//                                        {
//                                            Event_Renamed.EventErrorMessage = "Talkコマンドのパラメータの括弧の対応が取れていません";
//                                            LineNum = i;
//                                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 511026


//                                            Input:
//                                                                            Error(0)

//                                             */
//                                            break;
//                                        }

//                                    default:
//                                        {
//                                            Event_Renamed.EventErrorMessage = "Talkコマンドの引数の数が違います";
//                                            LineNum = i;
//                                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 511176


//                                            Input:
//                                                                            Error(0)

//                                             */
//                                            break;
//                                        }
//                                }

//                                if (!My.MyProject.Forms.frmMessage.Visible)
//                                {
//                                    Unit argu11 = null;
//                                    Unit argu21 = null;
//                                    GUI.OpenMessageForm(u1: ref argu11, u2: ref argu21);
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.EndCmd:
//                            {
//                                GUI.CloseMessageForm();
//                                GUI.MessageWindowIsOut = false;
//                                if ((int)withBlock.ArgNum != 1)
//                                {
//                                    Event_Renamed.EventErrorMessage = "End部分の引数の数が違います";
//                                    LineNum = i;
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 511627


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                break;
//                            }

//                        case Event_Renamed.CmdType.SuspendCmd:
//                            {
//                                if ((int)withBlock.ArgNum != 1)
//                                {
//                                    Event_Renamed.EventErrorMessage = "Suspend部分の引数の数が違います";
//                                    LineNum = i;
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 511873


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                break;
//                            }

//                        default:
//                            {
//                                if (!My.MyProject.Forms.frmMessage.Visible)
//                                {
//                                    Unit argu12 = null;
//                                    Unit argu22 = null;
//                                    GUI.OpenMessageForm(u1: ref argu12, u2: ref argu22);
//                                }

//                                GUI.DisplayMessage(ref current_pname, Event_Renamed.EventData[i], options);
//                                break;
//                            }
//                    }
//                }

//                NextLoop:
//                ;
//            }

//            if (i > Information.UBound(Event_Renamed.EventData))
//            {
//                GUI.CloseMessageForm();
//                Event_Renamed.EventErrorMessage = "TalkとEndが対応していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 512450


//                Input:
//                            Error(0)

//                 */
//            }

//            ExecTalkCmdRet = i + 1;
//            return ExecTalkCmdRet;
//        }

//        private int ExecTelopCmd()
//        {
//            int ExecTelopCmdRet = default;
//            string msg, BGM;
//            msg = GeneralLib.ListTail(ref Event_Renamed.EventData[LineNum], 2);
//            if (GeneralLib.ListLength(ref msg) == 1)
//            {
//                msg = Expression.GetValueAsString(ref msg);
//            }

//            Expression.FormatMessage(ref msg);
//            string argbgm_name = "Subtitle";
//            string argmidi_name = Sound.BGMName(ref argbgm_name);
//            BGM = Sound.SearchMidiFile(ref argmidi_name);
//            if (Strings.Len(BGM) > 0)
//            {
//                Sound.StartBGM(ref BGM, false);
//                if (!GUI.IsRButtonPressed())
//                {
//                    GUI.Sleep(1000);
//                }

//                GUI.DisplayTelop(ref msg);
//                if (!GUI.IsRButtonPressed())
//                {
//                    GUI.Sleep(2000);
//                }
//            }
//            else
//            {
//                GUI.DisplayTelop(ref msg);
//            }

//            ExecTelopCmdRet = LineNum + 1;
//            return ExecTelopCmdRet;
//        }

//        private int ExecTransformCmd()
//        {
//            int ExecTransformCmdRet = default;
//            Unit u;
//            string tname;
//            switch (ArgNum)
//            {
//                case 3:
//                    {
//                        u = GetArgAsUnit((short)2);
//                        tname = GetArgAsString((short)3);
//                        break;
//                    }

//                case 2:
//                    {
//                        u = Event_Renamed.SelectedUnitForEvent;
//                        tname = GetArgAsString((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Transformコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 513842


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if ((u.Name ?? "") == (tname ?? ""))
//            {
//                // 元々指定された形態になっていたので変形の必要なし
//                ExecTransformCmdRet = LineNum + 1;
//                return ExecTransformCmdRet;
//            }

//            // 変形
//            u.Transform(ref tname);

//            // グローバル変数の更新
//            if (ReferenceEquals(u, Commands.SelectedUnit))
//            {
//                Commands.SelectedUnit = u.CurrentForm();
//            }

//            if (ReferenceEquals(u, Event_Renamed.SelectedUnitForEvent))
//            {
//                Event_Renamed.SelectedUnitForEvent = u.CurrentForm();
//            }

//            if (ReferenceEquals(u, Commands.SelectedTarget))
//            {
//                Commands.SelectedTarget = u.CurrentForm();
//            }

//            if (ReferenceEquals(u, Event_Renamed.SelectedTargetForEvent))
//            {
//                Event_Renamed.SelectedTargetForEvent = u.CurrentForm();
//            }

//            ExecTransformCmdRet = LineNum + 1;
//            return ExecTransformCmdRet;
//        }

//        private int ExecUnitCmd()
//        {
//            int ExecUnitCmdRet = default;
//            string uname;
//            Unit u;
//            short urank;
//            if ((int)ArgNum < 0)
//            {
//                Event_Renamed.EventErrorMessage = "Unitコマンドのパラメータの括弧の対応が取れていません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 514928


//                Input:
//                            Error(0)

//                 */
//            }
//            else if ((int)ArgNum != 3)
//            {
//                Event_Renamed.EventErrorMessage = "Unitコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 515047


//                Input:
//                            Error(0)

//                 */
//            }

//            uname = GetArgAsString(2);
//            bool localIsDefined() { object argIndex1 = uname; var ret = SRC.UDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined())
//            {
//                Event_Renamed.EventErrorMessage = "指定したユニット「" + uname + "」のデータが見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 515257


//                Input:
//                            Error(0)

//                 */
//            }

//            urank = (short)GetArgAsLong(3);
//            string arguparty = "味方";
//            u = SRC.UList.Add(ref uname, urank, ref arguparty);
//            if (u is null)
//            {
//                Event_Renamed.EventErrorMessage = uname + "のユニットデータが不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 515477


//                Input:
//                            Error(0)

//                 */
//            }

//            Event_Renamed.SelectedUnitForEvent = u;
//            ExecUnitCmdRet = LineNum + 1;
//            return ExecUnitCmdRet;
//        }

//        private int ExecUnsetCmd()
//        {
//            int ExecUnsetCmdRet = default;
//            string argvar_name = GetArg(2);
//            Expression.UndefineVariable(ref argvar_name);
//            ExecUnsetCmdRet = LineNum + 1;
//            return ExecUnsetCmdRet;
//        }

//        private int ExecUpgradeCmd()
//        {
//            int ExecUpgradeCmdRet = default;
//            string uname;
//            Unit u1, u2;
//            short i;
//            string prev_status;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        u1 = Event_Renamed.SelectedUnitForEvent.CurrentForm();
//                        uname = GetArgAsString((short)2);
//                        break;
//                    }

//                case 3:
//                    {
//                        uname = GetArgAsString((short)2);
//                        bool localIsDefined() { object argIndex1 = (object)uname; var ret = SRC.UList.IsDefined(ref argIndex1); return ret; }

//                        if (!localIsDefined())
//                        {
//                            Event_Renamed.EventErrorMessage = uname + "というユニットはありません";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 516265


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        Unit localItem() { object argIndex1 = (object)uname; var ret = SRC.UList.Item(ref argIndex1); return ret; }

//                        u1 = localItem().CurrentForm();
//                        uname = GetArgAsString((short)3);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Upgradeコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 516484


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            bool localIsDefined1() { object argIndex1 = uname; var ret = SRC.UDList.IsDefined(ref argIndex1); return ret; }

//            if (!localIsDefined1())
//            {
//                Event_Renamed.EventErrorMessage = "ユニット「" + uname + "」のデータが見つかりません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 516662


//                Input:
//                            Error(0)

//                 */
//            }

//            prev_status = u1.Status_Renamed;
//            string arguparty = u1.Party0;
//            u2 = SRC.UList.Add(ref uname, u1.Rank, ref arguparty);
//            u1.Party0 = arguparty;
//            if (u2 is null)
//            {
//                Event_Renamed.EventErrorMessage = uname + "のユニットデータが不正です";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 516898


//                Input:
//                            Error(0)

//                 */
//            }

//            if (u1.BossRank > 0)
//            {
//                u2.BossRank = u1.BossRank;
//                u2.FullRecover();
//            }

//            // パイロットの乗せ換え
//            Pilot[] pilot_list;
//            Pilot[] support_list;
//            if (u1.CountPilot() > 0)
//            {
//                pilot_list = new Pilot[(u1.CountPilot() + 1)];
//                support_list = new Pilot[(u1.CountSupport() + 1)];
//                var loopTo = (short)Information.UBound(pilot_list);
//                for (i = 1; i <= loopTo; i++)
//                {
//                    object argIndex1 = i;
//                    pilot_list[i] = u1.Pilot(ref argIndex1);
//                }

//                var loopTo1 = (short)Information.UBound(support_list);
//                for (i = 1; i <= loopTo1; i++)
//                {
//                    object argIndex2 = i;
//                    support_list[i] = u1.Support(ref argIndex2);
//                }

//                object argIndex3 = 1;
//                u1.Pilot(ref argIndex3).GetOff();
//                var loopTo2 = (short)Information.UBound(pilot_list);
//                for (i = 1; i <= loopTo2; i++)
//                    pilot_list[i].Ride(ref u2);
//                var loopTo3 = (short)Information.UBound(support_list);
//                for (i = 1; i <= loopTo3; i++)
//                    support_list[i].Ride(ref u2);
//            }

//            // アイテムの交換
//            var loopTo4 = u1.CountItem();
//            for (i = 1; i <= loopTo4; i++)
//            {
//                Item localItem1() { object argIndex1 = i; var ret = u1.Item(ref argIndex1); return ret; }

//                var argitm = localItem1();
//                u2.AddItem(ref argitm);
//            }

//            var loopTo5 = u1.CountItem();
//            for (i = 1; i <= loopTo5; i++)
//            {
//                object argIndex4 = 1;
//                u1.DeleteItem(ref argIndex4);
//            }

//            // リンクの付け替え
//            u2.Master = u1.Master;
//            // UPGRADE_NOTE: オブジェクト u1.Master をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            u1.Master = null;
//            u2.Summoner = u1.Summoner;
//            // UPGRADE_NOTE: オブジェクト u1.Summoner をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//            u1.Summoner = null;

//            // 召喚ユニットの交換
//            var loopTo6 = u1.CountServant();
//            for (i = 1; i <= loopTo6; i++)
//            {
//                Unit localServant() { object argIndex1 = i; var ret = u1.Servant(ref argIndex1); return ret; }

//                var argu = localServant();
//                u2.AddServant(ref argu);
//            }

//            var loopTo7 = u1.CountServant();
//            for (i = 1; i <= loopTo7; i++)
//            {
//                object argIndex5 = 1;
//                u1.DeleteServant(ref argIndex5);
//            }

//            // 収納ユニットの交換
//            string argfname = "母艦";
//            if (u1.IsFeatureAvailable(ref argfname))
//            {
//                var loopTo8 = u1.CountOtherForm();
//                for (i = 1; i <= loopTo8; i++)
//                {
//                    Unit localOtherForm1() { object argIndex1 = i; var ret = u1.OtherForm(ref argIndex1); return ret; }

//                    if (localOtherForm1().Status_Renamed == "格納")
//                    {
//                        Unit localOtherForm() { object argIndex1 = i; var ret = u1.OtherForm(ref argIndex1); return ret; }

//                        var argu1 = localOtherForm();
//                        u2.AddOtherForm(ref argu1);
//                    }
//                }

//                var loopTo9 = u2.CountOtherForm();
//                for (i = 1; i <= loopTo9; i++)
//                {
//                    Unit localOtherForm3() { object argIndex1 = i; var ret = u2.OtherForm(ref argIndex1); return ret; }

//                    if (localOtherForm3().Status_Renamed == "格納")
//                    {
//                        Unit localOtherForm2() { object argIndex1 = i; var ret = u2.OtherForm(ref argIndex1); return ret; }

//                        u1.DeleteOtherForm(ref (object)localOtherForm2().ID);
//                    }
//                }
//            }

//            u2.Area = u1.Area;

//            // 元のユニットを削除
//            u1.Status_Renamed = "破棄";
//            var loopTo10 = u1.CountOtherForm();
//            for (i = 1; i <= loopTo10; i++)
//            {
//                Unit localOtherForm5() { object argIndex1 = i; var ret = u1.OtherForm(ref argIndex1); return ret; }

//                if (localOtherForm5().Status_Renamed == "他形態")
//                {
//                    Unit localOtherForm4() { object argIndex1 = i; var ret = u1.OtherForm(ref argIndex1); return ret; }

//                    localOtherForm4().Status_Renamed = "破棄";
//                }
//            }

//            u2.UsedAction = u1.UsedAction;
//            u2.UsedSupportAttack = u1.UsedSupportAttack;
//            u2.UsedSupportGuard = u1.UsedSupportGuard;
//            u2.UsedSyncAttack = u1.UsedSyncAttack;
//            u2.UsedCounterAttack = u1.UsedCounterAttack;
//            switch (prev_status ?? "")
//            {
//                case "出撃":
//                    {
//                        // UPGRADE_NOTE: オブジェクト MapDataForUnit() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                        Map.MapDataForUnit[u1.x, u1.y] = null;
//                        u2.StandBy(u1.x, u1.y);
//                        if (!GUI.IsPictureVisible)
//                        {
//                            GUI.RedrawScreen();
//                        }

//                        break;
//                    }

//                case "破壊":
//                case "破棄":
//                    {
//                        if (ReferenceEquals(Map.MapDataForUnit[u1.x, u1.y], u1))
//                        {
//                            // UPGRADE_NOTE: オブジェクト MapDataForUnit() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
//                            Map.MapDataForUnit[u1.x, u1.y] = null;
//                        }

//                        u2.StandBy(u1.x, u1.y);
//                        if (!GUI.IsPictureVisible)
//                        {
//                            GUI.RedrawScreen();
//                        }

//                        break;
//                    }

//                case "格納":
//                    {
//                        foreach (Unit u in SRC.UList)
//                        {
//                            {
//                                var withBlock = u;
//                                var loopTo11 = withBlock.CountUnitOnBoard();
//                                for (i = 1; i <= loopTo11; i++)
//                                {
//                                    Unit localUnitOnBoard() { object argIndex1 = i; var ret = withBlock.UnitOnBoard(ref argIndex1); return ret; }

//                                    if ((u1.ID ?? "") == (localUnitOnBoard().ID ?? ""))
//                                    {
//                                        withBlock.UnloadUnit(ref (object)u1.ID);
//                                        u2.Land(ref u, true);
//                                        goto ExitLoop;
//                                    }
//                                }
//                            }
//                        }

//                        ExitLoop:
//                        ;
//                        break;
//                    }

//                default:
//                    {
//                        u2.Status_Renamed = prev_status;
//                        break;
//                    }
//            }

//            // グローバル変数の更新
//            if (ReferenceEquals(u1, Commands.SelectedUnit))
//            {
//                Commands.SelectedUnit = u2;
//            }

//            if (ReferenceEquals(u1, Event_Renamed.SelectedUnitForEvent))
//            {
//                Event_Renamed.SelectedUnitForEvent = u2;
//            }

//            if (ReferenceEquals(u1, Commands.SelectedTarget))
//            {
//                Commands.SelectedTarget = u2;
//            }

//            if (ReferenceEquals(u1, Event_Renamed.SelectedTargetForEvent))
//            {
//                Event_Renamed.SelectedTargetForEvent = u2;
//            }

//            var loopTo12 = Commands.SelectionStackIndex;
//            for (i = 1; i <= loopTo12; i++)
//            {
//                if (ReferenceEquals(u1, Commands.SavedSelectedUnit[i]))
//                {
//                    Commands.SavedSelectedUnit[i] = u2;
//                }

//                if (ReferenceEquals(u1, Commands.SavedSelectedUnitForEvent[i]))
//                {
//                    Commands.SavedSelectedUnitForEvent[i] = u2;
//                }

//                if (ReferenceEquals(u1, Commands.SavedSelectedTarget[i]))
//                {
//                    Commands.SavedSelectedTarget[i] = u2;
//                }

//                if (ReferenceEquals(u1, Commands.SavedSelectedTargetForEvent[i]))
//                {
//                    Commands.SavedSelectedTargetForEvent[i] = u2;
//                }
//            }

//            ExecUpgradeCmdRet = LineNum + 1;
//            return ExecUpgradeCmdRet;
//        }

//        private int ExecUpvarCmd()
//        {
//            int ExecUpvarCmdRet = default;
//            Event_Renamed.UpVarLevel = (short)(Event_Renamed.UpVarLevel + 1);
//            ExecUpvarCmdRet = LineNum + 1;
//            return ExecUpvarCmdRet;
//        }

//        private int ExecUseAbilityCmd()
//        {
//            int ExecUseAbilityCmdRet = default;
//            Unit u1, u2;
//            string aname;
//            short a;
//            switch (ArgNum)
//            {
//                case 4:
//                    {
//                        u1 = GetArgAsUnit((short)2);
//                        aname = GetArgAsString((short)3);
//                        var loopTo = u1.CountAbility();
//                        for (a = (short)1; a <= loopTo; a++)
//                        {
//                            if ((aname ?? "") == (u1.Ability(a).Name ?? ""))
//                            {
//                                break;
//                            }
//                        }

//                        if (a > u1.CountAbility())
//                        {
//                            Event_Renamed.EventErrorMessage = "アビリティ名が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 522554


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        u2 = GetArgAsUnit((short)4);
//                        break;
//                    }

//                case 3:
//                    {
//                        u1 = Event_Renamed.SelectedUnitForEvent;
//                        if (u1 is object)
//                        {
//                            aname = GetArgAsString((short)2);
//                            var loopTo1 = u1.CountAbility();
//                            for (a = (short)1; a <= loopTo1; a++)
//                            {
//                                if ((aname ?? "") == (u1.Ability(a).Name ?? ""))
//                                {
//                                    break;
//                                }
//                            }

//                            if (a <= u1.CountAbility())
//                            {
//                                u2 = GetArgAsUnit((short)3);
//                            }
//                            else
//                            {
//                                u1 = GetArgAsUnit((short)2);
//                                aname = GetArgAsString((short)3);
//                                var loopTo2 = u1.CountAbility();
//                                for (a = (short)1; a <= loopTo2; a++)
//                                {
//                                    if ((aname ?? "") == (u1.Ability(a).Name ?? ""))
//                                    {
//                                        break;
//                                    }
//                                }

//                                if (a > u1.CountAbility())
//                                {
//                                    Event_Renamed.EventErrorMessage = "アビリティ名が間違っています";
//                                    ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                    /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 523270


//                                    Input:
//                                                                Error(0)

//                                     */
//                                }

//                                u2 = u1;
//                            }
//                        }
//                        else
//                        {
//                            u1 = GetArgAsUnit((short)2);
//                            aname = GetArgAsString((short)3);
//                            var loopTo3 = u1.CountAbility();
//                            for (a = (short)1; a <= loopTo3; a++)
//                            {
//                                if ((aname ?? "") == (u1.Ability(a).Name ?? ""))
//                                {
//                                    break;
//                                }
//                            }

//                            if (a > u1.CountAbility())
//                            {
//                                Event_Renamed.EventErrorMessage = "アビリティ名が間違っています";
//                                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 523646


//                                Input:
//                                                        Error(0)

//                                 */
//                            }

//                            u2 = u1;
//                        }

//                        break;
//                    }

//                case 2:
//                    {
//                        u1 = Event_Renamed.SelectedUnitForEvent;
//                        aname = GetArgAsString((short)2);
//                        var loopTo4 = u1.CountAbility();
//                        for (a = (short)1; a <= loopTo4; a++)
//                        {
//                            if ((aname ?? "") == (u1.Ability(a).Name ?? ""))
//                            {
//                                break;
//                            }
//                        }

//                        if (a > u1.CountAbility())
//                        {
//                            Event_Renamed.EventErrorMessage = "アビリティ名が間違っています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 524040


//                            Input:
//                                                Error(0)

//                             */
//                        }

//                        u2 = Event_Renamed.SelectedUnitForEvent;
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "UseAbilityコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 524229


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            if (u1.Status_Renamed != "出撃")
//            {
//                Event_Renamed.EventErrorMessage = u1.Nickname + "は出撃していません";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 524387


//                Input:
//                                Error(0)

//                 */
//            }

//            u1.ExecuteAbility(a, ref u2, false, true);
//            GUI.CloseMessageForm();
//            GUI.RedrawScreen();
//            ExecUseAbilityCmdRet = LineNum + 1;
//            return ExecUseAbilityCmdRet;
//        }

//        private int ExecWaitCmd()
//        {
//            int ExecWaitCmdRet = default;
//            short i;
//            int wait_time, start_time, cur_time;
//            switch (ArgNum)
//            {
//                case 2:
//                    {
//                        switch (Strings.LCase(GetArg((short)2)) ?? "")
//                        {
//                            case "start":
//                                {
//                                    Event_Renamed.WaitStartTime = GeneralLib.timeGetTime();
//                                    Event_Renamed.WaitTimeCount = 0;
//                                    break;
//                                }

//                            case "reset":
//                                {
//                                    Event_Renamed.WaitStartTime = -1;
//                                    Event_Renamed.WaitTimeCount = 0;
//                                    break;
//                                }

//                            case "click":
//                                {
//                                    // 先行入力されていたクリックイベントを解消
//                                    Application.DoEvents();
//                                    Commands.WaitClickMode = true;
//                                    GUI.IsFormClicked = false;
//                                    Event_Renamed.SelectedAlternative = "";

//                                    // ウィンドウが表示されていない場合は表示
//                                    {
//                                        var withBlock = GUI.MainForm;
//                                        if (!withBlock.Visible)
//                                        {
//                                            withBlock.Show();
//                                            withBlock.Refresh();
//                                        }
//                                    }

//                                    // クリックされるまで待つ
//                                    while (!GUI.IsFormClicked)
//                                    {
//                                        if (GUI.IsRButtonPressed(true))
//                                        {
//                                            GUI.MouseButton = (short)0;
//                                            break;
//                                        }

//                                        Application.DoEvents();
//                                        GUI.Sleep(25);
//                                    }

//                                    // マウスの左ボタンが押された場合はホットポイントの判定を行う
//                                    if (string.IsNullOrEmpty(Event_Renamed.SelectedAlternative) & (int)GUI.MouseButton == 1)
//                                    {
//                                        var loopTo = (short)Information.UBound(Event_Renamed.HotPointList);
//                                        for (i = (short)1; i <= loopTo; i++)
//                                        {
//                                            {
//                                                var withBlock1 = Event_Renamed.HotPointList[(int)i];
//                                                if ((float)withBlock1.Left_Renamed <= GUI.MouseX & GUI.MouseX < (float)(withBlock1.Left_Renamed + withBlock1.width) & (float)withBlock1.Top <= GUI.MouseY & GUI.MouseY < (float)(withBlock1.Top + withBlock1.Height))
//                                                {
//                                                    Event_Renamed.SelectedAlternative = withBlock1.Name;
//                                                    break;
//                                                }
//                                            }
//                                        }
//                                    }

//                                    Commands.WaitClickMode = false;
//                                    GUI.IsFormClicked = false;
//                                    break;
//                                }

//                            default:
//                                {
//                                    wait_time = (int)(100d * GetArgAsDouble((short)2));

//                                    // 待ち時間が切れるまで待機
//                                    if (wait_time < 1000)
//                                    {
//                                        if (!GUI.IsRButtonPressed(true))
//                                        {
//                                            Application.DoEvents();
//                                            GUI.Sleep(wait_time);
//                                        }
//                                    }
//                                    else
//                                    {
//                                        start_time = GeneralLib.timeGetTime();
//                                        while (start_time + wait_time > GeneralLib.timeGetTime())
//                                        {
//                                            // 右ボタンを押されていたら早送り
//                                            if (GUI.IsRButtonPressed(true))
//                                            {
//                                                break;
//                                            }

//                                            Application.DoEvents();
//                                            GUI.Sleep(25);
//                                        }
//                                    }

//                                    break;
//                                }
//                        }

//                        break;
//                    }

//                case 3:
//                    {
//                        // Wait Until ～

//                        wait_time = (int)(100d * GetArgAsDouble((short)3));
//                        Event_Renamed.WaitTimeCount = Event_Renamed.WaitTimeCount + 1;
//                        if (Event_Renamed.WaitStartTime == -1)
//                        {
//                            // Wait Reset が実行されていた場合
//                            Event_Renamed.WaitStartTime = GeneralLib.timeGetTime();
//                        }
//                        else if (wait_time < 100)
//                        {
//                            // アニメの１回目の表示は例外的に時間がかかってしまうことがある
//                            // ので、超過時間を無視する
//                            if (Event_Renamed.WaitTimeCount == 1)
//                            {
//                                cur_time = GeneralLib.timeGetTime();
//                                if (Event_Renamed.WaitStartTime + wait_time > cur_time)
//                                {
//                                    Event_Renamed.WaitStartTime = cur_time;
//                                }
//                            }
//                        }

//                        while (Event_Renamed.WaitStartTime + wait_time > GeneralLib.timeGetTime())
//                        {
//                            if (GUI.IsRButtonPressed(true))
//                            {
//                                break;
//                            }

//                            Application.DoEvents();
//                            GUI.Sleep(25);
//                        }

//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "Waitコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 528646


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            ExecWaitCmdRet = LineNum + 1;
//            return ExecWaitCmdRet;
//        }

//        private int ExecWaterCmd()
//        {
//            int ExecWaterCmdRet = default;
//            short prev_x, prev_y;
//            bool late_refresh;
//            short i;
//            string buf;
//            late_refresh = false;
//            Map.MapDrawIsMapOnly = false;
//            var loopTo = ArgNum;
//            for (i = (short)2; i <= loopTo; i++)
//            {
//                buf = GetArgAsString(i);
//                switch (buf ?? "")
//                {
//                    case "非同期":
//                        {
//                            late_refresh = true;
//                            break;
//                        }

//                    case "マップ限定":
//                        {
//                            Map.MapDrawIsMapOnly = true;
//                            break;
//                        }

//                    default:
//                        {
//                            Event_Renamed.EventErrorMessage = "Waterコマンドに不正なオプション「" + buf + "」が使われています";
//                            ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                            /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 529284


//                            Input:
//                                                Error(0)

//                             */
//                            break;
//                        }
//                }
//            }

//            prev_x = GUI.MapX;
//            prev_y = GUI.MapY;

//            // マウスカーソルを砂時計に
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.WaitCursor;
//            string argdraw_mode = "水中";
//            string argdraw_option = "非同期";
//            int argfilter_color = 0;
//            double argfilter_trans_par = 0d;
//            GUI.SetupBackground(ref argdraw_mode, ref argdraw_option, filter_color: ref argfilter_color, filter_trans_par: ref argfilter_trans_par);
//            foreach (Unit u in SRC.UList)
//            {
//                {
//                    var withBlock = u;
//                    if (withBlock.Status_Renamed == "出撃")
//                    {
//                        if (withBlock.BitmapID == 0)
//                        {
//                            object argIndex1 = withBlock.Name;
//                            {
//                                var withBlock1 = SRC.UList.Item(ref argIndex1);
//                                string argfname = "ダミーユニット";
//                                if ((u.Party0 ?? "") == (withBlock1.Party0 ?? "") & withBlock1.BitmapID != 0 & (u.get_Bitmap(false) ?? "") == (withBlock1.get_Bitmap(false) ?? "") & !withBlock1.IsFeatureAvailable(ref argfname))
//                                {
//                                    u.BitmapID = withBlock1.BitmapID;
//                                }
//                                else
//                                {
//                                    u.BitmapID = GUI.MakeUnitBitmap(ref u);
//                                }
//                            }

//                            withBlock.Name = Conversions.ToString(argIndex1);
//                        }
//                    }
//                }
//            }

//            GUI.Center(prev_x, prev_y);
//            GUI.RedrawScreen(late_refresh);

//            // マウスカーソルを元に戻す
//            // UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
//            Cursor.Current = Cursors.Default;
//            ExecWaterCmdRet = LineNum + 1;
//            return ExecWaterCmdRet;
//        }

//        private int ExecWhiteInCmd()
//        {
//            int ExecWhiteInCmdRet = default;
//            int cur_time, start_time, wait_time;
//            int i, ret;
//            short num;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        num = (short)10;
//                        break;
//                    }

//                case 2:
//                    {
//                        num = (short)GetArgAsLong((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "WhiteInコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 531028


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            GUI.SaveScreen();
//            {
//                var withBlock = GUI.MainForm;
//                {
//                    var withBlock1 = withBlock.picTmp;
//                    withBlock1.Picture = Image.FromFile("");
//                    withBlock1.width = GUI.MainPWidth;
//                    withBlock1.Height = GUI.MainPHeight;
//                }

//                // MOD START マージ
//                // ret = BitBlt(.picTmp.hDC, _
//                // '            0, 0, MapPWidth, MapPHeight, _
//                // '            .picMain(0).hDC, 0, 0, SRCCOPY)
//                ret = GUI.BitBlt(withBlock.picTmp.hDC, 0, 0, GUI.MainPWidth, GUI.MainPHeight, withBlock.picMain(0).hDC, 0, 0, GUI.SRCCOPY);
//                // MOD END マージ

//                var argpic = withBlock.picMain(0);
//                Graphics.InitFade(ref argpic, num, true);
//                start_time = GeneralLib.timeGetTime();
//                wait_time = 50;
//                var loopTo = (int)num;
//                for (i = 0; i <= loopTo; i++)
//                {
//                    if (i % 4 == 0)
//                    {
//                        if (GUI.IsRButtonPressed())
//                        {
//                            break;
//                        }
//                    }

//                    var argpic1 = withBlock.picMain(0);
//                    Graphics.DoFade(ref argpic1, i);
//                    withBlock.picMain(0).Refresh();
//                    cur_time = GeneralLib.timeGetTime();
//                    while (cur_time < start_time + wait_time * (i + 1))
//                    {
//                        Application.DoEvents();
//                        cur_time = GeneralLib.timeGetTime();
//                    }
//                }

//                Graphics.FinishFade();

//                ret = GUI.BitBlt(withBlock.picMain(0).hDC, 0, 0, GUI.MapPWidth, GUI.MapPHeight, withBlock.picTmp.hDC, 0, 0, GUI.SRCCOPY);
//                withBlock.picMain(0).Refresh();

//                {
//                    var withBlock2 = withBlock.picTmp;
//                    withBlock2.Picture = Image.FromFile("");
//                    withBlock2.width = 32;
//                    withBlock2.Height = 32;
//                }
//            }

//            ExecWhiteInCmdRet = LineNum + 1;
//            return ExecWhiteInCmdRet;
//        }

//        private int ExecWhiteOutCmd()
//        {
//            int ExecWhiteOutCmdRet = default;
//            int cur_time, start_time, wait_time;
//            int i, ret;
//            short num;
//            switch (ArgNum)
//            {
//                case 1:
//                    {
//                        num = (short)10;
//                        break;
//                    }

//                case 2:
//                    {
//                        num = (short)GetArgAsLong((short)2);
//                        break;
//                    }

//                default:
//                    {
//                        Event_Renamed.EventErrorMessage = "WhiteOutコマンドの引数の数が違います";
//                        ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 536101


//                        Input:
//                                        Error(0)

//                         */
//                        break;
//                    }
//            }

//            GUI.SaveScreen();
//            {
//                var withBlock = GUI.MainForm;
//                var argpic = withBlock.picMain(0);
//                Graphics.InitFade(ref argpic, num, true);
//                start_time = GeneralLib.timeGetTime();
//                wait_time = 50;
//                var loopTo = (int)num;
//                for (i = 0; i <= loopTo; i++)
//                {
//                    if (i % 4 == 0)
//                    {
//                        if (GUI.IsRButtonPressed())
//                        {
//                            {
//                                var withBlock1 = withBlock.picMain(0);
//                                ret = GUI.PatBlt(withBlock1.hDC, 0, 0, withBlock1.width, withBlock1.Height, GUI.WHITENESS);
//                                withBlock1.Refresh();
//                            }

//                            break;
//                        }
//                    }

//                    var argpic1 = withBlock.picMain(0);
//                    Graphics.DoFade(ref argpic1, (int)num - i);
//                    withBlock.picMain(0).Refresh();
//                    cur_time = GeneralLib.timeGetTime();
//                    while (cur_time < start_time + wait_time * (i + 1))
//                    {
//                        Application.DoEvents();
//                        cur_time = GeneralLib.timeGetTime();
//                    }
//                }

//                Graphics.FinishFade();
//            }

//            GUI.IsPictureVisible = true;
//            GUI.PaintedAreaX1 = GUI.MainPWidth;
//            GUI.PaintedAreaY1 = GUI.MainPHeight;
//            GUI.PaintedAreaX2 = -1;
//            GUI.PaintedAreaY2 = -1;
//            ExecWhiteOutCmdRet = LineNum + 1;
//            return ExecWhiteOutCmdRet;
//        }

//        private int ExecWriteCmd()
//        {
//            int ExecWriteCmdRet = default;
//            short f;
//            short i;
//            if ((int)ArgNum < 3)
//            {
//                Event_Renamed.EventErrorMessage = "Writeコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 538676


//                Input:
//                            Error(0)

//                 */
//            }

//            f = (short)GetArgAsLong(2);
//            var loopTo = ArgNum;
//            for (i = 3; i <= loopTo; i++)
//                FileSystem.WriteLine(f, GetArgAsString(i));
//            ExecWriteCmdRet = LineNum + 1;
//            return ExecWriteCmdRet;
//        }

//        // Flashファイルの再生
//        private int ExecPlayFlashCmd()
//        {
//            int ExecPlayFlashCmdRet = default;
//            string fname;
//            short fw, fx, fy, fh;
//            short i;
//            string opt, buf;
//            if ((int)ArgNum < 6)
//            {
//                Event_Renamed.EventErrorMessage = "PlayFlashコマンドの引数の数が違います";
//                ;
//#error Cannot convert ErrorStatementSyntax - see comment for details
//                /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 539170


//                Input:
//                            Error(0)

//                 */
//            }

//            fname = GetArgAsString(2);
//            fw = (short)GetArgAsLong(5);
//            fh = (short)GetArgAsLong(6);
//            buf = GetArgAsString(3);
//            if (buf == "-")
//            {
//                fx = (short)((480 - fw) / 2d);
//            }
//            else
//            {
//                fx = Conversions.ToShort(buf);
//            }

//            buf = GetArgAsString(4);
//            if (buf == "-")
//            {
//                fy = (short)((480 - fh) / 2d);
//            }
//            else
//            {
//                fy = Conversions.ToShort(buf);
//            }

//            opt = "";
//            var loopTo = ArgNum;
//            for (i = 7; i <= loopTo; i++)
//                opt = opt + " " + GetArgAsString(i);
//            opt = Strings.Trim(opt);
//            Flash.PlayFlash(ref fname, ref fx, ref fy, ref fw, ref fh, ref opt);
//            ExecPlayFlashCmdRet = LineNum + 1;
//            return ExecPlayFlashCmdRet;
//        }

//        // Flashファイルの消去
//        private int ExecClearFlashCmd()
//        {
//            int ExecClearFlashCmdRet = default;
//            Flash.ClearFlash();
//            ExecClearFlashCmdRet = LineNum + 1;
//            return ExecClearFlashCmdRet;
//        }
//    }
//}
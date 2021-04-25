using Newtonsoft.Json;
using SRCCore.Expressions;
using SRCCore.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SRCCore
{
    public enum SRCSaveKind
    {
        Normal,
        Suspend,
        Quik,
        Restart,
    }
    public class SRCSaveData
    {
        public string Version { get; set; }
        public SRCSaveKind Kind { get; set; }
        public IList<string> Titles { get; set; }
        public string NextStage { get; set; }
        public int TotalTurn { get; set; }
        public int Money { get; set; }

        // XXX 列挙時の順番がDictionaryだと問題になるかも
        public IDictionary<string, VarData> GlobalVariableList;

        public Pilots.Pilots PList { get; set; }
        public Units.Units UList { get; set; }
        public Items.Items IList { get; set; }
    }

    public class SRCQuikSaveData : SRCSaveData
    {
        public string ScenarioFileName { get; set; }
        public int Turn { get; set; }
        //    Event.DumpEventData();
        //    Map.DumpMapData();

        //    // Midi じゃなくて midi じゃないと検索失敗するようになってるので。
        //    if (Strings.InStr(Strings.LCase(Sound.BGMFileName), @"\midi\") > 0)
        //    {
        //        FileSystem.WriteLine(SaveDataFileNumber, Strings.Mid(Sound.BGMFileName, Strings.InStr(Strings.LCase(Sound.BGMFileName), @"\midi\") + 6));
        //    }
        //    else if (Strings.InStr(Sound.BGMFileName, @"\") > 0)
        //    {
        //        FileSystem.WriteLine(SaveDataFileNumber, Strings.Mid(Sound.BGMFileName, Strings.InStr(Sound.BGMFileName, @"\") + 1));
        //    }
        //    else
        //    {
        //        FileSystem.WriteLine(SaveDataFileNumber, Sound.BGMFileName);
        //    }

        //    FileSystem.WriteLine(SaveDataFileNumber, (object)Sound.RepeatMode);
        //    FileSystem.WriteLine(SaveDataFileNumber, (object)Sound.KeepBGM);
        //    FileSystem.WriteLine(SaveDataFileNumber, (object)Sound.BossBGM);
        //    FileSystem.WriteLine(SaveDataFileNumber, (object)GeneralLib.RndSeed);
        //    FileSystem.WriteLine(SaveDataFileNumber, (object)GeneralLib.RndIndex);
    }

    public partial class SRC
    {
        // TODO セーブ・ロードの精査（まだとりあえず保存できるだけ）
        // データをセーブ
        public void SaveData(Stream stream)
        {
            try
            {
                var data = new SRCSaveData()
                {
                    // XXX EntryなのかCoreなのか
                    Version = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                    Kind = SRCSaveKind.Normal,
                    Titles = Titles,
                    NextStage = Expression.GetValueAsString("次ステージ"),
                    TotalTurn = TotalTurn,
                    Money = Money,
                    GlobalVariableList = Event.GlobalVariableList,
                    PList = PList,
                    UList = UList,
                    IList = IList,
                };

                stream.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data, Formatting.Indented)));
            }
            catch
            {
                GUI.ErrorMessage("セーブ中にエラーが発生しました");
            }
        }

        // データをロード
        public void LoadData(Stream stream)
        {
            try
            {
                // XXX Version プロパティだけのオブジェクトでバージョンチェックなど
                var data = JsonConvert.DeserializeObject<SRCSaveData>((new StreamReader(stream).ReadToEnd()));
                GUI.SetLoadImageSize((data.Titles.Count * 2 + 5));
                Titles = data.Titles;
                if (!Expression.IsGlobalVariableDefined("次ステージ"))
                {
                    Expression.DefineGlobalVariable("次ステージ");
                }
                Expression.SetVariableAsString("次ステージ", data.NextStage);
                TotalTurn = data.TotalTurn;
                Money = data.Money;
                Event.GlobalVariableList = data.GlobalVariableList;
                PList = data.PList;
                UList = data.UList;
                IList = data.IList;

                foreach (var title in Titles)
                {
                    IncludeData(title);
                }
                // XXX Dataフォルダ直下って読んでる？
                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\alias.txt"))
                //    {
                //        ALDList.Load(ScenarioPath + @"Data\alias.txt");
                //    }

                //    bool localFileExists() { string argfname = ScenarioPath + @"Data\mind.txt"; var ret = GeneralLib.FileExists(argfname); return ret; }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\sp.txt"))
                //    {
                //        SPDList.Load(ScenarioPath + @"Data\sp.txt");
                //    }
                //    else if (localFileExists())
                //    {
                //        SPDList.Load(ScenarioPath + @"Data\mind.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\pilot.txt"))
                //    {
                //        PDList.Load(ScenarioPath + @"Data\pilot.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\non_pilot.txt"))
                //    {
                //        NPDList.Load(ScenarioPath + @"Data\non_pilot.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\robot.txt"))
                //    {
                //        UDList.Load(ScenarioPath + @"Data\robot.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\unit.txt"))
                //    {
                //        UDList.Load(ScenarioPath + @"Data\unit.txt");
                //    }

                //    GUI.DisplayLoadingProgress();
                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\pilot_message.txt"))
                //    {
                //        MDList.Load(ScenarioPath + @"Data\pilot_message.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\pilot_dialog.txt"))
                //    {
                //        DDList.Load(ScenarioPath + @"Data\pilot_dialog.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\effect.txt"))
                //    {
                //        EDList.Load(ScenarioPath + @"Data\effect.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\animation.txt"))
                //    {
                //        ADList.Load(ScenarioPath + @"Data\animation.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\ext_animation.txt"))
                //    {
                //        EADList.Load(ScenarioPath + @"Data\ext_animation.txt");
                //    }

                //    if (GeneralLib.FileExists(ScenarioPath + @"Data\item.txt"))
                //    {
                //        IDList.Load(ScenarioPath + @"Data\item.txt");
                //    }

                GUI.DisplayLoadingProgress();
                IsLocalDataLoaded = true;

                PList.Restore(this);
                UList.Restore(this);
                IList.Restore(this);

                PList.Update();
                UList.Update();
                IList.Update();

                //    // リンクデータを処理するため、セーブファイルを一旦閉じてから再度読み込み
                //    PList.LoadLinkInfo();
                //    UList.LoadLinkInfo();
                //    IList.LoadLinkInfo();
                //    FileSystem.FileClose(SaveDataFileNumber);
                GUI.DisplayLoadingProgress();

                // ユニットの状態を回復
                foreach (Unit u in UList.Items)
                {
                    u.Reset();
                }
                GUI.DisplayLoadingProgress();

                // 追加されたシステム側イベントデータの読み込み
                Event.LoadEventData("", load_mode: "");
                GUI.DisplayLoadingProgress();
            }
            catch
            {
                GUI.ErrorMessage("ロード中にエラーが発生しました");
                TerminateSRC();
            }
        }

        public void DumpData(string fname, SRCSaveKind saveKind)
        {
            // XXX FileName
            LastSaveDataFileName = fname;
            using (var stream = new FileInfo(fname).Open(FileMode.Create))
            {
                DumpData(stream, saveKind);
            }
        }

        // 一時中断用データをファイルにセーブする
        public void DumpData(Stream stream, SRCSaveKind saveKind)
        {
            try
            {
                var data = new SRCQuikSaveData()
                {
                    // XXX EntryなのかCoreなのか
                    Version = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                    Kind = saveKind,
                    Titles = Titles,
                    NextStage = Expression.GetValueAsString("次ステージ"),
                    TotalTurn = TotalTurn,
                    Money = Money,
                    GlobalVariableList = Event.GlobalVariableList,
                    PList = PList,
                    UList = UList,
                    IList = IList,
                    // QuikSave
                    ScenarioFileName = ScenarioFileName,
                    Turn = Turn,
                };

                stream.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data, Formatting.Indented)));
                if (saveKind == SRCSaveKind.Restart)
                {
                    IsRestartSaveDataAvailable = true;
                }
                else if (saveKind == SRCSaveKind.Quik)
                {
                    IsQuickSaveDataAvailable = true;
                }
            }
            catch
            {
                GUI.ErrorMessage("セーブ中にエラーが発生しました");
            }

        }

        public void RestoreData(string fname, SRCSaveKind saveKind)
        {
            // XXX FileName
            LastSaveDataFileName = fname;
            using (var stream = File.OpenRead(fname))
            {
                RestoreData(stream, saveKind);
            }
        }
        // 一時中断用データをロード
        public void RestoreData(Stream stream, SRCSaveKind saveKind)
        {
            var quick_load = saveKind == SRCSaveKind.Quik || saveKind == SRCSaveKind.Restart;
            try
            {
                // マウスカーソルを砂時計に
                GUI.ChangeStatus(GuiStatus.WaitCursor);
                if (quick_load)
                {
                    if (Expression.IsOptionDefined("デバッグ"))
                    {
                        Event.LoadEventData(ScenarioFileName, "クイックロード");
                    }
                }
                if (!quick_load)
                {
                    GUI.OpenNowLoadingForm();
                }

                // XXX Version プロパティだけのオブジェクトでバージョンチェックなど
                var data = JsonConvert.DeserializeObject<SRCQuikSaveData>((new StreamReader(stream).ReadToEnd()));
                //        SaveDataVersion = Conversions.ToInteger(fname2);
                //    // ウィンドウのタイトルを設定
                //    if ((ScenarioFileName ?? "") != (ScenarioPath + fname2 ?? ""))
                //    {
                //        GUI.MainForm.Text = "SRC - " + Strings.Left(fname2, Strings.Len(fname2) - 4);
                //        ScenarioFileName = ScenarioPath + fname2;
                //        scenario_file_is_different = true;
                //    }
                // TODO scenario_file_is_different
                var scenario_file_is_different = true;
                GUI.SetLoadImageSize((data.Titles.Count * 2 + 5));
                Titles = data.Titles;
                TotalTurn = data.TotalTurn;
                Money = data.Money;
                Event.GlobalVariableList = data.GlobalVariableList;
                PList = data.PList;
                UList = data.UList;
                IList = data.IList;
                //
                ScenarioFileName = data.ScenarioFileName;
                Turn = data.Turn;

                // 使用するデータをロード
                if (!quick_load)
                {
                    GUI.SetLoadImageSize(data.Titles.Count * 2 + 5);
                    foreach (var title in Titles)
                    {
                        IncludeData(title);
                    }

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\alias.txt"))
                    //{
                    //    ALDList.Load(ScenarioPath + @"Data\alias.txt");
                    //}

                    //bool localFileExists() { string argfname = ScenarioPath + @"Data\mind.txt"; var ret = GeneralLib.FileExists(argfname); return ret; }

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\sp.txt"))
                    //{
                    //    SPDList.Load(ScenarioPath + @"Data\sp.txt");
                    //}
                    //else if (localFileExists())
                    //{
                    //    SPDList.Load(ScenarioPath + @"Data\mind.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\pilot.txt"))
                    //{
                    //    PDList.Load(ScenarioPath + @"Data\pilot.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\non_pilot.txt"))
                    //{
                    //    NPDList.Load(ScenarioPath + @"Data\non_pilot.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\robot.txt"))
                    //{
                    //    UDList.Load(ScenarioPath + @"Data\robot.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\unit.txt"))
                    //{
                    //    UDList.Load(ScenarioPath + @"Data\unit.txt");
                    //}

                    //GUI.DisplayLoadingProgress();
                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\pilot_message.txt"))
                    //{
                    //    MDList.Load(ScenarioPath + @"Data\pilot_message.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\pilot_dialog.txt"))
                    //{
                    //    DDList.Load(ScenarioPath + @"Data\pilot_dialog.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\effect.txt"))
                    //{
                    //    EDList.Load(ScenarioPath + @"Data\effect.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\animation.txt"))
                    //{
                    //    ADList.Load(ScenarioPath + @"Data\animation.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\ext_animation.txt"))
                    //{
                    //    EADList.Load(ScenarioPath + @"Data\ext_animation.txt");
                    //}

                    //if (GeneralLib.FileExists(ScenarioPath + @"Data\item.txt"))
                    //{
                    //    IDList.Load(ScenarioPath + @"Data\item.txt");
                    //}

                    GUI.DisplayLoadingProgress();
                    IsLocalDataLoaded = true;
                    Event.LoadEventData(ScenarioFileName, "リストア");
                    GUI.DisplayLoadingProgress();
                }
                else
                {
                    if (scenario_file_is_different)
                    {
                        Event.LoadEventData(ScenarioFileName, "リストア");
                    }
                }

                // TODO Impl RestoreEventData
                //Event.RestoreEventData();
                PList.Restore(this);
                IList.Restore(this);
                UList.Restore(this);

                PList.Update();
                UList.Update();
                IList.Update();

                //    // MOD START 240a
                //    // RestoreMapData
                //    // 'ＢＧＭ関連の設定を復元
                //    // Input #SaveDataFileNumber, fname2
                //    // マップデータの互換性維持のため、RestoreMapDataでＢＧＭ関連の１行目まで読み込んで戻り値にした
                //    fname2 = Map.RestoreMapData();
                //    // MOD  END  240a
                //    fname2 = Sound.SearchMidiFile("(" + fname2 + ")");
                //    if (!string.IsNullOrEmpty(fname2))
                //    {
                //        Sound.KeepBGM = false;
                //        Sound.BossBGM = false;
                //        Sound.ChangeBGM(fname2);
                //        FileSystem.Input(SaveDataFileNumber, Sound.RepeatMode);
                //        FileSystem.Input(SaveDataFileNumber, Sound.KeepBGM);
                //        FileSystem.Input(SaveDataFileNumber, Sound.BossBGM);
                //    }
                //    else
                //    {
                //        Sound.StopBGM();
                //        dummy = FileSystem.LineInput(SaveDataFileNumber);
                //        dummy = FileSystem.LineInput(SaveDataFileNumber);
                //        dummy = FileSystem.LineInput(SaveDataFileNumber);
                //    }

                //    // 乱数系列を復元
                //    if (!Expression.IsOptionDefined("デバッグ") & !Expression.IsOptionDefined("乱数系列非保存") & !FileSystem.EOF(SaveDataFileNumber))
                //    {
                //        FileSystem.Input(SaveDataFileNumber, GeneralLib.RndSeed);
                //        GeneralLib.RndReset();
                //        FileSystem.Input(SaveDataFileNumber, GeneralLib.RndIndex);
                //    }

                if (!quick_load)
                {
                    GUI.DisplayLoadingProgress();
                }

                //    FileSystem.FileClose(SaveDataFileNumber);

                //    // リンクデータを処理するため、セーブファイルを一旦閉じてから再度読み込み
                //    Event.SkipEventData();
                //    PList.RestoreLinkInfo();
                //    IList.RestoreLinkInfo();
                //    UList.RestoreLinkInfo();
                //    FileSystem.FileClose(SaveDataFileNumber);

                //    // パラメータ情報を処理するため、セーブファイルを一旦閉じてから再度読み込み。
                //    // 霊力やＨＰ、ＥＮといったパラメータは最大値が特殊能力で変動するため、
                //    // 特殊能力の設定が終わってから改めて設定してやる必要がある。

                //    Event.SkipEventData();
                //    PList.RestoreParameter();
                //    IList.RestoreParameter();
                //    UList.RestoreParameter();
                //    PList.UpdateSupportMod();

                //    // 背景書き換え
                //    int map_x, map_y;
                //    if (Map.IsMapDirty)
                //    {
                //        map_x = GUI.MapX;
                //        map_y = GUI.MapY;
                //        GUI.SetupBackground(Map.MapDrawMode, "非同期", filter_color: 0, filter_trans_par: 0d);
                //        GUI.MapX = map_x;
                //        GUI.MapY = map_y;

                //        // 再開イベントによるマップ画像の書き換え処理を行う
                //        Event.HandleEvent("再開");
                //        Map.IsMapDirty = false;
                //    }

                //    Commands.SelectedUnit = null;
                //    Commands.SelectedTarget = null;

                //    // ユニット画像生成
                //    foreach (Unit u in UList)
                //    {
                //        {
                //            var withBlock = u;
                //            if (withBlock.BitmapID == 0)
                //            {
                //                withBlock.BitmapID = GUI.MakeUnitBitmap(u);
                //            }
                //        }
                //    }

                // 画面更新
                GUI.Center(GUI.MapX, GUI.MapY);
                if (!quick_load)
                {
                    GUI.DisplayLoadingProgress();
                }

                if (!quick_load)
                {
                    GUI.CloseNowLoadingForm();
                }

                if (!quick_load)
                {
                    GUI.MainFormShow();
                }

                // マウスカーソルを元に戻す
                GUI.ChangeStatus(GuiStatus.Default);
                GUIStatus.ClearUnitStatus();
                if (!GUI.MainFormVisible)
                {
                    GUI.MainFormShow();
                    GUI.RefreshScreen();
                }

                GUI.RedrawScreen();
                if (Turn == 0)
                {
                    Event.HandleEvent("スタート");

                    // スタートイベントから次のステージが開始された場合、StartTurnが上のHandleEventで
                    // 実行されてしまう。
                    // 味方ターンの処理が２重起動されるのを防ぐため、Turnをチェックしてから起動する
                    if (Turn == 0)
                    {
                        StartTurn("味方");
                    }
                }
                else
                {
                    Commands.CommandState = "ユニット選択";
                    Stage = "味方";
                }
                if (saveKind == SRCSaveKind.Restart)
                {
                    IsRestartSaveDataAvailable = true;
                }
                else if (saveKind == SRCSaveKind.Quik)
                {
                    IsQuickSaveDataAvailable = true;
                }
            }
            catch
            {
                GUI.ErrorMessage("ロード中にエラーが発生しました");
                TerminateSRC();
            }
        }
    }
}

using SRCCore.Events;
using System;

namespace SRCCore.CmdDatas.Commands
{
    public class RecoverENCmd : CmdData
    {
        public RecoverENCmd(SRC src, EventDataLine eventData) : base(src, CmdType.RecoverENCmd, eventData)
        {
        }

        protected override int ExecInternal()
        {
            throw new NotImplementedException();
            //            Unit u;
            //            double per;
            //            switch (ArgNum)
            //            {
            //                case 3:
            //                    {
            //                        u = GetArgAsUnit(2, true);
            //                        per = GetArgAsDouble(3);
            //                        break;
            //                    }

            //                case 2:
            //                    {
            //                        u = Event.SelectedUnitForEvent;
            //                        per = GetArgAsDouble(2);
            //                        break;
            //                    }

            //                default:
            //                    {
            //                        Event.EventErrorMessage = "RecoverENコマンドの引数の数が違います";
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
            //                    if (withBlock.EN == 0 && withBlock.Status == "出撃")
            //                    {
            //                        GUI.PaintUnitBitmap(u);
            //                    }

            //                    withBlock.CheckAutoHyperMode();
            //                    withBlock.CheckAutoNormalMode();
            //                }
            //            }
            //return EventData.NextID;
        }
    }
}

using SRCCore.Events;
using System;

namespace SRCCore.CmdDatas.Commands
{
    public class ExchangeItemCmd : CmdData
    {
        public ExchangeItemCmd(SRC src, EventDataLine eventData) : base(src, CmdType.ExchangeItemCmd, eventData)
        {
        }

        protected override int ExecInternal()
        {
            throw new NotImplementedException();
            //            Unit u;
            //            var ipart = default(string);
            //            switch (ArgNum)
            //            {
            //                case 1:
            //                    {
            //                        u = Event.SelectedUnitForEvent;
            //                        break;
            //                    }

            //                case 2:
            //                    {
            //                        u = GetArgAsUnit(2);
            //                        break;
            //                    }

            //                case 3:
            //                    {
            //                        u = GetArgAsUnit(2);
            //                        ipart = GetArgAsString(3);
            //                        break;
            //                    }

            //                default:
            //                    {
            //                        Event.EventErrorMessage = "ExchangeItemコマンドの引数の数が違います";
            //                        ;
            //#error Cannot convert ErrorStatementSyntax - see comment for details
            //                        /* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error(0)' at character 235024


            //                        Input:
            //                                        Error(0)

            //                         */
            //                        break;
            //                    }
            //            }

            //            InterMission.ExchangeItemCommand(u, ipart);
            //return EventData.NextID;
        }
    }
}

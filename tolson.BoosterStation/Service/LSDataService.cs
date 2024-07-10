using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using tolson.BoosterStation.Adadpter;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.UI;
using tolson.BoosterStation.Util;
using xbd.DataConvertLib;

namespace tolson.BoosterStation.Service
{
    public class LSDataService : Singleton<LSDataService>
    { 

        public bool Init { get; set; }

        private LSDataService()
        {
        }

        public OperateResult<LSData> InitCard()
        {
            // 初始化轴卡
            short result = LTDMC.dmc_board_init();
            LSData lsData = new LSData();

            if(result <= 0 || result > 8)
            {
                return OperateResult.CreateFailResult<LSData>("没有找到轴卡");
            }

            ushort CardNum = 0;
            uint[] CardTypeList = new uint[8];
            ushort[] CardIdList = new ushort[8];
            // 获取卡信息
            result = LTDMC.dmc_get_CardInfList(ref CardNum, CardTypeList, CardIdList);

            if(result == 0)
            {
                lsData.CardNo = CardIdList[0];
                lsData.Version = Convert.ToString(CardTypeList[0], 16);
            }
            else
            {
                return OperateResult.CreateFailResult<LSData>("获取卡信息失败");
            }

            uint totalAxis = 0;
            // 获取轴数
            LTDMC.dmc_get_total_axes(CardIdList[0], ref totalAxis);

            if(result == 0)
            {
                lsData.TotalAxis = totalAxis;
                for(ushort i = 0; i < totalAxis; i++)
                {
                    lsData.Axies[i] = i;
                }
            }
            else
            {
                return OperateResult.CreateFailResult<LSData>("获取轴数失败");
            }

            Init = true;
            return OperateResult.CreateSuccessResult(lsData);
        }

        public OperateResult CloseCard()
        {
            short result = LTDMC.dmc_board_close();

            if(result == 0)
            {
                Init = false;
                return OperateResult.CreateSuccessResult();
            }
            else
            {
                return OperateResult.CreateFailResult("关闭卡失败");
            }
        }

        /// <summary>
        /// 设置运动参数
        /// </summary>
        /// <param name="axis">当前选择的轴</param>
        /// <param name="startVal">起始速度</param>
        /// <param name="stopVal">停止速度</param>
        /// <param name="val">运行速度</param>
        /// <param name="sPara">S段时间</param>
        /// <param name="tacc">加速时间</param>
        /// <param name="tdec">减速时间</param>
        public OperateResult SetMoveParameters(ushort carNo, ushort axis, double startVal, double stopVal, double val, double sPara, double tacc, double tdec)
        {
            if(Init)
            {
                // 设置s段时间
                short res = LTDMC.dmc_set_s_profile(carNo, axis, 0, sPara);

                if(res != 0)
                {
                    return OperateResult.CreateFailResult($"调用dmc_set_s_profile 异常,异常码：{res.ToString()}");
                }

                // 设置单轴运动速度曲线
                res = LTDMC.dmc_set_profile(carNo, axis, startVal, val, tacc, tdec, stopVal);
                if(res != 0)
                {
                    return OperateResult.CreateFailResult($"调用dmc_set_profile 异常,异常码：{res.ToString()}");
                }

                // 设置停止时间
                res = LTDMC.dmc_set_dec_stop_time(carNo, axis, tdec);
                if(res != 0)
                {
                    return OperateResult.CreateFailResult($"调用dmc_set_dec_stop_time 异常,异常码：{res.ToString()}");
                }

                return OperateResult.CreateSuccessResult();
            } else
            {
                return OperateResult.CreateFailResult("卡未初始化");
            }
        }

        public OperateResult Move(ushort carNo,ushort axis,int dist, ushort mode)
        {
            if(Init) {
                short res = LTDMC.dmc_pmove(carNo, axis, dist, mode);

                if(res != 0)
                {
                    return OperateResult.CreateFailResult($"调用dmc_pmove 异常,异常码：{res.ToString()}");
                }

                return OperateResult.CreateSuccessResult();
            } else
            {
                return OperateResult.CreateFailResult("卡未初始化");
            }
            
        }
    }
}

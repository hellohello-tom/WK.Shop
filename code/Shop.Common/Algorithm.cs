using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Common
{

    /// <summary>
    /// 信用评价管理 公共算法类
    /// 
    /// ThinkWang
    /// 2014-11-18
    /// </summary>
    public class Algorithm
    {
        /// <summary>
        /// 平均插值算法 
        /// 高分在前，低分在后
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static decimal[] GetAverageInterpolation(int count, decimal min = 60, decimal max = 100)
        {
            if (count > 1)
            {//1个以上才进行平均内插
                decimal avg = (max - min) / (count - 1);
                decimal[] result = new decimal[count];
                for (int i = 0; i < count; i++)
                {
                    result[i] = max - i * avg;
                }
                return result;
            }
            else
            {//小于1个，直接返回传来的最大值最小值
                return new decimal[] { max, min };
            }
        }

        /// <summary>
        /// 业主上报排名中，分值范围
        /// min在前，max在后
        /// </summary>
        /// <param name="count">标段个数</param>
        /// <returns></returns>
        public static decimal[] GetCorpMinMax(int count)
        {
            decimal max = 0M, min = 0M;
            if (count <= 1)
            {
                max = min = 0;
            }
            else if (count <= 3)
            {
                min = -1;
                max = 1;
            }
            else if (count <= 5)
            {
                min = -2;
                max = 2;
            }
            else
            {
                min = -3;
                max = 3;
            }
            return new decimal[] { min, max };
        }

        /// <summary>
        /// 获取等级所占的比例个数
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static decimal[] GetLevelCount(int count)
        {
            decimal[] arryCount = new decimal[4];//等级数组（AA  A  B  C  ）
            decimal[] percent = new decimal[4] { 0.25M, 0.3M, 0.35M, 0.1M };//所占比例
            decimal decimalPlace = 0;
            for (int i = 0; i < arryCount.Length; i++)
            {
                if (i != 0)
                {
                    arryCount[i] = Math.Floor(count * percent[i] + decimalPlace);
                    decimalPlace = (count * percent[i] + decimalPlace) - arryCount[i];//小数位

                }
                else
                {
                    arryCount[i] = Math.Floor(count * percent[i]);
                    decimalPlace = (count * percent[i]) - Math.Floor(count * percent[i]);//小数位
                }
            }
            return arryCount;
        }

        /// <summary>
        /// 根据投资额 加权平均 计算 业主得分
        /// </summary>
        /// <param name="segmentScoreList">decimal 折算系数,decimal 合同额,decimal 得分</param>
        /// <returns></returns>
        public static decimal GetWeightedAverage(List<SegmentScore> segmentScoreList)
        {
            var orderList = segmentScoreList.OrderBy(x => x.Score).OrderByDescending(x => x.Money).ToList();//得分最低且投资额最大的在前

            var score = (orderList.Sum(x => x.Ratio * x.Money * x.Score) + orderList[0].Ratio * orderList[0].Money * orderList[0].Score)
                / (orderList.Sum(x => x.Ratio * x.Money) + orderList[0].Ratio * orderList[0].Money);

            return score;
        }

        /// <summary>
        /// 标段得分实体
        /// </summary>
        public class SegmentScore
        {
            /// <summary>
            /// 折算系数
            /// </summary>
            public decimal Ratio { get; set; }
            /// <summary>
            /// 合同额
            /// </summary>
            public decimal Money { get; set; }
            /// <summary>
            /// 业主名次得分
            /// </summary>
            public decimal Score { get; set; }
        }
    }
}
